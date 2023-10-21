using System;
using System.Collections.Generic;
using System.Drawing;
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
using Point = System.Windows.Point;

namespace HW_23._09._23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool isDragging = false;
        Point startPoint;
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(Canv);
            Rct.CaptureMouse();
        }
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = e.GetPosition(Canv);
                double offsetX = endPoint.X - startPoint.X;
                double offsetY = endPoint.Y - startPoint.Y;
                double newLeft = Canvas.GetLeft(Rct) + offsetX;
                double newTop = Canvas.GetTop(Rct) + offsetY;
                if (newLeft >= 0 && newTop >= 0 && (newLeft + Rct.ActualWidth) <= Canv.ActualWidth && (newTop + Rct.ActualHeight) <= Canv.ActualHeight)
                {
                    Canvas.SetLeft(Rct, newLeft);
                    Canvas.SetTop(Rct, newTop);
                    startPoint = endPoint;
                }
            }
        }
        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            Rct.ReleaseMouseCapture();
        }
        
    }
}
