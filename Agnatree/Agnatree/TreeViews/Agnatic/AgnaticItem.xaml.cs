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
        public AgnaticItem ChildLeft;
        public AgnaticItem ChildRight;

        static Random ran = new Random();
        private AgnaticView _view;
        public AgnaticItem(AgnaticView view)
        {
            _view = view;
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
                angleStep = angleStep / 2.0;
                if (c == '1')
                    angleDep += angleStep;
            }
            return new Tuple<double, double>(angleDep, angleDep + angleStep);
        }

        public void CalcPoints()
        {
            this.Polys.Points.Clear();
            double baseSize = 50;
            double scale = 30;
            if (PositionID.CompareTo("0") == 0)
                scale = 50;

            LinkedList<Point> top = new LinkedList<Point>();
            LinkedList<Point> _base = new LinkedList<Point>();

            double curSize = PositionID.Length * scale;
            //MessageBox.Show(PositionID.Length.ToString() + " " + PositionID);

            if (PositionID.Length > _view.Sizes.Count)
                _view.Sizes.Add(curSize);
            double bSize = 0;
            for (int i = 0; i < (PositionID.Length - 1) && i < _view.Sizes.Count; ++i)
            {
                bSize += _view.Sizes[i];
                //MessageBox.Show(_view.Sizes[i].ToString());
            }
            //double radiusBase = PositionID.Length * scale;
            //double radiusExtend = radiusBase + (PositionID.Length * scale);
            //MessageBox.Show(radiusBase.ToString());
            Tuple<double, double> angles = CalcAngles();
            double teta = angles.Item1;

            if (PositionID.CompareTo( "0" ) == 0)
            {
                _base.AddLast( new Point( -scale, 0 ) );
                _base.AddLast( new Point( scale, 0 ) );
            }

            for (; teta <= angles.Item2; teta = teta + 0.01)
            {
                double a;
                double b;

                if (PositionID.CompareTo( "0" ) != 0)
                {
                    a = (bSize * Math.Cos( teta ));
                    b = (bSize * Math.Sin( teta ));
                    _base.AddLast( new Point( -a, -b ) );
                }
                a = ((bSize + curSize) * Math.Cos( teta ));
                b = ((bSize + curSize) * Math.Sin( teta ));
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
            double curAngle = (angles.Item1 + angles.Item2) / 2;
            double testAvgX = -((bSize + (curSize / 2)) * Math.Cos( curAngle ));
            double testAvgY = -((bSize + (curSize / 2)) * Math.Sin(curAngle));
            double avgAngle = (angles.Item1 + angles.Item2) / 2;

            double rotAngle = -(360 - ((avgAngle / Math.PI) * 180));
            if (Math.Abs(avgAngle - (Math.PI / 2)) < 0.001)
                rotAngle = 0;
            if (avgAngle > (Math.PI / 2))
                rotAngle += 180;
            this.NodeContent.LayoutTransform = new RotateTransform(rotAngle);
            this.NodeContent.Measure(new Size(double.MaxValue, double.MaxValue));
            double x = testAvgX - (this.NodeContent.DesiredSize.Width / 2);
            double y = testAvgY - (this.NodeContent.DesiredSize.Height / 2);


            this.NodeContent.Margin = new Thickness(x, y, 0, 0);
            //var e = new Ellipse();
            //e.Margin = new Thickness(this.NodeContent.Margin.Left, this.NodeContent.Margin.Top, 0, 0);
            //e.Fill = new SolidColorBrush(Colors.Blue);
            //e.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            //e.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            ////e.StrokeThickness = 0.01;
            //e.Width = e.Height = 3;
            //this.GridItem.Children.Add(e);
        }

        public void CalcAngle()
        {
            //var angles = CalcAngles();
            //this.TextPos.X = -(50 * PositionID.Length + 50) * Math.Cos( (angles.Item1 + angles.Item2) / 2 );
            //this.TextPos.Y = -(50 * PositionID.Length + 50) * Math.Sin( (angles.Item1 + angles.Item2) / 2 );
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
