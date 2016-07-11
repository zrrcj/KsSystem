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
    public class JS_DAL
    {
        public bool add(JS_Model m)
        {
            throw new NotImplementedException();
        }

        public DataTable selects(string sql,SQL_DBHelp dp)
        {
           return  dp.GetList(sql);
        }
        public DataTable  updata(string tableName,string strWhere)
        {
            string sql = "select * from " + tableName + " where hnn09_js_id=" + strWhere;
            SQL_DBHelp da = new SQL_DBHelp();
            return  da.GetList(tableName,strWhere,sql);
            //throw new NotImplementedException();
        }
        public int updata(JS_Model m)
        {
            string sql = "UPDATE hnn09_js SET hnn09_js_no=@hnn09_js_no,hnn09_js_name=@hnn09_js_name,hnn09_js_sex=@hnn09_js_sex,hnn09_js_zw=@hnn09_js_zw,hnn09_js_zc=@hnn09_js_zc,hnn09_js_sj=@hnn09_js_sj WHERE hnn09_js_id=" + m.hnn09_js_id;
            SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_js_no",m.hnn09_js_no),
                  new SqlParameter("@hnn09_js_name",m.hnn09_js_name),
                  new SqlParameter("@hnn09_js_sex",m.hnn09_js_sex),
                  new SqlParameter("@hnn09_js_zw",m.hnn09_js_zw),
                  new SqlParameter("@hnn09_js_zc",m.hnn09_js_zc),
                  new SqlParameter("@hnn09_js_sj",m.hnn09_js_sj)
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
            string sql = "select count(0)from hnn09_js where 1=1 " + strWhere;
            return Convert.ToInt32(dp.ExeScalar(sql));

        }
        /// <summary>
        /// 教师授班修改方法
        /// </summary>
        /// <param name="m">关联表实体</param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public string Add(BJRJ_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into HNN09_BJRJ(HNN09_BJRJ_ID,HNN09_BJRJ_JSID,HNN09_BJRJ_CSSID) values(@HNN09_BJRJ_ID,@HNN09_BJRJ_JSID,@HNN09_BJRJ_CSSID)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_BJRJ_ID",m.HNN09_BJRJ_ID),
                  new SqlParameter("@HNN09_BJRJ_JSID",m.HNN09_BJRJ_JSID),
                  new SqlParameter("@HNN09_BJRJ_CSSID",m.HNN09_BJRJ_CSSID)
               };

                dp.ExeNonQuery(sql, param);
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        /// <summary>
        /// 教师学科修改
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public string Add(RJXK_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into HNN09_RJXK(HNN09_RJXK_ID,HNN09_RJXK_JSID,HNN09_RJXK_XKID) values(@HNN09_RJXK_ID,@HNN09_RJXK_JSID,@HNN09_RJXK_XKID)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@HNN09_RJXK_ID",m.HNN09_RJXK_ID),
                  new SqlParameter("@HNN09_RJXK_JSID",m.HNN09_RJXK_JSID),
                  new SqlParameter("@HNN09_RJXK_XKID",m.HNN09_RJXK_XKID)
               };

                dp.ExeNonQuery(sql, param);
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
    /// <summary>
    /// 添加方法
    /// </summary>
    /// <param name="m">教师实体</param>
    /// <param name="dp"></param>
    /// <returns></returns>
        public string Add(JS_Model m, SQL_DBHelp dp)
        {
            try
            {
                //参数化，效率高，防止SQL注入
                string sql = "insert into hnn09_js(hnn09_js_id,hnn09_js_no,hnn09_js_pwd,hnn09_js_name,hnn09_js_sex,hnn09_js_zw,hnn09_js_zc,hnn09_js_sj) values(@hnn09_js_id,@hnn09_js_no,@hnn09_js_pwd,@hnn09_js_name,@hnn09_js_sex,@hnn09_js_zw,@hnn09_js_zc,@hnn09_js_sj)";
                SqlParameter[] param = new SqlParameter[]{ 
                  new SqlParameter("@hnn09_js_id",m.hnn09_js_id),
                  new SqlParameter("@hnn09_js_no",m.hnn09_js_no),
                  new SqlParameter("@hnn09_js_pwd",m.hnn09_js_pwd),
                  new SqlParameter("@hnn09_js_name",m.hnn09_js_name),
                  new SqlParameter("@hnn09_js_sex",m.hnn09_js_sex),
                  new SqlParameter("@hnn09_js_zw",m.hnn09_js_zw),
                  new SqlParameter("@hnn09_js_zc",m.hnn09_js_zc),
                  new SqlParameter("@hnn09_js_sj",m.hnn09_js_sj)
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
        /// <summary>
        /// 教师授班
        /// </summary>
        /// <param name="JSID"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        //public DataTable list( string JSID, SQL_DBHelp dp)
        //{
        //    dp.Parames.Add(new DataSQLhelp("@HNN09_JS_ID", JSID));
        //    string sql = "select HNN09_CLSS_ID,HNN09_CLSS_NAME,HNN09_JS_ID,HNN09_JS_NAME,HNN09_BJRJ_JSID from HNN09_CLSS LEFT JOIN(select * from HNN09_JS LEFT join HNN09_BJRJ on HNN09_JS_ID=HNN09_BJRJ_JSID WHERE HNN09_JS_ID=@HNN09_JS_ID) as a on HNN09_CLSS_ID=HNN09_BJRJ_CSSID";
        //    //SQL_DBHelp dp = new SQL_DBHelp();
        //    DataTable dt = dp.GetList(sql);
        //    return dt;
        //}
        /// <summary>
        /// 教师授课
        /// </summary>
        /// <param name="sql">存储过程名称</param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public DataTable list(string SQL, SQL_DBHelp dp)
        {
            //dp.Parames.Add(new DataSQLhelp("@HNN09_JS_ID", JSID));
            //string sql = "P_RJXK";
            DataTable dt = dp.GetListProcedure(SQL);
            return dt;
        }
        /// <summary>
        /// 返回任教班级或任教科目
        /// </summary>
        /// <param name="V_name">视图</param>
        /// <param name="strWhere">查询条建</param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public DataTable list(string V_name, string strWhere,SQL_DBHelp dp)
        {
            string sql = "select * from " + V_name + " where 1=1 " + strWhere;
            return dp.GetList(sql);
        }
        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public JsonDataSource list(int pageIndex, int pageSize, string strWhere,SQL_DBHelp dp )
        {
            JsonDataSource jds = new JsonDataSource();
            string sql = "select * from(select *, row_number() over(order by hnn09_js_id desc)as rn from hnn09_js where 1=1 " + strWhere + " and hnn09_js_no!='admin') as a where rn between(" + pageIndex + "-1)*" + pageSize + "+1 and " + pageIndex * pageSize;
            //SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList(sql);
            jds.List = dt;
            jds.ListRecord = ListRecord(dp, strWhere);
            dp.CloseResource();
            return jds;
        }
    }
}
