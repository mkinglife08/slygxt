using System.Web;
using System.Web.Optimization;

namespace EMR.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/layui/js").Include(
                      "~/Scripts/jquery-1.10.2.min.js"
                      ,"~/Scripts/layui/layui.js"
                      , "~/Scripts/zTree/js/jquery.ztree.core.js"
                      ,"~/Scripts/index.js"
                      ,"~/Scripts/EMRBase.js"
                      ,"~/Scripts/EWins.Base.js"
                      ,"~/Scripts/select2.min.js"
                      , "~/Scripts/select2tree.js"
                      , "~/Scripts/Common.js"
                      , "~/Scripts/Extend.js"));

            bundles.Add(new StyleBundle("~/layui/css").Include(
                 "~/Content/iconfont/iconfont.css"
               , "~/Content/common.css"
                , "~/Scripts/layui/css/layui.css" 
                , "~/Content/style.css"
                , "~/Content/login.css"
                , "~/Scripts/zTree/zTreeStyle/zTreeStyle.css"
                , "~/Content/select2.min.css"));



            bundles.Add(new ScriptBundle("~/ueditor/js").Include(
                "~/Scripts//ueditor/ueditor.config.js"
                , "~/Scripts//ueditor/ueditor.all.min.js"
                ));
        }
    }
}
