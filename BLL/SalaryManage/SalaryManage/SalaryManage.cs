using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class SalaryManage
    {
        /// <summary>
        /// 验证是否存在员工
        /// </summary>
        /// <param name="stuff"></param>
        /// <returns></returns>
        private Entity.Stuff CheckStuff(Entity.Stuff stuff)
        {
            string sql = @"SELECT
                 [工号]
            FROM [dbo].[员工]
            WHERE [工号] = @stuffNum and [姓名] = @name";
            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",stuff.stuffNum),
                                    new SqlParameter ("@name",stuff.name)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            if (ds.Tables[0].Rows.Count == 0)
            {
                stuff = null;
            }
            return stuff;
        }

        /// <summary>
        /// 查询工资
        /// </summary>
        /// <param name="stuff"></param>
        /// <returns></returns>
        public Entity.Salary Search(Entity.Stuff stuff)
        {
            stuff = CheckStuff(stuff);
            if (stuff == null)
            {
                return null;
            }
            string sql = @"SELECT TOP 1
                 [工号]
                ,[姓名]
                ,[日期]
                ,[基本工资]
                ,[当月奖金]
                ,[部门津贴]
                ,[临时津贴]
                ,[个人所得税]
                ,[实际工资]
            FROM [dbo].[工资结算]
            WHERE [工号] = @stuffNum
            ORDER BY [日期] DESC";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",stuff.stuffNum),
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            Entity.Salary salary = new Entity.Salary();
            if (ds.Tables[0].Rows.Count > 0)
            {
                salary.stuffNum = ds.Tables[0].Rows[0]["工号"].ToString();
                salary.name = ds.Tables[0].Rows[0]["姓名"].ToString();
                salary.time = ds.Tables[0].Rows[0]["日期"].ToString();
                salary.basisSalary = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["基本工资"].ToString());
                salary.prize = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["当月奖金"].ToString());
                salary.depAllowance = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["部门津贴"].ToString());
                salary.tmpAllowance = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["临时津贴"].ToString());
                salary.tax = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["个人所得税"].ToString());
            }
            else
            {
                salary = null;
            }
            return salary;
        }

        /// <summary>
        /// 更改工资
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public string Change(Entity.Salary salary)
        {
            var time = System.DateTime.Now.ToString();
            string sql = @"INSERT INTO [dbo].[工资结算]
                ([工号]
                ,[姓名]
                ,[日期]
                ,[基本工资]
                ,[当月奖金]
                ,[部门津贴]
                ,[临时津贴]
                ,[个人所得税]
                ,[实际工资])
            VALUES
                (@stuffNum
                ,@name
                ,@time
                ,@basisSalary
                ,@prize
                ,@depAllowance
                ,@tmpAllowance
                ,@tax
                ,@trueSalary)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",salary.stuffNum),
                                    new SqlParameter ("@name",salary.name),
                                    new SqlParameter ("@basisSalary",salary.basisSalary),
                                    new SqlParameter ("@prize",salary.prize),
                                    new SqlParameter ("@depAllowance",salary.depAllowance),
                                    new SqlParameter ("@tmpAllowance",salary.tmpAllowance),
                                    new SqlParameter ("@time",time),
                                    new SqlParameter ("@tax",salary.tax),
                                    new SqlParameter ("@trueSalary",salary.trueSalary)
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
