using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoiOpdracht.Controllers;
using LoiOpdracht.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace LoiOpdracht.Views
{
    /// <summary>
    /// Interaction logic for SpelerKeyPage.xaml
    /// </summary>
    public partial class SpelerKeyPage : Page, INotifyPropertyChanged
    {
        // ----------------------------------------------------------------------
        // Declarations 
        // ----------------------------------------------------------------------
        private readonly ObservableCollection<Speler> spelerList = new ObservableCollection<Speler>();
        private string _selectedSpelerString;
        private Speler _selectedSpeler = new Speler();

        private string _errorText = "Error";
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
        private SpelerController spelerController = new SpelerController();

        public event PropertyChangedEventHandler PropertyChanged;

        public SpelerKeyPage()
        {
            InitializeComponent();
            Init();
        }

        public ObservableCollection<Speler> SpelerList
        {
            get { return spelerList; }
            set { _selectedSpelerString = value.ToString(); }
        }
        public Speler SelectedCoach
        {
            get { return _selectedSpeler; }
            set { _selectedSpeler = (Speler)value; }
        }
        private void Init()
        {
            _errorText = "";
            refreshSpelerCombo();
            DataContext = this;
            NotifyPropertyChanged("Speler1");
        }

        private void refreshSpelerCombo()
        {
            // Ophalen van alleSpelers
            var spelerList1 = spelerController.findAllByNaam();
            foreach (Speler cch in spelerList1)
            {
                spelerList.Add(cch);
                Speler1ComboBox.SelectedItem = 0;
            }
            _selectedSpelerString = "Roel de Lange";
            NotifyPropertyChanged("SpelerList");
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Speler1ComboBox.Text))
            {
                _errorText = "Spelernaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            _selectedSpeler = spelerController.getOnNaam(Speler1ComboBox.Text);

            // Indien de Coach al voorkomt, mag je niet verder gaan
            if (_selectedSpeler != null)// De coach bestaat niet indien gevonden record leeg is.
            {
                _errorText = "Speler naam komt niet voor in bestand, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            _selectedSpeler = new Speler(Speler1ComboBox.Text);

            SpelerDataPage SpelerDataPage = new SpelerDataPage(_selectedSpeler);
            SpelerDataPage.setSpeler(_selectedSpeler);
            this.NavigationService.Navigate(SpelerDataPage);
        }


        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Speler selectedSpeler = (Speler)Speler1ComboBox.SelectedItem;
            if (selectedSpeler == null)
            {
                _errorText = "Spelernaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            _selectedSpeler = spelerController.getOnNaam(selectedSpeler.Naam);

            if (_selectedSpeler == null)
            {
                // Naam komt niet voor, wijzigen is niet mogelijk
                _errorText = "Spelernaam komt niet voor in bestand, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            //coachList.Add(new Coach("xxx de Lange","xxx",true);
            NotifyPropertyChanged("SpelerList"); // method implemented below
                                                 //this.NavigationService.Navigate(new CoachDataPage());

            SpelerDataPage SpelerDataPage = new SpelerDataPage(_selectedSpeler);
            SpelerDataPage.setSpeler(_selectedSpeler);
            this.NavigationService.Navigate(SpelerDataPage);
        }

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((System.Windows.Controls.Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((System.Windows.Controls.Control)sender).ToolTip = "";
            }
        }
    }
}
