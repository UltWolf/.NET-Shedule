using DesktopShedule.Models;
using DesktopShedule.ModelsView.Components;
using DesktopShedule.Views;
using SharedSTANDARTLogic.Models;
using SharedSTANDARTLogic.Models.Resource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopShedule.ModelsView
{
    class MainViewModelView : BaseModelView
    {
        public ObservableCollection<Shedule> SheduleList {get;set;}
        public Shedule Shedule { get => _shedule; set { _shedule = value; OnPropertyChanged("Shedule"); }  }
        
        public ObservableCollection<String> Groups { get; set; }
        public string GroupName { get { return _groupName; } set { _groupName = value; OnPropertyChanged("GroupName"); }  }

        public string SelectedGroupName { get => _selectedGroupName; set { _selectedGroupName = value; OnPropertyChanged("SelectedGroupName"); } }
        public Boolean IsChosenGroup { get => _isChosenGroup; set { _isChosenGroup = value; OnPropertyChanged("IsChosenGroup"); } }
        public SelectedDatesCollection CollectionDate;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; OnPropertyChanged("CurrentDate"); }
        }

        private DateTime beginDate;
        private DateTime endDate;

        private DateTime _currentDate;
        public  DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value;OnPropertyChanged("SelectedDate"); }
        }
       
        private DateTime?  _selectedDate;
     
        private string _selectedGroupName;
        private string _groupName  ;
        private SheduleGetter SG;
        private Shedule _shedule;
        private Boolean _isChosenGroup;

        public ICommand GetGroup { get; private set; }
        public ICommand GetShedule { get; private set; }
         
        public ICommand SelectionDate { get; private set; }
        public MainViewModelView()
        {
            SG = new SheduleGetter();
            GetGroup = new RelayCommand(GetGroupName);
            GetShedule = new RelayCommand(GetSheduleList);
            SelectionDate = new RelayCommand(selectedRange);
            SelectedDate = DateTime.Now;  
            CurrentDate = DateTime.Now;
        }

        private void  GetGroupName(object obj)
        {
            
                if (GroupName?.Length >= 2)
                {
                    Groups = new ObservableCollection<string>(SG.GetGroups(GroupName).suggestions.ToList());
                    OnPropertyChanged("Groups");
                }
            
        }
        private void selectedRange(object a)
        {

            beginDate = CollectionDate[0];
            endDate = CollectionDate[CollectionDate.Count - 1];
        
        }
        private void GetSheduleList(object obj)
        {
          
            var SW = new SheduleWindow( SG.GetShedule("", "", SelectedGroupName,  beginDate.ToString("dd.MM"), endDate.ToString("dd.MM")));
            SW.Show();
        }
 
       
    }
}
