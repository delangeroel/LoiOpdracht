using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoiOpdracht.Models;
using LoiOpdracht.Controllers;

namespace LoiOpdracht.Views
{
    /// <summary>
    /// Interaction logic for SpelerDataPage.xaml
    /// </summary>
    public partial class SpelerDataPage : Page
    {

        // ----------------------------------------------------------------------
        // Declarations 
        // ----------------------------------------------------------------------
        private string _errorText = "";
        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value;
            }
        }
        // ----------------------------------------------------------------------
        // Controllers 
        // ----------------------------------------------------------------------
        private SpelerController speler1Controller = new SpelerController();
        private Speler _selectedSpeler1 = new Speler();
        public event PropertyChangedEventHandler PropertyChanged;

        public Speler Speler1
        {
            get
            {
                return _selectedSpeler1;
            }
            set
            {
                _selectedSpeler1 = value;
            }
        }
        // ----------------------------------------------------------------------
        // Program logic 
        // ----------------------------------------------------------------------
        public SpelerDataPage(Speler _speler)
        {
            this._selectedSpeler1 = _speler;
            InitializeComponent();
            Init();
            DataContext = this;
        }
        private void Init()
        {
            _errorText = "";
            DataContext = this;
        }
        public void setSpeler(Speler speler)
        {
            this._selectedSpeler1 = speler;
            NotifyPropertyChanged("ErrorText");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            Boolean succesfull = speler1Controller.save(_selectedSpeler1);
            if (succesfull)
            {
                this.NavigationService.Navigate(new SpelerKeyPage());
            }
            else
            {
                _errorText = speler1Controller.getErrors();
                NotifyPropertyChanged("ErrorText");
            }


        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Boolean succesfull = speler1Controller.delete(_selectedSpeler1);
            if (succesfull)
            {
                this.NavigationService.Navigate(new SpelerKeyPage());
            }
            else
            {
                _errorText = speler1Controller.getErrors();
                NotifyPropertyChanged("ErrorText");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SpelerKeyPage());
        }
        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

