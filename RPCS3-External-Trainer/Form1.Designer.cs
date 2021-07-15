
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
            this.Souls_Button = new System.Windows.Forms.Button();
            this.Souls_TextBox = new System.Windows.Forms.TextBox();
            this.rpcs3Status = new System.Windows.Forms.Label();
            this.CurrentSouls_Label = new System.Windows.Forms.Label();
            this.RPCS3Process_Timer = new System.Windows.Forms.Timer(this.components);
            this.RPCS3Mem_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Souls_Button
            // 
            this.Souls_Button.Location = new System.Drawing.Point(118, 26);
            this.Souls_Button.Name = "Souls_Button";
            this.Souls_Button.Size = new System.Drawing.Size(75, 23);
            this.Souls_Button.TabIndex = 1;
            this.Souls_Button.Text = "button1";
            this.Souls_Button.UseVisualStyleBackColor = true;
            this.Souls_Button.Click += new System.EventHandler(this.Souls_Button_Click);
            // 
            // Souls_TextBox
            // 
            this.Souls_TextBox.Location = new System.Drawing.Point(12, 28);
            this.Souls_TextBox.Name = "Souls_TextBox";
            this.Souls_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Souls_TextBox.TabIndex = 2;
            // 
            // rpcs3Status
            // 
            this.rpcs3Status.AutoSize = true;
            this.rpcs3Status.Location = new System.Drawing.Point(12, 74);
            this.rpcs3Status.Name = "rpcs3Status";
            this.rpcs3Status.Size = new System.Drawing.Size(35, 13);
            this.rpcs3Status.TabIndex = 3;
            this.rpcs3Status.Text = "label2";
            // 
            // CurrentSouls_Label
            // 
            this.CurrentSouls_Label.AutoSize = true;
            this.CurrentSouls_Label.Location = new System.Drawing.Point(9, 9);
            this.CurrentSouls_Label.Name = "CurrentSouls_Label";
            this.CurrentSouls_Label.Size = new System.Drawing.Size(43, 13);
            this.CurrentSouls_Label.TabIndex = 4;
            this.CurrentSouls_Label.Text = "SOULS";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 96);
            this.Controls.Add(this.CurrentSouls_Label);
            this.Controls.Add(this.rpcs3Status);
            this.Controls.Add(this.Souls_TextBox);
            this.Controls.Add(this.Souls_Button);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RPCS3 Trainer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Souls_Button;
        private System.Windows.Forms.TextBox Souls_TextBox;
        private System.Windows.Forms.Label rpcs3Status;
        private System.Windows.Forms.Label CurrentSouls_Label;
        private System.Windows.Forms.Timer RPCS3Process_Timer;
        private System.Windows.Forms.Timer RPCS3Mem_Timer;
    }
}

