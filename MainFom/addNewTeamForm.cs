using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3;
using MainForm;


namespace AddNewTeamForm {
    public partial class addNewTeamForm : Form {
        public addNewTeamForm(mainForm _form ) {
            InitializeComponent();
            mform = _form;
        }
        private mainForm mform;

        private void addTeamButton_Click(object sender, EventArgs e) {
            Team tempTeam = new Team(addTeamNameTextBox.Text, addTeamGroundTextBox.Text,
                            addTeamCoachTextBox.Text, Convert.ToInt32(addTeamYearFoundedTextBox.Text), addTeamRegionTextBox.Text);
            mform.listTeam.Add(tempTeam);

            Close();
        }

        private void closeForm() {
            ActiveForm.Close();
        }

        private void addTeamGroundTextBox_TextChanged(object sender, EventArgs e) {

        }
    }
}
