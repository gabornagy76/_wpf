using System.Windows;
using System.Windows.Controls;

namespace WPFGyakorlas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void udvozlesButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            string nev = nevTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(nev))
            {
                eredmenyTextBlock.Text = "Add meg a neved!";

                nevTextBox.Focus();

                return;
            }

            int eletkor;

            if (!int.TryParse(eletkorTextBox.Text, out eletkor))
            {
                eredmenyTextBlock.Text = "Az életkor csak szám lehet!";

                eletkorTextBox.Focus();

                return;
            }

            // Elkészítjük az alap üdvözlő szöveget.
            string uzenet =
                $"Üdvözöllek, {nev}!\nTe {eletkor} éves vagy.";
            if (wpfCheckBox.IsChecked == true)
            {
                uzenet += "\nÖrülök, hogy szereted a WPF-et!";
            }

            if (vremekCheckBox.IsChecked == true)
            {
                uzenet += "\nSzépen haladok a vizsgaremekkel!";
            }

            string nem;

            if (ferfiRadioButton.IsChecked == true)
            {
                nem = "férfi";
            }
            else
            {
                nem = "nő";
            }

            uzenet += $"\nNemed: {nem}";

            ComboBoxItem kivalasztottElem = (ComboBoxItem)osztalyComboBox.SelectedItem;

            string? osztaly = kivalasztottElem.Content.ToString();

            uzenet += $"\nAz osztályod: {osztaly}.";


            
            ListBoxItem kivalasztottTantargyElem = (ListBoxItem)tantargyListBox.SelectedItem;

            string tantargy = kivalasztottTantargyElem.Content.ToString();

            
            uzenet += $"\nA kedvenc tantárgyad: {tantargy}.";


            eredmenyTextBlock.Text = uzenet;
        }
    }
}

