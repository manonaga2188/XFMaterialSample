using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.Models;
using XFMaterialSample.ViewModel;

namespace XFMaterialSample
{
    public class HomeViewModel:BaseViewModel
    {
        ObservableCollection<string> jobs;
        public MaterialMenuItem[] Actions => new MaterialMenuItem[]
        {
            new MaterialMenuItem
            {
                Text = "Edit"
            },
            new MaterialMenuItem
            {
                Text = "Delete"
            }
        };
        public Command BtnCommand { get; set; }
        private string btnText;
        public HomeViewModel()
        {
            Jobs = new ObservableCollection<string>() {
            "Mobile Developement(Xamarin)",
            "Mobile Developement(Native)",
            "Web Developer",
            "Web Developer(Laravel)",
            "Quality Engineer",
            "Business Analyst",
                "HR Manager(Process)",
            "Project Manager"
            };
            BtnText = "Radio BUtton";
            BtnCommand = new Command(()=> {
                BtnText = "Clicked"; 
            });
        }

        public ObservableCollection<string> Jobs { get => jobs; set { jobs = value;OnPropertyChanged(); } }

        public string BtnText { get => btnText; set { btnText = value; OnPropertyChanged(); } }
    }
}
