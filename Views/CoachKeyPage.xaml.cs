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
    /// Interaction logic for CoachKeyPage.xaml
    /// </summary>
    public partial class CoachKeyPage : Page, INotifyPropertyChanged
    {
        // ----------------------------------------------------------------------
        // Declarations 
        // ----------------------------------------------------------------------
        private readonly ObservableCollection<Coach> coachList = new ObservableCollection<Coach>();
        private string _selectedCoachString;
        private Coach _selectedCoach;

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
        private CoachController coachController = new CoachController();

        public event PropertyChangedEventHandler PropertyChanged;

        public CoachKeyPage()
        {
            InitializeComponent();
            Init();
        }

        public ObservableCollection<Coach> CoachList
        {
            get { return coachList; }
            set { _selectedCoachString = value.ToString(); }
        }
        public string SelectedCoach
        {
            get { return _selectedCoachString; }
        }
        private void Init()
        {
            _errorText = "";
            refreshCoachCombo();
            DataContext = this;
        }
        private void refreshCoachCombo()
        {
            // Ophalen van alle Coaches
            var coachList1 = coachController.findAllByNaam();
            foreach (Coach cch in coachList1)
            {
                coachList.Add(cch);
                CoachComboBox.SelectedItem = 0;
            }
            //coachList.Add(new Coach("Stefan de Lange","",true));
            //_selectedCoachString = "Stefan de Lange";

            NotifyPropertyChanged("CoachList");

        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            // Controleren
            Coach selectedCoach = (Coach)CoachComboBox.SelectedItem;
            if (string.IsNullOrWhiteSpace(CoachComboBox.Text))
            {
                _errorText = "Coachnaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }

            _selectedCoach = coachController.getOnNaam(CoachComboBox.Text);

            // Indien de Coach al voorkomt, mag je die niet verder gaan
            if (_selectedCoach != null)// De coach bestaat niet indien gevonden record leeg is.
            {
                _errorText = "Coach bestaat al, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            if (_selectedCoach == null)
            {
                _selectedCoach = new Coach(CoachComboBox.Text);
            }
            // Uitvoeren
            CoachDataPage CoachDataPage = new CoachDataPage(_selectedCoach);
            CoachDataPage.setCoach(_selectedCoach);
            this.NavigationService.Navigate(CoachDataPage);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Coach selectedCoach = (Coach)CoachComboBox.SelectedItem;
            if (selectedCoach == null)
            {
                _errorText = "Coachnaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            _selectedCoach = coachController.getOnNaam(selectedCoach.Naam);

            if (_selectedCoach == null)
            {
                // Naam komt niet voor, wijzigen is niet mogelijk
                _errorText = "Coachnaam komt niet voor in bestand, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            //coachList.Add(new Coach("xxx de Lange","xxx",true);
            NotifyPropertyChanged("CoachList"); // method implemented below
                                                //this.NavigationService.Navigate(new CoachDataPage());

            CoachDataPage CoachDataPage = new CoachDataPage(_selectedCoach);
            CoachDataPage.setCoach(_selectedCoach);
            this.NavigationService.Navigate(CoachDataPage);
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
