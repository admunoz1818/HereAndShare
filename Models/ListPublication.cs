using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    ItemPublication item1 = new ItemPublication() { Place = "Mattelsa", Product = "Jean Sport Negro", Usuario = "@juanperez", ImageProduct = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"))};
                    ItemPublication item2 = new ItemPublication() { Place = "Carbones Dorados", Product = "Un perro especial", Usuario = "@linahoyos", ImageProduct = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"))};
                    ItemPublication item3 = new ItemPublication() { Place = "Specialized Biclycles", Product = "Jean Sport Negro", Usuario = "@marcelag", ImageProduct = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"))};
                    ItemPublication item4 = new ItemPublication() { Place = "Sitio!", Product = "Un perro especial", Usuario = "@juanperez", ImageProduct = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"))};
                    ItemPublication item5 = new ItemPublication() { Place = "Plazita Terminal", Product = "Piña x 10", Usuario = "marcelag"};
                    ItemPublication item6 = new ItemPublication() { Place = "Carbones Dorados", Product = "Lasaña", Usuario = "marcoprieto"};
                    data.Add(item1);
                    data.Add(item2);
                    data.Add(item3);
                    data.Add(item4);
                    //data.Add(item5);
                    //data.Add(item6);
                }
                return data;
            }
            set { }
        }
    }
}
