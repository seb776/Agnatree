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
        public AgnaticView()
        {
            InitializeComponent();
            AddChild( "0" );
        }
        public void AddChild(String position)
        {
            AgnaticItem item = new AgnaticItem();

            item.PositionID = position;
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add( item );
            item = new AddAgnaticItem();
            item.PositionID = position + "0";
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add(item);
            item = new AddAgnaticItem();
            item.PositionID = position + "1";
            item.CalcAngle();
            item.CalcPoints();
            this.Grid.Children.Add( item );
        }
        void RemoveChild(String position)
        {
            throw new System.Exception("Not implemented: AgnaticView.RemoveChild()");
        }
    }
}
