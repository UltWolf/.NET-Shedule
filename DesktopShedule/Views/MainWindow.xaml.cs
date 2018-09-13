using DesktopShedule.ModelsView;
using SharedSTANDARTLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DesktopShedule
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        MainViewModelView mw;
        public MainWindow()
        {
            InitializeComponent();

            mw = new MainViewModelView();
            DataContext = mw;


        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            mw.CollectionDate = Calendar.SelectedDates;

        }
    }
}
