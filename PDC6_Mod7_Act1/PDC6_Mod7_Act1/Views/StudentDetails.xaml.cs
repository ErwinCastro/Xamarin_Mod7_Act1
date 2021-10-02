using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using PDC6_Mod7_Act1.Services;
using PDC6_Mod7_Act1.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_Mod7_Act1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetails : ContentPage
    {

        DBFirebase services;


        public StudentDetails(Student Student)
        {
            InitializeComponent();
            BindingContext = Student;

            services = new DBFirebase();

        }

        public async void BtnDelete(object sender, EventArgs e)
        {

            await services.DeleteStudent(int.Parse(StudentID.Text),StudentName.Text, Course.Text, Year.Text, Section.Text);
            await Navigation.PushAsync(new StudentView());
        }



        public async void BtnUpdate(Object sender, EventArgs e)
        {
            await services.UpdateStudent(int.Parse(StudentID.Text), StudentName.Text, Course.Text, Year.Text, Section.Text);
            await Navigation.PushAsync(new StudentView());

        }
    }
}