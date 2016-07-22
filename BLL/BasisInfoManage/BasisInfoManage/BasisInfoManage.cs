using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BasisInfoManage
    {
        /// <summary>
        /// 查询员工基本信息
        /// </summary>
        /// <param name="stuff"></param>
        /// <returns></returns>
        public Entity.Stuff Search(Entity.Stuff stuff)
        {
            string sql = @"SELECT
                 [姓名]
                ,[工号]
                ,[在职情况]
                ,[部门]
                ,[学历]
                ,[技术类型]
                ,[职务]
                ,[职称]
            FROM [dbo].[员工]
            WHERE [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",stuff.stuffNum),
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                stuff.stuffNum = ds.Tables[0].Rows[0]["工号"].ToString();
                stuff.name = ds.Tables[0].Rows[0]["姓名"].ToString();
                stuff.ifOnTheJob = ds.Tables[0].Rows[0]["在职情况"].ToString();
                stuff.education = ds.Tables[0].Rows[0]["学历"].ToString();
                stuff.job = ds.Tables[0].Rows[0]["职务"].ToString();
                stuff.post = ds.Tables[0].Rows[0]["职称"].ToString();
                stuff.skill = ds.Tables[0].Rows[0]["技术类型"].ToString();
                stuff.department = ds.Tables[0].Rows[0]["部门"].ToString();
            }
            else
            {
                stuff = null;
            }
            return stuff;
        }
    }
}
