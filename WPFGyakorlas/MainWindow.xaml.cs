using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WPFGyakorlas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void udvozlesButton_Click(object sender, RoutedEventArgs e)
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


            // ComboBox
            ComboBoxItem kivalasztottElem = (ComboBoxItem)osztalyComboBox.SelectedItem;

            string? osztaly = kivalasztottElem.Content.ToString();

            uzenet += $"\nAz osztályod: {osztaly}.";


            // ListBox
            ListBoxItem kivalasztottTantargyElem = (ListBoxItem)tantargyListBox.SelectedItem;

            string tantargy = kivalasztottTantargyElem.Content.ToString();


            uzenet += $"\nA kedvenc tantárgyad: {tantargy}.";


            // PasswordBox
            string jelszo = jelszoPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(jelszo))
            {
                eredmenyTextBlock.Text = "Add meg a jelszót!";

                jelszoPasswordBox.Focus();

                return;
            }

            uzenet += $"\nA jelszót eltároltuk!";

            // DatePicker
            if (szuletesiDatumPicker.SelectedDate == null)
            {
                eredmenyTextBlock.Text = "Válaszd ki a születési dátumot!";

                szuletesiDatumPicker.Focus();

                return;
            }

            DateTime szuletesiDatum = szuletesiDatumPicker.SelectedDate.Value;

            string datum = szuletesiDatum.ToShortDateString();

            uzenet += $"\nSzületési dátumod: {datum}.";

            // Slider
            double tanulasiKedv = kedvSlider.Value;

            uzenet += $"\nTanulási kedved: {tanulasiKedv}%.";

            eredmenyTextBlock.Text = uzenet;

        }

        // Ez az esemény minden alkalommal lefut, amikor a Slider értéke megváltozik.
        // Az eseménykezelő első paramétere, a sender, mindig arra a vezérlőre hivatkozik, amely kiváltotta az eseményt. A mi példánkban ez maga a Slider, hiszen annak az értéke változott meg.
        // Ha ugyanazt az eseménykezelőt több Slider is használná, akkor a sender segítségével meg tudnánk állapítani, hogy éppen melyik Slider indította el az eseményt.A jelenlegi példában azonban csak egy Sliderünk van, ezért egyszerűbb közvetlenül a kedvSlider vezérlőt használni.
        // Az e (event) pedig az eseményhez tartozó kiegészítő adatokat tartalmazza.
        // Az EventArgs típusa attól függ, hogy milyen eseményről van szó.Egy gomb kattintásánál elegendő egy egyszerű RoutedEventArgs, míg a Slider értékváltozásánál már egy összetettebb RoutedPropertyChangedEventArgs<double> objektumra van szükség, mert a WPF a régi és az új értéket is át szeretné adni.
        private void kedvSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (kedvProgressBar != null)
            {
                /*
                 * Az e.NewValue tartalmazza a Slider új értékét.
                 * Ezt adjuk át a ProgressBarnak.
                 */
                kedvProgressBar.Value = e.NewValue;
            }
            
        }
    }
}

