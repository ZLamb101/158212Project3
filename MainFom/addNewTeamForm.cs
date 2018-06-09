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
    public partial class AddNewTeamForm : Form {

        /***
         * AddNewTeamForm Constructor
         * sets mForm
         **/        
        public AddNewTeamForm(mainForm _form ) {
            InitializeComponent();
            mForm = _form;
        }
        
        private mainForm mForm;     //< mForm, Holds parent form

        /***
         * When Add Team Button is clicked
         * checks all input validation
         * if fail display appropriate error message
         * if pass adds team to ListTeam in mForm
         * closes ActiveForm
         **/
        private void AddTeamButton_Click(object sender, EventArgs e) {
            try {
                if (!ValidateTeamName() && !ValidateGround() && !ValidateCoach() && !ValidateYearFounded() && !ValidateRegion()) {
                    Team tempTeam = new Team(addTeamNameTextBox.Text, addTeamGroundTextBox.Text,
                           addTeamCoachTextBox.Text, Convert.ToInt32(addTeamYearFoundedTextBox.Text), addTeamRegionTextBox.Text);
                    mForm.ListTeam.Add(tempTeam);

                    ActiveForm.Close();
                }
            }
            catch {
                MessageBox.Show("Input is incorrect", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /***
         * Checks input for TeamName
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateTeamName() {
            if (mForm.HasEmptyLine(addTeamNameTextBox.Text, "Team Name")) return true;         
            if (mForm.HasTooManyChars(addTeamNameTextBox.Text, "Team Name")) return true;
            if (mForm.HasNonAlphabet(addTeamNameTextBox.Text, "Team Name")) return true;
            foreach (Team x in mForm.ListTeam) {
                if (x.Name.ToLower() == addTeamNameTextBox.Text.ToLower()) {
                    MessageBox.Show("Team entered already exists\nEnter a Name that does not exist", "Team Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        /***
         * Checks input for Ground
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateGround() {
            if (mForm.HasEmptyLine(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mForm.HasTooManyChars(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mForm.HasNonAlphabet(addTeamGroundTextBox.Text, "Ground")) return true;         
            return false;
        }

        /***
         * Checks input for Coach
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateCoach() {
            if (mForm.HasEmptyLine(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mForm.HasTooManyChars(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mForm.HasNonAlphabet(addTeamCoachTextBox.Text, "Coach")) return true;     
            return false;
        }

        /***
         * Checks input for Year Founded
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateYearFounded() {
            if (mForm.HasEmptyLine(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
            if (mForm.HasNonDigitCharacters(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
            if (addTeamYearFoundedTextBox.Text.Count() != 4) {
                MessageBox.Show("Year Founded Input is invalid", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Convert.ToInt32(addTeamYearFoundedTextBox.Text) > DateTime.Now.Year) {
                MessageBox.Show("Incorrect Founded Year Value", "Founded Year Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        /***
         * Checks input for Region
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateRegion() {
            if (mForm.HasEmptyLine(addTeamRegionTextBox.Text, "Region")) return true;
            if (mForm.HasTooManyChars(addTeamRegionTextBox.Text, "Region")) return true;
            if (mForm.HasNonAlphabet(addTeamRegionTextBox.Text, "Region")) return true;
            return false;
        }

        
    }
}
