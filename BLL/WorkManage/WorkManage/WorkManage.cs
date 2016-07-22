using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class WorkManage
    {
        /// <summary>
        /// 获取员工原职务和职称
        /// </summary>
        /// <param name="chengedStuff"></param>
        /// <returns></returns>
        private Entity.Stuff GetOldInfo(Entity.Stuff chengedStuff)
        {
            string sql = @"SELECT
                 [职务]
                ,[职称]
            FROM [dbo].[员工]
            WHERE [工号] = @stuffNum and [姓名] = @name";
            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",chengedStuff.stuffNum),
                                    new SqlParameter ("@name",chengedStuff.name)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            DataSet ds = sh.Search(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chengedStuff.job = ds.Tables[0].Rows[0]["职务"].ToString();
                chengedStuff.post = ds.Tables[0].Rows[0]["职称"].ToString();
            }
            else
            {
                chengedStuff = null;
            }
            return chengedStuff;
        }

        /// <summary>
        /// 提交更改职务申请
        /// </summary>
        /// <param name="newJob"></param>
        /// <param name="chengedStuff"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string ChangeJobSubmit(string newJob, Entity.Stuff chengedStuff, Entity.Stuff submitStuff)
        {
            chengedStuff = GetOldInfo(chengedStuff);
            if(chengedStuff == null)
            {
                return "员工不存在";
            }
            var time = System.DateTime.Now.ToString();
            string sql = @"INSERT INTO [dbo].[职务变动]
                ([工号]
                ,[姓名]
                ,[原职务]
                ,[现职务]
                ,[提审时间]
                ,[审核情况]
                ,[提审人员工号])
            VALUES
                (@stuffNum
                ,@name
                ,@oldJob
                ,@newJob
                ,@time
                ,@result
                ,@submitStuffNum)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@newJob",newJob),
                                    new SqlParameter ("@stuffNum",chengedStuff.stuffNum),
                                    new SqlParameter ("@name",chengedStuff.name),
                                    new SqlParameter ("@oldJob",chengedStuff.job),
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
        /// 提交更改职称申请
        /// </summary>
        /// <param name="newPost"></param>
        /// <param name="chengedStuff"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string ChangePostSubmit(string newPost, Entity.Stuff chengedStuff, Entity.Stuff submitStuff)
        {
            chengedStuff = GetOldInfo(chengedStuff);
            if (chengedStuff == null)
            {
                return "员工不存在";
            }
            var time = System.DateTime.Now.ToString();
            string sql = @"INSERT INTO [dbo].[职称变动]
                ([工号]
                ,[姓名]
                ,[原职称]
                ,[现职称]
                ,[提审时间]
                ,[审核情况]
                ,[提审人员工号])
            VALUES
                (@stuffNum
                ,@name
                ,@oldPost
                ,@newPost
                ,@time
                ,@result
                ,@submitStuffNum)";

            SqlParameter[] paras ={
                                    new SqlParameter ("@newPost",newPost),
                                    new SqlParameter ("@stuffNum",chengedStuff.stuffNum),
                                    new SqlParameter ("@name",chengedStuff.name),
                                    new SqlParameter ("@oldPost",chengedStuff.post),
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
        /// 查询职务变动信息
        /// </summary>
        /// <returns></returns>
        public Entity.WorkChangeItem[] GetJobChangeList(string type)
        {
            string sql;
            DataSet ds;
            int itemNum;
            if (string.Equals(type, "待审核"))
            {
                sql = @"SELECT [id]
                    ,[工号]
                    ,[姓名]
                    ,[原职务]
                    ,[现职务]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[职务变动]
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
                    ,[姓名]
                    ,[原职务]
                    ,[现职务]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[职务变动]
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
                Entity.WorkChangeItem[] workChangeItem = new Entity.WorkChangeItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    workChangeItem[i] = new Entity.WorkChangeItem();
                    workChangeItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    workChangeItem[i].stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    workChangeItem[i].name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    workChangeItem[i].oldJob = ds.Tables[0].Rows[i]["原职务"].ToString();
                    workChangeItem[i].newJob = ds.Tables[0].Rows[i]["现职务"].ToString();
                    workChangeItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    workChangeItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    workChangeItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    workChangeItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return workChangeItem;
            }
        }

        /// <summary>
        /// 查询职称变动信息
        /// </summary>
        /// <returns></returns>
        public Entity.WorkChangeItem[] GetPostChangeList(string type)
        {
            string sql;
            DataSet ds;
            int itemNum;
            if (string.Equals(type, "待审核"))
            {
                sql = @"SELECT [id]
                    ,[工号]
                    ,[姓名]
                    ,[原职称]
                    ,[现职称]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[职称变动]
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
                    ,[姓名]
                    ,[原职称]
                    ,[现职称]
                    ,[提审时间]
                    ,[审核时间]
                    ,[审核情况]
                    ,[提审人员工号]
                    ,[审核人员工号]
                FROM [dbo].[职称变动]
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
                Entity.WorkChangeItem[] workChangeItem = new Entity.WorkChangeItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    workChangeItem[i] = new Entity.WorkChangeItem();
                    workChangeItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    workChangeItem[i].stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    workChangeItem[i].name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    workChangeItem[i].oldPost = ds.Tables[0].Rows[i]["原职称"].ToString();
                    workChangeItem[i].newPost = ds.Tables[0].Rows[i]["现职称"].ToString();
                    workChangeItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    workChangeItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    workChangeItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    workChangeItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return workChangeItem;
            }
        }

        /// <summary>
        /// 查询特定id的职务变动信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.WorkChangeItem[] GetJobChangeById(string id)
        {
            string sql = @"SELECT [id]
                ,[工号]
                ,[姓名]
                ,[原职务]
                ,[现职务]
                ,[提审时间]
                ,[审核时间]
                ,[审核情况]
                ,[提审人员工号]
                ,[审核人员工号]
            FROM [dbo].[职务变动]
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
                Entity.WorkChangeItem[] workChangeItem = new Entity.WorkChangeItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    workChangeItem[i] = new Entity.WorkChangeItem();
                    workChangeItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    workChangeItem[i].stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    workChangeItem[i].name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    workChangeItem[i].oldJob = ds.Tables[0].Rows[i]["原职务"].ToString();
                    workChangeItem[i].newJob = ds.Tables[0].Rows[i]["现职务"].ToString();
                    workChangeItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    workChangeItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    workChangeItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    workChangeItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return workChangeItem;
            }
        }

        /// <summary>
        /// 查询特定id的职称变动信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.WorkChangeItem[] GetPostChangeById(string id)
        {
            string sql = @"SELECT [id]
                ,[工号]
                ,[姓名]
                ,[原职称]
                ,[现职称]
                ,[提审时间]
                ,[审核时间]
                ,[审核情况]
                ,[提审人员工号]
                ,[审核人员工号]
            FROM [dbo].[职称变动]
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
                Entity.WorkChangeItem[] workChangeItem = new Entity.WorkChangeItem[itemNum];
                for (int i = 0; i < itemNum; i++)
                {
                    workChangeItem[i] = new Entity.WorkChangeItem();
                    workChangeItem[i].id = ds.Tables[0].Rows[i]["id"].ToString();
                    workChangeItem[i].stuffNum = ds.Tables[0].Rows[i]["工号"].ToString();
                    workChangeItem[i].name = ds.Tables[0].Rows[i]["姓名"].ToString();
                    workChangeItem[i].oldPost = ds.Tables[0].Rows[i]["原职称"].ToString();
                    workChangeItem[i].newPost = ds.Tables[0].Rows[i]["现职称"].ToString();
                    workChangeItem[i].submitTime = ds.Tables[0].Rows[i]["提审时间"].ToString();
                    workChangeItem[i].submitStuffNum = ds.Tables[0].Rows[i]["提审人员工号"].ToString();
                    workChangeItem[i].checkTime = ds.Tables[0].Rows[i]["审核时间"].ToString();
                    workChangeItem[i].checkStuffNum = ds.Tables[0].Rows[i]["审核人员工号"].ToString();
                }
                return workChangeItem;
            }
        }

        /// <summary>
        /// 审核职务变动
        /// </summary>
        /// <param name="result"></param>
        /// <param name="id"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string CheckJobChange(string result, string id, Entity.Stuff submitStuff)
        {
            var time = System.DateTime.Now.ToString();
            var workChangeItem = GetJobChangeById(id);
            string sql = @"UPDATE [dbo].[职务变动]
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
                    jobChange(workChangeItem[0]);
                }
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

        /// <summary>
        /// 审核职称变动
        /// </summary>
        /// <param name="result"></param>
        /// <param name="id"></param>
        /// <param name="submitStuff"></param>
        /// <returns></returns>
        public string CheckPostChange(string result, string id, Entity.Stuff submitStuff)
        {
            var time = System.DateTime.Now.ToString();
            var workChangeItem = GetPostChangeById(id);
            string sql = @"UPDATE [dbo].[职称变动]
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
                    postChange(workChangeItem[0]);
                }
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }

        /// <summary>
        /// 新职务写入数据库
        /// </summary>
        /// <param name="workChangeItem"></param>
        public void jobChange(Entity.WorkChangeItem workChangeItem)
        {
            var time = System.DateTime.Now.ToString();
            string sql = @"UPDATE [dbo].[员工]
            SET 
                 [职务] = @job
            WHERE [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",workChangeItem.stuffNum),
                                    new SqlParameter ("@job",workChangeItem.newJob)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
        }

        /// <summary>
        /// 新职称写入数据库
        /// </summary>
        /// <param name="workChangeItem"></param>
        public void postChange(Entity.WorkChangeItem workChangeItem)
        {
            var time = System.DateTime.Now.ToString();
            string sql = @"UPDATE [dbo].[员工]
            SET 
                 [职称] = @post
            WHERE [工号] = @stuffNum";

            SqlParameter[] paras ={
                                    new SqlParameter ("@stuffNum",workChangeItem.stuffNum),
                                    new SqlParameter ("@post",workChangeItem.newPost)
                                 };
            DAL.SqlHelper sh = new DAL.SqlHelper();
            var res = sh.ExeSql(sql, paras);
        }
    }
}
