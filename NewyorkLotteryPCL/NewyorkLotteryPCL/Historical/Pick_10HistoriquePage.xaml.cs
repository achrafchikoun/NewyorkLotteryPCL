using Acr.UserDialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewyorkLotteryPCL.AdMob;
using NewyorkLotteryPCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewyorkLotteryPCL.Historical
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pick_10HistoriquePage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public Pick_10HistoriquePage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if (GlobalVariable.count == 4)
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
                var pick_10s = new List<Pick_10>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_usa_api/Api/getAllNew_york_pick_10");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject(content);
                    JArray output = JArray.Parse(responseJson.ToString());

                    for (int i = 0; i < output.Count; i++)
                    {
                        string n1 = output.ElementAt(i)["n1"].ToString();
                        string n2 = output.ElementAt(i)["n2"].ToString();
                        string n3 = output.ElementAt(i)["n3"].ToString();
                        string n4 = output.ElementAt(i)["n4"].ToString();
                        string n5 = output.ElementAt(i)["n5"].ToString();
                        string n6 = output.ElementAt(i)["n6"].ToString();
                        string n7 = output.ElementAt(i)["n7"].ToString();
                        string n8 = output.ElementAt(i)["n8"].ToString();
                        string n9 = output.ElementAt(i)["n9"].ToString();
                        string n10 = output.ElementAt(i)["n10"].ToString();
                        string n11 = output.ElementAt(i)["n1"].ToString();
                        string n12 = output.ElementAt(i)["n2"].ToString();
                        string n13 = output.ElementAt(i)["n3"].ToString();
                        string n14 = output.ElementAt(i)["n4"].ToString();
                        string n15 = output.ElementAt(i)["n5"].ToString();
                        string n16 = output.ElementAt(i)["n6"].ToString();
                        string n17 = output.ElementAt(i)["n7"].ToString();
                        string n18 = output.ElementAt(i)["n8"].ToString();
                        string n19 = output.ElementAt(i)["n9"].ToString();
                        string n20 = output.ElementAt(i)["n10"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        pick_10s.Add(new Pick_10 { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, n7 = n7, n8 = n8, n9 = n9, n10 = n10, n11 = n11, n12 = n12, n13 = n13, n14 = n14, n15 = n15, n16 = n16, n17 = n17, n18 = n18, n19 = n19, n20 = n20, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = pick_10s;

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
    }
}
