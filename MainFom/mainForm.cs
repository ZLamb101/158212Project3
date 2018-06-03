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


      


        private void teamsToolLoad_Click(object sender, EventArgs e) {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string line;
                while (reader.Peek() >= 0) {
                    line = reader.ReadLine();
                    listTeam.Add(stringToTeam(line));
                }
                reader.Close();
            }
        }

        private Team stringToTeam(string line) {
            List<string> words = new List<string>(line.Split(';'));

            List<string> tempTeamPlayerList = new List<string>();
            string displayPlayerString = "";
            for (int i = 5; i < words.Count; i++) {
                tempTeamPlayerList.Add(words[i]);
                if (i == 5) {
                    displayPlayerString = words[i];
                } else {
                    displayPlayerString += ", " + words[i];
                }
            }
            Team tempTeam = new Team(words[0], words[1], words[2], Convert.ToInt32(words[3]), words[4], tempTeamPlayerList);

            updateTeamListView(tempTeam, displayPlayerString);
            return tempTeam;
        }



        private void playersToolLoad_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string line;
                while (reader.Peek() >= 0) {
                    line = reader.ReadLine();
                    listPlayer.Add(stringToPlayer(line));

                }
                reader.Close();
            }
        }


        public Player stringToPlayer(string line) {
            List<string> words = new List<string>(line.Split(';'));
            Player tempPlayer;
            if(words.Count == 6) {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5]);
            } else {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5], words[6]);
            }        
            updatePlayerListView(tempPlayer);           
            return tempPlayer;
        }

        public void updatePlayerListView(Player tempPlayer) {
            ListViewItem item = new ListViewItem(new[] { tempPlayer.ID, tempPlayer.Name, Convert.ToString(tempPlayer.BirthDate), Convert.ToString(tempPlayer.Height), Convert.ToString(tempPlayer.Weight), tempPlayer.BirthPlace, tempPlayer.TeamName });
            playerListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempPlayer.Name, tempPlayer.TeamName });
            enrollPlayerListView.Items.Add(item2);
        }

        public void updateTeamListView(Team tempTeam, string displayPlayerString) {
            ListViewItem item = new ListViewItem(new[] { tempTeam.Name, tempTeam.Ground, tempTeam.Coach, Convert.ToString(tempTeam.YearFounded), tempTeam.Region, displayPlayerString });
            teamListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempTeam.Name });
            enrollTeamListView.Items.Add(item2);
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

        private void playersToolSave_Click(object sender, EventArgs e) {
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

        private void teamsToolSave_Click(object sender, EventArgs e) {
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
                updatePlayerListView(listPlayer[i+1]);
            }

        }

        private void gotoAddTeamButton_Click(object sender, EventArgs e) {
            int i = listTeam.Count - 1;
            addNewTeamForm form2 = new addNewTeamForm(this);
            form2.ShowDialog();

            if (listTeam.Count - 1 != i) {              
                updateTeamListView(listTeam[i+1], "");
            }
        }

        private void enrollmentButton_Click(object sender, EventArgs e) {
            if (playerSelectedEnrollmentTextBox.Text != "" && teamSelectedEnrollmentTextBox.Text != "") {
                for (int i = 0; i < listPlayer.Count; i++) {
                    if (playerSelectedEnrollmentTextBox.Text == listPlayer[i].Name) {                   
                        for (int j = 0; j < listTeam.Count; j++) {
                            if (teamSelectedEnrollmentTextBox.Text == listTeam[j].Name) {

                                if (listPlayer[i].TeamName != "") {
                                    unenrollPlayer(listPlayer[i]);
                                }

                                enrollPlayer(i,j);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
    

        public void enrollPlayer(int playerToEnroll, int teamToEnroll) {
            listTeam[teamToEnroll].Players.Add(listPlayer[playerToEnroll].Name);
            listPlayer[playerToEnroll].TeamName = listTeam[teamToEnroll].Name;
                              
            enrollPlayerListView.Items[playerToEnroll] = new ListViewItem(new[] { listPlayer[playerToEnroll].Name, listPlayer[playerToEnroll].TeamName });
            playerListView.Items[playerToEnroll] = new ListViewItem(new[] { listPlayer[playerToEnroll].ID, listPlayer[playerToEnroll].Name, Convert.ToString(listPlayer[playerToEnroll].BirthDate), Convert.ToString(listPlayer[playerToEnroll].Height), Convert.ToString(listPlayer[playerToEnroll].Weight), listPlayer[playerToEnroll].BirthPlace, listPlayer[playerToEnroll].TeamName });

            string displayPlayerString = teamPlayerStringFormat(teamToEnroll);
            teamListView.Items[teamToEnroll] = new ListViewItem(new[] { listTeam[teamToEnroll].Name, listTeam[teamToEnroll].Ground, listTeam[teamToEnroll].Coach, Convert.ToString(listTeam[teamToEnroll].YearFounded), listTeam[teamToEnroll].Region, displayPlayerString });
        }


        public void unenrollPlayer(Player playerToUnenroll) {
            for (int i = 0; i < listTeam.Count; i++) {
                if (listTeam[i].Name == playerToUnenroll.TeamName) {
                    listTeam[i].Players.Remove(playerToUnenroll.Name);

                    string displayRemovePlayerString = teamPlayerStringFormat(i);
                    
                    teamListView.Items[i] = new ListViewItem(new[] { listTeam[i].Name, listTeam[i].Ground, listTeam[i].Coach, Convert.ToString(listTeam[i].YearFounded), listTeam[i].Region, displayRemovePlayerString });
                }
            }
        }

        public string teamPlayerStringFormat(int teamToSetup) {
            string tempString = "";
            for (int i = 0; i < listTeam[teamToSetup].Players.Count; i++) {
                if (i == 0) {
                    tempString = listTeam[teamToSetup].Players[i];
                } else {
                    tempString += ", " + listTeam[teamToSetup].Players[i];
                }
            }
            return tempString;
        }

        private void searchButton_Click(object sender, EventArgs e) {
            searchListView.Items.Clear();
            if(searchTextBox.Text != "") {
                
                if(ageRadioButton.Checked) {
                    int searchAge = Convert.ToInt32(searchTextBox.Text);

                    IEnumerable<Player> playerAgeListQuery =
                        from i in listPlayer
                        where i.getAge() == searchAge
                        //where i.BirthDate.Year == DateTime.Now.Year - searchAge
                        select i;

                    foreach (Player x in playerAgeListQuery) {
                        ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                        searchListView.Items.Add(newSearchItem);
                    }

                } else {
                    string searchLocation = searchTextBox.Text;

                    IEnumerable<Player> playerBPListQuery =
                        from i in listPlayer
                        where i.BirthPlace == searchLocation || i.BirthPlace == searchLocation + ", New Zealand"
                        select i;

                    foreach (Player x in playerBPListQuery) {
                        ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString( x.BirthDate),Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName});                      
                        searchListView.Items.Add(newSearchItem);
                    }
                   
                

                   //playerListQuery.
                }

              



            }
        }
    }
}
