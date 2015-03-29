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

namespace Agnatree.TreeViews.Agnatic
{
    /// <summary>
    /// Logique d'interaction pour AgnaticItem.xaml
    /// </summary>
    public partial class AgnaticItem : UserControl
    {
        public RotateTransform MyAngle;
        public String Position;
        public AgnaticItem()
        {
            InitializeComponent();
            //MyAngle = new RotateTransform( 42 );
            this.Text.Angle = 42;
            this.Polys.Points.Clear();
            Point p = new Point( 150, 150 );
            this.Polys.Points.Add( new Point( p.X + -50, p.Y + 0 ) );
            this.Polys.Points.Add( new Point( p.X + 0, p.Y - 50 ) );
            this.Polys.Points.Add( new Point( p.X + 50, p.Y + 0 ) );
        }
    }
}
