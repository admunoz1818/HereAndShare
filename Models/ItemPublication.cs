using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace HereAndShare.Models
{
    public class ItemPublication
    {
        public String Place { get; set; }
        public String Product { get; set; }
        public String Usuario { get; set; }
        public Image ImageProduct { get; set; }
        public String Time { get; set; }
        public int Likes { get; set; }

        public ItemPublication()
        {
            Place = "";
            Product = "";
            Usuario = "";
            ImageProduct = null;
            Time = null;
            Likes = 0;
        }

        public ItemPublication(String Place, String Product, String Usuario, Image ImageProduct, int Likes)
        {
            this.Place = Place;
            this.Product = Product;
            this.Usuario = Usuario;
            this.ImageProduct = ImageProduct;
            this.Time = Time;
            this.Likes = Likes;
        }
    }



}
