using AdvancedTimer.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewyorkLotteryPCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        IAdvancedTimer timer;

        public SplashPage()
        {
            InitializeComponent();

            timer = DependencyService.Get<IAdvancedTimer>();
            timer.initTimer(3000, timerElapsed, true);
            timer.startTimer();
        }

        private void timerElapsed(object sender, EventArgs e)
        {
            timer.stopTimer();
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage())
                    {
                        BarBackgroundColor = Color.FromHex("#263763"),
                        BarTextColor = Color.White,
                    };
                    Navigation.PushAsync(new MainPage());
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
