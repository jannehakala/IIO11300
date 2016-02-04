/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 28.1.2016 Modified: 29.1.2016
* Authors: Janne Hakala
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        BLLotto lotto = new BLLotto();
        private void comboSelectGame_Loaded(object sender, RoutedEventArgs e) {
            comboSelectGame.Items.Add("Lotto");
            comboSelectGame.Items.Add("Viking Lotto");
            comboSelectGame.Items.Add("Eurojackpot");
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e) {
            try {
                txtRandomlyDrawnNumbers.Text = String.Empty;
                for (int i = 0; i < int.Parse(txtNumberOfDrawns.Text); i++) {
                    txtRandomlyDrawnNumbers.AppendText(lotto.DrawGame(comboSelectGame.Text, i + 1));
                    txtRandomlyDrawnNumbers.AppendText(Environment.NewLine);
                }
            } catch (Exception ex) {
                MessageBox.Show("Select number of drawns.");
            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            txtRandomlyDrawnNumbers.Text = String.Empty;
            txtNumberOfDrawns.Text = String.Empty;
            txtMatchedNumbers.Text = String.Empty;
            txtCorrectRow.Text = String.Empty;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtRandomlyDrawnNumbers.Text)) {
                lotto.WriteLottoNumbers(txtRandomlyDrawnNumbers.Text);
            } else {
                MessageBox.Show("Draw numbers first.");
            }
        }
        private void btnCheckRows_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtCorrectRow.Text)) {
                txtMatchedNumbers.Text = String.Empty;
                string text = txtCorrectRow.Text.ToString();
                int[] array = lotto.ReadLottoNumbers(text);
                for (int i = 0; i < array.Length; i++) {
                    txtMatchedNumbers.AppendText("Row " + (i + 1) + ": right numbers: " + array[i] + "\n");
                }
            } else {
                MessageBox.Show("Insert correct row first.");
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}

