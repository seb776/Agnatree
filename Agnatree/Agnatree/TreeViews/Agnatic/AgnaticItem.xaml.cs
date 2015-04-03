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
        public double Length;
        public String PositionID
        {
            get;
            set;
        }
        static Random ran = new Random();
        public AgnaticItem()
        {
            this.Margin = new Thickness( 500 );
            PositionID = "0";
            InitializeComponent();
            //this.Text.Angle = -42;
            this.Polys.Points.Clear();
            this.Polys.Points.Add( new Point( 50, 0 ) );
            this.Polys.Points.Add( new Point( 0, 50 ) );
            this.Polys.Points.Add( new Point( 50, 50 ) );
            CalcAngle();
            CalcPoints();
        }

        public Tuple<double, double> CalcAngles()
        {
            double angleStep = Math.PI;
            double angleDep = 0;

            if (PositionID.CompareTo( "0" ) == 0)
            {
                return new Tuple<double, double>( 0, Math.PI );
            }
            foreach (char c in PositionID.Skip(1))
            {
                angleStep = angleStep / 2;
                if (c == '1')
                    angleDep += angleStep;
            }
            return new Tuple<double, double>(angleDep, angleDep + angleStep);
        }

        public void CalcPoints()
        {
            this.Polys.Points.Clear();

            LinkedList<Point> top = new LinkedList<Point>();
            LinkedList<Point> _base = new LinkedList<Point>();
            double radiusBase = PositionID.Length * 50;
            Tuple<double, double> angles = CalcAngles();
            double teta = angles.Item1;

            if (PositionID.CompareTo( "0" ) == 0)
            {
                _base.AddLast( new Point( -50, 0 ) );
                _base.AddLast( new Point( 50, 0 ) );
            }

            for (; teta <= angles.Item2; teta = teta + 0.01)
            {
                int a;
                int b;

                if (PositionID.CompareTo( "0" ) != 0)
                {
                    a = (int)(radiusBase * Math.Cos( teta ));
                    b = (int)(radiusBase * Math.Sin( teta ));
                    _base.AddLast( new Point( -a, -b ) );
                }
                a = (int)((radiusBase + 50) * Math.Cos( teta ));
                b = (int)((radiusBase + 50) * Math.Sin( teta ));
                top.AddFirst( new Point( -a, -b ) );
            }

            foreach (var b in _base)
            {
                this.Polys.Points.Add( b );
            }
            foreach (var t in top)
            {
                this.Polys.Points.Add( t );
            }
        }

        public void CalcAngle()
        {
            //var angles = CalcAngles();
            //this.TextPos.X = -(50 * PositionID.Length + 50) * Math.Cos((angles.Item1 + angles.Item2) / 2);
            //this.TextPos.Y = -(50 * PositionID.Length + 50) * Math.Sin((angles.Item1 + angles.Item2) / 2);
            //double _base = 45;
            //double angle = 0;
            //if (PositionID.CompareTo( "0" ) != 0)
            //{
            //    foreach (char c in PositionID)
            //    {
            //        if (c == '1')
            //            angle = angle - _base;
            //        else
            //            angle = angle + _base;

            //        _base = _base / 2;
            //    }
            //}
            //this.Text.Angle = angle;
        }

        virtual public void Polys_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Polys.Stroke = new SolidColorBrush( Colors.Red );
        }
    }
}
