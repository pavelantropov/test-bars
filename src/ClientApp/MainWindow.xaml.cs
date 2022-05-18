using DevExpress.Xpf.Core;
using System;
using DevExpress.Xpf.Grid;


namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
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
