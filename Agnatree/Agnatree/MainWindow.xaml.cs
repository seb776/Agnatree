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

namespace Agnatree
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Agnatree.TreeViews.Agnatic.AgnaticView agV = new Agnatree.TreeViews.Agnatic.AgnaticView();
            agV.Margin = new Thickness(150, 150, 0, 0);
            this.Workspace.Children.Add(agV);

            var a = new Agnatree.TreeViews.Tree.Tree();
            //a.Margin = new Thickness(150, 150, 0, 0);
            this.Workspace.Children.Add(a);
            //a.MainBranchTmp.LeftBranch.Children.Add(new TreeViews.Tree.FamilyBranch());
            //a.MainBranchTmp.RightBranch.Children.Add(new TreeViews.Tree.FamilyBranch());
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.ViewGrid.IsEnabled = false;
            this.ViewGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ViewGrid.IsEnabled = true;
            this.ViewGrid.Visibility = Visibility.Visible;
        }
    }
}
