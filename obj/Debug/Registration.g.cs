﻿#pragma checksum "C:\Users\Adrián\Documents\Visual Studio 2013\Projects\HereAndShare\HereAndShare\Registration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "01C801FD6AF328D39DED4EAF71C9C039"
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
    
    
    public partial class Registration : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox newName;
        
        internal System.Windows.Controls.TextBox newUser;
        
        internal System.Windows.Controls.TextBox newEmail;
        
        internal System.Windows.Controls.PasswordBox newPass1;
        
        internal System.Windows.Controls.PasswordBox newPass2;
        
        internal System.Windows.Controls.Button ButtonRegistration;
        
        internal System.Windows.Controls.HyperlinkButton GoFromRegistrationToMain;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/HereAndShare;component/Registration.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.newName = ((System.Windows.Controls.TextBox)(this.FindName("newName")));
            this.newUser = ((System.Windows.Controls.TextBox)(this.FindName("newUser")));
            this.newEmail = ((System.Windows.Controls.TextBox)(this.FindName("newEmail")));
            this.newPass1 = ((System.Windows.Controls.PasswordBox)(this.FindName("newPass1")));
            this.newPass2 = ((System.Windows.Controls.PasswordBox)(this.FindName("newPass2")));
            this.ButtonRegistration = ((System.Windows.Controls.Button)(this.FindName("ButtonRegistration")));
            this.GoFromRegistrationToMain = ((System.Windows.Controls.HyperlinkButton)(this.FindName("GoFromRegistrationToMain")));
        }
    }
}

