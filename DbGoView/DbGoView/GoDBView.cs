using DataAccessLayer;
using DataAccessLayer.Persistance;
using DbGoView.View;
using MetroFramework.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DbGoView
{
    public partial class GoDBView : MetroFramework.Forms.MetroForm
    {
        public const int TERMS_AMOUNT = 100;
        public GoDBView()
        {
            InitializeComponent();
            this.Load += LoadGoTermGridEvent;
            this.Load += LoadHumanStructGridEvent;
            this.Load += LoadGoTermVsGeneSymbolGridEvent;
            this.Load += LoadIsAGridEvent;
            this.Load += LoadPartOfGridEvent;
        }

        /// <summary>
        /// Shows GoTerms in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadGoTermGridEvent(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var goTerms = unitOfWork.GoTerms.GetTopTerms(TERMS_AMOUNT);
                foreach (var goTerm in goTerms)
                {
                    metroGoTermsGrid.Rows.Add(goTerm.GO_ID,
                                              goTerm.name,
                                              goTerm.Go_definition,
                                              goTerm.ontology);
                }
            }
        }
        /// <summary>
        /// Shows Human Structs in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadHumanStructGridEvent(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var humanStructs = unitOfWork.HumanStructs.GetTopHumanStruct(TERMS_AMOUNT);
                metroHumanStructGrid.Rows.AddRange();
                foreach (var humanStruct in humanStructs)
                {
                    metroHumanStructGrid.Rows.Add(humanStruct.id,
                                              humanStruct.DB_Object_Symbol,
                                              humanStruct.GOid);
                }
            }
        }
        public void LoadGoTermVsGeneSymbolGridEvent(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var humanStructs = unitOfWork.HumanStructs.GetTopHumanStruct(TERMS_AMOUNT);

                foreach (var humanStruct in humanStructs)
                {
                    var goTerms = unitOfWork.GoTerms.GetById(humanStruct.GOid);
                    foreach (var goTerm in goTerms)
                    {
                        metroGeneSymbolsGrid.Rows.Add(goTerm.GO_ID,
                                              humanStruct.DB_Object_Symbol,
                                              goTerm.name,
                                              goTerm.Go_definition);
                    }
                }
            }
        }
        public void LoadIsAGridEvent(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var isAs = unitOfWork.IsAs.GetTopIsAs(TERMS_AMOUNT);
                foreach (var isA in isAs)
                {
                    metroIsAGrid.Rows.Add(isA.id_term,
                                          isA.GOid);
                }
            }
        }
        public void LoadPartOfGridEvent(object sender, EventArgs e)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var partOfs = unitOfWork.PartOfs.GetTopPartOfs(TERMS_AMOUNT);

                foreach (var partOf in partOfs)
                {
                    metroPartOfGrid.Rows.Add(partOf.id_term,
                                          partOf.GOid);
                }
            }
        }
        private void metroSearchTermButton_Click(object sender, EventArgs e)
        {
            Search(metroGoTermsGrid, metroTextTermBox);
            
        }

        private void metroHumanStructSearchButton_Click(object sender, EventArgs e)
        {
            Search(metroHumanStructGrid, metroHumanStructTextBox);
        }

        private void metroAddTermButton_Click(object sender, EventArgs e)
        {
            new AddGoTermsForm().Show();
        }

        private void metroAddHumanStructButton_Click(object sender, EventArgs e)
        {
            new AddHumanStructForm().Show();
        }

        private void metroSearchGeneButton_Click(object sender, EventArgs e)
        {
            Search(metroGeneSymbolsGrid, metroGoVSGeneTextBox);
        }

        private void metroFindGeneTile_Click(object sender, EventArgs e)
        {
            metroGoDBTabControl.SelectedTab = metroGoDBTabControl.TabPages["metroGoWithGenePage"];
        }

        private void metroShowTermsTile_Click(object sender, EventArgs e)
        {
            metroGoDBTabControl.SelectedTab = metroGoDBTabControl.TabPages["metroTabGoTermsPage"];
        }

        private void metroRelationsTile_Click(object sender, EventArgs e)
        {
            metroGoDBTabControl.SelectedTab = metroGoDBTabControl.TabPages["metroRelationsTabPage"];
        }
        private void metroSearchRealtionsButton_Click(object sender, EventArgs e)
        {
            SearchRelations(metroIsAGrid, metroFindRelationsTextBox);
            SearchRelations(metroPartOfGrid, metroFindRelationsTextBox);
        }

        private void metroAboutUsTile_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Developed by Anna Gorbacheva.");
        }

        private void metroSearchRelationsButton_Click(object sender, EventArgs e)
        {
            if (metroGoTermsGrid.CurrentCell == null)
            {
                MessageBox.Show(@"Choose the term!");
            }
            else
            {
                using (var unitOfWork = new UnitOWork(new GoDBContext()))
                {
                    foreach (DataGridViewRow row in metroGoTermsGrid.Rows)
                    {
                        if (row.Selected)
                        {
                            var goTerms = unitOfWork.GoTerms.
                                GetById(Int32.Parse(row.Cells[0].Value.ToString()));
                            MetroTextBox txt = new MetroTextBox();
                            txt.Text = row.Cells[0].Value.ToString();
                            metroGoDBTabControl.SelectedTab = metroGoDBTabControl.
                                TabPages["metroRelationsTabPage"];
                            SearchRelations(metroIsAGrid, txt);
                            SearchRelations(metroPartOfGrid, txt);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Search elements in the grid by textbox.
        /// </summary>
        /// <param name="gridViewRow">DataGridView</param>
        /// <param name="textBox">Value of textbox</param>
        private void Search(MetroGrid gridViewRow, MetroTextBox textBox)
        {
            gridViewRow.CurrentCell = null;
            foreach (DataGridViewRow row in gridViewRow.Rows)
            {
                row.Visible = true;
            }
            foreach (DataGridViewRow row in gridViewRow.Rows)
            {
                if (row.Visible)
                {
                    row.Visible = row.Cells[1].Value.ToString().Contains(textBox.Text);
                }
            }
        }
        private void SearchRelations(MetroGrid gridViewRow, MetroTextBox textBox)
        {
            gridViewRow.CurrentCell = null;
            foreach (DataGridViewRow row in gridViewRow.Rows)
            {
                row.Visible = true;
            }
            foreach (DataGridViewRow row in gridViewRow.Rows)
            {
                if (row.Visible)
                {
                    row.Visible = row.Cells[0].Value.ToString().Equals(textBox.Text);
                }
            }
            if (textBox.Text == String.Empty)
            {
                foreach (DataGridViewRow row in gridViewRow.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
