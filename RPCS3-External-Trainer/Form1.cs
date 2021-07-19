using System;
using Memory;
using System.Windows.Forms;
using System.Globalization;
using System.Numerics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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

        #region AoB Scans

        public async void PatternScanSoulsDecrementFunction()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("4C 89 75 18 48 8B 4D 58 89 44 19 78", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x08;

            // Write 
            uint intValue = 0x90909090;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
        }

        public async void PatternScanSoulsLossOnDeath()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("4C 89 75 18 48 8B 4D 50 89 44 19 78", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x8;

            // Write 
            uint intValue = 0x90909090;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
        }

        public async void InfiniteHealthHack()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("F0 00 00 00 89 84 19 C4 03 00 00 7E 09 48 83 C4 28", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x3;
            var FinalResult2 = FinalResult + 0x4;
            
            // Write 
            uint intValue = 0x00909090;
            uint intValue2 = 0x90909090;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        #endregion

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

        #region TIMERS

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

                // This nifty bool is pretty helpful :)
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
            // aye if it aint running , we aint wasting the resources mmkay?
            if (!rpcs3Running)
            {
                return;
            }

            //Reads Current Souls and displays the value via Label
            BigInteger parseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            var SoulsAddr = parseSoulsAddr.ToString("X");
            var SoulsAddrValue = m.ReadUInt(SoulsAddr);
            var CURRENT_SOULS = SwapBytes(SoulsAddrValue);
            CurrentSouls_Label.Text = "Current Souls: " + Convert.ToString(CURRENT_SOULS);

            //Reads Current NewMoonGrass and displays the value via label
            BigInteger parseNewMoonGrass = BigInteger.Parse("3301E89E0", NumberStyles.HexNumber);
            var NewMoonGrassAddr = parseNewMoonGrass.ToString("X");
            var NewMoonGrassValue = m.ReadUInt(NewMoonGrassAddr);
            var CURRENT_NEWMOONGRASS = SwapBytes(NewMoonGrassValue);
            CurrentNewMoonGrass_Label.Text = "New Moon Grass: " + Convert.ToString(CURRENT_NEWMOONGRASS);

            //Reads Current SoldiersSouls and displays the value via Label
            BigInteger parseSoldiersSouls = BigInteger.Parse("3301E8700", NumberStyles.HexNumber);
            var SoldiersSoulsAddr = parseSoldiersSouls.ToString("X");
            var SoldiersSoulsValue = m.ReadUInt(SoldiersSoulsAddr);
            var CURRENT_SOLDIERSSOULS = SwapBytes(SoldiersSoulsValue);
            CurrentSoldiersSouls_Label.Text = "Current Soldiers Souls: " + Convert.ToString(CURRENT_SOLDIERSSOULS);

        }

        #endregion

        #region BUTTONS
        // Need to provide more paremeters for the buttons , for instance if there is text in the textbox etc
        private void Souls_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            // Player Souls Address
            BigInteger parseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            string hex = $"0x{parseSoulsAddr:X8}";
            
            // Convert Textbox text to to int
            int intValue = Convert.ToInt32(SendSouls_textBox.Text);
            
            // Convert & Reverse bytes
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            
            // Write Value in textbox to memory
            m.WriteBytes(hex, intBytes);
        }

        private void DarkMoonGrass_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            // Address
            BigInteger parseDarkMoonGrassAddr = BigInteger.Parse("3301E89E0", NumberStyles.HexNumber);
            string hex = $"0x{parseDarkMoonGrassAddr:X8}";
            
            // Convert textbox text to int
            int intValue = Convert.ToInt32(NewMoonGrass_textBox.Text);
            
            // Convert & Reverse bytes
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            
            // Write Value in textbox to memory
            m.WriteBytes(hex, intBytes);

        }

        private void SoldiersSouls_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            // Address
            BigInteger parseSoldiersSoulsAddr = BigInteger.Parse("3301E8700", NumberStyles.HexNumber);
            string hex = $"0x{parseSoldiersSoulsAddr:X8}";
            
            // Convert textbox text to int
            int intValue = Convert.ToInt32(SoldiersSouls_textBox.Text);
            
            // Convert & Reverse bytes
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            
            // Write Value in textbox to memory
            m.WriteBytes(hex, intBytes);
        }


        private void PatternScan_Button_Click(object sender, EventArgs e)
        {
            PatternScanSoulsDecrementFunction();
            PatternScanSoulsLossOnDeath();
        }

        private void InfiniteHealth_Button_Click(object sender, EventArgs e)
        {
            InfiniteHealthHack();
        }

        private void PatternScan2_Button_Click(object sender, EventArgs e)
        {
            //This is to reverse the byte change made by the previous button
            //Not yet implemented
            /// Might as well use this for a debug button 
        }
        #endregion


    }
}
