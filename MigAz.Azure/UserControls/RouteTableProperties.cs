﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigAz.Azure.UserControls
{
    public partial class RouteTableProperties : UserControl
    {
        private TargetTreeView _TargetTreeView;
        private MigrationTarget.RouteTable _RouteTable;

        public delegate Task AfterPropertyChanged();
        public event AfterPropertyChanged PropertyChanged;

        public RouteTableProperties()
        {
            InitializeComponent();
        }

        internal void Bind(TargetTreeView targetTreeView, MigrationTarget.RouteTable targetRouteTable)
        {
            _TargetTreeView = targetTreeView;
            _RouteTable = targetRouteTable;

            lblSourceName.Text = _RouteTable.SourceName;
            txtTargetName.Text = targetRouteTable.TargetName;

        }

        private void txtTargetName_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;

            _RouteTable.TargetName = txtSender.Text;

            PropertyChanged();
        }

        private void txtTargetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
