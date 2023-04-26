using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathMastermind.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();

            string mode = App.Current.Properties["GameMode"].ToString();

            UserAnswer.Text = "Wynik";
            UserAnswer.GotFocus += RemoveText;
            UserAnswer.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (UserAnswer.Text == "Wynik")
            {
                UserAnswer.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserAnswer.Text))
                UserAnswer.Text = "Wynik";
        }

        private void UserAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
