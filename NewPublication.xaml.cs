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
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using Windows.Devices.Geolocation;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.IO;
using HereAndShare.Models;
using HereAndShare.Net;

namespace HereAndShare
{
    public partial class NewPublication : PhoneApplicationPage
    {
        Mongo<ItemPost> itemPostMongo;
        //Constructor
        public NewPublication()
        {
            InitializeComponent();
            //For load you location
            ShowMyLocationOnTheMap();
            itemPostMongo = new Mongo<ItemPost>("9NlswL-HnWVU8mwH5zi8B8mgF7us7wHl", "hereandshare", "itemsPost");
        }

        /*For see you location on the map*/
        private async void ShowMyLocationOnTheMap()
        {
            // Get my current location.
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            // Make my current location the center of the Map.
            this.mapWithMyLocation.Center = myGeoCoordinate;
            this.mapWithMyLocation.ZoomLevel = 13;
            // Create a small circle to mark the current location.
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;
            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;
            // Create a MapLayer to contain the MapOverlay.
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);
            // Add the MapLayer to the Map.
            mapWithMyLocation.Layers.Add(myLocationLayer);
        }

        /*Events*/
        private void ButtonNewCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void ButtonOldImage_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.PixelWidth = 300;
            task.PixelHeight = 300;
            task.Completed += task_Completed;
            task.ShowCamera = true;
            task.Show();
        }

        private void ButtonNewTake_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureTask photoCameraCapture = new CameraCaptureTask();
            photoCameraCapture = new CameraCaptureTask();
            photoCameraCapture.Completed += new EventHandler<PhotoResult>(photoCameraCapture_Completed);
            photoCameraCapture.Show();
        }

        private void NewPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            NewPlace.Text = "";
        }

        private void NewPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NewPlace.Text == "")
            {
                NewPlace.Text = "¿Dónde estás?";
            }
        }

        /*Take photo or load image*/
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
                        newImage.Source = bitmap;
                    }
                }
            }
        }

        private void photoCameraCapture_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication();

                //Best practice is to check whether the file with same name doesn't exits then create a new file
                if (!isoStorage.FileExists("captured.jpg"))
                {
                    IsolatedStorageFileStream fileStream = isoStorage.CreateFile("captured.jpg");
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
                if (isoStorage.FileExists("captured.jpg"))
                {
                    using (IsolatedStorageFileStream fileStream = isoStorage.OpenFile("captured.jpg", FileMode.Open, FileAccess.Read))
                    {
                        //read the saved image
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.SetSource(fileStream);

                        //display the image in the imagecontrol
                        newImage.Source = bitmap;
                    }
                }
            }
        }

        /*To post a recommendation*/
        private void ButtonNewPublication_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                ItemPost newPost = new ItemPost()
                {
                    Place = NewPlace.Text,
                    Product = newProduct.Text,
                    Usuario = "@juanperez",
                    ImageProduct = newImage.Source as BitmapImage,
                    Time = convertTime(System.DateTime.Now)
                };
                itemPostMongo.insertDocument(newPost);
                MessageBox.Show("Recomendación publicada", "¡Aviso!", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/Main.xaml?PivotMain.SelectedIndex = 1", UriKind.Relative));
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe la conexión a internet", "Error de conexión", MessageBoxButton.OKCancel);
                throw;
            }
        }

        //To convert date in string
        public String convertTime(DateTime date)
        {
            int remMon = System.DateTime.Now.Month - date.Month;
            int remDay = System.DateTime.Now.Day - date.Day;
            int remHour = System.DateTime.Now.Hour - date.Hour;
            int remMin = System.DateTime.Now.Minute - date.Minute;

            if (remMin < 0)
                remMin = remMin * (-1);

            String answer = "0 tiempo";

            if (remHour < 1)
            {
                answer = remMin + " mins";
            }
            else
            {
                if (remHour == 1)
                {
                    answer = remHour + " hor";
                }
                else
                {
                    if (remHour >= 2 && remHour <= 24)
                    {
                        answer = remHour + " horas";
                    }
                    else
                    {
                        if (remDay < 7)
                        {
                            answer = remDay + " días";
                        }
                        else
                        {
                            if (remDay >= 7 && remDay <= 14) { answer = "2 semanas"; }
                            if (remDay >= 15 && remDay <= 21) { answer = "3 semanas"; }
                            if (remDay >= 22 && remDay <= 28) { answer = "4 semanas"; }
                            if (remDay >= 29) { answer = "1 mes"; }
                            if (remMon > 1) { answer = remMon + " meses"; }
                        }

                    }
                }
            }
            return answer;
        }
                  
    }
}