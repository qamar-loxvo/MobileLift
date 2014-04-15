using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MobileLift.Screens
{
    public partial class ContentScreen : PhoneApplicationPage
    {
        
        public ContentScreen()
        {
            InitializeComponent();
            ContentBrowser.LoadCompleted +=ContentBrowser_LoadCompleted;
            if (ContentBrowser.CanGoBack)
            {
                //PreviousButton.IsEnabled = true;
            }
            if (ContentBrowser.CanGoForward)
            {
               // NextButton.IsEnabled = true;
            }
        }

        private void ContentBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (ContentBrowser.CanGoBack) 
            {
                //PreviousButton.IsEnabled = true;
            }
            if (ContentBrowser.CanGoForward)
            {
                //NextButton.IsEnabled = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            if (App.content != null)
            {
                if (App.content.LinkURL != null ? !App.content.LinkURL.Trim().Equals("") : false) 
                {
                    ContentBrowser.Navigate(new Uri(App.content.LinkURL));
                }
            }
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (ContentBrowser.CanGoForward)
            {
                ContentBrowser.GoForward();
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            if (ContentBrowser.CanGoBack)
            {
                ContentBrowser.GoBack();
            }
        }
    }
}