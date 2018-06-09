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

namespace AddNewPlayerForm {
    public partial class AddNewPlayerForm : Form {

        /***
         * AddNewPlayerForm Constructor
         * sets mForm
         **/
        public AddNewPlayerForm(mainForm _form) {
            InitializeComponent();
            mform = _form;
            
        }

        private mainForm mform;     //< mForm, Holds parent form


        /***
         * When Add Player Button is clicked
         * checks all input validation
         * if fail display appropriate error message
         * if pass converts date string into datetime
         * and adds players to mlistPlayer in mForm
         * closes ActiveForm
         **/
        private void AddPlayerButton_Click(object sender, EventArgs e) {         
            try {
                if (!ValidateID() && !ValidateName() && !ValidateDOB() && !ValidateHeight() &&
                  !ValidateWeight() && !ValidateBirthPlace() && !ValidateTeamName()) {
                    DateTime birthDate = DateTime.ParseExact(addPlayerBirthDateDayTextBox.Text + "/" + addPlayerBirthDateMonthTextBox.Text + "/" + addPlayerBirthDateYearTextBox.Text, "dd/MM/yyyy",
                                                                System.Globalization.CultureInfo.InvariantCulture);

                    Player tempPlayer = new Player(addPlayerIDTextBox.Text, addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text,
                                 birthDate, Convert.ToInt32(addPlayerHeightTextBox.Text), Convert.ToInt32(addPlayerWeightTextBox.Text),
                                addPlayerBirthPlaceTextBox.Text, addPlayerTeamNameTextBox.Text);

                    mform.ListPlayer.Add(tempPlayer);
             
                    foreach (Team x in mform.ListTeam) {
                        if (x.Name == addPlayerTeamNameTextBox.Text) {
                            x.Players.Add(addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text);
                            break;
                        }
                    }
                    ActiveForm.Close();
                }
            }
            catch {
                MessageBox.Show("Input is incorrect", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }



        /***
         * Checks input for ID
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateID() {
            if (mform.HasEmptyLine(addPlayerIDTextBox.Text, "ID")) return true;        
            if (mform.HasNonDigitCharacters(addPlayerIDTextBox.Text, "ID")) return true;
            foreach (Player x in mform.ListPlayer) {
                if (x.ID == addPlayerIDTextBox.Text) {
                    MessageBox.Show("ID " + x.ID + " is already in use\nPlease choose a different value", "Not Unique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        /***
         * Checks input for Name
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateName() {
            if (mform.HasEmptyLine(addPlayerLNameTextBox.Text, "Last Name") || mform.HasEmptyLine(addPlayerFNameTextBox.Text, "First Name")) return true;            
            string playerName = addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text;
            if (mform.HasTooManyChars(playerName, "Name")) return true;
            if (mform.HasNonAlphabet(addPlayerFNameTextBox.Text, "Name")) return true;
            return false;
        }


        /***
         * Checks input for Height
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateHeight() {
            if (mform.HasEmptyLine(addPlayerHeightTextBox.Text, "Height")) return true;
            if (mform.HasNonDigitCharacters(addPlayerHeightTextBox.Text, "Height")) return true;
            return false;
        }

        /***
         * Checks input for Weight
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateWeight() {
            if (mform.HasEmptyLine(addPlayerWeightTextBox.Text, "Weight")) return true;
            if (mform.HasNonDigitCharacters(addPlayerWeightTextBox.Text, "Weight")) return true;
            return false;
        }

        /***
         * Checks input for Birth Place
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateBirthPlace() {
            if (mform.HasEmptyLine(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;
            if (mform.HasTooManyChars(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;
            foreach (char x in addPlayerBirthPlaceTextBox.Text.ToLower()) {
                if ((x < 'a' || x > 'z') && (x != ' ' && x != ',')) {
                    MessageBox.Show("Birth Place found incorrect character\nonly (a-z, A-Z) are acceptable values", "Incorrect Character Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        /***
         * Checks input for TeamName
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateTeamName() {
            if (addPlayerTeamNameTextBox.Text == "") return false;
            foreach (Team x in mform.ListTeam) {
                if (x.Name.ToLower() == addPlayerTeamNameTextBox.Text.ToLower()) {
                    return false;
                }
            }
            MessageBox.Show("Team entered does not exist\nEnter already existing Team or leave empty", "Team Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }

        /***
         * Checks input for Date of Birth
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool ValidateDOB() {            
            if (mform.HasEmptyLine(addPlayerBirthDateDayTextBox.Text,"Birth Date") || mform.HasEmptyLine(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.HasEmptyLine(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }      
            if (mform.HasNonDigitCharacters(addPlayerBirthDateDayTextBox.Text, "Birth Date") || mform.HasNonDigitCharacters(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.HasNonDigitCharacters(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }
            if (ValidateDayMonthYear()) return true;
            return false;
        }

        /***
         * Checks if day, month and year strings are valid
         * returns true if not valid
         **/
        private bool ValidateDayMonthYear() {
            int day = Convert.ToInt32(addPlayerBirthDateDayTextBox.Text);
            int month = Convert.ToInt32(addPlayerBirthDateMonthTextBox.Text);
            int year = Convert.ToInt32(addPlayerBirthDateYearTextBox.Text);
            switch (month) {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (day > 31) {
                        DateError("day");
                        return true;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day > 30) {
                        DateError("day");
                        return true;
                    }
                    break;
                case 2:
                    if (IsLeapyear(year)) {
                        if (day > 29) {
                            DateError("day");
                            return true;
                        }
                    } else {
                        if (day > 28) {
                            DateError("day");
                            return true;
                        }
                    }
                    break;
                default:
                    DateError("month");
                    return true;
            }
            if (year > DateTime.Now.Year) {
                MessageBox.Show("Incorrect Year Value", "Year Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        
        /***
         * Calculates if passed year is a LeapYear
         * return true if Leap year
         * else return false
         **/
        private bool IsLeapyear(int _year) {
            if(_year % 400 == 0) {
                return true;
            }else if(_year % 100 == 0) {
                return false;
            }else if(_year % 4 == 0) {
                return true;
            }
            return false;
        }

        /***
         * Display a Warning Message 
         * About incorrect date input
         **/
        private void DateError(string _var) {
            MessageBox.Show("Birth Date " + _var +" incorrect\nenter valid date", "Incorrect Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
