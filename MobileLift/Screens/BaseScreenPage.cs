using Microsoft.Phone.Controls;
using MobileLift.hyperin;
using MobileLift.Utility;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MobileLift.Screens
{
    public class BaseScreenPage : PhoneApplicationPage
    {
        private static bool isToShowAgain = true ;
        public static bool isToNavigateToContent;
        public BaseScreenPage() 
        { 

        }

        protected override void OnNavigatedTo(NavigationEventArgs e) 
        {
            base.OnNavigatedTo(e);
            if (isToNavigateToContent) {
                isToNavigateToContent = false;
                NavigationService.Navigate(new Uri("/Screens/ContentScreen.xaml", UriKind.Relative));
            }

            if (IsolatedStorageSettings.ApplicationSettings.Contains("IsToShowMobileLift"))
            {
                App.showAgainSetting = (bool)IsolatedStorageSettings.ApplicationSettings["IsToShowMobileLift"];
            }
            else {
                //for first Time
                IsolatedStorageSettings.ApplicationSettings["IsToShowMobileLift"] = true;
                App.showAgainSetting = true;
            }


            if (isToShowAgain && !App.isTransitionState && App.showAgainSetting) 
            {
                App.isTransitionState = true;
                FetchMobileLiftData();
            }
        }

        void FetchMobileLiftData()
        {

            WebClient client = new WebClient();

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadCompletedMLData);

            Uri uri = new Uri("http://hp-test.hyperin.com/hyperin-portal/mobile/lifts?apikey=foo&scid=82201&lang=fi");

            client.DownloadStringAsync(uri);
            
        }

        private void DownloadCompletedMLData(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result != null) {
                List<MobileSpecificContent> contents = XMLParser.ParseMobileLift(e.Result);

                if (contents.Count > 0) {
                    App.CheckForContentData(contents,this);
                    App.isTransitionState = false;
                }
            }
        }



    }
}
