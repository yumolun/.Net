using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarliCardsGUI
{
    [Serializable]
    public class GameOptions : INotifyPropertyChanged
    {
        private bool playAgainstComputer = true;
        private int numberOfPlayers = 2;
        private int minutesBeforeLoss = 10;
        private ComputerSkillLevel computerSkill = ComputerSkillLevel.Dumb;
        private ObservableCollection<string> playerNames = new ObservableCollection<string>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> SelectedPlayers { get; set; }

        public bool PlayAgainstComputer
        {
            get
            {
                return playAgainstComputer;
            }

            set
            {
                playAgainstComputer = value;
                OnPropertyChanged("PlayAgainstComputer");
            }
        }

        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }

            set
            {
                numberOfPlayers = value;
                OnPropertyChanged("NumberOfPlayers");
            }
        }

        public int MinutesBeforeLoss
        {
            get
            {
                return minutesBeforeLoss;
            }

            set
            {
                minutesBeforeLoss = value;
                OnPropertyChanged("MinutesBeforeLoss");
            }
        }

        public ComputerSkillLevel ComputerSkill
        {
            get
            {
                return computerSkill;
            }

            set
            {
                computerSkill = value;
                OnPropertyChanged("ComputerSkill");
            }
        }

        public ObservableCollection<string> PlayerNames
        {
            get
            {
                return playerNames;
            }

            set
            {
                playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }

        public GameOptions()
        {
            SelectedPlayers = new List<string>();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddPlayer(string playerName)
        {
            if (playerNames.Contains(playerName))
                return;
            playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }
    }

    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb = 0,
        Good = 1,
        Cheats = 2
    }
}
