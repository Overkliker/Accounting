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
using Accounting.countMoneyDataSetTableAdapters;

namespace Accounting
{
    /// <summary>
    /// Логика взаимодействия для TypesCrud.xaml
    /// </summary>
    public partial class TypesCrud : Page
    {
        DopFuns dop = new DopFuns();
        typesZapTableAdapter types = new typesZapTableAdapter();
        public TypesCrud()
        {
            InitializeComponent();
            TypesGrid.ItemsSource = types.GetData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).AllFrame.Content = null;
        }

        private void AddTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewTpBox.Text != null)
            {
                dop.addType(NewTpBox.Text);
                NewTpBox.Text = null;
                TypesGrid.ItemsSource = types.GetData();
            }

        }
    }
}
