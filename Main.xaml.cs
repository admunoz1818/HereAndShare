using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HereAndShare.Resources;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.IO;
using HereAndShare.Net;
using HereAndShare.Models;

namespace HereAndShare
{
    public partial class Main : PhoneApplicationPage, Mongo<ItemPost>.IMongo
    {

        Mongo<ItemPost> mongo;

        /*Constructor*/
        public Main()
        {
            InitializeComponent();
            mongo = new Mongo<ItemPost>("9NlswL-HnWVU8mwH5zi8B8mgF7us7wHl", "hereandshare", "itemsPost");
            mongo.findAllDocuments(this);
        }    

        /*Events*/
        private void ChangedPhotoProfile_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.PixelWidth = 300;
            task.PixelHeight = 300;
            task.Completed += task_Completed;
            task.ShowCamera = true;
            task.Show();
        }

        private void LinkGoToProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Main.xaml?PivotMain.SelectedIndex = 2", UriKind.Relative));
        }

        /*Methods*/
        private void task_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

                //Best practice is to check whether the file with same name doesn't exits then create a new file
                if (!isoStorage.FileExists("existing.jpg"))
                {
                    IsolatedStorageFileStream fileStream = isoStorage.CreateFile("existing.jpg");
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.DecodePixelHeight = 300;
                    bitmap.DecodePixelWidth = 300;
                    bitmap.SetSource(e.ChosenPhoto);
                    WriteableBitmap wb = new WriteableBitmap(bitmap);
                    wb.SaveJpeg(fileStream, 300, 300, 0, 85);
                    fileStream.Close();
                }
                //IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

                //Best practice is to check whether the file with a given name exists in isolated storage or not
                if (isoStorage.FileExists("existing.jpg"))
                {
                    using (IsolatedStorageFileStream fileStream = isoStorage.OpenFile("existing.jpg", FileMode.Open, FileAccess.Read))
                    {
                        //read the saved image
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.SetSource(fileStream);

                        //display the image in the imagecontrol
                        ImageProfile.Source = bitmap;
                    }
                }
            }
        }

        //Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        //To change pivot
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBarDescubre"]);
                    break;
                case 1:
                    ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBarPerfil"]);
                    break;
            }
        }

        public void loadDocuments(List<ItemPost> documents)
        {
            DataModel dmPost = Application.Current.Resources["dataModelPost"] as DataModel;
            dmPost.Data.Clear();
            for (int i = 0; i < documents.Count; i++)
            {
                dmPost.Data.Add(documents.ElementAt(i));
            }
        }
    }
}