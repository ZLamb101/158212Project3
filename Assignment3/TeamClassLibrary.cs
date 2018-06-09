using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3 {

    /***
     * A blueprint to represent a rugby team
     **/
    public class Team {

        private string mName;           //< Name of the Team
        private string mGround;         //< Ground at which the Team plays
        private string mCoach;          //< Team's Coach
        private int mYearFounded;       //< Year in which the team was founded
        private string mRegion;         //< The teams home Region
        private List<string> mPlayers;  //< List of the players names who are enrolled in the team.



        /***
         * Constructor which takes in Name, Ground, Coach, YearFounded, and Region values.
         * assigns them appropriately and initializers the list of strings for Players.
         **/
        public Team( string _Name, string _Ground, string _Coach, int _YearFounded, string _Region) {
            mName = _Name;
            mGround = _Ground;
            mCoach = _Coach;
            mYearFounded = _YearFounded;
            mRegion = _Region;
            mPlayers = new List<string>();
        }

       

        /***
         * Getter and Setter for mName
         **/
        public string Name{
            get{ return mName;  }
            set{ mName = value; }
        }

        /***
          * Getter and Setter for mGround
          **/
        public string Ground {
            get { return mGround;  }
            set { mGround = value; }
        }

        /***
         * Getter and Setter for mCoach
         **/
        public string Coach {
            get { return mCoach;  }
            set { mCoach = value; }
        }

        /***
         * Getter and Setter for mYearFounded
         **/
        public int YearFounded {
            get { return mYearFounded;  }
            set { mYearFounded = value; }
        }

        /***
         * Getter and Setter for mRegion
         **/
        public string Region {
            get { return mRegion;  }
            set { mRegion = value; }
        }

        /***
         * Getter and Setter for mPlayers
         **/
        public List<string> Players {
            get { return mPlayers; }
            set { mPlayers = value; }
        }

       /***
        * writes the name,ground,coach,yf,region data members into a string for save file format
        * returns string
        **/
        public string SaveString() {
            string teamString;
            teamString = mName + ";" + mGround + ";" + mCoach + ";" + mYearFounded + ";" + mRegion;          
            return teamString;
        }
    }

    /***
     * A blueprint to represent a rugby player
     **/
    public class Player {

        private string mID;             //< the unique ID of player
        private string mName;           //< first and last name of player
        private DateTime mBirthDate;    //< birth date in dd/MM/yyyy format of player
        private int mAge;               //< Age of player
        private int mHeight;            //< Height in cm of player
        private int mWeight;            //< Weight in kg of player
        private string mBirthPlace;     //< city and/or country birthplace of player
        private string mTeamName;       //< name of team the player is enrolled in, if enrolled.


        /***
        * Constructor which takes in ID, Name, BirthDate, Height, Weight, and birthplace values.
        * assigns them appropriately and calculates age
        **/
        public Player(string _ID, string _Name, DateTime _BirthDate, int _Height, int _Weight, string _BirthPlace) {
            mID = _ID;
            mName = _Name;
            mBirthDate = _BirthDate;
            mHeight = _Height;
            mWeight = _Weight;
            mBirthPlace = _BirthPlace;
            CalcAge();
        }


        /***
        * Constructor which takes in ID, Name, BirthDate, Height, Weight, and birthplace values.
        * includes Team name
        * assigns them appropriately and calculates age
        **/
        public Player(string _ID, string _Name, DateTime _BirthDate, int _Height, int _Weight, string _BirthPlace, string _TeamName) {
            mID = _ID;
            mName = _Name;
            mBirthDate = _BirthDate;
            mHeight = _Height;
            mWeight = _Weight;
            mBirthPlace = _BirthPlace;
            mTeamName = _TeamName;
            CalcAge();
        }

        /***
         * Getter and Setter for mID
         **/
        public string ID {
            get { return mID;  }
            set { mID = value; }
        }

       /***
        * Getter and Setter for mName
        **/
        public string Name {
            get { return mName; }
            set { mName = value; }
        }

       /***
        * Getter and Setter for mBirthDate
        **/
        public DateTime BirthDate {
            get { return mBirthDate;  }
            set { mBirthDate = value; }
        }

       /***
        * Getter for mAge
        **/
        public int Age {
            get { return mAge; }
        }

       /***
        * Getter and Setter for mHeight
        **/
        public int Height {
            get { return mHeight;  }
            set { mHeight = value; }
        }

       /***
        * Getter and Setter for mWeight
        **/
        public int Weight {
            get { return mWeight;  }
            set { mWeight = value; }
        }

       /***
        * Getter and Setter for mBirthPlace
        **/
        public string BirthPlace {
            get { return mBirthPlace;  }
            set { mBirthPlace = value; }
        }

       /***
        * Getter and Setter for mTeamName
        **/
        public string TeamName {
            get { return mTeamName;  }
            set { mTeamName = value; }
        }

        /***
        * writes the id,name,dob,weight,height,birthplace data members into a string for save file format
        * returns string
        **/
        public string SaveString() {
            string playerString;
            playerString = mID + ";" + mName + ";" + mBirthDate + ";" + mHeight + ";" + mWeight + ";" + mBirthPlace;
            if (mTeamName != "") {
                playerString = playerString + ";" + mTeamName;
            }
            return playerString;

        }

        /***
         * gets todays date.
         * compares date with players birth date to calculate players age
         * saves players age in mAge
         **/
        private void CalcAge() {
            // Save today's date.
            DateTime today = DateTime.Today;
            // Calculate the age.
            int age = today.Year - mBirthDate.Year;                
            // Go back to the year the person was born in case of a leap year
            if (mBirthDate > today.AddYears(-age)) age--;
            mAge = age;
        }

    }


}
