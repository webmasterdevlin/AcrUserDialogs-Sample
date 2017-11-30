using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace AcrUserDialogsDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            using (IProgressDialog progress = UserDialogs.Instance.Progress("Progress", null, null, true, MaskType.Black))
            {
                for (int i = 0; i < 100; i++)
                {
                    progress.PercentComplete = i;
                    await Task.Delay(60);
                }
            }

            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                await Task.Delay(5000);
            }

            UserDialogs.Instance.ShowError("ShowError (Obselete)", 3000); //Use ShowImage instead
            
            await Task.Delay(4000);

            UserDialogs.Instance.ShowSuccess("ShowSuccess (Obselete)", 3000); //Use ShowImage instead

            await Task.Delay(4000);

            Toast();

            await Task.Delay(5000);

            await UserDialogs.Instance.DatePromptAsync("DatePrompt", DateTime.Now);
        }

        private static void Toast()
        {
            ToastConfig toastConfig = new ToastConfig("Toast");
            toastConfig.SetDuration(3000);
            toastConfig.SetBackgroundColor(Color.DimGray);

            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}