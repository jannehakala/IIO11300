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
using Microsoft.Win32;

namespace H1MediaPlayer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        bool IsPlaying = false;
        public MainWindow() {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff() {
            //kootaan tänne kaikki alustukset mitä tarvitaan ohjelman suorittamiseksi
            //txtFileName.Text = "d:\\H3298\\CoffeeMaker.mp4";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e) {
            try {
                if ((txtFileName.Text.Length > 0) && System.IO.File.Exists(txtFileName.Text)) {
                    mediaElement.Source = new Uri(txtFileName.Text);
                    mediaElement.Play();
                    IsPlaying = true;
                    //nappulat käyttöön
                    SetMyButtons();
                } else {
                    MessageBox.Show("tiedostoa " + txtFileName.Text + " ei löydy.");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e) {
            if (IsPlaying) {
                mediaElement.Pause();
                IsPlaying = false;
                btnPause.Content = "Jatka";
            } else {
                mediaElement.Play();
                IsPlaying = true;
                btnPause.Content = "Pause";
            }    
        }

        private void btnStop_Click(object sender, RoutedEventArgs e) {
            mediaElement.Stop();
            IsPlaying = false;
            SetMyButtons();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "d:\\H3298";
            ofd.Filter = "Video-tiedostot mp4|*.mp4|All files|*.*";
            Nullable<bool> result = ofd.ShowDialog();

            if (result == true) {
                txtFileName.Text = ofd.FileName;
            }
        }
        private void SetMyButtons() {
            btnPause.IsEnabled = IsPlaying;
            btnStop.IsEnabled = IsPlaying;
            btnPlay.IsEnabled = !IsPlaying;
        }
    }
}
