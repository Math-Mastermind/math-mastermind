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
        User user = User.LoadFromFile();

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
                case "delta":
                    Delta(difficulty);
                    break;
                case "logarytm":
                    Logarytm(difficulty);
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
                user.Correct_Answers += 1;

                string difficulty = App.Current.Properties["Difficulty"].ToString();
                switch (difficulty)
                {
                    case "easy":
                        user.XP_Points += 5;
                        user.ELO_Easy += 3;
                        ResultText.Content = $"Gratulacje! Poprawna odpowiedź!\nTwój ranking (łatwy) wynosi {user.ELO_Easy} (+3)";
                        break;
                    case "medium":
                        user.XP_Points += 10;
                        user.ELO_Medium += 5;
                        ResultText.Content = $"Gratulacje! Poprawna odpowiedź!\nTwój ranking (średni) wynosi {user.ELO_Medium} (+5)";
                        break;
                    case "hard":
                        user.XP_Points += 15;
                        user.ELO_Hard += 9;
                        ResultText.Content = $"Gratulacje! Poprawna odpowiedź!\nTwój ranking (trudny) wynosi {user.ELO_Hard} (+9)";
                        break;
                }

            } else
            {
                Result.Visibility = Visibility.Visible;
                Result.Background = Brushes.Red;
                user.Wrong_Answers += 1;

                string difficulty = App.Current.Properties["Difficulty"].ToString();
                switch (difficulty)
                {
                    case "easy":
                        user.XP_Points += 1;
                        user.ELO_Easy -= 1;

                        if (user.ELO_Easy < 0)
                        {
                            user.ELO_Easy = 0;
                        }

                        ResultText.Content = $"Niestety! Niepoprawna odpowiedź!\nPoprawna odpowiedź to {correctAnswer}.\nTwój ranking (łatwy) wynosi {user.ELO_Easy} (-1)";
                        break;
                    case "medium":
                        user.XP_Points += 1;
                        user.ELO_Medium -= 3;

                        if (user.ELO_Medium < 0)
                        {
                            user.ELO_Medium = 0;
                        }

                        ResultText.Content = $"Niestety! Niepoprawna odpowiedź!\nPoprawna odpowiedź to {correctAnswer}.\nTwój ranking (średni) wynosi {user.ELO_Medium} (-3)";
                        break;
                    case "hard":
                        user.XP_Points += 1;
                        user.ELO_Hard -= 8;

                        if (user.ELO_Hard < 0)
                        {
                            user.ELO_Hard = 0;
                        }

                        ResultText.Content = $"Niestety! Niepoprawna odpowiedź!\nPoprawna odpowiedź to {correctAnswer}.\nTwój ranking (trudny) wynosi {user.ELO_Hard} (-8)";
                        break;
                }

            }

            UserAnswer.IsEnabled = false;
            CheckButton.Visibility = Visibility.Collapsed;
            NextButton.Visibility = Visibility.Visible;
            User.SaveToFile(user);
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
                    amin = 12;
                    amax = 30;

                    bmin = 3;
                    bmax = 6;
                    break;
                case "hard":
                    amin = 12;
                    amax = 50;

                    bmin = 4;
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
                    amin = 12;
                    amax = 30;

                    bmin = 4;
                    bmax = 8;
                    break;
                case "hard":
                    amin = 12;
                    amax = 50;

                    bmin = 5;
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
                    min = 6;
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
                    amin = 6;
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

        private void Delta(string difficulty)
        {
            var random = new Random();
            int amin = 0;
            int amax = 0;

            int bmin = 0;
            int bmax = 0;

            int cmin = 0;
            int cmax = 0;
            switch (difficulty)
            {
                case "easy":
                    amin = -2;
                    amax = 2;

                    bmin = -7;
                    bmax = 7;

                    cmin = -5;
                    cmax = 5;
                    break;
                case "medium":
                    amin = -5;
                    amax = 5;

                    bmin = -14;
                    bmax = 14;

                    cmin = -10;
                    cmax = 10;
                    break;
                case "hard":
                    amin = -10;
                    amax = 10;

                    bmin = -20;
                    bmax = 20;

                    cmin = -15;
                    cmax = 15;
                    break;
            }

            int a = random.Next(amin, amax);
            int b = random.Next(bmin, bmax);
            int c = random.Next(cmin, cmax);

            string bString, cString;

            if (b < 0) bString = $"- {Math.Abs(b)}"; else bString = $"+ {b}";
            if (c < 0) cString = $"- {Math.Abs(c)}"; else cString = $"+ {c}";

            double result = Math.Pow(b, 2) - (4 * a * c);
            string expression = $"{a}x\xB2 {bString}x {cString}";

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

        private void Logarytm(string difficulty)
        {
            var random = new Random();
            int amin = 0;
            int amax = 0;

            int bmin = 0;
            int bmax = 0;

            switch (difficulty)
            {
                case "easy":
                    amin = 2;
                    amax = 2;

                    bmin = 1;
                    bmax = 12;
                    break;
                case "medium":
                    amin = 3;
                    amax = 6;

                    bmin = 2;
                    bmax = 7;
                    break;
                case "hard":
                    amin = 4;
                    amax = 10;

                    bmin = 3;
                    bmax = 13;
                    break;
            }

            double a = random.Next(amin, amax);
            double b = random.Next(bmin, bmax);
            double c = Math.Pow(a, b);
            double result = b;
            string expression = "";

            if (a == 2)
            {
                expression = $"log\u2082 {c}";
            }
            else if (a == 3)
            {
                expression = $"log\u2083 {c}";
            }
            else if (a == 4)
            {
                expression = $"log\u2084 {c}";
            }
            else if (a == 5)
            {
                expression = $"log\u2085 {c}";
            }
            else if (a == 6)
            {
                expression = $"log\u2086 {c}";
            }
            else if (a == 7)
            {
                expression = $"log\u2087 {c}";
            }
            else if (a == 8)
            {
                expression = $"log\u2088 {c}";
            }
            else if (a == 9)
            {
                expression = $"log\u2089 {c}";
            }

            Expression.Content = expression;
            App.Current.Properties["CorrectAnswer"] = result;
        }

    }
}
