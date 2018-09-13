using DesktopShedule.ModelsView;
using SharedSTANDARTLogic.Models.Resource;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DesktopShedule.Views
{
    /// <summary>
    /// Логика взаимодействия для SheduleWindow.xaml
    /// </summary>
    public partial class SheduleWindow : Window
    {
        public SheduleWindow(Dictionary<int, List<Shedule>> dictShedule)
        {
            InitializeComponent();
            int leftMargin = 50;
            for (var a = 0; a < dictShedule.Count; a++) {
                var ls = new ListView();
                ls.HorizontalAlignment = HorizontalAlignment.Left;
                ls.VerticalAlignment = VerticalAlignment.Top;
                ls.Width  = 450 ;

                if (a % 2 == 0)
                {
                    ls.Margin = new Thickness(leftMargin , 50, 0, 0);
                }
                else
                {
                    ls.Margin = new Thickness(leftMargin , 200, 0, 0);
                }
                if (a % 2 !=  0)
                {
                    leftMargin += 460;
                }
                ls.FontSize = 14;


                    ls.Height = 150 ;
                foreach (var it in dictShedule[a]) {
                    ls.Items.Add(it.time  +" - "+ it.subject.Replace("  ", ""));
                }

                GridElement.Children.Add(ls);
            }
        }

    }
}
