<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personnel_stuff.aspx.cs" Inherits="web_Personnel_stuff" %>

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
    <title>人事部门员工门户</title>
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
    <input type="radio" name="radio-set" id="salary-manage" class="nav"/>
    <label class="nav-item">人员工资管理</label>
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
                <label>员工录入申请</label>
                <input type="radio" name="radio-set3" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">员工离职申请</label>

                <!-- 员工录入 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel31" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">员工录入申请</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="txtStuffNumForEntry" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="txtName" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">职务</span>
                                    <input type="text" class="form-control" id="txtJob" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">职称</span>
                                    <input type="text" class="form-control" id="txtPost" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                <span class="input-group-addon">学历</span>
                                    <input type="text" class="form-control" id="txtEducation" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">部门</span>
                                    <input type="text" class="form-control" id="txtDepartment" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">技术类型</span>
                                    <input type="text" class="form-control" id="txtSkill" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnStuffEntry" OnClick="StuffEntry" Text="确认" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnStuffEntry"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 员工离职 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePane32" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px;">员工离职申请</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="txtStuffNumForLeave" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="txtNameForLeave" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">离职原因</span>
                                    <input type="text" class="form-control" id="txtLeaveReason" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnStuffLeave" type="submit" OnClick="StuffLeave" Text="确认" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnStuffLeave"/>    
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

            <!-- 人员工资管理 -->
            <div id="salary-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set4" checked="checked" class="btn-change-item control-1"/>
                <label>工资查询</label>
                <input type="radio" name="radio-set4" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">工资管理</label>

                <!-- 工资查询 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel41" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">工资查询</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumInSearchSalary" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnSearchSalary" type="submit" OnClick="SearchSalary" Text="查询" runat="server"/>
                                <div class="input-group input-group-lg" style="margin: 10px 5px 0 5px">
                                    <span class="input-group-addon">工号</span>
                                    <asp:label class="form-control" id="labStuffNumInSearchSalary" runat="server"></asp:label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <label class="form-control" id="labNameInSearchSDalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">基本工资</span>
                                    <label class="form-control" id="labBasisSalaryInSearchSalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">部门津贴</span>
                                    <label class="form-control" id="labDepAllowanceInSearchSalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">临时津贴</span>
                                    <label class="form-control" id="labTmpAllowanceInSearchSalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">奖金</span>
                                    <label class="form-control" id="labPrizeInSearchSalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">个人所得税</span>
                                    <label class="form-control" id="labTaxInSearchSalary" runat="server"></label>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 0 5px">
                                    <span class="input-group-addon">实际工资</span>
                                    <label class="form-control" id="labTrueSalaryInSearchSalary" runat="server"></label>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnSearchSalary"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 工资管理 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePanel42" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px;">工资管理</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="stuffNumInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="nameInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">基本工资</span>
                                   <input type="text" class="form-control" id="basisSalaryInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">部门津贴</span>
                                    <input type="text" class="form-control" id="depAllowanceInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">临时津贴</span>
                                    <input type="text" class="form-control" id="tmpAllowanceInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">奖金</span>
                                    <input type="text" class="form-control" id="prizeInChangeSalary" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">个人所得税</span>
                                    <input type="text" class="form-control" id="taxInChangeSalary" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnChangeSalary" type="submit" OnClick="ChangeSalary" Text="更改" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChangeSalary"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>
            </div>

            <!-- 人员工作变动 -->
            <div id="work-manage-container">
                <!-- 侧边导航栏 -->
                <div class="side-navigation"></div>
                <input type="radio" name="radio-set5" checked="checked" class="btn-change-item control-1"/>
                <label>职务变动申请</label>
                <input type="radio" name="radio-set5" class="btn-change-item control-2" style="top: 34px; left: 0"/>
                <label style="top: 34px; left: 0">职称变动申请</label>

                <!-- 职务管理 -->
                <div class="panel panel-default div-1">
                    <asp:UpdatePanel ID="UpdatePanel51" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">职务变动申请</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="changeJobStuffNum" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="changeJobName" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新职务</span>
                                    <input type="text" class="form-control" id="newJob" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnChangeJob" type="submit" Onclick="ChangeJob" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChangeJob"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>

                <!-- 职称管理 -->
                <div class="panel panel-default div-2">
                    <asp:UpdatePanel ID="UpdatePanel52" runat="server" ChildrenAsTriggers="true" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="panel-heading">
                                <h3 class="panel-title" style="font-size: 25px">职称变动申请</h3>
                            </div>
                            <div class="bs-example bs-example-form">
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">工号</span>
                                    <input type="text" class="form-control" id="changePostStuffNum" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">姓名</span>
                                    <input type="text" class="form-control" id="changePostName" runat="server"/>
                                </div>
                                <div class="input-group input-group-lg" style="margin: 10px 5px">
                                    <span class="input-group-addon">新职称</span>
                                    <input type="text" class="form-control" id="newPost" runat="server"/>
                                </div>
                                <asp:button class="btn btn-primary btn-lg btn-accept" id="btnChangePost" type="submit" Onclick="ChangePost" Text="提交" runat="server"/>
                            </div>
                        </ContentTemplate>
                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChangePost"/>    
                        </Triggers> 
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>    

    </form>
</body>
</html>
