using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectManagerTwo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", "lol");
            DisplayAlert("hehehe", "hohoho", "lol");
        }
    }
}
