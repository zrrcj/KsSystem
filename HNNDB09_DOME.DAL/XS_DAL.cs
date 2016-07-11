using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNNDB09_DOME.COMMON;
using System.Data;
using System.Data.SqlClient;

namespace HNNDB09_DOME.DAL
{
    public class XS_DAL
    {
        public bool add(XS_Model m)
        {
            throw new NotImplementedException();
        }
        public DataTable select(SQL_DBHelp da)
        {
            
            return da.GetListProcedure("P_SJXS");
           
        }
        public DataTable selects(string sql,SQL_DBHelp dp)
        {
           return  dp.GetList(sql);
        }
        public DataTable  updata(string tableName,string strWhere)
        {
            string sql = "select * from " + tableName + " where hnn09_xs_id=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return  da.GetList(tableName,strWhere,sql);
            //throw new NotImplementedException();
        }
        public int updata(XS_Model m)
        {
            string sql = "UPDATE hnn09_xs SET hnn09_xs_no=@hnn09_xs_no,hnn09_xs_name=@hnn09_xs_name,hnn09_xs_sex=@hnn09_xs_sex,hnn09_xs_age=@hnn09_xs_age,hnn09_xs_phone=@hnn09_xs_phone,hnn09_xs_clsid=@hnn09_xs_clsid WHERE hnn09_xs_id=" + m.hnn09_xs_id;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_xs_no",m.hnn09_xs_no),
                  new SqlParameter("@hnn09_xs_name",m.hnn09_xs_name),
                  new SqlParameter("@hnn09_xs_sex",m.hnn09_xs_sex),
                  new SqlParameter("@hnn09_xs_age",m.hnn09_xs_age),
                  new SqlParameter("@hnn09_xs_phone",m.hnn09_xs_phone),
                   new SqlParameter("@hnn09_xs_clsid",m.hnn09_xs_clsid)
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
            string sql = "select count(0)from hnn09_xs where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));

        }

        public string Add(XS_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into hnn09_xs(hnn09_xs_id,hnn09_xs_no,hnn09_xs_pwd,hnn09_xs_name,hnn09_xs_sex,hnn09_xs_age,hnn09_xs_phone,hnn09_xs_clsid) values(@hnn09_xs_id,@hnn09_xs_no,@hnn09_xs_pwd,@hnn09_xs_name,@hnn09_xs_sex,@hnn09_xs_age,@hnn09_xs_phone,@hnn09_xs_clsid)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_xs_id",m.hnn09_xs_id),
                  new SqlParameter("@hnn09_xs_no",m.hnn09_xs_no),
                  new SqlParameter("@hnn09_xs_pwd",m.hnn09_xs_pwd),
                  new SqlParameter("@hnn09_xs_name",m.hnn09_xs_name),
                  new SqlParameter("@hnn09_xs_sex",m.hnn09_xs_sex),
                  new SqlParameter("@hnn09_xs_age",m.hnn09_xs_age),
                  new SqlParameter("@hnn09_xs_phone",m.hnn09_xs_phone),
                   new SqlParameter("@hnn09_xs_clsid",m.hnn09_xs_clsid)
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
        //    string sql = "select * from HNN09_XS where 1=1 " + strWhere;
        //    SQL_DBHelp da = new SQL_DBHelp();
        //    return  da.executeDataAdapter(sql);

        //}
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere, SQL_DBHelp dp,string V)
        {
            JsonDataSource jds = new JsonDataSource();
            string sql = "select * from(select *, row_number() over(order by hnn09_xs_id asc)as rn from V_TJ where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }

        public JsonDataSource list(int pageIndex, int pageSize, string strWhere, SQL_DBHelp dp)
        {
            JsonDataSource jds = new JsonDataSource();
            string sql = "select * from(select *, row_number() over(order by hnn09_xs_id desc)as rn from hnn09_xs where 1=1 " + strWhere + ") as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
