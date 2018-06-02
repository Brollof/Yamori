﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    class LimitTempView
    {
        private Label labName = new Label();
        private TextBox txtTime = new TextBox();
        private CheckBox cbSelected = new CheckBox();
        private LimitTempModel model;

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

        internal LimitTempModel Model
        {
            get { return model; }
            set { model = value; }
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

            txtTime.Text = "0";
            cbSelected.Checked = false;

            txtTime.TextChanged += txtTime_TextChanged;
            cbSelected.CheckedChanged += cbSelected_CheckedChanged;
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
    }
}