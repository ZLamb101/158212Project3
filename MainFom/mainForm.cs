using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AddNewPlayerForm;
using AddNewTeamForm;
using Assignment3;

namespace MainForm {
    public partial class mainForm : Form {

        public RugbyUnion rugbyUnion = new RugbyUnion();
        public List<Team> listTeam = new List<Team>();
        public List<Player> listPlayer = new List<Player>();

        public mainForm() {
            InitializeComponent();
        }


        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {

        }


        private void teamsToolStripMenuItem_Click(object sender, EventArgs e) {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string line;
                while (reader.Peek() >= 0) {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                    listTeam.Add(stringToTeam(line));
                   
                    
                }
                reader.Close();
            }
        }

        private Team stringToTeam(string line) {
            List<string> words = new List<string>(line.Split(';'));
           
            Team tempTeam = new Team(words[0], words[1], words[2], Convert.ToInt32(words[3]),words[4] );
            

            ListViewItem item = new ListViewItem(new[] { tempTeam.Name, tempTeam.Ground, tempTeam.Coach, Convert.ToString(tempTeam.YearFounded),  tempTeam.Region});
            teamListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempTeam.Name });
            enrollTeamListView.Items.Add(item2);
            return tempTeam;
        }

 

        private void playersToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string line;
                while (reader.Peek() >= 0) {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                    listPlayer.Add(stringToPlayer(line));
                    
                }
                reader.Close();
            }
        }    


        public Player stringToPlayer(string line) {
            List<string> words = new List<string>(line.Split(';'));
            Player tempPlayer;
            switch (words.Count) {
                case 6:
                    tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5]);
                    break;
                default:
                    tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5], words[6]);
                    break;
            }
           

            ListViewItem item = new ListViewItem(new[] { tempPlayer.ID, tempPlayer.Name , Convert.ToString(tempPlayer.BirthDate), Convert.ToString(tempPlayer.Height), Convert.ToString(tempPlayer.Weight),tempPlayer.BirthPlace, tempPlayer.TeamName});
            playerListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempPlayer.Name, tempPlayer.TeamName });
     
            enrollPlayerListView.Items.Add(item2);
            return tempPlayer;
        }

      


     

        public void enrollPlayerListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < listPlayer.Count; i++) {
                if (enrollPlayerListView.Items[i].Selected) {
                    playerSelectedEnrollmentTextBox.Text = listPlayer[i].Name;
                    break;
                }
            }
        }

        public void enrollTeamListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < listTeam.Count; i++) {
                if (enrollTeamListView.Items[i].Selected) {
                    teamSelectedEnrollmentTextBox.Text = listTeam[i].Name;
                    break;
                }
            }
        }

        private void playersToolStripMenuItem1_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "SavePlayerList.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK) {
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                int i = 0;
                for (i = 0; i < listPlayer.Count; i++) {
                    writer.WriteLine(listPlayer[i].saveString());
                }
                writer.Close();
            }

        }

        private void teamsToolStripMenuItem1_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "SaveTeamList.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK) {
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                int i = 0;
                for (i = 0; i < listTeam.Count; i++) {
                    writer.WriteLine(listTeam[i].saveString());
                }
                writer.Close();
            }
        }

        private void gotoAddPlayerButton_Click(object sender, EventArgs e) {
            int i = listPlayer.Count - 1;
            addNewPlayerForm form2 = new addNewPlayerForm(this);
            form2.ShowDialog();
            if (listPlayer.Count - 1 != i) {
                ListViewItem item = new ListViewItem(new[] { listPlayer[i].ID, listPlayer[i].Name, Convert.ToString(listPlayer[i].BirthDate), Convert.ToString(listPlayer[i].Height), Convert.ToString(listPlayer[i].Weight), listPlayer[i].BirthPlace, listPlayer[i].TeamName });
                playerListView.Items.Add(item);
                ListViewItem item2 = new ListViewItem(new[] { listPlayer[i].Name, listPlayer[i].TeamName });
                enrollPlayerListView.Items.Add(item2);
            }
           
        }

        private void gotoAddTeamButton_Click(object sender, EventArgs e) {
            int i = listTeam.Count - 1;
            addNewTeamForm form2 = new addNewTeamForm(this);
            form2.ShowDialog();
         
            if (listTeam.Count - 1 != i) {
                ListViewItem item = new ListViewItem(new[] { listTeam[i].Name, listTeam[i].Ground, listTeam[i].Coach, Convert.ToString(listTeam[i].YearFounded), listTeam[i].Region });
                teamListView.Items.Add(item);

                ListViewItem item2 = new ListViewItem(new[] { listTeam[i].Name });
                enrollTeamListView.Items.Add(item2);
            }
        }

        private void enrollmentButton_Click(object sender, EventArgs e) {
            if(playerSelectedEnrollmentTextBox.Text != "" && teamSelectedEnrollmentTextBox.Text != "") {

                for (int i = 0; i < listPlayer.Count; i++) {
                    if (playerSelectedEnrollmentTextBox.Text == listPlayer[i].Name) {

                        for (int j = 0; j < listTeam.Count; j++) {
                            if (teamSelectedEnrollmentTextBox.Text == listTeam[j].Name) {
                                ListViewItem item2 = new ListViewItem(new[] { listPlayer[i].Name, listPlayer[i].TeamName });
                                enrollPlayerListView.Items.Remove(item2);
                                enrollPlayerListView.Refresh();
                                listPlayer[i].TeamName = listTeam[j].Name;
                                item2 = new ListViewItem(new[] { listPlayer[i].Name, listPlayer[i].TeamName });
                                enrollPlayerListView.Items.Add(item2);
                                // Doesnt work! Get help

                                break;

                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}
