using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNNDB09_DOME.DAL;
using System.Data;
using HNNDB09_DOME.COMMON;
using HNNDB09_DOME.MODEL;

namespace HNNDB09_DOME.BLL
{
    public class XK_BLL
    {
        /// <summary>
        /// 返回分页数据和数据总条数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere,SQL_DBHelp dp)
        {
           XK_DAL a = new XK_DAL();
            //js_IDAL b = (js_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere,dp);
        }
        public XK_Model selects(string sql, SQL_DBHelp dp)
        {
           XK_DAL da = new XK_DAL();
            DataTable m = da.selects(sql,dp);
           XK_Model model = new XK_Model ();
            if (m.Rows.Count>0)
            {
                model.hnn09_xk_name = m.Rows[0]["HNN09_XK_NAME"].ToString();
                return model;
            }
            else
            {
                return null;
            }
           
           
        }
        public bool delete(string tableName, string IdName, string id)
        {
           XK_DAL da = new XK_DAL();
            int a = da.delel(tableName, IdName, id);
            if (a != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加是否成功
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool add(XK_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
           XK_DAL t = new XK_DAL();
            m.hnn09_xk_id = dp.GetSequnce("hnn09_XK", "hnn09_XK_id");
            string msg = t.Add(m, dp);
            if (msg.ToUpper().Equals("OK"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public XK_Model updata(string tableName,string strWhere)
        {
           XK_DAL da = new XK_DAL();
            DataTable  m= da.updata(tableName,strWhere);
           XK_Model model = new XK_Model();
            model.hnn09_xk_name= m.Rows[0]["HNN09_XK_NAME"].ToString();

            return model;
        }
        public bool updata(XK_Model m)
        {
           XK_DAL da = new XK_DAL();
           
            if (da.updata (m)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
