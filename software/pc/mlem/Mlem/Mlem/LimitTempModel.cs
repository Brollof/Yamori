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
        private TimeSpan time;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
    }

    class LimitTempModel
    {
        private string name;
        LimitInputModel min = new LimitInputModel();
        LimitInputModel max = new LimitInputModel();

        public LimitTempModel() { }
        public LimitTempModel(string name)
        {
            this.name = name;
        }

        internal LimitInputModel Min
        {
            get { return min; }
            set { min = value; }
        }

        internal LimitInputModel Max
        {
            get { return max; }
            set { max = value; }
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
