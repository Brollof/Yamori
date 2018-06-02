using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    class LimitInputView
    {
        private TextBox txtTime = new TextBox();
        private CheckBox cbSelected = new CheckBox();
        private LimitInputModel model = new LimitInputModel();

        public LimitInputView()
        {
            txtTime.TextChanged += txtTime_TextChanged;
            cbSelected.CheckedChanged += cbSelected_CheckedChanged;
        }

        void cbSelected_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            model.Selected = cb.Checked;
        }

        void txtTime_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            model.Time = Convert.ToInt32(txt.Text);
        }

        public TextBox TxtTime
        {
            get { return txtTime; }
            set { txtTime = value; }
        }

        public CheckBox CbSelected
        {
            get { return cbSelected; }
            set { cbSelected = value; }
        }

        internal LimitInputModel Model
        {
            get { return model; }
            set { model = value; }
        }
    }

    class LimitTempView
    {
        private Label labName = new Label();
        private LimitInputView min = new LimitInputView();
        private LimitInputView max = new LimitInputView();
        private LimitTempModel model;

        internal LimitTempModel Model
        {
            get { return model; }
            set { model = value; }
        }

        internal LimitInputView Min
        {
            get { return min; }
            set { min = value; }
        }

        internal LimitInputView Max
        {
            get { return max; }
            set { max = value; }
        }

        public Label LabName
        {
            get { return labName; }
            set { labName = value; }
        }

        public LimitTempView(LimitTempModel model)
        {
            this.model = model;

            labName.Text = model.Name;

            min.TxtTime.Text = "0";
            min.CbSelected.Checked = false;

            max.TxtTime.Text = "0";
            max.CbSelected.Checked = false;
        }

        public static List<LimitTempView> Create(List<LimitTempModel> models)
        {
            List<LimitTempView> ret = new List<LimitTempView>();
            foreach(var model in models)
            {
                LimitTempView view = new LimitTempView(model);
                ret.Add(view);
            }
            return ret;
        }
    }
}
