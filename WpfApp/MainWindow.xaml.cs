using Microsoft.Win32;
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
using WPFApp;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Auto> autok = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    // 📂 BETÖLTÉS GOMB
    private void btnBetolt_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new();
        ofd.Filter = "CSV files (*.csv)|*.csv";
        if (ofd.ShowDialog() == true)
        {
            autok = Auto.ReadFromCsv(ofd.FileName);
            dgvAutok.ItemsSource = autok;
        }
    }

    // 🔍 SZŰRÉS TEXTBOX
    private void txtEv_TextChanged(object sender, RoutedEventArgs e)
    {
        lstAutok.Items.Clear();
        if (int.TryParse(txtEv.Text, out int keresettEv))
        {
            var szurtLista = autok.Where(a => int.Parse(a.GyartasiEv) == keresettEv)
                                  .Select(a => $"{a.Marka} {a.Modell}").ToList();
            foreach (var item in szurtLista)
            {
                lstAutok.Items.Add(item);
            }
        }
    }

    // ❌ BEZÁRÁS GOMB
    private void btnBezar_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Biztosan ki akarsz lépni?", "Kilépés",
            MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }
}