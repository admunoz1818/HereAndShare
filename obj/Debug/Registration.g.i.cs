﻿#pragma checksum "C:\Users\Adrián\Documents\Visual Studio 2013\Projects\HereAndShare\HereAndShare\Registration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53FD3D177E731FF54FCAEF7275D17745"
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
        
        internal System.Windows.Controls.TextBox nombre;
        
        internal System.Windows.Controls.TextBox usuario;
        
        internal System.Windows.Controls.TextBox correoNuevo;
        
        internal System.Windows.Controls.PasswordBox contra1;
        
        internal System.Windows.Controls.PasswordBox contraR;
        
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
            this.nombre = ((System.Windows.Controls.TextBox)(this.FindName("nombre")));
            this.usuario = ((System.Windows.Controls.TextBox)(this.FindName("usuario")));
            this.correoNuevo = ((System.Windows.Controls.TextBox)(this.FindName("correoNuevo")));
            this.contra1 = ((System.Windows.Controls.PasswordBox)(this.FindName("contra1")));
            this.contraR = ((System.Windows.Controls.PasswordBox)(this.FindName("contraR")));
            this.ButtonRegistration = ((System.Windows.Controls.Button)(this.FindName("ButtonRegistration")));
            this.GoFromRegistrationToMain = ((System.Windows.Controls.HyperlinkButton)(this.FindName("GoFromRegistrationToMain")));
        }
    }
}
