using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        zapisTableAdapter zapis = new zapisTableAdapter();
        typesZapTableAdapter types = new typesZapTableAdapter();
        DopFuns dop = new DopFuns();
        public MainWindow()
        {
            InitializeComponent();
            ZamGrid.ItemsSource = zapis.GetDataBy1(DopFuns.dateCon());
            TypeBox.ItemsSource = types.GetData();
            TypeUpBox.ItemsSource = types.GetData();

            TypeUpBox.DisplayMemberPath = "typeName";
            TypeBox.DisplayMemberPath = "typeName";

            ChacngeDate.SelectedDate = DateTime.Now.Date;
            SumLb.Content = dop.sum();
        }


        private void ChacngeDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string date = DopFuns.timeCon(ChacngeDate.SelectedDate.ToString());
            ZamGrid.ItemsSource = zapis.GetDataBy1(date);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            zapis.DeleteQuery(Convert.ToInt32((ZamGrid.SelectedItem as DataRowView).Row[0]));
            ZamGrid.ItemsSource = zapis.GetDataBy1(DopFuns.timeCon(ChacngeDate.SelectedDate.ToString()));
            NameUpBox.Text = null;
            MoneyUpBox.Text = null;
            SumLb.Content = dop.sum();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameUpBox.Text != null && MoneyUpBox.Text != null && TypeUpBox.SelectedIndex != -1)
                {
                    int ct = 0;
                    if (MoneyUpBox.Text[0] == '-') ct++;
                    for (int i = 0; i < MoneyUpBox.Text.Length; i++)
                    {
                        if (Char.IsDigit(MoneyUpBox.Text[i]))
                        {
                            ct++;
                        }
                    }
                    
                    if (ct == MoneyUpBox.Text.Length)
                    {
                        int type = types.GetData()[TypeUpBox.SelectedIndex].id;
                        int count = Convert.ToInt32(MoneyUpBox.Text);
                        bool entrance;
                        int id = Convert.ToInt32((ZamGrid.SelectedItem as DataRowView).Row[0]);
                        if (count >= 0)
                        {
                            entrance = true;
                        }
                        else
                        {
                            entrance = false;
                        }
                        zapis.UpdateQuery(NameUpBox.Text, type, count, entrance, id);
                        ZamGrid.ItemsSource = zapis.GetDataBy1(DopFuns.timeCon(ChacngeDate.SelectedDate.ToString()));
                        NameUpBox.Text = null;
                        MoneyUpBox.Text = null;
                        SumLb.Content = dop.sum();
                    }

                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameBox.Text != null && MoneyBox.Text != null && TypeBox.SelectedIndex != -1)
                {
                    int ct = 0;
                    if (MoneyBox.Text[0] == '-') ct++;
                    for (int i = 0; i < MoneyBox.Text.Length; i++)
                    {
                        if (Char.IsDigit(MoneyBox.Text[i]))
                        {
                            ct++;
                        }
                    }

                    if (ct == MoneyBox.Text.Length)
                    {
                        int type = types.GetData()[TypeBox.SelectedIndex].id;
                        int count = Convert.ToInt32(MoneyBox.Text);
                        bool entrance;
                        if (count >= 0)
                        {
                            entrance = true;
                        }
                        else
                        {
                            entrance = false;
                        }

                        zapis.InsertQuery(NameBox.Text, type, count, entrance,
                            DopFuns.timeCon(ChacngeDate.SelectedDate.ToString()));
                        ZamGrid.ItemsSource = zapis.GetDataBy1(DopFuns.timeCon(ChacngeDate.SelectedDate.ToString()));
                        NameBox.Text = null;
                        MoneyBox.Text = null;
                        SumLb.Content = dop.sum();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ZamGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((ZamGrid.SelectedItem as DataRowView) != null)
            {
                NameUpBox.Text = (ZamGrid.SelectedItem as DataRowView).Row[1].ToString();
                MoneyUpBox.Text = (ZamGrid.SelectedItem as DataRowView).Row[3].ToString();
            }

        }

        private void NewTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AllFrame.Content = new TypesCrud();
        }

        private void UpdateTpBtn_Click(object sender, RoutedEventArgs e)
        {
            TypeBox.ItemsSource = types.GetData();
            TypeUpBox.ItemsSource = types.GetData();
        }
    }
}
