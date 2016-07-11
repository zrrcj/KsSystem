using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace HNNDB09_DOME.COMMON
{
    public class mtojson
    {
        public string getjson(DataTable dt)
        {
            string json = "[";
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    json += "{";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        json += "\"" + dc.ColumnName + "\":\"" +HttpContext.Current.Server.HtmlEncode( dr[dc.ColumnName].ToString()) + "\",";
                    }
                    json = json.Substring(0, json.Length - 1);
                    json += "},";
                }
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";
            return json;
        }

    }
}
