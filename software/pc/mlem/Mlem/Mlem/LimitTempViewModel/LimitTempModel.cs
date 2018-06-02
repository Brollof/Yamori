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
    }
}
