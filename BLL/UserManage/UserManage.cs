using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class UserManage
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Entity.User Login(Entity.User user)
        {
            string sql = @"SELECT 
               [姓名]
              ,[权限]
            FROM [dbo].[员工] where [工号]=@stuffNum and [密码]=@pwd and [在职情况] = '在职'";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",user.stuffNum),
                                    new SqlParameter ("@pwd",user.pwd)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.name = ds.Tables[0].Rows[0]["姓名"].ToString();
                user.power = ds.Tables[0].Rows[0]["权限"].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ChangePwd(string newPwd, Entity.User user)
        {
            string sql = @"UPDATE [dbo].[员工]
            SET [密码] = @newPwd
            WHERE [工号] = @stuffNum and [密码] = @oldPwd";

            SqlParameter[] paras ={
                                    new SqlParameter ("@newPwd",newPwd),
                                    new SqlParameter ("@stuffNum",user.stuffNum),
                                    new SqlParameter ("@oldPwd",user.pwd)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if(res > 0)
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string AddUser(Entity.User user)
        {
            string sql = @"INSERT INTO [dbo].[员工]
                ([姓名]
                ,[工号]
                ,[密码]
                ,[权限]
                ,[在职情况])
            VALUES
                (@name
                ,@stuffNum
                ,@pwd
                ,@power
                ,@ifOnTheJob)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@name",user.name),
                                    new SqlParameter ("@stuffNum",user.stuffNum),
                                    new SqlParameter ("@pwd","1234"),
                                    new SqlParameter ("@power",user.power),
                                    new SqlParameter ("@ifOnTheJob","在职")
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                return "增加成功";
            }
            else
            {
                return "增加失败";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string DelUser(Entity.User user)
        {
            string sql = @"DELETE FROM [dbo].[员工]
            WHERE [姓名] = @name and [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@name",user.name),
                                    new SqlParameter ("@stuffNum",user.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }

        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Entity.User SearchPower(Entity.User user)
        {
            string sql = @"SELECT 
                 [权限]
            FROM [dbo].[员工]
            WHERE [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",user.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.power = ds.Tables[0].Rows[0]["权限"].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }

        /// <summary>
        /// 更改用户权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ChangePower(Entity.User user)
        {
            string sql = @"UPDATE [dbo].[员工]
            SET 
                 [权限] = @power
            WHERE [工号] = @stuffNum and [姓名] = @name";

            SqlParameter[] paras ={
                                    new SqlParameter ("@name",user.name),
                                    new SqlParameter ("@stuffNum",user.stuffNum),
                                    new SqlParameter ("@power",user.power)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                return "更改成功";
            }
            else
            {
                return "更改失败";
            }
        }
    }
}
