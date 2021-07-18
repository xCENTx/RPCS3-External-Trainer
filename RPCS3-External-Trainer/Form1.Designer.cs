
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Souls_Button = new System.Windows.Forms.Button();
            this.SendSouls_textBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.CurrentSouls_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.CurrentSouls_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSouls_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurrentSouls_Label.Location = new System.Drawing.Point(0, 0);
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(25)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rpcs3Status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 26);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "THIS IS A TEST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(192, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 50);
            this.panel2.TabIndex = 7;
            // 
            // Souls_Button
            // 
            this.Souls_Button.Location = new System.Drawing.Point(117, 27);
            this.Souls_Button.Name = "Souls_Button";
            this.Souls_Button.Size = new System.Drawing.Size(124, 23);
            this.Souls_Button.TabIndex = 8;
            this.Souls_Button.Text = "SEND SOULS";
            this.Souls_Button.UseVisualStyleBackColor = true;
            this.Souls_Button.Click += new System.EventHandler(this.Souls_Button_Click);
            // 
            // SendSouls_textBox
            // 
            this.SendSouls_textBox.Location = new System.Drawing.Point(11, 29);
            this.SendSouls_textBox.Name = "SendSouls_textBox";
            this.SendSouls_textBox.Size = new System.Drawing.Size(100, 20);
            this.SendSouls_textBox.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(274, 96);
            this.Controls.Add(this.SendSouls_textBox);
            this.Controls.Add(this.Souls_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CurrentSouls_Label);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RPCS3 Trainer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

