﻿#pragma checksum "C:\Users\Adrián\Documents\Visual Studio 2013\Projects\HereAndShare\HereAndShare\Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7F5B54C566CFA9E9C2B632E9D307CE17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace HereAndShare {
    
    
    public partial class Main : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PivotItem PivotDescubre;
        
        internal Microsoft.Phone.Controls.LongListSelector listProducts;
        
        internal Microsoft.Phone.Controls.PivotItem PivotPerfil;
        
        internal System.Windows.Controls.Image ImageProfile;
        
        internal System.Windows.Controls.Button ChangedPhotoProfile;
        
        internal System.Windows.Controls.TextBox ttbName;
        
        internal System.Windows.Controls.TextBox ttbUser;
        
        internal System.Windows.Controls.TextBox ttbCity;
        
        internal System.Windows.Controls.TextBox ttbEmail;
        
        internal System.Windows.Controls.PasswordBox ttbPassword;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/HereAndShare;component/Main.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PivotDescubre = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotDescubre")));
            this.listProducts = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("listProducts")));
            this.PivotPerfil = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotPerfil")));
            this.ImageProfile = ((System.Windows.Controls.Image)(this.FindName("ImageProfile")));
            this.ChangedPhotoProfile = ((System.Windows.Controls.Button)(this.FindName("ChangedPhotoProfile")));
            this.ttbName = ((System.Windows.Controls.TextBox)(this.FindName("ttbName")));
            this.ttbUser = ((System.Windows.Controls.TextBox)(this.FindName("ttbUser")));
            this.ttbCity = ((System.Windows.Controls.TextBox)(this.FindName("ttbCity")));
            this.ttbEmail = ((System.Windows.Controls.TextBox)(this.FindName("ttbEmail")));
            this.ttbPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("ttbPassword")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
        }
    }
}

