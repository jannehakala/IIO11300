using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding {
    public static class TestHockeyBench {
        #region METHODS
        public static List<HockeyPlayer> GetPlayers() {
            List<HockeyPlayer> players = new List<HockeyPlayer>();
            players.Add(new HockeyPlayer("Teemu Selänne", "8"));
            players.Add(new HockeyPlayer("Jarkko Immonen", "26"));
            players.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return players;
        }
        #endregion
    }
    public class HockeyPlayer : INotifyPropertyChanged {
        #region VARIABLES
        private string name;
        private string number;
        #endregion
        #region PROPERTIES
        public string Name {
            set {
                name = value;
                Notify("Name");
                Notify("NameAndNumber");
            }
            get {
                return name;
            }
        }
        
        public string Number {
            set {
                number = value;
                Notify("Number");
                Notify("NameAndNumber");
            }
            get {
                return number;
            }
        }
        public string NameAndNumber {
            get {
                return name + " #" + number;
            }
        }
        #endregion
        #region CONSTRUCTORS
        public HockeyPlayer() {

        }
        public HockeyPlayer(string name, string number) {
            this.name = name;
            this.number = number;
        }
        #endregion
        #region INTERFACES
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
    public class HockeyTeam {
        #region PROPERTIES
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public override string ToString() {
            return Name + "@" + City;
        }
        public HockeyTeam() {
            Name = "";
            City = "none";
        }
        public HockeyTeam(string teamName, string city) {
            Name = teamName;
            City = city;
        }
        #endregion
    }
    public class HockeyLeague {
        #region VARIABLES
        List<HockeyTeam> teams = new List<HockeyTeam>();
        #endregion
        #region CONSTRUCTORS
        public HockeyLeague() {
            teams.Add(new HockeyTeam("Ilves", "Tampere"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kärpät", "Oulu"));
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
        }
        
        public List<HockeyTeam> GetTeams() {
            return teams;
        }
        #endregion
    }
}
