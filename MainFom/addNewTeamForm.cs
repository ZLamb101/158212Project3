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

        /***
         * AddNewTeamForm Constructor
         * sets mForm
         **/        
        public addNewTeamForm(mainForm _form ) {
            InitializeComponent();
            mForm = _form;
        }
        
        private mainForm mForm;     //< mForm, Holds parent form

        /***
         * When Add Team Button is clicked
         * checks all input validation
         * if fail display appropriate error message
         * if pass adds team to listTeam in mForm
         * closes ActiveForm
         **/
        private void addTeamButton_Click(object sender, EventArgs e) {
            try {
                if (!validateTeamName() && !validateGround() && !validateCoach() && !validateYearFounded() && !validateRegion()) {
                    Team tempTeam = new Team(addTeamNameTextBox.Text, addTeamGroundTextBox.Text,
                           addTeamCoachTextBox.Text, Convert.ToInt32(addTeamYearFoundedTextBox.Text), addTeamRegionTextBox.Text);
                    mForm.listTeam.Add(tempTeam);

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
        private bool validateTeamName() {
            if (mForm.hasEmptyLine(addTeamNameTextBox.Text, "Team Name")) return true;         
            if (mForm.hasTooManyChars(addTeamNameTextBox.Text, "Team Name")) return true;
            if (mForm.hasNonAlphabet(addTeamNameTextBox.Text, "Team Name")) return true;
            foreach (Team x in mForm.listTeam) {
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
        private bool validateGround() {
            if (mForm.hasEmptyLine(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mForm.hasTooManyChars(addTeamGroundTextBox.Text, "Ground")) return true;
            if (mForm.hasNonAlphabet(addTeamGroundTextBox.Text, "Ground")) return true;         
            return false;
        }

        /***
         * Checks input for Coach
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool validateCoach() {
            if (mForm.hasEmptyLine(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mForm.hasTooManyChars(addTeamCoachTextBox.Text, "Coach")) return true;
            if (mForm.hasNonAlphabet(addTeamCoachTextBox.Text, "Coach")) return true;     
            return false;
        }

        /***
         * Checks input for Year Founded
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool validateYearFounded() {
            if (mForm.hasEmptyLine(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
            if (mForm.hasNonDigitCharacters(addTeamYearFoundedTextBox.Text, "Year Founded")) return true;
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
        private bool validateRegion() {
            if (mForm.hasEmptyLine(addTeamRegionTextBox.Text, "Region")) return true;
            if (mForm.hasTooManyChars(addTeamRegionTextBox.Text, "Region")) return true;
            if (mForm.hasNonAlphabet(addTeamRegionTextBox.Text, "Region")) return true;
            return false;
        }

        
    }
}
