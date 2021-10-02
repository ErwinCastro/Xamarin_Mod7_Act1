using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDC6_Mod7_Act1.Models;
using PDC6_Mod7_Act1.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC6_Mod7_Act1.ViewModels;

namespace PDC6_Mod7_Act1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }
        public async void OnItemSelected(Object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetails(student));
            lstStudents.SelectedItem = null;
        }
    }
}