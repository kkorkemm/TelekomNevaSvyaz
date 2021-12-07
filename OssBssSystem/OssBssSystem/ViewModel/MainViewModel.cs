using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssBssSystem.ViewModel
{
    using MVVMCore;

    public class MainViewModel :INotify
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public BaseCommand AssetsCommand { get; set; }
        public BaseCommand BillingCommand { get; set; }
        public BaseCommand ClientsCommand { get; set; }
        public BaseCommand CrmCommand { get; set; }
        public BaseCommand ManagementCommand { get; set; }
        public BaseCommand SupportCommand { get; set; }

        public AssetsViewModel AssetsVM { get; set; }
        public BillingViewModel BillingVM { get; set; }
        public ClientsViewModel ClientsVM { get; set; }
        public CrmViewModel CrmVM { get; set; }
        public ManagementViewModel ManagementVM { get; set; }
        public SupportViewModel SupportVM { get; set; }


        public MainViewModel()
        {
            AssetsVM = new AssetsViewModel();
            BillingVM = new BillingViewModel();
            ClientsVM = new ClientsViewModel();
            CrmVM = new CrmViewModel();
            ManagementVM = new ManagementViewModel();
            SupportVM = new SupportViewModel();

            CurrentView = ClientsVM;

            AssetsCommand = new BaseCommand(o =>
            {
                CurrentView = AssetsVM;
            });
            BillingCommand = new BaseCommand(o =>
            {
                CurrentView = BillingVM;
            });
            ClientsCommand = new BaseCommand(o =>
            {
                CurrentView = ClientsVM;
            });
            CrmCommand = new BaseCommand(o =>
            {
                CurrentView = CrmVM;
            });
            ManagementCommand = new BaseCommand(o =>
            {
                CurrentView = ManagementVM;
            });
            SupportCommand = new BaseCommand(o =>
            {
                CurrentView = SupportVM;
            });
        }
    }
}
