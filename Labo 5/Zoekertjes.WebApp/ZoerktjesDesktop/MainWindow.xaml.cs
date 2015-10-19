using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoekertjes.WebApp.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZoerktjesDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebserviceAccess wsa = new WebserviceAccess();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lstData.ItemsSource = await wsa.Load();
            cmbCat.ItemsSource = await wsa.LoadCategories();
            cmbLoc.ItemsSource = await wsa.LoadLocaties();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Zoekertje newZoekertje = new Zoekertje();
            newZoekertje.Titel = txtWat.Text;
            newZoekertje.Omschrijving = txtOmschrijving.Text;
            newZoekertje.Naam = txtNaam.Text;
            newZoekertje.Telefoon = txtTelefoon.Text;
            newZoekertje.Email = txtEmail.Text;
            newZoekertje.Prijs = decimal.Parse(txtPrijs.Text);
            newZoekertje.CategorieId = (cmbCat.SelectedItem as Categorie).Id;
            newZoekertje.LocatieId = (cmbLoc.SelectedItem as Locatie).Id;
            newZoekertje.ContacteerViaEMail = chkMail.IsChecked.Value;
            newZoekertje.ContacteerViaTelefoon = chkTel.IsChecked.Value;

            if (await wsa.AddZoekertje(newZoekertje) == true)
            {
                lstData.ItemsSource = await wsa.Load();
            }
                 
        }


    }
}
