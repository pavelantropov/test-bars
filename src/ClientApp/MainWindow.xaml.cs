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

        public void DevExpressBtn_Click(object sender, RoutedEventArgs e)
        {
            var contractsWindow = new ContractsWindow() { Owner = this };
            contractsWindow.Show();
        }
    }
}
