using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        int modositas = 0;
        int hozzaadas = 0;
        int mindenTorlese = 0;
        int tesztAdatokTorlese = 0;
        int kijeloltAdatokTorlese = 0;
        public MainWindow()
        {
            
            InitializeComponent();
            this.Title = "Todo List";
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ha valóban ki szeretne lépni, nyomja meg az 'Ok' gombot. \n" +
                $"Módosíások száma: {modositas} \n" +
                $"Hoáadáasok száma: {hozzaadas} \n" +
                $"Teljes törlések száma: {mindenTorlese} \n" +
                $"Tesztadatok törlésének száma: {tesztAdatokTorlese} \n" +
                $"Kijelölt adatok törlésének száma: {kijeloltAdatokTorlese}");

            Application.Current.Shutdown();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Megakadályozzuk az ablak bezárását
            e.Cancel = true;
        }

        private bool buttonClicked = false;

        private bool buttonClicked2 = false;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Tesztadatok törlése
            if (!buttonClicked)
            {
                buttonClicked = true;
                Lista.Items.Clear();
                TesztAdat.Visibility = Visibility.Hidden;
                tesztAdatokTorlese += 1;
            }
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //Item hozzáadása a listához
            string newItem = Feladat.Text;
            if (!string.IsNullOrEmpty(newItem) && !Lista.Items.Contains(newItem))
            {
                Lista.Items.Add(newItem); 
                Feladat.Text = "";
                hozzaadas += 1;
            }
            else if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("Üres a mező, ezért nincs mit hozzáadni a listához!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Ha az új elem már szerepel a listában, akkor hibaüzenet jelenik meg

                MessageBox.Show("Az elem már szerepel a listában!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //Kijelölt adaok törlése
        {
            // Ellenőrizzük, hogy van-e kijelölt elem a ListBox-ban
            if (Lista.SelectedIndex != -1)
            {
                // Töröljük az elemet az ObservableCollection-ból a kijelölt index alapján
                Lista.Items.RemoveAt(Lista.SelectedIndex);
                kijeloltAdatokTorlese += 1;
            }
            else
            {
                MessageBox.Show("Válasszon ki egy elemet a törléshez!");
            }
        }

        private void Modositas_Click(object sender, RoutedEventArgs e)
        {
            string newText = Mszoveg.Text;
            if (!string.IsNullOrEmpty(newText)) { 
                if (Lista.SelectedIndex != -1)
                {
                    Lista.Items[Lista.SelectedIndex] = newText;
                    Mszoveg.Text = "";
                    modositas += 1;
                }
            }
            else if (string.IsNullOrEmpty(newText))
            {
                MessageBox.Show("Üres a mező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Válasszon ki egy elemet a módosításhoz!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MindenTorlese_Click(object sender, RoutedEventArgs e)
        {
            if (!buttonClicked2)
            {
                buttonClicked = true;
                Lista.Items.Clear();
                mindenTorlese += 1;
            }
            
        }
        public void MainWindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        
    }
}