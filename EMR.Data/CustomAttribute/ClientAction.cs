using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMR.Data.CustomAttribute
{
    public enum ClientAction
    {
        /// <summary>
        /// 弹出框（输出弹框提示，一般用于按钮操作）
        /// </summary>
        MessageBox=1,

        /// <summary>
        /// 输出消息（输出AJAX消息回馈，一般用于前端AJAX异步操作）
        /// </summary>
        ResponseAjaxMsg=2,

        /// <summary>
        /// 输出脚本（用于自定义脚本输出，一般用于弹框+跳转）
        /// </summary>
        ResponseJs=3,

        /// <summary>
        /// 输出内容（只输出失败的提示，一般用于获取数据等操作）
        /// </summary>
        ResponseContent = 4,

    }
}