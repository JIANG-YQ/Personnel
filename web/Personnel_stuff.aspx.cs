using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_Personnel_stuff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserInfo();
        GetNoticeList();
    }

    protected void GetNoticeList()
    {
        BLL.StuffManage sm = new BLL.StuffManage();
        BLL.WorkManage wm = new BLL.WorkManage();
        Entity.StuffListItem[] stuffEntryList = sm.GetEntryStuffList("已审核");
        Entity.StuffListItem[] stuffLeaveList = sm.GetLeaveStuffList("已审核");
        Entity.WorkChangeItem[] jobChagneList = wm.GetJobChangeList("已审核");
        Entity.WorkChangeItem[] postChangeList = wm.GetPostChangeList("已审核");

        jobChangeNoticeItem1.InnerText = "员工 " + jobChagneList[0].name + "（工号：" + jobChagneList[0].stuffNum + "），职务从 " + jobChagneList[0].oldJob + " 变更为 " + jobChagneList[0].newJob;
        jobChangeNoticeItem2.InnerText = "员工 " + jobChagneList[1].name + "（工号：" + jobChagneList[1].stuffNum + "），职务从 " + jobChagneList[1].oldJob + " 变更为 " + jobChagneList[1].newJob;
        jobChangeNoticeItem3.InnerText = "员工 " + jobChagneList[2].name + "（工号：" + jobChagneList[2].stuffNum + "），职务从 " + jobChagneList[2].oldJob + " 变更为 " + jobChagneList[2].newJob;
        jobChangeNoticeItem4.InnerText = "员工 " + jobChagneList[3].name + "（工号：" + jobChagneList[3].stuffNum + "），职务从 " + jobChagneList[3].oldJob + " 变更为 " + jobChagneList[3].newJob;
        jobChangeNoticeItem5.InnerText = "员工 " + jobChagneList[4].name + "（工号：" + jobChagneList[4].stuffNum + "），职务从 " + jobChagneList[4].oldJob + " 变更为 " + jobChagneList[4].newJob;

        postChangeNoticeItem1.InnerText = "员工 " + postChangeList[0].name + "（工号：" + postChangeList[0].stuffNum + "），职称从 " + postChangeList[0].oldPost + " 变更为 " + postChangeList[0].newPost;
        postChangeNoticeItem2.InnerText = "员工 " + postChangeList[1].name + "（工号：" + postChangeList[1].stuffNum + "），职称从 " + postChangeList[1].oldPost + " 变更为 " + postChangeList[1].newPost;
        postChangeNoticeItem3.InnerText = "员工 " + postChangeList[2].name + "（工号：" + postChangeList[2].stuffNum + "），职称从 " + postChangeList[2].oldPost + " 变更为 " + postChangeList[2].newPost;
        postChangeNoticeItem4.InnerText = "员工 " + postChangeList[3].name + "（工号：" + postChangeList[3].stuffNum + "），职称从 " + postChangeList[3].oldPost + " 变更为 " + postChangeList[3].newPost;
        postChangeNoticeItem5.InnerText = "员工 " + postChangeList[4].name + "（工号：" + postChangeList[4].stuffNum + "），职称从 " + postChangeList[4].oldPost + " 变更为 " + postChangeList[4].newPost;

        stuffEntryNoticeItem1.InnerText = "录入" + stuffEntryList[0].stuff.department + "（部门）员工 " + stuffEntryList[0].stuff.name + "（工号：" + stuffEntryList[0].stuff.stuffNum + "）";
        stuffEntryNoticeItem2.InnerText = "录入" + stuffEntryList[1].stuff.department + "（部门）员工 " + stuffEntryList[1].stuff.name + "（工号：" + stuffEntryList[1].stuff.stuffNum + "）";
        stuffEntryNoticeItem3.InnerText = "录入" + stuffEntryList[2].stuff.department + "（部门）员工 " + stuffEntryList[2].stuff.name + "（工号：" + stuffEntryList[2].stuff.stuffNum + "）";
        stuffEntryNoticeItem4.InnerText = "录入" + stuffEntryList[3].stuff.department + "（部门）员工 " + stuffEntryList[3].stuff.name + "（工号：" + stuffEntryList[3].stuff.stuffNum + "）";
        stuffEntryNoticeItem5.InnerText = "录入" + stuffEntryList[4].stuff.department + "（部门）员工 " + stuffEntryList[4].stuff.name + "（工号：" + stuffEntryList[4].stuff.stuffNum + "）";

        stuffLeaveNoticeItem1.InnerText = stuffLeaveList[0].stuff.department + "员工 " + stuffLeaveList[0].stuff.name + "（工号：" + stuffLeaveList[0].stuff.stuffNum + "）离职";
        stuffLeaveNoticeItem2.InnerText = stuffLeaveList[1].stuff.department + "员工 " + stuffLeaveList[1].stuff.name + "（工号：" + stuffLeaveList[1].stuff.stuffNum + "）离职";
        stuffLeaveNoticeItem3.InnerText = stuffLeaveList[2].stuff.department + "员工 " + stuffLeaveList[2].stuff.name + "（工号：" + stuffLeaveList[2].stuff.stuffNum + "）离职";
        stuffLeaveNoticeItem4.InnerText = stuffLeaveList[3].stuff.department + "员工 " + stuffLeaveList[3].stuff.name + "（工号：" + stuffLeaveList[3].stuff.stuffNum + "）离职";
        stuffLeaveNoticeItem5.InnerText = stuffLeaveList[4].stuff.department + "员工 " + stuffLeaveList[4].stuff.name + "（工号：" + stuffLeaveList[4].stuff.stuffNum + "）离职";
    }

    protected void ChangePwd(object sender, EventArgs e)
    {
        var oldPwd = txtOldPwd.Value;
        var newPwd = txtNewPwd.Value;
        BLL.UserManage um = new BLL.UserManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.User user = (Entity.User)Session[labStuffNum.InnerText];
            user.pwd = oldPwd;
            var res = um.ChangePwd(newPwd, user);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            txtOldPwd.Value = "";
            txtNewPwd.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void StuffEntry(object sender, EventArgs e)
    {
        BLL.StuffManage sm = new BLL.StuffManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff entryStuff = new Entity.Stuff();
            entryStuff.stuffNum = txtStuffNumForEntry.Value;
            entryStuff.name = txtName.Value;
            entryStuff.job = txtJob.Value;
            entryStuff.post = txtPost.Value;
            entryStuff.education = txtEducation.Value;
            entryStuff.department = txtDepartment.Value;
            entryStuff.skill = txtSkill.Value;
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = sm.EntrySubmit(entryStuff, submitStuff);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            txtStuffNumForEntry.Value = "";
            txtName.Value = "";
            txtJob.Value = "";
            txtPost.Value = "";
            txtEducation.Value = "";
            txtDepartment.Value = "";
            txtSkill.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void StuffLeave(object sender, EventArgs e)
    {
        BLL.StuffManage sm = new BLL.StuffManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff leaveStuff = new Entity.Stuff();
            leaveStuff.stuffNum = txtStuffNumForLeave.Value;
            leaveStuff.name = txtNameForLeave.Value;
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = sm.LeaveSubmit(txtLeaveReason.Value, leaveStuff, submitStuff);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            txtStuffNumForLeave.Value = "";
            txtNameForLeave.Value = "";
            txtLeaveReason.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void SearchBasisInfo(object sender, EventArgs e)
    {
        BLL.BasisInfoManage bm = new BLL.BasisInfoManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff stuff = new Entity.Stuff();
            stuff.stuffNum = stuffNumForBasisInfo.Value;
            stuff = bm.Search(stuff);
            if (stuff != null)
            {
                labStuffNumInBasisInfo.Text = stuff.stuffNum;
                labNameInBasisInfo.InnerText = stuff.name;
                labDepartmentInBasisInfo.InnerText = stuff.department;
                labEducationInBasisInfo.InnerText = stuff.education;
                labJobInBasisInfo.InnerText = stuff.job;
                labPostInBasisInfo.InnerText = stuff.post;
                labSkillInBasisInfo.InnerText = stuff.skill;
                labIfOnTheJobBasisInfo.InnerText = stuff.ifOnTheJob;
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('查询失败');", true);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    private void GetUserInfo()
    {
        string stuffNum = Request.QueryString["stuffNum"];
        if (Session[stuffNum] != null)
        {
            Entity.User user = (Entity.User)Session[stuffNum];
            labUserName.InnerText = user.name;
            labStuffNum.InnerText = user.stuffNum;
        }
    }

    protected void ChangeJob(object sender, EventArgs e)
    {
        BLL.WorkManage wm = new BLL.WorkManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff ChangedStuff = new Entity.Stuff();
            ChangedStuff.stuffNum = changeJobStuffNum.Value;
            ChangedStuff.name = changeJobName.Value;
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = wm.ChangeJobSubmit(newJob.Value, ChangedStuff, submitStuff);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            changeJobStuffNum.Value = "";
            changeJobName.Value = "";
            newJob.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void ChangePost(object sender, EventArgs e)
    {
        BLL.WorkManage wm = new BLL.WorkManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff ChangedStuff = new Entity.Stuff();
            ChangedStuff.stuffNum = changePostStuffNum.Value;
            ChangedStuff.name = changePostName.Value;
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = wm.ChangePostSubmit(newPost.Value, ChangedStuff, submitStuff);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            changePostStuffNum.Value = "";
            changePostName.Value = "";
            newPost.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void ChangeSalary(object sender, EventArgs e)
    {
        BLL.SalaryManage sm = new BLL.SalaryManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Salary salary = new Entity.Salary();
            salary.stuffNum = stuffNumInChangeSalary.Value;
            salary.name = nameInChangeSalary.Value;
            salary.basisSalary = (float)Convert.ToDouble(basisSalaryInChangeSalary.Value);
            salary.depAllowance = (float)Convert.ToDouble(depAllowanceInChangeSalary.Value);
            salary.tmpAllowance = (float)Convert.ToDouble(tmpAllowanceInChangeSalary.Value);
            salary.prize = (float)Convert.ToDouble(prizeInChangeSalary.Value);
            salary.tax = (float)Convert.ToDouble(taxInChangeSalary.Value);
            var res = sm.Change(salary);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
            stuffNumInChangeSalary.Value = "";
            nameInChangeSalary.Value = "";
            basisSalaryInChangeSalary.Value = "";
            depAllowanceInChangeSalary.Value = "";
            tmpAllowanceInChangeSalary.Value = "";
            prizeInChangeSalary.Value = "";
            taxInChangeSalary.Value = "";
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void SearchSalary(object sender, EventArgs e)
    {
        BLL.SalaryManage sm = new BLL.SalaryManage();
        if (Session[labStuffNum.InnerText] != null)
        {
            Entity.Stuff stuff = new Entity.Stuff();
            stuff.stuffNum = stuffNumInSearchSalary.Value;
            var salary = sm.Search(stuff);
            if (salary != null)
            {
                labStuffNumInSearchSalary.Text = salary.stuffNum;
                labNameInSearchSDalary.InnerText = salary.name;
                labBasisSalaryInSearchSalary.InnerText = salary.basisSalary.ToString();
                labDepAllowanceInSearchSalary.InnerText = salary.depAllowance.ToString();
                labTmpAllowanceInSearchSalary.InnerText = salary.tmpAllowance.ToString();
                labPrizeInSearchSalary.InnerText = salary.prize.ToString();
                labTaxInSearchSalary.InnerText = salary.tax.ToString();
                labTrueSalaryInSearchSalary.InnerText = salary.trueSalary.ToString();
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('员工不存在');", true);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}