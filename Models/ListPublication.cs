using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HereAndShare.Models
{
    public class ListPublication
    {
        //Atribute
        private ObservableCollection<ItemPublication> data;
        //Property
        public ObservableCollection<ItemPublication> Data
        {
            get
            {
                if (data == null)
                {
                    data = new ObservableCollection<ItemPublication>();
                    Image img = new Image();
                    BitmapImage bitmapImage = new BitmapImage();
                    Uri uri = new Uri("ms-appx:///Assets/Logo.png");
                    bitmapImage.UriSource = uri;
                    img.Source = bitmapImage;
                    
                    ItemPublication item1 = new ItemPublication() { Place = "Mattelsa", Product = "Jean Sport Negro", Usuario = "@juanperez", ImageProduct = img, Time=convertTime(System.DateTime.Now), Likes = 100};
                    ItemPublication item2 = new ItemPublication() { Place = "Carbones Dorados", Product = "Un perro especial", Usuario = "@linahoyos", ImageProduct = img, Time = convertTime(System.DateTime.Now), Likes = 2 };
                    ItemPublication item3 = new ItemPublication() { Place = "Specialized Biclycles", Product = "Fat Bike XB200", Usuario = "@marcelag", ImageProduct = img, Time = convertTime(System.DateTime.Now), Likes= 150 };
                    ItemPublication item4 = new ItemPublication() { Place = "Sitio!", Product = "Hamburguesa Doble", Usuario = "@juanperez", ImageProduct = img, Time = convertTime(System.DateTime.Now), Likes = 14 };
                    ItemPublication item5 = new ItemPublication() { Place = "Plazita Terminal", Product = "Piña x 10", Usuario = "@marcelag", ImageProduct = img, Time = convertTime(System.DateTime.Now), Likes = 8 };
                    ItemPublication item6 = new ItemPublication() { Place = "Carbones Dorados", Product = "Lasaña", Usuario = "@marcoprieto", ImageProduct = img, Time = convertTime(System.DateTime.Now), Likes = 26};
                    data.Add(item1);
                    data.Add(item2);
                    data.Add(item3);
                    data.Add(item4);
                    data.Add(item5);
                    data.Add(item6);
                }
                return data;
            }
            set { }
        }

        public String convertTime(DateTime date)
        {
            int remMon = System.DateTime.Now.Month - date.Month;
            int remDay = System.DateTime.Now.Day - date.Day;
            int remHour = System.DateTime.Now.Hour - date.Hour;
            int remMin = System.DateTime.Now.Minute - date.Minute;
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
