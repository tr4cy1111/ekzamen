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
    public partial class NotePage : ContentPage
    {
        private static Note currentNote;
        private static DB.Type currentType;
        public NotePage(Note note)
        {
            InitializeComponent();
            currentNote = note;
            BindingContext = note;
            currentType = App.Db.GetTypes().Where(t => t.Id == currentNote.ID_Type).FirstOrDefault();
            PType.SelectedItem = currentType;
            BindingContext = currentType;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы хотите изменить данные?", "Да", "Отмена"))
            {
                if (!String.IsNullOrEmpty(currentNote.Login))
                {
                    App.Db.SaveNote(currentNote);
                }
                await Navigation.PushAsync(new NotesPage());
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы хотите удалить данные?", "Да", "Отмена"))
            {
                App.Db.DeleteProject(currentNote.Id);
                await Navigation.PushAsync(new NotesPage());
            }
        }

        private async void BtnAddType_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTypePage());
        }
        protected override void OnAppearing()
        {
            PType.ItemsSource = App.Db.GetTypes().ToList();
            base.OnAppearing();
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}