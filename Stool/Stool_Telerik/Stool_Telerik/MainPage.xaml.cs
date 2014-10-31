using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Stool_Telerik.ViewModels;
using Telerik.Windows.Controls;
using System.Windows.Navigation;

namespace Stool_Telerik
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Loaded += Calendar_Loaded;
        }

        //void Calendar_Loaded(object sender, RoutedEventArgs e)
        //{
        //    DisplayAppoitmentForDate(DateTime.Now.Date);
        //}

        //void DisplayAppoitmentForDate(DateTime date)
        //{
            
        //    //await FileStorageOperations.LoadFromLocalFolderAsync();
        //}

        void SomePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ReviewBugger.IsTimeForReview())
            {
                ReviewBugger.PromptUser();
            }
        }

        //about
        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));
        }

        //datepicker
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Add.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void RadCalendar_ItemTap(object sender, CalendarItemTapEventArgs e)
        {
            App.Lista = await FileStorageOperations.LoadFromLocalFolderAsync();
            List<LogData> today = App.Lista.Where(x => x.DateTime.Date == e.Item.Date).ToList();
            if (today.Count == 0)
            {
                MessageBox.Show("You haven't visited your castle today :D");
            }
            else
            {
                string combined = App.Lista.Select(x=> x.Log + " (" + x.DateTime.ToString() + ")").Aggregate((first, second) => first + ", " + second);
                MessageBox.Show(combined);
            }
        }
    }
}
