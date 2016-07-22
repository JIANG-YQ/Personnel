using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Salary
    {
        public string stuffNum
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string time
        {
            get;
            set;
        }

        public float basisSalary
        {
            get;
            set;
        }

        public float prize
        {
            get;
            set;
        }

        public float depAllowance
        {
            get;
            set;
        }

        public float tmpAllowance
        {
            get;
            set;
        }

        public float tax
        {
            get;
            set;
        }

        public float trueSalary
        {
            get
            {
                return basisSalary + prize + depAllowance + tmpAllowance - tax;
            }
        }
    }
}
