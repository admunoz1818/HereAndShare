using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HereAndShare.Models
{
    public class Profile
    {
        public Oid _id { get; set; }
        public String Name { get; set; }
        public String User { get; set; }
        public BitmapImage Photo { get; set; }
        public String City { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
