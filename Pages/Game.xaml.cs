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

            InitGame();
        }

        public void InitGame()
        {
            string mode = App.Current.Properties["GameMode"].ToString();
            string difficulty = "easy";

            Result.Visibility = Visibility.Collapsed;
            UserAnswer.IsEnabled = true;
            UserAnswer.Text = "";

            switch (mode)
            {
                case "addition":
                    Addition(difficulty);
                    break;
                default:
                    break;
            }

            CheckButton.Visibility = Visibility.Visible;
            NextButton.Visibility = Visibility.Collapsed;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            InitGame();
        }

        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               Button_Click(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string correctAnswer = App.Current.Properties["CorrectAnswer"].ToString();
            string userAnswer = UserAnswer.Text;

            if (userAnswer == "")
            {
                Result.Visibility = Visibility.Visible;
                Result.Background = Brushes.DarkOrange;
                ResultText.Content = "Wprowadź odpowiedź!";
                return;
            }

            if (correctAnswer == userAnswer)
            {
                Result.Visibility = Visibility.Visible;
                Result.Background = Brushes.Green;
                ResultText.Content = "Gratulacje! Poprawna odpowiedź!";
            } else
            {
                Result.Visibility = Visibility.Visible;
                Result.Background = Brushes.Red;
                ResultText.Content = "Niestety! Niepoprawna odpowiedź!";
            }

            UserAnswer.IsEnabled = false;
            CheckButton.Visibility = Visibility.Collapsed;
            NextButton.Visibility = Visibility.Visible;
        }

        private void Addition(string difficulty)
        {
            var random = new Random();
            int min = 0;
            int max = 0;

            switch (difficulty)
            {
                case "easy":
                    min = 0;
                    max = 10;
                    break;
                case "medium":
                    min = 10;
                    max = 1000;
                    break;
                case "hard":
                    min = 100;
                    max = 10000;
                    break;
            }

            int a = random.Next(min, max);
            int b = random.Next(min, max);
            int result = a + b;
            string expression = $"{a} + {b}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }
    }
}
