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
    /// Interaction logic for TeamDataPage.xaml
    /// </summary>
    public partial class TeamDataPage : Page, INotifyPropertyChanged
    {
        // ----------------------------------------------------------------------
        // Declarations 
        // ----------------------------------------------------------------------
        // Team related fields
        private readonly ObservableCollection<Team> teamList = new ObservableCollection<Team>();
        private readonly ObservableCollection<Coach> _coachList = new ObservableCollection<Coach>();

        private Coach _selectedCoach1 = new Coach();

        private readonly ObservableCollection<Speler> speler1List = new ObservableCollection<Speler>();
        private string _selectedSpeler1String;


        private readonly ObservableCollection<Speler> speler2List = new ObservableCollection<Speler>();
        private string _selectedSpeler2String;

        // ----------------------------------------------------------------------
        // Combo set selection
        // ----------------------------------------------------------------------
        private Team _selectedTeam;
        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set { _selectedTeam = value; }
        }

        private Speler _selectedSpeler1;
        public Speler SelectedSpeler1
        {
            get { return _selectedSpeler1; }
            set { _selectedSpeler1 = value; }
        }
        public Speler _selectedSpeler2;
        public Speler SelectedSpeler2
        {
            get { return _selectedSpeler2; }
            set { _selectedSpeler2 = value; }
        }

        private Coach _selectedCoach = new Coach();
        public Coach SelectedCoach
        {
            get { return _selectedCoach; }
            set { _selectedCoach = value; }
        }
        public ObservableCollection<Coach> CoachList // Is nodig!
        {
            get { return _coachList; }
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
        private SpelerController spelerController = new SpelerController();

        public event PropertyChangedEventHandler PropertyChanged;


        public TeamDataPage(Team _team)
        {
            _selectedTeam = _team;
            InitializeComponent();
            Init();

            _selectedTeam = teamController.getOnNaam(_team.TeamNaam);
            //_selectedCoach = coachController.getOnNaam("Desiree");// _team.Coach.Naam);
            if (_selectedTeam == null)
            {
                _selectedTeam = new Team();
            }
            if (_selectedTeam.Coach == null)
            {
                Coach coach = new Coach();
                _selectedTeam.Coach = coach;
            }
            if (_selectedTeam.Speler1 == null)
            {
                Speler speler1 = new Speler();
                _selectedTeam.Speler1 = speler1;
            }
            if (_selectedTeam.Speler2 == null)
            {
                Speler speler2 = new Speler();
                _selectedTeam.Speler2 = speler2;
            }

            _selectedCoach = _selectedTeam.Coach;
            _selectedSpeler1 = _selectedTeam.Speler1;
            _selectedSpeler2 = _selectedTeam.Speler2;
            //CoachComboBox.SelectedItem = SelectedTeam.Coach;
            //CoachComboBox.SelectedValue = SelectedTeam.Coach;
            DataContext = this;


        }
        private void Init()
        {
            _errorText = "";
            //refreshTeamComboBox();
            refreshCoachComboBox();
            refreshSpeler1ComboBox();
            refreshSpeler2ComboBox();

        }
        private void refreshTeamComboBox()
        {   // Ophalen van alle Coaches
            var teamList1 = teamController.findAllByNaam();
            foreach (Team team in teamList1)
            {
                teamList.Add(team);
            }

        }
        private void refreshCoachComboBox()
        {   // Ophalen van alle Coaches
            _coachList.Clear();
            //_selectedCoach = null;
            var coachList1 = coachController.findAllByNaam();
            foreach (Coach cch in coachList1)
            {
                _coachList.Add(cch);
                _selectedCoach = cch;
                NotifyPropertyChanged("CoachList");
            }
        }
        private void refreshSpeler1ComboBox()
        {   // Ophalen van alle Coaches
            var speler1Listx = spelerController.findAllByNaam();
            foreach (Speler speler in speler1Listx)
            {
                speler1List.Add(speler);
            }
        }
        private void refreshSpeler2ComboBox()
        {   // Ophalen van alle Coaches
            var speler2Listx = spelerController.findAllByNaam();
            foreach (Speler speler in speler2Listx)
            {
                speler2List.Add(speler);
            }
        }
        public void setTeam(Team team)
        {
            this._selectedTeam = team;
            NotifyPropertyChanged("ErrorText");
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //var test = CoachComboBox.SelectedValue;
            //var test1 = CoachComboBox.SelectedItem;

            var x = _selectedTeam.SoortSport;
            _selectedTeam.Coach = (Coach)CoachComboBox.SelectedItem;
            _selectedTeam.Speler1 = (Speler)Speler1ComboBox.SelectedItem;
            _selectedTeam.Speler2 = (Speler)Speler2ComboBox.SelectedItem;
            Boolean succesfull = teamController.save(_selectedTeam);
            if (succesfull)
            {
                this.NavigationService.Navigate(new TeamKeyPage());
            }
            else
            {
                _errorText = coachController.getErrors();
                NotifyPropertyChanged("ErrorText");
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeamKeyPage());
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeamKeyPage());
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
