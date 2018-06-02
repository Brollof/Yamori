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
        private System.Windows.Forms.Label labMin;
        private System.Windows.Forms.TableLayoutPanel limitSetter;
        private Label label1;
        private Label label2;
        private TextBox txtMaxTemp;
        private TextBox txtMinTemp;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private System.Windows.Forms.Label labMax;
    
        protected override void Dispose(bool disposing)
        {
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labMin = new System.Windows.Forms.Label();
            this.labMax = new System.Windows.Forms.Label();
            this.limitSetter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.txtMinTemp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.limitSetter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labMin
            // 
            this.labMin.AutoSize = true;
            this.labMin.Location = new System.Drawing.Point(4, 67);
            this.labMin.Name = "labMin";
            this.labMin.Size = new System.Drawing.Size(30, 13);
            this.labMin.TabIndex = 0;
            this.labMin.Text = "Min.:";
            // 
            // labMax
            // 
            this.labMax.AutoSize = true;
            this.labMax.Location = new System.Drawing.Point(4, 34);
            this.labMax.Name = "labMax";
            this.labMax.Size = new System.Drawing.Size(33, 13);
            this.labMax.TabIndex = 1;
            this.labMax.Text = "Max.:";
            // 
            // limitSetter
            // 
            this.limitSetter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.limitSetter.ColumnCount = 1;
            this.limitSetter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.limitSetter.Controls.Add(this.labMin, 0, 2);
            this.limitSetter.Controls.Add(this.labMax, 0, 1);
            this.limitSetter.Location = new System.Drawing.Point(33, 77);
            this.limitSetter.Name = "limitSetter";
            this.limitSetter.RowCount = 3;
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.Size = new System.Drawing.Size(50, 100);
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
            // txtMaxTemp
            // 
            this.txtMaxTemp.Location = new System.Drawing.Point(140, 13);
            this.txtMaxTemp.MaxLength = 2;
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.Size = new System.Drawing.Size(48, 20);
            this.txtMaxTemp.TabIndex = 5;
            // 
            // txtMinTemp
            // 
            this.txtMinTemp.Location = new System.Drawing.Point(140, 38);
            this.txtMinTemp.MaxLength = 2;
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.Size = new System.Drawing.Size(48, 20);
            this.txtMinTemp.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMinTemp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaxTemp);
            this.groupBox1.Location = new System.Drawing.Point(33, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limity";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "°C";
            // 
            // LimitWindow
            // 
            this.ClientSize = new System.Drawing.Size(517, 203);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.limitSetter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LimitWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.limitSetter.ResumeLayout(false);
            this.limitSetter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public LimitWindow()
        {
            InitializeComponent();
        }

        private void FillCell(CheckBox cb, TextBox txt, int col, int row)
        {
            Panel panel = new Panel();
            limitSetter.Controls.Add(panel, col, row);

            txt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txt.Location = new Point(50, 0);
            txt.Width = 50;

            cb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cb.Width = 45;

            panel.Width = 100;
            panel.Controls.Add(cb);
            panel.Controls.Add(txt);
        }

        private void UpdateColumnStyles()
        {
            float percent = 100f / (limitSetter.ColumnCount - 1);
            for (int i = 1; i < limitSetter.ColumnCount; i++)
            {
                limitSetter.ColumnStyles[i].SizeType = SizeType.Percent;
                limitSetter.ColumnStyles[i].Width = percent;
            }
        }

        public LimitWindow(List<LimitTempView> views) : this()
        {
            try
            {
                for (int i = 0; i < views.Count; i++)
                {
                    LimitTempView col = views[i];
                    limitSetter.ColumnCount++;
                    limitSetter.Width += 100;
                    ColumnStyle style = new ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                    limitSetter.ColumnStyles.Add(style);

                    limitSetter.Controls.Add(col.LabName, i + 1, 0);
                    FillCell(col.Max.CbSelected, col.Max.TxtTime, i + 1, 1);
                    FillCell(col.Min.CbSelected, col.Min.TxtTime, i + 1, 2);
                }

                UpdateColumnStyles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
