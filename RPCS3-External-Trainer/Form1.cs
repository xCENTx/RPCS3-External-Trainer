using System;
using Memory;
using System.Windows.Forms;
using System.Globalization;
using System.Numerics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RPCS3_External_Trainer_SOURCE
{
    public partial class MainForm : Form
    {
        Mem m = new Mem();
        private const string RPCS3PROCESSNAME = "rpcs3.exe";
        bool rpcs3Running;
        bool HackActive;
        bool NeverLoseSoulsActive;
        bool InfiniteHealthActive;
        bool InfiniteStaminaActive;
        bool InfiniteMagicActive;

        #region Methods

        public uint SwapBytes(uint x)
        {
            return ((x & 0x000000ff) << 24) +
                   ((x & 0x0000ff00) << 8) +
                   ((x & 0x00ff0000) >> 8) +
                   ((x & 0xff000000) >> 24);
        }

        public void MemoryReader()
        {
            //Reads Current Souls and displays the value via Label
            BigInteger parseSoulsAddr = BigInteger.Parse("3301E8098", NumberStyles.HexNumber);
            var SoulsAddr = parseSoulsAddr.ToString("X");
            var SoulsAddrValue = m.ReadUInt(SoulsAddr);
            var CURRENT_SOULS = SwapBytes(SoulsAddrValue);
            CurrentSouls_Label.Text = "Souls: " + Convert.ToString(CURRENT_SOULS);

            //Reads Current NewMoonGrass and displays the value via label
            BigInteger parseNewMoonGrass = BigInteger.Parse("3301E89E0", NumberStyles.HexNumber);
            var NewMoonGrassAddr = parseNewMoonGrass.ToString("X");
            var NewMoonGrassValue = m.ReadUInt(NewMoonGrassAddr);
            var CURRENT_NEWMOONGRASS = SwapBytes(NewMoonGrassValue);
            CurrentNewMoonGrass_Label.Text = "EqSlot 1: " + Convert.ToString(CURRENT_NEWMOONGRASS);

            //Reads Current SoldiersSouls and displays the value via Label
            BigInteger parseSoldiersSouls = BigInteger.Parse("3301E8700", NumberStyles.HexNumber);
            var SoldiersSoulsAddr = parseSoldiersSouls.ToString("X");
            var SoldiersSoulsValue = m.ReadUInt(SoldiersSoulsAddr);
            var CURRENT_SOLDIERSSOULS = SwapBytes(SoldiersSoulsValue);
            CurrentSoldiersSouls_Label.Text = "EqSlot 2: " + Convert.ToString(CURRENT_SOLDIERSSOULS);
        }

        public void SendSouls()
        {
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

        /// ITEMS
        /// From what I can tell , this memory region contains item values specific to each player save so these MUST be edited manually :/
        /// FOR ME THIS IS NEW MOON GRASS
        public void SendItem1()
        {
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

        /// FOR ME THIS IS SOLDIERS SOULS
        public void SendItem2()
        {
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

        /// AoB Scans & Patches
        /// 
        public void D3BUG()
        {
            if (!HackActive)
            {
                var CAUTION = Color.FromArgb(169, 169, 0);
                PatternScanSoulsLossOnDeath();
                Thread.Sleep(125);
                PatternScanSoulsDecrementFunction();
                Thread.Sleep(125);
                InfiniteHealthHack();
                Thread.Sleep(125);
                InfiniteStamina();
                Thread.Sleep(125);
                InfiniteStamina2();
                Thread.Sleep(125);
                InfiniteStamina3();
                InfiniteMagic();
                D3BUG_Indicator.BackColor = Color.FromArgb(0, 169, 0);
                InfiniteHealth_Indicator.BackColor = CAUTION;
                InfiniteStamina_Indicator.BackColor = CAUTION;
                InfiniteMagic_Indicator.BackColor = CAUTION;
                NeverLoseSouls_Indicator.BackColor = CAUTION;
                HackActive = true;
            }
            else
            {
                DISABLE_SoulsLossOnDeath();
                Thread.Sleep(125);
                DISABLE_SoulsDecrementFunction();
                Thread.Sleep(125);
                DISABLE_InfinitHealthHack();
                Thread.Sleep(125);
                DISABLE_InfiniteStamina();
                Thread.Sleep(125);
                DISABLE_InfiniteStamina2();
                Thread.Sleep(125);
                DISABLE_InfiniteStamina3();
                DISABLE_InfiniteMagic();
                HackActive = false;
            }
        }

        public async void PatternScanSoulsLossOnDeath()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
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

        public async void PatternScanSoulsDecrementFunction()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
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

        //Fully Functional
        //Notes: Enemies have increased health
        public async void InfiniteHealthHack()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
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
        
        public async void InfiniteMagic()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("89 94 18 CC 03 00 00 89 8D 74 04 00 00 48 83 C4 28 49 FF E0 BA 88 FC 26 00", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x90909090;
            uint intValue2 = 0x90909089;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);

        }

        public async void DISABLE_InfiniteMagic()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("90 90 90 90 90 90 90 89 8D 74 04 00 00 48 83 C4 28 49 FF E0 BA 88 FC 26 00", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x899418CC;
            uint intValue2 = 0x03000089;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        public async void InfiniteStamina()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("F8 00 00 00 89 84 19 D4 03 00 00", false, true);
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

        public async void InfiniteStamina2()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("89 84 19 D4 03 00 00 7E 09 48 83 C4 28", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x90909090;
            uint intValue2 = 0x9090907E;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        public async void InfiniteStamina3()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("89 94 18 D4 03 00 00 89 8D 74 04 00 00 48 83 C4 28 49 FF E0 BA D8 FC 26 00", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x90909090;
            uint intValue2 = 0x90909089;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        public async void DISABLE_InfiniteStamina()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("F8 00 00 00 90 90 90 90 90 90 90", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x4;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x898419D4;
            uint intValue2 = 0x030000B0;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        public async void DISABLE_InfiniteStamina2()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("90 90 90 90 90 90 90 7E 09 48 83 C4 28", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x898419D4;
            uint intValue2 = 0x0300007E;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        public async void DISABLE_InfiniteStamina3()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("90 90 90 90 90 90 90 89 8D 74 04 00", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x898419D4;
            uint intValue2 = 0x03000089;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        //Fully Functional
        public async void DISABLE_InfinitHealthHack()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("90 90 90 90 90 90 90 7E 09 48 83 C4 28", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult;
            var FinalResult2 = FinalResult + 0x4;

            // Write 
            uint intValue = 0x898419C4;
            uint intValue2 = 0x0300007E;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            byte[] intBytes2 = BitConverter.GetBytes(intValue2);
            Array.Reverse(intBytes2);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
            m.WriteBytes(FinalResult2.ToString("X"), intBytes2);
        }

        //Fully Functional
        public async void DISABLE_SoulsLossOnDeath()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("4C 89 75 18 48 8B 4D 50 90 90 90 90", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x8;

            // Write 
            uint intValue = 0x89441978;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
        }

        //Fully Functional
        public async void DISABLE_SoulsDecrementFunction()
        {
            if (!m.OpenProcess(RPCS3PROCESSNAME))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AoB Scan & Store Result
            IEnumerable<long> AoBScanResults = await m.AoBScan("4C 89 75 18 48 8B 4D 58 90 90 90 90", false, true);
            long SingleAoBScanResult = AoBScanResults.FirstOrDefault();
            var FinalResult = SingleAoBScanResult + 0x08;

            // Write 89 44 19 78
            uint intValue = 0x89441978;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            Array.Reverse(intBytes);
            m.WriteBytes(FinalResult.ToString("X"), intBytes);
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
            if (!rpcs3Running)
            {
                return;
            }
            MemoryReader();

            ///Color Indicators ... very helpful 
            var INACTIVE_COLOR = Color.FromArgb(169, 0, 0);
            if ((!NeverLoseSoulsActive) && (!HackActive))
            {
                NeverLoseSouls_Indicator.BackColor = INACTIVE_COLOR;
            }
            if ((!InfiniteHealthActive) && (!HackActive))
            {
                InfiniteHealth_Indicator.BackColor = INACTIVE_COLOR;
            }
            if ((!InfiniteStaminaActive) && (!HackActive))
            {
                InfiniteStamina_Indicator.BackColor = INACTIVE_COLOR;
            }
            if ((!InfiniteMagicActive) && (!HackActive))
            {
                InfiniteMagic_Indicator.BackColor = INACTIVE_COLOR;
            }
            if ((!HackActive) && (!InfiniteStaminaActive) && (!InfiniteHealthActive) && (!InfiniteMagicActive) && (!NeverLoseSoulsActive))
            {
                D3BUG_Indicator.BackColor = INACTIVE_COLOR;
            }
            
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
            SendSouls();
        }

        //Item Slot 1
        //This is New Moon Grass for me
        private void DarkMoonGrass_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            SendItem1();
        }
        
        //Item Slot 2
        //This is Soldiers Souls for me
        private void SoldiersSouls_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            SendItem2();
        }

        // Never Lose Souls
        private void PatternScan_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            
            if ((!NeverLoseSoulsActive) && (!HackActive))
            {
                PatternScanSoulsDecrementFunction();
                Thread.Sleep(125);
                PatternScanSoulsLossOnDeath();
                NeverLoseSouls_Indicator.BackColor = Color.FromArgb(0, 169, 0);
                D3BUG_Indicator.BackColor = Color.FromArgb(169, 169, 0);
                NeverLoseSoulsActive = true;
            }
            else if (!HackActive)
            {
                DISABLE_SoulsLossOnDeath();
                Thread.Sleep(125);
                DISABLE_SoulsDecrementFunction();
                NeverLoseSoulsActive = false;
            }
        }

        // Infinite Health
        private void InfiniteHealth_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            if ((!InfiniteHealthActive) && (!HackActive))
            {
                InfiniteHealthHack();
                InfiniteHealth_Indicator.BackColor = Color.FromArgb(0, 169, 0);
                D3BUG_Indicator.BackColor = Color.FromArgb(169, 169, 0);
                InfiniteHealthActive = true;
            }
            else if (!HackActive)
            {
                DISABLE_InfinitHealthHack();
                InfiniteHealthActive = false;
            }
        }

        // Infinite Stamina
        private void InfiniteStamina_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }

            if ((!InfiniteStaminaActive) && (!HackActive))
            {
                InfiniteStamina();
                Thread.Sleep(100);
                InfiniteStamina2();
                Thread.Sleep(100);
                InfiniteStamina3();
                InfiniteStaminaActive = true;
                InfiniteStamina_Indicator.BackColor = Color.FromArgb(0, 169, 0);
                D3BUG_Indicator.BackColor = Color.FromArgb(169, 169, 0);
            }
            else if (!HackActive)
            {
                DISABLE_InfiniteStamina();
                Thread.Sleep(100);
                DISABLE_InfiniteStamina2();
                Thread.Sleep(100);
                DISABLE_InfiniteStamina3();
                InfiniteStaminaActive = false;
            }
        }

        // LABEL = D3BUG
        private void PatternScan2_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            /// Might as well use this for a debug button 
            /// This activates all 3 Pattern scans and pushes the patches at the same time
            /// Infinite Health, Magic, Stamina & Never Lose Souls
            if ((!InfiniteHealthActive) && (!InfiniteStaminaActive) && (!NeverLoseSoulsActive) && (!InfiniteMagicActive))
            {
                D3BUG();
            }
        }

        #endregion

        private void InfiniteMagic_Button_Click(object sender, EventArgs e)
        {
            if (!rpcs3Running)
            {
                return;
            }
            if ((!InfiniteMagicActive) && (!HackActive))
            {
                InfiniteMagic();
                InfiniteMagic_Indicator.BackColor = Color.FromArgb(0, 169, 0);
                D3BUG_Indicator.BackColor = Color.FromArgb(169, 169, 0);
                InfiniteMagicActive = true;
            }
            else if (!HackActive)
            {
                DISABLE_InfiniteMagic();
                InfiniteMagicActive = false;
            }
        }
    }
}
