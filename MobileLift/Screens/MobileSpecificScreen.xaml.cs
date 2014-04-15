using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using MobileLift.hyperin;
using MobileLift.Resources;

namespace MobileLift.Screens
{
    public partial class MobileSpecificScreen : PhoneApplicationPage
    {
        private MobileSpecificContent gotContent;
        public MobileSpecificScreen()
        {
            InitializeComponent();
        }

        private void showContentAgain_Checked(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["IsToShowMobileLift"] = true;
        }

        private void goToDetail_Click(object sender, RoutedEventArgs e)
        {
            if (gotContent.LinkURL != null)
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                    BaseScreenPage.isToNavigateToContent = true;
                }
               

            }
            else 
            {
                if (NavigationService.CanGoBack)
                    NavigationService.GoBack();
            }
        }

        private void closeButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {


            gotContent = App.content;
            MapFields();
        }

        private void MapFields() 
        {
            pageTitle.Text = AppResources.AppName + " - " + AppResources.ContentScreeenTitle;
            contentTitle.Text = gotContent.Title;
            contentDescription.Text = gotContent.Description;
            if (gotContent.LinkURL != null)
            {
                if (gotContent.LinkText != null ? !gotContent.LinkText.Trim().Equals("") : false)
                {
                    goToDetail.Content = gotContent.LinkText;
                }
            }
            else 
            {
                goToDetail.Content = AppResources.ContentScreenClose; ;
                closeButton.Visibility = System.Windows.Visibility.Collapsed;
            }



        }

        private void showContentAgain_Unchecked(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["IsToShowMobileLift"] = false;
        }
        
        
    }
}