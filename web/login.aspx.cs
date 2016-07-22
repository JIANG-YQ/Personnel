using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login(object sender, EventArgs e)
    {
        BLL.UserManage um = new BLL.UserManage();
        Entity.User user = new Entity.User();
        user.stuffNum = txtUserName.Value;
        user.pwd = txtPwd.Value;
        user = um.Login(user);
        if (user != null)
        {
            Session[user.stuffNum] = user;
            if (string.Equals(user.power, "人事部门"))
            {
                string url;
                url = "Personnel_stuff.aspx?stuffNum=" + user.stuffNum;
                Response.Redirect(url);
            }
            else if (string.Equals(user.power, "相关部门"))
            {
                string url;
                url = "Related_stuff.aspx?stuffNum=" + user.stuffNum;
                Response.Redirect(url);
            }
            else if (string.Equals(user.power, "普通用户"))
            {
                string url;
                url = "Normal_stuff.aspx?stuffNum=" + user.stuffNum;
                Response.Redirect(url);
            }
            else if (string.Equals(user.power, "管理员"))
            {
                string url;
                url = "Administrator.aspx?stuffNum=" + user.stuffNum;
                Response.Redirect(url);
            }
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('工号或密码错误');", true);
        }
    }

}