using Acr.UserDialogs;
using Newtonsoft.Json;
using NewyorkLotteryPCL.AdMob;
using NewyorkLotteryPCL.Historical;
using NewyorkLotteryPCL.Prize;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewyorkLotteryPCL
{
    public partial class MainPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public MainPage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if(GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                adInterstitial = DependencyService.Get<IAdInterstitial>();

                adInterstitial.ShowAd();
            }
            

            callAPI();
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Loading, Please wait...", MaskType.Black);
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_usa_api/Api/getLastNew_york");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //megamillions
                    dynamic megamillions = output["mega_millions"];
                    megamillions_n1.Text = megamillions[0]["n1"];
                    megamillions_n2.Text = megamillions[0]["n2"];
                    megamillions_n3.Text = megamillions[0]["n3"];
                    megamillions_n4.Text = megamillions[0]["n4"];
                    megamillions_n5.Text = megamillions[0]["n5"];
                    megamillions_n6.Text = megamillions[0]["n6"];
                    megamillions_n7.Text = megamillions[0]["n7"];
                    megamillions_jackpot.Text = megamillions[0]["jackpot"];
                    megamillions_tirage_du.Text = megamillions[0]["tirage_du"];
                    megamillions_nextdraw.Text = megamillions[0]["prochain_tirage"];

                    //powerball
                    dynamic powerball = output["power_ball"];
                    powerball_n1.Text = powerball[0]["n1"];
                    powerball_n2.Text = powerball[0]["n2"];
                    powerball_n3.Text = powerball[0]["n3"];
                    powerball_n4.Text = powerball[0]["n4"];
                    powerball_n5.Text = powerball[0]["n5"];
                    powerball_n6.Text = powerball[0]["n6"];
                    powerball_n7.Text = powerball[0]["n7"];
                    powerball_jackpot.Text = powerball[0]["jackpot"];
                    powerball_tirage_du.Text = powerball[0]["tirage_du"];
                    powerball_nextdraw.Text = powerball[0]["prochain_tirage"];

                    //cash4life
                    dynamic cash4life = output["cash_4_life"];
                    cash4life_n1.Text = cash4life[0]["n1"];
                    cash4life_n2.Text = cash4life[0]["n2"];
                    cash4life_n3.Text = cash4life[0]["n3"];
                    cash4life_n4.Text = cash4life[0]["n4"];
                    cash4life_n5.Text = cash4life[0]["n5"];
                    cash4life_n6.Text = cash4life[0]["n6"];
                    cash4life_tirage_du.Text = cash4life[0]["tirage_du"];
                    cash4life_nextdraw.Text = cash4life[0]["prochain_tirage"];

                    //lotto
                    dynamic lotto = output["lotto"];
                    lotto_n1.Text = lotto[0]["n1"];
                    lotto_n2.Text = lotto[0]["n2"];
                    lotto_n3.Text = lotto[0]["n3"];
                    lotto_n4.Text = lotto[0]["n4"];
                    lotto_n5.Text = lotto[0]["n5"];
                    lotto_n6.Text = lotto[0]["n6"];
                    lotto_n7.Text = lotto[0]["n7"];
                    lotto_jackpot.Text = lotto[0]["jackpot"];
                    lotto_tirage_du.Text = lotto[0]["tirage_du"];
                    lotto_nextdraw.Text = lotto[0]["prochain_tirage"];

                    //take_5
                    dynamic take_5 = output["take_5"];
                    take_5_n1.Text = take_5[0]["n1"];
                    take_5_n2.Text = take_5[0]["n2"];
                    take_5_n3.Text = take_5[0]["n3"];
                    take_5_n4.Text = take_5[0]["n4"];
                    take_5_n5.Text = take_5[0]["n5"];
                    take_5_tirage_du.Text = take_5[0]["tirage_du"];
                    take_5_nextdraw.Text = take_5[0]["prochain_tirage"];

                    //numbers_midday
                    dynamic numbers_midday = output["numbers_midday"];
                    numbers_midday_n1.Text = numbers_midday[0]["n1"];
                    numbers_midday_n2.Text = numbers_midday[0]["n2"];
                    numbers_midday_n3.Text = numbers_midday[0]["n3"];
                    numbers_midday_n4.Text = numbers_midday[0]["n4"];
                    numbers_midday_tirage_du.Text = numbers_midday[0]["tirage_du"];
                    numbers_midday_nextdraw.Text = numbers_midday[0]["prochain_tirage"];

                    //numbers_evening
                    dynamic numbers_evening = output["numbers_evening"];
                    numbers_evening_n1.Text = numbers_evening[0]["n1"];
                    numbers_evening_n2.Text = numbers_evening[0]["n2"];
                    numbers_evening_n3.Text = numbers_evening[0]["n3"];
                    numbers_evening_n4.Text = numbers_evening[0]["n4"];
                    numbers_evening_tirage_du.Text = numbers_evening[0]["tirage_du"];
                    numbers_evening_nextdraw.Text = numbers_evening[0]["prochain_tirage"];

                    //win_4_midday
                    dynamic win_4_midday = output["win_4_midday"];
                    win_4_midday_n1.Text = win_4_midday[0]["n1"];
                    win_4_midday_n2.Text = win_4_midday[0]["n2"];
                    win_4_midday_n3.Text = win_4_midday[0]["n3"];
                    win_4_midday_n4.Text = win_4_midday[0]["n4"];
                    win_4_midday_n5.Text = win_4_midday[0]["n5"];
                    win_4_midday_tirage_du.Text = win_4_midday[0]["tirage_du"];
                    win_4_midday_nextdraw.Text = win_4_midday[0]["prochain_tirage"];

                    //win_4_evening
                    dynamic win_4_evening = output["win_4_evening"];
                    win_4_evening_n1.Text = win_4_evening[0]["n1"];
                    win_4_evening_n2.Text = win_4_evening[0]["n2"];
                    win_4_evening_n3.Text = win_4_evening[0]["n3"];
                    win_4_evening_n4.Text = win_4_evening[0]["n4"];
                    win_4_evening_n5.Text = win_4_evening[0]["n5"];
                    win_4_evening_tirage_du.Text = win_4_evening[0]["tirage_du"];
                    win_4_evening_nextdraw.Text = win_4_evening[0]["prochain_tirage"];

                    //pick_10
                    dynamic pick_10 = output["pick_10"];
                    pick_10_n1.Text = pick_10[0]["n1"];
                    pick_10_n2.Text = pick_10[0]["n2"];
                    pick_10_n3.Text = pick_10[0]["n3"];
                    pick_10_n4.Text = pick_10[0]["n4"];
                    pick_10_n5.Text = pick_10[0]["n5"];
                    pick_10_n6.Text = pick_10[0]["n6"];
                    pick_10_n7.Text = pick_10[0]["n7"];
                    pick_10_n8.Text = pick_10[0]["n8"];
                    pick_10_n9.Text = pick_10[0]["n9"];
                    pick_10_n10.Text = pick_10[0]["n10"];
                    pick_10_n11.Text = pick_10[0]["n11"];
                    pick_10_n12.Text = pick_10[0]["n12"];
                    pick_10_n13.Text = pick_10[0]["n13"];
                    pick_10_n14.Text = pick_10[0]["n14"];
                    pick_10_n15.Text = pick_10[0]["n15"];
                    pick_10_n16.Text = pick_10[0]["n16"];
                    pick_10_n17.Text = pick_10[0]["n17"];
                    pick_10_n18.Text = pick_10[0]["n18"];
                    pick_10_n19.Text = pick_10[0]["n19"];
                    pick_10_n20.Text = pick_10[0]["n20"];
                    pick_10_tirage_du.Text = pick_10[0]["tirage_du"];
                    pick_10_nextdraw.Text = pick_10[0]["prochain_tirage"];


                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "An error has occurred, Please try again.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        private void btnMegamillionsPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new MegamillionPrizePage());
        }

        private void btnMegamillionsHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new MegamillionsHistoriquePage());
        }

        private void btnPowerballPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new PowerballPrizePage());
        }

        private void btnPowerballHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new PowerballHistoriquePage());
        }

        private void btnCash4lifePrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Cash4lifePrizePage());
        }

        private void btnCash4lifeHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Cash4lifeHistoriquePage());
        }

        private void btnLottoPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoPrizePage());
        }

        private void btnLottoHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoHistoriquePage());
        }

        private void btnTake5Historique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Take_5HistoriquePage());
        }

        private void btnNumbers_middayHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Numbers_middayHistoriquePage());
        }

        private void btnNumbers_eveningHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Numbers_eveningHistorique());
        }

        private void btnWin_4_middayHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Win_4_middayHistoriquePage());
        }

        private void btnPick10Historique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Pick_10HistoriquePage());
        }

        private void btnWin_4_eveningHistorique_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Win_4_eveningHistoriquePage());
        }
    }
}
