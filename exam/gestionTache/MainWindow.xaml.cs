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

namespace gestionTache
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TacheData tache = new TacheData();
        public MainWindow()
        {
            InitializeComponent();
  
            this.taches.DataContext = tache.getTacheList;
            IList<int> priorités = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                priorités.Add(i);
            }
            PrioriteValeur.DataContext = priorités;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tache newTache = new Tache((string)description.Text, (int)PrioriteValeur.SelectedItem, TermineValeur.IsChecked.Value);
            tache.getTacheList.Add(newTache);
            taches.Items.Refresh();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Tache tacheToDelete = (Tache)taches.SelectedItem;
            tache.getTacheList.Remove(tacheToDelete);
            taches.Items.Refresh();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            taches.SelectedItem = null;
        }
    }
}
