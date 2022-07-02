using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileExam.DB;
using System.Text.RegularExpressions;

namespace MobileExam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            EPassword.IsPassword = true;
            var nums = new Regex(@"[0-9]{4}");
            if (EPassword.Text == EPasswordConfrim.Text)
            {
                if (nums.IsMatch(EPassword.Text) && EPassword.Text.Length <= 6)
                {
                    User user = new User()
                    {
                        Login = ELogin.Text,
                        Password = EPassword.Text
                    };
                    App.Db.SaveUser(user);
                    await Navigation.PushAsync(new AuthoPage());

                }
                else
                    await DisplayAlert("Неверный пароль", $"Пароль должен включать лишь цифры, длина пароля от 4 до 6 символов", "Ладно");

            }
            else
                await DisplayAlert("Пароли не совпадают", $"Пароли должны совпадать", "Ладно");

        }
    }
}