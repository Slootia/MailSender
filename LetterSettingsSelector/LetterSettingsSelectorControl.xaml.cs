using System;
using System.CodeDom;
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

namespace LetterSettingsSelector
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class LetterSettingsSelectorControl : UserControl
    {
        public event RoutedEventHandler btnAddClick;
        public event RoutedEventHandler btnEditClick;
        public event RoutedEventHandler btnDeleteClick;

        public string HeaderText
        {
            get => lHeader.Content.ToString();
            set
            {
                lHeader.Content = value;
            }
        }

        public KeyValuePair<string, string> SelectedItem
        {
            get => new KeyValuePair<string, string>(cbSelect.Text, ((KeyValuePair<string,string>)cbSelect.SelectedItem).Value);
        }

        public Dictionary<string, string> Dictionary
        {
            set
            {
                cbSelect.ItemsSource = value;
                cbSelect.DisplayMemberPath = "Key";
                cbSelect.SelectedValuePath = "Value";
            }
        }

        public LetterSettingsSelectorControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnAddClick?.Invoke(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEditClick?.Invoke(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteClick?.Invoke(sender, e);
        }
    }
}
