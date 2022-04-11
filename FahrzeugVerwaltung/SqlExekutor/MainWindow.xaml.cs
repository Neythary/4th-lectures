using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using Microsoft.Win32;
using MySqlConnector;
using System.IO;

namespace SqlExekutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private void SelectScriptButton_Click(object sender, RoutedEventArgs e)
        {
            FileInfo? datei = this.SkriptDateiWaehlen();
            string dateiInhalt = this.DateiEinlesen(datei);
            this.ScriptTextBox.Text = dateiInhalt;
        }

        private FileInfo? SkriptDateiWaehlen()
        {
            OpenFileDialog dateiDialog = new OpenFileDialog();
            dateiDialog.Filter = "SQL files (*.sql)|*.sql";
            if (dateiDialog.ShowDialog() == true)
            {
                return new FileInfo(dateiDialog.FileName);
            }
            else
            {
                return null;
            }
        }

        private string DateiEinlesen(FileInfo? datei)
        {
            if (datei == null) return string.Empty;
            string dateiInhalt = File.ReadAllText(datei.FullName);
            return dateiInhalt;
        }

        private void ExecuteScriptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FuehreSkriptAus(this.ScriptTextBox.Text, this.ConnectionTextBox.Text);
                MessageBox.Show("Das Skript wurde erfolgreich ausgefuehrt!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FuehreSkriptAus(string sqlScript, string connectionString)
        {
            using var datenbankVerbindung = new MySqlConnection(connectionString);
            datenbankVerbindung.Open();

            using var kommando = new MySqlCommand(sqlScript, datenbankVerbindung);
            kommando.ExecuteNonQuery();
        }

        //Portangabe nicht zwingend notwendig, funktioniert auch ohne...
        public MainWindow()
        {
            InitializeComponent();
            this.ConnectionTextBox.Text = "Server=localhost;Port=3306;User ID=root;Password=root;";
        }

    }
}
