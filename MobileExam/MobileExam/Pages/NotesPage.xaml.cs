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
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        private async void LVNotes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Note selectedNote = (Note)e.SelectedItem;
            NotePage selectedNotePage = new NotePage(selectedNote);
            selectedNotePage.BindingContext = selectedNote;
            await Navigation.PushAsync(selectedNotePage);
        }
        protected override void OnAppearing()
        {
            LVNotes.ItemsSource = App.Db.GetNotes();
            base.OnAppearing();
        }

        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNotePage());
        }
    }
}