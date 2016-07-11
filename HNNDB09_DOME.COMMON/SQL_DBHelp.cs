using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace HNNDB09_DOME.COMMON
{
    public class SQL_DBHelp
    {
        //数据库连接字符串
        private string ConnStr = string.Empty;

        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        public List<DataSQLhelp> Parames = new List<DataSQLhelp>();
        private SqlTransaction trans = null;
        //利用构造初始化全局变量
        public SQL_DBHelp()
        { //第一步：编写或获取数据库连接字符串
            ConnStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            //ConfigurationManager.AppSettings["ConnectonString"];//"server=.\\sqlexpress;database=students1403;uid=sa;pwd=sa;";
            //第二步;根据连接字符串创建连接对象
            conn = new SqlConnection(ConnStr);
            //第三步：判断连接对象是否打开，若关闭则打开
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //第四步：根据连接对象创建命令对象并执行命令
            //string sql = "select * from dd_student";
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        //返回表或视图数据
        public DataTable GetList(string sql)
        {
            cmd.CommandText = sql;
            foreach (DataSQLhelp  prarme in Parames )
            {
                SqlParameter sp = new SqlParameter(prarme.ParameName, prarme.ParameVale);
                cmd.Parameters.Add(sp);
            }
            //第五步：声明数据适配器和容器
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //第六步：使用适配器填充容器
            sda.Fill(dt);
            cmd.Parameters.Clear();
            //第七步：关闭连接   <若用DataReader,则不能关闭>
            //conn.Close();
            return dt;
        }
        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="procedure">存储过程名称</param>
        /// <returns></returns>
        public DataTable GetListProcedure(string procedure)
        {
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            foreach (DataSQLhelp prarme in Parames)
            {
                SqlParameter sp = new SqlParameter(prarme.ParameName, prarme.ParameVale);
                cmd.Parameters.Add(sp);
            }
            //第五步：声明数据适配器和容器
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //第六步：使用适配器填充容器
            sda.Fill(dt);
            //第七步：关闭连接   <若用DataReader,则不能关闭>
            //conn.Close();
            return dt;
        }
        /// <summary>
        ///根据ID删除
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="IdName">主键名</param>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public int deleID(string tableName, string IdName, string id)
        {
            string sql = "DELETE FROM " + tableName + " WHERE " + IdName + " in(" + id + ")";
            return Convert.ToInt32(ExeNonQuery(sql));
        }
        /// <summary>
        /// 返回一张表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetList(string tableName, string strWhere, string sql)
        {
            cmd.CommandText = sql;
            //第五步：声明数据适配器和容器
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //第六步：使用适配器填充容器
            sda.Fill(dt);
            cmd.Parameters.Clear();
            //第七步：关闭连接   <若用DataReader,则不能关闭>
            //conn.Close();
            return dt;
        }
        /// <summary>
        /// 返回首行首列数据（单元格的值）已废弃
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public object ExeScalar(string tableName, string strWhere)
        {
            string sql = "select * from " + tableName + " where hnn09_js_id=" + strWhere;
            object obj = cmd.ExecuteScalar();
            //第七步：关闭连接
            //conn.Close();
            return obj;
        }
        /// <summary>
        /// 简单的 SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExeScalar(string sql)
        {
            //string sql = "select * from " + tableName + " where hnn09_js_id=" + strWhere;
            cmd.CommandText = sql;
            foreach (DataSQLhelp prarme in Parames)
            {
                SqlParameter sp = new SqlParameter(prarme.ParameName, prarme.ParameVale);
                cmd.Parameters.Add(sp);
            }
            object obj = cmd.ExecuteScalar();
            //第七步：关闭连接
            //conn.Close();
            return obj;
        }
        /// <summary>
        /// 获取下一条记录的ID
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkid">主键</param>
        /// <returns></returns>
        public int GetSequnce(string tableName, string pkid)
        {
            string sql = "select ISNULL(max(" + pkid + "),0)+1from " + tableName; 
            return Convert.ToInt32(ExeScalar(sql));
        }
        /// <summary>
        /// 简单的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExeNonQuery(string sql)
        {
            cmd.CommandText = sql;
            int obj = cmd.ExecuteNonQuery();
            //第七步：关闭连接
            //conn.Close();
            return obj;
        }
        /// <summary>
        /// 开启事务
        /// </summary>
        public void KqTransa()
        {
            trans = conn.BeginTransaction();
            cmd.Transaction = trans;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void TjTransa()
        {
            trans.Commit();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void HgTransa()
        {
            trans.Rollback();
        }
        /// <summary>
        /// 参数化执行增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public int ExeNonQuery(string sql, SqlParameter[] param)
        {
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(param);
            int obj = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return obj;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseResource()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}