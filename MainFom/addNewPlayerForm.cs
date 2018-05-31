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

        public mainForm mform;

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void AddPlayerButton_Click(object sender, EventArgs e) {
            Player tempPlayer = new Player(addPlayerIDTextBox.Text, addPlayerFNameTextBox.Text + addPlayerLNameTextBox.Text,
                                 Convert.ToDateTime(addPlayerBirthDateTextBox.Text), Convert.ToInt32(addPlayerHeightTextBox.Text), Convert.ToInt32(addPlayerWeightTextBox.Text), 
                                addPlayerBirthPlaceTextBox.Text, addPlayerTeamNameTextBox.Text);

            mform.listPlayer.Add(tempPlayer);
            
            closeForm();
        }


        private void closeForm() {
            ActiveForm.Close();
        }
    }
}
