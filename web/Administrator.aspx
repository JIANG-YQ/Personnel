<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" Inherits="web_Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
    <link rel="stylesheet" type="text/css" href="css/common.css"/>
    <link rel="stylesheet" type="text/css" href="css/notice_page.css"/>
    <link rel="stylesheet" type="text/css" href="css/side_navigation.css"/>
    <link rel="stylesheet" type="text/css" href="css/top_navigation.css"/>
    <link href="http://apps.bdimg.com/libs/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="/scripts/jquery.min.js"></script>
    <script src="/bootstrap/js/bootstrap.min.js"></script>
    <title>管理员门户</title>
</head>
<body>
	<!-- 顶部导航栏 -->
    <input type="radio" name="radio-set" checked="checked" id="home-page" class="nav"/>
    <label class="nav-item">首页</label>
    <input type="radio" name="radio-set" id="basis-info" class="nav"/>
    <label class="nav-item">人员基本信息</label>
    <input type="radio" name="radio-set" id="pwd-manage" class="nav"/>
    <label class="nav-item">更改密码</label>
    <input type="radio" name="radio-set" id="user-manage" class="nav"/>
    <label class="nav-item">用户管理</label>
    <label class="nav-item" id="labUserName" runat="server"></label>
    <label id="labStuffNum" hidden="hidden" runat="server"></label>

	<!-- logo -->
    <div><img class="logo-img" src="./images/logo.png"/></div>

    <form class="contant-form" role="form" runat="server" target="post_frame">
        <asp:ScriptManager ID="sm" runat="server" ></asp:ScriptManager>
        <iframe name='post_frame' id="post_frame" style="display:none"></iframe>

        <div class="contant">

            <!-- 密码管理 -->
            <div id="pwd-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set6" checked="checked" class="btn-change-item control-1"/>
                <label>更改密码</label>

                <!-- 更改密码 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">更改密码</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">原密码</span>
                                    <input id="txtOldPwd" type="password" class="form-control" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新密码</span>
                                    <input id="txtNewPwd" type="password" class="form-control" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnChangePwd" OnClick="ChangePwd" Text="确认" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChangePwd"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>
            </div>

            <!-- 公示栏 -->
            <div id="notice-list-container">
                <!-- 人员工作变动公示 -->
                <div class="panel panel-default notice-list-panel">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="text-align:center">人员工作变动公示</h3>
                    </div>
                    <div class="panel panel-default notice-list">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align:center">职称公示</h3>
                        </div>
                        <label class="list-group-item" id="jobChangeNoticeItem1" runat="server"></label>
                        <label class="list-group-item" id="jobChangeNoticeItem2" runat="server"></label>
                        <label class="list-group-item" id="jobChangeNoticeItem3" runat="server"></label>
                        <label class="list-group-item" id="jobChangeNoticeItem4" runat="server"></label>
                        <label class="list-group-item" id="jobChangeNoticeItem5" runat="server"></label>
                    </div>

                    <div class="panel panel-default notice-list" style="top: 0">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align:center">职务公示</h3>
                        </div>
                        <label class="list-group-item" id="postChangeNoticeItem1" runat="server"></label>
                        <label class="list-group-item" id="postChangeNoticeItem2" runat="server"></label>
                        <label class="list-group-item" id="postChangeNoticeItem3" runat="server"></label>
                        <label class="list-group-item" id="postChangeNoticeItem4" runat="server"></label>
                        <label class="list-group-item" id="postChangeNoticeItem5" runat="server"></label>
                    </div>
                </div>

                <!-- 人员增减变动公示 -->
                <div class="panel panel-default notice-list-container">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="text-align:center">人员增减变动公示</h3>
                    </div>
                    <div class="panel panel-default notice-list">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align:center">入职公示</h3>
                        </div>
                        <label class="list-group-item" id="stuffEntryNoticeItem1" runat="server"></label>
                        <label class="list-group-item" id="stuffEntryNoticeItem2" runat="server"></label>
                        <label class="list-group-item" id="stuffEntryNoticeItem3" runat="server"></label>
                        <label class="list-group-item" id="stuffEntryNoticeItem4" runat="server"></label>
                        <label class="list-group-item" id="stuffEntryNoticeItem5" runat="server"></label>
                    </div>

                    <div class="panel panel-default notice-list">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align:center">离职公示</h3>
                        </div>
                        <label class="list-group-item" id="stuffLeaveNoticeItem1" runat="server"></label>
                        <label class="list-group-item" id="stuffLeaveNoticeItem2" runat="server"></label>
                        <label class="list-group-item" id="stuffLeaveNoticeItem3" runat="server"></label>
                        <label class="list-group-item" id="stuffLeaveNoticeItem4" runat="server"></label>
                        <label class="list-group-item" id="stuffLeaveNoticeItem5" runat="server"></label>
                    </div>
                </div>
            </div>

            <!-- 基本信息 -->
            <div id="basis-info-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set2" checked="checked" class="btn-change-item control-1"/>
                <label>信息查询</label>

                <!-- 信息查询 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">信息查询</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumForBasisInfo" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" ID="btnSearchBasisInfo" type="submit" OnClick="SearchBasisInfo" Text="查询" runat="server"/>
                                <div class="input-group input-group-lg" style="margin: 10px 5px 0 5px">
                                    <span class="input-group-addon">工号</span>
                                    <asp:label class="form-control" id="labStuffNumInBasisInfo" runat="server"></asp:label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label class="form-control" id="labNameInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">部门</span>
                                    <label class="form-control" id="labDepartmentInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">学历</span>
                                    <label class="form-control" id="labEducationInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">职务</span>
                                    <label class="form-control" id="labJobInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">职称</span>
                                    <label class="form-control" id="labPostInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">技术类型</span>
                                    <label class="form-control" id="labSkillInBasisInfo" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">在职情况</span>
                                    <label class="form-control" id="labIfOnTheJobBasisInfo" runat="server"></label>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnSearchBasisInfo"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>         
            </div>

            <!-- 用户管理 -->
            <div id="user-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set5" checked="checked" class="btn-change-item control-1"/>
                <label>增加用户</label>
                <input type="radio" name="radio-set5" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">删除用户</label>
                <input type="radio" name="radio-set5" class="btn-change-item control-3" style="top: 68px; left: 0"/>
                <label style="top: 68px; left: 0">查看用户权限</label>
                <input type="radio" name="radio-set5" class="btn-change-item control-4" style="top: 102px; left: 0"/>
                <label style="top: 102px; left: 0">更改用户权限</label>

                <!-- 增加用户 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">增加用户</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumForAddUser" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="nameForAddUser" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">权限</span>
                                    <asp:DropDownList class="form-control" id="powerForAddUser" runat="server">
                                        <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
                                        <asp:ListItem Value="人事部门">人事部门</asp:ListItem>
                                        <asp:ListItem Value="相关部门">相关部门</asp:ListItem>
                                        <asp:ListItem Value="管理员">管理员</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnAddUser" OnClick="AddUser" type="submit" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnAddUser"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 删除用户 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">删除用户</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumForDelUser" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="nameForDelUser" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnDelUser" OnClick="DelUser" type="submit" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnDelUser"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 查看用户权限 -->
                <div class="panel panel-default div-3">
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">查看用户权限</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumForSearchPower" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnSearchPower" OnClick="SearchPower" type="submit" Text="提交" runat="server"/>
                                <div class="input-group input-group-lg" style="margin: 10px 5px 0 5px">
                                    <span class="input-group-addon">权限</span>
                                    <label type="text" class="form-control" id="labPowerForSearchPower" runat="server"></label>
                                </div>    
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnSearchPower"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 更改用户权限 -->
                <div class="panel panel-default div-4">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">更改用户权限</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumForChangePower" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="nameForChangePower" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新权限</span>
                                    <asp:DropDownList class="form-control" id="powerForChangePower" runat="server">
                                        <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
                                        <asp:ListItem Value="人事部门">人事部门</asp:ListItem>
                                        <asp:ListItem Value="相关部门">相关部门</asp:ListItem>
                                        <asp:ListItem Value="管理员">管理员</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnChangePower" OnClick="ChangePower" type="submit" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChangePower"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>    

    </form>
</body>
</html>
