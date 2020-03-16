using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMR.Data.Domain
{
    /// <summary>
    /// 分页实体，包含分页存储过程中所含的部分字段。一般存在于获取分页数据的业务逻辑中。
    /// </summary>
    public partial class PagingEntity : PagingEntity_base
    {
        public static readonly int MIN_PAGE_COUNT = 1;

        private string fields = "*";

        private string primaryKey = "id";

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QueryString { get; set; }

        /// <summary>
        /// 排序 如（ID DESC,createtime desc）
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        /// <summary>
        /// 要查询的字段
        /// </summary>
        public string Fields
        {
            get { return fields; }
            set { fields = value; }
        }
    }

    /// <summary>
    /// 分页实体基类，包含当前页码、显示条数等信息。一般存在于返回前台的数据集中
    /// </summary>
    public class PagingEntity_base
    {
        private const int MIN_PAGE_COUNT = 1;
        private int curPage = 1;

        private int pageSize = 10;

        private int dataCount;

        private int? _pageCount;

        /// <summary>
        /// 当前页码，默认1
        /// </summary>
        public int CurPage
        {
            get { return curPage; }
            set { curPage = value; }
        }

        /// <summary>
        /// 每页显示条数，默认10条
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }

            set
            {
                pageSize = value;
                _pageCount = null;
            }
        }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int DataCount
        {
            get { return dataCount; }

            set
            {
                dataCount = value;
                _pageCount = null;
            }
        }

        /// <summary>
        /// 页数，自动计算
        /// </summary>
        public int PageCount
        {
            get
            {
                if (_pageCount.HasValue)
                {
                    return _pageCount.Value;
                }

                if (this.DataCount == 0 || this.PageSize == 0)
                {
                    return MIN_PAGE_COUNT;
                }

                int pageCount = this.DataCount / this.PageSize;
                pageCount = (this.DataCount % this.PageSize == 0) ? pageCount : pageCount + 1;

                _pageCount = (pageCount == 0) ? MIN_PAGE_COUNT : pageCount;

                return _pageCount.Value;
            }
        }

        public string CreateHtmlPage(string FormQueryString)
        {
            string strReturn = "";
            strReturn += "<div class=\"page\">";
            strReturn += "<span>共" + DataCount + "条记录</span>";
            strReturn += "<span>共" + PageCount + "页</span>";
            var maxShowPage = CurPage + 5 > PageCount ? PageCount : CurPage + 5;
            var minShowPage = CurPage - 5 > 1 ? CurPage - 5 : 1;
            FormQueryString += FormQueryString.Contains("?") ? "&page=" : "?page=";
            if (CurPage > 6)
                strReturn += "<a href=\"" + FormQueryString + "1\">首页</a>";
            if (CurPage > 1)
                strReturn += "<a href=\"" + FormQueryString + (CurPage - 1) + "\">上一页</a>";
            for (var i = minShowPage; i <= maxShowPage; i++)
            {
                strReturn += "<a href=\"" + FormQueryString + i + "\"" + (i == CurPage ? " class=\"cur\"" : "") + ">" + i + "</a>";
            }
            if (CurPage < PageCount)
                strReturn += "<a href=\"" + FormQueryString + (CurPage + 1) + "\">下一页</a>";
            if (PageCount > maxShowPage)
                strReturn += "<a href=\"" + FormQueryString + PageCount + "\">尾页></a>";
            return strReturn+"</div>";
        }
    }
}