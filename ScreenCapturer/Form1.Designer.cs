namespace ScreenCapturer
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
            this.acquire_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.globalEventProvider1 = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.generateppt_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acquire_Button
            // 
            this.acquire_Button.Location = new System.Drawing.Point(11, 12);
            this.acquire_Button.Name = "acquire_Button";
            this.acquire_Button.Size = new System.Drawing.Size(96, 23);
            this.acquire_Button.TabIndex = 0;
            this.acquire_Button.Text = "Select Areas";
            this.acquire_Button.UseVisualStyleBackColor = true;
            this.acquire_Button.Click += new System.EventHandler(this.acquire_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(159, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(35, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "About";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // generateppt_Button
            // 
            this.generateppt_Button.Location = new System.Drawing.Point(12, 47);
            this.generateppt_Button.Name = "generateppt_Button";
            this.generateppt_Button.Size = new System.Drawing.Size(93, 22);
            this.generateppt_Button.TabIndex = 4;
            this.generateppt_Button.Text = "Generate PPT";
            this.generateppt_Button.UseVisualStyleBackColor = true;
            this.generateppt_Button.Visible = false;
            this.generateppt_Button.Click += new System.EventHandler(this.generateppt_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 81);
            this.Controls.Add(this.generateppt_Button);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.acquire_Button);
            this.Name = "Form1";
            this.Text = "ScrCpt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acquire_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button generateppt_Button;
    }
}

