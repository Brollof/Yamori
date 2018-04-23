namespace Mlem
{
    partial class MainWindow
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
            this.butConn = new System.Windows.Forms.Button();
            this.labConnStatus = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butConn
            // 
            this.butConn.Location = new System.Drawing.Point(22, 24);
            this.butConn.Name = "butConn";
            this.butConn.Size = new System.Drawing.Size(75, 23);
            this.butConn.TabIndex = 0;
            this.butConn.Text = "Connect";
            this.butConn.UseVisualStyleBackColor = true;
            this.butConn.Click += new System.EventHandler(this.button1_Click);
            // 
            // labConnStatus
            // 
            this.labConnStatus.AutoSize = true;
            this.labConnStatus.Location = new System.Drawing.Point(103, 29);
            this.labConnStatus.Name = "labConnStatus";
            this.labConnStatus.Size = new System.Drawing.Size(24, 13);
            this.labConnStatus.TabIndex = 1;
            this.labConnStatus.Text = "Idle";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(22, 65);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnJson
            // 
            this.btnJson.Location = new System.Drawing.Point(324, 129);
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(75, 23);
            this.btnJson.TabIndex = 3;
            this.btnJson.Text = "button1";
            this.btnJson.UseVisualStyleBackColor = true;
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 345);
            this.Controls.Add(this.btnJson);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.labConnStatus);
            this.Controls.Add(this.butConn);
            this.Name = "MainWindow";
            this.Text = "Mlem 0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butConn;
        private System.Windows.Forms.Label labConnStatus;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnJson;
    }
}

