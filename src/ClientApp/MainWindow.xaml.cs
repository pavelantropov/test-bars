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
        public MainWindow()
        {
            InitializeComponent();

            const string serviceRoot = "http://localhost:59623/ContractsDataService.svc";
            var context = new TaskBarsDbEntities(new Uri(serviceRoot));
            ContractsListView.ItemsSource = context.Contracts.Select(c => new ContractTableModel()
            {
                Id = c.Id,
                Index = c.Index,
                CreatedOn = c.CreatedOn,
                UpdatedOn = c.UpdatedOn,
            });
        }
    }
}
