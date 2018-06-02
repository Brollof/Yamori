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
        private TextBox txtMaxTemp;
        private TextBox txtMinTemp;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private const int COL_WIDTH = 80;
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.limitSetter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.txtMinTemp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            // LimitWindow
            // 
            this.ClientSize = new System.Drawing.Size(545, 203);
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
            float percent = 100f / limitSetter.ColumnCount;
            for (int i = 0; i < limitSetter.ColumnCount; i++)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
