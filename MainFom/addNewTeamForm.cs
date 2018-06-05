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

            try {
                if (!validateTeamName() && !validateGround() && !validateCoach() && !validateYearFounded() && !validateRegion()) {
                    Team tempTeam = new Team(addTeamNameTextBox.Text, addTeamGroundTextBox.Text,
                           addTeamCoachTextBox.Text, Convert.ToInt32(addTeamYearFoundedTextBox.Text), addTeamRegionTextBox.Text);
                    mform.listTeam.Add(tempTeam);

                    Close();
                }
            }
            catch {
                MessageBox.Show("Input is incorrect", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeForm() {
            ActiveForm.Close();
        }

        private bool validateTeamName() {
            if (mform.hasEmptyLine(addTeamNameTextBox.Text, "Team Name")) return true;         
            if (mform.hasTooManyChars(addTeamNameTextBox.Text, "Team Name")) return true;
            if (mform.hasNonAlphabet(addTeamNameTextBox.Text, "Team Name")) return true;
            foreach (Team x in mform.listTeam) {
                if (x.Name.ToLower() == addTeamNameTextBox.Text.ToLower()) {
                    MessageBox.Show("Team entered already exists\nEnter a Name that does not exist", "Team Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        private bool validateGround() {
            if (mform.hasEmptyLine(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mform.hasTooManyChars(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mform.hasNonAlphabet(addTeamGroundTextBox.Text, "Ground")) return true;         
            return false;
        }

        private bool validateCoach() {
            if (mform.hasEmptyLine(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mform.hasTooManyChars(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mform.hasNonAlphabet(addTeamCoachTextBox.Text, "Coach")) return true;     
            return false;
        }

        private bool validateYearFounded() {
            if (mform.hasEmptyLine(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
            if (mform.hasNonDigitCharacters(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
            if (addTeamYearFoundedTextBox.Text.Count() != 4) {
                MessageBox.Show("Year Founded Input is invalid", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private bool validateRegion() {
            if (mform.hasEmptyLine(addTeamRegionTextBox.Text, "Region")) return true;
            if (mform.hasTooManyChars(addTeamRegionTextBox.Text, "Region")) return true;
            if (mform.hasNonAlphabet(addTeamRegionTextBox.Text, "Region")) return true;
            return false;
        }

    }
}
