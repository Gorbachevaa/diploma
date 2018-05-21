using DataAccessLayer;
using DataAccessLayer.Persistance;
using MetroFramework.Controls;
using System;
using System.Linq;
using System.Windows.Forms;
using Models;

namespace DbGoView.View
{
    public partial class AddHumanStructForm : MetroFramework.Forms.MetroForm
    {
        public AddHumanStructForm()
        {
            InitializeComponent();
        }

        private void metroAddHumanStructButton_Click(object sender, EventArgs e)
        {
            HumanStruct currentHumanStruct = new HumanStruct();
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                if (this.Controls.OfType<MetroTextBox>().All(textBox => textBox.Text != String.Empty))
                {
                    currentHumanStruct.id = Int32.Parse(metroHumanStructIdTextBox.Text); 
                    currentHumanStruct.DB_Object_Symbol = metroGeneSymbolTextBox.Text;
                    currentHumanStruct.GOid = Int32.Parse(metroHumanStructGoIdTextBox.Text); 
                    Confirm confirm = new Confirm();
                    confirm.ShowDialog();
                    if (confirm.Result)
                    {
                        unitOfWork.HumanStructs.Add(currentHumanStruct);
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
