using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    class LimitTempModel
    {
        private string name;
        private bool selected;
        private int time;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public LimitTempModel() { }
        public LimitTempModel(string name)
        {
            this.name = name;
        }

        public static List<LimitTempModel> Create(List<string> names)
        {
            List<LimitTempModel> ret = new List<LimitTempModel>();
            foreach(var name in names)
            {
                LimitTempModel model = new LimitTempModel(name);
                ret.Add(model);
            }
            return ret;
        }

        public static List<LimitTempModel> Create(List<string> names, List<LimitTempModel> models)
        {
            List<LimitTempModel> ret = new List<LimitTempModel>();
            for (int i = 0; i < names.Count; i++)
            {
                LimitTempModel model;
                if (i < models.Count)
                {
                    model = models[i].Clone();
                    model.Name = names[i];
                }
                else
                {
                    model = new LimitTempModel(names[i]);
                }

                ret.Add(model);
            }
            return ret;
        }

        public LimitTempModel Clone()
        {
            LimitTempModel model = new LimitTempModel(this.Name);
            model.selected = this.selected;
            model.time = this.time;
            return model;
        }
    }
}
