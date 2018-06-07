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

        public RugbyUnion rugbyUnion = new RugbyUnion(); //
        public List<Team> listTeam = new List<Team>();          //< listTeam , a List of teams which represents all rugby team
        public List<Player> listPlayer = new List<Player>();    //< listPlayer, a list of players which represents all players

        Dictionary<string, byte> ageCount = new Dictionary<string, byte>   //< ageCount, Dictionary to hold each count for age histogram
                {
                    {"0-10", 0},
                    {"10-20", 0},
                    {"20-30", 0},
                    {"30-40", 0},
                    {"40-50", 0},
                    {"50-60", 0},
                    {"60+", 0}
                };


        /***
         *  Initializes the Form
         **/
        public mainForm() {
            InitializeComponent();
        }

        /***
         * Opens and Loads a team file
         * Validates the file and reads into listTeam 
         **/
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
                MessageBox.Show("This is an invalid Load file", "Invalid Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        /***
         * Takes a string and splits it into multiple strings then
         * Reads it into a Team and adds to listviews
         * returns the created Team
         **/
        private Team stringToTeam(string line) {            
            List<string> tempTeamPlayerList = new List<string>();
            List<string> words = new List<string>(line.Split(';'));
            if (words.Count != 5) throw new FileLoadException();
            Team tempTeam = new Team(words[0], words[1], words[2], Convert.ToInt32(words[3]), words[4]);

            updateTeamListView(tempTeam);
            return tempTeam;
        }

        /***
         * Passes a warning if Teams have not been loaded in
        * Opens and Loads a  player file
        * Validates the file and reads into listPlayer
        **/
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
            catch(FormatException exception) {  
                MessageBox.Show("Loading players cancelled, Player already\nexists with ID " + exception.Message, "Player Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileLoadException) {
                MessageBox.Show("This is an invalid Load file", "Invalid Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /***
         * Takes a string and splits it into multiple strings then
         * Validates the input to make sure there is no multiple occurances
         * Reads it into a Player and adds to listviews
         * returns the created Player
         **/
        private Player stringToPlayer(string line) {
            List<string> words = new List<string>(line.Split(';'));
            if (words.Count < 6) throw new FileLoadException();
            Player tempPlayer;
            if(words.Count == 6) {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5]);
            } else {
                tempPlayer = new Player(words[0], words[1], Convert.ToDateTime(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), words[5], words[6]);
                for(byte i=0;i < listTeam.Count; i++) {
                    if(listTeam[i].Name == words[6]) {
                        listTeam[i].Players.Add(tempPlayer.Name);
                        break;
                    }
                    if(i == listTeam.Count - 1) tempPlayer.TeamName = "";
                }
            }  
             for (byte i = 0; i < listPlayer.Count; i++) {
                if (words[0] == listPlayer[i].ID) throw new FormatException(words[0]);                
             }
             updatePlayerListView(tempPlayer);
 
            return tempPlayer;
        }



        /***
        * Clears ageChart HistoGram
        * and replots the histogram
        **/
        private void updateAgeChart() {
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
        * Takes a Player in params
        * and adds it to related listviews
        * adds Height, weight and age to nessecery place for charts
        **/
        private void updatePlayerListView(Player tempPlayer) {
            ListViewItem item = new ListViewItem(new[] { tempPlayer.ID, tempPlayer.Name, Convert.ToString(tempPlayer.BirthDate), Convert.ToString(tempPlayer.Height), Convert.ToString(tempPlayer.Weight), tempPlayer.BirthPlace, tempPlayer.TeamName });
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
            updateAgeChart();
        }

        /***
        * Takes a Team in params and adds it to related listviews
        **/
        private void updateTeamListView(Team tempTeam) {
            ListViewItem item = new ListViewItem(new[] { tempTeam.Name, tempTeam.Ground, tempTeam.Coach, Convert.ToString(tempTeam.YearFounded), tempTeam.Region});
            teamListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem(new[] { tempTeam.Name });
            enrollTeamListView.Items.Add(item2);
        }


        /***
         * On Enroll tab
         * If a Player index is selected displays selected index in the appropriate textbox
         **/
        private void enrollPlayerListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (byte i = 0; i < listPlayer.Count; i++) {
                if (enrollPlayerListView.Items[i].Selected) {
                    playerSelectedEnrollmentTextBox.Text = listPlayer[i].Name;
                    break;
                }
            }
        }

        /***
        * On Enroll tab
        * If a Team index is selected displays selected index in the appropriate textbox
        **/
        private void enrollTeamListView_SelectedIndexChanged(object sender, EventArgs e) {
            for (byte i = 0; i < listTeam.Count; i++) {
                if (enrollTeamListView.Items[i].Selected) {
                    teamSelectedEnrollmentTextBox.Text = listTeam[i].Name;
                    break;
                }
            }
        }

        /***
         * Opens a File Dialog
         * Writes Player information to designated file
         **/
        private void playersToolSave_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "SavePlayerList.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK) {
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                
                for (byte i = 0; i < listPlayer.Count; i++) {
                    writer.WriteLine(listPlayer[i].saveString());
                }
                writer.Close();
            }

        }

        /***
         * Opens a File Dialog
         * Writes Team information to designated file
         **/
        private void teamsToolSave_Click(object sender, EventArgs e) {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "SaveTeamList.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK) {
                FileStream fs;
                fs = File.Create(save.FileName);
                StreamWriter writer;
                writer = new StreamWriter(fs);
                
                for (byte i = 0; i < listTeam.Count; i++) {
                    writer.WriteLine(listTeam[i].saveString());
                }
                writer.Close();
            }
        }

        /***
         * When Button is pressed
         * Open Add new player tab
         * if player is added update listview
         **/
        private void gotoAddPlayerButton_Click(object sender, EventArgs e) {
            int i = listPlayer.Count - 1;
            addNewPlayerForm form2 = new addNewPlayerForm(this);
            form2.ShowDialog();
            if (listPlayer.Count - 1 != i) {          
                updatePlayerListView(listPlayer[i+1]);
            }

        }

        /***
        * When Button is pressed
        * Open Add new team tab
        * if team is added update listview
        **/
        private void gotoAddTeamButton_Click(object sender, EventArgs e) {
            int i = listTeam.Count - 1;
            addNewTeamForm form2 = new addNewTeamForm(this);
            form2.ShowDialog();

            if (listTeam.Count - 1 != i) {              
                updateTeamListView(listTeam[i+1]);
            }
        }


        /***
         * On Enrollment Tab
         * When Enrol Button is Clicked
         * Checks if Both Text boxes are filled out,
         * Finds selected player and selected team
         * Performs Unenroll of current team if nessecery
         * then Enrolls player to selected team
         **/
        private void enrollmentButton_Click(object sender, EventArgs e) {
            if (playerSelectedEnrollmentTextBox.Text != "" && teamSelectedEnrollmentTextBox.Text != "") {
                for (byte i = 0; i < listPlayer.Count; i++) {
                    if (playerSelectedEnrollmentTextBox.Text == listPlayer[i].Name) {                   
                        for (byte j = 0; j < listTeam.Count; j++) {
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
    

        /***
         * Enroll player
         * Adds player to team , And adds Team Name to player
         * updates all listviews nessecery
         **/
        private void enrollPlayer(int playerToEnroll, int teamToEnroll) {
            listTeam[teamToEnroll].Players.Add(listPlayer[playerToEnroll].Name);
            listPlayer[playerToEnroll].TeamName = listTeam[teamToEnroll].Name;
                              
            enrollPlayerListView.Items[playerToEnroll] = new ListViewItem(new[] { listPlayer[playerToEnroll].Name, listPlayer[playerToEnroll].TeamName });
            playerListView.Items[playerToEnroll] = new ListViewItem(new[] { listPlayer[playerToEnroll].ID, listPlayer[playerToEnroll].Name, Convert.ToString(listPlayer[playerToEnroll].BirthDate), Convert.ToString(listPlayer[playerToEnroll].Height), Convert.ToString(listPlayer[playerToEnroll].Weight), listPlayer[playerToEnroll].BirthPlace, listPlayer[playerToEnroll].TeamName });
            
            teamListView.Items[teamToEnroll] = new ListViewItem(new[] { listTeam[teamToEnroll].Name, listTeam[teamToEnroll].Ground, listTeam[teamToEnroll].Coach, Convert.ToString(listTeam[teamToEnroll].YearFounded), listTeam[teamToEnroll].Region });
        }

        /***
         * Unenroll player
         * Finds players current team.
         * Removes player from team,
         * updates team listview
         **/
        private void unenrollPlayer(Player playerToUnenroll) {
            for (byte i = 0; i < listTeam.Count; i++) {
                if (listTeam[i].Name == playerToUnenroll.TeamName) {
                    listTeam[i].Players.Remove(playerToUnenroll.Name);
                                       
                    teamListView.Items[i] = new ListViewItem(new[] { listTeam[i].Name, listTeam[i].Ground, listTeam[i].Coach, Convert.ToString(listTeam[i].YearFounded), listTeam[i].Region });
                }
            }
        }
       

        /***
         * When search button is clicked
         * Clears search listview
         * Calls SearchAge or SearchBirthAddress according to which radio button is selected
         **/
        private void searchButton_Click(object sender, EventArgs e) {
            searchListView.Items.Clear();           
            if(searchTextBox.Text != "") {
                try {
                    if (ageRadioButton.Checked) searchAge();
                    else searchBirthAddress();   
                }
                catch {

                }

            }
        }

        /***
         * Search Age
         * Uses LinQ query to find all players in listPlayer with search age
         * Adds all selected players to search Listview
         **/
        private void searchAge() {
            int searchAge = Convert.ToInt32(searchTextBox.Text);

            IEnumerable<Player> playerAgeListQuery =
                from i in listPlayer
                where i.Age == searchAge
                select i;

            foreach (Player x in playerAgeListQuery) {
                ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                searchListView.Items.Add(newSearchItem);
            }
        }

      /***
       * Search Birth Place
       * Uses LinQ query to find all players in listPlayer with search birth Place
       * Adds all selected players to search Listview
       **/
        private void searchBirthAddress() {
            string searchLocation = searchTextBox.Text.ToLower();

            IEnumerable<Player> playerBPListQuery =
                from i in listPlayer
                where i.BirthPlace.ToLower() == searchLocation || i.BirthPlace.ToLower() == searchLocation + ", new zealand"
                select i;

            foreach (Player x in playerBPListQuery) {
                ListViewItem newSearchItem = new ListViewItem(new[] { x.ID, x.Name, Convert.ToString(x.BirthDate), Convert.ToString(x.Height), Convert.ToString(x.Weight), x.BirthPlace, x.TeamName });
                searchListView.Items.Add(newSearchItem);
            }
        }

        /***
         * When teamListview index is selected
         * clears previous player details
         * Updates Player listview on team tab
         * to display players appropriate for selected team
         **/
        private void teamListView_SelectedIndexChanged(object sender, EventArgs e) {
            teamPlayersListView.Items.Clear();
            for(byte i = 0; i < listTeam.Count; i++) {
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

        /***
         * When playerListview index is selected
         * Clears previous details
         * Updates tean listview on player tab
         * to display team details appropriate for selected player
         **/
        private void playerListView_SelectedIndexChanged(object sender, EventArgs e) {
            playerTeamNameTextBox.Text = "";
            playerTeamGroundTextBox.Text = "";
            playerTeamCoachTextBox.Text = "";
            playerTeamYearFoundedTextBox.Text = "";
            playerTeamRegionTextBox.Text = "";
            for (byte i=0; i < listPlayer.Count; i++) {
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

        /***
         * When Age button on chart page is selected
         * Hides HeightvsWeight Chart
         * And shows AgeChart
         **/
        private void ageHistogramButton_CheckedChanged(object sender, EventArgs e) {
            if (ageHistogramButton.Checked) {
                ageChart.Visible = true;
                HeightvsWeightChart.Visible = false;
            }

        }

        /***
         * When HeightvsWeight button on chart page is selected
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
        public bool hasNonDigitCharacters(string _line, string _var) {
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
        public bool hasEmptyLine(string _line, string _var) {
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
        public bool hasTooManyChars(string _line, string _var) {
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
