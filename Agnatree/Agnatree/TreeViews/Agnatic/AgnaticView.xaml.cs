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
    /// Logique d'interaction pour AgnaticView.xaml
    /// </summary>
    public partial class AgnaticView : UserControl
    {
        public List<Double> Sizes;
        private AgnaticItem _baseItem;
        public AgnaticView()
        {
            InitializeComponent();
            Sizes = new List<double>();
            _baseItem = AddChild( "0" );
        }
        public AgnaticItem AddChild(String position)
        {
            AgnaticItem item = new AgnaticItem(this);
            var backItem = item;

            item.PositionID = position;
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add( item );
            item = new AddAgnaticItem(this);
            item.PositionID = position + "0";
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add(item);
            item = new AddAgnaticItem(this);
            item.PositionID = position + "1";
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add( item );
            return backItem;
        }
        void RemoveChild(String position)
        {
            throw new System.Exception("Not implemented: AgnaticView.RemoveChild()");
        }

        private void Grid_MouseMove_1(object sender, MouseEventArgs e)
        {
            Point baseView = new Point(_baseItem.Margin.Left, _baseItem.Margin.Top);
            double dist = (baseView - e.GetPosition(this.Grid)).Length;
            double radius = 0;
            foreach (double s in Sizes)
            {
                radius += s;
                if (Math.Abs(dist - radius) < 1)
                {
                    Mouse.OverrideCursor = Cursors.ScrollNS;
                    break;
                }
                else
                {
                    Mouse.OverrideCursor = null;
                }
            }
        }
    }
}
