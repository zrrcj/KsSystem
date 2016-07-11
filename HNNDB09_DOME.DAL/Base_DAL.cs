using HNNDB09_DOME.COMMON;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNNDB09_DOME.DAL
{
   public  class Base_DAL
    {
       /// <summary>
       /// 教师更新密码
       /// </summary>
       /// <param name="m">教师模型</param>
       /// <returns></returns>
        public int updata(JS_Model m)
        {
            string sql = "UPDATE hnn09_js SET hnn09_js_pwd=@hnn09_js_pwd WHERE hnn09_js_id=" + m.hnn09_js_id;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_js_pwd",m.hnn09_js_pwd),
                  new SqlParameter("@hnn09_js_id",m.hnn09_js_id)
               };
            SQL_DBHelp da = new SQL_DBHelp();
            return da.ExeNonQuery(sql, param);
            //throw new NotImplementedException();
        }
        public int updata(QX_Model m)
        {
            string sql = "UPDATE HNN09_QX SET HNN09_QX_QX=@HNN09_QX_QX WHERE HNN09_QX_JSID=" + m.HNN09_QX_JSID;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_QX_QX",m.HNN09_QX_QX),
                  new SqlParameter("@HNN09_QX_JSID",m.HNN09_QX_JSID)
               };
            SQL_DBHelp da = new SQL_DBHelp();
            return da.ExeNonQuery(sql, param);
            //throw new NotImplementedException();
        }
        public bool add(QX_Model m ,SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into HNN09_QX(HNN09_QX_ID,HNN09_QX_JSID,HNN09_QX_QX) values(@HNN09_QX_ID,@HNN09_QX_JSID,@HNN09_QX_QX)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_QX_ID",m.HNN09_QX_ID),
                  new SqlParameter("@HNN09_QX_JSID",m.HNN09_QX_JSID),
                  new SqlParameter("@HNN09_QX_QX",m.HNN09_QX_QX)
               };

                dp.ExeNonQuery(sql, param);
                return true;

            }
            catch (Exception ex)
            {
                //throw;
                return false;

            }
        }
        public DataTable list( string strWhere, SQL_DBHelp dp)
        {
            string sql = "select * from hnn09_qx where HNN09_QX_JSID="+ strWhere;
            return dp.GetList(sql);
        }
    }
}
