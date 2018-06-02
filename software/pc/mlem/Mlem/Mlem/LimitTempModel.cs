using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    class LimitInputModel
    {
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
    }

    class LimitTempModel
    {
        private string name;

        public LimitTempModel() { }
        public LimitTempModel(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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
