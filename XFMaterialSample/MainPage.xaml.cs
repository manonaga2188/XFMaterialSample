using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.Resources;
using XF.Material.Forms.Resources.Typography;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;
using XFMaterialSample.Controls;

namespace XFMaterialSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<string> Jobs { get; set; }
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
        }

        private async void MaterialButton_Clicked(object sender, EventArgs e)
        {
            var alertDialogConfiguration = new MaterialAlertDialogConfiguration
            {
                BackgroundColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.PRIMARY),
                TitleTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.SECONDARY),
                TitleFontFamily = XF.Material.Forms.Material.GetResource<OnPlatform<string>>("FontFamily.RobotoBold"),
                MessageTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.SECONDARY).MultiplyAlpha(0.8),
                TintColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.SECONDARY),
                CornerRadius = 8,
                ScrimColor = Color.FromHex("#232F34").MultiplyAlpha(0.32),
                ButtonAllCaps = false
            };
            await MaterialDialog.Instance.AlertAsync(message: "This is an alert dialog",
                                                title: "Alert Dialog",
                                                acknowledgementText: "Got It",
                                                configuration: alertDialogConfiguration);

        }

        private async void MaterialButton_Clicked_1(object sender, EventArgs e)
        {
            var choices = new string[]
{
    "Biology",
    "Psychology",
    "Phsyics",
    "Chemistry"
};

            var view = new MaterialRadioButtonGroup()
            {
                Choices = choices
            };

            bool? wasConfirmed = await MaterialDialog.Instance.ShowCustomContentAsync(view, "What field of science is considered as the study of life?", "Question 1", "OK", "Cancel");
            Debug.WriteLine(wasConfirmed);


        }

        private async void MaterialButton_Clicked_2(object sender, EventArgs e)
        {
            var jobs = new string[]
{
    "Mobile Developer (Xamarin)",
    "Mobile Developer (Native)",
    "Web Developer (.NET)",
    "Web Developer (Laravel)",
    "Quality Assurance Engineer",
    "Business Analyst",
    "Recruitment Officer",
    "Project Manager",
    "Scrum Master"
};

            //Show confirmation dialog for choosing one.
            var result = await MaterialDialog.Instance.SelectChoicesAsync(title: "Select a job",
                selectedIndices: new int[] { 1, 6 },
                                                              choices: jobs);
        }

        private async void MaterialButton_Clicked_3(object sender, EventArgs e)
        {
            var config = new MaterialInputDialogConfiguration()
            {
                InputType = MaterialTextFieldInputType.Password,
                CornerRadius = 8,
                BackgroundColor = Color.FromHex("#2c3e50"),
                InputTextColor = Color.White,
                InputPlaceholderColor = Color.White.MultiplyAlpha(0.6),
                TintColor = Color.White,
                TitleTextColor = Color.White,
                MessageTextColor = Color.FromHex("#DEFFFFFF"),
               
            };
            var input = await MaterialDialog.Instance.InputAsync(title: "Deactivate account",
                                                     message: "To continue, please enter your current password",
                                                     inputPlaceholder: "Email",
                                                     confirmingText: "Deactivate",
                                                     configuration: config);
        }

        private async void MaterialButton_Clicked_4(object sender, EventArgs e)
        {
            var cc = XF.Material.Forms.Material.GetResource<OnPlatform<string>>("FontFamily.OpenSansRegular");
            var alertLoadingConfiguration = new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.PRIMARY),
                MessageTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_BACKGROUND).MultiplyAlpha(0.8),
                TintColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.SECONDARY),
                CornerRadius = 8,
                ScrimColor = Color.FromHex("#232F34").MultiplyAlpha(0.32)
            };
            using (var dialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Something is running", configuration: alertLoadingConfiguration))
            {
                await Task.Delay(5000); // Represents a task that is running.
                dialog.MessageText = "Something else is running now!";
                await Task.Delay(5000);// Represents a task that is running.
            };

        }

        private async void MaterialButton_Clicked_5(object sender, EventArgs e)
        {
            await MaterialDialog.Instance.SnackbarAsync(message: "This is a snackbar.",
                                            actionButtonText: "Got It",
                                            msDuration: 3000);
            using (var snackbar = await MaterialDialog.Instance.LoadingSnackbarAsync(message: "Something is running"))
            {
                await Task.Delay(5000); // Represents a task that is running.
                snackbar.MessageText = "Something else is running now!";
                await Task.Delay(5000); // Represents a task that is running.
            }
        }

        private async void MaterialButton_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        private async void MaterialButton_Clicked_7(object sender, EventArgs e)
        {
            await MaterialDialog.Instance.AlertAsync(message: txtPicker.Text + " - " + txtPicker.Text,
                                                title: "Alert Dialog",
                                                acknowledgementText: "Got It");
        }

        private async void MaterialButton_Clicked_8(object sender, EventArgs e)
        {
            //RadioButtonOpener rb = (RadioButtonOpener)sender;
            var jobs = new string[]
                            {
                                "Mobile Developer (Xamarin)",
                                "Mobile Developer (Native)",
                                "Web Developer (.NET)",
                                "Web Developer (Laravel)",
                                "Quality Assurance Engineer",
                                "Business Analyst",
                                "Recruitment Officer",
                                "Project Manager",
                                "Scrum Master"
                            };

            //Show confirmation dialog for choosing one.
            var result = await MaterialDialog.Instance.SelectChoiceAsync(title: "Select a job",
                selectedIndex:-1,
                choices: jobs);
            if (result >= 0)
            {
                ((MaterialButton)sender).Text = jobs[result].ToString();
                // rb.SelectedIndex = result;

                //// rb.SelectedItem = s;
                // rb.Text = jobs[result].ToString();
            }
        }


    }
}
