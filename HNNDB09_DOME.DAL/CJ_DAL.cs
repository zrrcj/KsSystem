
using System;
using HNNDB09_DOME.COMMON;
using System.Data;
using System.Data.SqlClient;
using HNNDB09_DOME.MODEL;
namespace HNNDB09_DOME.DAL
{
    public class CJ_DAL
    {

        public DataTable selects(string sql,SQL_DBHelp dp)
        {
           return  dp.GetList(sql);
        }
        public DataTable  updata(string tableName,string strWhere)
        {
            string sql = "select * from " + tableName + " where HNN09_CJ_ID=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return  da.GetList(tableName,strWhere,sql);
            //throw new NotImplementedException();
        }
        public DataTable select(string strWhere)
        {
            string sql = "select top 1* from HNN09_CJ WHERE 1=1 " + strWhere + "  ORDER BY NEWID()";
            SQL_DBHelp da = new SQL_DBHelp();
            return da.GetList(sql);
        }
        public int updata(CJ_Model m)
        {
            string sql = "UPDATE HNN09_WT SET HNN09_CJ_CJ=@HNN09_CJ_CJ,HNN09_CJ_WTID=@HNN09_CJ_WTID,HNN09_CJ_XSID=@HNN09_CJ_XSID WHERE HNN09_CJ_ID=" + m.HNN09_CJ_ID;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_CJ_ID",m.HNN09_CJ_ID),
                  new SqlParameter("@HNN09_CJ_WTID",m.HNN09_CJ_WTID),
                  new SqlParameter("@HNN09_CJ_XSID",m.HNN09_CJ_XSID),
                  new SqlParameter("@HNN09_CJ_CJ",m.HNN09_CJ_CJ)
               };
            SQL_DBHelp da = new SQL_DBHelp();
            return da.ExeNonQuery(sql,param );
            //throw new NotImplementedException();
        }
        public int delel(string tableName, string IdName, string id)
        {
            SQL_DBHelp da = new SQL_DBHelp();

            int a = da.deleID(tableName, IdName, id);
            return a;
            //throw new NotImplementedException();
        }

        private int ListRecord(SQL_DBHelp dp, string strWhere)
        {
            string sql = "select count(0)from HNN09_CJ where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));

        }

        public string Add(CJ_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into HNN09_CJ(HNN09_CJ_ID,HNN09_CJ_WTID,HNN09_CJ_CJ,HNN09_CJ_XSID) values(@HNN09_CJ_ID,@HNN09_CJ_WTID,@HNN09_CJ_CJ,@HNN09_CJ_XSID)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_CJ_ID",m.HNN09_CJ_ID),
                  new SqlParameter("@HNN09_CJ_WTID",m.HNN09_CJ_WTID),
                  new SqlParameter("@HNN09_CJ_CJ",m.HNN09_CJ_CJ),
                  new SqlParameter("@HNN09_CJ_XSID",m.HNN09_CJ_XSID)
               };
                dp.ExeNonQuery(sql, param);
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        //public DataTable list(string strWhere)
        //{
        //    string sql = "select * from HNN09_JS where 1=1 " + strWhere;
        //    SQL_DBHelp da = new SQL_DBHelp();
        //    return  da.executeDataAdapter(sql);

        //}
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere,SQL_DBHelp dp )
        {
            JsonDataSource jds = new JsonDataSource();
            string sql = "select * from(select *, row_number() over(order by HNN09_CJ_ID desc)as rn from HNN09_CJ where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
