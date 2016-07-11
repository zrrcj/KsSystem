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
    public class WT_BLL
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
           WT_DAL a = new WT_DAL();
            //js_IDAL b = (js_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere,dp);
        }
        /// <summary>
        /// 随机抽取一条问题
        /// </summary>
        /// <param name="strWhere">条件为空</param>
        /// <returns></returns>
        public WT_Model select( string strWhere)
        {
            WT_DAL da = new WT_DAL();
            DataTable m = da.select(strWhere);
            WT_Model model = new WT_Model();
            if (m.Rows.Count > 0)
            {
                model.HNN09_WT_WT = m.Rows[0]["HNN09_WT_WT"].ToString();
                model.HNN09_WT_DA = m.Rows[0]["HNN09_WT_DA"].ToString();
                model.HNN09_WT_ID = Convert.ToInt32(m.Rows[0]["HNN09_WT_ID"].ToString()); ;
                model.HNN09_WT_XKID = Convert.ToInt32(m.Rows[0]["HNN09_WT_XKID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        public WT_Model selects(string sql, SQL_DBHelp dp)
        {
           WT_DAL da = new WT_DAL();
           DataTable m = da.selects(sql,dp);
           WT_Model model = new WT_Model ();
            if (m.Rows.Count>0)
            {
                model.HNN09_WT_WT = m.Rows[0]["HNN09_WT_WT"].ToString();
                model.HNN09_WT_DA = m.Rows[0]["HNN09_WT_DA"].ToString();
                model.HNN09_WT_ID = Convert.ToInt32(m.Rows[0]["HNN09_WT_ID"].ToString()); ;
                model.HNN09_WT_XKID = Convert.ToInt32(m.Rows[0]["HNN09_WT_XKID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
           
           
        }
        public bool delete(string tableName, string IdName, string id)
        {
           WT_DAL da = new WT_DAL();
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
        public bool add(WT_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
           WT_DAL t = new WT_DAL();
            m.HNN09_WT_ID = dp.GetSequnce("HNN09_WT", "HNN09_WT_ID");
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
        public WT_Model updata(string tableName,string strWhere)
        {
           WT_DAL da = new WT_DAL();
            DataTable  m= da.updata(tableName,strWhere);
           WT_Model model = new WT_Model();
           model.HNN09_WT_WT = m.Rows[0]["HNN09_WT_WT"].ToString();
           model.HNN09_WT_DA = m.Rows[0]["HNN09_WT_DA"].ToString();
           model.HNN09_WT_ID = Convert.ToInt32(m.Rows[0]["HNN09_WT_ID"].ToString()); ;
           model.HNN09_WT_XKID = Convert.ToInt32(m.Rows[0]["HNN09_WT_XKID"].ToString());
            return model;
        }
        public bool updata(WT_Model m)
        {
           WT_DAL da = new WT_DAL();
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
