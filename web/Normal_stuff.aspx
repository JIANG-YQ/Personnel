<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Normal_stuff.aspx.cs" Inherits="web_Normal_stuff" %>

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
    <title>普通员工门户</title>
</head>
<body>
	<!-- 顶部导航栏 -->
    <input type="radio" name="radio-set" checked="checked" id="home-page" class="nav"/>
    <label class="nav-item">首页</label>
    <input type="radio" name="radio-set" id="basis-info" class="nav"/>
    <label class="nav-item">人员基本信息</label>
    <input type="radio" name="radio-set" id="pwd-manage" class="nav"/>
    <label class="nav-item">更改密码</label>
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

        </div>    

    </form>
</body>
</html>
