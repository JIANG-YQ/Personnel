using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class StuffManage
    {
        /// <summary>
        /// 提交员工录入申请
        /// </summary>
        /// <param name="entryStuff"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string EntrySubmit(Entity.Stuff entryStuff, Entity.Stuff submitStuff)
        {
            var time = System.DateTime.Now.ToString();
            string sql = @"INSERT INTO [dbo].[人员增加]
                ([工号]
                ,[部门]
                ,[职务]
                ,[职称]
                ,[姓名]
                ,[学历]
                ,[技术类型]
                ,[提审时间]
                ,[审核情况]
                ,[提审人员工号])
            VALUES
                (@stuffNum
                ,@department
                ,@job
                ,@post
                ,@name
                ,@education
                ,@skill
                ,@time
                ,@result
                ,@submitStuffNum)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",entryStuff.stuffNum),
                                    new SqlParameter ("@name",entryStuff.name),
                                    new SqlParameter ("@department",entryStuff.department),
                                    new SqlParameter ("@education",entryStuff.education),
                                    new SqlParameter ("@skill",entryStuff.skill),
                                    new SqlParameter ("@job",entryStuff.job),
                                    new SqlParameter ("@post",entryStuff.post),
                                    new SqlParameter ("@time",time),
                                    new SqlParameter ("@result","待审核"),
                                    new SqlParameter ("@submitStuffNum",submitStuff.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

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
        /// 提交员工离职申请
        /// </summary>
        /// <param name="reson"></param>
        /// <param name="leaveStuff"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string LeaveSubmit(string reson, Entity.Stuff leaveStuff, Entity.Stuff submitStuff)
        {
            leaveStuff = CheckStuff(leaveStuff);
            if(leaveStuff == null)
            {
                return "员工不存在";
            }
            var time = System.DateTime.Now.ToString();
            string sql = @"INSERT INTO [dbo].[人员减少]
                ([工号]
                ,[姓名]
                ,[原因]
                ,[提审时间]
                ,[审核情况]
                ,[提审人员工号])
            VALUES
                (@stuffNum
                ,@name
                ,@reson
                ,@time
                ,@result
                ,@submitStuffNum)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",leaveStuff.stuffNum),
                                    new SqlParameter ("@name",leaveStuff.name),
                                    new SqlParameter ("@reson",reson),
                                    new SqlParameter ("@time",time),
                                    new SqlParameter ("@result","待审核"),
                                    new SqlParameter ("@submitStuffNum",submitStuff.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

        /// <summary>
        /// 查询录入员工信息
        /// </summary>
        /// <returns></returns>
        public Entity.StuffListItem[] GetEntryStuffList(string type)
        {
            string sql;
            DataSet ds;
            int itemNum;
            if(string.Equals(type, "待审核"))
            {
                sql = @"SELECT
                     [id]
                    ,[工号]
                    ,[部门]
                    ,[职务]
                    ,[职称]
                    ,[姓名]
                    ,[学历]
                    ,[技术类型]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[人员增加]
                WHERE [审核情况] = '待审核'";

                DAL.SqlHelper sh = new DAL.SqlHelper();
                ds = sh.Search(sql);
                itemNum = ds.Tables[0].Rows.Count;
            }

            else
            {
                sql = @"SELECT TOP 5
                     [id]
                    ,[工号]
                    ,[部门]
                    ,[职务]
                    ,[职称]
                    ,[姓名]
                    ,[学历]
                    ,[技术类型]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[人员增加]
                WHERE [审核情况] = '通过' or [审核情况] = '不通过'
                ORDER BY [审核时间] DESC";

                DAL.SqlHelper sh = new DAL.SqlHelper();
                ds = sh.Search(sql);
                itemNum = ds.Tables[0].Rows.Count;
            }
            if(itemNum == 0)
            {
                return null;
            }
            else
            {
                Entity.StuffListItem[] stuffListItem = new Entity.StuffListItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    stuffListItem[i] = new Entity.StuffListItem();
                    stuffListItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    stuffListItem[i].stuff.stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    stuffListItem[i].stuff.name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    stuffListItem[i].stuff.department = ds.Tables[0].Rows[i]["部门"].ToString();
                    stuffListItem[i].stuff.job = ds.Tables[0].Rows[i]["职务"].ToString();
                    stuffListItem[i].stuff.post = ds.Tables[0].Rows[i]["职称"].ToString();
                    stuffListItem[i].stuff.education = ds.Tables[0].Rows[i]["学历"].ToString();
                    stuffListItem[i].stuff.skill = ds.Tables[0].Rows[i]["技术类型"].ToString();
                    stuffListItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    stuffListItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    stuffListItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    stuffListItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return stuffListItem;
            }
        }

        /// <summary>
        /// 查询特定id录入员工的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.StuffListItem[] GetEntryStuffById(string id)
        {
            string sql = @"SELECT
                 [id]
                ,[工号]
                ,[部门]
                ,[职务]
                ,[职称]
                ,[姓名]
                ,[学历]
                ,[技术类型]
                ,[提审时间]
                ,[审核时间]
                ,[审核情况]
                ,[提审人员工号]
                ,[审核人员工号]
            FROM [dbo].[人员增加]
            WHERE [id] = @id";

            SqlParameter[] paras ={
                                    new SqlParameter ("@id", id)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            var itemNum = ds.Tables[0].Rows.Count;
            if (itemNum == 0)
            {
                return null;
            }
            else
            {
                Entity.StuffListItem[] stuffListItem = new Entity.StuffListItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    stuffListItem[i] = new Entity.StuffListItem();
                    stuffListItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    stuffListItem[i].stuff.stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    stuffListItem[i].stuff.name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    stuffListItem[i].stuff.department = ds.Tables[0].Rows[i]["部门"].ToString();
                    stuffListItem[i].stuff.job = ds.Tables[0].Rows[i]["职务"].ToString();
                    stuffListItem[i].stuff.post = ds.Tables[0].Rows[i]["职称"].ToString();
                    stuffListItem[i].stuff.education = ds.Tables[0].Rows[i]["学历"].ToString();
                    stuffListItem[i].stuff.skill = ds.Tables[0].Rows[i]["技术类型"].ToString();
                    stuffListItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    stuffListItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    stuffListItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    stuffListItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return stuffListItem;
            }
        }

        /// <summary>
        /// 审核录入员工
        /// </summary>
        /// <param name="result"></param>
        /// <param name="id"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string CheckEntryStuff(string result, string id, Entity.Stuff submitStuff)
        {
            var time = System.DateTime.Now.ToString();
            var entryStuff = GetEntryStuffById(id);
            string sql = @"UPDATE [dbo].[人员增加]
            SET 
                 [审核时间] = @time
                ,[审核情况] = @result
                ,[审核人员工号] = @submitStuffNum
            WHERE [id] = @id";

            SqlParameter[] paras ={
                                    new SqlParameter ("@id",id),
                                    new SqlParameter ("@time",time),
                                    new SqlParameter ("@result",result),
                                    new SqlParameter ("@submitStuffNum",submitStuff.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                if (string.Equals(result, "通过"))
                {
                    EntryStuff(entryStuff[0].stuff);
                }
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

        /// <summary>
        /// 录入员工信息写入数据库
        /// </summary>
        /// <param name="entryStuff"></param>
        public void EntryStuff(Entity.Stuff entryStuff)
        {
            string sql = @"INSERT INTO [dbo].[员工]
                ([工号]
                ,[部门]
                ,[职务]
                ,[职称]
                ,[姓名]
                ,[学历]
                ,[技术类型]
                ,[在职情况]
                ,[权限]
                ,[密码])
            VALUES
                (@stuffNum
                ,@department
                ,@job
                ,@post
                ,@name
                ,@education
                ,@skill
                ,@ifOnTheJob
                ,@power
                ,@pwd)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",entryStuff.stuffNum),
                                    new SqlParameter ("@name",entryStuff.name),
                                    new SqlParameter ("@department",entryStuff.department),
                                    new SqlParameter ("@education",entryStuff.education),
                                    new SqlParameter ("@skill",entryStuff.skill),
                                    new SqlParameter ("@job",entryStuff.job),
                                    new SqlParameter ("@post",entryStuff.post),
                                    new SqlParameter ("@ifOnTheJob","在职"),
                                    new SqlParameter ("@power","普通用户"),
                                    new SqlParameter ("@pwd","1234")
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
        }

        /// <summary>
        /// 查询离职人员信息
        /// </summary>
        /// <returns></returns>
        public Entity.StuffListItem[] GetLeaveStuffList(string type)
        {
            string sql;
            DataSet ds;
            int itemNum;
            if (string.Equals(type, "待审核"))
            {
                sql = @"SELECT [id]
                    ,[姓名]
                    ,[工号]
                    ,[原因]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[人员减少]
                WHERE [审核情况] = '待审核'";

                DAL.SqlHelper sh = new DAL.SqlHelper();
                ds = sh.Search(sql);
                itemNum = ds.Tables[0].Rows.Count;
            }
            else
            {
                sql = @"SELECT [id]
                    ,[姓名]
                    ,[工号]
                    ,[原因]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[人员减少]
                WHERE [审核情况] = '通过' or [审核情况] = '不通过'
                ORDER BY [审核时间] DESC";

                DAL.SqlHelper sh = new DAL.SqlHelper();
                ds = sh.Search(sql);
                itemNum = ds.Tables[0].Rows.Count;
            }          
            if (itemNum == 0)
            {
                return null;
            }
            else
            {
                Entity.StuffListItem[] stuffListItem = new Entity.StuffListItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    stuffListItem[i] = new Entity.StuffListItem();
                    stuffListItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    stuffListItem[i].stuff.stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    stuffListItem[i].stuff.name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    stuffListItem[i].leaveReason = ds.Tables[0].Rows[i]["原因"].ToString();
                    stuffListItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    stuffListItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    stuffListItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    stuffListItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return stuffListItem;
            }
        }

        /// <summary>
        /// 查询特定id离职员工的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.StuffListItem[] GetLeaveStuffById(string id)
        {
            string sql = @"SELECT [id]
                ,[姓名]
                ,[工号]
                ,[原因]
                ,[提审时间]
                ,[审核时间]
                ,[审核情况]
                ,[提审人员工号]
                ,[审核人员工号]
            FROM [dbo].[人员减少]
            WHERE [id] = @id";

            SqlParameter[] paras ={
                                    new SqlParameter ("@id", id)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            var itemNum = ds.Tables[0].Rows.Count;
            if (itemNum == 0)
            {
                return null;
            }
            else
            {
                Entity.StuffListItem[] stuffListItem = new Entity.StuffListItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    stuffListItem[i] = new Entity.StuffListItem();
                    stuffListItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    stuffListItem[i].stuff.stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    stuffListItem[i].stuff.name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    stuffListItem[i].leaveReason = ds.Tables[0].Rows[i]["原因"].ToString();
                    stuffListItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    stuffListItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    stuffListItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    stuffListItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return stuffListItem;
            }
        }

        /// <summary>
        /// 审核离职员工
        /// </summary>
        /// <param name="result"></param>
        /// <param name="id"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string CheckLeaveStuff(string result, string id, Entity.Stuff submitStuff)
        {
            var time = System.DateTime.Now.ToString();
            var leaveStuff = GetLeaveStuffById(id);
            string sql = @"UPDATE [dbo].[人员减少]
            SET 
                 [审核时间] = @time
                ,[审核情况] = @result
                ,[审核人员工号] = @submitStuffNum
            WHERE [id] = @id";

            SqlParameter[] paras ={
                                    new SqlParameter ("@id",id),
                                    new SqlParameter ("@time",time),
                                    new SqlParameter ("@result",result),
                                    new SqlParameter ("@submitStuffNum",submitStuff.stuffNum)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
            if (res > 0)
            {
                if (string.Equals(result, "通过"))
                {
                    LeaveStuff(leaveStuff[0].stuff);
                }
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

        /// <summary>
        /// 将员工离职
        /// </summary>
        /// <param name="entryStuff"></param>
        public void LeaveStuff(Entity.Stuff entryStuff)
        {
            string sql = @"UPDATE [dbo].[员工]
            SET 
                 [在职情况] = @ifOnTheJob
            WHERE [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",entryStuff.stuffNum),
                                    new SqlParameter ("@ifOnTheJob","离职")
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
        }
    }
}
