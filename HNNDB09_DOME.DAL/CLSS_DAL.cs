using HNNDB09_DOME.MODEL;
using System;
using HNNDB09_DOME.COMMON;
using System.Data;
using System.Data.SqlClient;

namespace HNNDB09_DOME.DAL
{
    public class CLSS_DAL
    {
        public bool add(CLSS_Model m)
        {
            throw new NotImplementedException();
        }

        public DataTable selects(string sql,SQL_DBHelp dp)
        {
           return  dp.GetList(sql);
        }
        public DataTable  updata(string tableName,string strWhere)
        {
            string sql = "select * from " + tableName + " where hnn09_clss_id=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return  da.GetList(tableName,strWhere,sql);
            //throw new NotImplementedException();
        }
        public int updata(CLSS_Model m)
        {
            string sql = "UPDATE hnn09_clss SET hnn09_clss_name=@hnn09_clss_name,hnn09_clss_number=@hnn09_clss_number WHERE hnn09_clss_id=" + m.hnn09_clss_id;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_clss_name",m.hnn09_clss_name),
                  new SqlParameter("@hnn09_clss_number",m.hnn09_clss_number)
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
            string sql = "select count(0)from hnn09_clss where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));

        }

        public string Add(CLSS_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into hnn09_clss(hnn09_clss_id,hnn09_clss_name,hnn09_clss_number) values(@hnn09_clss_id,@hnn09_clss_name,@hnn09_clss_number)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_clss_id",m.hnn09_clss_id),
                  new SqlParameter("@hnn09_clss_name",m.hnn09_clss_name),
                  new SqlParameter("@hnn09_clss_number",m.hnn09_clss_number)
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
            string sql = "select * from(select *, row_number() over(order by hnn09_clss_id desc)as rn from hnn09_clss where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
