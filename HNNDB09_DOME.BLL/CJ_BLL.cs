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
    public class CJ_BLL
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
           CJ_DAL a = new CJ_DAL();
            //js_IDAL b = (js_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere,dp);
        }
        /// <summary>
        /// 随机抽取一条问题
        /// </summary>
        /// <param name="strWhere">条件为空</param>
        /// <returns></returns>
        public CJ_Model select( string strWhere)
        {
            CJ_DAL da = new CJ_DAL();
            DataTable m = da.select(strWhere);
            CJ_Model model = new CJ_Model();
            if (m.Rows.Count > 0)
            {
                model.HNN09_CJ_WTID =Convert.ToInt32( m.Rows[0]["HNN09_CJ_WTID"].ToString());
                model.HNN09_CJ_CJ =Convert.ToInt32( m.Rows[0]["HNN09_CJ_CJ"].ToString());
                model.HNN09_CJ_ID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_ID"].ToString()); ;
                model.HNN09_CJ_XSID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_XSID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        public CJ_Model selects(string sql, SQL_DBHelp dp)
        {
           CJ_DAL da = new CJ_DAL();
           DataTable m = da.selects(sql,dp);
           CJ_Model model = new CJ_Model ();
            if (m.Rows.Count>0)
            {
                model.HNN09_CJ_WTID =Convert.ToInt32( m.Rows[0]["HNN09_CJ_WTID"].ToString());
                model.HNN09_CJ_CJ =Convert.ToInt32( m.Rows[0]["HNN09_CJ_CJ"].ToString());
                model.HNN09_CJ_ID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_ID"].ToString()); ;
                model.HNN09_CJ_XSID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_XKID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
           
           
        }
        public bool delete(string tableName, string IdName, string id)
        {
           CJ_DAL da = new CJ_DAL();
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
        public bool add(CJ_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
           CJ_DAL t = new CJ_DAL();
            m.HNN09_CJ_ID = dp.GetSequnce("HNN09_CJ", "HNN09_CJ_ID");
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
        public CJ_Model updata(string tableName,string strWhere)
        {
           CJ_DAL da = new CJ_DAL();
            DataTable  m= da.updata(tableName,strWhere);
           CJ_Model model = new CJ_Model();
           model.HNN09_CJ_WTID =Convert.ToInt32 ( m.Rows[0]["HNN09_CJ_WTID"].ToString());
           model.HNN09_CJ_CJ =Convert.ToInt32( m.Rows[0]["HNN09_CJ_CJ"].ToString());
           model.HNN09_CJ_ID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_ID"].ToString()); ;
           model.HNN09_CJ_XSID = Convert.ToInt32(m.Rows[0]["HNN09_CJ_XSID"].ToString());
            return model;
        }
        public bool updata(CJ_Model m)
        {
           CJ_DAL da = new CJ_DAL();
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
