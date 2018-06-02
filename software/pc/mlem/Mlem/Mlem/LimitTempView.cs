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
