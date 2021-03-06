﻿using System;
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


        private List<Team> mAllTeams;          //< AllTeams , a List of teams which represents all rugby team
        private List<Player> mAllPlayers;    //< AllPlayers, a list of players which represents all players
        private Dictionary<string, byte> ageCount;   //< ageCount, Dictionary to hold each count for age histogram

        /***
         * Getter and Setter for mAllTeam
         **/
        public List<Team> AllTeams {
            get { return mAllTeams; }
            set { mAllTeams = value; }
        }

        /***
         * Getter and Setter for mAllPlayers
         **/
        public List<Player> AllPlayers {
            get { return mAllPlayers; }
            set { mAllPlayers = value; }
        }

        /***
         *  Constructor
         *  Initializes the Form
         **/
        public mainForm() {
            mAllTeams = new List<Team>();
            mAllPlayers = new List<Player>();
            

            ageCount = new Dictionary<string, byte>   
                {
                    {"0-10", 0},
                    {"10-20", 0},
                    {"20-30", 0},
                    {"30-40", 0},
                    {"40-50", 0},
                    {"50-60", 0},
                    {"60+", 0}
                };


            InitializeComponent();
        }

        /***
         * Opens and Loads a team file
         * Validates the file and reads into mAllTeam 
         **/
        private void TeamsToolLoad_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK) {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                    StreamReader reader = new StreamReader(fs);
                                      
                    while (reader.Peek() > -1) {
                        string line;
                        line = reader.ReadLine();                      
                        mAllTeams.Add(StringToTeam(line));
                    }
                    reader.Close();
                }
            }
            catch {
                MessageBox.Show("This is an invalid Load file", "Invalid Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        /***
         * Takes a string and splits it into multiple strings then
         * Reads it into a Team and adds to list views
         * returns the created Team
         **/
        private Team StringToTeam(string line) {
            string[] words = (line.Split(';'));
            if (words.Length != 5) throw new FileLoadException();
            Team tempTeam = new Team(words[0], words[1], words[2], Convert.ToInt32(words[3]), words[4]);
           
            NewTeamUpdate(tempTeam);
            return tempTeam;
        }

        /***
         * Passes a warning if Teams have not been loaded in
        * Opens and Loads a  player file
        * Validates the file and reads into mAllPlayers
        **/
        private void PlayersToolLoad_Click(object sender, EventArgs e) {
            if (mAllTeams.Count == 0) {
                MessageBox.Show("Are you sure you want to load players before teams\nPlayers will be unassigned from their team if the\n team does not exist", "Loading Players Before Teams", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK) {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                    StreamReader reader = new StreamReader(fs);
                    
                    while (reader.Peek() > -1) {
                        string line;
                        line = reader.ReadLine();
                        mAllPlayers.Add(StringToPlayer(line));

                    }
                    reader.Close();
                }
            }
            catch(FormatException exception) {  
                MessageBox.Show("Loading players cancelled, Player already\nexists with ID " + exception.Message, "Player Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileLoadException) {
                MessageBox.Show("This is an invalid Load file", "Invalid Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /***
         * Takes a string and splits it into multiple strings then
         * Validates the input to make sure there is no multiple occurrences
         * Reads it into a Player and adds to list views
         * returns the created Player
         **/
        private Player StringToPlayer(string line) {
            string[] words = (line.Split(';'));
            if (words.Length < 6) throw new FileLoadException();
            Player tempPlayer;
            if(words.Length == 6) {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5]);
            } else {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5], words[6]);
                if (mAllTeams.Count == 0) tempPlayer.TeamName = "";
                else {                
                    for (byte i=0;i < mAllTeams.Count; i++) {
                        if(mAllTeams[i].Name == words[6]) {
                            mAllTeams[i].Players.Add(tempPlayer.Name);
                            break;
                        }
                        if(i == mAllTeams.Count - 1) tempPlayer.TeamName = "";
                    }
                }
            }  
             for (byte i = 0; i < mAllPlayers.Count; i++) {
                if (words[0] == mAllPlayers[i].ID) throw new FormatException(words[0]);                
             }
             NewPlayerUpdate(tempPlayer);
 
            return tempPlayer;
        }

        /***
        * Takes a Player in params
        * and adds it to related list views
        * adds Height, weight and age to necessary place for charts
        **/
        private void NewPlayerUpdate(Player tempPlayer) {
            ListViewItem item = new ListViewItem(new[] { tempPlayer.ID, tempPlayer.Name, Convert.ToString(tempPlayer.BirthDate.ToShortDateString()), Convert.ToString(tempPlayer.Height), Convert.ToString(tempPlayer.Weight), tempPlayer.BirthPlace, tempPlayer.TeamName });
            playerListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempPlayer.Name, tempPlayer.TeamName });
            enrollPlayerListView.Items.Add(item2);

            HeightvsWeightChart.Series["Height"].Points.AddXY(tempPlayer.Name, tempPlayer.Height);
            HeightvsWeightChart.Series["Weight"].Points.AddXY(tempPlayer.Name, tempPlayer.Weight);

            
            if (tempPlayer.Age < 10) ageCount["0-10"]++;
            else if (tempPlayer.Age < 20) ageCount["10-20"]++;
            else if (tempPlayer.Age < 30) ageCount["20-30"]++;
            else if (tempPlayer.Age < 40) ageCount["30-40"]++;
            else if (tempPlayer.Age < 50) ageCount["40-50"]++;
            else if (tempPlayer.Age < 60) ageCount["50-60"]++;
            else ageCount["60+"]++;
            UpdateAgeChart();
        }




        /***
        * Takes a Team in params and adds it to related list views
        **/
        private void NewTeamUpdate(Team tempTeam) {
            ListViewItem item = new ListViewItem(new[] { tempTeam.Name, tempTeam.Ground, tempTeam.Coach, Convert.ToString(tempTeam.YearFounded), tempTeam.Region});
            teamListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempTeam.Name });
            enrollTeamListView.Items.Add(item2);
        }


       /***
        * Clears ageChart HistoGram
        * and re plots the histogram
        **/
        private void UpdateAgeChart() {
            ageChart.Series["Age"].Points.Clear();
            
            ageChart.Series["Age"].Points.AddXY("0-10", ageCount["0-10"]);
            ageChart.Series["Age"].Points.AddXY("10-20", ageCount["10-20"]);
            ageChart.Series["Age"].Points.AddXY("20-30", ageCount["20-30"]);
            ageChart.Series["Age"].Points.AddXY("30-40", ageCount["30-40"]);
            ageChart.Series["Age"].Points.AddXY("40-50", ageCount["40-50"]);
            ageChart.Series["Age"].Points.AddXY("50-60", ageCount["50-60"]);
            ageChart.Series["Age"].Points.AddXY("60+", ageCount["60+"]);
        }


        

        /***
         * Opens a File Dialog
         * Writes Player information to designated file
         **/
        private void PlayersToolSave_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog {
                FileName = "SavePlayerList.txt",
                Filter = "Text File | *.txt"
            };
            if (save.ShowDialog() == DialogResult.OK) {
               
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                
                for (byte i = 0; i < mAllPlayers.Count; i++) {
                    writer.WriteLine(mAllPlayers[i].SaveString());
                }
                writer.Close();
            }

        }

        /***
         * Opens a File Dialog
         * Writes Team information to designated file
         **/
        private void TeamsToolSave_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog {
                FileName = "SaveTeamList.txt",
                Filter = "Text File | *.txt"
            };
            if (save.ShowDialog() == DialogResult.OK) {
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                
                for (byte i = 0; i < mAllTeams.Count; i++) {
                    writer.WriteLine(mAllTeams[i].SaveString());
                }
                writer.Close();
            }
        }

        /***
         * When Button is pressed
         * Open Add new player tab
         * if player is added update list view
         **/
        private void GotoAddPlayerButton_Click(object sender, EventArgs e) {
            int i = mAllPlayers.Count;
            AddNewPlayerForm.AddNewPlayerForm addPlayerForm = new AddNewPlayerForm.AddNewPlayerForm(this);
            addPlayerForm.ShowDialog();
            
            if (mAllPlayers.Count != i) {          
                NewPlayerUpdate(mAllPlayers[i]);
            }

        }

        /***
        * When Button is pressed
        * Open Add new team tab
        * if team is added update list view
        **/
        private void GotoAddTeamButton_Click(object sender, EventArgs e) {
            int i = mAllTeams.Count;
            AddNewTeamForm.AddNewTeamForm addTeamForm = new AddNewTeamForm.AddNewTeamForm(this);
            addTeamForm.ShowDialog();
            
            if (mAllTeams.Count != i) {              
                NewTeamUpdate(mAllTeams[i]);
            }
        }

        private int enrollPlayerIndex; //< holds the index for player being enrolled

        /***
         * On Enroll tab
         * If a Player index is selected displays selected index in the appropriate textbox
         **/
        private void EnrollPlayerListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (byte i = 0; i < mAllPlayers.Count; i++) {
                if (enrollPlayerListView.Items[i].Selected) {
                    playerSelectedEnrollmentTextBox.Text = mAllPlayers[i].Name;
                    enrollPlayerIndex = i;
                    break;
                }
            }
        }

        private int enrollTeamIndex; //< holds the index for team being enrolled with

        /***
        * On Enroll tab
        * If a Team index is selected displays selected index in the appropriate textbox
        **/
        private void EnrollTeamListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (byte i = 0; i < mAllTeams.Count; i++) {
                if (enrollTeamListView.Items[i].Selected) {
                    teamSelectedEnrollmentTextBox.Text = mAllTeams[i].Name;
                    enrollTeamIndex = i;
                    break;
                }
            }
        }


        /***
         * On Enrollment Tab
         * When Enroll Button is Clicked
         * Checks if Both Text boxes are filled out,
         * Finds selected player and selected team
         * Performs Un enroll of current team if necessary
         * then Enrolls player to selected team
         **/
        private void EnrollmentButton_Click(object sender, EventArgs e) {
            if (playerSelectedEnrollmentTextBox.Text != "" && teamSelectedEnrollmentTextBox.Text != "") {             
                if (mAllPlayers[enrollPlayerIndex].TeamName != "") {
                    UnenrollPlayer(mAllPlayers[enrollPlayerIndex]);
                }
               EnrollPlayer(enrollPlayerIndex, enrollTeamIndex);          
            }
        }


        /***
         * Enroll player
         * Adds player to team , And adds Team Name to player
         * updates all list views necessary
         **/
        private void EnrollPlayer(int playerIndex, int teamIndex) {
            mAllTeams[teamIndex].Players.Add(mAllPlayers[playerIndex].Name);
            mAllPlayers[playerIndex].TeamName = mAllTeams[teamIndex].Name;
                              
            enrollPlayerListView.Items[playerIndex] = new ListViewItem(new[] { mAllPlayers[playerIndex].Name, mAllPlayers[playerIndex].TeamName });
            playerListView.Items[playerIndex] = new ListViewItem(new[] { mAllPlayers[playerIndex].ID, mAllPlayers[playerIndex].Name, Convert.ToString(mAllPlayers[playerIndex].BirthDate.ToShortDateString()), Convert.ToString(mAllPlayers[playerIndex].Height), Convert.ToString(mAllPlayers[playerIndex].Weight), mAllPlayers[playerIndex].BirthPlace, mAllPlayers[playerIndex].TeamName });
            
            teamListView.Items[teamIndex] = new ListViewItem(new[] { mAllTeams[teamIndex].Name, mAllTeams[teamIndex].Ground, mAllTeams[teamIndex].Coach, Convert.ToString(mAllTeams[teamIndex].YearFounded), mAllTeams[teamIndex].Region });
        }

        /***
         * Un enroll player
         * Finds players current team.
         * Removes player from team,
         * updates team list view
         **/
        private void UnenrollPlayer(Player playerToUnenroll) {
            for (byte i = 0; i < mAllTeams.Count; i++) {
                if (mAllTeams[i].Name == playerToUnenroll.TeamName) {
                    mAllTeams[i].Players.Remove(playerToUnenroll.Name);
                                       
                    teamListView.Items[i] = new ListViewItem(new[] { mAllTeams[i].Name, mAllTeams[i].Ground, mAllTeams[i].Coach, Convert.ToString(mAllTeams[i].YearFounded), mAllTeams[i].Region });
                }
            }
        }
       

        /***
         * When search button is clicked
         * Clears search list view
         * Calls SearchAge or SearchBirthAddress according to which radio button is selected
         **/
        private void SearchButton_Click(object sender, EventArgs e) {
            searchListView.Items.Clear();           
            if(searchTextBox.Text != "") {
                try {
                    if (ageRadioButton.Checked) SearchAge();
                    else SearchBirthAddress();   
                }
                catch {

                }

            }
        }

        /***
         * Search Age
         * Uses LinQ query to find all players in mAllPlayers with search age
         * Adds all selected players to search List view
         **/
        private void SearchAge() {
            int searchAge = Convert.ToInt32(searchTextBox.Text);

            IEnumerable<Player> playerAgeListQuery =
                from i in mAllPlayers
                where i.Age == searchAge
                select i;

            foreach (Player x in playerAgeListQuery) {
                ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate.ToShortDateString()), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                searchListView.Items.Add(newSearchItem);
            }
        }

      /***
       * Search Birth Place
       * Uses LinQ query to find all players in mAllPlayers with search birth Place
       * Adds all selected players to search List view
       **/
        private void SearchBirthAddress() {
            string searchLocation = searchTextBox.Text.ToLower();

            IEnumerable<Player> playerBPListQuery =
                from i in mAllPlayers
                where i.BirthPlace.ToLower() == searchLocation || i.BirthPlace.ToLower() == searchLocation + ", new zealand"
                select i;

            foreach (Player x in playerBPListQuery) {
                ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate.ToShortDateString()), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                searchListView.Items.Add(newSearchItem);
            }
        }

        /***
         * When team List view index is selected
         * clears previous player details
         * Updates Player list view on team tab
         * to display players appropriate for selected team
         **/
        private void TeamListView_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                teamPlayersListView.Items.Clear();
                for (byte i = 0; i < mAllTeams.Count; i++) {
                    if (teamListView.Items[i].Selected) {
                        IEnumerable<Player> listOfTeamPlayersQuery =
                            from x in mAllPlayers
                            where x.TeamName == mAllTeams[i].Name
                            select x;


                        foreach (Player x in listOfTeamPlayersQuery) {
                            ListViewItem item = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate.ToShortDateString()), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace });
                            teamPlayersListView.Items.Add(item);
                        }
                        break;
                    }
                }
            }
            catch { }
        }

        /***
         * When player List view index is selected
         * Clears previous details
         * Updates team list view on player tab
         * to display team details appropriate for selected player
         **/
        private void PlayerListView_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                clearPlayerTeamDetails();
                for (byte i = 0; i < mAllPlayers.Count; i++) {
                    if (playerListView.Items[i].Selected) {
                        IEnumerable<Team> playersTeamQuery =
                            from x in mAllTeams
                            where x.Name == mAllPlayers[i].TeamName
                            select x;

                        updatePlayerTeamDetails(playersTeamQuery.First());
                        break;
                    }
                }
            }
            catch { }
        }

        /***
         * Clears player team details textboxes
         **/
        private void updatePlayerTeamDetails(Team x) {
            playerTeamNameTextBox.Text = x.Name;
            playerTeamGroundTextBox.Text = x.Ground;
            playerTeamCoachTextBox.Text = x.Coach;
            playerTeamYearFoundedTextBox.Text = Convert.ToString(x.YearFounded);
            playerTeamRegionTextBox.Text = x.Region;
        }
        

        /***
         * Clears player team details textboxes
         **/
        private void clearPlayerTeamDetails() {
            playerTeamNameTextBox.Text = "";
            playerTeamGroundTextBox.Text = "";
            playerTeamCoachTextBox.Text = "";
            playerTeamYearFoundedTextBox.Text = "";
            playerTeamRegionTextBox.Text = "";
        }

        /***
         * When Age button on chart page is selected
         * Hides Height vs Weight Chart
         * And shows AgeChart
         **/
        private void AgeHistogramButton_CheckedChanged(object sender, EventArgs e) {
            if (ageHistogramButton.Checked) {
                ageChart.Visible = true;
                HeightvsWeightChart.Visible = false;
            }

        }

        /***
         * When Height vs Weight button on chart page is selected
         * Hides AgeChart
         * and shows Height vs weight chart
         **/
        private void HeightvsWeightButton_CheckedChanged(object sender, EventArgs e) {
            if (HeightvsWeightButton.Checked) {
                ageChart.Visible = false;
                HeightvsWeightChart.Visible = true;
            }
        }

        //Validation

        /***
         * Checks if string has any non digits 
         * display appropriate error message if it does
         **/
        public bool HasNonDigitCharacters(string _line, string _var) {
            foreach (char x in _line) {
                if ((x < '0' || x > '9')) {
                    MessageBox.Show("Non-digit character found in " + _var + "\nonly(0-9) are acceptable values", "Non Digit Character", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

       /***
        * Checks if string is empty
        * display appropriate error message if it is
        **/
        public bool HasEmptyLine(string _line, string _var) {
            if (_line == "") {
                MessageBox.Show(_var + " is Empty\nPlease fill everything out", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

      /***
       * Checks if string has over 21 characters
       * display appropriate error message if it does
       **/
        public bool HasTooManyChars(string _line, string _var) {
            if (_line.Count() > 21) {
                MessageBox.Show(_var + " has too many characters\n must contain (1-20) characters", "Too Many Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

      /***
       * Checks if string is contains any digits or unwanted symbols
       * display appropriate error message if it does
       **/
        public bool HasNonAlphabet(string _line, string _var) {
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
