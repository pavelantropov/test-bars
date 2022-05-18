using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using ClientApp.Models;
using ContractsModel;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _serviceRoot = "http://localhost:59623/ContractsDataService.svc";
        private readonly TaskBarsDbEntities _context;

        public MainWindow()
        {
            InitializeComponent();
            
            _context = new TaskBarsDbEntities(new Uri(_serviceRoot));
            ContractsListView.ItemsSource = _context.Contracts.Select(c => new ContractTableModel(c));
        }

        public void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractsListView.ItemsSource = _context.Contracts.Select(c => new ContractTableModel(c));
        }

        public void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateWindow { Owner = this };
            createWindow.Show();
        }

        public void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ContractsListView.SelectedItem == null)
            {
                return;
            }

            var changeWindow = new ChangeWindow { Owner = this };
            changeWindow.Show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ContractsListView.SelectedItem == null)
            {
                return;
            }

            var deleteWindow = new DeleteWindow { Owner = this };
            deleteWindow.Show();
        }
    }
}
