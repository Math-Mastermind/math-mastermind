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
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            var user = User.LoadFromFile();

            XP_Points.Content = user.XP_Points;
            ELO_Easy.Content = user.ELO_Easy;
            ELO_Medium.Content = user.ELO_Medium;
            ELO_Hard.Content = user.ELO_Hard;
            Correct_Answers.Content = user.Correct_Answers;
            Wrong_Answers.Content = user.Wrong_Answers;
        }
    }
}
