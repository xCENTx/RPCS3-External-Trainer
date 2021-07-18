using System;
using Memory;
using System.Windows.Forms;
using System.Globalization;
using System.Numerics;
using System.Drawing;

namespace RPCS3_External_Trainer_SOURCE
{
    public partial class MainForm : Form
    {
        Mem m = new Mem();
        private const string RPCS3PROCESSNAME = "rpcs3.exe";
        bool rpcs3Running;

        public uint SwapBytes(uint x)
        {
            return ((x & 0x000000ff) << 24) +
                   ((x & 0x0000ff00) << 8) +
                   ((x & 0x00ff0000) >> 8) +
                   ((x & 0xff000000) >> 24);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(RPCS3PROCESSNAME);
            if (PID > 0)
            {
                m.OpenProcess(PID);
            }
        }

        private void RPCS3Process_Timer_Tick(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(RPCS3PROCESSNAME);
            if (PID > 0)
            {
                m.OpenProcess(PID);

                //Proc Label Status
                rpcs3Status.ForeColor = Color.FromArgb(0, 169, 0);
                rpcs3Status.BackColor = Color.FromArgb(32, 32, 35);
                rpcs3Status.Text = "RPCS3 CONNECTED";
                rpcs3Running = true;
                return;
            }
            rpcs3Status.Text = "RPCS3 NOT DETECTED";
            rpcs3Status.ForeColor = Color.FromArgb(169, 0, 0);
            rpcs3Status.BackColor = Color.FromArgb(32, 32, 35);
            rpcs3Running = false;
        }

        private void RPCS3Mem_Timer_Tick(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            //Reads Current Souls and displays the value via Label
            BigInteger parseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            var SoulsAddr = parseSoulsAddr.ToString("X");
            var SoulsAddrValue = m.ReadUInt(SoulsAddr);
            var CURRENT_SOULS = SwapBytes(SoulsAddrValue);
            CurrentSouls_Label.Text = "CURRENT SOULS: " + Convert.ToString(CURRENT_SOULS);
        }

        private void Souls_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            BigInteger parseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            string hex = $"0x{parseSoulsAddr:X8}";
            int intValue = Convert.ToInt32(SendSouls_textBox.Text);
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            byte[] result = intBytes;
            m.WriteBytes(hex, intBytes);
        }
    }
}
