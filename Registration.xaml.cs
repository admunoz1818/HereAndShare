using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HereAndShare.Net;
using HereAndShare.Models;

namespace HereAndShare
{
    public partial class Registration : PhoneApplicationPage
    {
        Mongo<Profile> profile;

        /*Constructor*/
        public Registration()
        {
            InitializeComponent();
            profile = new Mongo<Profile>("9NlswL-HnWVU8mwH5zi8B8mgF7us7wHl", "hereandshare", "profiles");
        }

        /*Events*/
        private void GoFromRegistrationToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Main.xaml", UriKind.Relative));
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (newPass1.Password.Equals(newPass2.Password))
                {
                    try
                    {                
                        Profile newProfile = new Profile()
                        {
                            Name = newName.Text,
                            User = newUser.Text,
                            Photo = null,
                            City = "Ciudad",
                            Email = newEmail.Text,
                            Password = newPass1.Password
                        };
                        profile.insertDocument(newProfile);
                        MessageBox.Show("Registrado con éxito!", "¡Mensaje!", MessageBoxButton.OK);
                        NavigationService.Navigate(new Uri("/Main.xaml", UriKind.Relative));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Compruebe la conexión a internet", "Error de conexión", MessageBoxButton.OK);
                        throw;
                    }
                }
                else {
                    MessageBox.Show("Contraseñas no son iguales.", "Error, verificar contraseñas", MessageBoxButton.OK);
                    newPass1.Password = "";
                    newPass2.Password = "";
                }
        }
    }
}