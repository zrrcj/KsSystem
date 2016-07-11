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
    public class XS_BLL
    {
        /// <summary>
        /// 返回分页数据和数据总条数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        ///  
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere, SQL_DBHelp dp,string v)
        {
            XS_DAL a = new XS_DAL();
            //XS_IDAL b = (XS_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere, dp,"");
        }
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere, SQL_DBHelp dp)
        {
            XS_DAL a = new XS_DAL();
            //XS_IDAL b = (XS_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere, dp);
        }
        public DataTable select(SQL_DBHelp dp)
        {
            XS_DAL da = new XS_DAL();
            return da.select(dp);
        }
        public XS_Model selects(string sql, SQL_DBHelp dp)
        {
            XS_DAL da = new XS_DAL();
            DataTable m = da.selects(sql, dp);
            XS_Model model = new XS_Model();
            if (m.Rows.Count > 0)
            {
                model.hnn09_xs_no = m.Rows[0]["HNN09_XS_NO"].ToString();
                model.hnn09_xs_name = m.Rows[0]["HNN09_XS_NAME"].ToString();
                model.hnn09_xs_pwd = m.Rows[0]["HNN09_XS_PWD"].ToString();
                model.hnn09_xs_sex = Convert.ToInt32(m.Rows[0]["HNN09_XS_SEX"].ToString());
                model.hnn09_xs_phone = m.Rows[0]["HNN09_XS_PHONE"].ToString();
                model.hnn09_xs_age = Convert.ToInt32(m.Rows[0]["HNN09_XS_AGE"].ToString());
                model.hnn09_xs_clsid = Convert.ToInt32(m.Rows[0]["HNN09_XS_CLSID"].ToString());
                return model;
            }
            else
            {
                return null;
            }


        }
        public bool delete(string tableName, string IdName, string id)
        {
            XS_DAL da = new XS_DAL();
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
        public bool add(XS_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            XS_DAL t = new XS_DAL();
            m.hnn09_xs_id = dp.GetSequnce("hnn09_xs", "hnn09_xs_id");
            string msg = t.Add(m, dp);
            dp.CloseResource();
            if (msg.ToUpper().Equals("OK"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public XS_Model updata(string tableName, string strWhere)
        {
            XS_DAL da = new XS_DAL();
            DataTable m = da.updata(tableName, strWhere);
            XS_Model model = new XS_Model();
            model.hnn09_xs_no = m.Rows[0]["HNN09_XS_NO"].ToString();
            model.hnn09_xs_name = m.Rows[0]["HNN09_XS_NAME"].ToString();
            model.hnn09_xs_pwd = m.Rows[0]["HNN09_XS_PWD"].ToString();
            model.hnn09_xs_sex = Convert.ToInt32(m.Rows[0]["HNN09_XS_SEX"].ToString());
            model.hnn09_xs_phone = m.Rows[0]["HNN09_XS_PHONE"].ToString();
            model.hnn09_xs_age = Convert.ToInt32(m.Rows[0]["HNN09_XS_AGE"].ToString());
            model.hnn09_xs_clsid = Convert.ToInt32(m.Rows[0]["HNN09_XS_CLSID"].ToString());
            return model;
        }
        public bool updata(XS_Model m)
        {
            XS_DAL da = new XS_DAL();

            if (da.updata(m) > 0)
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
