
using System;
using HNNDB09_DOME.COMMON;
using System.Data;
using System.Data.SqlClient;
using HNNDB09_DOME.MODEL;
namespace HNNDB09_DOME.DAL
{
    public class XK_DAL
    {

        public DataTable selects(string sql, SQL_DBHelp dp)
        {
            return dp.GetList(sql);
        }
        public DataTable updata(string tableName, string strWhere)
        {
            string sql = "select * from " + tableName + " where hnn09_xk_id=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return da.GetList(tableName, strWhere, sql);
        }
        public int updata(XK_Model m)
        {
            string sql = "UPDATE hnn09_xk SET hnn09_xk_name=@hnn09_xk_name WHERE hnn09_xk_id=" + m.hnn09_xk_id;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_xk_name",m.hnn09_xk_name)
               };
            SQL_DBHelp da = new SQL_DBHelp();
            return da.ExeNonQuery(sql, param);
        }
        public int delel(string tableName, string IdName, string id)
        {
            SQL_DBHelp da = new SQL_DBHelp();
            int a = da.deleID(tableName, IdName, id);
            return a;
        }
        private int ListRecord(SQL_DBHelp dp, string strWhere)
        {
            string sql = "select count(0)from hnn09_xk where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));
        }
        public string Add(XK_Model m, SQL_DBHelp dp)
        {
            try
            {
                string sql = "insert into hnn09_xk(hnn09_xk_id,hnn09_xk_name) values(@hnn09_xk_id,@hnn09_xk_name)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_xk_id",m.hnn09_xk_id),
                  new SqlParameter("@hnn09_xk_name",m.hnn09_xk_name)
               };
                dp.ExeNonQuery(sql, param);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere, SQL_DBHelp dp)
        {
            JsonDataSource jds = new JsonDataSource();
            string sql = "select * from(select *, row_number() over(order by hnn09_xk_id desc)as rn from hnn09_xk where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
