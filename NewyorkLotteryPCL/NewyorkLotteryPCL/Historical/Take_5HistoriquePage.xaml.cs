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
    public partial class Take_5HistoriquePage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public Take_5HistoriquePage()
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
                var take_5s = new List<Take_5>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_usa_api/Api/getAllNew_york_take_5");
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
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        take_5s.Add(new Take_5 { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = take_5s;

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
