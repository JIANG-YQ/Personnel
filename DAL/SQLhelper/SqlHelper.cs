using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlHelper
    {
        /// <summary>
        /// 链接数据库
        /// </summary>
        /// <returns></returns>
        private SqlConnection Conn() 
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=.;Database=Personnel;Trusted_Connection=SSPI";
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 关闭数据库链接
        /// </summary>
        /// <param name="conn"></param>
        private void CloseConn(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataSet Search(string sql,SqlParameter[] paras)
        {
            SqlConnection conn = Conn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            CloseConn(conn);
            return ds;
        }

        public DataSet Search(string sql)
        {
            return Search(sql, null);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int ExeSql(string sql, SqlParameter[] paras)
        {
            SqlConnection conn = Conn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            int rtn = cmd.ExecuteNonQuery();
            CloseConn(conn);
            return rtn;
        }

        public int ExeSql(string sql)
        {
            return ExeSql(sql, null);
        }

    }
}
