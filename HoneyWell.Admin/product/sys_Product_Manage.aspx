<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_Product_Manage.aspx.cs" Inherits="HoneyWell.Admin.product.sys_Product_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ace.min.css" />
    <%--    <script type="text/javascript" src="../js/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../js/jquery.form.js"></script>
    <script type="text/javascript" src="../js/imges.js"></script>--%>
    <script type="text/javascript" src="../js/DataValid.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="../editor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript" charset="utf-8" src="../kindedito/kindeditor.js"></script>
    <script type="text/javascript" src="../js/uploader.js"></script>
    <style type="text/css">
        /*上传样式*/
        .upload-box {
            position: relative;
            display: inline-block;
            height: 32px;
            vertical-align: middle;
            zoom: 1;
            *display: inline;
        }

            .upload-box .upload-btn {
                display: inline-block;
                height: 32px;
                zoom: 1;
                *display: inline;
            }

            .upload-box .upload-progress {
                position: absolute;
                top: 0;
                left: 0;
                padding: 2px 5px;
                width: 115px;
                height: 26px;
                border: 1px solid #d7d7d7;
                background: #fff;
                overflow: hidden;
            }

                .upload-box .upload-progress .txt {
                    display: block;
                    padding-right: 10px;
                    font-weight: normal;
                    font-style: normal;
                    font-size: 11px;
                    line-height: 18px;
                    height: 18px;
                    text-overflow: ellipsis;
                    overflow: hidden;
                }

                .upload-box .upload-progress .bar {
                    position: relative;
                    display: block;
                    width: 112px;
                    height: 4px;
                    border: 1px solid #1da76b;
                }

                    .upload-box .upload-progress .bar b {
                        display: block;
                        width: 0%;
                        height: 4px;
                        font-weight: normal;
                        text-indent: -99em;
                        background: #28B779;
                        overflow: hidden;
                    }

                .upload-box .upload-progress .close {
                    position: absolute;
                    display: block;
                    top: 1px;
                    right: 1px;
                    width: 14px;
                    height: 14px;
                    line-height: 14px;
                    text-align: center;
                    cursor: pointer;
                    overflow: hidden;
                }

                    .upload-box .upload-progress .close:hover {
                        text-decoration: none;
                    }

                    .upload-box .upload-progress .close i {
                        color: #535353;
                        font-size: 10px;
                        line-height: 14px;
                        -webkit-transform: scale(0.833);
                    }

        /*图片相册样式-缩略图*/
        .photo-list {
            margin: 0;
            padding: 10px 0 0 0;
        }

            .photo-list ul {
                margin: 0 0 0 -15px;
            }

                .photo-list ul li {
                    float: left;
                    margin-left: 15px;
                    text-align: center;
                    *width: 188px;
                }

                    .photo-list ul li .img-box {
                        position: relative;
                        margin: 5px auto;
                        width: 182px;
                        height: 182px;
                        border: 3px #efefed solid;
                        cursor: pointer;
                        overflow: hidden;
                    }

                        .photo-list ul li .img-box.selected {
                            border: 3px #f60 solid;
                        }

                        .photo-list ul li .img-box img {
                            width: 100%;
                            height: 100%;
                            opacity: 1;
                        }

                        .photo-list ul li .img-box .remark {
                            position: absolute;
                            display: block;
                            left: 0;
                            right: 0;
                            bottom: 0;
                            margin: 0;
                            padding: 3px 2px;
                            height: 18px;
                            line-height: 18px;
                            background: #000;
                            filter: alpha(opacity=50);
                            opacity: 0.5;
                            -moz-opacity: 0.5;
                            text-align: left;
                            overflow: hidden;
                        }

                            .photo-list ul li .img-box .remark:hover {
                                top: 0;
                                bottom: 0;
                                height: 100%;
                            }

                            .photo-list ul li .img-box .remark i {
                                position: relative;
                                font-size: 12px;
                                color: #fff;
                                font-style: normal;
                                line-height: 18px;
                            }

                    .photo-list ul li a {
                        padding-right: 1em;
                    }


        /*图片相册样式-产品图*/
        .photo-list1 {
            margin: 0;
            padding: 10px 0 0 0;
        }

            .photo-list1 ul {
                margin: 0 0 0 -15px;
            }

                .photo-list1 ul li {
                    float: left;
                    margin-left: 15px;
                    text-align: center;
                    *width: 188px;
                }

                    .photo-list1 ul li .img-box {
                        position: relative;
                        margin: 5px auto;
                        width: 182px;
                        height: 182px;
                        border: 3px #efefed solid;
                        cursor: pointer;
                        overflow: hidden;
                    }

                        .photo-list1 ul li .img-box.selected {
                            border: 3px #f60 solid;
                        }

                        .photo-list1 ul li .img-box img {
                            width: 100%;
                            height: 100%;
                            opacity: 1;
                        }

                        .photo-list1 ul li .img-box .remark {
                            position: absolute;
                            display: block;
                            left: 0;
                            right: 0;
                            bottom: 0;
                            margin: 0;
                            padding: 3px 2px;
                            height: 18px;
                            line-height: 18px;
                            background: #000;
                            filter: alpha(opacity=50);
                            opacity: 0.5;
                            -moz-opacity: 0.5;
                            text-align: left;
                            overflow: hidden;
                        }

                            .photo-list1 ul li .img-box .remark:hover {
                                top: 0;
                                bottom: 0;
                                height: 100%;
                            }

                            .photo-list1 ul li .img-box .remark i {
                                position: relative;
                                font-size: 12px;
                                color: #fff;
                                font-style: normal;
                                line-height: 18px;
                            }

                    .photo-list1 ul li a {
                        padding-right: 1em;
                    }

        /*按钮样式*/
        .td-input {
            display: inline-block;
            padding: 0 3px;
            border: 1px solid #d7d7d7;
            width: 92%;
            height: 20px;
            line-height: 18px;
            color: #666;
            font-size: 12px;
            background: #fff;
            vertical-align: middle;
        }

        .btn {
            background: #16a0d3;
            border: none;
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-family: "Microsoft Yahei";
            font-size: 12px;
            height: 32px;
            line-height: 32px;
            margin: 0 1px 0 0;
            padding: 0 20px;
        }

            .btn:hover {
                background: #117ea6;
            }

            .btn.green {
                background: #52A152;
            }

                .btn.green:hover {
                    background: #328032;
                }

            .btn.yellow {
                background: #FF9C30;
            }

                .btn.yellow:hover {
                    background: #c87316;
                }

            .btn.violet {
                background: #993333;
            }

                .btn.violet:hover {
                    background: #990033;
                }

        .icon-btn {
            display: inline-block;
            margin: 0;
            padding: 4px 10px 4px 8px;
            line-height: 20px;
            height: 20px;
            border: solid 1px #e1e1e1;
            color: #333;
            font-size: 12px;
            text-decoration: none;
            cursor: pointer;
            white-space: nowrap;
            text-overflow: ellipsis;
        }

            .icon-btn:hover {
                color: #2A72C5;
            }

            .icon-btn span {
                display: inline-block;
            }

            .icon-btn i {
                display: inline-block;
                margin-right: 3px;
                width: 14px;
                height: 14px;
                color: #333;
                font-size: 14px;
                line-height: 14px;
            }

        .img-btn {
            display: inline-block;
            margin: 0px 2px;
            width: 14px;
            height: 14px;
            line-height: 14px;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            word-break: break-all;
            cursor: pointer;
        }

            .img-btn:hover {
                text-decoration: none;
            }

            .img-btn i {
                color: #333;
                font-size: 14px;
            }


        /*=====================以下部分是Validform必须的====================*/
        .Validform_checktip {
            margin-left: 8px;
            line-height: 20px;
            height: 20px;
            overflow: hidden;
            color: #999;
            font-size: 12px;
        }

        .Validform_right {
            color: #71b83d;
            padding-left: 20px;
            background: url(valid_icons.png) no-repeat -40px -20px;
        }

        .Validform_wrong {
            color: red;
            padding-left: 20px;
            white-space: nowrap;
            background: url(valid_icons.png) no-repeat -20px -40px;
        }

        .Validform_loading {
            padding-left: 20px;
            background: url(icon_onload.gif) no-repeat left center;
        }

        .Validform_error {
            background: #FEFBD3;
        }

        #Validform_msg {
            color: #7d8289;
            font: 12px/1.5 tahoma, arial, \5b8b\4f53, sans-serif;
            width: 280px;
            -webkit-box-shadow: 2px 2px 3px #aaa;
            -moz-box-shadow: 2px 2px 3px #aaa;
            background: #fff;
            position: absolute;
            top: 0px;
            right: 50px;
            z-index: 99999;
            display: none;
            filter: progid:DXImageTransform.Microsoft.Shadow(Strength=3, Direction=135, Color='#999999');
            box-shadow: 2px 2px 0 rgba(0, 0, 0, 0.1);
        }

            #Validform_msg .iframe {
                position: absolute;
                left: 0px;
                top: -1px;
                z-index: -1;
            }

            #Validform_msg .Validform_title {
                position: relative;
                line-height: 35px;
                height: 35px;
                text-align: left;
                font-weight: bold;
                padding: 0 10px;
                color: #fff;
                background: #33B5E5;
            }

            #Validform_msg a.Validform_close:link, #Validform_msg a.Validform_close:visited {
                line-height: 30px;
                position: absolute;
                right: 10px;
                top: 0px;
                color: #fff;
                text-decoration: none;
            }

            #Validform_msg a.Validform_close:hover {
                color: #ccc;
            }

            #Validform_msg .Validform_info {
                padding: 10px;
                border: 1px solid #bbb;
                border-top: none;
                text-align: left;
            }
        /*=====================以上部分是Validform必须的====================*/

        /*=====================以下部分是WebUploader必须的====================*/
        .webuploader-container {
            position: relative;
        }

        .webuploader-element-invisible {
            position: absolute !important;
            clip: rect(1px 1px 1px 1px); /* IE6, IE7 */
            clip: rect(1px,1px,1px,1px);
        }

        .webuploader-pick {
            position: relative;
            display: inline-block;
            width: 65px;
            line-height: 30px;
            height: 30px;
            border: 1px solid #e1e1e1;
            cursor: pointer;
            background: #fff;
            color: #333;
            text-align: center;
            overflow: hidden;
            zoom: 1;
            *display: inline;
        }

        .webuploader-pick-hover {
            background: #fafafa;
        }

        .webuploader-pick-disable {
            opacity: 0.6;
            pointer-events: none;
        }
        /*=====================以上部分是WebUploader必须的====================*/
    </style>
    <style type="text/css">
        #page-content .genre {
            margin-left: 30px;
            margin-top: auto;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            KE.show({
                id: 'txtPDetails',
                imageUploadJson: '../../../product/upload_json.ashx',
                fileManagerJson: '../product/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function (id) {
                    KE.event.ctrl(document, 13, function () {
                        KE.util.setData(id);
                        document.forms['form1'].submit();
                    });
                    KE.event.ctrl(KE.g[id].iframeDoc, 13, function () {
                        KE.util.setData(id);
                        document.forms['form1'].submit();
                    });
                }
            });

            $("#txtPTypeMain").bind("change", BindType);
            //绑定类别
            function BindType() {
                var paras = { TCode: $("#txtPTypeMain").val(), TLevel: 2 };
                $.post("../handlers/product/sys_Product.ashx", paras, function (data) {
                    $("#txtPTypeSmall").empty();
                    $("#txtPTypeSmall").append(data);
                }, "HTML");
            }

            //缩略图上传
            $(".upload-album").InitUploader({ btntext: "批量上传", multiple: true, water: true, thumbnail: true, filesize: "10240", sendurl: "../handlers/product/upload_ajax.ashx", swf: "../scripts/webuploader/uploader.swf" });

            //详情图上传
            $(".upload-album1").InitUploader1({ btntext: "批量上传", multiple: true, water: true, thumbnail: true, filesize: "10240", sendurl: "../handlers/product/upload_ajax.ashx", swf: "../scripts/webuploader/uploader.swf" });

            //添加按钮事件
            $("#btnSave").click(function () {
                DataAdd("reset");
            });

            $("#btnSaveBack").click(function () {
                DataAdd("");
            });

            //修改返回单选按钮值
            var name1 = $("#PRecommend").val();
            if (name1 != "") {
                $("input[name='Recommend'][value='" + name1 + "']").attr('checked', true)
            }
            var name2 = $("#PShelf").val();
            if (name2 != "") {
                $("input[name='Shelf'][value='" + name2 + "']").attr('checked', true)
            }

            function DataAdd(t) {
                //缩略图
                var PPic = [];
                var txt = $('.photo-list').find(':input');
                for (var i = 0; i < txt.length; i++) {
                    PPic.push(txt.eq(i).val());
                }
                //详情图
                var DPic = [];
                var txt = $('.photo-list1').find(':input');
                for (var i = 0; i < txt.length; i++) {
                    DPic.push(txt.eq(i).val());
                }

                //获取表单值
                var PTypeMain = $("#txtPTypeMain").val();
                var PTypeSmall = $("#txtPTypeSmall").val();
                var PProperty = $("#txtPProperty").val();
                var PName = $("#txtPName").val();
                var PMarket = $("#txtPMarket").val();
                var PRetail = $("#txtPRetail").val();
                var PFormat = $("#txtPFormat").val();
                var PParam = $("#txtPParam").val();
                var PMould = $("#txtPMould").val();
                var PStock = $("#txtPStock").val();
                var PRecommend = $("input[name='Recommend']:checked").val();
                var PShelf = $("input[name='Shelf']:checked").val();
                var PDetails = $("#txtPDetails").val();

                //TODO:数据有效性验证\格式验证\非空验证等 

                if (PTypeMain == "0") {
                    alert("请选择产品大类名称！");
                    document.getElementById("txtPTypeMain").focus();
                    return false;
                }
                if (PProperty == "0") {
                    alert("请选择产品属性！");
                    document.getElementById("txtPProperty").focus();
                    return false;
                }
                if (PName == "") {
                    alert("产品名称不能为空！");
                    document.getElementById("txtPName").focus();
                    return false;
                }
                if (PMarket == "") {
                    alert("市场价不能为空！");
                    document.getElementById("txtPMarket").focus();
                    return false;
                }
                if (PRetail == "") {
                    alert("零售价不能为空！");
                    document.getElementById("txtPRetail").focus();
                    return false;
                }
                if (PDetails == "") {
                    alert("产品详情不能为空！");
                    document.getElementById("txtPDetails").focus();
                    return false;
                }

                //ID作为区别何种操作 
                var Id = $("#hdnPKID").val();

                //参数Json串
                var paras = {
                    Id: Id,
                    PTypeMain: PTypeMain,
                    PTypeSmall: PTypeSmall,
                    PProperty:PProperty,
                    PName: PName,
                    PPicUrl: PPic.toString(),
                    DPicUrl: DPic.toString(),
                    PMarket: PMarket,
                    PRetail: PRetail,
                    PFormat: PFormat,
                    PParam: PParam,
                    PMould: PMould,
                    PStock: PStock,
                    PRecommend: PRecommend,
                    PShelf: PShelf,
                    PDetails: PDetails
                };
                $.post("../handlers/product/sys_Product_Manage.ashx", paras, function (data) {
                    alert(data);
                    if (t == "reset") //写入成功之后清空文本框
                    {
                        $(":input", "#form1").not(":button,:submit,:reset").val("").removeAttr("checked");
                    }
                    else //写入成功之后返回列表
                    {
                        window.location.href = "sys_Product_List.aspx?Pageindex=<%=Pageindex%>&Ptypemain=<%=Ptypemain%>&Ptypesmall=<%=Ptypesmall%>&Pname=<%=Pname%>&Precommend=<%=Precommend%>&Pshelf=<%=Pshelf%>";
                }
                }, "text");
        }
        });
    </script>
</head>
<body>
    <form id="form1" class="form-horizontal" method="post">
        <input type="hidden" value="<%=PKID%>" id="hdnPKID" />
        <input type="hidden" value="<%=PRecommend%>" id="PRecommend" />
        <input type="hidden" value="<%=PShelf%>" id="PShelf" />
        <input type="hidden" name="ImgUrl" id="ImgUrl" value="<%=GetImgUrl()%>" />
        <div class="container-fluid" id="main-container">
            <div class="clearfix">
                <div id="page-content" class="clearfix">
                    <div class="page-header position-relative">
                        <h1>产品管理<small><i class="icon-double-angle-right"></i><a href="sys_Product_List.aspx">产品列表</a></small></h1>
                    </div>
                    <div class="row-fluid">
                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;类别名称1</label>
                            <div class="controls">
                                <select id="txtPTypeMain" style="width: 150px;"><%=StrClass1 %></select>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;类别名称2</label>
                            <div class="controls">
                                <select id="txtPTypeSmall" style="width: 150px;"><%=StrClass2 %></select>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;类别属性</label>
                            <div class="controls">
                                <select id="txtPProperty" style="width: 150px;"><%=StrClass3 %></select>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;产品名称</label>
                            <div class="controls">
                                <input type="text" id="txtPName" style="width: 200px" value="<%=PName%>" placeholder="产品名称不能为空" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;产品缩略图</label>
                            <div class="controls" style="padding-top: 5px">
                                <div class="upload-box upload-album"></div>
                                <font color="red">上传图片的大小不能大于500KB！</font>
                                <div class="photo-list">
                                    <ul>
                                        <%=PPic_List%>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;产品详情图</label>
                            <div class="controls" style="padding-top: 5px">
                                <div class="upload-box upload-album1"></div>
                                <font color="red">上传图片的大小不能大于500KB！</font>
                                <div class="photo-list1">
                                    <ul>
                                        <%=DPic_List%>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;市场价</label>
                            <div class="controls">
                                <input type="text" id="txtPMarket" style="width: 100px" value="<%=PMarket%>" onkeyup="if(isNaN(value))execCommand('undo')" />元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;零售价</label>
                            <div class="controls">
                                <input type="text" id="txtPRetail" style="width: 100px" value="<%=PRetail%>" onkeyup="if(isNaN(value))execCommand('undo')" />元
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;产品规格</label>
                            <div class="controls">
                                <input type="text" id="txtPFormat" style="width: 200px" value="<%=PFormat%>" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;产品参数</label>
                            <div class="controls">
                                <input type="text" id="txtPParam" style="width: 200px" value="<%=PParam%>" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;适用机型</label>
                            <div class="controls">
                                <input type="text" id="txtPMould" style="width: 200px" value="<%=PMould%>" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1"><font color="red">*</font>&nbsp;库存数量</label>
                            <div class="controls">
                                <input type="text" id="txtPStock" style="width: 50px" value="<%=PStock%>" onkeyup="if(isNaN(value))execCommand('undo')" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;是否推荐&nbsp;&nbsp;</label>
                            <input type="radio" class="genre" name="Recommend" checked="checked" value="0" />&nbsp;&nbsp;是
                            <input type="radio" class="genre" name="Recommend" value="1" />&nbsp;&nbsp;否
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="form-field-1">&nbsp;是否上架&nbsp;&nbsp;</label>
                            <input type="radio" class="genre" name="Shelf" checked="checked" value="0" />&nbsp;是
                            <input type="radio" class="genre" name="Shelf" value="1" />&nbsp;否
                        </div>

                        <div class="control-group" id="Content">
                            <label class="control-label" for="form-field-2"><font color="red">*</font>&nbsp;产品详情</label>
                            <div class="controls">
                                <textarea id="txtPDetails" style="width: 780px; height: 400px; visibility: hidden;" runat="server"></textarea>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button class="btn" type="button" id="back" onclick="javascript:history.go(-1);">
                                <i class="icon-undo"></i>返回上一步</button>
                            &nbsp; &nbsp;
                        <button class="btn btn-info" type="button" id="btnSave" onclick="">
                            <i class="icon-ok"></i>完成并继续添加</button>
                            &nbsp; &nbsp;
                        <button class="btn btn-info" type="button" id="btnSaveBack" onclick="">
                            <i class="icon-ok"></i>完成并返回列表</button>
                        </div>

                        <div class="space-24ger"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
