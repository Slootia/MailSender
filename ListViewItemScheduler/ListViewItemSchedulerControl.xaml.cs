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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewItemScheduler
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ListViewItemSchedulerControl : UserControl
    {
        public DateTime? Time { get; set; }
        public ListViewItemSchedulerControl()
        {
            InitializeComponent();
        }


        public event RoutedEventHandler btnEditLetterClick;
        public event RoutedEventHandler btnDeleteClick;
        private void btnEditLetter_Click(object sender, RoutedEventArgs e)
        {
            btnEditLetterClick?.Invoke(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteClick?.Invoke(sender, e);
        }

        private void dtpSendTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Time = dtpSendTime.Value;
        }
    }
}
