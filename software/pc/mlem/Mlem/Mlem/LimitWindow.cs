using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    class LimitWindow : Office2007Form
    {
        private System.Windows.Forms.TableLayoutPanel limitSetter;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Button btnOK;
        private NumericTextBox txtMaxTemp;
        private NumericTextBox txtMinTemp;
        private const int COL_WIDTH = 80;
        private List<LimitTempView> views;
        private bool isValid = false;
        public enum TempType { MIN, MAX };
        private bool closeByOk = false;

        public bool IsValid
        {
            get { return isValid; }
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.limitSetter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtMinTemp = new Mlem.NumericTextBox();
            this.txtMaxTemp = new Mlem.NumericTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // limitSetter
            // 
            this.limitSetter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.limitSetter.ColumnCount = 1;
            this.limitSetter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.limitSetter.Location = new System.Drawing.Point(33, 73);
            this.limitSetter.Name = "limitSetter";
            this.limitSetter.RowCount = 2;
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.limitSetter.Size = new System.Drawing.Size(100, 60);
            this.limitSetter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Maksymalna temperatura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimalna temperatura:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMinTemp);
            this.groupBox1.Controls.Add(this.txtMaxTemp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "°C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "°C";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(230, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMinTemp
            // 
            this.txtMinTemp.Location = new System.Drawing.Point(140, 38);
            this.txtMinTemp.MaxLength = 2;
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.ShortcutsEnabled = false;
            this.txtMinTemp.Size = new System.Drawing.Size(48, 20);
            this.txtMinTemp.TabIndex = 8;
            this.txtMinTemp.Text = "0";
            // 
            // txtMaxTemp
            // 
            this.txtMaxTemp.Location = new System.Drawing.Point(140, 13);
            this.txtMaxTemp.MaxLength = 2;
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.ShortcutsEnabled = false;
            this.txtMaxTemp.Size = new System.Drawing.Size(48, 20);
            this.txtMaxTemp.TabIndex = 8;
            this.txtMaxTemp.Text = "0";
            // 
            // LimitWindow
            // 
            this.ClientSize = new System.Drawing.Size(615, 203);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.limitSetter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LimitWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        public LimitWindow()
        {
            InitializeComponent();
            limitSetter.ColumnStyles[0].Width = COL_WIDTH;
            limitSetter.Width = COL_WIDTH;
            closeByOk = false;
            this.FormClosing += LimitWindow_FormClosing;
        }

        void LimitWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeByOk)
            {
                for (int i = 0; i < views.Count; i++)
                {
                    views[i].Model = beginState[i];
                }
            }
        }

        private void FillCell(CheckBox cb, TextBox txt, int col, int row)
        {
            Panel panel = new Panel();
            limitSetter.Controls.Add(panel, col, row);

            cb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cb.Width = 20;

            txt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txt.Location = new Point(cb.Width + 10, 0);
            txt.Width = 40;

            panel.Width = COL_WIDTH;
            panel.Controls.Add(cb);
            panel.Controls.Add(txt);
        }

        private void UpdateColumnStyles()
        {
            float percent = 100f / limitSetter.ColumnCount;
            for (int i = 0; i < limitSetter.ColumnCount; i++)
            {
                limitSetter.ColumnStyles[i].SizeType = SizeType.Percent;
                limitSetter.ColumnStyles[i].Width = percent;
            }
        }

        private List<LimitTempModel> beginState = new List<LimitTempModel>();

        public LimitWindow(List<LimitTempView> gui, int min, int max)
            : this()
        {
            views = gui;
            txtMinTemp.Text = min.ToString();
            txtMaxTemp.Text = max.ToString();

            for (int i = 0; i < views.Count; i++)
            {
                LimitTempView col = views[i];
                // Do not add new column on the first iteration
                // because there is already one
                if (!(limitSetter.ColumnCount == 1 && i == 0))
                {
                    limitSetter.ColumnCount++;
                    limitSetter.Width += COL_WIDTH;
                }
                ColumnStyle style = new ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                limitSetter.ColumnStyles.Add(style);

                limitSetter.Controls.Add(col.LabName, i, 0);
                FillCell(col.CbSelected, col.TxtTime, i, 1);
            }

            UpdateColumnStyles();

            // Copy current model state
            beginState.Clear();
            beginState.AddRange(views.ConvertAll(view => view.Model.Clone()));
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "Błąd danych wejściowych", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (string.IsNullOrEmpty(txtMinTemp.Text) ||
                string.IsNullOrEmpty(txtMaxTemp.Text))
            {
                msg = "Pola nie mogą być puste!";
                goto finish;
            }

            int min = Convert.ToInt32(txtMinTemp.Text);
            int max = Convert.ToInt32(txtMaxTemp.Text);

            if (min >= max)
            {
                msg = "Temperatura minimalna musi być mniejsza niż temperatura maksymalna!";
                goto finish;
            }

            foreach (var view in views)
            {
                if (view.CbSelected.Checked)
                {
                    if (string.IsNullOrEmpty(view.TxtTime.Text))
                    {
                        msg = "Pola nie mogą być puste!";
                        goto finish;
                    }
                    else if (view.TxtTime.Text == "0")
                    {
                        msg = "Czas musi być większy od 0!";
                        goto finish;
                    }
                }
            }

        finish:
            if (!string.IsNullOrEmpty(msg))
            {
                isValid = false;
                ShowError(msg);
            }
            else
            {
                isValid = true;
                closeByOk = true;
                this.Close();
            }
        }

        public int GetTemp(TempType type)
        {
            if (type == TempType.MIN)
            {
                return Convert.ToInt32(txtMinTemp.Text);
            }
            else if (type == TempType.MAX)
            {
                return Convert.ToInt32(txtMaxTemp.Text);
            }

            return 0;
        }
    }
}
