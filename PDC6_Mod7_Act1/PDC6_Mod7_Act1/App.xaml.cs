using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_Mod7_Act1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.StudentView());
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
