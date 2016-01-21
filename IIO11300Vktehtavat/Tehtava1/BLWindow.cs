using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {


    public class IkkunaVE1 {
        #region variables
        private double height;
        //private double area;
        #endregion
        #region properties
        //oliosuunnittelun aikana on päätetty että pinta-ala ja hinta ovat read-only ominaisuuksia
        public double Area {
            get {
                return width * height;
            }

        }
        public float Price {
            get {
                return CalculatePrice();
            }
        }

        public double Height {
            get {
                return height;
            }
            set {
                //tässä kohdassa voisi tarvittaessa tehdä tarkistuksia
                height = value;
            }
        }
        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        #endregion
        #region constructors
        #endregion
        #region methods
        public double CalculateArea() {
            return height * width;
        }
        private float CalculatePrice() {
            float coverage = 100;
            float job = 200;
            float substance;
            substance = 100 * (float)(width * height / 1000000);
            return (coverage + job + substance);
        }
        #endregion

    }

    public class Ikkuna {
        public double width;
        public double height;
        public double CalculateArea() {
            return width * height;
        }
    }
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
