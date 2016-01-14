/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 14.1.2016
* Authors: Janne Hakala , Esa Salmikangas
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

namespace Tehtava1 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e) {
            double WindowWidth;
            double WindowHeight;
            double FrameHorizontal;
            double FrameVertical;
            double WidthWithFrame;
            double HeightWithFrame;
            double area;
            double perimeter;
            double FrameArea;
            //TODO
            try {
                double FrameWidth = double.Parse((txtWidthFrame.Text));

                area = BusinessLogicWindow.CalculateWindowArea(WindowWidth = double.Parse(txtWidthWindow.Text), WindowHeight = double.Parse(txtHeightWindow.Text)) / 1000000;
                tbWindowAreaResult.Text = area.ToString("0.##") + " m^2";

                perimeter = BusinessLogicWindow.CalculateFramePerimeter(FrameHorizontal = WindowWidth, FrameVertical = WindowHeight + double.Parse((txtWidthFrame.Text)) * 2) / 1000;
                tbFramePerimeterResult.Text = perimeter.ToString("0.##") + " m";

                FrameArea = BusinessLogicWindow.CalculateFrameArea(WidthWithFrame = WindowWidth + FrameWidth * 2, HeightWithFrame = WindowHeight + FrameWidth * 2, WindowWidth, WindowHeight) / 1000000;
                tbFrameAreaResult.Text = FrameArea.ToString("0.###") + " m^2";
            }
            catch (Exception ex) {
                MessageBox.Show("Joku kenttä jäi tyhjäksi!");
            }
            finally {
                //tell user that everything is okay
            }
        }
    private void btnClose_Click(object sender, RoutedEventArgs e) {
      Application.Current.Shutdown();
    }
  } 
}
