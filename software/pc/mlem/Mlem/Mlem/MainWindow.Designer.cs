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
            this.InTabContextMenu = new DevComponents.DotNetBar.ButtonItem();
            this.InTabRemoveTab = new DevComponents.DotNetBar.ButtonItem();
            this.cbShowPeriod = new System.Windows.Forms.CheckBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnLimits = new System.Windows.Forms.Button();
            this.gbAddDevice = new System.Windows.Forms.GroupBox();
            this.ddDeviceSlot = new System.Windows.Forms.ComboBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.ddDeviceType = new System.Windows.Forms.ComboBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.labDeviceName = new System.Windows.Forms.Label();
            this.labDeviceType = new System.Windows.Forms.Label();
            this.labDeviceSlot = new System.Windows.Forms.Label();
            this.labDeviceColor = new System.Windows.Forms.Label();
            this.cddDeviceColor = new Mlem.ColorDropDown();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.gbAddDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(22, 21);
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
            this.calendarView1.Visible = false;
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
            this.IntervalHeaderContextMenu,
            this.InTabContextMenu});
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
            this.InContentAddAppContextItem.Text = "Dodaj";
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
            this.AppDeleteContextItem.Text = "Usuń";
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
            // InTabContextMenu
            // 
            this.InTabContextMenu.AutoExpandOnClick = true;
            this.InTabContextMenu.Name = "InTabContextMenu";
            this.InTabContextMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.InTabRemoveTab});
            this.InTabContextMenu.Text = "InTab";
            // 
            // InTabRemoveTab
            // 
            this.InTabRemoveTab.Name = "InTabRemoveTab";
            this.InTabRemoveTab.Text = "Usuń urządzenie";
            this.InTabRemoveTab.Click += new System.EventHandler(this.InTabRemoveTab_Click);
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
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(22, 77);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 38);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "Odczytaj konfigurację";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnLimits
            // 
            this.btnLimits.Enabled = false;
            this.btnLimits.Location = new System.Drawing.Point(779, 66);
            this.btnLimits.Name = "btnLimits";
            this.btnLimits.Size = new System.Drawing.Size(75, 23);
            this.btnLimits.TabIndex = 12;
            this.btnLimits.Text = "Limity";
            this.btnLimits.UseVisualStyleBackColor = true;
            this.btnLimits.Click += new System.EventHandler(this.btnLimits_Click);
            // 
            // gbAddDevice
            // 
            this.gbAddDevice.Controls.Add(this.labDeviceColor);
            this.gbAddDevice.Controls.Add(this.labDeviceSlot);
            this.gbAddDevice.Controls.Add(this.labDeviceType);
            this.gbAddDevice.Controls.Add(this.labDeviceName);
            this.gbAddDevice.Controls.Add(this.ddDeviceSlot);
            this.gbAddDevice.Controls.Add(this.txtDeviceName);
            this.gbAddDevice.Controls.Add(this.cddDeviceColor);
            this.gbAddDevice.Controls.Add(this.ddDeviceType);
            this.gbAddDevice.Controls.Add(this.btnAddDevice);
            this.gbAddDevice.Location = new System.Drawing.Point(148, 21);
            this.gbAddDevice.Name = "gbAddDevice";
            this.gbAddDevice.Size = new System.Drawing.Size(444, 68);
            this.gbAddDevice.TabIndex = 13;
            this.gbAddDevice.TabStop = false;
            this.gbAddDevice.Text = "Dodaj urządzenie";
            // 
            // ddDeviceSlot
            // 
            this.ddDeviceSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDeviceSlot.FormattingEnabled = true;
            this.ddDeviceSlot.Location = new System.Drawing.Point(270, 34);
            this.ddDeviceSlot.Name = "ddDeviceSlot";
            this.ddDeviceSlot.Size = new System.Drawing.Size(76, 21);
            this.ddDeviceSlot.TabIndex = 4;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(103, 34);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(79, 20);
            this.txtDeviceName.TabIndex = 3;
            // 
            // ddDeviceType
            // 
            this.ddDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDeviceType.FormattingEnabled = true;
            this.ddDeviceType.Location = new System.Drawing.Point(188, 34);
            this.ddDeviceType.Name = "ddDeviceType";
            this.ddDeviceType.Size = new System.Drawing.Size(76, 21);
            this.ddDeviceType.TabIndex = 1;
            this.ddDeviceType.SelectedIndexChanged += new System.EventHandler(this.ddDeviceType_SelectedIndexChanged);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(6, 32);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(75, 23);
            this.btnAddDevice.TabIndex = 0;
            this.btnAddDevice.Text = "Dodaj";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // labDeviceName
            // 
            this.labDeviceName.AutoSize = true;
            this.labDeviceName.Location = new System.Drawing.Point(109, 18);
            this.labDeviceName.Name = "labDeviceName";
            this.labDeviceName.Size = new System.Drawing.Size(40, 13);
            this.labDeviceName.TabIndex = 5;
            this.labDeviceName.Text = "Nazwa";
            // 
            // labDeviceType
            // 
            this.labDeviceType.AutoSize = true;
            this.labDeviceType.Location = new System.Drawing.Point(199, 18);
            this.labDeviceType.Name = "labDeviceType";
            this.labDeviceType.Size = new System.Drawing.Size(25, 13);
            this.labDeviceType.TabIndex = 5;
            this.labDeviceType.Text = "Typ";
            // 
            // labDeviceSlot
            // 
            this.labDeviceSlot.AutoSize = true;
            this.labDeviceSlot.Location = new System.Drawing.Point(279, 18);
            this.labDeviceSlot.Name = "labDeviceSlot";
            this.labDeviceSlot.Size = new System.Drawing.Size(25, 13);
            this.labDeviceSlot.TabIndex = 5;
            this.labDeviceSlot.Text = "Slot";
            // 
            // labDeviceColor
            // 
            this.labDeviceColor.AutoSize = true;
            this.labDeviceColor.Location = new System.Drawing.Point(361, 18);
            this.labDeviceColor.Name = "labDeviceColor";
            this.labDeviceColor.Size = new System.Drawing.Size(31, 13);
            this.labDeviceColor.TabIndex = 5;
            this.labDeviceColor.Text = "Kolor";
            // 
            // cddDeviceColor
            // 
            this.cddDeviceColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cddDeviceColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cddDeviceColor.FormattingEnabled = true;
            this.cddDeviceColor.Location = new System.Drawing.Point(352, 34);
            this.cddDeviceColor.Name = "cddDeviceColor";
            this.cddDeviceColor.Size = new System.Drawing.Size(73, 21);
            this.cddDeviceColor.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(870, 428);
            this.Controls.Add(this.gbAddDevice);
            this.Controls.Add(this.btnLimits);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cbShowPeriod);
            this.Controls.Add(this.contextMenuBar1);
            this.Controls.Add(this.calendarView1);
            this.Controls.Add(this.btnSend);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mlem 0.1";
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.gbAddDevice.ResumeLayout(false);
            this.gbAddDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.CheckBox cbShowPeriod;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnLimits;
        private System.Windows.Forms.GroupBox gbAddDevice;
        private System.Windows.Forms.ComboBox ddDeviceType;
        private System.Windows.Forms.Button btnAddDevice;
        private ColorDropDown cddDeviceColor;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.ComboBox ddDeviceSlot;
        private DevComponents.DotNetBar.ButtonItem InTabContextMenu;
        private DevComponents.DotNetBar.ButtonItem InTabRemoveTab;
        private System.Windows.Forms.Label labDeviceName;
        private System.Windows.Forms.Label labDeviceColor;
        private System.Windows.Forms.Label labDeviceSlot;
        private System.Windows.Forms.Label labDeviceType;
    }
}

