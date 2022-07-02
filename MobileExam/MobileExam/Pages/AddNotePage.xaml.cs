using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileExam.DB;

namespace MobileExam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotePage : ContentPage
    {
        public AddNotePage()
        {
            InitializeComponent();
        }

        private async void BtnAddNote_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите добавить запись?", "Да", "Нет");

            if (result == true)
            {
                Note note = new Note();
                note.Login =ELogin.Text;
                note.Password = EPassword.Text;
                note.URL = EURL.Text;
                App.Db.SaveNote(note);
                await Navigation.PopAsync();
            }
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        protected override void OnAppearing()
        {
            PType.ItemsSource = App.Db.GetTypes().ToList();
            base.OnAppearing();
        }

        private async void BtnAddType_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTypePage());
        }
    }
}