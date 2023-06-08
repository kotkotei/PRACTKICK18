using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PR18Sistem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Device";
            dataGridView1.Columns[1].Name = "Device ID";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ManagementObjectSearcher device_searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            foreach (ManagementObject usb_device in device_searcher.Get())
            {
                var device = usb_device.Properties["DeviceID"].Value.ToString();
                var deviceID = usb_device.Properties["PNPDeviceID"].Value.ToString();
                var desc = usb_device.Properties["Description"].Value.ToString();
                dataGridView1.Rows.Add(device, deviceID, desc);
            }
        }
    }
}
