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

            try {
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
            catch {

            }

            
        }

        private Team stringToTeam(string line) {            
            List<string> tempTeamPlayerList = new List<string>();
            List<string> words = new List<string>(line.Split(';'));
            if (words.Count != 5) throw new FileLoadException();
            Team tempTeam = new Team(words[0], words[1], words[2], Convert.ToInt32(words[3]), words[4]);

            updateTeamListView(tempTeam);
            return tempTeam;
        }



        private void playersToolLoad_Click(object sender, EventArgs e) {
            if (listTeam.Count == 0) {
                MessageBox.Show("Are you sure you want to load players before teams\nPlayers will be unassigned from their team if the\n team does not exist", "Loading Players Before Teams", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try {
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
            catch {

            }
        }


        public Player stringToPlayer(string line) {
            List<string> words = new List<string>(line.Split(';'));
            if (words.Count < 6) throw new FileLoadException();
            Player tempPlayer;
            if(words.Count == 6) {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5]);
            } else {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5], words[6]);
                for(int i=0;i < listTeam.Count; i++) {
                    if(listTeam[i].Name == tempPlayer.TeamName) {
                        listTeam[i].Players.Add(tempPlayer.Name);
                        break;
                    }
                    if(i == listTeam.Count - 1) tempPlayer.TeamName = "";
                }
            }
         
            updatePlayerListView(tempPlayer);           
            return tempPlayer;
        }

        public void updatePlayerListView(Player tempPlayer) {
            ListViewItem item = new ListViewItem(new[] { tempPlayer.ID, tempPlayer.Name, Convert.ToString(tempPlayer.BirthDate), Convert.ToString(tempPlayer.Height), Convert.ToString(tempPlayer.Weight), tempPlayer.BirthPlace, tempPlayer.TeamName });
            playerListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempPlayer.Name, tempPlayer.TeamName });
            enrollPlayerListView.Items.Add(item2);

            HeightvsWeightChart.Series["Height"].Points.AddXY(tempPlayer.Name, tempPlayer.Height);
            HeightvsWeightChart.Series["Weight"].Points.AddXY(tempPlayer.Name, tempPlayer.Weight);

            
            AgeChart.Series["Age"].Points.AddY(tempPlayer.getAge());
        }

        public void updateTeamListView(Team tempTeam) {
            ListViewItem item = new ListViewItem(new[] { tempTeam.Name, tempTeam.Ground, tempTeam.Coach, Convert.ToString(tempTeam.YearFounded), tempTeam.Region});
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
                updateTeamListView(listTeam[i+1]);
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
            
            teamListView.Items[teamToEnroll] = new ListViewItem(new[] { listTeam[teamToEnroll].Name, listTeam[teamToEnroll].Ground, listTeam[teamToEnroll].Coach, Convert.ToString(listTeam[teamToEnroll].YearFounded), listTeam[teamToEnroll].Region });
        }


        public void unenrollPlayer(Player playerToUnenroll) {
            for (int i = 0; i < listTeam.Count; i++) {
                if (listTeam[i].Name == playerToUnenroll.TeamName) {
                    listTeam[i].Players.Remove(playerToUnenroll.Name);
                                       
                    teamListView.Items[i] = new ListViewItem(new[] { listTeam[i].Name, listTeam[i].Ground, listTeam[i].Coach, Convert.ToString(listTeam[i].YearFounded), listTeam[i].Region });
                }
            }
        }
       

        private void searchButton_Click(object sender, EventArgs e) {
            searchListView.Items.Clear();
            
            if(searchTextBox.Text != "") {
                try {
                    if (ageRadioButton.Checked) {
                        int searchAge = Convert.ToInt32(searchTextBox.Text);

                        IEnumerable<Player> playerAgeListQuery =
                            from i in listPlayer
                            where i.getAge() == searchAge
                            select i;

                        foreach (Player x in playerAgeListQuery) {
                            ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                            searchListView.Items.Add(newSearchItem);
                        }

                    } else {
                        string searchLocation = searchTextBox.Text.ToLower();

                        IEnumerable<Player> playerBPListQuery =
                            from i in listPlayer
                            where i.BirthPlace.ToLower() == searchLocation || i.BirthPlace.ToLower() == searchLocation + ", new zealand"
                            select i;

                        foreach (Player x in playerBPListQuery) {
                            ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                            searchListView.Items.Add(newSearchItem);
                        }



                        //playerListQuery.
                    }
                }
                catch {

                }
              



            }
        }

        private void teamListView_SelectedIndexChanged(object sender, EventArgs e) {
            teamPlayersListView.Items.Clear();
            for(int i = 0; i < listTeam.Count; i++) {
                if (teamListView.Items[i].Selected) {
                    string teamSelected = listTeam[i].Name;
                    IEnumerable<Player> listOfTeamPlayersQuery =
                        from x in listPlayer
                        where x.TeamName == teamSelected
                        select x;

                    foreach (Player x in listOfTeamPlayersQuery) {
                        ListViewItem item = new ListViewItem(new[] {x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace });
                        teamPlayersListView.Items.Add(item);
                    }
                    break;
                }
            }
        }

        private void playerListView_SelectedIndexChanged(object sender, EventArgs e) {
            playerTeamNameTextBox.Text = "";
            playerTeamGroundTextBox.Text = "";
            playerTeamCoachTextBox.Text = "";
            playerTeamYearFoundedTextBox.Text = "";
            playerTeamRegionTextBox.Text = "";
            for (int i=0; i < listPlayer.Count; i++) {
                if (playerListView.Items[i].Selected){
                    string playerSelected = listPlayer[i].TeamName;
                    IEnumerable<Team> playersTeamQuery =
                        from x in listTeam
                        where x.Name == playerSelected
                        select x;
                    
                    foreach(Team x in playersTeamQuery) {
                        playerTeamNameTextBox.Text = x.Name;
                        playerTeamGroundTextBox.Text = x.Ground;
                        playerTeamCoachTextBox.Text = x.Coach;
                        playerTeamYearFoundedTextBox.Text = Convert.ToString(x.YearFounded);
                        playerTeamRegionTextBox.Text = x.Region;

                    }
                    break;
                }
            }
        }

        //Validation
        public bool hasNonDigitCharacters(string _line, string _var) {
            foreach (char x in _line) {
                if ((x < '0' || x > '9')) {
                    MessageBox.Show("Non-digit character found in " + _var + "\nonly(0-9) are acceptable values", "Non Digit Character", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        public bool hasEmptyLine(string _line, string _var) {
            if (_line == "") {
                MessageBox.Show(_var + " is Empty\nPlease fill everything out", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        public bool hasTooManyChars(string _line, string _var) {
            if (_line.Count() > 21) {
                MessageBox.Show(_var + " has too many characters\n must contain (1-20) characters", "Too Many Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        public bool hasNonAlphabet(string _line, string _var) {
            foreach (char x in _line.ToLower()) {
                if ((x < 'a' || x > 'z') && x != ' ') {
                    MessageBox.Show(_var + " textbox found incorrect character\nonly (a-z, A-Z) are acceptable values", "Incorrect Character Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

      
    }
}
