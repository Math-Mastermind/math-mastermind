using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;
using System.Reflection.Emit;
using System.Windows.Controls;
using System.Runtime.InteropServices;

namespace MathMastermind
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    /// 

    public class User {
        public int XP_Points { get; set; }
        public int ELO_Easy { get; set; }
        public int ELO_Medium { get; set; }
        public int ELO_Hard { get; set; }
        public int Correct_Answers { get; set; }
        public int Wrong_Answers { get; set; }

        public User()
        {
            if (!File.Exists("UserConfig.json"))
            {
                XP_Points = 0;
                ELO_Easy = 0;
                ELO_Medium = 0;
                ELO_Hard = 0;
                Correct_Answers = 0;
                Wrong_Answers = 0;

                SaveToFile(this);
            }
        }

        public static void SaveToFile(User user)
        {
            string fileName = "UserConfig.json";
            string jsonString = JsonSerializer.Serialize(user);
            File.WriteAllText(fileName, jsonString);
        }

        public static User LoadFromFile()
        {
            string fileName = "UserConfig.json";
            string jsonString = File.ReadAllText(fileName);
            User user = JsonSerializer.Deserialize<User>(jsonString);

            return user;
        }
    }
    public partial class App : Application
    {
        static App()
        {
            User user = new User();
        }
    }
}
