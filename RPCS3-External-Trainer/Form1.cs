using System;
using Memory;
using System.Windows.Forms;
using System.Globalization;
using System.Numerics;

namespace RPCS3_External_Trainer_SOURCE
{
    public partial class MainForm : Form
    {
        Mem m = new Mem();
        private const string RPCS3PROCESSNAME = "rpcs3.exe";
        bool rpcs3Running;

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
                rpcs3Status.Text = "RPCS3 CONNECTED";
                rpcs3Running = true;
                return;
            }
            rpcs3Status.Text = "RPCS3 NOT DETECTED";
            rpcs3Running = false;
        }

        private void RPCS3Mem_Timer_Tick(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }

            //Displays Current Souls in 4byte Value .. Need to convert to 4byte Big Endian
            BigInteger baseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            var SoulsAddr = baseSoulsAddr.ToString("X");
            CurrentSouls_Label.Text = "CURRENT SOULS: " + Convert.ToString(m.ReadInt(SoulsAddr));
        }

        private void Souls_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }



        }
    }
}
