using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPCMessages;
using System.Diagnostics;
using System.Threading;
using System.IO.Pipes;

namespace CompoundingTwo {
    public partial class Form1 : Form {
        // The named pipe that we use to communicate with the kernel
        private NamedPipeClientStream npcsClient = null;
        public Form1() {
            InitializeComponent();
        }

        private void cboCompMeth_SelectedIndexChanged(object sender, EventArgs e) {
            btnCalc.Enabled = (cboCompMeth.SelectedIndex >= 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a process to run the kernel and start it
            Process pKernel = new Process();
            pKernel.StartInfo.FileName = "CompoundingKernel.exe";
            pKernel.Start();
            // Wait for .5 seconds to allow the kernel to get started
            Thread.Sleep(500);
            // Create the client named pipe and connect to the kernel
            npcsClient = new NamedPipeClientStream("CompoundingKernel");
            npcsClient.Connect();
            // Call the function to receive the methods from the kernel
            vReceiveMethods();
        }

        // Function to receive the list of compounding methods that the kernel supports
        // and put them in the combo box
        private void vReceiveMethods()
        {
            // Receive the message from the kernel
            (string strCmd, string strArg) = MessageUtils.ReceiveMsg(npcsClient);
            // Check that we received a methods command
            if (strCmd.ToLower() == "methods")
            {
                // Split the argument into the seperate method names
                string[] astrMethNames = strArg.Split(',');
                // Add the names to the combobox
                cboCompMeth.Items.AddRange(astrMethNames);
            }
            else
            {
                // Error. Notify the user and exit
                MessageBox.Show("Kernel error, exiting");
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tell the kernel to quit, then dispose of the named pipe
            MessageUtils.SendMsg(npcsClient, "quit", "");
            npcsClient.Close();
            npcsClient.Dispose();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Get the principal, interest rate, and compounding method
            double dPrinc = double.Parse(txtPrinc.Text);
            double dIntRate = double.Parse(txtInterest.Text);
            // Convert interest rate to a decimal
            dIntRate /= 100;
            string strCompMeth = cboCompMeth.SelectedItem.ToString();
            // Send to the kernel
            MessageUtils.SendMsg(npcsClient, "principal", MessageUtils.DoubleToHex(dPrinc));
            MessageUtils.SendMsg(npcsClient, "rate", MessageUtils.DoubleToHex(dIntRate));
            MessageUtils.SendMsg(npcsClient, "method", strCompMeth);
            // Tell the kernel to do the computation and receive the reply
            MessageUtils.SendMsg(npcsClient, "compute", "");
            (string strCmd, string strArg) = MessageUtils.ReceiveMsg(npcsClient);
            // Check that we received a "result" message and display the interest earned if so
            if (strCmd.ToLower() == "result")
            {
                double dIntEarned = MessageUtils.HexToDouble(strArg);
                txtIntEarned.Text = dIntEarned.ToString("C2");
            }
        }
    }
}
