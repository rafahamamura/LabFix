using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public frm_configIP()
        {
            InitializeComponent();
        }

        private void frm_configIP_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(labList);
            comboBox2.Items.AddRange(machineList);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            // Load interfaces description into comboBox
            int indexCB = 0; // selected item in comboBox
            int index = 0;
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            
            // log
            textBox1.Text += "Carregando interfaces..." + Environment.NewLine + Environment.NewLine;

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Add only Ethernet and IPv4 network interfaces
                if (networkInterface.Supports(NetworkInterfaceComponent.IPv4) &&
                    networkInterface.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet))
                {
                    string desc = networkInterface.Description;
                    comboBox3.Items.Add(desc);
                    textBox1.Text += desc + Environment.NewLine;
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
            comboBox3.SelectedIndex = indexCB;
            // log
            textBox1.Text += Environment.NewLine;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setIP();
        }

        private void setIP()
        {
            // log
            textBox1.Text += "Configurando endereços IP e Hostname..." + Environment.NewLine;

            int ipLab = (int)comboBox1.SelectedIndex + 1;
            int ipMac = (int)comboBox2.SelectedIndex + 10;

            ip = "." + ipLab + "." + ipMac;

            txtBoxIP.Text = network + ip;

            // log
            textBox1.Text += "IP = " + network + ip + Environment.NewLine;

            string lab = "LAB" + ipLab.ToString("00");
            if (ipMac.Equals(10))
            {
                txtBoxHostname.Text = lab + "-PROFESSOR";
            }
            else
            {
                string host = "M" + (ipMac - 10).ToString("00");

                txtBoxHostname.Text = lab + "-" + host;
            }
            //log
            textBox1.Text += "Hostname = " + txtBoxHostname.Text + Environment.NewLine;
            textBox1.Text += Environment.NewLine;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setIP();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.Description.Equals(comboBox3.SelectedText))
                {
                    selectedNIC = networkInterface;
                }
            }
        }
    }
}
