using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileExam.DB;
using System.IO;

namespace MobileExam
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Project.db";
        internal static Storage db;
        internal static Storage Db
        {
            get
            {
                if (db == null)
                {
                    db = new Storage(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
            }

        }
        public App()
        {
            InitializeComponent();
            if(Db.GetUsers().Count > 0)
                MainPage = new NavigationPage(new Pages.AuthoPage()) { BarBackgroundColor = Color.FromHex("#000000"), BarTextColor = Color.White };
            else
                MainPage = new NavigationPage(new Pages.RegPage()) { BarBackgroundColor = Color.FromHex("#000000"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
