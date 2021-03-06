﻿using LoiOpdracht.Controllers;
using LoiOpdracht.Models;
using LoiOpdracht.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LoiOpdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CoachButton_Click(object sender, RoutedEventArgs e)
        {
            CoachView coachView = new CoachView();
            coachView.Show();
        }

        private void SpelerButton_Click(object sender, RoutedEventArgs e)
        {
            SpelerView spelerView = new SpelerView();
            spelerView.Show();
        }

        private void TeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamView teamView = new TeamView();
            teamView.Show();
        }
    }
}
;