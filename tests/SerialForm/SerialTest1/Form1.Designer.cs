namespace SerialTest1
{
    partial class Form1
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.viewWindow = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(395, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // viewWindow
            // 
            this.viewWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewWindow.BackColor = System.Drawing.SystemColors.Window;
            this.viewWindow.Location = new System.Drawing.Point(12, 12);
            this.viewWindow.Name = "viewWindow";
            this.viewWindow.ReadOnly = true;
            this.viewWindow.Size = new System.Drawing.Size(776, 342);
            this.viewWindow.TabIndex = 1;
            this.viewWindow.Text = "";
            this.viewWindow.TextChanged += new System.EventHandler(this.viewWindow_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(375, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Speech Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 360);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(776, 20);
            this.commandLine.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.viewWindow);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Ducker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox viewWindow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox commandLine;
    }
}

