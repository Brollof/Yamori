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
            this.components = new System.ComponentModel.Container();
            this.butConn = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.calendarView1 = new DevComponents.DotNetBar.Schedule.CalendarView();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.InContentContextMenu = new DevComponents.DotNetBar.ButtonItem();
            this.InContentAddAppContextItem = new DevComponents.DotNetBar.ButtonItem();
            this.AppointmentContextMenu = new DevComponents.DotNetBar.ButtonItem();
            this.AppDeleteContextItem = new DevComponents.DotNetBar.ButtonItem();
            this.IntervalHeaderContextMenu = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.ddLampNum = new System.Windows.Forms.ComboBox();
            this.cbShowPeriod = new System.Windows.Forms.CheckBox();
            this.lampPicker = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.lampPicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // butConn
            // 
            this.butConn.Location = new System.Drawing.Point(22, 24);
            this.butConn.Name = "butConn";
            this.butConn.Size = new System.Drawing.Size(75, 23);
            this.butConn.TabIndex = 0;
            this.butConn.Text = "Połącz";
            this.butConn.UseVisualStyleBackColor = true;
            this.butConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(22, 65);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 39);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Zapisz konfigurację";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // calendarView1
            // 
            this.calendarView1.AllowTabReorder = false;
            this.calendarView1.AutoScrollMinSize = new System.Drawing.Size(26880, 102);
            this.calendarView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.calendarView1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.calendarView1.ContainerControlProcessDialogKey = true;
            this.calendarView1.EnableDragDrop = false;
            this.calendarView1.Is24HourFormat = true;
            this.calendarView1.IsMonthMoreItemsIndicatorVisible = false;
            this.calendarView1.IsMonthSideBarVisible = false;
            this.calendarView1.LabelTimeSlots = true;
            this.calendarView1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.calendarView1.Location = new System.Drawing.Point(22, 149);
            this.calendarView1.MultiUserTabHeight = 19;
            this.calendarView1.Name = "calendarView1";
            this.calendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.TimeLine;
            this.calendarView1.Size = new System.Drawing.Size(820, 260);
            this.calendarView1.TabIndex = 2;
            this.calendarView1.Text = "calendarView1";
            this.calendarView1.TimeIndicator.BorderColor = System.Drawing.Color.Empty;
            this.calendarView1.TimeIndicator.IndicatorArea = DevComponents.DotNetBar.Schedule.eTimeIndicatorArea.All;
            this.calendarView1.TimeIndicator.Tag = null;
            this.calendarView1.TimeIndicator.Visibility = DevComponents.DotNetBar.Schedule.eTimeIndicatorVisibility.AllResources;
            this.calendarView1.TimeSlotDuration = 15;
            this.calendarView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.calendarView1_MouseUp);
            this.calendarView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.calendarView1_KeyUp);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(55)))), ((int)(((byte)(58))))));
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.InContentContextMenu,
            this.AppointmentContextMenu,
            this.IntervalHeaderContextMenu});
            this.contextMenuBar1.Location = new System.Drawing.Point(87, 244);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(565, 25);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 6;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // InContentContextMenu
            // 
            this.InContentContextMenu.AutoExpandOnClick = true;
            this.InContentContextMenu.Name = "InContentContextMenu";
            this.InContentContextMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.InContentAddAppContextItem});
            this.InContentContextMenu.Text = "InContent";
            // 
            // InContentAddAppContextItem
            // 
            this.InContentAddAppContextItem.Name = "InContentAddAppContextItem";
            this.InContentAddAppContextItem.Text = "Add Appointment";
            this.InContentAddAppContextItem.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // AppointmentContextMenu
            // 
            this.AppointmentContextMenu.AutoExpandOnClick = true;
            this.AppointmentContextMenu.Name = "AppointmentContextMenu";
            this.AppointmentContextMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AppDeleteContextItem});
            this.AppointmentContextMenu.Text = "Appointment";
            // 
            // AppDeleteContextItem
            // 
            this.AppDeleteContextItem.Name = "AppDeleteContextItem";
            this.AppDeleteContextItem.Text = "Delete Appointment";
            this.AppDeleteContextItem.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // IntervalHeaderContextMenu
            // 
            this.IntervalHeaderContextMenu.AutoExpandOnClick = true;
            this.IntervalHeaderContextMenu.Name = "IntervalHeaderContextMenu";
            this.IntervalHeaderContextMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem7});
            this.IntervalHeaderContextMenu.Text = "InIntervalHeader";
            // 
            // labelItem7
            // 
            this.labelItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.labelItem7.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem7.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.labelItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.PaddingBottom = 1;
            this.labelItem7.PaddingLeft = 10;
            this.labelItem7.PaddingTop = 1;
            this.labelItem7.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.labelItem7.Text = "Interval Time";
            // 
            // ddLampNum
            // 
            this.ddLampNum.FormattingEnabled = true;
            this.ddLampNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.ddLampNum.Location = new System.Drawing.Point(148, 21);
            this.ddLampNum.Name = "ddLampNum";
            this.ddLampNum.Size = new System.Drawing.Size(121, 21);
            this.ddLampNum.TabIndex = 8;
            this.ddLampNum.Text = "4";
            this.ddLampNum.SelectedIndexChanged += new System.EventHandler(this.cbLampsNum_SelectedIndexChanged);
            // 
            // cbShowPeriod
            // 
            this.cbShowPeriod.AutoSize = true;
            this.cbShowPeriod.Location = new System.Drawing.Point(779, 12);
            this.cbShowPeriod.Name = "cbShowPeriod";
            this.cbShowPeriod.Size = new System.Drawing.Size(81, 17);
            this.cbShowPeriod.TabIndex = 9;
            this.cbShowPeriod.Text = "Pokaż czas";
            this.cbShowPeriod.UseVisualStyleBackColor = true;
            this.cbShowPeriod.CheckedChanged += new System.EventHandler(this.cbShowPeriod_CheckedChanged);
            // 
            // lampPicker
            // 
            this.lampPicker.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.lampPicker.ColumnCount = 1;
            this.lampPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.lampPicker.Controls.Add(this.label2, 0, 1);
            this.lampPicker.Controls.Add(this.label1, 0, 0);
            this.lampPicker.Location = new System.Drawing.Point(148, 56);
            this.lampPicker.Name = "lampPicker";
            this.lampPicker.RowCount = 2;
            this.lampPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lampPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.lampPicker.Size = new System.Drawing.Size(60, 74);
            this.lampPicker.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kolor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(870, 428);
            this.Controls.Add(this.lampPicker);
            this.Controls.Add(this.cbShowPeriod);
            this.Controls.Add(this.ddLampNum);
            this.Controls.Add(this.contextMenuBar1);
            this.Controls.Add(this.calendarView1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.butConn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mlem 0.1";
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.lampPicker.ResumeLayout(false);
            this.lampPicker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butConn;
        private System.Windows.Forms.Button btnSend;
        private DevComponents.DotNetBar.Schedule.CalendarView calendarView1;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem InContentContextMenu;
        private DevComponents.DotNetBar.ButtonItem InContentAddAppContextItem;
        private DevComponents.DotNetBar.ButtonItem AppointmentContextMenu;
        private DevComponents.DotNetBar.ButtonItem AppDeleteContextItem;
        private DevComponents.DotNetBar.ButtonItem IntervalHeaderContextMenu;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ComboBox ddLampNum;
        private System.Windows.Forms.CheckBox cbShowPeriod;
        private System.Windows.Forms.TableLayoutPanel lampPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

