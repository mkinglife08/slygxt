var cookie = {
    set: function (key, val, time) {//设置cookie方法
        var date = new Date(); //获取当前时间
        var expiresDays = time;  //将date设置为n天以后的时间
        date.setTime(date.getTime() + expiresDays * 24 * 3600 * 1000); //格式化为cookie识别的时间
        document.cookie = key + "=" + val + ";expires=" + date.toGMTString();  //设置cookie
    },
    get: function (key) {//获取cookie方法
        /*获取cookie参数*/
        var getCookie = document.cookie.replace(/[ ]/g, "");  //获取cookie，并且将获得的cookie格式化，去掉空格字符
        var arrCookie = getCookie.split(";")  //将获得的cookie以"分号"为标识 将cookie保存到arrCookie的数组中
        var tips;  //声明变量tips
        for (var i = 0; i < arrCookie.length; i++) {   //使用for循环查找cookie中的tips变量
            var arr = arrCookie[i].split("=");   //将单条cookie用"等号"为标识，将单条cookie保存为arr数组
            if (key == arr[0]) {  //匹配变量名称，其中arr[0]是指的cookie名称，如果该条变量为tips则执行判断语句中的赋值操作
                tips = arr[1];   //将cookie的值赋给变量tips
                break;   //终止for循环遍历
            }
        }
        return tips;
    },
    getbysign: function (key) {
        var sign = GetQueryString("EMRIDSIGN");
        if (sign == "" && parent)
            sign = parent.GetQueryString("EMRIDSIGN");
        return cookie.get(key + sign);
    },
    //获取EMR用户cookie
    GetEMRUserCookie: function (cookieName, objName) {
        var mycookie = cookie.getbysign(cookieName);
        if (mycookie) {
            mycookie = JSON.parse(mycookie);
            if (objName == undefined
        || objName == null
        || (typeof objName == "string" && objName.trim() == ""))
                return mycookie;
            else if (mycookie[objName])
                return mycookie[objName];
            else
                return GetQueryString(objName);
        }
        return "";
    },
    deleteCookie: function (key) { //删除cookie方法
        var date = new Date(); //获取当前时间
        date.setTime(date.getTime() - 10000); //将date设置为过去的时间
        document.cookie = key + "=v; expires =" + date.toGMTString();//设置cookie
    }
}
var EWinsBase = {
    __webApiAddress: '',
    __curHostAddress: __curHostAddress,
    __cacheData: {},

    /*登陆数据，无缓存效果，页面需要每次都单独处理*/
    LoginUser: undefined,
    /*缓存默认时间为2分钟*/
    Cache: function (key, data, expireseconds) {
        if (expireseconds == undefined) {
            expireseconds = 2 * 60;
        }
        if (data != undefined) {
            EWinsBase.__cacheData[key] = { data: data, expiredate: Date.parse(new Date()) + expireseconds * 1000 };
        } else {
            var cache = EWinsBase.__cacheData[key];
            if (cache != undefined && cache.expiredate > Date.parse(new Date())) {
                return cache.data;
            }
        }
    },
    /*当前登陆票据*/
    Token: cookie.GetEMRUserCookie("api_token", "Token"),
    /*组织架构*/
    ORGANID: cookie.GetEMRUserCookie("api_token", "ORGANID"),
    /*Json请求前处理逻辑*/
    before: function (xhr) {
        var token = EWinsBase.Token;
        if (EWinsBase.isNullOrEmpty(token)) {
            token = "";
        }
        xhr.setRequestHeader('token', token);//
    },
    /*---------------------------
     *   Json数据获取请求，支持部分前端缓存，减少服务器压力
     *   Options:SaveDiagData
     *       usedCache: true/false 是否使用缓存
     *       expireSeconds: 120 Cache有效时间，为秒数
     *       async: true/false 是否使用异步数据获取
     *       type: GET/POST/DELETE/PUT 需要服务器支持
     *       error: JSON请求失败后的回调地址
     *       success: JSON请求成功后的回调函数
     *       data: 需要提交的数据对象
    ----------------------------*/
    json: function (url, options) {
        //config, error, async, params, type, success

        if (!options.type) {
            options.type = "GET";
        }
        if (options.async == undefined) {
            options.async = true;
        }
        //if (options.usedCache == undefined || options.usedCache == true) {
        //默认不使用缓存
        if (options.usedCache == true) {
            options.usedCache = true;
            if (options.expireSeconds == undefined) {
                options.expireSeconds = 2 * 60;
            }
            //var key = $.md5(url + JSON.stringify(options)),
            var key = url + JSON.stringify(options),
                obj = EWinsBase.Cache(key);
        }
        if (options.processData)
            options.data["token"] = EWinsBase.Token;
        else
            url += (url.indexOf('?') > 0 ? "&" : "?") + "token=" + EWinsBase.Token;
        if (obj == undefined || obj == null) {
            $.ajax({
                async: options.async,
                url: EWinsBase.__curHostAddress + url,
                dataType: "json",
                type: options.type,
                data: options.data,
                processData: options.processData,
                contentType: options.contentType,
                beforeSend: EWinsBase.before,
                complete: options.complete,
                error: function (reqObj, status, err) {
                    if (options.error) {
                        options.error(reqObj.responseText);
                    }
                },
                success: function (data) {
                    //显示返回的数据 Status 0失败 1成功，其他状态需要在回调时自行解析。
                    switch (data.code) {
                        case 0:
                            if (options.success) {
                                if (options.usedCache == true) {
                                    EWinsBase.Cache(key, data, options.expireSeconds);
                                }
                                if (options.success)
                                    options.success(options.config, data);
                            }
                            break;
                        case 1:
                            if (!EWinsBase.isNullOrEmpty(data.msg))
                                EWinsBase.alert(data.msg);
                            if (options.error)
                                options.error(options.config, data);
                            break;
                        case 6:
                            if (!EWinsBase.isNullOrEmpty(data.msg))
                                EWinsBase.alert(data.msg);
                            if (options.error)
                                options.error(options.config, data);
                            break;
                        case 13:
                            if (!EWinsBase.isNullOrEmpty(data.msg)) {
                                layer.confirm('<span style="color:red;font-size:18px;">'+data.msg+' 是否立刻重新登录？</span>', {
                                    btn: ['确定', '取消']
                                }, function (index, layero) {
                                    layer.closeAll('dialog');  //加入这个信息点击确定 会关闭这个消息框
                                    top.location.href = EWinsBase.__curHostAddress + "login";
                                }
                        );
                            }
                            //top.location.href = EWinsBase.__curHostAddress + "login";
                            break;
                        default:
                            if (options.error)
                                options.error(options.config, data);
                            break;
                    }
                }
            });
        } else {
            if (options.success) {
                options.success(options.config, obj);
            }
        }
    },
    /*带Jsonp的跨域访问，需要服务器端支持*/
    jsonp: function (url, options) {
        //config, error, async, params, type, success
        if (!options.type) {
            options.type = "GET";
        }

        if (options.async == undefined) {
            options.async = true;
        }

        //var key = $.md5(url + JSON.stringify(options));
        var key = url + JSON.stringify(options);
        var obj = EWinsBase.Cache(key);
        //options.data["token"] = EWinsBase.Token;//跨域的token请在具体实现时提交
        if (obj == undefined || obj == null) {
            $.ajax(
            {
                async: false,
                url: EWinsBase.__webApiAddress + url,
                dataType: "jsonp",
                jsonp: 'callback',
                type: options.type,
                data: options.data,
                //beforeSend: EWinsBase.before,
                headers: { 'Authorization': 'Basic ' + EWinsBase.Token, "token": EWinsBase.Token },
                error: function (reqObj, status, err) {
                    if (options.error) {
                        //options.error(reqObj.responseText);
                    }

                },
                //错误隐藏在DIV里
                success: function (data) {
                    //显示返回的数据
                    if (data.Status != 0) {
                        //EWinsBase.alert(data.FeedbackInfo);
                    } else {
                        if (options.success) {
                            EWinsBase.Cache(key, data.Result);
                            options.success(options.config, data.Result);
                        }
                    }
                    //console.log(data);
                }
            });
        } else {
            if (options.success) {
                options.success(options.config, obj);
            }
        }
    },
    /*当前Cookie信息获取*/
    cookie: function (name, value, days) {
        if (EWinsBase.isNullOrEmpty(name)) {
            document.cookie = "";
        }
        else if (EWinsBase.isNullOrEmpty(value)) {
            /* 获取浏览器所有cookie将其拆分成数组 */
            var arr = document.cookie.split('; ');

            for (var i = 0; i < arr.length; i++) {
                /* 将cookie名称和值拆分进行判断 */
                var arr2 = arr[i].split('=');
                if (arr2[0] == name) {
                    return arr2[1];
                }
            }
            return '';
        } else {
            if (days == undefined || days == null) {
                days = 10 * 365;
            }
            var oDate = new Date();
            oDate.setSeconds(oDate.getSeconds() + 24 * 60 * 60 * days);
            document.cookie = name + '=' + value + ';expires=' + oDate.toGMTString() + ";path=/";
        }
    },
    /*Url参数截取*/
    urlParameter: function (sParam) {
        var sPageUrl = decodeURIComponent(window.location.search.substring(1)),
            sUrlVariables = sPageUrl.split('&'),
            sParameterName,
            i;
        for (i = 0; i < sUrlVariables.length; i++) {
            sParameterName = sUrlVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? null : sParameterName[1];
            }
        }
        return null;
    },
    /*传送的Token值*/
    bearerToken: function (tokenParamName) {
        var token = window.localStorage.getItem("token");
        if (!token) {
            if (EWinsBase.isNullOrEmpty(tokenParamName)) {
                tokenParamName = "token";
            }
            token = base.GetUrlParameter(tokenParamName);
        }
        return token;
    },
    /*本地Token值*/
    localStorageToken: function (key, token) {
        if (EWinsBase.isNullOrEmpty(key)) {
            key = "token";
        }

        if (EWinsBase.isNullOrEmpty(token)) {
            return window.localStorage.getItem(key);
        } else {
            window.localStorage.setItem(key, token);
        }
    },
    /*判定无数据*/
    isNullOrEmpty: function (data) {
        if (data == undefined
            || data == null
            || (typeof data == "string" && data.trim() == "")) {
            return true;
        }
        return false;
    },
    /*自动判定登录状态，并自动跳转，已登陆的则将数据写入LoginUser*/
    /*checkLoginState: function () {
        if (EWinsBase.LoginUser != undefined || window.location.pathname == "/home/login") {
            return;
        }

        EWinsBase.Token = EWinsBase.cookie("loginToken");
        if (EWinsBase.isNullOrEmpty(EWinsBase.Token)) {
            window.location.href = "/home/login?url=" + window.location.href;
        }

        EWinsBase.json("api/admin/login", {
            data: { "loginToken": EWinsBase.Token },
            async: false,
            success: function (config, data) {
                if (EWinsBase.isNullOrEmpty(data.Token)) {
                    window.location.href = "/home/login?url=" + window.location.href;
                } else {
                    //取得用户的实际信息
                    EWinsBase.json("api/user/loginuser", {
                        data: { "userid": data.UserId },
                        async: false,
                        success: function (config, data) {
                            EWinsBase.LoginUser = data
                        },
                        error: function (error) {
                            window.location.reload();
                        }
                    });
                }
            },
            error: function (error) {
                window.location.reload();
            }
        });
    },
    /*模态框弹层数据填充*/
    fillDetailModalBase: function (modal, view, id) {
        $("#" + modal + " [data-id]").each(function (i, o) {
            var viewId = $(o).data("id");
            var viewCtl = $("#" + view).find("#" + id + " [data-id='" + viewId + "']");
            if (viewCtl != undefined) {
                $(o).val($(viewCtl).text());
            }
        });
    },
    fillBasicModalBase: function (modal, view, id) {
        $("#" + modal + " [data-id]").each(function (i, o) {
            var viewId = $(o).data("id");
            var viewCtl = $("#" + view + " [data-id='" + viewId + "']");
            if (viewCtl != undefined) {
                $(o).val($(viewCtl).text());
            }
        });
    },
    /*获取基础配置表数据*/
    extConfigDatas: function (codes) {
        var returndata = {};
        //取得用户的实际信息
        EWinsBase.json("api/common/extenddatas", {
            data: { "codes": codes },
            async: false,
            success: function (config, data) {
                returndata = data;
            }
        });
        return returndata;
    },
    /*获取无参数数据返回*/
    simplifySyncJsonGet: function (api, data) {
        var returndata = {};
        //取得用户的实际信息
        EWinsBase.json(api, {
            data: data,
            async: false,
            success: function (config, data) {
                returndata = data;
            }
        });
        return returndata;
    },
    uploadFiles: function (url, options) {
        EWinsBase.json("api/SystemSupport/User/SaveFiles", {
            data: options.data,
            type: "POST",
            async: false,
            usedCache: false,
            processData: false,
            contentType: false,
            success: function (config, data) {
                if (options.success)
                    options.success(options.config, data);
            }
        })
    },
    get: function (url, data, callback) {
        var returndata = {};
        data["token"] = EWinsBase.Token;
        $.ajax({
            url: EWinsBase.__curHostAddress + url,
            data: data,
            async: false,
            dataType: "text",
            success: function (result) {
                returndata = result;
                if (callback)
                    callback(result);
            },
        });
        return returndata;
    },
    get: function (url, callback) {
        var returndata = {};
        var postdata = {};
        postdata["token"] = EWinsBase.Token;
        $.ajax({
            url: EWinsBase.__curHostAddress + url,
            data: postdata,
            async: false,
            dataType: "text",
            success: function (result) {
                returndata = result;
                if (callback)
                    callback(result);
            },
        });
        return returndata;
    },
    ajax: function (option) {
        option.data["token"] = EWinsBase.Token;
        $.ajax({
            url: EWinsBase.__curHostAddress + option.url,
            type: option.type,
            data: option.data,
            async: option.async,
            cache: option.cache,
            dataType: option.dataType,
            success: function (data) {
                if (option.success)
                    option.success(data);
            }
        });
    },
    /*构建下拉框数据*/
    createSelOptionHtml: function (ctl, data, displayField, valueField, isShowEmptyline) {
        //取得用户的实际信息
        var html = ""
        if (isShowEmptyline) {
            html = " <option value=''>请选择</option>";
        }

        for (i in data) {
            var o = data[i];
            html += " <option value='" + o[valueField] + "'>" + o[displayField] + "</option>"
        }
        $(ctl).html(html);
    },
    createSelOptionHtmlExcs: function (ctl, data, displayField, valueField, excsField, isShowEmptyline) {
        //取得用户的实际信息
        var html = ""
        if (isShowEmptyline) {
            html = " <option value=''>请选择</option>";
        }

        for (i in data) {
            var o = data[i];
            html += " <option value='" + o[valueField] + "' data-excs" + excsField + "='" + o[excsField] + "'>" + o[displayField] + "</option>"
        }

        if (!EWinsBase.isNullOrEmpty(excsField)) {
            $(ctl).data("excs", excsField);
        }
        $(ctl).html(html);
    },
    /*数据格式化操作，目前只支持日期时间格式化*/
    formatData: function (data, formatter) {
        if (formatter == undefined || formatter == null) return data;
        //目前只支持日期时间格式化
        //var d = data.replace(/-/g, "/").replace(/T/g, " ");
        //var date = new Date(d);
        //return date.Format(formatter);
        var d = eval('new ' + data.substr(1, data.length - 2));
        return d.Format(formatter);
    },
    getDataModel: function (ctls, dataSign) {
        if (dataSign == undefined || dataSign == "")
            dataSign = "id";
        var data = {};
        //var tags = ctls.getElementsByTag("");
        //for (var i = 0; i < tags.length; i++) {
        //    if (tags[i].id != "") {
        //        data[$(tags[i]).attr("id")] = $(tags[i]).val();
        //    }
        //}
        ctls.each(function (i, o) {
            data[$(o).data(dataSign)] = $(o).val();
        });
        return data;
    },
    setDataModel: function (ctls, data, dataSign) {
        if (data == undefined || data == null) return;
        if (dataSign == undefined || dataSign == "")
            dataSign = "id";
        ctls.each(function (i, o) {
            // debugger;
            var curdata = data[$(o).data(dataSign)] + "";
            if (curdata.indexOf("/Date(") >= 0) { 
                curdata = $.ParseDate(curdata);//EWinsBase.formatData(curdata, "yyyy-MM-dd hh:mm:ss");
            }
            if (curdata != "undefined") {
                if ($(o).context.tagName == "SPAN" || $(o).context.tagName == "LABEL" || $(o).context.tagName == "DIV" || $(o).context.tagName == "P") {
                    $(o).html(curdata == "null" ? "" : curdata);
                }
                //else if ($(o).attr("type") == "checkbox") { }
                else if ($(o).context.type == "checkbox" || $(o).context.type == "radio")
                {  //2020-03-12 mk新增单选，复选判断
                    var cbxName = $(o).attr("name");
                    $("input[name=" + cbxName+"]").each(function () { //遍历所有复选框
                        if ($(this).val() == curdata) {
                            $(this).prop('checked', true);
                        }
                    });
                }
                else {
                    $(o).val(curdata == "null" ? "" : curdata);
                }
            }

        });
    },
    //setDataModel: function (ctls, data, dataSign) {
    //    if (data == undefined || data == null) return;
    //    if (dataSign == undefined || dataSign == "")
    //        dataSign = "id";
    //    ctls.each(function (i, o) {
    //       // debugger;
    //            var curdata = data[$(o).data(dataSign)] + "";
    //        if (curdata.indexOf("/Date(") >= 0)
    //            curdata = $.ParseDate(curdata);//EWinsBase.formatData(curdata, "yyyy-MM-dd hh:mm:ss");
    //            if (curdata != "undefined") {
    //                if ($(o).context.tagName == "SPAN" || $(o).context.tagName == "LABEL" || $(o).context.tagName == "DIV" || $(o).context.tagName == "P") {
    //                    $(o).html(curdata == "null" ? "" : curdata);
    //                }
    //                    //else if ($(o).attr("type") == "checkbox") { }
    //                else
    //                    $(o).val(curdata == "null" ? "" : curdata);
    //            }
            
    //    });
    //},
    ClearPageData: function (ctls) {
        ctls.each(function (i, o) {
            if ($('#ParentId').attr('type') == "checkbox" || $('#ParentId').attr('type') == "radio")
                $(o).attr("checked", 'false');
            else if ($('#ParentId').attr('type') != "hidden")
                $(o).val("");
        });
    },

    //    getDataModel: function (ctls) {
    //        var data = {};
    //        var tags = ctls.getElementsByTagName("input");
    //        for (var i = 0; i < tags.length; i++) {
    //            if (tags[i].id != "") {
    //                data[$(tags[i]).attr("id")] = $(tags[i]).val();
    //            }
    //        }
    //        //ctls.each(function (i, o) {
    //        //    EWinsBase.alert(i)
    //        //    data[$(o).id] = $(o).val();
    //        //});
    //        return data;
    //    },
    //ClearPageData: function (ctls) {
    //    var tags = ctls.getElementsByTagName("input");
    //    for (var i = 0; i < tags.length; i++) {
    //        if (tags[i].id != "") {
    //            $(tags[i]).val("");
    //        }
    //    }
    //}

    SaveDiagData: function (objId, actionName, webdata) {
        if (EWinsBase.validate(objId)) {
            if (webdata == undefined || webdata == "")
                var data = EWinsBase.getDataModel($("#" + objId + " [data-id]"));
            else
                data = webdata;
            EWinsBase.json("?myaction=" + actionName, {
                data: data,
                type: "POST",
                async: false,
                success: function (config, data) {
                    EWinsBase.alert(data.msg);
                    window.location.reload();
                },
                error: function (error) {
                    //window.location.reload();
                }
            });
        }
        hideDiag(objId);
    },
    showDiag: function (objid) {
        var obj = $("#" + objid);
        obj.show();
        EWinsBase.ClearPageData($("#" + objid + " [data-id]"));
        document.getElementById("bgdiv").style.display = "block";
        document.getElementById("bgdiv").style.height = document.body.scrollHeight + "px";
    },
    showDiag_DoNotClearPageData: function (objid) {
        var obj = $("#" + objid);
        obj.show();
        document.getElementById("bgdiv").style.display = "block";
        document.getElementById("bgdiv").style.height = document.body.scrollHeight + "px";
    },
    hideDiag: function (objid) {
        var obj = $("#" + objid);
        obj.hide();
    },
    showDiagWithId: function (objId, ActionSign, conValue) {
        EWinsBase.json("?myaction=getpageinfo&ActionSign=" + ActionSign, {
            data: { "keyvalue": conValue },
            type: "POST",
            async: false,
            success: function (config, data) {
                if (ActionSign == "celue") {
                    //$("#LS_MIN").val(data.Result.SettingDetaileEntity.LS_MIN);

                    EWinsBase.setDataModel($("#" + objId + " [data-id]"), data.Result.SettingDetaileEntity);
                    EWinsBase.setDataModel($("#" + objId + " [data-id]"), data.Result.MP_StrategySettingEntity);
                    var ModeOption = document.getElementsByName("ModeOption");
                    for (var i = 0; i < ModeOption.length; i++) {
                        if ((data.Result.MP_StrategySettingEntity.ModeOption + "").indexOf(ModeOption[i].value) > 0)
                            ModeOption[i].checked = true;
                        else
                            ModeOption[i].checked = false;
                    }
                    //if(data.Result.ModeOption.indexOf("LJXXF") > -1)

                }
                else
                    EWinsBase.setDataModel($("#" + objId + " [data-id]"), data.Result)
            },
            error: function (error) {
                //window.location.reload();
            }
        })
        var obj = $("#" + objId);
        obj.show();
        document.getElementById("bgdiv").style.display = "block";
        document.getElementById("bgdiv").style.height = document.body.scrollHeight + "px";
    },
    delDiagWithId: function (ActionSign, conValue) {
        EWinsBase.json("?myaction=del&ActionSign=" + ActionSign, {
            data: { "keyvalue": conValue },
            type: "POST",
            async: false,
            success: function (config, data) {
                if (data.Status == 1) {
                    EWinsBase.alert(data.msg, function () { location.reload(); });//删除成功后刷新页面
                }
                else
                    EWinsBase.alert(data.msg);
            },
            error: function (error) {
                //window.location.reload();
            }
        })
    },
    alert: function (msg, callback) {
        if ($("#PopupWindow").attr("id") != undefined) {
            $("#PopupWindow").show();
            $("#bgdiv").height($(document.body).height())
            $("#bgdiv").show();
            $("#PopupWindow_content").html(msg);
            $(".widget_button").click(function () {
                $("#PopupWindow").hide();
                $("#bgdiv").hide();
                //if (dataSign == undefined || dataSign == "")
                //    dataSign = "id";
                //return true;
                if (callback)
                    callback();
            });
        }
        else if (top.layui && top.layui.layer) {
            top.layui.layer.alert(msg, { time: false, btn: '确定' });
        }
        else
        {
            //top.layer.msg(msg);
            layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.alert(msg, { time: false, btn: '确定' });
            });
            //window.alert(msg);
        }
        return false;
    },
    ValidateToken: function (data) {
        if (data.code == 13) {
            layer.confirm('<span style="color:red;font-size:18px;">' + data.msg + ' 是否立刻重新登录？</span>', {
                btn: ['确定', '取消']
            }, function (index, layero) {
                layer.closeAll('dialog');  //加入这个信息点击确定 会关闭这个消息框
                top.location.href = EWinsBase.__curHostAddress + "login";
            }
    );
        }
    },
    validate: function (objid) {
        var ctls = $("#" + objid + " [valid]");
        var relValue = true;
        ctls.each(function (i, o) {
            var valid = $(o).attr("valid");
            if (valid.indexOf("Required") >= 0 && $(o).val().trim() == "") {
                EWinsBase.alert($(o).attr("placeholder"));
                window.setTimeout(function () { $(o).focus(); }, 0);
                relValue = false;
                return false;
            }
            //日期格式验证
            var DATE_FORMAT = /^[0-9]{4}-[0-1]?[0-9]{1}-[0-3]?[0-9]{1}$/;
            var DATE_FORMAT2 = /^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])\s+(20|21|22|23|[0-1]\d):[0-5]\d$/;
            if (valid.indexOf("date") >= 0 && (!DATE_FORMAT.test($(o).val()) && !DATE_FORMAT2.test($(o).val())) && $(o).val().trim() != "") {
                EWinsBase.alert($(o).attr("placeholder").replace("请选择", "") + "输入不正确，不是正确的日期格式！");
                window.setTimeout(function () { $(o).focus(); }, 0);
                relValue = false;
                return false;
            }
            //手机格式验证
            DATE_FORMAT = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|145|147|149|198|199|166)+\d{8})$/;
            if (valid.indexOf("mobile") >= 0 && !DATE_FORMAT.test($(o).val()) && $(o).val().trim() != "") {
                EWinsBase.alert($(o).attr("placeholder").replace("请选择", "") + "输入不正确，不是正确的手机号码！");
                window.setTimeout(function () { $(o).focus(); }, 0);
                relValue = false;
                return false;
            }
            //电子邮箱格式验证
            DATE_FORMAT = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            if (valid.indexOf("email") >= 0 && !DATE_FORMAT.test($(o).val()) && $(o).val().trim() != "") {
                EWinsBase.alert($(o).attr("placeholder").replace("请选择", "") + "输入不正确，不是正确的电子邮箱！");
                window.setTimeout(function () { $(o).focus(); }, 0);
                relValue = false;
                return false;
            }
            //数字验证，正整数
            if (valid.indexOf("num") >= 0 && $(o).val().trim() != "") {
                if (isNaN($(o).val().trim())) {
                    EWinsBase.alert($(o).attr("placeholder").replace("请输入", "") + "输入不正确，不是正确的数字！");
                    window.setTimeout(function () { $(o).focus(); }, 0);
                    relValue = false;
                    return false;
                }
                else {
                    var curNum = parseFloat($(o).val().trim());
                    if (curNum <= 0) {
                        EWinsBase.alert($(o).attr("placeholder").replace("请输入", "") + "输入不正确，请输入大于0的正整数！");
                        window.setTimeout(function () { $(o).focus(); }, 0);
                        relValue = false;
                        return false;
                    }
                }

            }
        });
        return relValue;
    }
};
//$(function () {
//    EWinsBase.checkLoginState();
//});
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

String.prototype.trim = function () { //删除左右两端的空格　　

    return this.replace(/(^\s*)|(\s*$)/g, "");

}

function setCookie(c_name, value, expiredays) {
    var exdate = new Date()
    exdate.setDate(exdate.getDate() + expiredays)
    document.cookie = c_name + "=" + escape(value) +
        ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString());
}

//function setCookie(c_name, value) {
//    setCookie(c_mame, value, 60);
//}

function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length;
            return unescape(document.cookie.substring(c_start, c_end));
        }
    }
    return "";
}

if (EWinsBase.isNullOrEmpty(EWinsBase.Token) && location.href.indexOf("login") < 0 && location.href.toLowerCase().indexOf("doctor") < 0 && location.href.toLowerCase().indexOf("publicpages/medrecordquery") < 0) {
    EWinsBase.alert("登录凭证失效，请重新登录！");
    top.location.href = EWinsBase.__curHostAddress + "login";
}

String.prototype.isNullOrEmpty = function () {
    if (this == undefined
        || this == null
        || (typeof this == "string" && this.trim() == "")) {
        return true;
    }
    return false;
},

String.prototype.ToString = function (format) {
    if (!EWinsBase.isNullOrEmpty(this)) {
        var dateTime = new Date(parseInt(this.substring(6, this.length - 2)));
        if (this.indexOf('Date') < 0)
            dateTime = new Date(this);
        format = format.replace("yyyy", dateTime.getFullYear());
        format = format.replace("yy", dateTime.getFullYear().toString().substr(2));
        format = format.replace("MM", dateTime.getMonth() + 1)
        format = format.replace("dd", dateTime.getDate());
        format = format.replace("hh", dateTime.getHours());
        format = format.replace("mm", dateTime.getMinutes());
        format = format.replace("ss", dateTime.getSeconds());
        format = format.replace("ms", dateTime.getMilliseconds())
    }
    return format;
};
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", 'i');
    var r = window.location.search.substr(1).match(reg);
    if (r !== null) return unescape(r[2]); return "";
}

//if (navigator.userAgent.toLowerCase().indexOf("chrome") == -1) {
//    alert('请使用谷歌浏览器，否则相关功能将不能正常使用！'); location.href = "http://www.baidu.com";
//} else {
//}
function ConvertDateToString(date, format) {
    format = format.replace("yyyy", date.getFullYear());
    format = format.replace("MM", padZeros(date.getMonth() + 1));
    format = format.replace("dd", padZeros(date.getDate()));
    format = format.replace("HH", padZeros(date.getHours()));
    format = format.replace("mm", padZeros(date.getMinutes()));
    format = format.replace("ss", padZeros(date.getSeconds()));

    return format;
}

function padZeros(number, len) {
    var str = '' + number;
    if (len == undefined) len = 2;
    while (str.length < len) {
        str = '0' + str;
    }
    return str;
}
function getTodayString(fmt) {
    if (fmt == "D") {
        return ConvertDateToString(new Date(), "yyyy-MM-dd");
    }
    else {
        return ConvertDateToString(new Date(), "yyyy-MM-dd HH:mm:ss");
    }
}
function closediag() {
    layer.closeAll();
}

//弹出层（URL页面，非DIV）初始化
function PopupPageInit() {
    $(".layui-edit-btn-div").css("top", (parseInt(GetQueryString("height")) - 108) + "px");
    $(".layui-form-edit").css("width", parseInt(GetQueryString("width")) + "px");
    $(".layui-form-edit").css("height", parseInt(GetQueryString("height")) - 108 + "px");
}

if (!Array.prototype.forEach) {
    Array.prototype.forEach = function forEach(callback, thisArg) {
        var T, k;
        if (this == null) {
            throw new TypeError("this is null or not defined");
        }
        var O = Object(this);
        var len = O.length >>> 0;
        if (typeof callback !== "function") {
            throw new TypeError(callback + " is not a function");
        }
        if (arguments.length > 1) {
            T = thisArg;
        }
        k = 0;
        while (k < len) {
            var kValue;
            if (k in O) {
                kValue = O[k];
                callback.call(T, kValue, k, O);
            }
            k++;
        }
    };
}

//设置分页大小
var mylimit = parseInt(($(window).height() - 130) / 40);

function GetOrganList() {
    $('#OrganID').select2(); 
    EWinsBase.json("api/SystemSupport/OrganInfo/Getall", {
        data: { page: 1, limit: 100 },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (val, index) {
                    $("#OrganID").append("<option value=" + val.OrganID + ">" + val.OrganName + "</option>");
                });
               
                $("#OrganID").val(cookie.GetEMRUserCookie("api_token", "ORGANID")).trigger('change');
            }
        },
    });
}

function GetOrganSelect() {
    $('#OrganID').select2();
    EWinsBase.json("api/SystemSupport/OrganInfo/Getall", {
        data: { page: 1, limit: 100 },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (val, index) {
                    $("#OrganID").append("<option value=" + val.OrganID + ">" + val.OrganName + "</option>");
                });
                $("#OrganID").val(cookie.GetEMRUserCookie("api_token", "ORGANID")).trigger('change');
            }
        },
    });
}
//通过字典英文名获取子类填充select2
function CreateSelectOptionFromCodeDict2(obj, dictKey) {
    obj.select2();
    EWinsBase.json("api/SystemSupport/CodeDict/GetChildByEName", {
        data: { EName: dictKey },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.DictCode + ">" + item.DictName + "</option>");
                });
                obj.trigger('change');
            }
        },
    });
}
//用户性别单选按钮
function CreateRadiosFromCodeDict(obj,radioName, dictKey) {
    EWinsBase.json("api/SystemSupport/CodeDict/GetChildByEName", {
        data: { EName: dictKey },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                var outHtml = "";
                data.data.forEach(function (item, index) {
                    outHtml += '<input type="radio" name="' + radioName + '" value="' + item.DictCode + '" title="' + item.DictName + '">' + item.DictName + '';
                });
                obj.html(outHtml);
            }
        },
    });
}

//获取用户select2
function GetUserSelect(obj, data) {
    obj.select2();
    EWinsBase.json("api/SystemSupport/User/GetUserListByUserFilter", {
        data: data,
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.userid + "  data-UserCode='" + item.usercode + "'>" + item.username + "</option>");
                });
                obj.trigger('change');
            }
        }
    });
}

