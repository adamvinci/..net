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

namespace taches
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         Taches taches = new Taches();
        public MainWindow()
        {
            InitializeComponent();
    this.datagrid.DataContext = taches.TachesList;
            this.combox.DataContext = Enumerable.Range(1, 5).ToList();
        }

        private void Button_ClickSupprimer(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null) MessageBox.Show("you have to select");
            taches.TachesList.Remove((Taches.Tach)datagrid.SelectedItem);
            datagrid.Items.Refresh();
        }
        private void Button_ClickAjouter(object sender, RoutedEventArgs e)
        {
            Taches.Tach tache = new Taches.Tach(description.Text);
            tache.Date = (DateTime)datepicker.SelectedDate;
            tache.Termine = termine.IsChecked.Value;
            tache.Priorite = (int)combox.SelectedItem;
            taches.TachesList.Add(tache);
            datagrid.Items.Refresh();
        }

        private void Button_ClickVider(object sender, RoutedEventArgs e)
        {
            datepicker.SelectedDate = null;
            combox.SelectedItem = null;
            description.Text = null;
        }
    }
}
