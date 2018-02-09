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
using System.Management.Instrumentation;
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;

/**************************************************************************/
/* http://www.dreamincode.net/forums/topic/42934-using-wmi-class-in-c%23/ */
/* https://msdn.microsoft.com/en-us/library/aa338809(v=vs.71).aspx        */
/* https://msdn.microsoft.com/en-us/library/aa720448(v=vs.71).aspx        */
/* https://en.wikipedia.org/wiki/Windows_Management_Instrumentation       */
/* https://msdn.microsoft.com/en-us/library/aa394084(v=vs.85).aspx        */
/* https://www.codeproject.com/Articles/18268/How-To-Almost-Everything-In-WMI-via-C-Part-Hardw */

namespace projectWMI
{
    public partial class Menu : Form
    {

        Thread hddInfoWorkerThread;
        Thread ssidFinderThread;

        public Menu()
        {
            InitializeComponent();
        }

        // Click 'Disk Activity' button
        private void diskMon_Click(object sender, EventArgs e)
        {
            clearText();
            clearTextBox();

            if (hddInfoWorkerThread != null)
            {
                //already running
                hddInfoWorkerThread.Abort();
                hddLED.BackColor = Color.Transparent;
                hddInfoWorkerThread = null;
                
            }
            else
            {
                // not already running
                hddInfoWorkerThread = new Thread(HddActivityThread);
                hddInfoWorkerThread.Start();
            }

        }

        // Click 'SSID finder' button
        private void button1_Click(object sender, EventArgs e)
        {
            ssidFinderThread = new Thread(ssidFindThread);
            ssidFinderThread.Start();
            
        }

        // Disk Activity Thread
        public void HddActivityThread()
        {
            ManagementClass driveDataClass = new ManagementClass("Win32_PerfFormattedData_PerfDisk_PhysicalDisk");

            try
            {
                // Main loop where all the magic happens
                while (true)
                {
                    // Connect to the drive performance instance 
                    ManagementObjectCollection driveDataClassCollection = driveDataClass.GetInstances();
                    foreach (ManagementObject obj in driveDataClassCollection)
                    {
                        // Only process the _Total instance and ignore all the indevidual instances
                        if (obj["Name"].ToString() == "_Total")
                        {
                            if (Convert.ToUInt64(obj["DiskBytesPersec"]) > 0)
                            {
                                // Show busy icon
                                hddLED.BackColor = Color.Green;
                            }
                            else
                            {
                                // Show idle icon
                                hddLED.BackColor = Color.Transparent;
                            }
                        }
                    }
                    //GC.Collect();
                    //driveDataClassCollection.Dispose();
                    // Sleep for 10th of millisecond 
                    //Thread.Sleep(0);
                }
            }
            catch (ThreadAbortException tbe)
            {
                driveDataClass.Dispose();
                hddInfoWorkerThread = null;
                //MessageBox.Show("Excepetion message from .NET: " + tbe.Message);
                // Thead was aborted
            }
        }

        // SSID Finder Thread
        public void ssidFindThread()
        {
            ManagementClass mc = new ManagementClass("root\\WMI", "MSNdis_80211_ServiceSetIdentifier", null);
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                string wlanCard = (string)mo["InstanceName"];
                bool active;
                if (!bool.TryParse((string)mo["Active"], out active))
                {
                    active = false;
                }
                byte[] ssid = (byte[])mo["Ndis80211SsId"];
            }
        }

        // On menu form close
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop hdd thread on form close
            if (hddInfoWorkerThread != null)
            {
                hddInfoWorkerThread.Abort();
            }

            //stop ssid finder thread onm form close
            if (ssidFinderThread != null)
            {
                if (ssidFinderThread.IsAlive) { ssidFinderThread.Abort(); }
            }

            if (!this.IsDisposed)
            {
                this.Dispose();
            }


        }

        // Click "Get Comp. Info button"
        private void compInfobtn_Click(object sender, EventArgs e)
        {
            clearText();
            clearTextBox();
            // create management class object
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");

            StringBuilder sb = new StringBuilder();
            UInt16 counter = 0;

            //collection to store all management objects
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    counter++;
                    // display general system information
                    sb.Append(String.Concat("Manufacturer: ", mo["Manufacturer"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Model", mo["Model"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("System type: ", mo["SystemType"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("DNS host name: ", mo["DNSHostName"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("User name: ", mo["UserName"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Domain: ", mo["Domain"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("ChassisBootupState: ", mo["ChassisBootupState"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Description:  ", mo["Description"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("UserName : ", mo["UserName"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Total Phys Memory : ", mo["TotalPhysicalMemory"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Thermal State : ", mo["ThermalState"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("System Family : ", mo["SystemFamily"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Status : ", mo["Status"].ToString()) + Environment.NewLine);
                    //sb.Append(String.Concat("Owner : ", mo["PrimaryOwnerName"].ToString()) + Environment.NewLine);
                    //sb.Append(String.Concat("Total Phys Memory : ", mo["PrimaryOwnerContact"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Power State : ", mo["PowerState"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Boot ROM supported: ", mo["BootROMSupported"].ToString()) + Environment.NewLine);
                    sb.Append(String.Concat("Bootup State : ", mo["BootupState"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Domain Role : ", mo["DomainRole"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Hypervisor Present : ", mo["HypervisorPresent"].ToString(), Environment.NewLine));
                    //sb.Append(String.Concat("Install Date: ", mo["InstallDate"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Bootup State : ", mo["BootupState"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Bootup State : ", mo["BootupState"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Bootup State : ", mo["BootupState"].ToString(), Environment.NewLine));
                    sb.Append(String.Concat("Bootup State : ", mo["BootupState"].ToString(), Environment.NewLine));
                    // sb.Append(String.Concat(" : ", mo[""].ToString()));
                    //  sb.Append(String.Concat(" : ", mo[""].ToString()));
                    //sb.Append(String.Concat(" : ", mo[""].ToString()));
                    // sb.Append(String.Concat(" : ", mo[""].ToString()));
                    // sb.Append(String.Concat(" : ", mo[""].ToString()));
                    //  sb.Append(String.Concat(" : ", mo[""].ToString()));
                    //sb.Append(String.Concat(" : ", mo[""].ToString()));
                    // sb.Append(String.Concat(" : ", mo[""].ToString()));
                    // sb.Append(String.Concat(" : ", mo[""].ToString()));
                    //  sb.Append(String.Concat(" : ", mo[""].ToString()));

                    mo.Dispose();
                }
                TextBox.Text = sb.ToString();          }
                showTextBox();

            moc.Dispose();
        }


        private void enumInstancesBtn_Click(object sender, EventArgs e) {

            clearTextBox();
            clearText();
             
                StringBuilder enumInstString = new StringBuilder();

                TextBox.Visible = true;

                SelectQuery query = new SelectQuery("Win32_Environment");

                // Instantiate an object searcher with this query
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                System.Diagnostics.Debug.WriteLine(Environment.NewLine + "output: " + Environment.NewLine);

                // Call Get() to retrieve the collection of objects and loop through it
                foreach (ManagementBaseObject envVar in searcher.Get())
                {
                    enumInstString.Append( "Variable: " + envVar["Name"] + " Value: " + envVar["VariableValue"] + Environment.NewLine);
                    envVar.Dispose();
                }

                TextBox.Text = enumInstString.ToString();

                showTextBox();

            searcher.Dispose();
        }

        private void nicBtn_Click(object sender, EventArgs e)
        {
            clearText();
            StringBuilder sb = new StringBuilder();
            ManagementClass nicMClass = new ManagementClass("Win32_NetworkAdapterConfiguration");

            ManagementObjectCollection nicMOC = nicMClass.GetInstances();

            foreach (ManagementObject mo in nicMOC)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    try {
                        String [] strA = (String []) mo["DefaultIPGateway"];
                        sb.Append("MAC Address: " + mo["MacAddress"].ToString() + Environment.NewLine +
                        "Default IP Gateway: " + strA[0] + Environment.NewLine); } catch { }
                     

                }
                mo.Dispose();
            }

            TextBox.Text = sb.ToString();
            showTextBox();
            //ManagementClass nicMClass2 = new ManagementClass("MSFT_NetAdapter");
            //ManagementObjectCollection nicMOC2 = nicMClass.GetInstances();
            //foreach (ManagementObject mo in nicMOC2)
            //{
            //    String name = mo["DeviceName"].ToString();
            //    System.Diagnostics.Debug.WriteLine(name);
            //}
            nicMClass.Dispose();
        }

        private void hddFreeSpaceBtn_Click(object sender, EventArgs e)
        {
            clearText();
            clearTextBox();
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + "C"+ ":\"");
            disk.Get();
            
            label1.Text = Math.Round((Convert.ToDouble(disk["FreeSpace"])/1024/1024/2014), 3).ToString() + " GB free";
            label3.Text = Math.Round((Convert.ToDouble(disk["Size"]) / 1024/1024/1024), 3).ToString() + " GB total";
            label5.Text = "Serial #: " + disk["VolumeSerialNumber"].ToString();

            showText();
            disk.Dispose();

        }

        #region utils
        private void showText()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

        }

        private void showTextBox()
        {
            TextBox.Visible = true;
        }

        private void clearText()
        {

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label5.Text = label4.Text = label3.Text = label2.Text = label1.Text = "";
        }

        private void clearTextBox()
        {
            if (TextBox.Visible)
            {
                TextBox.Text = "";
                TextBox.Visible = false;
            }
        }

        private void w(String input)
        {
            System.Diagnostics.Debug.WriteLine(input);
        }
        #endregion

        private void tpmBtn_Click(object sender, EventArgs e)
        {
            bool isTpmPresent;
            UInt32 status = 0;
            object[] wmiParams = null;

            // create management class object
            ManagementClass mc = new ManagementClass("\\root\\CIMv2\\Security\\MicrosoftTpm:Win32_Tpm");

            //collection to store all management objects
            ManagementObjectCollection moc = mc.GetInstances();

            // Retrieve single instance of WMI management object
            ManagementObjectCollection.ManagementObjectEnumerator moe = moc.GetEnumerator();

            moe.MoveNext();

            ManagementObject mo = (ManagementObject)moe.Current;

            if (null == mo)
            {
                isTpmPresent = false;
                w("\nTPM Present: {0}\n" + isTpmPresent.ToString());
            }
            else
            {
                isTpmPresent = true;
                w("\nTPM Present: {0}\n" + isTpmPresent.ToString());
            }
            if (isTpmPresent) // Query if TPM is in activated state

            {

                wmiParams = new object[1];
                wmiParams[0] = false;
                status = (UInt32)mo.InvokeMethod("IsActivated", wmiParams);

                if (0 != status)
                {
                    w("The WMI method call {0} returned error status {1}" + "IsActivated" + status);
                }

                else
                {
                    w("TPM Status: {0}" + status);
                }

            }
        }

        private void cpuBtn_Click(object sender, EventArgs e)
        {
            clearText();
            clearTextBox();

            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();

            foreach (ManagementObject obj in objCol)
            {
                // only return cpuInfo from first CPU
                label1.Text = "CPU ID: " + obj.Properties["ProcessorId"].Value.ToString();
                label3.Text = "Manufacturer: " +  obj.Properties["Manufacturer"].Value.ToString();
                label5.Text = "Current Clock Speed: " + obj.Properties["CurrentClockSpeed"].Value.ToString() + "Hz";
            }
            showText();
        }

        private void envVarBtn_Click(object sender, EventArgs e)
        {
            // How to perform an object query

            clearText();
            clearTextBox();

            // Create a query for system environment variables only
            SelectQuery query = new SelectQuery("Win32_Environment", "UserName=\"<SYSTEM>\"");

            // Initialize an object searcher with this query
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            StringBuilder sb = new StringBuilder();

            // Get the resulting collection and loop through it
            foreach (ManagementBaseObject envVar in searcher.Get())
            {
                sb.Append("System environment variable " +envVar["Name"] + " = " + envVar["VariableValue"] + Environment.NewLine);
            }

            TextBox.Text = sb.ToString();
            showTextBox();
        }

        private void wikiBtn_Click(object sender, EventArgs e)
        {
            ManagementClass mc = new ManagementClass("root\\WMI", "MSNdis_80211_ServiceSetIdentifier", null);
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                string wlanCard = (string)mo["InstanceName"];
                bool active;
                if (!bool.TryParse((string)mo["Active"], out active))
                {
                    active = false;
                }
                byte[] ssid = (byte[])mo["Ndis80211SsId"];
                MessageBox.Show(ssid.ToString());
            }
        }

        private void proc(String inProcName)
        {
            Process [] inputProc = Process.GetProcessesByName(inProcName);
            foreach (Process curProc in inputProc)
            {
                if (curProc.HasExited == false && curProc != null)
                {
                    try { curProc.Kill(); } catch { MessageBox.Show("Process couldn't be killed"); }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
