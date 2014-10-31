using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Stool_Telerik.ViewModels;

namespace Stool_Telerik
{
    public partial class Add : PhoneApplicationPage
    {
        public Add()
        {
            InitializeComponent();
            Loaded += Add_Loaded;
        }

        void Add_Loaded(object sender, RoutedEventArgs e)
        {
            this.radDatePicker.Value = DateTime.Now;
            this.radTimePicker.Value = DateTime.Now;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);

        //    if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back
        //        && e.NavigationMode != System.Windows.Navigation.NavigationMode.Forward)
        //    {
        //        // If we are exiting the page because we've navigated back, no need
        //        // to save transient data, because this page will be closed and disposed.
        //        // Otherwise, we're being deactivated, so save transient data 
        //        // in case we get tombstoned
        //        this.State["incompleteEntry"] = this.selectedValueDescription.Text;
        //    }
        //}

        //protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    // If the State dictionary contains our transient data, 
        //    // we're being reactivated so restore the transient data
        //    if (this.State.ContainsKey("incompleteEntry"))
        //    {
        //        this.selectedValueDescription.Text = (string)this.State["incompleteEntry"];
        //    }
        //}

        //save
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            SaveLogEntry();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private async void SaveLogEntry()
        {
            LogData added = new LogData();
            added.DateTime = this.radTimePicker.Value.Value;
            added.Log = this.loginfo.Text;

            App.Lista.Add(added);
            await FileStorageOperations.SaveToLocalFolderAsync(App.Lista);
            //MessageBox.Show("done");
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}