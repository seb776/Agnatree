using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;

namespace Agnatree.TreeViews.Agnatic
{
    public class AddAgnaticItem : AgnaticItem
    {
        public AddAgnaticItem(AgnaticView view) : base(view)
        {
            this.Polys.Fill = new System.Windows.Media.SolidColorBrush( System.Windows.Media.Color.FromArgb(0x42, 0x82, 0xb3, 0xae));
        }

        override public void Polys_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            String posID;
            this.Polys.Stroke = new SolidColorBrush( Colors.Black );
          //  AgnaticItem nitem = new AgnaticItem();

            posID = this.PositionID;
           // nitem.CalcAngle();
          //  nitem.CalcPoints();
            Grid p = (VisualTreeHelper.GetParent( this ) as Grid);
            p.Children.Remove( this );
            AgnaticView gp = (p.Parent as AgnaticView);
            gp.AddChild( posID );
        }
    }
}
