using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNNDB09_DOME.COMMON
{
   public  class DataSQLhelp
    {
        public string ParameName { get; set; }
        public object ParameVale { get; set; }
        public DataSQLhelp(string  paramename,object paramevale)
        {
            ParameName = paramename;
            ParameVale = paramevale;
        }
    }
}
