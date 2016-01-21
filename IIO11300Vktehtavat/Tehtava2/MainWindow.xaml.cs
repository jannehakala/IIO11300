/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 21.1.2016
* Authors: Janne Hakala
*/

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

namespace JAMK.IT.IIO11300 {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void comboSelectGame_Loaded(object sender, RoutedEventArgs e) {
            comboSelectGame.Items.Add("Lotto");
            comboSelectGame.Items.Add("Viking Lotto");
            comboSelectGame.Items.Add("Eurojackpot");
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e) {
            try {
                txtRandomlyDrawnNumbers.Text = String.Empty;
                BLLotto lotto = new BLLotto();
                for (int i = 0; i < int.Parse(txtNumberOfDrawns.Text); i++) {
                    txtRandomlyDrawnNumbers.AppendText(lotto.drawGame(comboSelectGame.Text));
                    txtRandomlyDrawnNumbers.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Select number of drawns.");
            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            txtRandomlyDrawnNumbers.Text = String.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
