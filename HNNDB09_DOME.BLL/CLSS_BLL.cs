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
    public class CLSS_BLL
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
            CLSS_DAL a = new CLSS_DAL();
            //js_IDAL b = (js_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere,dp);
        }
        public CLSS_Model selects(string sql, SQL_DBHelp dp)
        {
            CLSS_DAL da = new CLSS_DAL();
            DataTable m = da.selects(sql,dp);
            CLSS_Model model = new CLSS_Model ();
            if (m.Rows.Count>0)
            {
                model.hnn09_clss_name = m.Rows[0]["HNN09_CLSS_NAME"].ToString();
                model.hnn09_clss_number = Convert.ToInt32(m.Rows[0]["HNN09_CLSS_NUMBER"].ToString());
                return model;
            }
            else
            {
                return null;
            }
           
           
        }
        public bool delete(string tableName, string IdName, string id)
        {
            CLSS_DAL da = new CLSS_DAL();
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
        public bool add(CLSS_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            CLSS_DAL t = new CLSS_DAL();
            m.hnn09_clss_id = dp.GetSequnce("hnn09_clss", "hnn09_clss_id");
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
        public CLSS_Model updata(string tableName,string strWhere)
        {
            CLSS_DAL da = new CLSS_DAL();
            DataTable  m= da.updata(tableName,strWhere);
            CLSS_Model model = new CLSS_Model();
            model.hnn09_clss_name= m.Rows[0]["HNN09_CLSS_NAME"].ToString();

            model.hnn09_clss_number = Convert.ToInt32(m.Rows[0]["HNN09_CLSS_NUMBER"].ToString());

            return model;
        }
        public bool updata(CLSS_Model m)
        {
            CLSS_DAL da = new CLSS_DAL();
           
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
