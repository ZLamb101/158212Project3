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
        public addNewPlayerForm(mainForm _form) {
            InitializeComponent();
            mform = _form;
        }

        private mainForm mform;

        private void Form1_Load(object sender, EventArgs e) {

        }

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
                    closeForm();
                }
            }
            catch {
                MessageBox.Show("Input is incorrect", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }


        private void closeForm() {
            ActiveForm.Close();
        }

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

        private bool validateName() {
            if (mform.hasEmptyLine(addPlayerLNameTextBox.Text, "Last Name") || mform.hasEmptyLine(addPlayerFNameTextBox.Text, "First Name")) return true;            
            string playerName = addPlayerFNameTextBox.Text + " " + addPlayerLNameTextBox.Text;
            if (mform.hasTooManyChars(playerName, "Name")) return true;
            if (mform.hasNonAlphabet(addPlayerFNameTextBox.Text, "Name")) return true;
            return false;
        }

        private bool validateDOB() {            
            if (mform.hasEmptyLine(addPlayerBirthDateDayTextBox.Text,"Birth Date") || mform.hasEmptyLine(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.hasEmptyLine(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }      
            if (mform.hasNonDigitCharacters(addPlayerBirthDateDayTextBox.Text, "Birth Date") || mform.hasNonDigitCharacters(addPlayerBirthDateMonthTextBox.Text, "Birth Date") || mform.hasNonDigitCharacters(addPlayerBirthDateYearTextBox.Text, "Birth Date")) {
                return true;
            }
            int day = Convert.ToInt32(addPlayerBirthDateDayTextBox.Text);
            int month = Convert.ToInt32(addPlayerBirthDateMonthTextBox.Text);
            int year = Convert.ToInt32(addPlayerBirthDateYearTextBox.Text);
            switch (month) {
                case 1: case 3: case 5:
                case 7: case 8: case 10:
                case 12:
                    if(day > 31) {
                        dateError();
                        return true;
                    }
                    break;
                case 4: case 6: case 9:
                case 11:
                    if(day > 30) {
                        dateError();
                        return true;
                    }
                    break;
                case 2:
                    if(isLeapyear(year)) {
                        if(day > 29) {
                            dateError();
                            return true;
                        }
                    } else {
                        if(day > 28) {
                            dateError();
                            return true;
                        }
                    }
                    break;
                default:
                    dateError();
                    return true;
            }
          
            if(year > DateTime.Now.Year) {
                MessageBox.Show("Incorrect Year Value", "Incorrect Year Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private void dateError() {
            MessageBox.Show("Birth Date incorrect\nenter valid date", "Incorrect Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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

        private bool validateHeight() {
            if (mform.hasEmptyLine(addPlayerHeightTextBox.Text, "Height")) return true;
            if (mform.hasNonDigitCharacters(addPlayerHeightTextBox.Text, "Height")) return true;           
            return false;
        }

        private bool validateWeight() {
            if (mform.hasEmptyLine(addPlayerWeightTextBox.Text, "Weight")) return true;
            if (mform.hasNonDigitCharacters(addPlayerWeightTextBox.Text, "Weight")) return true;          
            return false;
        }

        private bool validateBirthPlace() {
            if (mform.hasEmptyLine(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;
            if (mform.hasTooManyChars(addPlayerBirthPlaceTextBox.Text, "Birth Place")) return true;           
            foreach (char x in addPlayerBirthPlaceTextBox.Text.ToLower()) {
                if ((x < 'a' || x > 'z') && (x != ' ' || x!= ',') ) {
                    MessageBox.Show("Birth Place found incorrect character\nonly (a-z, A-Z) are acceptable values", "Incorrect Character Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        private bool validateTeamName() {
            foreach (Team x in mform.listTeam) {
                if (x.Name.ToLower() == addPlayerTeamNameTextBox.Text.ToLower()) {
                    return false;
                }
            }
            MessageBox.Show("Team entered does not exist\nEnter already existing Team or leave empty", "Team Non-Existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }

      
    }
}
