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
    public partial class addNewPlayerForm : Form {

        /***
         * AddNewPlayerForm Constructor
         * sets mForm
         **/
        public addNewPlayerForm(mainForm _form) {
            InitializeComponent();
            mform = _form;
            
        }

        private mainForm mform;     //< mForm, Holds parent form


        /***
         * When Add Player Button is clicked
         * checks all input validation
         * if fail display appropriate error message
         * if pass converts date string into datetime
         * and adds players to listPlayer in mForm
         * closes ActiveForm
         **/
        private void AddPlayerButton_Click(object sender, EventArgs e) {         
            try {
                if (!validateID() && !validateName() && !validateDOB() && !validateHeight() &&
                  !validateWeight() && !validateBirthPlace() && !validateTeamName()) {
                    DateTime birthDate = DateTime.ParseExact(addPlayerBirthDateDayTextBox.Text + "/" + addPlayerBirthDateMonthTextBox.Text + "/" + addPlayerBirthDateYearTextBox.Text, "dd/MM/yyyy",
                                                                System.Globalization.CultureInfo.InvariantCulture);

                    Player tempPlayer = new Player(addPlayerIDTextBox.Text, addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text,
                                 birthDate, Convert.ToInt32(addPlayerHeightTextBox.Text), Convert.ToInt32(addPlayerWeightTextBox.Text),
                                addPlayerBirthPlaceTextBox.Text, addPlayerTeamNameTextBox.Text);

                    mform.listPlayer.Add(tempPlayer);
                    foreach (Team x in mform.listTeam) {
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
        private bool validateID() {
            if (mform.hasEmptyLine(addPlayerIDTextBox.Text, "ID")) return true;        
            if (mform.hasNonDigitCharacters(addPlayerIDTextBox.Text, "ID")) return true;
            foreach (Player x in mform.listPlayer) {
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
        private bool validateName() {
            if (mform.hasEmptyLine(addPlayerLNameTextBox.Text, "Last Name") || mform.hasEmptyLine(addPlayerFNameTextBox.Text, "First Name")) return true;            
            string playerName = addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text;
            if (mform.hasTooManyChars(playerName, "Name")) return true;
            if (mform.hasNonAlphabet(addPlayerFNameTextBox.Text, "Name")) return true;
            return false;
        }


        /***
         * Checks input for Height
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool validateHeight() {
            if (mform.hasEmptyLine(addPlayerHeightTextBox.Text, "Height")) return true;
            if (mform.hasNonDigitCharacters(addPlayerHeightTextBox.Text, "Height")) return true;
            return false;
        }

        /***
         * Checks input for Weight
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool validateWeight() {
            if (mform.hasEmptyLine(addPlayerWeightTextBox.Text, "Weight")) return true;
            if (mform.hasNonDigitCharacters(addPlayerWeightTextBox.Text, "Weight")) return true;
            return false;
        }

        /***
         * Checks input for Birth Place
         * if fails validation returns true(it failed)
         * else returns false(it passed)
         **/
        private bool validateBirthPlace() {
            if (mform.hasEmptyLine(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;
            if (mform.hasTooManyChars(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;
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
        private bool validateTeamName() {
            foreach (Team x in mform.listTeam) {
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
        private bool validateDOB() {            
            if (mform.hasEmptyLine(addPlayerBirthDateDayTextBox.Text,"Birth Date") || mform.hasEmptyLine(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.hasEmptyLine(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }      
            if (mform.hasNonDigitCharacters(addPlayerBirthDateDayTextBox.Text, "Birth Date") || mform.hasNonDigitCharacters(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.hasNonDigitCharacters(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }
            if (validateDayMonthYear()) return true;
            return false;
        }

        /***
         * Checks if day, month and year strings are valid
         * returns true if not valid
         **/
        private bool validateDayMonthYear() {
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
                        dateError("day");
                        return true;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day > 30) {
                        dateError("day");
                        return true;
                    }
                    break;
                case 2:
                    if (isLeapyear(year)) {
                        if (day > 29) {
                            dateError("day");
                            return true;
                        }
                    } else {
                        if (day > 28) {
                            dateError("day");
                            return true;
                        }
                    }
                    break;
                default:
                    dateError("month");
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
         * return true if Leapyear
         * else return false
         **/
        private bool isLeapyear(int _year) {
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
        private void dateError(string _var) {
            MessageBox.Show("Birth Date " + _var +" incorrect\nenter valid date", "Incorrect Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
