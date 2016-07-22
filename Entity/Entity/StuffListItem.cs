using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StuffListItem
    {
        public Stuff stuff
        {
            get;
            set;
        }

        public string id
        {
            get;
            set;
        }

        public string leaveReason
        {
            get;
            set;
        }

        public string submitTime
        {
            get;
            set;
        }

        public string submitStuffNum
        {
            get;
            set;
        }

        public string checkTime
        {
            get;
            set;
        }

        public string checkStuffNum
        {
            get;
            set;
        }

        public StuffListItem()
        {
            stuff = new Stuff();
        }
    }
}
