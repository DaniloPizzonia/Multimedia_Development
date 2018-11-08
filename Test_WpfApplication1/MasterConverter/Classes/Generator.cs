using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterConverter.Classes {
    public class Generator {

        public Generator() {

        }

        private void cleanImageBoxes(int amount) {
            switch(amount) {
                case 0:
                    //  imageContainer_left.Source = null;
                    //  imageContainer_right.Source = null;
                    break;
                case 1:
                    // imageContainer_right.Source = null;
                    break;
                case 2:
                    //  imageContainer_right.Source = null;
                    break;
                default:
                    break;
            }
        }

        private void swapImages(float input) {
            float devider = input / 10;

            int vorkommastelle = (int)devider;
            float nachkommastelle = (devider - (float)vorkommastelle) * 10;
            double nachkommastelleRounded = Math.Round(nachkommastelle);
            swapLeft(vorkommastelle);
            swapRight(nachkommastelleRounded);
        }

        private void swapLeft(int num) {
            switch(num) {
                case 0:
                    //  imageContainer_left.Source = null;
                    break;
                case 1:
                    //  imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    break;
                case 2:
                    // imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    break;
                case 3:
                    //  imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    break;
                case 4:
                    // imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    break;
                case 5:
                    //  imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void swapRight(double num) {
            int numm = (int)num;
            switch(numm) {
                case 0:
                    //  imageContainer_right.Source = null;
                    break;
                case 1:
                    // imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    break;
                case 2:
                    //  imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    break;
                case 3:
                    //  imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    break;
                case 4:
                    //  imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    break;
                case 5:
                    // imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    break;
                case 6:
                    //imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    break;
                case 7:
                    //imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    break;
                case 8:
                    //imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    break;
                case 9:
                    //imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
