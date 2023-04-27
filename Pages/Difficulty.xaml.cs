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
    /// Logika interakcji dla klasy Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Page
    {
        public Difficulty()
        {
            InitializeComponent();
        }

        private void NavigateNext()
        {

            Uri myUri = new Uri("/Pages/Game.xaml", UriKind.Relative);
            NavigationService.Navigate(myUri);
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["Difficulty"] = "easy";
            NavigateNext();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["Difficulty"] = "medium";
            NavigateNext();
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["Difficulty"] = "hard";
            NavigateNext();
        }
    }
}
