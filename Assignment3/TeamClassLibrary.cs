using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3 {
    public class Team {

        public Team( string _Name, string _Ground, string _Coach, int _YearFounded, string _Region) {
            mName = _Name;
            mGround = _Ground;
            mCoach = _Coach;
            mYearFounded = _YearFounded;
            mRegion = _Region;
            mPlayers = new List<string>();
        }

        public Team(string _Name, string _Ground, string _Coach, int _YearFounded, string _Region, List<string> _playerList) {
            mName = _Name;
            mGround = _Ground;
            mCoach = _Coach;
            mYearFounded = _YearFounded;
            mRegion = _Region;
            mPlayers = _playerList;
        }

        private string mName;
        public string Name{
            get{ return mName;  }
            set{ mName = value; }
        }

        private string mGround;
        public string Ground {
            get { return mGround;  }
            set { mGround = value; }
        }

        private string mCoach;
        public string Coach {
            get { return mCoach;  }
            set { mCoach = value; }
        }

        private int mYearFounded;
        public int YearFounded {
            get { return mYearFounded;  }
            set { mYearFounded = value; }
        }

        private string mRegion;
        public string Region {
            get { return mRegion;  }
            set { mRegion = value; }
        }

        private List<string> mPlayers;
        public List<string> Players {
            get { return mPlayers; }
            set { mPlayers = value; }
        }

        
        public string saveString() {
            string teamString;
            teamString = mName + ";" + mGround + ";" + mCoach + ";" + mYearFounded + ";" + mRegion;
            for (int i = 0; i< mPlayers.Count; i++) {
                teamString = teamString + ";" + mPlayers[i];
            }

            return teamString;


        }
    }

    
    public class Player {

        public Player(string _ID, string _Name, DateTime _BirthDate, int _Height, int _Weight, string _BirthPlace) {
            mID = _ID;
            mName = _Name;
            mBirthDate = _BirthDate;
            mHeight = _Height;
            mWeight = _Weight;
            mBirthPlace = _BirthPlace;
        }

        public Player(string _ID, string _Name, DateTime _BirthDate, int _Height, int _Weight, string _BirthPlace, string _TeamName) {
            mID = _ID;
            mName = _Name;
            mBirthDate = _BirthDate;
            mHeight = _Height;
            mWeight = _Weight;
            mBirthPlace = _BirthPlace;
            mTeamName = _TeamName;
        }

        private string mID;
        public string ID {
            get { return mID;  }
            set { mID = value; }
        }

        private string mName;
        public string Name {
            get { return mName; }
            set { mName = value; }
        }

        private DateTime mBirthDate;
        public DateTime BirthDate {
            get { return mBirthDate;  }
            set { mBirthDate = value; }
        }

        private int mHeight;
        public int Height {
            get { return mHeight;  }
            set { mHeight = value; }
        }

        private int mWeight;
        public int Weight {
            get { return mWeight;  }
            set { mWeight = value; }
        }

        private string mBirthPlace;
        public string BirthPlace {
            get { return mBirthPlace;  }
            set { mBirthPlace = value; }
        }

        private string mTeamName;
        public string TeamName {
            get { return mTeamName;  }
            set { mTeamName = value; }
        }

        public string saveString() {
            string playerString;
            playerString = mID + ";" + mName + ";" + mBirthDate + ";" + mHeight + ";" + mWeight + ";" + mBirthPlace;
            if (mTeamName != "") {
                playerString = playerString + ";" + mTeamName;
            }


            return playerString;

        }


    }



    public class RugbyUnion {

        public RugbyUnion() { }

        private List<Team> allTeams;
        public List<Team> Teams {
            get { return allTeams;  }
            set { allTeams = value; }
        }

        public void AddTeam(Team newTeam) {
            allTeams.Add(newTeam);

        }


    }
}
