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
    public class JS_BLL
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
            JS_DAL a = new JS_DAL();
            //js_IDAL b = (js_IDAL)a;
            return a.list(pageIndex, pageSize, strWhere,dp);
        }
        /// <summary>
        /// 返回任教班级或任教学科
        /// </summary>
        /// <param name="V_name">视图</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public DataTable list(string V_name, string strWhere, SQL_DBHelp dp)
        {
            JS_DAL dal = new JS_DAL();
            return  dal.list(V_name, strWhere, dp);
        }
        /// <summary>
        /// 任教班级数据
        /// </summary>
        /// <param name="jsid"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public DataTable list(string jsid, SQL_DBHelp dp)
        {
            return new JS_DAL().list(jsid, dp);
        }
        public JS_Model selects(string sql, SQL_DBHelp dp)
        {
            JS_DAL da = new JS_DAL();
            DataTable m = da.selects(sql,dp);
            JS_Model model = new JS_Model ();
            if (m.Rows.Count>0)
            {
                model.hnn09_js_id = Convert.ToInt32( m.Rows[0]["HNN09_JS_ID"].ToString());
                model.hnn09_js_no = m.Rows[0]["HNN09_JS_NO"].ToString();
                model.hnn09_js_name = m.Rows[0]["HNN09_JS_NAME"].ToString();
                model.hnn09_js_pwd = m.Rows[0]["HNN09_JS_PWD"].ToString();
                model.hnn09_js_sex = Convert.ToInt32(m.Rows[0]["HNN09_JS_SEX"].ToString());
                model.hnn09_js_zw = m.Rows[0]["HNN09_JS_ZW"].ToString();
                model.hnn09_js_zc = m.Rows[0]["HNN09_JS_ZC"].ToString();
                model.hnn09_js_sj = Convert.ToInt32(m.Rows[0]["HNN09_JS_SJ"].ToString());
                return model;
            }
            else
            {
                return null;
            }
           
           
        }
        /// <summary>
        /// 教师授班
        /// </summary>
        /// <param name="lm"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool add(List<BJRJ_Model> lm,string id)
        {
            bool mesg = false;
            JS_DAL da = new JS_DAL();
            SQL_DBHelp dp = new SQL_DBHelp();
            dp.KqTransa();
            try
            {
                da.delel("HNN09_BJRJ", "HNN09_BJRJ_JSID", id);
                foreach (BJRJ_Model m in lm)
                {
                    m.HNN09_BJRJ_ID = dp.GetSequnce("HNN09_BJRJ","HNN09_BJRJ_ID");
                    da.Add(m, dp);
                }
                dp.TjTransa();
                mesg = true;
            }
            catch (Exception ex)
            {
                dp.HgTransa();
                throw ex;
            }
            return mesg;
        }
        
        public bool delete(string tableName, string IdName, string id)
        {
            JS_DAL da = new JS_DAL();
            int a = da.delel(tableName, IdName, id);
            if (a != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 教师授课
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="IdName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool add(List<RJXK_Model> lm, string id)
        {
            bool mesg = false;
            JS_DAL da = new JS_DAL();
            SQL_DBHelp dp = new SQL_DBHelp();
            dp.KqTransa();
            try
            {
                da.delel("HNN09_RJXK", "HNN09_RJXK_JSID", id);
                foreach (RJXK_Model m in lm)
                {
                    m.HNN09_RJXK_ID = dp.GetSequnce("HNN09_RJXK", "HNN09_RJXK_ID");
                    da.Add(m, dp);
                }
                dp.TjTransa();
                mesg = true;
                dp.CloseResource();
            }
            catch (Exception ex)
            {
                dp.HgTransa();
                throw ex;
            }
            return mesg;
        }
        //public bool delete(string tableName, string IdName, string id)
        //{
        //    JS_DAL da = new JS_DAL();
        //    int a = da.delel(tableName, IdName, id);
        //    if (a != 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        /// <summary>
        /// 添加是否成功
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool add(JS_Model m)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_DAL t = new JS_DAL();
            m.hnn09_js_id = dp.GetSequnce("hnn09_js", "hnn09_js_id");
            Base_BLL bl = new Base_BLL();
            bool s= bl.add(m.hnn09_js_id);
            string msg = t.Add(m, dp);
            if (msg.ToUpper().Equals("OK")||s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public JS_Model updata(string tableName,string strWhere)
        {
            JS_DAL da = new JS_DAL();
            DataTable  m= da.updata(tableName,strWhere);
            JS_Model model = new JS_Model();
            model.hnn09_js_no= m.Rows[0]["HNN09_JS_NO"].ToString();
            model.hnn09_js_name=m.Rows[0]["HNN09_JS_NAME"].ToString();
            model.hnn09_js_pwd = m.Rows[0]["HNN09_JS_PWD"].ToString();
            model.hnn09_js_sex = Convert.ToInt32(m.Rows[0]["HNN09_JS_SEX"].ToString());
            model.hnn09_js_zw = m.Rows[0]["HNN09_JS_ZW"].ToString();
            model.hnn09_js_zc = m.Rows[0]["HNN09_JS_ZC"].ToString();
            model.hnn09_js_sj = Convert.ToInt32(m.Rows[0]["HNN09_JS_SJ"].ToString());
            return model;
        }
        public bool updata(JS_Model m)
        {
            JS_DAL da = new JS_DAL();
           
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
