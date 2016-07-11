using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNNDB09_DOME.MODEL;
using System.Data;
using HNNDB09_DOME.COMMON;

namespace HNNDB09_DOME.IDAL
{
    public interface  js_IDAL
    {
         bool  add(JS_Model m);
        bool  updata(JS_Model m);
        bool delel(string tableid);
        JsonDataSource list(int pageIndex, int pageSize, string strWhere);
    }
}
