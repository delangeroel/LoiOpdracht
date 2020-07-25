using System;
using System.Collections.Generic;
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
    /// Interaction logic for CoachDataPage.xaml
    /// </summary>
    public partial class CoachDataPage : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private CoachController coachController = new CoachController();
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
        Coach _selectedCoach = new Coach();
        public Coach Coach
        {
            get
            {
                return _selectedCoach;
            }
            set
            {
                _selectedCoach = value;
            }
        }
        public CoachDataPage(Coach _coach)
        {
            this._selectedCoach = _coach;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _errorText = "";
            DataContext = this;
        }
        public void setCoach(Coach coach)
        {
            this._selectedCoach = coach;
            NotifyPropertyChanged("ErrorText");
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean succesfull = coachController.save(_selectedCoach);
            if (succesfull)
            {
                this.NavigationService.Navigate(new CoachKeyPage());
            }
            else
            {
                _errorText = coachController.getErrors();
                NotifyPropertyChanged("ErrorText");
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean succesfull = coachController.delete(_selectedCoach);
            if (succesfull)
            {
                this.NavigationService.Navigate(new CoachKeyPage());
            }
            else
            {
                _errorText = coachController.getErrors();
                NotifyPropertyChanged("ErrorText");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoachKeyPage());
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
