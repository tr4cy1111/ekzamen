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
    public partial class AddTypePage : ContentPage
    {
        public AddTypePage()
        {
            InitializeComponent();
        }

        private async void BtnAddType_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите добавить {EType.Text}?", "Да", "Нет");

            if (result == true)
            {
                DB.Type type = new DB.Type();
                type.Name = EType.Text;
                App.Db.SaveType(type);
                await Navigation.PopAsync();
            }
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}