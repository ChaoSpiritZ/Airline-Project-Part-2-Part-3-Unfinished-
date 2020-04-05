using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AirlineProject;

namespace AirlineProjectWPF
{
    class MainWindowViewModel : INotifyPropertyChanged
    {


        public DelegateCommand AddToDB { get; set; }
        public DelegateCommand ReplaceDB { get; set; }

        public int AirlineCompanies { get; set; }
        public int Customers { get; set; }
        public int FlightsPerCompany { get; set; }
        public int TicketsPerCustomer { get; set; }
        public int Countries { get; set; }

        private string _logText;
        public string LogText
        {
            get
            {
                return _logText;
            }
            set
            {
                _logText = value;
                OnPropertyChanged("LogText");
            }
        }

        private string _progressText;
        public string ProgressText
        {
            get
            {
                return _progressText;
            }
            set
            {
                _progressText = value;
                OnPropertyChanged("ProgressText");
            }
        }

        private int _progressBar;
        public int ProgressBar
        {
            get
            {
                return _progressBar;
            }
            set
            {
                _progressBar = value;
                OnPropertyChanged("ProgressBar");
            }
        }

        public MainWindowViewModel()
        {
            AddToDB = new DelegateCommand(AddToDBExecute, AddToDBCanExecute);
            ReplaceDB = new DelegateCommand(ReplaceDBExecute, ReplaceDbCanExecute);

            ProgressText = "Unstarted";

            Task.Run(() =>
            {
                while (true)
                {
                    AddToDB.RaiseCanExecuteChanged();
                    ReplaceDB.RaiseCanExecuteChanged();
                    Thread.Sleep(10);
                }
            });
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// adds rows to the database
        /// </summary>
        public void AddToDBExecute()
        {
            Task.Run(() => 
            {
                ProgressBar = 0;
                ProgressText = "Adding...";
                LogText = string.Empty;
                Thread.Sleep(1000);
                ProgressBar = 20;
                LogText += string.Format($"- {AirlineCompanies} Airline Companies Added \n");
                Thread.Sleep(1000);
                ProgressBar = 40;
                LogText += string.Format($"- {Customers} Customers Added \n");
                Thread.Sleep(1000);
                ProgressBar = 60;
                LogText += string.Format($"- {FlightsPerCompany} Flights Per Company Added \n");
                Thread.Sleep(1000);
                ProgressBar = 80;
                LogText += string.Format($"- {TicketsPerCustomer} Tickets Per Customer Added \n");
                Thread.Sleep(1000);
                ProgressBar = 100;
                LogText += string.Format($"- {Countries} Countries Added \n");
                ProgressText = "Completed!";
            });
        }

        public bool AddToDBCanExecute()
        {
            if(ProgressText == "Unstarted" || ProgressText == "Completed!")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// clears database then adds rows to it
        /// </summary>
        public void ReplaceDBExecute()
        {
            Task.Run(() =>
            {
                ProgressBar = 0;
                ProgressText = "Replacing...";
                LogText = string.Empty;
                Thread.Sleep(1000);
                ProgressBar = 16;
                LogText += "- Cleared Database \n";
                Thread.Sleep(1000);
                ProgressBar = 33;
                LogText += string.Format($"- {AirlineCompanies} Airline Companies Added \n");
                Thread.Sleep(1000);
                ProgressBar = 50;
                LogText += string.Format($"- {Customers} Customers Added \n");
                Thread.Sleep(1000);
                ProgressBar = 66;
                LogText += string.Format($"- {FlightsPerCompany} Flights Per Company Added \n");
                Thread.Sleep(1000);
                ProgressBar = 83;
                LogText += string.Format($"- {TicketsPerCustomer} Tickets Per Customer Added \n");
                Thread.Sleep(1000);
                ProgressBar = 100;
                LogText += string.Format($"- {Countries} Countries Added \n");
                ProgressText = "Completed!";
            });
        }

        public bool ReplaceDbCanExecute()
        {
            if (ProgressText == "Unstarted" || ProgressText == "Completed!")
            {
                return true;
            }
            return false;
        }
    }
}
