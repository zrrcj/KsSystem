
using System;
using HNNDB09_DOME.COMMON;
using System.Data;
using System.Data.SqlClient;
using HNNDB09_DOME.MODEL;
namespace HNNDB09_DOME.DAL
{
    public class WT_DAL
    {

        public DataTable selects(string sql,SQL_DBHelp dp)
        {
           return  dp.GetList(sql);
        }
        public DataTable  updata(string tableName,string strWhere)
        {
            string sql = "select * from " + tableName + " where HNN09_WT_id=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return  da.GetList(tableName,strWhere,sql);
            //throw new NotImplementedException();
        }
        public DataTable select(string strWhere)
        {
            string sql = "select top 1* from HNN09_WT WHERE 1=1 " + strWhere + "  ORDER BY NEWID()";
            SQL_DBHelp da = new SQL_DBHelp();
            return da.GetList(sql);
        }
        public int updata(WT_Model m)
        {
            string sql = "UPDATE HNN09_WT SET HNN09_WT_WT=@HNN09_WT_WT,HNN09_WT_DA=@HNN09_WT_DA,HNN09_WT_XKID=@HNN09_WT_XKID WHERE HNN09_WT_ID=" + m.HNN09_WT_ID;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_WT_DA",m.HNN09_WT_DA),
                  new SqlParameter("@HNN09_WT_WT",m.HNN09_WT_WT),
                  new SqlParameter("@HNN09_WT_XKID",m.HNN09_WT_XKID)
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
            string sql = "select count(0)from HNN09_WT where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));

        }

        public string Add(WT_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into HNN09_WT(HNN09_WT_ID,HNN09_WT_WT,HNN09_WT_DA,HNN09_WT_XKID) values(@HNN09_WT_ID,@HNN09_WT_WT,@HNN09_WT_DA,@HNN09_WT_XKID)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_WT_ID",m.HNN09_WT_ID),
                  new SqlParameter("@HNN09_WT_WT",m.HNN09_WT_WT),
                  new SqlParameter("@HNN09_WT_DA",m.HNN09_WT_DA),
                  new SqlParameter("@HNN09_WT_XKID",m.HNN09_WT_XKID)
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
            string sql = "select * from(select *, row_number() over(order by HNN09_WT_ID desc)as rn from HNN09_WT where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
