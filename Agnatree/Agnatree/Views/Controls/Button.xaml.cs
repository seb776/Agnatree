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

namespace Agnatree.Views.Controls
{
    /// <summary>
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class Button : UserControl
    {
        
        public Button()
        {
            InitializeComponent();
        }

        private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
        {
            this.Rectangle.Fill = new SolidColorBrush(Colors.DeepSkyBlue);
        }

        private void Grid_MouseLeave_1(object sender, MouseEventArgs e)
        {
            this.Rectangle.Fill = new SolidColorBrush(Colors.DodgerBlue);
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Rectangle.Fill = new SolidColorBrush(Colors.Blue);
            // Call delegate
        }

        private void Grid_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.Rectangle.Fill = new SolidColorBrush(Colors.DeepSkyBlue);
        }
    }
}
