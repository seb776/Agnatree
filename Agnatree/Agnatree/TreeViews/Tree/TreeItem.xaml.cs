﻿using System;
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

namespace Agnatree.TreeViews.Tree
{
    /// <summary>
    /// Interaction logic for TreeItem.xaml
    /// </summary>
    public partial class TreeItem : UserControl
    {
        public TreeItem TreeParent;
        public String Code;

        public TreeItem()
        {
            InitializeComponent();
        }

        public void AddPartner(String name) // Todo: move this into ViewModel and string will become a "Person"
        {
            
        }

        //public void AddChild
    }
}
