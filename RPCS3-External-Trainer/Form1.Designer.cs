
namespace RPCS3_External_Trainer_SOURCE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rpcs3Status = new System.Windows.Forms.Label();
            this.CurrentSouls_Label = new System.Windows.Forms.Label();
            this.RPCS3Process_Timer = new System.Windows.Forms.Timer(this.components);
            this.RPCS3Mem_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Souls_Button = new System.Windows.Forms.Button();
            this.SendSouls_textBox = new System.Windows.Forms.TextBox();
            this.NewMoonGrass_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CurrentNewMoonGrass_Label = new System.Windows.Forms.Label();
            this.PatternScan_Button = new System.Windows.Forms.Button();
            this.PatternScan2_Button = new System.Windows.Forms.Button();
            this.SoldiersSouls_textBox = new System.Windows.Forms.TextBox();
            this.SoldiersSouls_Button = new System.Windows.Forms.Button();
            this.CurrentSoldiersSouls_Label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.InfiniteHealth_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpcs3Status
            // 
            this.rpcs3Status.AutoSize = true;
            this.rpcs3Status.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpcs3Status.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpcs3Status.Location = new System.Drawing.Point(0, 0);
            this.rpcs3Status.Name = "rpcs3Status";
            this.rpcs3Status.Size = new System.Drawing.Size(111, 26);
            this.rpcs3Status.TabIndex = 3;
            this.rpcs3Status.Text = "rpcs3Status";
            this.rpcs3Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentSouls_Label
            // 
            this.CurrentSouls_Label.AutoSize = true;
            this.CurrentSouls_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSouls_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentSouls_Label.Location = new System.Drawing.Point(1, 2);
            this.CurrentSouls_Label.Name = "CurrentSouls_Label";
            this.CurrentSouls_Label.Size = new System.Drawing.Size(198, 24);
            this.CurrentSouls_Label.TabIndex = 4;
            this.CurrentSouls_Label.Text = "CurrentSoulsLabel";
            // 
            // RPCS3Process_Timer
            // 
            this.RPCS3Process_Timer.Enabled = true;
            this.RPCS3Process_Timer.Interval = 1000;
            this.RPCS3Process_Timer.Tick += new System.EventHandler(this.RPCS3Process_Timer_Tick);
            // 
            // RPCS3Mem_Timer
            // 
            this.RPCS3Mem_Timer.Enabled = true;
            this.RPCS3Mem_Timer.Tick += new System.EventHandler(this.RPCS3Mem_Timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rpcs3Status);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 26);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(190, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 26);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "THIS IS A TEST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Souls_Button
            // 
            this.Souls_Button.Location = new System.Drawing.Point(151, 27);
            this.Souls_Button.Name = "Souls_Button";
            this.Souls_Button.Size = new System.Drawing.Size(65, 23);
            this.Souls_Button.TabIndex = 8;
            this.Souls_Button.Text = "SEND";
            this.Souls_Button.UseVisualStyleBackColor = true;
            this.Souls_Button.Click += new System.EventHandler(this.Souls_Button_Click);
            // 
            // SendSouls_textBox
            // 
            this.SendSouls_textBox.Location = new System.Drawing.Point(68, 29);
            this.SendSouls_textBox.Name = "SendSouls_textBox";
            this.SendSouls_textBox.Size = new System.Drawing.Size(77, 20);
            this.SendSouls_textBox.TabIndex = 9;
            // 
            // NewMoonGrass_textBox
            // 
            this.NewMoonGrass_textBox.Location = new System.Drawing.Point(68, 31);
            this.NewMoonGrass_textBox.Name = "NewMoonGrass_textBox";
            this.NewMoonGrass_textBox.Size = new System.Drawing.Size(77, 20);
            this.NewMoonGrass_textBox.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DarkMoonGrass_Button_Click);
            // 
            // CurrentNewMoonGrass_Label
            // 
            this.CurrentNewMoonGrass_Label.AutoSize = true;
            this.CurrentNewMoonGrass_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentNewMoonGrass_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentNewMoonGrass_Label.Location = new System.Drawing.Point(1, 2);
            this.CurrentNewMoonGrass_Label.Name = "CurrentNewMoonGrass_Label";
            this.CurrentNewMoonGrass_Label.Size = new System.Drawing.Size(243, 24);
            this.CurrentNewMoonGrass_Label.TabIndex = 10;
            this.CurrentNewMoonGrass_Label.Text = "CurrentNewMoonGrass";
            // 
            // PatternScan_Button
            // 
            this.PatternScan_Button.Location = new System.Drawing.Point(6, 183);
            this.PatternScan_Button.Name = "PatternScan_Button";
            this.PatternScan_Button.Size = new System.Drawing.Size(130, 23);
            this.PatternScan_Button.TabIndex = 13;
            this.PatternScan_Button.Text = "NEVER LOSE SOULS";
            this.PatternScan_Button.UseVisualStyleBackColor = true;
            this.PatternScan_Button.Click += new System.EventHandler(this.PatternScan_Button_Click);
            // 
            // PatternScan2_Button
            // 
            this.PatternScan2_Button.Location = new System.Drawing.Point(92, 212);
            this.PatternScan2_Button.Name = "PatternScan2_Button";
            this.PatternScan2_Button.Size = new System.Drawing.Size(99, 23);
            this.PatternScan2_Button.TabIndex = 14;
            this.PatternScan2_Button.Text = "D3BUG";
            this.PatternScan2_Button.UseVisualStyleBackColor = true;
            this.PatternScan2_Button.Click += new System.EventHandler(this.PatternScan2_Button_Click);
            // 
            // SoldiersSouls_textBox
            // 
            this.SoldiersSouls_textBox.Location = new System.Drawing.Point(68, 31);
            this.SoldiersSouls_textBox.Name = "SoldiersSouls_textBox";
            this.SoldiersSouls_textBox.Size = new System.Drawing.Size(77, 20);
            this.SoldiersSouls_textBox.TabIndex = 17;
            // 
            // SoldiersSouls_Button
            // 
            this.SoldiersSouls_Button.Location = new System.Drawing.Point(151, 29);
            this.SoldiersSouls_Button.Name = "SoldiersSouls_Button";
            this.SoldiersSouls_Button.Size = new System.Drawing.Size(65, 23);
            this.SoldiersSouls_Button.TabIndex = 16;
            this.SoldiersSouls_Button.Text = "SEND";
            this.SoldiersSouls_Button.UseVisualStyleBackColor = true;
            this.SoldiersSouls_Button.Click += new System.EventHandler(this.SoldiersSouls_Button_Click);
            // 
            // CurrentSoldiersSouls_Label
            // 
            this.CurrentSoldiersSouls_Label.AutoSize = true;
            this.CurrentSoldiersSouls_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSoldiersSouls_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentSoldiersSouls_Label.Location = new System.Drawing.Point(1, 2);
            this.CurrentSoldiersSouls_Label.Name = "CurrentSoldiersSouls_Label";
            this.CurrentSoldiersSouls_Label.Size = new System.Drawing.Size(154, 24);
            this.CurrentSoldiersSouls_Label.TabIndex = 15;
            this.CurrentSoldiersSouls_Label.Text = "Soldier\'sSouls";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.CurrentSouls_Label);
            this.panel3.Controls.Add(this.Souls_Button);
            this.panel3.Controls.Add(this.SendSouls_textBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 59);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.CurrentNewMoonGrass_Label);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.NewMoonGrass_textBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 59);
            this.panel4.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.CurrentSoldiersSouls_Label);
            this.panel5.Controls.Add(this.SoldiersSouls_Button);
            this.panel5.Controls.Add(this.SoldiersSouls_textBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 118);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(274, 59);
            this.panel5.TabIndex = 20;
            // 
            // InfiniteHealth_Button
            // 
            this.InfiniteHealth_Button.Location = new System.Drawing.Point(146, 183);
            this.InfiniteHealth_Button.Name = "InfiniteHealth_Button";
            this.InfiniteHealth_Button.Size = new System.Drawing.Size(120, 23);
            this.InfiniteHealth_Button.TabIndex = 21;
            this.InfiniteHealth_Button.Text = "INFINITE HEALTH";
            this.InfiniteHealth_Button.UseVisualStyleBackColor = true;
            this.InfiniteHealth_Button.Click += new System.EventHandler(this.InfiniteHealth_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(274, 269);
            this.Controls.Add(this.InfiniteHealth_Button);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PatternScan2_Button);
            this.Controls.Add(this.PatternScan_Button);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RPCS3 Trainer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label rpcs3Status;
        private System.Windows.Forms.Label CurrentSouls_Label;
        private System.Windows.Forms.Timer RPCS3Process_Timer;
        private System.Windows.Forms.Timer RPCS3Mem_Timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Souls_Button;
        private System.Windows.Forms.TextBox SendSouls_textBox;
        private System.Windows.Forms.TextBox NewMoonGrass_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CurrentNewMoonGrass_Label;
        private System.Windows.Forms.Button PatternScan_Button;
        private System.Windows.Forms.Button PatternScan2_Button;
        private System.Windows.Forms.TextBox SoldiersSouls_textBox;
        private System.Windows.Forms.Button SoldiersSouls_Button;
        private System.Windows.Forms.Label CurrentSoldiersSouls_Label;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button InfiniteHealth_Button;
    }
}

