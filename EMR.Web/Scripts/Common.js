
//用于select2的多选取值
function getMultiSelectVal(id) {
    return $.map($("#" + id).select2('data'), function (value) {
        return value.id;
    }).join(",");
}
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)",'i');
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return "";
}
//获得父框架的参数
function NewGetQueryString(key) {
    var cur = GetQueryString(key);
    if (EWinsBase.isNullOrEmpty(cur))
        cur = parent.GetQueryString(key);
    return cur;
}

//代替锚滚动
function naver(id) {
    var obj = $("#" + id);
    var oPos = obj.offset().top;
    window.scrollTo(0, oPos - 36);
}

//用于select2的多选取text
function getMultiSelectText(id) {
    return $.map($("#" + id).select2('data'), function (value) {
        return value.text;
    }).join(",");
}

//通过病区判断获得科室获得病区，isInpatient=0:科室，isInpatient=1:病区
function DrugResistQuarSel_1(obj, isInpatient, extraParams, addOption,selType) { 
    var url = EWinsBase.__curHostAddress + "api/Infection/CommonHelper/GetDrugResistQuarSelect";
    AjaxSelect2(obj, url, extraParams, addOption,
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, isInpatient: isInpatient, selType: selType }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) { return $(data).map(function () { return { id: this.value, text: this.text }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}

//环境检测结果页面下拉框
function EnvSel_1(obj, isInpatient, extraParams, addOption) {
    var url = EWinsBase.__curHostAddress + "api/Infection/CommonHelper/GetEnvSelect";
    AjaxSelect2(obj, url, extraParams, addOption,
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, isInpatient: isInpatient }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) { return $(data).map(function () { return { id: this.value, text: this.text }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}

//手卫生依从性页面下拉框
function HandHygieneSel_1(obj, isInpatient, extraParams, addOption) {
    var url = EWinsBase.__curHostAddress + "api/Infection/CommonHelper/GetHandHygieneSelect";
    AjaxSelect2(obj, url, extraParams, addOption,
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, isInpatient: isInpatient }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) { return $(data).map(function () { return { id: this.value, text: this.text }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}



//通过病区判断获得科室获得病区，isInpatient=0:科室，isInpatient=1:病区
function CreateSelectOptionFromUser(obj, extraParams, addOption) {
    var url = EWinsBase.__curHostAddress + "api/Public/UserInfo/GetList";
    AjaxSelect2(obj, url, extraParams, addOption,
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) { return $(data).map(function () { return { id: this.UserID, text: this.UserName }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}
//通过病区判断获得科室获得病区，isInpatient=0:科室，isInpatient=1:病区
function CreateSelectOptionFromDeptInfo(obj, isInpatient, extraParams, addOption) {
    var url = EWinsBase.__curHostAddress + "api/Public/DeptInfo/GetDeptInfoByInpatient";
    AjaxSelect2(obj, url, extraParams, addOption,
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, isInpatient: isInpatient }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) { return $(data).map(function () { return { id: this.DeptID, text: this.DeptName }; }).get();});//select2的参数形式{id:id,text:text},在这里转换一下
}
//创建疾病诊断/手术操作下拉框 valueSign: 1 value绑定诊断ID(DiagnosisId)；2 value绑定疾病代码编码(DiagnosisCode)；3 value绑定ICD代码(ICDCode)；
function CreateSelectOptionFromDiagnosis(obj, extraParams,valueSign) {
    var url = EWinsBase.__curHostAddress + "api/Doctor/OperationRecord/GetDiagnosisList";
    if (!valueSign)
        valueSign = 1;
    AjaxSelect2(obj, url, extraParams,"",
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term }; },//ajax需要的参数，term.term是取输入的关键词，isInpatient是病区判断
        function (data) {
            return $(data).map(function () {
                if (valueSign == 1)
                    return { id: this.DiagnosisId, text: this.DiagnosisName };
                else if (valueSign == 2)
                    return { id: this.DiagnosisCode, text: this.DiagnosisName };
                else if (valueSign == 3)
                    return { id: this.ICDCode, text: this.DiagnosisName };

            }).get();
        });//select2的参数形式{id:id,text:text},在这里转换一下
}
//select2绑定用户分组
function CreateSelectOptionFromRole(obj, extraParams) {
    obj.select2();
    //select2默认宽加了!important,所以要添加一个!important的宽覆盖上去：{ width: 540px!important" }
    if (typeof (extraParams) != "undefined") {
        $.each(extraParams, function (i, val) {
            obj.siblings().css("cssText", i + ":" + val);
        });
    }
    EWinsBase.json("api/SystemSupport/Role/GetAll", {
        data: { page: 1, limit: 100 },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.RoleID + ">" + item.RoleNAME + "</option>");
                });
                obj.trigger('change');
            }
        }
    });
}
//select2绑定医疗组
function CreateSelectOptionFromDoctorGroup(obj, extraParams, addOption) {
    var url = EWinsBase.__curHostAddress + "api/Public/DoctorGroup/Getall";
    AjaxSelect2(obj, url, extraParams,"",
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, page: 1, limit:10 }; },//ajax需要的参数，term.term是取输入的关键词,limit是单次最多显示多少数据
        function (data) { return $(data).map(function () { return { id: this.DoctorGroupId, text: this.GroupName }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}
//通过字典英文名获取子类填充select2
function CreateSelectOptionFromCodeDict(obj, ParentDictNameEN,extraParams,addOption) {
    var url = EWinsBase.__curHostAddress + "api/SystemSupport/CodeDict/GetAll";
    AjaxSelect2(obj, url, extraParams, "",
        function (term) { return { Token: cookie.GetEMRUserCookie("api_token", "Token"), keyword: term.term, ParentDictNameEN: ParentDictNameEN, page:1, limit: 20 }; },//ajax需要的参数，term.term是取输入的关键词,ParentDictNameEN是父类的英文名,limit是单次最多显示多少数据
        function (data) { return $(data).map(function () { return { id: this.DictCode, text: this.DictName }; }).get(); });//select2的参数形式{id:id,text:text},在这里转换一下
}
//通过字典英文名获取子类填充普通下拉框
function BindSelectOptionFromCOdeDict(obj, ParentDictNameEN) {
    EWinsBase.json("api/SystemSupport/CodeDict/GetAll", {
        data: { page: 1, limit: 20, ParentDictNameEN: ParentDictNameEN },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.DictCode + ">" + item.DictName + "</option>");
                });
                
            }
        }
    });
}


//select2结构化模板
function CreateSelectStructuredTemplate(obj, IsCategory, extraParams) {
    obj.select2tree();
    //select2默认宽加了!important,所以要添加一个!important的宽覆盖上去：{ width: 540px!important" }
    if (typeof (extraParams) != "undefined") {
        $.each(extraParams, function (i, val) {
            obj.siblings().css("cssText", i + ":" + val);
        });
    }
    EWinsBase.json("api/Public/StructuredTemplate/GetTreeNode", {
        data: { page: 1, limit: 100, IsCategory: IsCategory },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.id + ">" + item.name + "</option>");
                    getChildren(item.children, obj);
                });
                obj.trigger('change');
            }
        }
    });
}

function CreateSelectFormEmrTemplate(obj, IsCategory, extraParams) {
    obj.select2tree();
    //select2默认宽加了!important,所以要添加一个!important的宽覆盖上去：{ width: 540px!important" }
    if (typeof (extraParams) != "undefined") {
        $.each(extraParams, function (i, val) {
            obj.siblings().css("cssText", i + ":" + val);
        });
    }
    EWinsBase.json("api/Public/FormEmrTemplate/GetTreeNode", {
        data: { page: 1, limit: 100, IsCategory: IsCategory },
        type: "POST",
        async: false,
        usedCache: false,
        success: function (config, data) {
            if (data.data) {
                data.data.forEach(function (item, index) {
                    obj.append("<option value=" + item.id + ">" + item.name + "</option>");
                    getChildren(item.children, obj);
                });
                obj.trigger('change');
            }
        }
    });
}
/** 
 * selec2动态ajax获取值
 * @desc 根据目标对象获取运营商
 * @param {jquery} $obj select的juqery对象
 * @param {string} url ajax地址
 * @param {array} extraParams 自定义的css
 * @param {array} addOption 需要另外添加的项  参考：[{ id: "", text: "全部" }]
 * @param {function(array)} datef ajax需要的参数
 * @param {function(array)} binf 用于将返回参数修改伟select2需要的参数类型
 */
function AjaxSelect2($obj, url, extraParams, addOption, datef, binf) {
    $obj.select2({
        ajax: {
            cache: true,//开启缓存
            url: url,//ajax地址
            data: datef,//ajax参数
            processResults: function (json, params) {
                //返回数据的处理
                //将接收到的JSON格式的字符串转换成JSON数据
                var data = JSON.parse(json).data == null ? [] : JSON.parse(json).data;
                var rel = [];


                //如果addOption是数组
                if ($.isArray(addOption)) {
                    //判断数组中是否包含id和text的值
                    $.each(addOption, function (i, val) {
                        if (val.hasOwnProperty("id") && val.hasOwnProperty("text")) {
                            //将另加的数组添加到下拉中
                            rel.push({ id: val.id, text: val.text });
                        }
                    });
                }


                if (data.length == 0) {   //如果没有查询到数据，将会返回空串
                    if (!$.isArray(addOption)) {
                        //如果没有新添的项目，返回无符合条件记录
                        return {
                            results: [{ id: params.term, text: "无符合条件记录", tag: true }],
                            pagination: { more: false }
                        };
                    } else {
                        //如果有新添的项目，返回新添的项目
                        return {
                            results: rel,
                            pagination: { more: false }
                        };
                    }

                } else {
                    params.page = params.page || 1;
                    params.pageSize = params.pageSize || 10;
                    var more = (params.page * params.pageSize) < data.total; //用来判断是否还有更多数据可以加载                    
                    if (binf != '' && typeof binf == "function") {
                        $(binf(data)).each(function (i, val) { rel.push(val); });
                    }
                    else {
                        $.each(data, function (i, n) {//如果返回的数组符合select2要求，binf留空
                            rel.push({ id: n.id, text: n.name });
                        });
                    }
                    return {
                        results: rel,
                        pagination: { more: more }
                    };
                }
            }
        }
    });
    if (typeof (extraParams) != "undefined") {
        $.each(extraParams, function (i, val) {
            $obj.siblings().css("cssText", i + ":" + val);
        });
    }
}

//添加子类
function getChildren(children,obj) {
    if (children.length > 0) {
        children.forEach(function (item, index) {
            obj.append("<option value=" + item.id + " parent=" + item.pid + ">" + item.name + "</option>");
            getChildren(item.children, obj);
        });
    }
}
//html标签转义
function HTMLEncode(html) {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}
//html标签反转义
function HTMLDecode(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output ? output.replace(/&((g|l|quo)t|amp|#39|nbsp);/g, function (m) {
        return {
            '&lt;': '<',
            '&amp;': '&',
            '&quot;': '"',
            '&gt;': '>',
            '&#39;': "'",
            '&nbsp;': ' '
        }[m];
    }) : '';
} 

//两个时间相差天数 兼容firefox chrome
function datedifference(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式  
    var dateSpan,
        tempDate,
        iDays;
    sDate1 = Date.parse(sDate1);
    sDate2 = Date.parse(sDate2);
    dateSpan = sDate2 - sDate1;
    //dateSpan = Math.abs(dateSpan);
    iDays = Math.floor(dateSpan / (24 * 3600 * 1000));
    return iDays;
}


//增加月 
function AddMonths(sDate, value) {
    var date = new Date(sDate);
    date.setMonth(date.getMonth() + value);
    return date;
}
//增加天 
function AddDays(sDate, value) {
    var date = new Date(sDate);
    date.setDate(date.getDate() + value);
    return date;
}
//增加时
function AddHours(sDate, value) {
    var date = new Date(sDate);
    date.setHours(date.getHours() + value);
    return date;
}

//当前时间横杠格式的日期
function currentTime(Spacer, sDate) {
    Spacer = Spacer === undefined ? "-" : Spacer;
    var now = sDate === undefined ? new Date() : new Date(sDate);
    
    var year = now.getFullYear(); //年 
    var month = now.getMonth() + 1; //月 
    var day = now.getDate(); //日 
    var hh = now.getHours(); //时 
    var mm = now.getMinutes(); //分 
    var ss = now.getSeconds(); //秒
    var clock = year + Spacer;
    if (month < 10) clock += "0";
    clock += month + Spacer;
    if (day < 10) clock += "0";
    clock += day + " ";
    if (hh < 10) clock += "0";
    clock += hh + ":";
    if (mm < 10) clock += '0';
    clock += mm + ":";
    if (ss < 10) clock += '0';
    clock += ss;
    return (clock);
} 
