﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;

namespace LabFix
{
    public partial class frm_configIP : Form
    {
        String[] labList = {"LAB01","LAB02","LAB03","LAB04","LAB05","LAB06","LAB07","LAB08","LAB09",
                        "LAB10","LAB11","LAB12","LAB13","LAB14", "LAB15", "LAB16", "LAB17", "LAB18"};
        String[] machineList = { "PROFESSOR","M01","M02","M03","M04","M05","M06","M07","M08","M09",
                        "M10","M11","M12","M13","M14","M15","M16","M17","M18","M19",
                        "M20","M21","M22","M23","M24","M25","M26","M27","M28","M29",
                        "M30","M31","M32","M33","M34","M35","M36","M37","M38","M39","M40"};

        NetworkInterface[] networkInterfaces;
        NetworkInterface selectedNIC;
        String network = "10.10";
        String ip = ".1.10";
        String ipFull = "";
        String gateway = "10.10.0.1";
        public frm_configIP()
        {
            InitializeComponent();
        }

        private void frm_configIP_Load(object sender, EventArgs e)
        {
            cbLabs.Items.AddRange(labList);
            cbLabs.SelectedIndex = 0;
            cbHosts.Items.AddRange(machineList);
            cbHosts.SelectedIndex = 0;

            checkHostname();

            // Load interfaces description into comboBox
            int indexCB = 0; // selected item in comboBox
            int index = 0;
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Add only Ethernet and IPv4 network interfaces
                if (networkInterface.Supports(NetworkInterfaceComponent.IPv4) &&
                    networkInterface.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet))
                {
                    string desc = networkInterface.Description;
                    cbInterfaces.Items.Add(desc);
                    if (desc.StartsWith("Realtek") ||
                        desc.StartsWith("Intel") ||
                        desc.StartsWith("Broadcom") ||
                        desc.StartsWith("Atheros"))
                    {
                        indexCB = index;
                        selectedNIC = networkInterface;
                    }
                    index++;
                }

            }
            cbInterfaces.SelectedIndex = indexCB;

        }

        private void checkHostname()
        {
            IPGlobalProperties prop = IPGlobalProperties.GetIPGlobalProperties();
            if (prop.HostName.Contains("LAB"))
            {
                string[] hostname = prop.HostName.Split('-');
                cbLabs.SelectedText = hostname[0];
                cbHosts.SelectedText = hostname[1];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setIpFull();
        }

        private void setIpFull()
        {
            int ipLab = (int)cbLabs.SelectedIndex + 1;
            int ipMac = (int)cbHosts.SelectedIndex + 10;

            ip = "." + ipLab + "." + ipMac;
            ipFull = network + ip;

            txtBoxIP.Text = ipFull;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setIpFull();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.Description.Equals(cbInterfaces.SelectedText))
                {
                    selectedNIC = networkInterface;
                }
            }
        }

        private void setConfig()
        {
            var adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var networkCollection = adapterConfig.GetInstances();
            foreach (ManagementObject adapter in networkCollection)
            {
                string description = adapter["Description"] as string;
                if (String.Compare(description, selectedNIC.Description) == 0)
                {
                    try
                    {
                        // Set DefaultGateway
                        var newGateway = adapter.GetMethodParameters("SetGateways");
                        newGateway["DefaultIPGateway"] = new string[] { gateway };
                        newGateway["GatewayCostMetric"] = new int[] { 1 };

                        // Set IPAddress and Subnet Mask
                        var newAddress = adapter.GetMethodParameters("EnableStatic");
                        newAddress["IPAddress"] = new string[] { ipFull };
                        newAddress["SubnetMask"] = new string[] { "255.255.255.0" };

                        adapter.InvokeMethod("EnableStatic", newAddress, null);
                        adapter.InvokeMethod("SetGateways", newGateway, null);

                        txtLog.Text.Insert(0,"Updated to static IP address!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Unable to Set IP : " + ex.Message);
                    }
                }
            }
        }
    }
}
