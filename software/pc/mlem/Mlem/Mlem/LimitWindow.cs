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
            this.limitSetter.SuspendLayout();
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
            this.limitSetter.Location = new System.Drawing.Point(33, 34);
            this.limitSetter.Name = "limitSetter";
            this.limitSetter.RowCount = 3;
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.limitSetter.Size = new System.Drawing.Size(50, 100);
            this.limitSetter.TabIndex = 2;
            // 
            // LimitWindow
            // 
            this.ClientSize = new System.Drawing.Size(517, 203);
            this.Controls.Add(this.limitSetter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LimitWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.limitSetter.ResumeLayout(false);
            this.limitSetter.PerformLayout();
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
