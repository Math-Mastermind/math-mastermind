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
            string difficulty = App.Current.Properties["Difficulty"].ToString();

            Result.Visibility = Visibility.Collapsed;
            UserAnswer.IsEnabled = true;
            UserAnswer.Text = "";

            switch (mode)
            {
                case "addition":
                    Addition(difficulty);
                    break;
                case "substraction":
                    Substraction(difficulty);
                    break;
                case "multiplication":
                    Multiplication(difficulty);
                    break;
                case "division":
                    Division(difficulty);
                    break;
                case "root":
                    Root(difficulty);
                    break;
                case "power":
                    Power(difficulty);
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
                    min = 1;
                    max = 30;
                    break;
                case "medium":
                    min = 1;
                    max = 100;
                    break;
                case "hard":
                    min = 100;
                    max = 5000;
                    break;
            }

            int a = random.Next(min, max);
            int b = random.Next(min, max);
            int result = a + b;
            string expression = $"{a} + {b}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Substraction(string difficulty)
        {
            var random = new Random();
            int min = 0;
            int max = 0;

            switch (difficulty)
            {
                case "easy":
                    min = 1;
                    max = 30;
                    break;
                case "medium":
                    min = 1;
                    max = 100;
                    break;
                case "hard":
                    min = 100;
                    max = 5000;
                    break;
            }

            int a = random.Next(min, max);
            int b = random.Next(min, max);
            int result = a - b;
            string expression = $"{a} - {b}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Multiplication(string difficulty)
        {
            var random = new Random();
            int amin = 0;
            int amax = 0;

            int bmin = 0;
            int bmax = 0;

            switch (difficulty)
            {
                case "easy":
                    amin = 1;
                    amax = 10;

                    bmin = 1;
                    bmax = 10;
                    break;
                case "medium":
                    amin = 1;
                    amax = 30;

                    bmin = 1;
                    bmax = 6;
                    break;
                case "hard":
                    amin = 1;
                    amax = 50;

                    bmin = 2;
                    bmax = 10;
                    break;
            }

            int a = random.Next(amin, amax);
            int b = random.Next(bmin, bmax);
            int result = a * b;
            string expression = $"{a} • {b}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Division(string difficulty)
        {
            var random = new Random();
            int amin = 0;
            int amax = 0;

            int bmin = 0;
            int bmax = 0;

            switch (difficulty)
            {
                case "easy":
                    amin = 1;
                    amax = 10;

                    bmin = 1;
                    bmax = 10;
                    break;
                case "medium":
                    amin = 5;
                    amax = 30;

                    bmin = 2;
                    bmax = 6;
                    break;
                case "hard":
                    amin = 7;
                    amax = 50;

                    bmin = 2;
                    bmax = 10;
                    break;
            }

            int a = random.Next(amin, amax);
            int b = random.Next(bmin, bmax);
            int result = (a*b) / b;
            string expression = $"{a*b} ÷ {b}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Root(string difficulty)
        {
            var random = new Random();
            int min = 0;
            int max = 0;
            int index = 0;
            switch (difficulty)
            {
                case "easy":
                    min = 1;
                    max = 10;
                    index = 2;
                    break;
                case "medium":
                    min = 10;
                    max = 20;
                    index = 2;
                    break;
                case "hard":
                    min = 1;
                    max = 20;
                    index = 3;
                    break;
            }

            int a = random.Next(min, max);
            int result = a;
            string expression = "";

            if (index == 2)
            {
                expression = $"\u00B2\u221A{a * a}";
            } else if (index ==3) 
            {
                expression = $"\u00B3\u221A{a * a * a}";
            }


            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Power(string difficulty)
        {
            var random = new Random();
            int amin = 0;
            int amax = 0;

            int bmin = 0;
            int bmax = 0;

            switch (difficulty)
            {
                case "easy":
                    amin = 1;
                    amax = 10;

                    bmin = 2;
                    bmax = 2;
                    break;
                case "medium":
                    amin = 3;
                    amax = 12;

                    bmin = 3;
                    bmax = 3;
                    break;
                case "hard":
                    amin = 2;
                    amax = 12;

                    bmin = 3;
                    bmax = 7;
                    break;
            }

            double a = random.Next(amin, amax);
            double power = random.Next(bmin, bmax);
            double result = 0;
            string expression = "";
            if (power == 2)
            {
                result = Math.Pow(a,power);
                expression = $"{a}\u00B2";
            }
            else if (power == 3)
            {
                result = Math.Pow(a, power);
                expression = $"{a}\u00B3";
            }
            else if (power == 4)
            {
                result = Math.Pow(a, power);
                expression = $"{a}\u2074";
            }
            else if (power == 5)
            {
                result = Math.Pow(a, power);
                expression = $"{a}\u2075";
            }
            else if (power == 6)
            {
                result = Math.Pow(a, power);
                expression = $"{a}\u2076";
            }

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }


    }
}
