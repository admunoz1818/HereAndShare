using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HereAndShare.Models
{
    public class ItemPost
    {
        public Oid _id { get; set; }
        public String Place { get; set; }
        public String Product { get; set; }
        public String Usuario { get; set; }
        public BitmapImage ImageProduct { get; set; }
        public String Time { get; set; }
    }



}
