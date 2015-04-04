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

namespace HereAndShare
{
    public partial class NewPublication : PhoneApplicationPage
    {
        public NewPublication()
        {
            InitializeComponent();
            //For load you location
            ShowMyLocationOnTheMap();
        }

        /*For see you location on the map*/
        private async void ShowMyLocationOnTheMap()
        {
            // Get my current location.
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate =
                CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
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

      
                        
    }
}