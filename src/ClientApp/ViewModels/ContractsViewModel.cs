using System;
using System.Collections.ObjectModel;
using ContractsModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.Xpf;

namespace ClientApp.ViewModels
{
    public class ContractsViewModel : ViewModelBase
    {
        private const string _serviceRoot = "http://localhost:59623/ContractsDataService.svc";
        private readonly TaskBarsDbEntities _context;

        public ObservableCollection<Contract> Contracts
        {
            get => GetValue<ObservableCollection<Contract>>();
            private set => SetValue(value);
        }

        public ContractsViewModel()
        {
            _context = new TaskBarsDbEntities(new Uri(_serviceRoot));

            Contracts = IsInDesignMode ? 
                new ObservableCollection<Contract>() : _context.Contracts.ToObservableCollection();
        }

        [Command]
        public void ValidateAndSave(RowValidationArgs args)
        {
            _context.SaveChanges();
        }
    }
}
