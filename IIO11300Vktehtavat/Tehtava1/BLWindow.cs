using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1 {
    public class BusinessLogicWindow {
        
        public static double CalculateWindowArea(double width, double height) {
            double area = width * height;
            return area;
        }
        public static double CalculateFramePerimeter(double width, double height) {
            double perimeter = 2 * (width + height);
            return perimeter;
        }
        public static double CalculateFrameArea(double width, double height, double windowwidth, double windowheight) {
            double area = (width * height) - BusinessLogicWindow.CalculateWindowArea(windowwidth, windowheight);
            return area;
        }
    }
}
