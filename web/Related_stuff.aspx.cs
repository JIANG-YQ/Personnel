using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_Related_stuff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserInfo();
        GetNoticeList();
        RefreshEntryStuffList(null, null);
        RefreshLeaveStuffList(null, null);
        RefreshJobChangeList(null, null);
        RefreshPostChangeList(null, null);
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

    protected void RefreshEntryStuffList(object sender, EventArgs e)
    {
        btnBackEntryStuffList.Style["display"] = "none";
        if (Session[labStuffNum.InnerText] != null)
        {
            entryStuffList.Controls.Clear();
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.StuffListItem[] stuffListitem = sm.GetEntryStuffList("待审核");
            if (stuffListitem == null)
            {
                return;
            }
            for (int i = 0; i < stuffListitem.Length; i++)
            {
                LinkButton linkBtn = new LinkButton();
                var text = "[待审核]  " + stuffListitem[i].stuff.name + "（工号：" + stuffListitem[i].stuff.stuffNum + "）";
                linkBtn.Text = text;
                linkBtn.CommandArgument = stuffListitem[i].id;
                linkBtn.CssClass = "list-group-item notice-item";
                linkBtn.Click += new EventHandler(EntryStuffDetail);
                entryStuffList.Controls.Add(linkBtn);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void BackEntryStuffList(object sender, EventArgs e)
    {
        entryStuffList.Style["display"] = "block";
        stuffEntryDetail.Style["display"] = "none";
        btnRefreshEntryStuffList.Style["display"] = "inline";
        btnBackEntryStuffList.Style["display"] = "none";
        labStuffNumForEntry.InnerText = "";
        labName.InnerText = "";
        labJob.InnerText = "";
        labPost.InnerText = "";
        labEducation.InnerText = "";
        labDepartment.InnerText = "";
        labSkill.InnerText = "";
        labTimeForEntry.InnerText = "";
        labSubmitStuffNumForEntry.InnerText = "";
    }

    protected void EntryStuffDetail(object sender, EventArgs e)
    {
        if (Session[labStuffNum.InnerText] != null)
        {
            entryStuffList.Style["display"] = "none";
            stuffEntryDetail.Style["display"] = "block";
            btnRefreshEntryStuffList.Style["display"] = "none";
            btnBackEntryStuffList.Style["display"] = "inline";
            BackLeaveStuffList(null, null);

            var btn = (LinkButton)sender;
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.StuffListItem[] stuffListitem = sm.GetEntryStuffById(btn.CommandArgument);
            labIdForEntry.InnerText = btn.CommandArgument;
            labStuffNumForEntry.InnerText = stuffListitem[0].stuff.stuffNum;
            labName.InnerText = stuffListitem[0].stuff.name;
            labJob.InnerText = stuffListitem[0].stuff.job;
            labPost.InnerText = stuffListitem[0].stuff.job;
            labEducation.InnerText = stuffListitem[0].stuff.education;
            labDepartment.InnerText = stuffListitem[0].stuff.department;
            labSkill.InnerText = stuffListitem[0].stuff.skill;
            labTimeForEntry.InnerText = stuffListitem[0].submitTime;
            labSubmitStuffNumForEntry.InnerText = stuffListitem[0].submitStuffNum;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void CheckEntryStuff(object sender, EventArgs e)
     {
         if (Session[labStuffNum.InnerText] != null)
        {
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = sm.CheckEntryStuff(resultForEntry.SelectedItem.Text, labIdForEntry.InnerText, submitStuff);
            BackEntryStuffList(null, null);
            RefreshEntryStuffList(null, null);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void RefreshLeaveStuffList(object sender, EventArgs e)
     {
        btnBackLeaveStuffList.Style["display"] = "none";
        if (Session[labStuffNum.InnerText] != null)
        {
            leaveStuffList.Controls.Clear();
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.StuffListItem[] stuffListitem = sm.GetLeaveStuffList("待审核");
            if (stuffListitem == null)
            {
                return;
            }
            for (int i = 0; i < stuffListitem.Length; i++)
            {
                LinkButton linkBtn = new LinkButton();
                var text = "[待审核]  " + stuffListitem[i].stuff.name + "（工号：" + stuffListitem[i].stuff.stuffNum + "）";
                linkBtn.Text = text;
                linkBtn.CommandArgument = stuffListitem[i].id;
                linkBtn.CssClass = "list-group-item notice-item";
                linkBtn.Click += new EventHandler(LeaveStuffDetail);
                leaveStuffList.Controls.Add(linkBtn);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void BackLeaveStuffList(object sender, EventArgs e)
     {
         leaveStuffList.Style["display"] = "block";
         stuffLeaveDetail.Style["display"] = "none";
         btnRefreshLeaveStuffList.Style["display"] = "inline";
         btnBackLeaveStuffList.Style["display"] = "none";
         labStuffNumForLeave.InnerText = "";
         labNameForLeave.InnerText = "";
         labLeaveReason.InnerText = "";
         labTimeForLeave.InnerText = "";
         labSubmitStuffNumForLeave.InnerText = "";
     }

     protected void LeaveStuffDetail(object sender, EventArgs e)
     {
         if (Session[labStuffNum.InnerText] != null)
        {
            leaveStuffList.Style["display"] = "none";
            stuffLeaveDetail.Style["display"] = "block";
            btnRefreshLeaveStuffList.Style["display"] = "none";
            btnBackLeaveStuffList.Style["display"] = "inline";
            BackEntryStuffList(null, null);

            var btn = (LinkButton)sender;
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.StuffListItem[] stuffListitem = sm.GetLeaveStuffById(btn.CommandArgument);
            labIdForLeave.InnerText = btn.CommandArgument;
            labStuffNumForLeave.InnerText = stuffListitem[0].stuff.stuffNum;
            labNameForLeave.InnerText = stuffListitem[0].stuff.name;
            labLeaveReason.InnerText = stuffListitem[0].leaveReason;
            labTimeForLeave.InnerText = stuffListitem[0].submitTime;
            labSubmitStuffNumForLeave.InnerText = stuffListitem[0].submitStuffNum;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void CheckLeaveStuff(object sender, EventArgs e)
     {
         if (Session[labStuffNum.InnerText] != null)
        {
            BLL.StuffManage sm = new BLL.StuffManage();
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = sm.CheckLeaveStuff(resultForEntry.SelectedItem.Text, labIdForLeave.InnerText, submitStuff);
            BackLeaveStuffList(null, null);
            RefreshLeaveStuffList(null, null);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void RefreshJobChangeList(object sender, EventArgs e)
     {
        btnBackJobChangeList.Style["display"] = "none";
        if (Session[labStuffNum.InnerText] != null)
        {
            jobChangeList.Controls.Clear();
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.WorkChangeItem[] workChangeitem = wm.GetJobChangeList("待审核");
            if (workChangeitem == null)
            {
                return;
            }
            for (int i = 0; i < workChangeitem.Length; i++)
            {
                LinkButton linkBtn = new LinkButton();
                var text = "[待审核]  " + workChangeitem[i].name + "（工号：" + workChangeitem[i].stuffNum + "）";
                linkBtn.Text = text;
                linkBtn.CommandArgument = workChangeitem[i].id;
                linkBtn.CssClass = "list-group-item notice-item";
                linkBtn.Click += new EventHandler(JobChangeDetail);
                jobChangeList.Controls.Add(linkBtn);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void BackJobChangeList(object sender, EventArgs e)
     {
         jobChangeList.Style["display"] = "block";
         jobChangeDetail.Style["display"] = "none";
         btnRefreshJobChangeList.Style["display"] = "inline";
         btnBackJobChangeList.Style["display"] = "none";
         stuffNumForJobChange.InnerText = "";
         nameForJobChange.InnerText = "";
         oldJob.InnerText = "";
         newJob.InnerText = "";
         timeJobChange.InnerText = "";
         submitStuffNumForJobChange.InnerText = "";
     }

     protected void JobChangeDetail(object sender, EventArgs e)
     {
         if (Session[labStuffNum.InnerText] != null)
        {
            jobChangeList.Style["display"] = "none";
            jobChangeDetail.Style["display"] = "block";
            btnRefreshJobChangeList.Style["display"] = "none";
            btnBackJobChangeList.Style["display"] = "inline";
            BackPostChangeList(null, null);

            var btn = (LinkButton)sender;
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.WorkChangeItem[] workChangeItem = wm.GetJobChangeById(btn.CommandArgument);
            labIdForJobChange.InnerText = btn.CommandArgument;
            stuffNumForJobChange.InnerText = workChangeItem[0].stuffNum;
            nameForJobChange.InnerText = workChangeItem[0].name;
            oldJob.InnerText = workChangeItem[0].oldJob;
            newJob.InnerText = workChangeItem[0].newJob;
            timeJobChange.InnerText = workChangeItem[0].submitTime;
            submitStuffNumForJobChange.InnerText = workChangeItem[0].submitStuffNum;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void CheckJobChange(object sender, EventArgs e)
     {
         if (Session[labStuffNum.InnerText] != null)
        {
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = wm.CheckJobChange(resultForJobChange.SelectedItem.Text, labIdForJobChange.InnerText, submitStuff);
            BackJobChangeList(null, null);
            RefreshJobChangeList(null, null);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

     protected void RefreshPostChangeList(object sender, EventArgs e)
     {
        btnBackPostChangeList.Style["display"] = "none";
        if (Session[labStuffNum.InnerText] != null)
        {
            postChangeList.Controls.Clear();
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.WorkChangeItem[] workChangeitem = wm.GetPostChangeList("待审核");
            if (workChangeitem == null)
            {
                return;
            }
            for (int i = 0; i < workChangeitem.Length; i++)
            {
                LinkButton linkBtn = new LinkButton();
                var text = "[待审核]  " + workChangeitem[i].name + "（工号：" + workChangeitem[i].stuffNum + "）";
                linkBtn.Text = text;
                linkBtn.CommandArgument = workChangeitem[i].id;
                linkBtn.CssClass = "list-group-item notice-item";
                linkBtn.Click += new EventHandler(PostChangeDetail);
                postChangeList.Controls.Add(linkBtn);
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
     }

    protected void BackPostChangeList(object sender, EventArgs e)
    {
        postChangeList.Style["display"] = "block";
        postChangeDetail.Style["display"] = "none";
        btnRefreshPostChangeList.Style["display"] = "inline";
        btnBackPostChangeList.Style["display"] = "none";
        stuffNumForPostChange.InnerText = "";
        nameForPostChange.InnerText = "";
        oldPost.InnerText = "";
        newPost.InnerText = "";
        timePostChange.InnerText = "";
        submitStuffNumForPostChange.InnerText = "";
    }

    protected void PostChangeDetail(object sender, EventArgs e)
    {
        if (Session[labStuffNum.InnerText] != null)
        {
            postChangeList.Style["display"] = "none";
            postChangeDetail.Style["display"] = "block";
            btnRefreshPostChangeList.Style["display"] = "none";
            btnBackPostChangeList.Style["display"] = "inline";
            BackJobChangeList(null, null);

            var btn = (LinkButton)sender;
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.WorkChangeItem[] workChangeItem = wm.GetPostChangeById(btn.CommandArgument);
            labIdForPostChange.InnerText = btn.CommandArgument;
            stuffNumForPostChange.InnerText = workChangeItem[0].stuffNum;
            nameForPostChange.InnerText = workChangeItem[0].name;
            oldPost.InnerText = workChangeItem[0].oldPost;
            newPost.InnerText = workChangeItem[0].newPost;
            timePostChange.InnerText = workChangeItem[0].submitTime;
            submitStuffNumForPostChange.InnerText = workChangeItem[0].submitStuffNum;
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void CheckPostChange(object sender, EventArgs e)
    {
        if (Session[labStuffNum.InnerText] != null)
        {
            BLL.WorkManage wm = new BLL.WorkManage();
            Entity.Stuff submitStuff = new Entity.Stuff();
            submitStuff.stuffNum = labStuffNum.InnerText;
            var res = wm.CheckPostChange(resultForPostChange.SelectedItem.Text, labIdForPostChange.InnerText, submitStuff);
            BackPostChangeList(null, null);
            RefreshPostChangeList(null, null);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('" + res + "');", true);
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}