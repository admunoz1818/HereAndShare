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
    public class DataModel
    {        
        //Atribute
        public ObservableCollection<ItemPost> data;
        public ObservableCollection<Profile> dataProfile;

        //Property
        public ObservableCollection<ItemPost> Data
        {
            get
            {
                if (data == null)
                    data = new ObservableCollection<ItemPost>();  
                return data;
            }
            set {
                data = value;
            }
        }
        public ObservableCollection<Profile> DataProfile
        {
            get
            {
                if (dataProfile == null)
                    dataProfile = new ObservableCollection<Profile>();
                return dataProfile;
            }
            set
            {
                dataProfile = value;
            }
        }
    }
}
