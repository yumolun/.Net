using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace KarliCardsGUI
{
    /// <summary>
    /// Interaction logic for StartGame.xaml
    /// </summary>
    public partial class StartGame : Window
    {
        private GameOptions gameOptions;

        public StartGame()
        {
            if (gameOptions == null)
            {
                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }
                else
                    gameOptions = new GameOptions();
            }

            DataContext = gameOptions;

            InitializeComponent();

            if (gameOptions.PlayAgainstComputer)
                playersNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playersNamesListBox.SelectionMode = SelectionMode.Multiple;
        }

        private void playersNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = playersNamesListBox.SelectedItems.Count == 1;
            else
                okButton.IsEnabled = playersNamesListBox.SelectedItems.Count == gameOptions.NumberOfPlayers;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = null;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in playersNamesListBox.SelectedItems)
            {
                gameOptions.SelectedPlayers.Add(item);
            }

            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, gameOptions);
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;

            this.Close();
        }
    }
}
