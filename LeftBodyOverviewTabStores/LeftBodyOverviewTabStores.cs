﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseClass;

namespace LeftBodyOverviewTabStores
{
    public partial class LeftBodyOverviewTabStores: UserControl
    {
        public event EventHandler<string> EmployeeSelected;
        public LeftBodyOverviewTabStores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            if (item != null)
            {
                string employeeId = item.SubItems[0].Text;
                EmployeeSelected?.Invoke(this, employeeId);
            }
        }
        public void UpdateEmployeeList(List<DatabaseAccess.Employee> employees)
        {
            listView1.Items.Clear();
            if (employees == null)
                return;
            foreach (var employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.Employee_Name);
                item.SubItems.Add(employee.Employee_ID);
                item.SubItems.Add("Working");
                listView1.Items.Add(item);
            }
        }
    }
}
