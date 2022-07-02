using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileExam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthoPage : ContentPage
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var user = App.Db.GetUser(EPassword.Text);
            if (user != null)
            {
                await Navigation.PushAsync(new NotesPage());
            }
            else
            {
                await DisplayAlert("Ошибка авторизации", "Неверный логин или пароль", "Закрыть");
            }
        }
    }
}