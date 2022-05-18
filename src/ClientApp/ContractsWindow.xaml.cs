using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;


namespace ClientApp
{
    /// <summary>
    /// Interaction logic for ContractsWindow.xaml
    /// </summary>
    public partial class ContractsWindow : ThemedWindow
    {
        public ContractsWindow()
        {
            InitializeComponent();
        }
        private void ContractsGrid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (!e.IsGetData) return;

            var updatedOn = Convert.ToDateTime(e.GetListSourceFieldValue("UpdatedOn"));
            e.Value = (DateTime.UtcNow - updatedOn).Days < 30;
        }
    }
}
