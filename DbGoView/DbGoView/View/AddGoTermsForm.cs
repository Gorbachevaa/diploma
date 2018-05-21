using DataAccessLayer;
using DataAccessLayer.Persistance;
using MetroFramework.Controls;
using System;
using System.Linq;
using System.Windows.Forms;
using Models;

namespace DbGoView.View
{
    public partial class AddGoTermsForm : MetroFramework.Forms.MetroForm
    {
        public AddGoTermsForm()
        {
            InitializeComponent();
        }

        private void metroAddGoTermButton_Click(object sender, EventArgs e)
        {
            GoTerm currentGoTerm = new GoTerm();
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                if (this.Controls.OfType<MetroTextBox>().All(textBox => textBox.Text != String.Empty))
                {
                    currentGoTerm.GO_ID = Int32.Parse(metroGoIdTextBox.Text);
                    currentGoTerm.name = metroNameTextBox.Text;
                    currentGoTerm.Go_definition = metroDefinitionTextBox.Text;
                    currentGoTerm.ontology = metroOntologyTextBox.Text;
                    Confirm confirm = new Confirm();
                    confirm.ShowDialog();
                    if (confirm.Result)
                    {
                        unitOfWork.GoTerms.Add(currentGoTerm);
                        unitOfWork.Complete();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"Invalid input values");
                }
            }
        }
    }
}
