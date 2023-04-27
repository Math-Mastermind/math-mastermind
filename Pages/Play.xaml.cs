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
    /// Logika interakcji dla klasy Play.xaml
    /// </summary>
    public partial class Play : Page
    {
        public Play()
        {
            InitializeComponent();
        }

        private void NavigateNext()
        {
            
            Uri myUri = new Uri("/Pages/Difficulty.xaml", UriKind.Relative);
            NavigationService.Navigate(myUri);
        }

        private void Addition(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["GameMode"] = "addition";
            NavigateNext();
        }

        private void Substraction(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["GameMode"] = "substraction";
            NavigateNext();
        }

        private void Multiplication(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["GameMode"] = "multiplication";
            NavigateNext();
        }

        private void Division(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["GameMode"] = "division";
            NavigateNext();
        }

        private void Root(object sender, MouseButtonEventArgs e)
        {
            App.Current.Properties["GameMode"] = "root";
            NavigateNext();
        }
    }
}
