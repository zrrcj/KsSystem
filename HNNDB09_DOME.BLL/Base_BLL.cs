using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNNDB09_DOME.DAL;
using HNNDB09_DOME.COMMON;
using System.Data;

namespace HNNDB09_DOME.BLL
{
    public class Base_BLL
    {
        /// <summary>
        /// 教师更新密码
        /// </summary>
        /// <param name="m">教师实体</param>
        /// <returns></returns>
        public bool update(JS_Model m)
        {
            if (new Base_DAL().updata(m) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool update(QX_Model m)
        {
            if (new Base_DAL().updata(m) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool add(int qxid)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            Base_DAL dal = new Base_DAL();
            QX_Model m = new QX_Model();
            m.HNN09_QX_ID = dp.GetSequnce("hnn09_qx", "hnn09_qx_id"); ;
            m.HNN09_QX_JSID = qxid;
            m.HNN09_QX_QX = "00001";
           return dal.add(m, dp);
        }
        public QX_Model List( string strWhere)
        {
            SQL_DBHelp dp=new SQL_DBHelp ();
            Base_DAL dal = new Base_DAL();
            QX_Model m = new QX_Model();
            DataTable dt= dal.list( strWhere, dp);
            if (dal!=null)
            {
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        m.HNN09_QX_ID =Convert.ToInt32( dr["HNN09_QX_ID"]);
                        m.HNN09_QX_JSID = Convert.ToInt32(dr["HNN09_QX_JSID"]);
                        m.HNN09_QX_QX = dr["HNN09_QX_QX"].ToString();
                    }
                }
            }
            return m;
        }

    }
}