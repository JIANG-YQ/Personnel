<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Related_stuff.aspx.cs" Inherits="web_Related_stuff" %>

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
    <title>相关部门员工门户</title>
</head>
<body>
	<!-- 顶部导航栏 -->
    <input type="radio" name="radio-set" checked="checked" id="home-page" class="nav"/>
    <label class="nav-item">首页</label>
    <input type="radio" name="radio-set" id="basis-info" class="nav"/>
    <label class="nav-item">人员基本信息</label>
    <input type="radio" name="radio-set" id="work-manage" class="nav"/>
    <label class="nav-item">人员工作变动</label>
    <input type="radio" name="radio-set" id="stuff-manage" class="nav"/>
    <label class="nav-item">人员增减变动</label>
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

            <!-- 人员增减变动 -->
            <div id="stuff-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set3" checked="checked" class="btn-change-item control-1"/>
                <label>员工录入审核</label>
                <input type="radio" name="radio-set3" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">员工离职审核</label>

                <!-- 员工录入 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel31" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">员工录入审核</h3>
                            </div>
                            <asp:button class="btn btn-primary btn-lg btn-accept" id="btnRefreshEntryStuffList" OnClick="RefreshEntryStuffList" type="submit" Text="刷新" runat="server"/>
                            <asp:button class="btn btn-primary btn-lg btn-back" id="btnBackEntryStuffList" OnClick="BackEntryStuffList" type="submit" Text="返回" runat="server"/>
                            <div class="panel panel-default" id="entryStuffList" style="position: relative; margin: 10px 0 0 0" runat="server"></div>
                            <div class="bs-example bs-example-form" id="stuffEntryDetail" runat="server" style="position: relative; display: none">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <label type="text" class="form-control" id="labStuffNumForEntry" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label type="text" class="form-control" id="labName" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">职务</span>
                                    <label type="text" class="form-control" id="labJob" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">职称</span>
                                    <label type="text" class="form-control" id="labPost" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">学历</span>
                                    <label type="text" class="form-control" id="labEducation" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">部门</span>
                                    <label type="text" class="form-control" id="labDepartment" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">技术类型</span>
                                    <label type="text" class="form-control" id="labSkill" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审时间</span>
                                    <label type="text" class="form-control" id="labTimeForEntry" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审人员工号</span>
                                    <label type="text" class="form-control" id="labSubmitStuffNumForEntry" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">审核结果</span>
                                    <asp:DropDownList class="form-control" id="resultForEntry" runat="server">
                                        <asp:ListItem Value="通过">通过</asp:ListItem>
                                        <asp:ListItem Value="不通过">不通过</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label id="labIdForEntry" hidden="hidden" runat="server"></label>
                                <asp:button class="btn btn-primary btn-lg btn-accept" OnClick="CheckEntryStuff" id="btnCheckEntry" type="submit" Text="确认" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnRefreshEntryStuffList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnBackEntryStuffList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnCheckEntry"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 员工离职 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePane32" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px;">员工离职审核</h3>
                            </div>
                            <asp:button class="btn btn-primary btn-lg btn-accept" id="btnRefreshLeaveStuffList" OnClick="RefreshLeaveStuffList" type="submit" Text="刷新" runat="server"/>
                            <asp:button class="btn btn-primary btn-lg btn-back" id="btnBackLeaveStuffList" OnClick="BackLeaveStuffList" type="submit" Text="返回" runat="server"/>
                            <div class="panel panel-default" id="leaveStuffList" style="position: relative; margin: 10px 0 0 0" runat="server"></div>
                            <div class="bs-example bs-example-form" id="stuffLeaveDetail" runat="server" style="position: relative; display: none">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <label type="text" class="form-control" id="labStuffNumForLeave" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label type="text" class="form-control" id="labNameForLeave" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">离职原因</span>
                                    <label type="text" class="form-control" id="labLeaveReason" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审时间</span>
                                    <label type="text" class="form-control" id="labTimeForLeave" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审人员工号</span>
                                    <label type="text" class="form-control" id="labSubmitStuffNumForLeave" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">审核结果</span>
                                    <asp:DropDownList class="form-control" id="resultForLeave" runat="server">
                                        <asp:ListItem Value="通过">通过</asp:ListItem>
                                        <asp:ListItem Value="不通过">不通过</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label id="labIdForLeave" hidden="hidden" runat="server"></label>
                                <asp:button class="btn btn-primary btn-lg btn-accept" OnClick="CheckLeaveStuff" id="btnCheckLeave" type="submit" Text="确认" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnRefreshLeaveStuffList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnBackLeaveStuffList"/>   
                            <asp:AsyncPostBackTrigger ControlID="btnCheckLeave"/>     
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

            </div>

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

            <!-- 人员工作变动 -->
            <div id="work-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set5" checked="checked" class="btn-change-item control-1"/>
                <label>职务管理</label>
                <input type="radio" name="radio-set5" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">职称管理</label>

                <!-- 职务管理 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel51" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">职务管理</h3>
                            </div>
                            <asp:button class="btn btn-primary btn-lg btn-accept" id="btnRefreshJobChangeList" OnClick="RefreshJobChangeList" type="submit" Text="刷新" runat="server"/>
                            <asp:button class="btn btn-primary btn-lg btn-back" id="btnBackJobChangeList" OnClick="BackJobChangeList" type="submit" Text="返回" runat="server"/>
                            <div class="panel panel-default" id="jobChangeList" style="position: relative; margin: 10px 0 0 0" runat="server"></div>
                            <div class="bs-example bs-example-form" id="jobChangeDetail" runat="server" style="position: relative; display: none">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <label type="text" class="form-control" id="stuffNumForJobChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label type="text" class="form-control" id="nameForJobChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">原职务</span>
                                    <label type="text" class="form-control" id="oldJob" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新职务</span>
                                    <label type="text" class="form-control" id="newJob" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审时间</span>
                                    <label type="text" class="form-control" id="timeJobChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审人员工号</span>
                                    <label type="text" class="form-control" id="submitStuffNumForJobChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">审核结果</span>
                                    <asp:DropDownList class="form-control" id="resultForJobChange" runat="server">
                                        <asp:ListItem Value="通过">通过</asp:ListItem>
                                        <asp:ListItem Value="不通过">不通过</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label id="labIdForJobChange" hidden="hidden" runat="server"></label>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnCheckJobChange" OnClick="CheckJobChange" type="submit" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnRefreshJobChangeList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnBackJobChangeList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnCheckJobChange"/>
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 职称管理 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePanel52" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">职称管理</h3>
                            </div>
                            <asp:button class="btn btn-primary btn-lg btn-accept" id="btnRefreshPostChangeList" OnClick="RefreshPostChangeList" type="submit" Text="刷新" runat="server"/>
                            <asp:button class="btn btn-primary btn-lg btn-back" id="btnBackPostChangeList" OnClick="BackPostChangeList" type="submit" Text="返回" runat="server"/>
                            <div class="panel panel-default" id="postChangeList" style="position: relative; margin: 10px 0 0 0" runat="server"></div>
                            <div class="bs-example bs-example-form" id="postChangeDetail" runat="server" style="position: relative; display: none">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <label type="text" class="form-control" id="stuffNumForPostChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label type="text" class="form-control" id="nameForPostChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">原职称</span>
                                    <label type="text" class="form-control" id="oldPost" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新职称</span>
                                    <label type="text" class="form-control" id="newPost" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审时间</span>
                                    <label type="text" class="form-control" id="timePostChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">提审人员工号</span>
                                    <label type="text" class="form-control" id="submitStuffNumForPostChange" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">审核结果</span>
                                    <asp:DropDownList class="form-control" id="resultForPostChange" runat="server">
                                        <asp:ListItem Value="通过">通过</asp:ListItem>
                                        <asp:ListItem Value="不通过">不通过</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label id="labIdForPostChange" hidden="hidden" runat="server"></label>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnCheckPostChange" OnClick="CheckPostChange" type="submit" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnRefreshPostChangeList"/>
                            <asp:AsyncPostBackTrigger ControlID="btnBackPostChangeList"/>    
                            <asp:AsyncPostBackTrigger ControlID="btnCheckPostChange"/>
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>    

    </form>
</body>
</html>

