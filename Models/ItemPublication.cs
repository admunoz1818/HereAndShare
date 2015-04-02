﻿using System;
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
    }
}
