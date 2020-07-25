using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoiOpdracht.Controllers;
using LoiOpdracht.Models;

namespace LoiOpdracht.Views
{
    /// <summary>
    /// Interaction logic for TeamKeyPage.xaml
    /// </summary>
    public partial class TeamKeyPage : Page, INotifyPropertyChanged
    {
        // ----------------------------------------------------------------------
        // Declarations 
        // ----------------------------------------------------------------------
        private readonly ObservableCollection<Team> teamList = new ObservableCollection<Team>();
        private string _selectedTeamString;
        private Team _selectedTeam = new Team();

        private readonly ObservableCollection<Coach> coachList = new ObservableCollection<Coach>();
        private string _selectedCoachString;
        private Coach _selectedCoach = new Coach();

        private readonly ObservableCollection<Speler> speler1List = new ObservableCollection<Speler>();
        private string _selectedSpeler1String;


        private readonly ObservableCollection<Speler> speler2List = new ObservableCollection<Speler>();
        private string _selectedSpeler2String;
        private Speler _selectedSpeler2 = new Speler();

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
        private TeamController teamController = new TeamController();
        private CoachController coachController = new CoachController();
        private SpelerController speler1Controller = new SpelerController();
        private SpelerController speler2Controller = new SpelerController();

        public event PropertyChangedEventHandler PropertyChanged;

        public TeamKeyPage()
        {
            InitializeComponent();
            Init();
        }

        public ObservableCollection<Team> TeamList
        {
            get { return teamList; }
            set { _selectedTeamString = value.ToString(); }
        }
        public ObservableCollection<Coach> CoachList
        {
            get { return coachList; }
            set { _selectedCoachString = value.ToString(); }
        }
        public ObservableCollection<Speler> Speler1List
        {
            get { return speler1List; }
            set { _selectedSpeler1String = value.ToString(); }
        }
        public ObservableCollection<Speler> Speler2List
        {
            get { return speler2List; }
            set { _selectedSpeler2String = value.ToString(); }
        }

        public string SelectedTeam
        {
            get { return _selectedTeamString; }
        }
        public string SelectedCoach
        {
            get { return _selectedCoachString; }
        }
        public string SelectedSpeler1
        {
            get { return _selectedSpeler1String; }
        }
        public string SelectedSpeler2
        {
            get { return _selectedSpeler2String; }
        }
        private void Init()
        {
            _errorText = "";
            refreshTeamComboBox();
            //refreshCoachComboBox();
            //refreshSpeler1ComboBox();
            //refreshSpeler2ComboBox();
            DataContext = this;
        }

        private void refreshTeamComboBox()
        {
            // Ophalen van alle Coaches
            var teamList1 = teamController.findAllByNaam();
            foreach (Team team in teamList1)
            {
                teamList.Add(team);
                if (TeamComboBox.SelectedValue == null)
                    TeamComboBox.SelectedValue = team;
            }
            NotifyPropertyChanged("TeamList");
        }
        //private void refreshCoachComboBox()
        //{
        //// Ophalen van alle Coaches
        //var coachList = coachController.findAllByNaam();
        //foreach (Coach coach in coachList)
        //{
        //    coachList.Add(coach);
        //    if (CoachComboBox.SelectedValue == null)
        //        TeamComboBox.SelectedValue = coach;
        //    }
        //coachList.Add(new Team("Stefan de Lange"));
        //coachList.Add("Wesley de Lange");
        //coachList.Add("Roel de Lange");
        //coachList.Add("Desiree de Lange"); 
        //
        //    NotifyPropertyChanged("Speler2List");
        //}
        //private void refreshSpeler1ComboBox()
        //{
        //    // Ophalen van alle Coaches
        //    var spelerList1 = spelerController.findAllByNaam();
        //    foreach (Speler splr in spelerList1)
        //    {
        //        speler1List.Add(splr);
        //        comboBox1.SelectedItem = 0;
        //    }    
        //    NotifyPropertyChanged("Speler2List");
        // }
        //private void refreshSpeler2ComboBox()
        //{   // Ophalen van alle Coaches
        //    var spelerList2 = speler2Controller.findAllByNaam();
        //    foreach (Speler splr in speler2List)
        //    {
        //      speler2List.Add(splr);
        //        Speler2ComboBox.SelectedItem = 0;
        //    }
        //    NotifyPropertyChanged("Speler2List");
        //}
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Team _selectedTeam = (Team)TeamComboBox.SelectedItem; ;
            if (string.IsNullOrWhiteSpace(TeamComboBox.Text))
            {
                _errorText = "Teamnaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            if (_selectedTeam is null)
            {
                _selectedTeam = new Team(TeamComboBox.Text);
            }
            _selectedTeam = teamController.getOnNaam(_selectedTeam.TeamNaam);

            // Indien de Coach al voorkomt, mag je die niet verder gaan
            if (_selectedTeam != null)// De coach bestaat niet indien gevonden record leeg is.
            {
                _errorText = "Team naam komt niet voor in bestand, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }

            if (_selectedTeam == null)
            {
                _selectedTeam = new Team(TeamComboBox.Text);
                _selectedTeam.SoortSport = "Tennis";
            }

            TeamDataPage TeamDataPage = new TeamDataPage(_selectedTeam);
            TeamDataPage.setTeam(_selectedTeam);
            this.NavigationService.Navigate(TeamDataPage);
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam = (Team)TeamComboBox.SelectedItem;
            if (selectedTeam == null)
            {
                _errorText = "Teamnaam is niet ingevuld, vul een naam in";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            _selectedTeam = teamController.getOnNaam(selectedTeam.TeamNaam);

            if (_selectedTeam == null)
            {
                // Naam komt niet voor, wijzigen is niet mogelijk
                _errorText = "Teamnaam komt niet voor in bestand, kies een andere naam";
                NotifyPropertyChanged("ErrorText");
                return;
            }
            //coachList.Add(new Coach("xxx de Lange","xxx",true);
            NotifyPropertyChanged("TeamList"); // method implemented below
                                               //this.NavigationService.Navigate(new CoachDataPage());
            if (_selectedTeam == null)
            {
                _selectedTeam = new Team(TeamComboBox.Text);
            }
            TeamDataPage TeamDataPage = new TeamDataPage(_selectedTeam);
            TeamDataPage.setTeam(_selectedTeam);
            this.NavigationService.Navigate(TeamDataPage);
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


