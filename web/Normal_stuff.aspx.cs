using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_Normal_stuff : System.Web.UI.Page
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
}