
using System;
using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Models
{
    /// <summary>
    ///系统支持 GI_SYSAPPParam 系统业务参数信息 实体类
    /// </summary>
    [Serializable]
    public partial class GI_SYSAPPParam
    {
        /// <summary>
        /// 参数序号
        /// </summary>
        [Display(Name = "参数序号")]
        [StringLength(20)]
        public virtual string ParamID { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        [Display(Name = "机构代码")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Display(Name = "中文名称")]
        [StringLength(200)]
        public virtual string ParamName { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Display(Name = "英文名称")]
        [StringLength(50)]
        public virtual string ParamNameEN { get; set; }

        /// <summary>
        /// 系统序号
        /// </summary>
        [Display(Name = "系统序号")]
        [StringLength(20)]
        public virtual string SysID { get; set; }

        /// <summary>
        /// 参数内容
        /// </summary>
        [Display(Name = "参数内容")]
        [StringLength(500)]
        public virtual string ParamContent { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        [Display(Name = "备注说明")]
        [StringLength(200)]
        public virtual string ParamNote { get; set; }

        /// <summary>
        /// 存取类别
        /// </summary>
        [Display(Name = "存取类别")]
        public virtual int? ParamType { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

    }
    /// <summary>
    ///系统支持 GI_OrganInfo  组织机构信息表 实体类
    /// </summary>
    [Serializable]
    public partial class GI_OrganInfo
    {
        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 父类序号
        /// </summary>
        [Display(Name = "父类序号")]
        [StringLength(20)]
        public virtual string ParentID { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [Display(Name = "机构名称")]
        [StringLength(100)]
        public virtual string OrganName { get; set; }

        /// <summary>
        /// 机构简称
        /// </summary>
        [Display(Name = "机构简称")]
        [StringLength(20)]
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 机构图标
        /// </summary>
        [Display(Name = "机构图标")]
        [StringLength(100)]
        public virtual string OrganIcon { get; set; }

        /// <summary>
        /// 机构地址
        /// </summary>
        [Display(Name = "机构地址")]
        [StringLength(100)]
        public virtual string Address { get; set; }

        /// <summary>
        /// 机构电话
        /// </summary>
        [Display(Name = "机构电话")]
        [StringLength(100)]
        public virtual string OrganTel { get; set; }

        /// <summary>
        /// 联系人员
        /// </summary>
        [Display(Name = "联系人员")]
        [StringLength(20)]
        public virtual string OrganUser { get; set; }

        /// <summary>
        /// 机构介绍
        /// </summary>
        [Display(Name = "机构介绍")]
        [StringLength(2000)]
        public virtual string OrganNote { get; set; }

        /// <summary>
        /// 启用日期
        /// </summary>
        [Display(Name = "启用日期")]
        public virtual DateTime? StartDate { get; set; }

        /// <summary>
        /// 终止日期
        /// </summary>
        [Display(Name = "终止日期")]
        public virtual DateTime? StopDate { get; set; }

        /// <summary>
        /// 末级判别0不是未级1未级
        /// </summary>
        [Display(Name = "末级判别")]
        public virtual int? IsLast { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_SerialInfo  系统主键编号 实体类
    /// </summary>
    [Serializable]
    public partial class GI_SerialInfo
    {
        /// <summary>
        /// 主键序号
        /// </summary>
        [Display(Name = "主键序号")]
        [StringLength(20)]
        public virtual string KeyID { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        [Display(Name = "机构代码")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 主键表名
        /// </summary>
        [Display(Name = "主键表名")]
        [StringLength(50)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 主键列名
        /// </summary>
        [Display(Name = "主键列名")]
        [StringLength(50)]
        public virtual string ColumnName { get; set; }

        /// <summary>
        /// 当前序号
        /// </summary>
        [Display(Name = "当前序号")]
        [StringLength(20)]
        public virtual string CurrentID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_CodeDict 公用代码字典 实体类
    /// </summary>
    [Serializable]
    public partial class GI_CodeDict
    {
        /// <summary>
        /// 字典序号
        /// </summary>
        [Display(Name = "字典序号")]
        [StringLength(20)]
        public virtual string DictID { get; set; }

        /// <summary>
        /// 代码序号
        /// </summary>
        [Display(Name = "父类序号")]
        [StringLength(20)]
        public virtual string ParentID { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        [Display(Name = "字典编码")]
        [StringLength(20)]
        public virtual string DictCode { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Display(Name = "中文名称")]
        [StringLength(100)]
        public virtual string DictName { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Display(Name = "英文名称")]
        [StringLength(100)]
        public virtual string DictNameEN { get; set; }

        /// <summary>
        /// 末级判别0不是未级1未级
        /// </summary>
        [Display(Name = "末级判别")]
        public virtual int? ISLast { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        [Display(Name = "显示排序")]
        public virtual int? DisplaySort { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

        /// <summary>
        /// 对应编码
        /// </summary>
        [Display(Name = "对应编码")]
        [StringLength(20)]
        public virtual string TheCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(500)]
        public virtual string Note { get; set; }

    }
    /// <summary>
    ///系统支持 GI_FunInfo  系统功能定义 实体类
    /// </summary>
    [Serializable]
    public partial class GI_FunInfo
    {
        /// <summary>
        /// 功能序号
        /// </summary>
        [Display(Name = "功能序号")]
        [StringLength(20)]
        public virtual string FUNID { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 父类序号
        /// </summary>
        [Display(Name = "父类序号")]
        [StringLength(20)]
        public virtual string ParentID { get; set; }

        /// <summary>
        /// 系统序号
        /// </summary>
        [Display(Name = "系统序号")]
        [StringLength(20)]
        public virtual string SYSID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [Display(Name = "功能名称")]
        [StringLength(50)]
        public virtual string FUNName { get; set; }

        /// <summary>
        /// 功能级别1一级2二级3三级
        /// </summary>
        [Display(Name = "功能级别")]
        public virtual int? FUNLevel { get; set; }

        /// <summary>
        /// 末级判别0不是1是
        /// </summary>
        [Display(Name = "末级判别")]
        public virtual int? IsLast { get; set; }

        /// <summary>
        /// 对应页面
        /// </summary>
        [Display(Name = "对应页面")]
        [StringLength(100)]
        public virtual string FUNPage { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [Display(Name = "备注信息")]
        [StringLength(100)]
        public virtual string FUNNtoe { get; set; }

        /// <summary>
        /// 功能图片
        /// </summary>
        [Display(Name = "功能图片")]
        [StringLength(50)]
        public virtual string FUNIcon { get; set; }

        /// <summary>
        /// 选中图片
        /// </summary>
        [Display(Name = "选中图片")]
        [StringLength(50)]
        public virtual string CheckIcon { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        [Display(Name = "显示排序")]
        public virtual int? DisplaySort { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_SYSAPPINFO  系统模块信息 实体类
    /// </summary>
    [Serializable]
    public partial class GI_SYSAPPINFO
    {
        /// <summary>
        /// 系统序号
        /// </summary>
        [Display(Name = "系统序号")]
        [StringLength(20)]
        public virtual string SYSID { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [Display(Name = "系统名称")]
        [StringLength(100)]
        public virtual string SYSName { get; set; }

        /// <summary>
        /// 系统简称
        /// </summary>
        [Display(Name = "系统简称")]
        [StringLength(10)]
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 默认标题
        /// </summary>
        [Display(Name = "默认标题")]
        [StringLength(20)]
        public virtual string DefaultTitle { get; set; }

        /// <summary>
        /// 默认页面
        /// </summary>
        [Display(Name = "默认页面")]
        [StringLength(100)]
        public virtual string defaultPage { get; set; }

        /// <summary>
        /// 系统图标
        /// </summary>
        [Display(Name = "系统图标")]
        [StringLength(200)]
        public virtual string SYSICON { get; set; }

        /// <summary>
        /// 系统说明
        /// </summary>
        [Display(Name = "系统说明")]
        [StringLength(200)]
        public virtual string SYSNote { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        [Display(Name = "显示排序")]
        public virtual int? DisplaySort { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_UserSYS  用户系统对照 实体类
    /// </summary>
    [Serializable]
    public partial class GI_UserSYS
    {
        /// <summary>
        /// 用户人员代码
        /// </summary>
        [Display(Name = "用户序号")]
        [StringLength(20)]
        public virtual string UserID { get; set; }

        /// <summary>
        /// 系统模块代码
        /// </summary>
        [Display(Name = "系统序号")]
        [StringLength(20)]
        public virtual string SYSID { get; set; }

        /// <summary>
        /// 是否默认1是0否
        /// </summary>
        [Display(Name = "是否默认")]
        public virtual int? IsDefault { get; set; }

    }
    /// <summary>
    ///系统支持 GI_RoleMember  分组用户对照 实体类
    /// </summary>
    [Serializable]
    public partial class GI_RoleMember
    {
        /// <summary>
        /// 分组序号
        /// </summary>
        [Display(Name = "分组序号")]
        [StringLength(20)]
        public virtual string RoleID { get; set; }

        /// <summary>
        /// 用户序号
        /// </summary>
        [Display(Name = "用户序号")]
        [StringLength(20)]
        public virtual string UserID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_RoleRight  系统分组权限 实体类
    /// </summary>
    [Serializable]
    public partial class GI_RoleRight
    {
        /// <summary>
        /// 分组编号
        /// </summary>
        [Display(Name = "分组编号")]
        [StringLength(20)]
        public virtual string RoleID { get; set; }

        /// <summary>
        /// 功能序号
        /// </summary>
        [Display(Name = "功能序号")]
        [StringLength(20)]
        public virtual string FUNID { get; set; }

    }
    /// <summary>
    ///系统支持 GI_Role  用户分组 实体类
    /// </summary>
    [Serializable]
    public partial class GI_Role
    {
        /// <summary>
        /// 分组序号
        /// </summary>
        [Display(Name = "分组序号")]
        [StringLength(20)]
        public virtual string RoleID { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 用户分组名称
        /// </summary>
        [Display(Name = "分组名称")]
        [StringLength(20)]
        public virtual string RoleNAME { get; set; }

        /// <summary>
        /// 用户分组说明
        /// </summary>
        [Display(Name = "分组说明")]
        [StringLength(100)]
        public virtual string RoleNote { get; set; }

        /// <summary>
        /// 权限控制1增加2删除3修改4查看2打印6授权
        /// </summary>
        [Display(Name = "权限控制")]
        [StringLength(20)]
        public virtual string RolePower { get; set; }

    }
    /// <summary>
    ///系统支持 GI_UserInfo  系统用户人员 实体类
    /// </summary>
    [Serializable]
    public partial class GI_UserInfo
    {
        /// <summary>
        /// 用员序号
        /// </summary>
        [Display(Name = "用员序号")]
        [StringLength(20)]
        public virtual string UserID { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        [Display(Name = "机构代码")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Display(Name = "用户编号")]
        [StringLength(20)]
        public virtual string UserCode { get; set; }

        /// <summary>
        /// HIS编号
        /// </summary>
        [Display(Name = "编号")]
        [StringLength(20)]
        public virtual string HISCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [Display(Name = "用户名称")]
        [StringLength(20)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// 用户照片
        /// </summary>
        [Display(Name = "用户照片")]
        [StringLength(200)]
        public virtual string UserPhoto { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Display(Name = "登录密码")]
        [StringLength(100)]
        public virtual string PassWord { get; set; }

        /// <summary>
        /// 用户科室
        /// </summary>
        [Display(Name = "用户科室")]
        [StringLength(20)]
        public virtual string DpetID { get; set; }

        /// <summary>
        /// 用户病区
        /// </summary>
        [Display(Name = "用户病区")]
        [StringLength(20)]
        public virtual string InpatientID { get; set; }

        /// <summary>
        /// 用户医疗组
        /// </summary>
        [Display(Name = "用户医疗组")]
        [StringLength(20)]
        public virtual string MedicalID { get; set; }

        /// <summary>
        /// 电子签名
        /// </summary>
        [Display(Name = "电子签名")]
        [StringLength(200)]
        public virtual string ESign { get; set; }

        /// <summary>
        /// 用户职务
        /// </summary>
        [Display(Name = "职务")]
        [StringLength(20)]
        public virtual string Job { get; set; }

        /// <summary>
        /// 职务级别
        /// </summary>
        [Display(Name = "职务级别")]
        [StringLength(20)]
        public virtual string JobLevel { get; set; }

        /// <summary>
        /// 用户职称
        /// </summary>
        [Display(Name = "用户职称")]
        [StringLength(20)]
        public virtual string UserPosition { get; set; }

        /// <summary>
        /// 用户性别1男2女3保密
        /// </summary>
        [Display(Name = "用户性别")]
        public virtual int? UserSex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public virtual DateTime? UserBirthday { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        [Display(Name = "用户电话")]
        [StringLength(20)]
        public virtual string UserTel { get; set; }

        /// <summary>
        /// 审核状态0未审核1通过
        /// </summary>
        [Display(Name = "审核状态")]
        public virtual int? CheckState { get; set; }

        /// <summary>
        /// 说明信息
        /// </summary>
        [Display(Name = "说明信息")]
        [StringLength(2000)]
        public virtual string UserNote { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        [Display(Name = "登录时间")]
        public virtual DateTime? LoginTime { get; set; }

        /// <summary>
        /// 是否在线0不在线1在线
        /// </summary>
        [Display(Name = "是否在线")]
        public virtual int? IsOnLine { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 用户类型0医生1护士2其他
        /// </summary>
        [Display(Name = "用户类型")]
        public virtual int? UserType { get; set; }

        /// <summary>
        /// 上级医师
        /// </summary>
        [Display(Name = "上级医师")]
        [StringLength(20)]
        public virtual string SuperiorUser { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

    }
    /// <summary>
    ///病案首页 CD_MedicalRecordHomePage病案首页 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MedicalRecordHomePage
    {
        /// <summary>
        /// 病案首页ID
        /// </summary>
        [Display(Name = "病案首页")]
        [StringLength(20)]
        public virtual string HomePageId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 健康卡号
        /// </summary>
        [Display(Name = "健康卡号")]
        [StringLength(20)]
        public virtual string HealthCard { get; set; }

        /// <summary>
        /// 医疗付费方式  26
        /// </summary>
        [Display(Name = "医疗付费方式")]
        [StringLength(20)]
        public virtual string PaymentMethod { get; set; }

        /// <summary>
        /// 入院途径  228
        /// </summary>
        [Display(Name = "入院途径")]
        public virtual int? AdmissionWay { get; set; }

        /// <summary>
        /// 门诊诊断编码
        /// </summary>
        [Display(Name = "门诊诊断编码")]
        [StringLength(20)]
        public virtual string ClinicDiagnosisCode { get; set; }

        /// <summary>
        /// 门诊诊断
        /// </summary>
        [Display(Name = "门诊诊断")]
        [StringLength(50)]
        public virtual string ClinicDiagnosis { get; set; }

        /// <summary>
        /// 损伤、中毒的外部因素编码
        /// </summary>
        [Display(Name = "损伤")]
        [StringLength(20)]
        public virtual string ExternalityCode { get; set; }

        /// <summary>
        /// 损伤、中毒的外部因素
        /// </summary>
        [Display(Name = "损伤")]
        [StringLength(50)]
        public virtual string ExternalityDesc { get; set; }

        /// <summary>
        /// 药物过敏 0：无 1：有
        /// </summary>
        [Display(Name = "药物过敏")]
        [StringLength(1)]
        public virtual string DrugAllergy { get; set; }

        /// <summary>
        /// 药物过敏内容
        /// </summary>
        [Display(Name = "药物过敏内容")]
        [StringLength(50)]
        public virtual string DrugAllergyDesc { get; set; }

        /// <summary>
        /// 病理诊断编码
        /// </summary>
        [Display(Name = "病理诊断编码")]
        [StringLength(20)]
        public virtual string PathologicDiagnosisCode { get; set; }

        /// <summary>
        /// 病理诊断
        /// </summary>
        [Display(Name = "病理诊断")]
        [StringLength(100)]
        public virtual string PathologicDiagnosis { get; set; }

        /// <summary>
        /// 病理号
        /// </summary>
        [Display(Name = "病理号")]
        [StringLength(20)]
        public virtual string PathologyNo { get; set; }

        /// <summary>
        /// 科主任代码
        /// </summary>
        [Display(Name = "科主任代码")]
        [StringLength(20)]
        public virtual string DeptDirectorUserId { get; set; }

        /// <summary>
        /// 科主任姓名
        /// </summary>
        [Display(Name = "科主任姓名")]
        [StringLength(20)]
        public virtual string DeptDirectorName { get; set; }

        /// <summary>
        /// 主任(副主任)医师代码
        /// </summary>
        [Display(Name = "主任")]
        [StringLength(20)]
        public virtual string DirectorUserId { get; set; }

        /// <summary>
        /// 主任(副主任)医师姓名
        /// </summary>
        [Display(Name = "主任")]
        [StringLength(20)]
        public virtual string DirectorName { get; set; }

        /// <summary>
        /// 主治医师代码
        /// </summary>
        [Display(Name = "主治医师代码")]
        [StringLength(20)]
        public virtual string VisitingStaffId { get; set; }

        /// <summary>
        /// 主治医师姓名
        /// </summary>
        [Display(Name = "主治医师姓名")]
        [StringLength(20)]
        public virtual string VisitingName { get; set; }

        /// <summary>
        /// 住院医师代码
        /// </summary>
        [Display(Name = "住院医师代码")]
        [StringLength(20)]
        public virtual string ResidentDoctorId { get; set; }

        /// <summary>
        /// 住院医师姓名
        /// </summary>
        [Display(Name = "住院医师姓名")]
        [StringLength(20)]
        public virtual string ResidentName { get; set; }

        /// <summary>
        /// 责任护士代码
        /// </summary>
        [Display(Name = "责任护士代码")]
        [StringLength(20)]
        public virtual string ResponsibleNurseId { get; set; }

        /// <summary>
        /// 责任护士姓名
        /// </summary>
        [Display(Name = "责任护士姓名")]
        [StringLength(20)]
        public virtual string ResponsibleNurseName { get; set; }

        /// <summary>
        /// 进修医师代码
        /// </summary>
        [Display(Name = "进修医师代码")]
        [StringLength(20)]
        public virtual string RefresherDoctorId { get; set; }

        /// <summary>
        /// 进修医师姓名
        /// </summary>
        [Display(Name = "进修医师姓名")]
        [StringLength(20)]
        public virtual string RefresherDoctorName { get; set; }

        /// <summary>
        /// 实习医师代码
        /// </summary>
        [Display(Name = "实习医师代码")]
        [StringLength(20)]
        public virtual string InternDoctorId { get; set; }

        /// <summary>
        /// 实习医师姓名
        /// </summary>
        [Display(Name = "实习医师姓名")]
        [StringLength(20)]
        public virtual string InternDoctorName { get; set; }

        /// <summary>
        /// 编码员代码
        /// </summary>
        [Display(Name = "编码员代码")]
        [StringLength(20)]
        public virtual string CoderUserId { get; set; }

        /// <summary>
        /// 编码员姓名
        /// </summary>
        [Display(Name = "编码员姓名")]
        [StringLength(20)]
        public virtual string CoderUserName { get; set; }

        /// <summary>
        /// 病案质量  773
        /// </summary>
        [Display(Name = "病案质量")]
        public virtual int? MedicalRecordMass { get; set; }

        /// <summary>
        /// 质控医师代码
        /// </summary>
        [Display(Name = "质控医师代码")]
        [StringLength(20)]
        public virtual string QcDoctorId { get; set; }

        /// <summary>
        /// 质控医师姓名
        /// </summary>
        [Display(Name = "质控医师姓名")]
        [StringLength(20)]
        public virtual string QcDoctorName { get; set; }

        /// <summary>
        /// 质控护士代码
        /// </summary>
        [Display(Name = "质控护士代码")]
        [StringLength(20)]
        public virtual string QcNurseId { get; set; }

        /// <summary>
        /// 质控护士姓名
        /// </summary>
        [Display(Name = "质控护士姓名")]
        [StringLength(20)]
        public virtual string QcNurseName { get; set; }

        /// <summary>
        /// 质控日期
        /// </summary>
        [Display(Name = "质控日期")]
        public virtual DateTime? QcTime { get; set; }

        /// <summary>
        /// 住院费用总计
        /// </summary>
        [Display(Name = "住院费用总计")]
        [StringLength(10)]
        public virtual string FeeTotal { get; set; }

        /// <summary>
        /// 自付金额
        /// </summary>
        [Display(Name = "自付金额")]
        [StringLength(10)]
        public virtual string FeeOwn { get; set; }

        /// <summary>
        /// 一般医疗服务费
        /// </summary>
        [Display(Name = "一般医疗服务费")]
        [StringLength(10)]
        public virtual string MedicalServicesFee { get; set; }

        /// <summary>
        /// 一般治疗操作费
        /// </summary>
        [Display(Name = "一般治疗操作费")]
        [StringLength(10)]
        public virtual string TreatmentOperateFee { get; set; }

        /// <summary>
        /// 护理费
        /// </summary>
        [Display(Name = "护理费")]
        [StringLength(10)]
        public virtual string NursingFee { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [Display(Name = "其他费用")]
        [StringLength(10)]
        public virtual string OtherServiceFee { get; set; }

        /// <summary>
        /// 病理诊断费
        /// </summary>
        [Display(Name = "病理诊断费")]
        [StringLength(10)]
        public virtual string DiagnosisFee { get; set; }

        /// <summary>
        /// 影像学诊断费
        /// </summary>
        [Display(Name = "影像学诊断费")]
        [StringLength(10)]
        public virtual string ImagingDiagnosisDee { get; set; }

        /// <summary>
        /// 实验室诊断费
        /// </summary>
        [Display(Name = "实验室诊断费")]
        [StringLength(10)]
        public virtual string LaboratoryDiagnosisFee { get; set; }

        /// <summary>
        /// 临床诊断费
        /// </summary>
        [Display(Name = "临床诊断费")]
        [StringLength(10)]
        public virtual string ClinicalDiagnosisFee { get; set; }

        /// <summary>
        /// 非手术治疗项目费
        /// </summary>
        [Display(Name = "非手术治疗项目费")]
        [StringLength(10)]
        public virtual string NonOperationProjectFee { get; set; }

        /// <summary>
        /// 临床物理治疗费
        /// </summary>
        [Display(Name = "临床物理治疗费")]
        [StringLength(10)]
        public virtual string ClinicalPhysicalTreatmentFee { get; set; }

        /// <summary>
        /// 手术治疗费
        /// </summary>
        [Display(Name = "手术治疗费")]
        [StringLength(10)]
        public virtual string OperationTreatmentFee { get; set; }

        /// <summary>
        /// 麻醉费
        /// </summary>
        [Display(Name = "麻醉费")]
        [StringLength(10)]
        public virtual string AnestheticFee { get; set; }

        /// <summary>
        /// 手术费
        /// </summary>
        [Display(Name = "手术费")]
        [StringLength(10)]
        public virtual string OperationFee { get; set; }

        /// <summary>
        /// 康复费
        /// </summary>
        [Display(Name = "康复费")]
        [StringLength(10)]
        public virtual string RehabilitationFee { get; set; }

        /// <summary>
        /// 中医治疗费
        /// </summary>
        [Display(Name = "中医治疗费")]
        [StringLength(10)]
        public virtual string ChineseMedicineTreatmentFee { get; set; }

        /// <summary>
        /// 西药费
        /// </summary>
        [Display(Name = "西药费")]
        [StringLength(10)]
        public virtual string WesternMedicineFee { get; set; }

        /// <summary>
        /// 抗菌药物费用
        /// </summary>
        [Display(Name = "抗菌药物费用")]
        [StringLength(10)]
        public virtual string AntimicrobialCostsFee { get; set; }

        /// <summary>
        /// 中成药费
        /// </summary>
        [Display(Name = "中成药费")]
        [StringLength(10)]
        public virtual string PatentMedicineFee { get; set; }

        /// <summary>
        /// 中草药费
        /// </summary>
        [Display(Name = "中草药费")]
        [StringLength(10)]
        public virtual string HerbalMedicineFee { get; set; }

        /// <summary>
        /// 血费
        /// </summary>
        [Display(Name = "血费")]
        [StringLength(10)]
        public virtual string NloodFee { get; set; }

        /// <summary>
        /// 白蛋白制品费
        /// </summary>
        [Display(Name = "白蛋白制品费")]
        [StringLength(10)]
        public virtual string AlbuminProductsFee { get; set; }

        /// <summary>
        /// 球蛋白制品费
        /// </summary>
        [Display(Name = "球蛋白制品费")]
        [StringLength(10)]
        public virtual string ImmunoglobulinFee { get; set; }

        /// <summary>
        /// 凝血因子制品费
        /// </summary>
        [Display(Name = "凝血因子制品费")]
        [StringLength(10)]
        public virtual string ClottingFactorFee { get; set; }

        /// <summary>
        /// 细胞因子制品费
        /// </summary>
        [Display(Name = "细胞因子制品费")]
        [StringLength(10)]
        public virtual string CytokineFee { get; set; }

        /// <summary>
        /// 检查用一次性医用材料费
        /// </summary>
        [Display(Name = "检查用一次性医用材料费")]
        [StringLength(10)]
        public virtual string InspectionMaterialFee { get; set; }

        /// <summary>
        /// 治疗用一次性医用材料费
        /// </summary>
        [Display(Name = "治疗用一次性医用材料费")]
        [StringLength(10)]
        public virtual string TreatmentMaterialFee { get; set; }

        /// <summary>
        /// 手术用一次性医用材料费
        /// </summary>
        [Display(Name = "手术用一次性医用材料费")]
        [StringLength(10)]
        public virtual string OperationMaterialFee { get; set; }

        /// <summary>
        /// 其他费
        /// </summary>
        [Display(Name = "其他费")]
        [StringLength(10)]
        public virtual string OtherFee { get; set; }

        /// <summary>
        /// 尸检1：是 2：否
        /// </summary>
        [Display(Name = "尸检")]
        [StringLength(1)]
        public virtual string Autopsy { get; set; }

        /// <summary>
        /// 离院方式  221
        /// </summary>
        [Display(Name = "离院方式")]
        [StringLength(1)]
        public virtual string LeaveHospitalWay { get; set; }

        /// <summary>
        /// 转院机构
        /// </summary>
        [Display(Name = "转院机构")]
        [StringLength(50)]
        public virtual string ToHospital { get; set; }

        /// <summary>
        /// 血型 444
        /// </summary>
        [Display(Name = "血型")]
        [StringLength(1)]
        public virtual string BloodType { get; set; }

        /// <summary>
        /// Rh1  21
        /// </summary>
        [Display(Name = "")]
        [StringLength(1)]
        public virtual string RH { get; set; }

        /// <summary>
        /// 是否有出院31天内再住院计划0：无  1：有
        /// </summary>
        [Display(Name = "是否有出院")]
        [StringLength(1)]
        public virtual string ReadmPlan { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [Display(Name = "目的")]
        [StringLength(100)]
        public virtual string ReadmPlanCause { get; set; }

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院前
        /// </summary>
        [Display(Name = "颅脑损伤患者昏迷时间")]
        [StringLength(100)]
        public virtual string ComaTimeBefore { get; set; }

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院后
        /// </summary>
        [Display(Name = "颅脑损伤患者昏迷时间")]
        [StringLength(100)]
        public virtual string ComaTimeAfter { get; set; }

        /// <summary>
        /// 记录医师代码
        /// </summary>
        [Display(Name = "记录医师代码")]
        [StringLength(20)]
        public virtual string RecordUserId { get; set; }

        /// <summary>
        /// 单病种管理0：无 1：有(中医)  2: 有(西医)
        /// </summary>
        [Display(Name = "单病种管理")]
        [StringLength(1)]
        public virtual string SingleDiseaseManage { get; set; }

        /// <summary>
        /// 门诊与住院
        /// </summary>
        [Display(Name = "门诊与住院")]
        [StringLength(1)]
        public virtual string ClinicInhospital { get; set; }

        /// <summary>
        /// 入院与出院
        /// </summary>
        [Display(Name = "入院与出院")]
        [StringLength(1)]
        public virtual string AdmissionDischarged { get; set; }

        /// <summary>
        /// 术前与术后
        /// </summary>
        [Display(Name = "术前与术后")]
        [StringLength(1)]
        public virtual string OperationBeforeAfter { get; set; }

        /// <summary>
        /// 临床与病理
        /// </summary>
        [Display(Name = "临床与病理")]
        [StringLength(1)]
        public virtual string ClinicPathology { get; set; }

        /// <summary>
        /// 放射与病理
        /// </summary>
        [Display(Name = "放射与病理")]
        [StringLength(1)]
        public virtual string IrradiationPathology { get; set; }

        /// <summary>
        /// 抢救情况0：无 1：有
        /// </summary>
        [Display(Name = "抢救情况")]
        [StringLength(1)]
        public virtual string RescueCase { get; set; }

        /// <summary>
        /// 抢救次数
        /// </summary>
        [Display(Name = "抢救次数")]
        public virtual int? RescueNum { get; set; }

        /// <summary>
        /// 抢救成功次数
        /// </summary>
        [Display(Name = "抢救成功次数")]
        public virtual int? RescueSucceedNum { get; set; }

        /// <summary>
        /// 是否为自动出院  0：否 1：是 
        /// </summary>
        [Display(Name = "是否为自动出院")]
        [StringLength(1)]
        public virtual string AgainstAdviseDischarge { get; set; }

        /// <summary>
        /// 转归情况   777
        /// </summary>
        [Display(Name = "转归情况")]
        [StringLength(1)]
        public virtual string PrognosisOfDisease { get; set; }

        /// <summary>
        /// 手术并发症 0：无 1：有
        /// </summary>
        [Display(Name = "手术并发症")]
        [StringLength(1)]
        public virtual string OperativeComplications { get; set; }

        /// <summary>
        /// 手术并发症_有 783
        /// </summary>
        [Display(Name = "手术并发症")]
        [StringLength(500)]
        public virtual string OperativeComplicationsDesc { get; set; }

        /// <summary>
        /// 手术并发症_有_其他
        /// </summary>
        [Display(Name = "手术并发症")]
        [StringLength(100)]
        public virtual string OperativeComplicationsOther { get; set; }

        /// <summary>
        /// 输血及血制品0 ：无 1：有
        /// </summary>
        [Display(Name = "输血及血制品")]
        [StringLength(1)]
        public virtual string BloodProduct { get; set; }

        /// <summary>
        /// 输血反应  1：有输血无反应  2：有输血有反应  3：未输血
        /// </summary>
        [Display(Name = "输血反应")]
        [StringLength(1)]
        public virtual string TransfusionReaction { get; set; }

        /// <summary>
        /// 住院期间是否告病危或危重  0：否 1：是 
        /// </summary>
        [Display(Name = "住院期间是否告病危或危重")]
        [StringLength(1)]
        public virtual string LmminenceGrave { get; set; }

        /// <summary>
        /// 医院感染情况 0：无  1：有
        /// </summary>
        [Display(Name = "医院感染情况")]
        public virtual int? InfectionSituation { get; set; }

        /// <summary>
        /// 临床路经管理 1：完成 2：变异 3：退出 4：未入
        /// </summary>
        [Display(Name = "临床路经管理")]
        public virtual int? ClinicalPathway { get; set; }

        /// <summary>
        /// 急症 0：否 1：是 
        /// </summary>
        [Display(Name = "急症")]
        public virtual int? EmergencyCase { get; set; }

        /// <summary>
        /// 疑难情况 0：否 1：是 
        /// </summary>
        [Display(Name = "疑难情况")]
        public virtual int? DifficultSituation { get; set; }

        /// <summary>
        /// 病例分型0.无1.单纯普通病历2.单纯急症病例3.复杂疑难病例4.复杂危重病例 
        /// </summary>
        [Display(Name = "病例分型")]
        public virtual int? CaseClassification { get; set; }

        /// <summary>
        /// 手术相关院内感染 0：无  1：有
        /// </summary>
        [Display(Name = "手术相关院内感染")]
        public virtual int? SurgicalInfections { get; set; }

        /// <summary>
        /// 入院后确诊日期
        /// </summary>
        [Display(Name = "入院后确诊日期")]
        public virtual DateTime? DiagnosisDate { get; set; }

        /// <summary>
        /// 非预期重返手术 0：否 1：是 
        /// </summary>
        [Display(Name = "非预期重返手术")]
        public virtual int? UnexpectedSurgery { get; set; }

        /// <summary>
        /// 保存方式0：暂存1：保存
        /// </summary>
        [Display(Name = "保存方式")]
        public virtual int? RecordState { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病案首页 CD_OperationRecord 手术记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_OperationRecord
    {
        /// <summary>
        /// 手术记录id
        /// </summary>
        [Display(Name = "手术记录")]
        [StringLength(20)]
        public virtual string OperationId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 手术开始时间
        /// </summary>
        [Display(Name = "手术开始时间")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// 手术结束时间
        /// </summary>
        [Display(Name = "手术结束时间")]
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 手术持续时间
        /// </summary>
        [Display(Name = "手术持续时间")]
        [StringLength(20)]
        public virtual string OperationContinueTime { get; set; }

        /// <summary>
        /// 手术代码
        /// </summary>
        [Display(Name = "手术代码")]
        [StringLength(50)]
        public virtual string OperationCode { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        [Display(Name = "手术名称")]
        [StringLength(200)]
        public virtual string OperationName { get; set; }

        /// <summary>
        /// 手术级别
        /// </summary>
        [Display(Name = "手术级别")]
        public virtual int? OperationLevel { get; set; }

        /// <summary>
        /// 主刀医师代码
        /// </summary>
        [Display(Name = "主刀医师代码")]
        [StringLength(20)]
        public virtual string SurgeonId { get; set; }

        /// <summary>
        /// 主刀医师姓名
        /// </summary>
        [Display(Name = "主刀医师姓名")]
        [StringLength(20)]
        public virtual string SurgeonName { get; set; }

        /// <summary>
        /// 一助代码
        /// </summary>
        [Display(Name = "一助代码")]
        [StringLength(20)]
        public virtual string FirstAssistantId { get; set; }

        /// <summary>
        /// 一助姓名
        /// </summary>
        [Display(Name = "一助姓名")]
        [StringLength(20)]
        public virtual string FirstAssistantName { get; set; }

        /// <summary>
        /// 二助代码
        /// </summary>
        [Display(Name = "二助代码")]
        [StringLength(20)]
        public virtual string SecondAssistantId { get; set; }

        /// <summary>
        /// 二助姓名
        /// </summary>
        [Display(Name = "二助姓名")]
        [StringLength(20)]
        public virtual string SecondAssistantName { get; set; }

        /// <summary>
        /// 三助代码
        /// </summary>
        [Display(Name = "三助代码")]
        [StringLength(20)]
        public virtual string ThirdAssistantId { get; set; }

        /// <summary>
        /// 三助姓名
        /// </summary>
        [Display(Name = "三助姓名")]
        [StringLength(20)]
        public virtual string ThirdAssistantName { get; set; }

        /// <summary>
        /// 麻醉方式代码  450

        /// </summary>
        [Display(Name = "麻醉方式代码")]
        public virtual int? AnesthesiaWayCode { get; set; }

        /// <summary>
        /// 麻醉医师代码1
        /// </summary>
        [Display(Name = "麻醉医师代码")]
        [StringLength(20)]
        public virtual string Anesthesia1Id { get; set; }

        /// <summary>
        /// 麻醉医师姓名1
        /// </summary>
        [Display(Name = "麻醉医师姓名")]
        [StringLength(20)]
        public virtual string Anesthesia1Name { get; set; }

        /// <summary>
        /// 麻醉医师代码2
        /// </summary>
        [Display(Name = "麻醉医师代码")]
        [StringLength(20)]
        public virtual string Anesthesia2Id { get; set; }

        /// <summary>
        /// 麻醉医师姓名2
        /// </summary>
        [Display(Name = "麻醉医师姓名")]
        [StringLength(20)]
        public virtual string Anesthesia2Name { get; set; }

        /// <summary>
        /// 术前诊断
        /// </summary>
        [Display(Name = "术前诊断")]
        [StringLength(200)]
        public virtual string PreoperativeDiagnosis { get; set; }

        /// <summary>
        /// 术后诊断
        /// </summary>
        [Display(Name = "术后诊断")]
        [StringLength(200)]
        public virtual string PostoperativeDiagnosis { get; set; }

        /// <summary>
        /// 手术经过
        /// </summary>
        [Display(Name = "手术经过")]
        [StringLength(4000)]
        public virtual string OperationCourse { get; set; }

        /// <summary>
        /// 手术图片
        /// </summary>
        [Display(Name = "手术图片")]
        [StringLength(500)]
        public virtual string OperationPicture { get; set; }

        /// <summary>
        /// ASA分级
        /// </summary>
        [Display(Name = "分级")]
        public virtual int? AsaLevel { get; set; }

        /// <summary>
        /// 冰冻切片诊断代码
        /// </summary>
        [Display(Name = "冰冻切片诊断代码")]
        [StringLength(20)]
        public virtual string DiagnosticCode { get; set; }

        /// <summary>
        /// 冰冻切片诊断名称
        /// </summary>
        [Display(Name = "冰冻切片诊断名称")]
        [StringLength(100)]
        public virtual string DiagnosticName { get; set; }

        /// <summary>
        /// 手术标本
        /// </summary>
        [Display(Name = "手术标本")]
        [StringLength(4000)]
        public virtual string SurgicalSpecimens { get; set; }

        /// <summary>
        /// 失血量
        /// </summary>
        [Display(Name = "失血量")]
        public virtual int? BloodLoss { get; set; }

        /// <summary>
        /// 血、 血制品PRBC
        /// </summary>
        [Display(Name = "血")]
        public virtual int? Prbc { get; set; }

        /// <summary>
        /// FFP
        /// </summary>
        [Display(Name = "")]
        public virtual int? FFP { get; set; }

        /// <summary>
        /// PLATES
        /// </summary>
        [Display(Name = "")]
        public virtual int? Plates { get; set; }

        /// <summary>
        /// 手术类别   797
        /// </summary>
        [Display(Name = "手术类别")]
        public virtual int? OperationCategory { get; set; }

        /// <summary>
        /// 手术切口分级  238
        /// </summary>
        [Display(Name = "手术切口分级")]
        public virtual int? IncisionLevel { get; set; }

        /// <summary>
        /// 手术切口愈合等级 343
        /// </summary>
        [Display(Name = "手术切口愈合等级")]
        public virtual int? HealingLevel { get; set; }

        /// <summary>
        /// NNIS分级
        /// </summary>
        [Display(Name = "分级")]
        public virtual int? NNISLevel { get; set; }

        /// <summary>
        /// 手术类型  802
        /// </summary>
        [Display(Name = "手术类型")]
        public virtual int? OperationType { get; set; }

        /// <summary>
        /// 手术其他内容
        /// </summary>
        [Display(Name = "手术其他内容")]
        [StringLength(20000)]
        public virtual string OperationContent { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病案首页 病人诊断 实体类
    /// </summary>
    [Serializable]
    public partial class CD_PatientDiagnosis
    {
        /// <summary>
        /// 诊断id
        /// </summary>
        [Display(Name = "诊断")]
        [StringLength(20)]
        public virtual string DiagnosisId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 病历记录id
        /// </summary>
        [Display(Name = "病历记录")]
        [StringLength(20)]
        public virtual string RecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 父诊断ID
        /// </summary>
        [Display(Name = "父诊断")]
        [StringLength(20)]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// ICD代码
        /// </summary>
        [Display(Name = "代码")]
        [StringLength(10)]
        public virtual string ICDCode { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        [Display(Name = "诊断名称")]
        [StringLength(100)]
        public virtual string DiagnosisName { get; set; }

        /// <summary>
        /// 诊断名称补充
        /// </summary>
        [Display(Name = "诊断名称补充")]
        [StringLength(50)]
        public virtual string DiagnosisNameSupplement { get; set; }

        /// <summary>
        /// 确诊标志   489
        /// </summary>
        [Display(Name = "确诊标志")]
        public virtual int? DiagnosisFlag { get; set; }

        /// <summary>
        /// 诊断类别  468

        /// </summary>
        [Display(Name = "诊断类别")]
        [StringLength(10)]
        public virtual string DiagnosisType { get; set; }

        /// <summary>
        /// 入院病情
        /// </summary>
        [Display(Name = "入院病情")]
        [StringLength(10)]
        public virtual string AdmissionIllness { get; set; }

        /// <summary>
        /// 记录医生
        /// </summary>
        [Display(Name = "记录医生")]
        [StringLength(20)]
        public virtual string RecordUserId { get; set; }

        /// <summary>
        /// 记录医生姓名
        /// </summary>
        [Display(Name = "记录医生姓名")]
        [StringLength(20)]
        public virtual string RecordUserName { get; set; }

        /// <summary>
        /// 诊断时间
        /// </summary>
        [Display(Name = "诊断时间")]
        public virtual DateTime? DiagnosisTime { get; set; }

        /// <summary>
        /// 报卡类型   484
        /// </summary>
        [Display(Name = "报卡类型")]
        public virtual int? ReportCardId { get; set; }

        /// <summary>
        /// 排列顺序
        /// </summary>
        [Display(Name = "排列顺序")]
        public virtual int SortOrder { get; set; }

        /// <summary>
        /// 主诊断标志0不是1是
        /// </summary>
        [Display(Name = "主诊断标志")]
        public virtual int? MainDiagnosis { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病案首页 CD_BasicInpatientInfo 病人基本信息表 实体类
    /// </summary>
    [Serializable]
    public partial class CD_BasicInpatientInfo
    {
        /// <summary>
        /// 健康卡号
        /// </summary>
        [Display(Name = "健康卡号")]
        [StringLength(20)]
        public virtual string HealthCard { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [StringLength(20)]
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别代码 340
        /// </summary>
        [Display(Name = "性别代码")]
        public virtual int GenderCode { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [StringLength(10)]
        public virtual string Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// 民族代码    713
        /// </summary>
        [Display(Name = "民族代码")]
        public virtual int? EthnicCode { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display(Name = "民族")]
        [StringLength(20)]
        public virtual string Ethnic { get; set; }

        /// <summary>
        /// 籍贯编码    493
        /// </summary>
        [Display(Name = "籍贯编码")]
        [StringLength(20)]
        public virtual string NativeCode { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Display(Name = "籍贯")]
        [StringLength(100)]
        public virtual string NativePlace { get; set; }

        /// <summary>
        /// 出生地编码 
        /// </summary>
        [Display(Name = "出生地编码")]
        [StringLength(20)]
        public virtual string BirthplaceCode { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [Display(Name = "出生地")]
        [StringLength(100)]
        public virtual string BirthPlace { get; set; }

        /// <summary>
        /// 婚姻状态代码  323
        /// </summary>
        [Display(Name = "婚姻状态代码")]
        public virtual int? MaritalCode { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        [Display(Name = "婚姻状态")]
        [StringLength(10)]
        public virtual string Marital { get; set; }

        /// <summary>
        /// 现住址编码
        /// </summary>
        [Display(Name = "现住址编码")]
        [StringLength(10)]
        public virtual string AddressCode { get; set; }

        /// <summary>
        /// 现地址-补充信息
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(50)]
        public virtual string AddressOther { get; set; }

        /// <summary>
        /// 现地址-详细地址
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(100)]
        public virtual string AddressDetail { get; set; }

        /// <summary>
        /// 现地址-邮编
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(10)]
        public virtual string AddressPostcode { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [StringLength(20)]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 联系人1
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactName { get; set; }

        /// <summary>
        /// 联系人1电话
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactPhone { get; set; }

        /// <summary>
        /// 联系人1关系
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactRelation { get; set; }

        /// <summary>
        /// 联系人1关系编码
        /// </summary>
        [Display(Name = "联系人")]
        public virtual int? ContactRelationCode { get; set; }

        /// <summary>
        /// 联系人1地址
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(100)]
        public virtual string ContactPlace { get; set; }

        /// <summary>
        /// 联系人2
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactName2 { get; set; }

        /// <summary>
        /// 联系人2电话
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactPhone2 { get; set; }

        /// <summary>
        /// 联系人2关系
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactRelation2 { get; set; }

        /// <summary>
        /// 联系人2关系编码
        /// </summary>
        [Display(Name = "联系人")]
        public virtual int? ContactRelationCode2 { get; set; }

        /// <summary>
        /// 联系人2地址
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(100)]
        public virtual string ContactPlace2 { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        [Display(Name = "国籍")]
        [StringLength(20)]
        public virtual string Nationality { get; set; }

        /// <summary>
        /// 国籍编码
        /// </summary>
        [Display(Name = "国籍编码")]
        [StringLength(20)]
        public virtual string NationalityCode { get; set; }

        /// <summary>
        /// 户口地址编码
        /// </summary>
        [Display(Name = "户口地址编码")]
        [StringLength(20)]
        public virtual string HouseholdCode { get; set; }

        /// <summary>
        /// 户口地址-补充信息
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(50)]
        public virtual string HouseholdOther { get; set; }

        /// <summary>
        /// 户口地址-详细信息
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(100)]
        public virtual string HouseholdDetailed { get; set; }

        /// <summary>
        /// 户口地址-邮编
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(10)]
        public virtual string HouseholdPostcode { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        [Display(Name = "工作单位")]
        [StringLength(100)]
        public virtual string Company { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        [Display(Name = "单位电话")]
        [StringLength(20)]
        public virtual string CompanyPhone { get; set; }

        /// <summary>
        /// 单位邮编
        /// </summary>
        [Display(Name = "单位邮编")]
        [StringLength(10)]
        public virtual string CompanyPostcode { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        [Display(Name = "单位地址")]
        [StringLength(100)]
        public virtual string CompanyAddress { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>
        [Display(Name = "家庭电话")]
        [StringLength(20)]
        public virtual string HomePhone { get; set; }

        /// <summary>
        /// 家庭邮编
        /// </summary>
        [Display(Name = "家庭邮编")]
        [StringLength(10)]
        public virtual string HomePostcode { get; set; }

        /// <summary>
        /// 文化程度
        /// </summary>
        [Display(Name = "文化程度")]
        [StringLength(20)]
        public virtual string Education { get; set; }

        /// <summary>
        /// 文化程度编码  320
        /// </summary>
        [Display(Name = "文化程度编码")]
        [StringLength(10)]
        public virtual string EducationCode { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [Display(Name = "职业")]
        [StringLength(20)]
        public virtual string Job { get; set; }

        /// <summary>
        /// 职业编码 268
        /// </summary>
        [Display(Name = "职业编码")]
        [StringLength(10)]
        public virtual string JobCode { get; set; }

        /// <summary>
        /// 宗教信仰
        /// </summary>
        [Display(Name = "宗教信仰")]
        [StringLength(20)]
        public virtual string Religion { get; set; }

        /// <summary>
        /// 宗教信仰编码
        /// </summary>
        [Display(Name = "宗教信仰编码")]
        public virtual int? ReligionCode { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病案首页 CD_Inpatient    住院病人 实体类
    /// </summary>
    [Serializable]
    public partial class CD_Inpatient
    {
        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 健康卡号
        /// </summary>
        [Display(Name = "健康卡号")]
        [StringLength(20)]
        public virtual string HealthCard { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// HIS住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string HISInpatientId { get; set; }

        /// <summary>
        /// HIS住院次数
        /// </summary>
        [Display(Name = "住院次数")]
        public virtual int? HISInpatientCount { get; set; }

        /// <summary>
        /// 付费类型 26
        /// </summary>
        [Display(Name = "付费类型")]
        [StringLength(20)]
        public virtual string PaymentType { get; set; }

        /// <summary>
        /// 病历类型 849
        /// </summary>
        [Display(Name = "病历类型")]
        [StringLength(20)]
        public virtual string RecordType { get; set; }

        /// <summary>
        /// 入院病区
        /// </summary>
        [Display(Name = "入院病区")]
        [StringLength(20)]
        public virtual string AdmissionWard { get; set; }

        /// <summary>
        /// 出院病区
        /// </summary>
        [Display(Name = "出院病区")]
        [StringLength(20)]
        public virtual string LeaveWard { get; set; }

        /// <summary>
        /// 入院病房
        /// </summary>
        [Display(Name = "入院病房")]
        [StringLength(20)]
        public virtual string AdmissionBedWard { get; set; }

        /// <summary>
        /// 出院病房
        /// </summary>
        [Display(Name = "出院病房")]
        [StringLength(20)]
        public virtual string LeaveBedWard { get; set; }

        /// <summary>
        /// 出院科室
        /// </summary>
        [Display(Name = "出院科室")]
        [StringLength(20)]
        public virtual string LeaveDept { get; set; }

        /// <summary>
        /// 入院科室
        /// </summary>
        [Display(Name = "入院科室")]
        [StringLength(20)]
        public virtual string AdmissionDept { get; set; }

        /// <summary>
        /// 转科情况
        /// </summary>
        [Display(Name = "转科情况")]
        [StringLength(20)]
        public virtual string ConversionDept { get; set; }

        /// <summary>
        /// 当前科室ID
        /// </summary>
        [Display(Name = "当前科室")]
        [StringLength(20)]
        public virtual string CurrentDeptID { get; set; }

        /// <summary>
        /// 当前病区ID
        /// </summary>
        [Display(Name = "当前病区")]
        [StringLength(20)]
        public virtual string CurrentWardID { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(4)]
        public virtual string BedNumber { get; set; }

        /// <summary>
        /// 门诊就诊卡号
        /// </summary>
        [Display(Name = "门诊就诊卡号")]
        [StringLength(20)]
        public virtual string OutpatientCard { get; set; }

        /// <summary>
        /// 影像号
        /// </summary>
        [Display(Name = "影像号")]
        [StringLength(20)]
        public virtual string ImageNumber { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [StringLength(20)]
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别代码 340
        /// </summary>
        [Display(Name = "性别代码")]
        public virtual int? GenderCode { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [StringLength(10)]
        public virtual string Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// 就诊年龄(岁)
        /// </summary>
        [Display(Name = "就诊年龄")]
        [StringLength(20)]
        public virtual string Age { get; set; }

        /// <summary>
        /// 父母姓名(新生儿填写)
        /// </summary>
        [Display(Name = "父母姓名")]
        [StringLength(20)]
        public virtual string ParentsName { get; set; }

        /// <summary>
        /// 胎龄(新生儿填写)
        /// </summary>
        [Display(Name = "胎龄")]
        [StringLength(20)]
        public virtual string GestationalAge { get; set; }

        /// <summary>
        /// 新生儿年龄(月)
        /// </summary>
        [Display(Name = "新生儿年龄")]
        public virtual int? NBAgeMonth { get; set; }

        /// <summary>
        /// 新生儿年龄(天)
        /// </summary>
        [Display(Name = "新生儿年龄")]
        public virtual int? NBAgeDay { get; set; }

        /// <summary>
        /// 新生儿出生体重
        /// </summary>
        [Display(Name = "新生儿出生体重")]
        public virtual int? NBAgeWeight { get; set; }

        /// <summary>
        /// 新生儿入院体重
        /// </summary>
        [Display(Name = "新生儿入院体重")]
        public virtual int? NBHospitalWeight { get; set; }

        /// <summary>
        /// 民族代码   713
        /// </summary>
        [Display(Name = "民族代码")]
        public virtual int? EthnicCode { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display(Name = "民族")]
        [StringLength(20)]
        public virtual string Ethnic { get; set; }

        /// <summary>
        /// 籍贯编
        /// </summary>
        [Display(Name = "籍贯编码")]
        [StringLength(20)]
        public virtual string NativeCode { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Display(Name = "籍贯")]
        [StringLength(100)]
        public virtual string NativePlace { get; set; }

        /// <summary>
        /// 出生地编码 
        /// </summary>
        [Display(Name = "出生地编码")]
        [StringLength(20)]
        public virtual string BirthplaceCode { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [Display(Name = "出生地")]
        [StringLength(100)]
        public virtual string BirthPlace { get; set; }

        /// <summary>
        /// 婚姻状态代码  323
        /// </summary>
        [Display(Name = "婚姻状态代码")]
        public virtual int? MaritalCode { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        [Display(Name = "婚姻状态")]
        [StringLength(10)]
        public virtual string Marital { get; set; }

        /// <summary>
        /// 现住址编码
        /// </summary>
        [Display(Name = "现住址编码")]
        [StringLength(10)]
        public virtual string AddressCode { get; set; }

        /// <summary>
        /// 现地址-补充信息
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(50)]
        public virtual string AddressOther { get; set; }

        /// <summary>
        /// 现地址-详细地址
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(100)]
        public virtual string AddressDetail { get; set; }

        /// <summary>
        /// 现地址-邮编
        /// </summary>
        [Display(Name = "现地址")]
        [StringLength(10)]
        public virtual string AddressPostcode { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [StringLength(20)]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Display(Name = "联系人")]
        [StringLength(20)]
        public virtual string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [Display(Name = "联系人电话")]
        [StringLength(20)]
        public virtual string ContactPhone { get; set; }

        /// <summary>
        /// 联系人电话1
        /// </summary>
        [Display(Name = "联系人电话")]
        [StringLength(20)]
        public virtual string ContactPhone1 { get; set; }

        /// <summary>
        /// 联系人关系
        /// </summary>
        [Display(Name = "联系人关系")]
        [StringLength(20)]
        public virtual string ContactRelation { get; set; }

        /// <summary>
        /// 关系编码
        /// </summary>
        [Display(Name = "关系编码")]
        public virtual int? ContactRelationCode { get; set; }

        /// <summary>
        /// 联系人地址
        /// </summary>
        [Display(Name = "联系人地址")]
        [StringLength(100)]
        public virtual string ContactPlace { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        [Display(Name = "国籍")]
        [StringLength(20)]
        public virtual string Nationality { get; set; }

        /// <summary>
        /// 国籍编码 493
        /// </summary>
        [Display(Name = "国籍编码")]
        [StringLength(20)]
        public virtual string NationalityCode { get; set; }

        /// <summary>
        /// 户口地址编码
        /// </summary>
        [Display(Name = "户口地址编码")]
        [StringLength(20)]
        public virtual string HouseholdCode { get; set; }

        /// <summary>
        /// 户口地址-补充信息
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(50)]
        public virtual string HouseholdOther { get; set; }

        /// <summary>
        /// 户口地址-详细信息
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(100)]
        public virtual string HouseholdDetailed { get; set; }

        /// <summary>
        /// 户口地址-邮编
        /// </summary>
        [Display(Name = "户口地址")]
        [StringLength(10)]
        public virtual string HouseholdPostCode { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        [Display(Name = "工作单位")]
        [StringLength(100)]
        public virtual string Company { get; set; }

        /// <summary>
        /// 单位电话
        /// </summary>
        [Display(Name = "单位电话")]
        [StringLength(20)]
        public virtual string CompanyPhone { get; set; }

        /// <summary>
        /// 单位邮编
        /// </summary>
        [Display(Name = "单位邮编")]
        [StringLength(10)]
        public virtual string CompanyPostcode { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        [Display(Name = "单位地址")]
        [StringLength(100)]
        public virtual string CompanyAddress { get; set; }

        /// <summary>
        /// 文化程度
        /// </summary>
        [Display(Name = "文化程度")]
        [StringLength(20)]
        public virtual string Education { get; set; }

        /// <summary>
        /// 文化程度编码  320
        /// </summary>
        [Display(Name = "文化程度编码")]
        [StringLength(10)]
        public virtual string EducationCode { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [Display(Name = "职业")]
        [StringLength(20)]
        public virtual string Job { get; set; }

        /// <summary>
        /// 职业编码  268
        /// </summary>
        [Display(Name = "职业编码")]
        [StringLength(10)]
        public virtual string JobCode { get; set; }

        /// <summary>
        /// 入院途径代码 228
        /// </summary>
        [Display(Name = "入院途径代码")]
        public virtual int? InpatientCode { get; set; }

        /// <summary>
        /// 入院途径
        /// </summary>
        [Display(Name = "入院途径")]
        [StringLength(20)]
        public virtual string InpatientWay { get; set; }

        /// <summary>
        /// 入院时间（患者首次入科时间）
        /// </summary>
        [Display(Name = "入院时间")]
        public virtual DateTime EntryTime { get; set; }

        /// <summary>
        /// 住院次数
        /// </summary>
        [Display(Name = "住院次数")]
        public virtual int? AdmisstTimes { get; set; }

        /// <summary>
        /// 临床路径管理 463
        /// </summary>
        [Display(Name = "临床路径管理")]
        [StringLength(1)]
        public virtual string CpManage { get; set; }

        /// <summary>
        /// 转科次数
        /// </summary>
        [Display(Name = "转科次数")]
        public virtual int? ConversionDeptNum { get; set; }

        /// <summary>
        /// 出院时间（即预出院时间）
        /// </summary>
        [Display(Name = "出院时间")]
        public virtual DateTime? LeaveTime { get; set; }

        /// <summary>
        /// 宗教信仰
        /// </summary>
        [Display(Name = "宗教信仰")]
        [StringLength(20)]
        public virtual string Religion { get; set; }

        /// <summary>
        /// 宗教信仰编码
        /// </summary>
        [Display(Name = "宗教信仰编码")]
        public virtual int? ReligionCode { get; set; }

        /// <summary>
        /// 病历归档状态0未归档1归档
        /// </summary>
        [Display(Name = "病历归档状态")]
        [StringLength(1)]
        public virtual string MedicalRecordState { get; set; }

        /// <summary>
        /// 病历状态0在院1预出院2出院3死亡
        /// </summary>
        [Display(Name = "病历状态")]
        public virtual int? MedicalState { get; set; }

        /// <summary>
        /// 主诊医师代码
        /// </summary>
        [Display(Name = "主诊医师代码")]
        [StringLength(20)]
        public virtual string AttendingDoctorId { get; set; }

        /// <summary>
        /// 主诊医师姓名
        /// </summary>
        [Display(Name = "主诊医师姓名")]
        [StringLength(20)]
        public virtual string AttendingName { get; set; }

        /// <summary>
        /// 接待医师代码
        /// </summary>
        [Display(Name = "接待医师代码")]
        [StringLength(20)]
        public virtual string ReceptionDoctorId { get; set; }

        /// <summary>
        /// 接待医师姓名
        /// </summary>
        [Display(Name = "接待医师姓名")]
        [StringLength(20)]
        public virtual string ReceptionDoctorName { get; set; }

        /// <summary>
        /// 主管护士代码
        /// </summary>
        [Display(Name = "主管护士代码")]
        [StringLength(20)]
        public virtual string ChargeNurseId { get; set; }

        /// <summary>
        /// 主管护士姓名
        /// </summary>
        [Display(Name = "主管护士姓名")]
        [StringLength(20)]
        public virtual string ChargeNurseName { get; set; }

        /// <summary>
        /// 住院证开单人代码
        /// </summary>
        [Display(Name = "住院证开单人代码")]
        [StringLength(20)]
        public virtual string IssuerId { get; set; }

        /// <summary>
        /// 住院证开单人姓名
        /// </summary>
        [Display(Name = "住院证开单人姓名")]
        [StringLength(20)]
        public virtual string IssuerName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病案首页 CD_InpatientAuthorized    住院病人授权 实体类
    /// </summary>
    [Serializable]
    public partial class CD_InpatientAuthorized
    {
        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 被授权人ID
        /// </summary>
        [Display(Name = "被授权人")]
        [StringLength(20)]
        public virtual string AuthorizedPersonID { get; set; }

        /// <summary>
        /// 被授权人姓名
        /// </summary>
        [Display(Name = "被授权人姓名")]
        [StringLength(20)]
        public virtual string AuthorizedPersonName { get; set; }

        /// <summary>
        /// 授权原因
        /// </summary>
        [Display(Name = "授权原因")]
        [StringLength(2000)]
        public virtual string AuthorizedReason { get; set; }

        /// <summary>
        /// 被授权时间
        /// </summary>
        [Display(Name = "被授权时间")]
        public virtual DateTime? AuthorizedPersonTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

    }
    /// <summary>
    ///病案首页 CD_Transfer    转科 实体类
    /// </summary>
    [Serializable]
    public partial class CD_Transfer
    {
        /// <summary>
        /// 转科ID
        /// </summary>
        [Display(Name = "转科")]
        [StringLength(20)]
        public virtual string CurrentID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 转前科室ID
        /// </summary>
        [Display(Name = "转前科室")]
        [StringLength(20)]
        public virtual string OldDeptID { get; set; }

        /// <summary>
        /// 转前病区ID
        /// </summary>
        [Display(Name = "转前病区")]
        [StringLength(20)]
        public virtual string OldWardID { get; set; }

        /// <summary>
        /// 当前科室ID
        /// </summary>
        [Display(Name = "当前科室")]
        [StringLength(20)]
        public virtual string CurrentDeptID { get; set; }

        /// <summary>
        /// 当前病区ID
        /// </summary>
        [Display(Name = "当前病区")]
        [StringLength(20)]
        public virtual string CurrentWardID { get; set; }

        /// <summary>
        /// 转科信息
        /// </summary>
        [Display(Name = "转科信息")]
        [StringLength(200)]
        public virtual string ConversionDept { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "转科时间")]
        public virtual DateTime? ConversionTime { get; set; }

        /// <summary>
        /// 转科时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///病历文书 CD_MedicalRecord  文书记录  实体类
    /// </summary>
    [Serializable]
    public partial class CD_MedicalRecord
    {
        /// <summary>
        /// 文书记录序号
        /// </summary>
        [Display(Name = "文书记录序号")]
        [StringLength(20)]
        public virtual string ClerkId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(20)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 病历类别  849

        /// </summary>
        [Display(Name = "病历类别")]
        public virtual int RecordClass { get; set; }

        /// <summary>
        /// 病历名称
        /// </summary>
        [Display(Name = "病历名称")]
        [StringLength(50)]
        public virtual string RecordName { get; set; }

        /// <summary>
        /// 病历书写状态0：暂存1：保存
        /// </summary>
        [Display(Name = "病历书写状态")]
        public virtual int RecordState { get; set; }

        /// <summary>
        /// 记录医师编码
        /// </summary>
        [Display(Name = "记录医师编码")]
        [StringLength(20)]
        public virtual string RecordUserId { get; set; }

        /// <summary>
        /// 记录医生姓名
        /// </summary>
        [Display(Name = "记录医生姓名")]
        [StringLength(20)]
        public virtual string RecordUserName { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public virtual DateTime? RecordTime { get; set; }

        /// <summary>
        /// 上级医师签名代码
        /// </summary>
        [Display(Name = "上级医师代码")]
        [StringLength(20)]
        public virtual string SuperiorUserId { get; set; }

        /// <summary>
        /// 上级医生姓名
        /// </summary>
        [Display(Name = "上级医生姓名")]
        [StringLength(20)]
        public virtual string SuperiorUserName { get; set; }

        /// <summary>
        /// 病历打印次数
        /// </summary>
        [Display(Name = "病历打印次数")]
        public virtual int? PrintCount { get; set; }

        /// <summary>
        /// 打印后修改标志 0否1是
        /// </summary>
        [Display(Name = "打印后修改标志")]
        public virtual int? AfterPrintModify { get; set; }

        /// <summary>
        /// 打印人
        /// </summary>
        [Display(Name = "打印人")]
        [StringLength(20)]
        public virtual string PrinterId { get; set; }

        /// <summary>
        /// 打印人姓名
        /// </summary>
        [Display(Name = "打印人姓名")]
        [StringLength(20)]
        public virtual string PrinterName { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_ProgressNote 病程记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_ProgressNote
    {
        /// <summary>
        /// 病程记录id
        /// </summary>
        [Display(Name = "病程记录")]
        [StringLength(20)]
        public virtual string ProgressNoteId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 病程类别id  824
        /// </summary>
        [Display(Name = "病程类别")]
        public virtual int ProgressTypeId { get; set; }

        /// <summary>
        /// 病程记录时间
        /// </summary>
        [Display(Name = "病程记录时间")]
        [StringLength(50)]
        public virtual string ProgressNoteTime { get; set; }

        /// <summary>
        /// 记录类型补充
        /// </summary>
        [Display(Name = "记录类型补充")]
        [StringLength(100)]
        public virtual string RecordContentSupplement { get; set; }

        /// <summary>
        /// 是否需要家属签名
        /// </summary>
        [Display(Name = "是否需要家属签名")]
        public virtual int? FamilySignature { get; set; }

        /// <summary>
        /// 是否需要换页打印
        /// </summary>
        [Display(Name = "是否需要换页打印")]
        public virtual int? ChangePagePrint { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        [Display(Name = "记录内容")]
        [StringLength(20000)]
        public virtual string RecordContent { get; set; }

        /// <summary>
        /// 查房医师代码
        /// </summary>
        [Display(Name = "查房医师代码")]
        [StringLength(50)]
        public virtual string WardRoundUserId { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_DeathRecord 死亡记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_DeathRecord
    {
        /// <summary>
        /// 死亡记录id
        /// </summary>
        [Display(Name = "死亡记录")]
        [StringLength(20)]
        public virtual string DeathId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 死亡时间
        /// </summary>
        [Display(Name = "死亡时间")]
        [StringLength(20)]
        public virtual string DeathTime { get; set; }

        /// <summary>
        /// 入院原因
        /// </summary>
        [Display(Name = "入院原因")]
        [StringLength(3000)]
        public virtual string HospitalizedCause { get; set; }

        /// <summary>
        /// 入院情况
        /// </summary>
        [Display(Name = "入院情况")]
        [StringLength(2000)]
        public virtual string HospitalizedCase { get; set; }

        /// <summary>
        /// 诊治经过
        /// </summary>
        [Display(Name = "诊治经过")]
        [StringLength(2000)]
        public virtual string HospitalCourse { get; set; }

        /// <summary>
        /// 死亡原因
        /// </summary>
        [Display(Name = "死亡原因")]
        [StringLength(2000)]
        public virtual string DeathCause { get; set; }

        /// <summary>
        /// 记录类型：0：24小时内入院死亡记录1：死亡记录
        /// </summary>
        [Display(Name = "记录类型")]
        public virtual int? RecordType { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_OuthospitalRecord 出院记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_OuthospitalRecord
    {
        /// <summary>
        /// 出院记录id
        /// </summary>
        [Display(Name = "出院记录")]
        [StringLength(20)]
        public virtual string OuthospitalRecordId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 出院时间
        /// </summary>
        [Display(Name = "出院时间")]
        [StringLength(20)]
        public virtual string DischargeTime { get; set; }

        /// <summary>
        /// 入院原因
        /// </summary>
        [Display(Name = "入院原因")]
        [StringLength(4000)]
        public virtual string HospitalizedCause { get; set; }

        /// <summary>
        /// 转院日期
        /// </summary>
        [Display(Name = "转院日期")]
        [StringLength(10)]
        public virtual string TransferDate { get; set; }

        /// <summary>
        /// 转往医疗机构名称
        /// </summary>
        [Display(Name = "转往医疗机构名称")]
        [StringLength(50)]
        public virtual string TransferInstitutions { get; set; }

        /// <summary>
        /// 转往医院联系医生
        /// </summary>
        [Display(Name = "转往医院联系医生")]
        [StringLength(20)]
        public virtual string TransferDoctor { get; set; }

        /// <summary>
        /// 转院目的
        /// </summary>
        [Display(Name = "转院目的")]
        [StringLength(200)]
        public virtual string TransferPurpose { get; set; }

        /// <summary>
        /// 入院情况
        /// </summary>
        [Display(Name = "入院情况")]
        [StringLength(3000)]
        public virtual string HospitalizedCase { get; set; }

        /// <summary>
        /// 住院诊治经过
        /// </summary>
        [Display(Name = "住院诊治经过")]
        [StringLength(3000)]
        public virtual string HospitalCourse { get; set; }

        /// <summary>
        /// 出院状况
        /// </summary>
        [Display(Name = "出院状况")]
        [StringLength(1500)]
        public virtual string DischargeStatus { get; set; }

        /// <summary>
        /// 出院带药
        /// </summary>
        [Display(Name = "出院带药")]
        [StringLength(2000)]
        public virtual string DischargeMedication { get; set; }

        /// <summary>
        /// 出院体温
        /// </summary>
        [Display(Name = "出院体温")]
        public virtual int? DischargeTemperature { get; set; }

        /// <summary>
        /// 出院脉搏
        /// </summary>
        [Display(Name = "出院脉搏")]
        public virtual int? DischargePulse { get; set; }

        /// <summary>
        /// 出院呼吸
        /// </summary>
        [Display(Name = "出院呼吸")]
        public virtual int? DischargeBreathe { get; set; }

        /// <summary>
        /// 出院血压
        /// </summary>
        [Display(Name = "出院血压")]
        [StringLength(20)]
        public virtual string DischargeBloodpressure { get; set; }

        /// <summary>
        /// 出院体重
        /// </summary>
        [Display(Name = "出院体重")]
        public virtual int? DischargeBodyweight { get; set; }

        /// <summary>
        /// 出院去向  254
        /// </summary>
        [Display(Name = "出院去向")]
        [StringLength(1)]
        public virtual string DischargeWhere { get; set; }

        /// <summary>
        /// 出院去向其他
        /// </summary>
        [Display(Name = "出院去向其他")]
        [StringLength(20)]
        public virtual string DischargeWhereother { get; set; }

        /// <summary>
        /// 是否需要随访
        /// </summary>
        [Display(Name = "是否需要随访")]
        [StringLength(1)]
        public virtual string TollowUpGuidancestate { get; set; }

        /// <summary>
        /// 随访指导
        /// </summary>
        [Display(Name = "随访指导")]
        [StringLength(5000)]
        public virtual string TollowUpGuidance { get; set; }

        /// <summary>
        /// 记录类型：0：24小时内入出院记录，1：出院记录，2：出观记录，3：自动出院记录，4：产科新生儿出院记录，5：转院记录

        /// </summary>
        [Display(Name = "记录类型")]
        [StringLength(1)]
        public virtual string RecordType { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_ObservedPatient 急诊留观病历 实体类
    /// </summary>
    [Serializable]
    public partial class CD_ObservedPatient
    {
        /// <summary>
        /// 留观病历id
        /// </summary>
        [Display(Name = "留观病历")]
        [StringLength(20)]
        public virtual string observedPatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        [Display(Name = "主诉")]
        [StringLength(50)]
        public virtual string ChiefComplaint { get; set; }

        /// <summary>
        /// 现病史
        /// </summary>
        [Display(Name = "现病史")]
        [StringLength(4000)]
        public virtual string PresentHistory { get; set; }

        /// <summary>
        /// 既往史
        /// </summary>
        [Display(Name = "既往史")]
        [StringLength(4000)]
        public virtual string PreviousHistory { get; set; }

        /// <summary>
        /// 个人史
        /// </summary>
        [Display(Name = "个人史")]
        [StringLength(4000)]
        public virtual string PersonalHistory { get; set; }

        /// <summary>
        /// 婚育史
        /// </summary>
        [Display(Name = "婚育史")]
        [StringLength(4000)]
        public virtual string ObstericalHistory { get; set; }

        /// <summary>
        /// 家族史
        /// </summary>
        [Display(Name = "家族史")]
        [StringLength(4000)]
        public virtual string FamilyHistory { get; set; }

        /// <summary>
        /// 体格检查
        /// </summary>
        [Display(Name = "体格检查")]
        [StringLength(4000)]
        public virtual string PhysicalExamination { get; set; }

        /// <summary>
        /// 辅助检查
        /// </summary>
        [Display(Name = "辅助检查")]
        [StringLength(4000)]
        public virtual string OtherInspection { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_HospitalRecord 入院记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_HospitalRecord
    {
        /// <summary>
        /// 入院记录id
        /// </summary>
        [Display(Name = "入院记录")]
        [StringLength(20)]
        public virtual string HospitalRecordId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 记录类型  816

        /// </summary>
        [Display(Name = "记录类型")]
        public virtual int RecordType { get; set; }

        /// <summary>
        /// 病史陈述者
        /// </summary>
        [Display(Name = "病史陈述者")]
        [StringLength(20)]
        public virtual string Narrator { get; set; }

        /// <summary>
        /// 病史陈述者其他
        /// </summary>
        [Display(Name = "病史陈述者其他")]
        [StringLength(20)]
        public virtual string NarratorSupplement { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        [Display(Name = "主诉")]
        [StringLength(100)]
        public virtual string ChiefComplaint { get; set; }

        /// <summary>
        /// 现病史
        /// </summary>
        [Display(Name = "现病史")]
        [StringLength(4000)]
        public virtual string PresentHistory { get; set; }

        /// <summary>
        /// 既往史
        /// </summary>
        [Display(Name = "既往史")]
        [StringLength(4000)]
        public virtual string PreviousHistory { get; set; }

        /// <summary>
        /// 系统回顾
        /// </summary>
        [Display(Name = "系统回顾")]
        [StringLength(4000)]
        public virtual string SystemReview { get; set; }

        /// <summary>
        /// 个人史
        /// </summary>
        [Display(Name = "个人史")]
        [StringLength(4000)]
        public virtual string PersonalHistory { get; set; }

        /// <summary>
        /// 婚育史
        /// </summary>
        [Display(Name = "婚育史")]
        [StringLength(4000)]
        public virtual string ObstericalHistory { get; set; }

        /// <summary>
        /// 月经史
        /// </summary>
        [Display(Name = "月经史")]
        [StringLength(4000)]
        public virtual string MensesHistory { get; set; }

        /// <summary>
        /// 家族史
        /// </summary>
        [Display(Name = "家族史")]
        [StringLength(4000)]
        public virtual string FamilyHistory { get; set; }

        /// <summary>
        /// 喂养史
        /// </summary>
        [Display(Name = "喂养史")]
        [StringLength(200)]
        public virtual string FeedingHistory { get; set; }

        /// <summary>
        /// 出生史
        /// </summary>
        [Display(Name = "出生史")]
        [StringLength(200)]
        public virtual string BirthHistory { get; set; }

        /// <summary>
        /// 体格检查
        /// </summary>
        [Display(Name = "体格检查")]
        [StringLength(20000)]
        public virtual string PhysicalExam { get; set; }

        /// <summary>
        /// 专科检查
        /// </summary>
        [Display(Name = "专科检查")]
        [StringLength(20000)]
        public virtual string SpecialInspection { get; set; }

        /// <summary>
        /// 实验室检查
        /// </summary>
        [Display(Name = "实验室检查")]
        [StringLength(20000)]
        public virtual string LaboratoryExamination { get; set; }

        /// <summary>
        /// 特殊检查
        /// </summary>
        [Display(Name = "特殊检查")]
        [StringLength(20000)]
        public virtual string SpecialExamination { get; set; }

        /// <summary>
        /// 病理检查
        /// </summary>
        [Display(Name = "病理检查")]
        [StringLength(20000)]
        public virtual string PathologicalExamination { get; set; }

        /// <summary>
        /// 其他内容
        /// </summary>
        [Display(Name = "其他内容")]
        [StringLength(20000)]
        public virtual string OtherContent { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 保存方式0：暂存1：保存
        /// </summary>
        [Display(Name = "保存方式")]
        public virtual int? RecordState { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public virtual DateTime? RecordTime { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_Consultation 会诊单 实体类
    /// </summary>
    [Serializable]
    public partial class CD_Consultation
    {
        /// <summary>
        /// 会诊记录id
        /// </summary>
        [Display(Name = "会诊记录")]
        [StringLength(20)]
        public virtual string ConsultationId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(20)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 会诊状态：1：新开、2：已回复
        /// </summary>
        [Display(Name = "会诊状态")]
        [StringLength(1)]
        public virtual string ConsultationState { get; set; }

        /// <summary>
        /// 会诊类型：1：普通 2：紧急
        /// </summary>
        [Display(Name = "会诊类型")]
        [StringLength(1)]
        public virtual string ConsultationType { get; set; }

        /// <summary>
        /// 会诊医院类型：1：本院 2：外院
        /// </summary>
        [Display(Name = "会诊医院类型")]
        [StringLength(1)]
        public virtual string HospitalType { get; set; }

        /// <summary>
        /// 会诊医院名称
        /// </summary>
        [Display(Name = "会诊医院名称")]
        [StringLength(50)]
        public virtual string HospitalName { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        [Display(Name = "请求时间")]
        public virtual DateTime? ApplyTime { get; set; }

        /// <summary>
        /// 病情摘要
        /// </summary>
        [Display(Name = "病情摘要")]
        [StringLength(4000)]
        public virtual string DiseaseSummary { get; set; }

        /// <summary>
        /// 请求科室代码
        /// </summary>
        [Display(Name = "请求科室代码")]
        [StringLength(20)]
        public virtual string ApplyDepartCode { get; set; }

        /// <summary>
        /// 请求科室名称
        /// </summary>
        [Display(Name = "请求科室名称")]
        [StringLength(20)]
        public virtual string ApplyDepartName { get; set; }

        /// <summary>
        /// 请求病区代码
        /// </summary>
        [Display(Name = "请求病区代码")]
        [StringLength(20)]
        public virtual string ApplyWardCode { get; set; }

        /// <summary>
        /// 请求病区名称
        /// </summary>
        [Display(Name = "请求病区名称")]
        [StringLength(20)]
        public virtual string ApplyWardName { get; set; }

        /// <summary>
        /// 请求医生代码
        /// </summary>
        [Display(Name = "请求医生代码")]
        [StringLength(20)]
        public virtual string ApplyDoctorCode { get; set; }

        /// <summary>
        /// 请求医生姓名
        /// </summary>
        [Display(Name = "请求医生姓名")]
        [StringLength(20)]
        public virtual string ApplyDoctorName { get; set; }

        /// <summary>
        /// 申请科室代码
        /// </summary>
        [Display(Name = "申请科室代码")]
        [StringLength(20)]
        public virtual string RequestDepartCode { get; set; }

        /// <summary>
        /// 申请人代码
        /// </summary>
        [Display(Name = "申请人代码")]
        [StringLength(20)]
        public virtual string RequesterCode { get; set; }

        /// <summary>
        /// 审核签名时间
        /// </summary>
        [Display(Name = "审核签名时间")]
        [StringLength(20)]
        public virtual string VerifierTime { get; set; }

        /// <summary>
        /// 审核签名医生代码
        /// </summary>
        [Display(Name = "审核签名医生代码")]
        [StringLength(20)]
        public virtual string VerifierCode { get; set; }

        /// <summary>
        /// 答复时间
        /// </summary>
        [Display(Name = "答复时间")]
        [StringLength(20)]
        public virtual string ReplyTime { get; set; }

        /// <summary>
        /// 答复内容
        /// </summary>
        [Display(Name = "答复内容")]
        [StringLength(4000)]
        public virtual string ReplyContent { get; set; }

        /// <summary>
        /// 答复科室代码
        /// </summary>
        [Display(Name = "答复科室代码")]
        [StringLength(20)]
        public virtual string ReplyDepartCode { get; set; }

        /// <summary>
        /// 答复科室名称
        /// </summary>
        [Display(Name = "答复科室名称")]
        [StringLength(20)]
        public virtual string ReplyDepartName { get; set; }

        /// <summary>
        /// 答复病区代码
        /// </summary>
        [Display(Name = "答复病区代码")]
        [StringLength(20)]
        public virtual string ReplyWardCode { get; set; }

        /// <summary>
        /// 答复病区名称
        /// </summary>
        [Display(Name = "答复病区名称")]
        [StringLength(20)]
        public virtual string ReplyWardName { get; set; }

        /// <summary>
        /// 答复医生代码
        /// </summary>
        [Display(Name = "答复医生代码")]
        [StringLength(20)]
        public virtual string ReplyDoctorCode { get; set; }

        /// <summary>
        /// 答复医生姓名
        /// </summary>
        [Display(Name = "答复医生姓名")]
        [StringLength(20)]
        public virtual string ReplyDoctorName { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_HospitalPhysicalRxam 体格检查 实体类
    /// </summary>
    [Serializable]
    public partial class CD_HospitalPhysicalRxam
    {
        /// <summary>
        /// 体格检查id
        /// </summary>
        [Display(Name = "体格检查")]
        [StringLength(20)]
        public virtual string PhysicalExamId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        [Display(Name = "体温")]
        public virtual double? Degree { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        [Display(Name = "脉搏")]
        [StringLength(10)]
        public virtual string Pulse { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        [Display(Name = "呼吸")]
        [StringLength(10)]
        public virtual string Breathe { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Display(Name = "舒张压")]
        [StringLength(10)]
        public virtual string DiastolicPressure { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Display(Name = "收缩压")]
        [StringLength(10)]
        public virtual string SystolicPressure { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Display(Name = "身高")]
        [StringLength(10)]
        public virtual string Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        [StringLength(10)]
        public virtual string Weight { get; set; }

        /// <summary>
        /// 发育
        /// </summary>
        [Display(Name = "发育")]
        [StringLength(50)]
        public virtual string Growth { get; set; }

        /// <summary>
        /// 营养
        /// </summary>
        [Display(Name = "营养")]
        [StringLength(50)]
        public virtual string Nutrition { get; set; }

        /// <summary>
        /// 意识
        /// </summary>
        [Display(Name = "意识")]
        [StringLength(50)]
        public virtual string Conscious { get; set; }

        /// <summary>
        /// 病容
        /// </summary>
        [Display(Name = "病容")]
        [StringLength(50)]
        public virtual string SicklyLook { get; set; }

        /// <summary>
        /// 合作
        /// </summary>
        [Display(Name = "合作")]
        [StringLength(50)]
        public virtual string Cooperation { get; set; }

        /// <summary>
        /// 神智
        /// </summary>
        [Display(Name = "神智")]
        [StringLength(50)]
        public virtual string Mind { get; set; }

        /// <summary>
        /// 呼吸频率
        /// </summary>
        [Display(Name = "呼吸频率")]
        [StringLength(50)]
        public virtual string Breathing { get; set; }

        /// <summary>
        /// 面容
        /// </summary>
        [Display(Name = "面容")]
        [StringLength(50)]
        public virtual string Face { get; set; }

        /// <summary>
        /// 表情
        /// </summary>
        [Display(Name = "表情")]
        [StringLength(50)]
        public virtual string Expression { get; set; }

        /// <summary>
        /// 体位
        /// </summary>
        [Display(Name = "体位")]
        [StringLength(50)]
        public virtual string Position { get; set; }

        /// <summary>
        /// 步态
        /// </summary>
        [Display(Name = "步态")]
        [StringLength(50)]
        public virtual string Tread { get; set; }

        /// <summary>
        /// 配合检查
        /// </summary>
        [Display(Name = "配合检查")]
        [StringLength(50)]
        public virtual string Cooperate { get; set; }

        /// <summary>
        /// 皮肤苍白
        /// </summary>
        [Display(Name = "皮肤苍白")]
        [StringLength(50)]
        public virtual string SkinPale { get; set; }

        /// <summary>
        /// 皮肤潮红
        /// </summary>
        [Display(Name = "皮肤潮红")]
        [StringLength(50)]
        public virtual string SkinFlush { get; set; }

        /// <summary>
        /// 面颊潮红
        /// </summary>
        [Display(Name = "面颊潮红")]
        [StringLength(50)]
        public virtual string FaceFlush { get; set; }

        /// <summary>
        /// 皮肤黄色
        /// </summary>
        [Display(Name = "皮肤黄色")]
        [StringLength(50)]
        public virtual string SkinYellow { get; set; }

        /// <summary>
        /// 皮疹
        /// </summary>
        [Display(Name = "皮疹")]
        [StringLength(50)]
        public virtual string Rash { get; set; }

        /// <summary>
        /// 紫癍
        /// </summary>
        [Display(Name = "紫癍")]
        [StringLength(50)]
        public virtual string PurpleMacula { get; set; }

        /// <summary>
        /// 水肿
        /// </summary>
        [Display(Name = "水肿")]
        [StringLength(50)]
        public virtual string Edema { get; set; }

        /// <summary>
        /// 脱水现象
        /// </summary>
        [Display(Name = "脱水现象")]
        [StringLength(50)]
        public virtual string Dehydration { get; set; }

        /// <summary>
        /// 松紧度
        /// </summary>
        [Display(Name = "松紧度")]
        [StringLength(50)]
        public virtual string Tightness { get; set; }

        /// <summary>
        /// 皮肤温度
        /// </summary>
        [Display(Name = "皮肤温度")]
        [StringLength(50)]
        public virtual string SkinDegree { get; set; }

        /// <summary>
        /// 出汗
        /// </summary>
        [Display(Name = "出汗")]
        [StringLength(50)]
        public virtual string Sweat { get; set; }

        /// <summary>
        /// 瘢痕
        /// </summary>
        [Display(Name = "瘢痕")]
        [StringLength(50)]
        public virtual string Scar { get; set; }

        /// <summary>
        /// 皮肤感染
        /// </summary>
        [Display(Name = "皮肤感染")]
        [StringLength(50)]
        public virtual string SkinInfaction { get; set; }

        /// <summary>
        /// 色泽
        /// </summary>
        [Display(Name = "色泽")]
        [StringLength(50)]
        public virtual string Color { get; set; }

        /// <summary>
        /// 出血
        /// </summary>
        [Display(Name = "出血")]
        [StringLength(50)]
        public virtual string Bleeding { get; set; }

        /// <summary>
        /// 头颅大小
        /// </summary>
        [Display(Name = "头颅大小")]
        [StringLength(50)]
        public virtual string HeadSize { get; set; }

        /// <summary>
        /// 头颅畸形
        /// </summary>
        [Display(Name = "头颅畸形")]
        [StringLength(50)]
        public virtual string HeadAbnormal { get; set; }

        /// <summary>
        /// 头颅包块
        /// </summary>
        [Display(Name = "头颅包块")]
        [StringLength(50)]
        public virtual string HeadMass { get; set; }

        /// <summary>
        /// 头颅压痛
        /// </summary>
        [Display(Name = "头颅压痛")]
        [StringLength(50)]
        public virtual string HeadTenderness { get; set; }

        /// <summary>
        /// 头颅凹陷
        /// </summary>
        [Display(Name = "头颅凹陷")]
        [StringLength(50)]
        public virtual string HeadDent { get; set; }

        /// <summary>
        /// 头部外形
        /// </summary>
        [Display(Name = "头部外形")]
        [StringLength(50)]
        public virtual string HeadShape { get; set; }

        /// <summary>
        /// 眼睑
        /// </summary>
        [Display(Name = "眼睑")]
        [StringLength(50)]
        public virtual string Eyelid { get; set; }

        /// <summary>
        /// 结膜
        /// </summary>
        [Display(Name = "结膜")]
        [StringLength(50)]
        public virtual string Conjunctiva { get; set; }

        /// <summary>
        /// 巩膜
        /// </summary>
        [Display(Name = "巩膜")]
        [StringLength(50)]
        public virtual string Sclera { get; set; }

        /// <summary>
        /// 左眼象限运动
        /// </summary>
        [Display(Name = "左眼象限运动")]
        [StringLength(50)]
        public virtual string LeftEyeActivity { get; set; }

        /// <summary>
        /// 右眼象限运动
        /// </summary>
        [Display(Name = "右眼象限运动")]
        [StringLength(50)]
        public virtual string RightEyeActivity { get; set; }

        /// <summary>
        /// 左眼外形
        /// </summary>
        [Display(Name = "左眼外形")]
        [StringLength(50)]
        public virtual string LeftEyeShape { get; set; }

        /// <summary>
        /// 右眼外形
        /// </summary>
        [Display(Name = "右眼外形")]
        [StringLength(50)]
        public virtual string RightEyeShape { get; set; }

        /// <summary>
        /// 角膜
        /// </summary>
        [Display(Name = "角膜")]
        [StringLength(200)]
        public virtual string Conea { get; set; }

        /// <summary>
        /// 瞳孔
        /// </summary>
        [Display(Name = "瞳孔")]
        [StringLength(50)]
        public virtual string Pupil { get; set; }

        /// <summary>
        /// 左眼对光反射
        /// </summary>
        [Display(Name = "左眼对光反射")]
        [StringLength(50)]
        public virtual string LeftEyeReflex { get; set; }

        /// <summary>
        /// 右眼对光反射
        /// </summary>
        [Display(Name = "右眼对光反射")]
        [StringLength(50)]
        public virtual string RightEyeReflex { get; set; }

        /// <summary>
        /// 鼻外形
        /// </summary>
        [Display(Name = "鼻外形")]
        [StringLength(50)]
        public virtual string NoseShape { get; set; }

        /// <summary>
        /// 鼻其他异常
        /// </summary>
        [Display(Name = "鼻其他异常")]
        [StringLength(50)]
        public virtual string NoseOther { get; set; }

        /// <summary>
        /// 副鼻窦压痛
        /// </summary>
        [Display(Name = "副鼻窦压痛")]
        [StringLength(50)]
        public virtual string ParanasalSinusTenderness { get; set; }

        /// <summary>
        /// 鼻通气
        /// </summary>
        [Display(Name = "鼻通气")]
        [StringLength(50)]
        public virtual string NasalVentilation { get; set; }

        /// <summary>
        /// 唇
        /// </summary>
        [Display(Name = "唇")]
        [StringLength(50)]
        public virtual string Lip { get; set; }

        /// <summary>
        /// 口腔黏膜
        /// </summary>
        [Display(Name = "口腔黏膜")]
        [StringLength(50)]
        public virtual string OralMucosa { get; set; }

        /// <summary>
        /// 腮腺导管开口
        /// </summary>
        [Display(Name = "腮腺导管开口")]
        [StringLength(50)]
        public virtual string Parotid { get; set; }

        /// <summary>
        /// 舌
        /// </summary>
        [Display(Name = "舌")]
        [StringLength(50)]
        public virtual string Tongue { get; set; }

        /// <summary>
        /// 牙龈
        /// </summary>
        [Display(Name = "牙龈")]
        [StringLength(50)]
        public virtual string Gum { get; set; }

        /// <summary>
        /// 龋齿
        /// </summary>
        [Display(Name = "龋齿")]
        [StringLength(50)]
        public virtual string DecayedTooth { get; set; }

        /// <summary>
        /// 扁桃体
        /// </summary>
        [Display(Name = "扁桃体")]
        [StringLength(200)]
        public virtual string Tonsil { get; set; }

        /// <summary>
        /// 咽
        /// </summary>
        [Display(Name = "咽")]
        [StringLength(50)]
        public virtual string Pharynx { get; set; }

        /// <summary>
        /// 声音
        /// </summary>
        [Display(Name = "声音")]
        [StringLength(50)]
        public virtual string Voice { get; set; }

        /// <summary>
        /// 淋巴结
        /// </summary>
        [Display(Name = "淋巴结")]
        [StringLength(50)]
        public virtual string LymphNode { get; set; }

        /// <summary>
        /// 颈部抵抗感
        /// </summary>
        [Display(Name = "颈部抵抗感")]
        [StringLength(50)]
        public virtual string NeckEndpoint { get; set; }

        /// <summary>
        /// 颈动脉
        /// </summary>
        [Display(Name = "颈动脉")]
        [StringLength(50)]
        public virtual string NeckArtery { get; set; }

        /// <summary>
        /// 颈静脉
        /// </summary>
        [Display(Name = "颈静脉")]
        [StringLength(50)]
        public virtual string JugularVein { get; set; }

        /// <summary>
        /// 气管位置
        /// </summary>
        [Display(Name = "气管位置")]
        [StringLength(50)]
        public virtual string TrachealPosition { get; set; }

        /// <summary>
        /// 颈静脉回流征
        /// </summary>
        [Display(Name = "颈静脉回流征")]
        [StringLength(50)]
        public virtual string NeckVeinReflux { get; set; }

        /// <summary>
        /// 甲状腺
        /// </summary>
        [Display(Name = "甲状腺")]
        [StringLength(50)]
        public virtual string Thyroid { get; set; }

        /// <summary>
        /// 胸部外形
        /// </summary>
        [Display(Name = "胸部外形")]
        [StringLength(50)]
        public virtual string ChestShape { get; set; }

        /// <summary>
        /// 胸廓
        /// </summary>
        [Display(Name = "胸廓")]
        [StringLength(50)]
        public virtual string Thorax { get; set; }

        /// <summary>
        /// 乳房
        /// </summary>
        [Display(Name = "乳房")]
        [StringLength(50)]
        public virtual string Breast { get; set; }

        /// <summary>
        /// 乳突压痛
        /// </summary>
        [Display(Name = "乳突压痛")]
        [StringLength(50)]
        public virtual string MastoidTenderness { get; set; }

        /// <summary>
        /// 呼吸运动
        /// </summary>
        [Display(Name = "呼吸运动")]
        [StringLength(50)]
        public virtual string BreathingMovement { get; set; }

        /// <summary>
        /// 语颤
        /// </summary>
        [Display(Name = "语颤")]
        [StringLength(100)]
        public virtual string VF { get; set; }

        /// <summary>
        /// 胸膜摩擦感
        /// </summary>
        [Display(Name = "胸膜摩擦感")]
        [StringLength(50)]
        public virtual string PleuraFriction { get; set; }

        /// <summary>
        /// 叩诊音
        /// </summary>
        [Display(Name = "叩诊音")]
        [StringLength(50)]
        public virtual string PercussionSound { get; set; }

        /// <summary>
        /// 肺下界活动度
        /// </summary>
        [Display(Name = "肺下界活动度")]
        [StringLength(50)]
        public virtual string LungsLbActivity { get; set; }

        /// <summary>
        /// 呼吸节奏
        /// </summary>
        [Display(Name = "呼吸节奏")]
        [StringLength(50)]
        public virtual string BreathingRhythm { get; set; }

        /// <summary>
        /// 双肺呼吸音
        /// </summary>
        [Display(Name = "双肺呼吸音")]
        [StringLength(50)]
        public virtual string BreathingSound { get; set; }

        /// <summary>
        /// 语音传导
        /// </summary>
        [Display(Name = "语音传导")]
        [StringLength(50)]
        public virtual string VoiceConducation { get; set; }

        /// <summary>
        /// 啰音
        /// </summary>
        [Display(Name = "啰音")]
        [StringLength(50)]
        public virtual string Rales { get; set; }

        /// <summary>
        /// 胸膜摩擦音
        /// </summary>
        [Display(Name = "胸膜摩擦音")]
        [StringLength(50)]
        public virtual string PleuraFrictionSonds { get; set; }

        /// <summary>
        /// 心尖搏动弥散
        /// </summary>
        [Display(Name = "心尖搏动弥散")]
        [StringLength(50)]
        public virtual string ApicalPulseDispersion { get; set; }

        /// <summary>
        /// 其他位置移动
        /// </summary>
        [Display(Name = "其他位置移动")]
        [StringLength(50)]
        public virtual string OtherPositionMove { get; set; }

        /// <summary>
        /// 心尖搏动位置
        /// </summary>
        [Display(Name = "心尖搏动位置")]
        [StringLength(50)]
        public virtual string ApicalPulsePosition { get; set; }

        /// <summary>
        /// 心尖搏动
        /// </summary>
        [Display(Name = "心尖搏动")]
        [StringLength(50)]
        public virtual string ApicalPulse { get; set; }

        /// <summary>
        /// 振颤
        /// </summary>
        [Display(Name = "振颤")]
        [StringLength(50)]
        public virtual string Flapping { get; set; }

        /// <summary>
        /// 心包摩檫感
        /// </summary>
        [Display(Name = "心包摩檫感")]
        [StringLength(50)]
        public virtual string PericardiumFriction { get; set; }

        /// <summary>
        /// 心浊音界
        /// </summary>
        [Display(Name = "心浊音界")]
        [StringLength(300)]
        public virtual string HeartDulnessArea { get; set; }

        /// <summary>
        /// 肝脏
        /// </summary>
        [Display(Name = "肝脏")]
        [StringLength(50)]
        public virtual string Liver { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [Display(Name = "心率")]
        [StringLength(50)]
        public virtual string HeartRate { get; set; }

        /// <summary>
        /// 心律
        /// </summary>
        [Display(Name = "心律")]
        [StringLength(50)]
        public virtual string HeartRhythm { get; set; }

        /// <summary>
        /// 锁骨中线距前中线
        /// </summary>
        [Display(Name = "锁骨中线距前中线")]
        [StringLength(50)]
        public virtual string ClavicalFrontLength { get; set; }

        /// <summary>
        /// 心音
        /// </summary>
        [Display(Name = "心音")]
        [StringLength(50)]
        public virtual string HeartSounds { get; set; }

        /// <summary>
        /// 额外心音
        /// </summary>
        [Display(Name = "额外心音")]
        [StringLength(50)]
        public virtual string OtherHeartSounds { get; set; }

        /// <summary>
        /// 杂音
        /// </summary>
        [Display(Name = "杂音")]
        [StringLength(50)]
        public virtual string Noise { get; set; }

        /// <summary>
        /// 心包摩擦音
        /// </summary>
        [Display(Name = "心包摩擦音")]
        [StringLength(50)]
        public virtual string PericardiumFrictionSounds { get; set; }

        /// <summary>
        /// 异常血管征
        /// </summary>
        [Display(Name = "异常血管征")]
        [StringLength(50)]
        public virtual string AbnormalVesselSign { get; set; }

        /// <summary>
        /// 腹部外形
        /// </summary>
        [Display(Name = "腹部外形")]
        [StringLength(200)]
        public virtual string AbdominalShape { get; set; }

        /// <summary>
        /// 腹式呼吸
        /// </summary>
        [Display(Name = "腹式呼吸")]
        [StringLength(50)]
        public virtual string AbdominalBreathing { get; set; }

        /// <summary>
        /// 脐
        /// </summary>
        [Display(Name = "脐")]
        [StringLength(50)]
        public virtual string Navel { get; set; }

        /// <summary>
        /// 腹部其他异常
        /// </summary>
        [Display(Name = "腹部其他异常")]
        [StringLength(50)]
        public virtual string AbdominalOtherAbnormal { get; set; }

        /// <summary>
        /// 腹壁紧张度
        /// </summary>
        [Display(Name = "腹壁紧张度")]
        [StringLength(50)]
        public virtual string AbdominalWallTension { get; set; }

        /// <summary>
        /// 压痛
        /// </summary>
        [Display(Name = "压痛")]
        [StringLength(50)]
        public virtual string Tenderness { get; set; }

        /// <summary>
        /// 反跳痛
        /// </summary>
        [Display(Name = "反跳痛")]
        [StringLength(50)]
        public virtual string ReboundTenderness { get; set; }

        /// <summary>
        /// 液波振颤
        /// </summary>
        [Display(Name = "液波振颤")]
        [StringLength(50)]
        public virtual string FluidWaveFlapping { get; set; }

        /// <summary>
        /// 振水声
        /// </summary>
        [Display(Name = "振水声")]
        [StringLength(50)]
        public virtual string FlappingWaterSounds { get; set; }

        /// <summary>
        /// 周围血管征
        /// </summary>
        [Display(Name = "周围血管征")]
        [StringLength(50)]
        public virtual string PeripheralVascularSign { get; set; }

        /// <summary>
        /// 胆囊
        /// </summary>
        [Display(Name = "胆囊")]
        [StringLength(50)]
        public virtual string Gallbladder { get; set; }

        /// <summary>
        /// Murphy征
        /// </summary>
        [Display(Name = "征")]
        [StringLength(50)]
        public virtual string Murphy { get; set; }

        /// <summary>
        /// 脾脏
        /// </summary>
        [Display(Name = "脾脏")]
        [StringLength(50)]
        public virtual string Spleen { get; set; }

        /// <summary>
        /// 肝浊音界
        /// </summary>
        [Display(Name = "肝浊音界")]
        [StringLength(50)]
        public virtual string LiverDulnessArea { get; set; }

        /// <summary>
        /// 肠鸣音
        /// </summary>
        [Display(Name = "肠鸣音")]
        [StringLength(50)]
        public virtual string BowelSounds { get; set; }

        /// <summary>
        /// 肠鸣音频率
        /// </summary>
        [Display(Name = "肠鸣音频率")]
        [StringLength(50)]
        public virtual string BowelSoundsFrequency { get; set; }

        /// <summary>
        /// 气过水音
        /// </summary>
        [Display(Name = "气过水音")]
        [StringLength(50)]
        public virtual string AirPathWaterSounds { get; set; }

        /// <summary>
        /// 血管杂音
        /// </summary>
        [Display(Name = "血管杂音")]
        [StringLength(50)]
        public virtual string VesselOtherSounds { get; set; }

        /// <summary>
        /// 肛门直肠
        /// </summary>
        [Display(Name = "肛门直肠")]
        [StringLength(100)]
        public virtual string RectumAnus { get; set; }

        /// <summary>
        /// 生殖器
        /// </summary>
        [Display(Name = "生殖器")]
        [StringLength(100)]
        public virtual string Genitals { get; set; }

        /// <summary>
        /// 脊柱
        /// </summary>
        [Display(Name = "脊柱")]
        [StringLength(50)]
        public virtual string Spine { get; set; }

        /// <summary>
        /// 压痛叩痛
        /// </summary>
        [Display(Name = "压痛叩痛")]
        [StringLength(50)]
        public virtual string PressPercussPain { get; set; }

        /// <summary>
        /// 活动度
        /// </summary>
        [Display(Name = "活动度")]
        [StringLength(50)]
        public virtual string Activity { get; set; }

        /// <summary>
        /// 四肢
        /// </summary>
        [Display(Name = "四肢")]
        [StringLength(50)]
        public virtual string Limbs { get; set; }

        /// <summary>
        /// 杵状指趾
        /// </summary>
        [Display(Name = "杵状指趾")]
        [StringLength(50)]
        public virtual string ClubbedFinger { get; set; }

        /// <summary>
        /// 腹壁反射
        /// </summary>
        [Display(Name = "腹壁反射")]
        [StringLength(50)]
        public virtual string NapesReflex { get; set; }

        /// <summary>
        /// 肌张力
        /// </summary>
        [Display(Name = "肌张力")]
        [StringLength(50)]
        public virtual string MuscleTension { get; set; }

        /// <summary>
        /// 四肢肌力
        /// </summary>
        [Display(Name = "四肢肌力")]
        [StringLength(50)]
        public virtual string LimbMuscleStrength { get; set; }

        /// <summary>
        /// 肢体瘫痪
        /// </summary>
        [Display(Name = "肢体瘫痪")]
        [StringLength(50)]
        public virtual string LimbParalysis { get; set; }

        /// <summary>
        /// 肱二头肌反射
        /// </summary>
        [Display(Name = "肱二头肌反射")]
        [StringLength(50)]
        public virtual string BicepsReflex { get; set; }

        /// <summary>
        /// Hoffman征
        /// </summary>
        [Display(Name = "征")]
        [StringLength(50)]
        public virtual string Hoffman { get; set; }

        /// <summary>
        /// 跟腱反射
        /// </summary>
        [Display(Name = "跟腱反射")]
        [StringLength(50)]
        public virtual string AchillesTendoReflex { get; set; }

        /// <summary>
        /// Babinski征
        /// </summary>
        [Display(Name = "征")]
        [StringLength(50)]
        public virtual string BabinshisSign { get; set; }

        /// <summary>
        /// 膝腱反射
        /// </summary>
        [Display(Name = "膝腱反射")]
        [StringLength(50)]
        public virtual string KneeTendonReflex { get; set; }

        /// <summary>
        /// Kernig征
        /// </summary>
        [Display(Name = "征")]
        [StringLength(50)]
        public virtual string kernig { get; set; }

        /// <summary>
        /// 软硬度
        /// </summary>
        [Display(Name = "软硬度")]
        [StringLength(50)]
        public virtual string Softness { get; set; }

        /// <summary>
        /// 肋间隙
        /// </summary>
        [Display(Name = "肋间隙")]
        [StringLength(50)]
        public virtual string RibGap { get; set; }

        /// <summary>
        /// 蠕动波
        /// </summary>
        [Display(Name = "蠕动波")]
        [StringLength(50)]
        public virtual string PeristalticWave { get; set; }

        /// <summary>
        /// 肾区叩痛
        /// </summary>
        [Display(Name = "肾区叩痛")]
        [StringLength(50)]
        public virtual string KidneyAreaPercussionPain { get; set; }

        /// <summary>
        /// 移动性浊音
        /// </summary>
        [Display(Name = "移动性浊音")]
        [StringLength(50)]
        public virtual string MobileDullness { get; set; }

        /// <summary>
        /// 浅表淋巴结
        /// </summary>
        [Display(Name = "浅表淋巴结")]
        [StringLength(50)]
        public virtual string SuperficialLymphNodes { get; set; }

        /// <summary>
        /// 听力粗测
        /// </summary>
        [Display(Name = "听力粗测")]
        [StringLength(50)]
        public virtual string ListeningRoughTest { get; set; }

        /// <summary>
        /// 外生殖器
        /// </summary>
        [Display(Name = "外生殖器")]
        [StringLength(50)]
        public virtual string ExternalGenitalia { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        [StringLength(100)]
        public virtual string Other { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 体格图片编辑
        /// </summary>
        [Display(Name = "体格图片编辑")]
        [StringLength(20000)]
        public virtual string TgImgSrc { get; set; }

        /// <summary>
        /// 心肺图片编辑
        /// </summary>
        [Display(Name = "心肺图片编辑")]
        [StringLength(20000)]
        public virtual string XfImgSrc { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_FormEmr 表单病历 实体类
    /// </summary>
    [Serializable]
    public partial class CD_FormEmr
    {
        /// <summary>
        /// 表单病历id
        /// </summary>
        [Display(Name = "表单病历")]
        [StringLength(20)]
        public virtual string FormEmrId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 分类id
        /// </summary>
        [Display(Name = "分类")]
        [StringLength(20)]
        public virtual string CategoryId { get; set; }

        /// <summary>
        /// 模板id
        /// </summary>
        [Display(Name = "模板")]
        [StringLength(20)]
        public virtual string FormId { get; set; }

        /// <summary>
        /// 知情同意书内容
        /// </summary>
        [Display(Name = "知情同意书内容")]
        [StringLength(20000)]
        public virtual string FormContent { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_FormEmrTemplate 表单病历模板 实体类
    /// </summary>
    [Serializable]
    public partial class CD_FormEmrTemplate
    {
        /// <summary>
        /// 模板id
        /// </summary>
        [Display(Name = "模板")]
        [StringLength(20)]
        public virtual string TemplateId { get; set; }

        /// <summary>
        /// 父类模板id
        /// </summary>
        [Display(Name = "父类模板")]
        [StringLength(20)]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [Display(Name = "模板名称")]
        [StringLength(200)]
        public virtual string TemplateName { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [Display(Name = "模板内容")]
        [StringLength(20000)]
        public virtual string TemplateContent { get; set; }

        /// <summary>
        /// 模板类型10知情同意书，11营养评估，12康复评估，13手术风险评估表，14手术安全核查表，15心血管介入治疗术安全核查表
        /// </summary>
        [Display(Name = "模板类型")]
        public virtual int? TemplateType { get; set; }

        /// <summary>
        /// 拼音输入码
        /// </summary>
        [Display(Name = "拼音输入码")]
        [StringLength(50)]
        public virtual string PhoneticCode { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Display(Name = "医院名称")]
        [StringLength(100)]
        public virtual string HospitalName { get; set; }

        /// <summary>
        /// 应用科室
        /// </summary>
        [Display(Name = "应用科室")]
        [StringLength(50)]
        public virtual string ApplicationDepartment { get; set; }

        /// <summary>
        /// 末级判别0不是未级1未级
        /// </summary>
        [Display(Name = "末级判别")]
        public virtual int? ISLast { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_ObservedPatientInfo 急诊留观病历_基本信息 实体类
    /// </summary>
    [Serializable]
    public partial class CD_ObservedPatientInfo
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [Display(Name = "流水号")]
        public virtual long IncrementId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 检伤分类 1:Ⅰ类（危急)2:Ⅱ类（危重）3:Ⅲ类（紧急）4:Ⅳ类（不紧急）5:Ⅴ类（非急诊）
        /// </summary>
        [Display(Name = "检伤分类")]
        public virtual int? TriageClassify { get; set; }

        /// <summary>
        /// 检伤分类描述
        /// </summary>
        [Display(Name = "检伤分类描述")]
        [StringLength(200)]
        public virtual string TriageClassifyDesc { get; set; }

        /// <summary>
        /// 检伤操作1.留抢2.留抢转留观3.留观
        /// </summary>
        [Display(Name = "检伤操作")]
        [StringLength(1)]
        public virtual string TriageOperating { get; set; }

        /// <summary>
        /// 病史提供者
        /// </summary>
        [Display(Name = "病史提供者")]
        [StringLength(20)]
        public virtual string MedicalHistoryProvider { get; set; }

        /// <summary>
        /// 患者关系
        /// </summary>
        [Display(Name = "患者关系")]
        public virtual int? PatientRelationship { get; set; }

        /// <summary>
        /// 来院方式1.120急救2.家庭护送3.社会人员护送4.110护送5.患者自行来院
        /// </summary>
        [Display(Name = "来院方式")]
        public virtual int? ToHospitalWay { get; set; }

        /// <summary>
        /// 医生签名
        /// </summary>
        [Display(Name = "医生签名")]
        [StringLength(20)]
        public virtual string DoctorSignature { get; set; }

        /// <summary>
        /// 诊疗组长签名
        /// </summary>
        [Display(Name = "诊疗组长签名")]
        [StringLength(20)]
        public virtual string TheheadofthepatientSignature { get; set; }

        /// <summary>
        /// 主任签名
        /// </summary>
        [Display(Name = "主任签名")]
        [StringLength(20)]
        public virtual string DirectorSignature { get; set; }

        /// <summary>
        /// 护士签名
        /// </summary>
        [Display(Name = "护士签名")]
        [StringLength(20)]
        public virtual string NurseSignature { get; set; }

        /// <summary>
        /// 护士长签名
        /// </summary>
        [Display(Name = "护士长签名")]
        [StringLength(20)]
        public virtual string HeadNurseSignature { get; set; }

        /// <summary>
        /// 签名日期
        /// </summary>
        [Display(Name = "签名日期")]
        [StringLength(20)]
        public virtual string SignatureDate { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_MedicalRecordChanges  病历修改记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MedicalRecordChanges
    {
        /// <summary>
        /// 病历修改记录id
        /// </summary>
        [Display(Name = "病历修改记录")]
        [StringLength(20)]
        public virtual string MedicalRecordChangeId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 修改内容
        /// </summary>
        [Display(Name = "修改内容")]
        [StringLength(20000)]
        public virtual string ChangeContent { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_CommonLanguage 常用语 实体类
    /// </summary>
    [Serializable]
    public partial class CD_CommonLanguage
    {
        /// <summary>
        /// 常用语id
        /// </summary>
        [Display(Name = "常用语")]
        [StringLength(20)]
        public virtual string CommonlanguageId { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 常用语标题
        /// </summary>
        [Display(Name = "常用语标题")]
        [StringLength(50)]
        public virtual string CommonLanguageTitle { get; set; }

        /// <summary>
        /// 常用语内容
        /// </summary>
        [Display(Name = "常用语内容")]
        [StringLength(4000)]
        public virtual string CommonLanguageContent { get; set; }

        /// <summary>
        /// 常用语父级id
        /// </summary>
        [Display(Name = "常用语父级")]
        [StringLength(20)]
        public virtual string CommonLanguageParentid { get; set; }

        /// <summary>
        /// 是否分类判别
        /// </summary>
        [Display(Name = "是否分类判别")]
        public virtual int? Iscategory { get; set; }

        /// <summary>
        /// 常用语类型
        /// </summary>
        [Display(Name = "常用语类型")]
        [StringLength(20)]
        public virtual string CommonlanguageType { get; set; }

        /// <summary>
        /// 应用范围0全院 1科室 3个人
        /// </summary>
        [Display(Name = "应用范围")]
        public virtual int? Apply { get; set; }

        /// <summary>
        /// 引用范围id
        /// </summary>
        [Display(Name = "引用范围")]
        [StringLength(20)]
        public virtual string Apply_id { get; set; }

        /// <summary>
        /// 排序序号
        /// </summary>
        [Display(Name = "排序序号")]
        [StringLength(10)]
        public virtual string Orderby { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_Score 评分记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_Score
    {
        /// <summary>
        /// 评分ID
        /// </summary>
        [Display(Name = "评分")]
        [StringLength(20)]
        public virtual string ScoreId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 评分时间
        /// </summary>
        [Display(Name = "评分时间")]
        public virtual DateTime? ScoreTime { get; set; }

        /// <summary>
        /// 评分类型
        /// </summary>
        [Display(Name = "评分类型")]
        public virtual int? ScoreType { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        [Display(Name = "得分")]
        public virtual int? PatientScore { get; set; }

        /// <summary>
        /// 评分人
        /// </summary>
        [Display(Name = "评分人")]
        [StringLength(20)]
        public virtual string StaffId { get; set; }

        /// <summary>
        /// 评分人姓名
        /// </summary>
        [Display(Name = "评分人姓名")]
        [StringLength(20)]
        public virtual string ScoreerName { get; set; }

        /// <summary>
        /// 评分内容（xml或json数据）
        /// </summary>
        [Display(Name = "评分内容")]
        [StringLength(20000)]
        public virtual string ScoreDetail { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_PharmacyRecord 药学监护日志 实体类
    /// </summary>
    [Serializable]
    public partial class CD_PharmacyRecord
    {
        /// <summary>
        /// 药学监护日志id
        /// </summary>
        [Display(Name = "药学监护日志")]
        [StringLength(20)]
        public virtual string PharmacyId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 日志类别id
        /// </summary>
        [Display(Name = "日志类别")]
        [StringLength(50)]
        public virtual string TypeId { get; set; }

        /// <summary>
        /// 日志其他类别
        /// </summary>
        [Display(Name = "日志其他类别")]
        [StringLength(50)]
        public virtual string OtherType { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        [StringLength(50)]
        public virtual string RecordTime { get; set; }

        /// <summary>
        /// 是否需要换页打印
        /// </summary>
        [Display(Name = "是否需要换页打印")]
        public virtual int? ChangePagePrint { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        [Display(Name = "记录内容")]
        [StringLength(3000)]
        public virtual string RecordContent { get; set; }

        /// <summary>
        /// 修改历史
        /// </summary>
        [Display(Name = "修改历史")]
        public virtual int? ChangeHistory { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_TreatPlan 多科协作诊疗计划 实体类
    /// </summary>
    [Serializable]
    public partial class CD_TreatPlan
    {
        /// <summary>
        /// 诊疗计划id
        /// </summary>
        [Display(Name = "诊疗计划")]
        [StringLength(20)]
        public virtual string TreatPlanId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 计划制定时间
        /// </summary>
        [Display(Name = "计划制定时间")]
        public virtual DateTime? MakeTime { get; set; }

        /// <summary>
        /// 分类0医疗1会诊2营养3康复4用药检测计划5护理
        /// </summary>
        [Display(Name = "分类")]
        public virtual int? PlanType { get; set; }

        /// <summary>
        /// 问题
        /// </summary>
        [Display(Name = "问题")]
        [StringLength(4000)]
        public virtual string Problem { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        [Display(Name = "目标")]
        [StringLength(4000)]
        public virtual string Goal { get; set; }

        /// <summary>
        /// 措施
        /// </summary>
        [Display(Name = "措施")]
        [StringLength(4000)]
        public virtual string Action { get; set; }

        /// <summary>
        /// 计划制定人
        /// </summary>
        [Display(Name = "计划制定人")]
        [StringLength(20)]
        public virtual string MakeId { get; set; }

        /// <summary>
        /// 计划制定人姓名
        /// </summary>
        [Display(Name = "计划制定人姓名")]
        [StringLength(20)]
        public virtual string MakeName { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历文书 CD_OuthospitalCard 出院证 实体类
    /// </summary>
    [Serializable]
    public partial class CD_OuthospitalCard
    {
        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 建议
        /// </summary>
        [Display(Name = "建议")]
        [StringLength(4000)]
        public virtual string Proposal { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

    }
    /// <summary>
    ///病历文书 CD_InpatientCard 住院卡 实体类
    /// </summary>
    [Serializable]
    public partial class CD_InpatientCard
    {
        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 并发症
        /// </summary>
        [Display(Name = "并发症")]
        [StringLength(1000)]
        public virtual string Complication { get; set; }

        /// <summary>
        /// 治疗简要
        /// </summary>
        [Display(Name = "治疗简要")]
        [StringLength(4000)]
        public virtual string BriefTreatment { get; set; }

        /// <summary>
        /// 愈合时间
        /// </summary>
        [Display(Name = "愈合时间")]
        [StringLength(20)]
        public virtual string HealingTime { get; set; }

        /// <summary>
        /// 术后并发症 :休克;出血;脓肿;裂缝;肺炎;败血症;其他;无
        /// </summary>
        [Display(Name = "术后并发症")]
        [StringLength(20)]
        public virtual string Complications { get; set; }

        /// <summary>
        /// 接收医院
        /// </summary>
        [Display(Name = "接收医院")]
        [StringLength(100)]
        public virtual string ReceivingHospital { get; set; }

        /// <summary>
        /// 接收社区
        /// </summary>
        [Display(Name = "接收社区")]
        [StringLength(100)]
        public virtual string ReceivingCommunity { get; set; }

        /// <summary>
        /// 疾病转归;医嘱离院;非医嘱离院;死亡;其他
        /// </summary>
        [Display(Name = "疾病转归")]
        [StringLength(20)]
        public virtual string DiseaseOutCome { get; set; }

        /// <summary>
        /// 保存状态
        /// </summary>
        [Display(Name = "保存状态")]
        public virtual int? SaveState { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

    }
    /// <summary>
    ///病历文书 CD_MedicalRecordAccessRecord 病历查阅记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MedicalRecordAccessRecord
    {
        /// <summary>
        /// 查阅ID
        /// </summary>
        [Display(Name = "查阅")]
        [StringLength(20)]
        public virtual string AccessID { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 申请人员ID
        /// </summary>
        [Display(Name = "申请人员")]
        [StringLength(20)]
        public virtual string ApplyUserID { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Display(Name = "申请时间")]
        public virtual DateTime? ApplyDate { get; set; }

        /// <summary>
        /// 查阅状态0审阅1已审阅
        /// </summary>
        [Display(Name = "查阅状态")]
        public virtual int? AccessState { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_DoctorGroup 医生分组 实体类
    /// </summary>
    [Serializable]
    public partial class AI_DoctorGroup
    {
        /// <summary>
        /// 医生分组id
        /// </summary>
        [Display(Name = "医生分组")]
        [StringLength(20)]
        public virtual string DoctorGroupId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        [Display(Name = "组号")]
        [StringLength(20)]
        public virtual string GroupNum { get; set; }

        /// <summary>
        /// 组名
        /// </summary>
        [Display(Name = "组名")]
        [StringLength(20)]
        public virtual string GroupName { get; set; }

        /// <summary>
        /// 组长id
        /// </summary>
        [Display(Name = "组长")]
        [StringLength(20)]
        public virtual string ChiefId { get; set; }

        /// <summary>
        /// 组长工号
        /// </summary>
        [Display(Name = "组长工号")]
        [StringLength(20)]
        public virtual string ChiefNum { get; set; }

        /// <summary>
        /// 组长姓名
        /// </summary>
        [Display(Name = "组长姓名")]
        [StringLength(20)]
        public virtual string ChiefName { get; set; }

        /// <summary>
        /// 副组长id
        /// </summary>
        [Display(Name = "副组长")]
        [StringLength(20)]
        public virtual string DeputyId { get; set; }

        /// <summary>
        /// 副组长工号
        /// </summary>
        [Display(Name = "副组长工号")]
        [StringLength(20)]
        public virtual string DeputyNum { get; set; }

        /// <summary>
        /// 副组长姓名
        /// </summary>
        [Display(Name = "副组长姓名")]
        [StringLength(20)]
        public virtual string DeputyName { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        [Display(Name = "所属科室")]
        [StringLength(20)]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 所属科室名称
        /// </summary>
        [Display(Name = "所属科室名称")]
        [StringLength(20)]
        public virtual string DeptName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(100)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_GroupMember 医生组成员 实体类
    /// </summary>
    [Serializable]
    public partial class AI_GroupMember
    {
        /// <summary>
        /// 医生组成员id
        /// </summary>
        [Display(Name = "医生组成员")]
        [StringLength(20)]
        public virtual string MemberId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 医生分组id
        /// </summary>
        [Display(Name = "医生分组")]
        [StringLength(20)]
        public virtual string DoctorGroupId { get; set; }

        /// <summary>
        /// 成员id
        /// </summary>
        [Display(Name = "成员")]
        [StringLength(20)]
        public virtual string Member { get; set; }

        /// <summary>
        /// 成员工号
        /// </summary>
        [Display(Name = "成员工号")]
        [StringLength(20)]
        public virtual string MemberNum { get; set; }

        /// <summary>
        /// 成员姓名
        /// </summary>
        [Display(Name = "成员姓名")]
        [StringLength(20)]
        public virtual string MemberName { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_StructuredTemplate 结构化模板 实体类
    /// </summary>
    [Serializable]
    public partial class AI_StructuredTemplate
    {
        /// <summary>
        /// 模板id
        /// </summary>
        [Display(Name = "模板")]
        [StringLength(20)]
        public virtual string TemplateId { get; set; }

        /// <summary>
        /// 父模板id
        /// </summary>
        [Display(Name = "父模板")]
        [StringLength(20)]
        public virtual string ParentTempId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [Display(Name = "模板名称")]
        [StringLength(20)]
        public virtual string TemplateName { get; set; }

        /// <summary>
        /// 模板类型  806 
        /// </summary>
        [Display(Name = "模板类型")]
        public virtual int? TemplateType { get; set; }

        /// <summary>
        /// 共享类型 811
        /// </summary>
        [Display(Name = "共享类型")]
        public virtual int? ShareType { get; set; }

        /// <summary>
        /// 共享范围
        /// </summary>
        [Display(Name = "共享范围")]
        [StringLength(20)]
        public virtual string ShareRange { get; set; }

        /// <summary>
        /// 是否分类判别
        /// </summary>
        [Display(Name = "是否分类判别")]
        public virtual int IsCategory { get; set; }

        /// <summary>
        /// 模板数据
        /// </summary>
        [Display(Name = "模板数据")]
        [StringLength(20000)]
        public virtual string TemplateData { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [Display(Name = "模板内容")]
        [StringLength(20000)]
        public virtual string TemplateContent { get; set; }

        /// <summary>
        /// 末级判别0不是未级1未级
        /// </summary>
        [Display(Name = "末级判别")]
        public virtual int? ISLast { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_UserDept 用户科室对照  实体类
    /// </summary>
    [Serializable]
    public partial class AI_UserDept
    {
        /// <summary>
        /// 用户序号
        /// </summary>
        [Display(Name = "用户序号")]
        [StringLength(20)]
        public virtual string UserID { get; set; }

        /// <summary>
        /// 科室序号
        /// </summary>
        [Display(Name = "科室序号")]
        [StringLength(20)]
        public virtual string DeptID { get; set; }

        /// <summary>
        /// 科室类型1科室2病区
        /// </summary>
        [Display(Name = "科室类型")]
        public virtual int? TypeCode { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        [Display(Name = "显示排序")]
        public virtual int? DisplaySort { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_UserSuperiorDoctor 用户上级医师对照  实体类
    /// </summary>
    [Serializable]
    public partial class AI_UserSuperiorDoctor
    {
        /// <summary>
        /// 用户序号
        /// </summary>
        [Display(Name = "用户序号")]
        [StringLength(20)]
        public virtual string UserID { get; set; }

        /// <summary>
        /// 上级医师序号
        /// </summary>
        [Display(Name = "上级医师序号")]
        [StringLength(20)]
        public virtual string SuperiorUserID { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        [Display(Name = "显示排序")]
        public virtual int? DisplaySort { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_DeptInfo 科室病区  实体类
    /// </summary>
    [Serializable]
    public partial class AI_DeptInfo
    {
        /// <summary>
        /// 医疗组序号
        /// </summary>
        [Display(Name = "科室序号")]
        [StringLength(20)]
        public virtual string DeptID { get; set; }

        /// <summary>
        /// 代码序号
        /// </summary>
        [Display(Name = "父类序号")]
        [StringLength(20)]
        public virtual string ParentID { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// HIS序号
        /// </summary>
        [Display(Name = "序号")]
        [StringLength(20)]
        public virtual string HISID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DeptName { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 作废判别0正常1作废
        /// </summary>
        [Display(Name = "作废判别")]
        public virtual int? IsCance { get; set; }

        /// <summary>
        /// 病区判别0不是1是
        /// </summary>
        [Display(Name = "病区判别")]
        public virtual int? IsInpatient { get; set; }

        /// <summary>
        /// 科室说明
        /// </summary>
        [Display(Name = "科室说明")]
        [StringLength(500)]
        public virtual string DeptNote { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Display(Name = "操作时间")]
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string ModifyUserID { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_Diagnosis  标准诊断 实体类
    /// </summary>
    [Serializable]
    public partial class AI_Diagnosis
    {
        /// <summary>
        /// 诊断id
        /// </summary>
        [Display(Name = "诊断")]
        [StringLength(20)]
        public virtual string DiagnosisId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 父诊断ID
        /// </summary>
        [Display(Name = "父诊断")]
        [StringLength(20)]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 疾病代码编码
        /// </summary>
        [Display(Name = "疾病代码编码")]
        [StringLength(20)]
        public virtual string DiagnosisCode { get; set; }

        /// <summary>
        /// ICD代码
        /// </summary>
        [Display(Name = "代码")]
        [StringLength(10)]
        public virtual string ICDCode { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        [Display(Name = "诊断名称")]
        [StringLength(100)]
        public virtual string DiagnosisName { get; set; }

        /// <summary>
        /// 诊断类别  468

        /// </summary>
        [Display(Name = "诊断类别")]
        [StringLength(10)]
        public virtual string DiagnosisType { get; set; }

        /// <summary>
        /// 报卡类型   484
        /// </summary>
        [Display(Name = "报卡类型")]
        public virtual int? ReportCardId { get; set; }

        /// <summary>
        /// 排列顺序
        /// </summary>
        [Display(Name = "排列顺序")]
        public virtual int SortOrder { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

        /// <summary>
        /// 备注使用说明
        /// </summary>
        [Display(Name = "备注使用说明")]
        [StringLength(100)]
        public virtual string BZSYSM { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_Area  地区 实体类
    /// </summary>
    [Serializable]
    public partial class AI_Area
    {
        /// <summary>
        /// 地区编号
        /// </summary>
        [Display(Name = "地区编号")]
        public virtual long ID { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Display(Name = "省")]
        [StringLength(50)]
        public virtual string PROVINCE { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Display(Name = "市")]
        [StringLength(50)]
        public virtual string CITY { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [Display(Name = "县")]
        [StringLength(50)]
        public virtual string AREA { get; set; }

    }
    /// <summary>
    /// 基础信息 AI_Area  籍贯 实体类
    /// </summary>
    [Serializable]
    public partial class AI_Ethnic
    {
        /// <summary>
        /// 籍贯Id
        /// </summary>
        [Display(Name = "籍贯")]
        public virtual long Id { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Display(Name = "籍贯名称")]
        [StringLength(15)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [Display(Name = "邮政编码")]
        [StringLength(15)]
        public virtual string PostCode { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [Display(Name = "拼音码")]
        [StringLength(6)]
        public virtual string SpellCode { get; set; }

        /// <summary>
        /// 自定义码
        /// </summary>
        [Display(Name = "自定义码")]
        [StringLength(6)]
        public virtual string CustomCode { get; set; }

    }
    /// <summary>
    ///其他内容 药品不良反应报告 实体类
    /// </summary>
    [Serializable]
    public partial class CD_AdrReport
    {
        /// <summary>
        /// 报告id
        /// </summary>
        [Display(Name = "报告")]
        [StringLength(20)]
        public virtual string ReportId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 报告类型0首次报告1跟踪报告  
        /// </summary>
        [Display(Name = "报告类型")]
        public virtual int? ReportType { get; set; }

        /// <summary>
        /// 事件严重程度0新的1严重2一般
        /// </summary>
        [Display(Name = "事件严重程度")]
        public virtual int? Level { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Display(Name = "患者姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public virtual int? Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public virtual DateTime? Birthdate { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display(Name = "民族")]
        [StringLength(10)]
        public virtual string Ethnic { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        [StringLength(10)]
        public virtual string Weight { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [Display(Name = "联系方式")]
        [StringLength(20)]
        public virtual string Contact { get; set; }

        /// <summary>
        /// 原患疾病
        /// </summary>
        [Display(Name = "原患疾病")]
        [StringLength(50)]
        public virtual string Disease { get; set; }

        /// <summary>
        /// 病历号
        /// </summary>
        [Display(Name = "病历号")]
        [StringLength(20)]
        public virtual string PatientNum { get; set; }

        /// <summary>
        /// 既往药品不良反应
        /// </summary>
        [Display(Name = "既往药品不良反应")]
        [StringLength(10)]
        public virtual string PastAdr { get; set; }

        /// <summary>
        /// 家族药品不良反应
        /// </summary>
        [Display(Name = "家族药品不良反应")]
        [StringLength(10)]
        public virtual string FamilyAdr { get; set; }

        /// <summary>
        /// 相关重要信息
        /// </summary>
        [Display(Name = "相关重要信息")]
        [StringLength(50)]
        public virtual string Importent { get; set; }

        /// <summary>
        /// 不良反应/事件名称
        /// </summary>
        [Display(Name = "不良反应")]
        [StringLength(20)]
        public virtual string AdrName { get; set; }

        /// <summary>
        /// 不良反应/事件发生时间
        /// </summary>
        [Display(Name = "不良反应")]
        public virtual DateTime? AdrTime { get; set; }

        /// <summary>
        /// 来院原因
        /// </summary>
        [Display(Name = "来院原因")]
        [StringLength(20)]
        public virtual string ComeReason { get; set; }

        /// <summary>
        /// 来院方式0门诊1住院
        /// </summary>
        [Display(Name = "来院方式")]
        public virtual int? ComeType { get; set; }

        /// <summary>
        /// 用药时间
        /// </summary>
        [Display(Name = "用药时间")]
        public virtual DateTime? UseTime { get; set; }

        /// <summary>
        /// 用药名称
        /// </summary>
        [Display(Name = "用药名称")]
        [StringLength(20)]
        public virtual string Medicine { get; set; }

        /// <summary>
        /// 用药剂量
        /// </summary>
        [Display(Name = "用药剂量")]
        [StringLength(10)]
        public virtual string Dose { get; set; }

        /// <summary>
        /// 溶媒
        /// </summary>
        [Display(Name = "溶媒")]
        [StringLength(20)]
        public virtual string Resolvent { get; set; }

        /// <summary>
        /// 溶媒剂量
        /// </summary>
        [Display(Name = "溶媒剂量")]
        [StringLength(10)]
        public virtual string ResolventDose { get; set; }

        /// <summary>
        /// 用药方式
        /// </summary>
        [Display(Name = "用药方式")]
        [StringLength(10)]
        public virtual string Supply { get; set; }

        /// <summary>
        /// 用药频次
        /// </summary>
        [Display(Name = "用药频次")]
        [StringLength(10)]
        public virtual string Frequency { get; set; }

        /// <summary>
        /// 反应发生时间
        /// </summary>
        [Display(Name = "反应发生时间")]
        public virtual DateTime? ReactionTime { get; set; }

        /// <summary>
        /// 反应发生症状
        /// </summary>
        [Display(Name = "反应发生症状")]
        [StringLength(20)]
        public virtual string ReactionSymptom { get; set; }

        /// <summary>
        /// 查体
        /// </summary>
        [Display(Name = "查体")]
        [StringLength(50)]
        public virtual string CheckBody { get; set; }

        /// <summary>
        /// 采取措施
        /// </summary>
        [Display(Name = "采取措施")]
        [StringLength(50)]
        public virtual string TakeMeasures { get; set; }

        /// <summary>
        /// 治疗措施
        /// </summary>
        [Display(Name = "治疗措施")]
        [StringLength(50)]
        public virtual string TreatMeasures { get; set; }

        /// <summary>
        /// 治疗后反应时间
        /// </summary>
        [Display(Name = "治疗后反应时间")]
        public virtual DateTime? AfterTreatTime { get; set; }

        /// <summary>
        /// 治疗后反应
        /// </summary>
        [Display(Name = "治疗后反应")]
        [StringLength(50)]
        public virtual string AfterTreatReaction { get; set; }

        /// <summary>
        /// 是否继续使用该药物
        /// </summary>
        [Display(Name = "是否继续使用该药物")]
        [StringLength(10)]
        public virtual string UseContinue { get; set; }

        /// <summary>
        /// 不良反应/事件结果
        /// </summary>
        [Display(Name = "不良反应")]
        [StringLength(50)]
        public virtual string AdrResult { get; set; }

        /// <summary>
        /// 不良反应/事件表现
        /// </summary>
        [Display(Name = "不良反应")]
        [StringLength(50)]
        public virtual string AdrReflect { get; set; }

        /// <summary>
        /// 是否死亡
        /// </summary>
        [Display(Name = "是否死亡")]
        [StringLength(10)]
        public virtual string Die { get; set; }

        /// <summary>
        /// 死亡直接原因
        /// </summary>
        [Display(Name = "死亡直接原因")]
        [StringLength(50)]
        public virtual string DieReason { get; set; }

        /// <summary>
        /// 死亡时间
        /// </summary>
        [Display(Name = "死亡时间")]
        public virtual DateTime? DieTime { get; set; }

        /// <summary>
        /// 停药或减量后反应
        /// </summary>
        [Display(Name = "停药或减量后反应")]
        [StringLength(50)]
        public virtual string AfterStopReaction { get; set; }

        /// <summary>
        /// 再次使用可疑药品后反应
        /// </summary>
        [Display(Name = "再次使用可疑药品后反应")]
        [StringLength(50)]
        public virtual string UseAgainReaction { get; set; }

        /// <summary>
        /// 对原患疾病的影响
        /// </summary>
        [Display(Name = "对原患疾病的影响")]
        [StringLength(50)]
        public virtual string EffectDisease { get; set; }

        /// <summary>
        /// 报告人评价
        /// </summary>
        [Display(Name = "报告人评价")]
        [StringLength(50)]
        public virtual string ReporterAssessment { get; set; }

        /// <summary>
        /// 报告单位评价
        /// </summary>
        [Display(Name = "报告单位评价")]
        [StringLength(50)]
        public virtual string ReportCompAssessment { get; set; }

        /// <summary>
        /// 报告单位评价人id
        /// </summary>
        [Display(Name = "报告单位评价人")]
        [StringLength(20)]
        public virtual string CompAssessmenter_id { get; set; }

        /// <summary>
        /// 报告单位评价人姓名
        /// </summary>
        [Display(Name = "报告单位评价人姓名")]
        [StringLength(20)]
        public virtual string CompAssessmenter_name { get; set; }

        /// <summary>
        /// 报告人联系电话
        /// </summary>
        [Display(Name = "报告人联系电话")]
        [StringLength(20)]
        public virtual string ReporterPhone { get; set; }

        /// <summary>
        /// 报告人职业
        /// </summary>
        [Display(Name = "报告人职业")]
        [StringLength(10)]
        public virtual string ReporterJob { get; set; }

        /// <summary>
        /// 报告人电子邮件
        /// </summary>
        [Display(Name = "报告人电子邮件")]
        [StringLength(20)]
        public virtual string ReporterEmail { get; set; }

        /// <summary>
        /// 报告人科室
        /// </summary>
        [Display(Name = "报告人科室")]
        [StringLength(20)]
        public virtual string ReporterDept { get; set; }

        /// <summary>
        /// 报告人id
        /// </summary>
        [Display(Name = "报告人")]
        [StringLength(20)]
        public virtual string ReporterId { get; set; }

        /// <summary>
        /// 报告人姓名
        /// </summary>
        [Display(Name = "报告人姓名")]
        [StringLength(20)]
        public virtual string ReporterName { get; set; }

        /// <summary>
        /// 报告日期
        /// </summary>
        [Display(Name = "报告日期")]
        public virtual DateTime? ReportTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(200)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 报告单位名称
        /// </summary>
        [Display(Name = "报告单位名称")]
        [StringLength(50)]
        public virtual string ReportComp { get; set; }

        /// <summary>
        /// 报告单位联系人
        /// </summary>
        [Display(Name = "报告单位联系人")]
        [StringLength(20)]
        public virtual string ReportCompContact { get; set; }

        /// <summary>
        /// 报告单位联系电话
        /// </summary>
        [Display(Name = "报告单位联系电话")]
        [StringLength(20)]
        public virtual string ReportCompPhone { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///其他内容 不良反应药品信息 实体类
    /// </summary>
    [Serializable]
    public partial class CD_AdrMedicine
    {
        /// <summary>
        /// 不良反应药品信息id
        /// </summary>
        [Display(Name = "不良反应药品信息")]
        [StringLength(20)]
        public virtual string MedicineId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 报告id
        /// </summary>
        [Display(Name = "报告")]
        [StringLength(20)]
        public virtual string ReportId { get; set; }

        /// <summary>
        /// 药品类型0怀疑药品1并用药品
        /// </summary>
        [Display(Name = "药品类型")]
        public virtual int? MedicineType { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [Display(Name = "批准文号")]
        public virtual DateTime? ApprovalNum { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name = "商品名称")]
        [StringLength(20)]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 通用名称
        /// </summary>
        [Display(Name = "通用名称")]
        [StringLength(20)]
        public virtual string UsuallyName { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [Display(Name = "生产厂家")]
        [StringLength(50)]
        public virtual string Manufacturer { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [Display(Name = "生产批号")]
        [StringLength(20)]
        public virtual string BatchBum { get; set; }

        /// <summary>
        /// 用法用量
        /// </summary>
        [Display(Name = "用法用量")]
        [StringLength(20)]
        public virtual string SupplyDose { get; set; }

        /// <summary>
        /// 用药起止时间
        /// </summary>
        [Display(Name = "用药起止时间")]
        [StringLength(50)]
        public virtual string FromTo { get; set; }

        /// <summary>
        /// 用药原因
        /// </summary>
        [Display(Name = "用药原因")]
        [StringLength(50)]
        public virtual string UseReason { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///其他内容 药品不良反应事件分析 实体类
    /// </summary>
    [Serializable]
    public partial class CD_AdrAssessment
    {
        /// <summary>
        /// 分析id
        /// </summary>
        [Display(Name = "分析")]
        [StringLength(20)]
        public virtual string AssessmentId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 事件严重程度0新的1严重2一般
        /// </summary>
        [Display(Name = "事件严重程度")]
        public virtual int? Level { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Display(Name = "患者姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public virtual int? Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public virtual DateTime? Birthdate { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display(Name = "民族")]
        [StringLength(10)]
        public virtual string Ethnic { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        [StringLength(10)]
        public virtual string Weight { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [Display(Name = "联系方式")]
        [StringLength(20)]
        public virtual string Contact { get; set; }

        /// <summary>
        /// 怀疑药品
        /// </summary>
        [Display(Name = "怀疑药品")]
        [StringLength(200)]
        public virtual string DoubtMedicine { get; set; }

        /// <summary>
        /// 不良反应/事件名称
        /// </summary>
        [Display(Name = "不良反应")]
        [StringLength(20)]
        public virtual string AdrName { get; set; }

        /// <summary>
        /// 不良反应/事件发生时间
        /// </summary>
        [Display(Name = "不良反应")]
        public virtual DateTime? AdrTime { get; set; }

        /// <summary>
        /// 不良反应/事件描述及处理情况
        /// </summary>
        [Display(Name = "不良反应")]
        [StringLength(4000)]
        public virtual string AdrContent { get; set; }

        /// <summary>
        /// 有无合理的事件关系
        /// </summary>
        [Display(Name = "有无合理的事件关系")]
        [StringLength(1)]
        public virtual string EventRelation { get; set; }

        /// <summary>
        /// 是否符合该药已知的不良反应类型
        /// </summary>
        [Display(Name = "是否符合不良反应类型")]
        [StringLength(1)]
        public virtual string MatchReaction { get; set; }

        /// <summary>
        /// 停药或减量后，反应是否消失或减轻
        /// </summary>
        [Display(Name = "反应是否消失或减轻")]
        [StringLength(1)]
        public virtual string ReactionGone { get; set; }

        /// <summary>
        /// 再次使用可疑药品是否再次出现同样反应/事件
        /// </summary>
        [Display(Name = "再次使用")]
        [StringLength(1)]
        public virtual string UseAgain { get; set; }

        /// <summary>
        /// 反应/事件是否可用并用药的作用、患者病情的进展、其他治疗的影响来解释
        /// </summary>
        [Display(Name = "是否合理解释")]
        [StringLength(1)]
        public virtual string Rationalize { get; set; }

        /// <summary>
        /// 药物利弊评价
        /// </summary>
        [Display(Name = "药物利弊评价")]
        [StringLength(200)]
        public virtual string Assessment { get; set; }

        /// <summary>
        /// 安全性建议
        /// </summary>
        [Display(Name = "安全性建议")]
        [StringLength(200)]
        public virtual string Suggest { get; set; }

        /// <summary>
        /// 评价人id
        /// </summary>
        [Display(Name = "评价人")]
        [StringLength(20)]
        public virtual string AssessmenterId { get; set; }

        /// <summary>
        /// 评价人姓名
        /// </summary>
        [Display(Name = "评价人姓名")]
        [StringLength(20)]
        public virtual string AssessmenterName { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        [Display(Name = "评价时间")]
        public virtual DateTime? AssessmentTime { get; set; }

        /// <summary>
        /// 查看人id
        /// </summary>
        [Display(Name = "查看人")]
        [StringLength(20)]
        public virtual string ViewerId { get; set; }

        /// <summary>
        /// 查看人姓名
        /// </summary>
        [Display(Name = "查看人姓名")]
        [StringLength(20)]
        public virtual string ViewerName { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///其他内容 病历归档记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_ArchiveRecord
    {
        /// <summary>
        /// 归档记录id
        /// </summary>
        [Display(Name = "归档记录")]
        [StringLength(20)]
        public virtual string ArchiveId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 操作类型0未提交1已提交2已接收3已归档
        /// </summary>
        [Display(Name = "归档标志")]
        public virtual int? ArchiveType { get; set; }

        /// <summary>
        /// 归档操作人
        /// </summary>
        [Display(Name = "归档操作人")]
        [StringLength(20)]
        public virtual string OperationUser { get; set; }

        /// <summary>
        /// 归档操作人姓名
        /// </summary>
        [Display(Name = "归档操作人姓名")]
        [StringLength(20)]
        public virtual string OperationUserName { get; set; }

        /// <summary>
        /// 归档操作人时间
        /// </summary>
        [Display(Name = "归档操作人时间")]
        public virtual DateTime? OperationTime { get; set; }

        /// <summary>
        /// 提交操作人
        /// </summary>
        [Display(Name = "提交操作人")]
        [StringLength(20)]
        public virtual string SubmitUser { get; set; }

        /// <summary>
        /// 提交操作人姓名
        /// </summary>
        [Display(Name = "提交操作人姓名")]
        [StringLength(20)]
        public virtual string SubmitUserName { get; set; }

        /// <summary>
        /// 提交操作人时间
        /// </summary>
        [Display(Name = "提交操作人时间")]
        public virtual DateTime? SubmitTime { get; set; }

        /// <summary>
        /// 接收操作人
        /// </summary>
        [Display(Name = "接收操作人")]
        [StringLength(20)]
        public virtual string ReceiveUser { get; set; }

        /// <summary>
        /// 接收操作人姓名
        /// </summary>
        [Display(Name = "接收操作人姓名")]
        [StringLength(20)]
        public virtual string ReceiveUserName { get; set; }

        /// <summary>
        /// 接收操作人时间
        /// </summary>
        [Display(Name = "接收操作人时间")]
        public virtual DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///其他内容 院士查房上报 实体类
    /// </summary>
    [Serializable]
    public partial class CD_AcademicianRounds
    {
        /// <summary>
        /// 查房记录id
        /// </summary>
        [Display(Name = "查房记录")]
        [StringLength(20)]
        public virtual string RoundsId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [StringLength(10)]
        public virtual string Gender { get; set; }

        /// <summary>
        /// 就诊年龄
        /// </summary>
        [Display(Name = "就诊年龄")]
        [StringLength(20)]
        public virtual string Age { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(50)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 教授id
        /// </summary>
        [Display(Name = "教授")]
        [StringLength(20)]
        public virtual string ProfessorId { get; set; }

        /// <summary>
        /// 教授
        /// </summary>
        [Display(Name = "教授")]
        [StringLength(20)]
        public virtual string Professor { get; set; }

        /// <summary>
        /// 主诉
        /// </summary>
        [Display(Name = "主诉")]
        [StringLength(100)]
        public virtual string ChiefComplaint { get; set; }

        /// <summary>
        /// 现病史
        /// </summary>
        [Display(Name = "现病史")]
        [StringLength(4000)]
        public virtual string PressentHistory { get; set; }

        /// <summary>
        /// 体格检查
        /// </summary>
        [Display(Name = "体格检查")]
        [StringLength(4000)]
        public virtual string PhysicalExamination { get; set; }

        /// <summary>
        /// 辅助检查
        /// </summary>
        [Display(Name = "辅助检查")]
        [StringLength(4000)]
        public virtual string LaboratoryData { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        [Display(Name = "图像")]
        [StringLength(4000)]
        public virtual string ImageFindings { get; set; }

        /// <summary>
        /// 主诊断
        /// </summary>
        [Display(Name = "主诊断")]
        [StringLength(100)]
        public virtual string PrimaryDiagnosis { get; set; }

        /// <summary>
        /// PURPOSE FOR DISCUSSION
        /// </summary>
        [Display(Name = "")]
        [StringLength(4000)]
        public virtual string PurposeForDiscussion { get; set; }

        /// <summary>
        /// 上报时间
        /// </summary>
        [Display(Name = "上报时间")]
        public virtual DateTime? ReportDate { get; set; }

        /// <summary>
        /// 上报人id
        /// </summary>
        [Display(Name = "上报人")]
        [StringLength(20)]
        public virtual string ReporterId { get; set; }

        /// <summary>
        /// 上报人
        /// </summary>
        [Display(Name = "上报人")]
        [StringLength(20)]
        public virtual string Reporter { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///其他内容 院士查房上报时间设置 实体类
    /// </summary>
    [Serializable]
    public partial class CD_ReportTime
    {
        /// <summary>
        /// 上报时间id
        /// </summary>
        [Display(Name = "上报时间")]
        [StringLength(20)]
        public virtual string ReportTimeId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 抗生素审批记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_AntibioticApproval
    {
        /// <summary>
        /// 审批记录id
        /// </summary>
        [Display(Name = "审批记录")]
        [StringLength(20)]
        public virtual string ApprovalId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 抗生素名称
        /// </summary>
        [Display(Name = "抗生素名称")]
        [StringLength(1)]
        public virtual string AntibioticName { get; set; }

        /// <summary>
        /// 剂量
        /// </summary>
        [Display(Name = "剂量")]
        [StringLength(10)]
        public virtual string Dose { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        [Display(Name = "剂量单位")]
        [StringLength(10)]
        public virtual string DoseUnit { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [Display(Name = "剂型")]
        [StringLength(10)]
        public virtual string DrugForm { get; set; }

        /// <summary>
        /// 频率
        /// </summary>
        [Display(Name = "频率")]
        [StringLength(10)]
        public virtual string Frequency { get; set; }

        /// <summary>
        /// 给药方式
        /// </summary>
        [Display(Name = "给药方式")]
        [StringLength(20)]
        public virtual string SupplyName { get; set; }

        /// <summary>
        /// 简要病情
        /// </summary>
        [Display(Name = "简要病情")]
        [StringLength(200)]
        public virtual string DiseaseSummary { get; set; }

        /// <summary>
        /// 药敏送检标志1未送检2已送检结果未回3已送检结果已回
        /// </summary>
        [Display(Name = "药敏送检标志")]
        [StringLength(10)]
        public virtual string SensitivityFlag { get; set; }

        /// <summary>
        /// 药敏实验结果1敏感2中介3耐药 
        /// </summary>
        [Display(Name = "药敏实验结果")]
        [StringLength(10)]
        public virtual string SensitivityResult { get; set; }

        /// <summary>
        /// 药敏实验内容
        /// </summary>
        [Display(Name = "药敏实验内容")]
        [StringLength(500)]
        public virtual string SensitivityContent { get; set; }

        /// <summary>
        /// 申请医生姓名
        /// </summary>
        [Display(Name = "申请医生姓名")]
        [StringLength(20)]
        public virtual string ApplyName { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Display(Name = "申请时间")]
        public virtual DateTime? ApplyTime { get; set; }

        /// <summary>
        /// 审批数量
        /// </summary>
        [Display(Name = "审批数量")]
        [StringLength(10)]
        public virtual string ApprovalAmount { get; set; }

        /// <summary>
        /// 主治医生意见
        /// </summary>
        [Display(Name = "主治医生意见")]
        [StringLength(200)]
        public virtual string PhysicianSuggestion { get; set; }

        /// <summary>
        /// 主治医生id
        /// </summary>
        [Display(Name = "主治医生")]
        [StringLength(20)]
        public virtual string PhysicianId { get; set; }

        /// <summary>
        /// 主治医生姓名
        /// </summary>
        [Display(Name = "主治医生姓名")]
        [StringLength(20)]
        public virtual string PhysicianName { get; set; }

        /// <summary>
        /// 主治医生签名时间
        /// </summary>
        [Display(Name = "主治医生签名时间")]
        public virtual DateTime? PhysicianTime { get; set; }

        /// <summary>
        /// 主任医生意见
        /// </summary>
        [Display(Name = "主任医生意见")]
        [StringLength(200)]
        public virtual string head_suggestion { get; set; }

        /// <summary>
        /// 主任医生id
        /// </summary>
        [Display(Name = "主任医生")]
        [StringLength(20)]
        public virtual string HeadId { get; set; }

        /// <summary>
        /// 主任医生姓名
        /// </summary>
        [Display(Name = "主任医生姓名")]
        [StringLength(20)]
        public virtual string head_name { get; set; }

        /// <summary>
        /// 主任医生签名时间
        /// </summary>
        [Display(Name = "主任医生签名时间")]
        public virtual DateTime head_time { get; set; }

        /// <summary>
        /// 会诊医生意见
        /// </summary>
        [Display(Name = "会诊医生意见")]
        [StringLength(200)]
        public virtual string ConsSuggestion { get; set; }

        /// <summary>
        /// 会诊医生id
        /// </summary>
        [Display(Name = "会诊医生")]
        [StringLength(20)]
        public virtual string ConsDoctId { get; set; }

        /// <summary>
        /// 会诊医生姓名
        /// </summary>
        [Display(Name = "会诊医生姓名")]
        [StringLength(20)]
        public virtual string ConsName { get; set; }

        /// <summary>
        /// 会诊医生签名时间
        /// </summary>
        [Display(Name = "会诊医生签名时间")]
        public virtual DateTime? ConsTime { get; set; }

        /// <summary>
        /// 紧急用药理由
        /// </summary>
        [Display(Name = "紧急用药理由")]
        [StringLength(200)]
        public virtual string Emergency { get; set; }

        /// <summary>
        /// 紧急用药申请医生id
        /// </summary>
        [Display(Name = "紧急用药申请医生")]
        [StringLength(20)]
        public virtual string EmergencyDoctId { get; set; }

        /// <summary>
        /// 紧急用药申请医生姓名
        /// </summary>
        [Display(Name = "紧急用药申请医生姓名")]
        [StringLength(20)]
        public virtual string EmergencyName { get; set; }

        /// <summary>
        /// 紧急用药申请时间
        /// </summary>
        [Display(Name = "紧急用药申请时间")]
        public virtual DateTime? EmergencyTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(200)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 审批标志
        /// </summary>
        [Display(Name = "审批标志")]
        [StringLength(10)]
        public virtual string ApprovalFlag { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        [Display(Name = "审批时间")]
        public virtual DateTime? ApprovalTime { get; set; }

        /// <summary>
        /// 审批医生id
        /// </summary>
        [Display(Name = "审批医生")]
        [StringLength(20)]
        public virtual string ApprovalDoctId { get; set; }

        /// <summary>
        /// 审批医生姓名
        /// </summary>
        [Display(Name = "审批医生姓名")]
        [StringLength(20)]
        public virtual string ApprovalName { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 医嘱 实体类
    /// </summary>
    [Serializable]
    public partial class CO_Order
    {
        /// <summary>
        /// 医嘱id
        /// </summary>
        [Display(Name = "医嘱")]
        [StringLength(32)]
        public virtual string OrderId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// his医嘱id
        /// </summary>
        [Display(Name = "医嘱")]
        [StringLength(100)]
        public virtual string HisOrderId { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        [Display(Name = "组号")]
        [StringLength(32)]
        public virtual string GroupId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        [Display(Name = "病区名称")]
        [StringLength(20)]
        public virtual string WardName { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DepartmentName { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 住院号
        /// </summary>
        [Display(Name = "住院号")]
        [StringLength(20)]
        public virtual string PatientNum { get; set; }

        /// <summary>
        /// 病人类型0门诊1住院
        /// </summary>
        [Display(Name = "病人类型")]
        public virtual int PatientType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 药品id
        /// </summary>
        [Display(Name = "药品")]
        [StringLength(100)]
        public virtual string DrugId { get; set; }

        /// <summary>
        /// 诊疗项目id
        /// </summary>
        [Display(Name = "诊疗项目")]
        [StringLength(100)]
        public virtual string TreatId { get; set; }

        /// <summary>
        /// 医嘱名称
        /// </summary>
        [Display(Name = "医嘱名称")]
        [StringLength(200)]
        public virtual string order_name { get; set; }

        /// <summary>
        /// 是否长期医嘱
        /// </summary>
        [Display(Name = "是否长期医嘱")]
        public virtual int? StandingOrder { get; set; }

        /// <summary>
        /// his频率代码
        /// </summary>
        [Display(Name = "频率代码")]
        [StringLength(20)]
        public virtual string FrequencyCode { get; set; }

        /// <summary>
        /// 频率
        /// </summary>
        [Display(Name = "频率")]
        [StringLength(10)]
        public virtual string Frequency { get; set; }

        /// <summary>
        /// his给药方式代码
        /// </summary>
        [Display(Name = "给药方式代码")]
        [StringLength(20)]
        public virtual string SupplyCode { get; set; }

        /// <summary>
        /// 给药方式
        /// </summary>
        [Display(Name = "给药方式")]
        [StringLength(20)]
        public virtual string SupplyName { get; set; }

        /// <summary>
        /// 剂量
        /// </summary>
        [Display(Name = "剂量")]
        [StringLength(10)]
        public virtual string Dose { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        [Display(Name = "剂量单位")]
        [StringLength(10)]
        public virtual string DoseUnit { get; set; }

        /// <summary>
        /// 单次领药量(含单位)
        /// </summary>
        [Display(Name = "单次领药量")]
        [StringLength(10)]
        public virtual string PickDose { get; set; }

        /// <summary>
        /// 滴速
        /// </summary>
        [Display(Name = "滴速")]
        [StringLength(10)]
        public virtual string DripRate { get; set; }

        /// <summary>
        /// 是否新医嘱
        /// </summary>
        [Display(Name = "是否新医嘱")]
        public virtual int? NewOrder { get; set; }

        /// <summary>
        /// 状态1 未停 2 已停 3 撤销  
        /// </summary>
        [Display(Name = "状态")]
        [StringLength(3)]
        public virtual string Status { get; set; }

        /// <summary>
        /// 医嘱分类 1西药 2 成药 4 中药 5 诊疗
        /// </summary>
        [Display(Name = "医嘱分类")]
        [StringLength(3)]
        public virtual string OrderCategory { get; set; }

        /// <summary>
        /// 医嘱类型 1药品 2 诊疗 3 文本 4 检验 5 检查 6 手术 7 配置 8三升袋 9 化疗 10 审方 21 饮食
        /// </summary>
        [Display(Name = "医嘱类型")]
        [StringLength(3)]
        public virtual string order_type { get; set; }

        /// <summary>
        /// 医嘱开始时间
        /// </summary>
        [Display(Name = "医嘱开始时间")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// 医嘱结束时间
        /// </summary>
        [Display(Name = "医嘱结束时间")]
        public virtual DateTime? end_time { get; set; }

        /// <summary>
        /// 高危药品
        /// </summary>
        [Display(Name = "高危药品")]
        public virtual int? DangerDrug { get; set; }

        /// <summary>
        /// 易跌倒药品
        /// </summary>
        [Display(Name = "易跌倒药品")]
        public virtual int? MayFall { get; set; }

        /// <summary>
        /// 急诊标志
        /// </summary>
        [Display(Name = "急诊标志")]
        public virtual int? Emergency { get; set; }

        /// <summary>
        /// 皮试结果1阴性2阳性3免试4皮试5续注6强阳性
        /// </summary>
        [Display(Name = "皮试结果")]
        [StringLength(3)]
        public virtual string SkinTest { get; set; }

        /// <summary>
        /// 开立医生id
        /// </summary>
        [Display(Name = "开立医生")]
        [StringLength(32)]
        public virtual string MakeDoctorId { get; set; }

        /// <summary>
        /// 开立医生
        /// </summary>
        [Display(Name = "开立医生")]
        [StringLength(20)]
        public virtual string MakeDoctor { get; set; }

        /// <summary>
        /// 医嘱开立时间
        /// </summary>
        [Display(Name = "医嘱开立时间")]
        public virtual DateTime? MakeTime { get; set; }

        /// <summary>
        /// 停止医生id
        /// </summary>
        [Display(Name = "停止医生")]
        [StringLength(32)]
        public virtual string EndDoctorId { get; set; }

        /// <summary>
        /// 停止医生
        /// </summary>
        [Display(Name = "停止医生")]
        [StringLength(20)]
        public virtual string EndDoctor { get; set; }

        /// <summary>
        /// 嘱托
        /// </summary>
        [Display(Name = "嘱托")]
        [StringLength(100)]
        public virtual string Advice { get; set; }

        /// <summary>
        /// 执行方式0院内,1出院带药,2领药
        /// </summary>
        [Display(Name = "执行方式")]
        [StringLength(3)]
        public virtual string perform_way { get; set; }

        /// <summary>
        /// 处理类型0正常 1自备 2嘱托
        /// </summary>
        [Display(Name = "处理类型")]
        [StringLength(3)]
        public virtual string TreatmentType { get; set; }

        /// <summary>
        /// 成组医嘱排序
        /// </summary>
        [Display(Name = "成组医嘱排序")]
        public virtual int? GroupOrderby { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 给药方式 实体类
    /// </summary>
    [Serializable]
    public partial class CO_Supply
    {
        /// <summary>
        /// 给药方式代码
        /// </summary>
        [Display(Name = "给药方式代码")]
        [StringLength(20)]
        public virtual string SupplyCode { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 给药方式名称
        /// </summary>
        [Display(Name = "给药方式名称")]
        [StringLength(20)]
        public virtual string SupplyName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Display(Name = "分类")]
        [StringLength(3)]
        public virtual string Category { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Display(Name = "分类名称")]
        [StringLength(20)]
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 频率 实体类
    /// </summary>
    [Serializable]
    public partial class CO_Frequency
    {
        /// <summary>
        /// 频率代码
        /// </summary>
        [Display(Name = "频率代码")]
        [StringLength(20)]
        public virtual string FrequencyCode { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 频率
        /// </summary>
        [Display(Name = "频率")]
        [StringLength(10)]
        public virtual string Frequency { get; set; }

        /// <summary>
        /// 执行次数
        /// </summary>
        [Display(Name = "执行次数")]
        public virtual int? PerformCount { get; set; }

        /// <summary>
        /// 执行间隔
        /// </summary>
        [Display(Name = "执行间隔")]
        public virtual float? PerformInterval { get; set; }

        /// <summary>
        /// 间隔单位(周、天、小时)
        /// </summary>
        [Display(Name = "间隔单位")]
        [StringLength(10)]
        public virtual string IntervalUnit { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 检验输血医嘱执行 实体类
    /// </summary>
    [Serializable]
    public partial class CO_TestOrderPerform
    {
        /// <summary>
        /// 医嘱id
        /// </summary>
        [Display(Name = "医嘱")]
        [StringLength(32)]
        public virtual string OrderId { get; set; }

        /// <summary>
        /// 样本ID
        /// </summary>
        [Display(Name = "样本")]
        [StringLength(100)]
        public virtual string SampleId { get; set; }

        /// <summary>
        /// 采样目的
        /// </summary>
        [Display(Name = "采样目的")]
        [StringLength(100)]
        public virtual string SamplePurpose { get; set; }

        /// <summary>
        /// 急诊标志
        /// </summary>
        [Display(Name = "急诊标志")]
        public virtual int? Emergency { get; set; }

        /// <summary>
        /// 病人类型0门诊1住院
        /// </summary>
        [Display(Name = "病人类型")]
        public virtual int PatientType { get; set; }

        /// <summary>
        /// 计划采样时间
        /// </summary>
        [Display(Name = "计划采样时间")]
        public virtual DateTime? ScheduleSamplingTime { get; set; }

        /// <summary>
        /// 样本状态0未采集、1已采集、2已送检、3已接收
        /// </summary>
        [Display(Name = "样本状态")]
        [StringLength(3)]
        public virtual string SampleStatus { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        [Display(Name = "申请人")]
        [StringLength(20)]
        public virtual string Applyer { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Display(Name = "申请时间")]
        public virtual DateTime? ApplyTime { get; set; }

        /// <summary>
        /// 执行备注说明
        /// </summary>
        [Display(Name = "执行备注说明")]
        [StringLength(200)]
        public virtual string PerformMemo { get; set; }

        /// <summary>
        /// 采样人id
        /// </summary>
        [Display(Name = "采样人")]
        [StringLength(32)]
        public virtual string SamplerId { get; set; }

        /// <summary>
        /// 采样人
        /// </summary>
        [Display(Name = "采样人")]
        [StringLength(20)]
        public virtual string Sampler { get; set; }

        /// <summary>
        /// 采样时间
        /// </summary>
        [Display(Name = "采样时间")]
        public virtual DateTime? SamplingTime { get; set; }

        /// <summary>
        /// 送检人id
        /// </summary>
        [Display(Name = "送检人")]
        [StringLength(32)]
        public virtual string SenderId { get; set; }

        /// <summary>
        /// 送检人
        /// </summary>
        [Display(Name = "送检人")]
        [StringLength(20)]
        public virtual string Sender { get; set; }

        /// <summary>
        /// 送检时间
        /// </summary>
        [Display(Name = "送检时间")]
        public virtual DateTime? SendTime { get; set; }

        /// <summary>
        /// 送检操作人id
        /// </summary>
        [Display(Name = "送检操作人")]
        [StringLength(32)]
        public virtual string SendOperaterId { get; set; }

        /// <summary>
        /// 送检操作人
        /// </summary>
        [Display(Name = "送检操作人")]
        [StringLength(20)]
        public virtual string SendOperater { get; set; }

        /// <summary>
        /// 接收人id
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(32)]
        public virtual string ReciverId { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(20)]
        public virtual string Reciver { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        [Display(Name = "接收时间")]
        public virtual DateTime? ReciveTime { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 医嘱执行计划 实体类
    /// </summary>
    [Serializable]
    public partial class CO_OrderPerformSchedule
    {
        /// <summary>
        /// 执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(32)]
        public virtual string PerformScheduleId { get; set; }

        /// <summary>
        /// his执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(100)]
        public virtual string HisPerformScheduleId { get; set; }

        /// <summary>
        /// 医嘱id
        /// </summary>
        [Display(Name = "医嘱")]
        [StringLength(32)]
        public virtual string OrderId { get; set; }

        /// <summary>
        /// his医嘱id
        /// </summary>
        [Display(Name = "医嘱")]
        [StringLength(100)]
        public virtual string HisOrderId { get; set; }

        /// <summary>
        /// 计划执行时间
        /// </summary>
        [Display(Name = "计划执行时间")]
        public virtual DateTime? SchedulePerformTime { get; set; }

        /// <summary>
        /// 执行状态0未执行 1已执行 2已完成 3已中止
        /// </summary>
        [Display(Name = "执行状态")]
        [StringLength(3)]
        public virtual string perform_status { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        [Display(Name = "生成时间")]
        public virtual DateTime? perform_time { get; set; }

        /// <summary>
        /// 执行用户id
        /// </summary>
        [Display(Name = "操作人")]
        [StringLength(32)]
        public virtual string perform_user_id { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 药品打包接收记录 实体类
    /// </summary>
    [Serializable]
    public partial class CO_DrugPkgRcv
    {
        /// <summary>
        /// 打包id
        /// </summary>
        [Display(Name = "打包")]
        [StringLength(32)]
        public virtual string PackageId { get; set; }

        /// <summary>
        /// 执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(32)]
        public virtual string PerformScheduleId { get; set; }

        /// <summary>
        /// his执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(100)]
        public virtual string HisPerformScheduleId { get; set; }

        /// <summary>
        /// 打包条码(静配中心或其他送药系统产生)
        /// </summary>
        [Display(Name = "打包条码")]
        [StringLength(100)]
        public virtual string PackageBarcode { get; set; }

        /// <summary>
        /// 执行组号(HIS生成的条码，静配以JP_开头，药房以YP_开头)
        /// </summary>
        [Display(Name = "执行组号")]
        [StringLength(100)]
        public virtual string PerformGroupId { get; set; }

        /// <summary>
        /// 打包人id
        /// </summary>
        [Display(Name = "打包人")]
        [StringLength(32)]
        public virtual string PackagerId { get; set; }

        /// <summary>
        /// 打包人姓名
        /// </summary>
        [Display(Name = "打包人姓名")]
        [StringLength(20)]
        public virtual string Packager { get; set; }

        /// <summary>
        /// 打包备注说明
        /// </summary>
        [Display(Name = "打包备注说明")]
        [StringLength(200)]
        public virtual string PackageMemo { get; set; }

        /// <summary>
        /// 打包时间
        /// </summary>
        [Display(Name = "打包时间")]
        public virtual DateTime? PackageTime { get; set; }

        /// <summary>
        /// 接收人id
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(32)]
        public virtual string ReciverId { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(20)]
        public virtual string Reciver { get; set; }

        /// <summary>
        /// 接收备注说明
        /// </summary>
        [Display(Name = "接收备注说明")]
        [StringLength(200)]
        public virtual string ReciveMemo { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        [Display(Name = "接收时间")]
        public virtual DateTime? ReciveTime { get; set; }

        /// <summary>
        /// 药品接收标志(0未接收 1已接收)
        /// </summary>
        [Display(Name = "药品接收标志")]
        [StringLength(3)]
        public virtual string DrugReciveFlag { get; set; }

        /// <summary>
        /// 补打标志0否1是
        /// </summary>
        [Display(Name = "补打标志")]
        public virtual int? Printed { get; set; }

        /// <summary>
        /// 打印人id
        /// </summary>
        [Display(Name = "打印人")]
        [StringLength(32)]
        public virtual string PrinterId { get; set; }

        /// <summary>
        /// 打印人
        /// </summary>
        [Display(Name = "打印人")]
        [StringLength(20)]
        public virtual string Printer { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        [Display(Name = "打印时间")]
        public virtual DateTime? PrintTime { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 输血记录 实体类
    /// </summary>
    [Serializable]
    public partial class CO_Transfusion
    {
        /// <summary>
        /// 输血记录id
        /// </summary>
        [Display(Name = "输血记录")]
        [StringLength(32)]
        public virtual string TransfusionId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        [Display(Name = "病区名称")]
        [StringLength(20)]
        public virtual string WardName { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DepartmentName { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 住院号
        /// </summary>
        [Display(Name = "住院号")]
        [StringLength(20)]
        public virtual string PatientNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 配型样本id
        /// </summary>
        [Display(Name = "配型样本")]
        [StringLength(100)]
        public virtual string SampleId { get; set; }

        /// <summary>
        /// 血液制品id
        /// </summary>
        [Display(Name = "血液制品")]
        [StringLength(20)]
        public virtual string BloodProductId { get; set; }

        /// <summary>
        /// 血液制品名称规格
        /// </summary>
        [Display(Name = "血液制品名称规格")]
        [StringLength(100)]
        public virtual string BloodNameSpec { get; set; }

        /// <summary>
        /// ABO血型
        /// </summary>
        [Display(Name = "血型")]
        [StringLength(5)]
        public virtual string Abo { get; set; }

        /// <summary>
        /// Rh血型
        /// </summary>
        [Display(Name = "血型")]
        [StringLength(5)]
        public virtual string RH { get; set; }

        /// <summary>
        /// 计划输血时间
        /// </summary>
        [Display(Name = "计划输血时间")]
        public virtual DateTime? TransfusionTime { get; set; }

        /// <summary>
        /// 出库人
        /// </summary>
        [Display(Name = "出库人")]
        [StringLength(20)]
        public virtual string OutOperator { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        [Display(Name = "出库时间")]
        public virtual DateTime? OutTime { get; set; }

        /// <summary>
        /// 回收人
        /// </summary>
        [Display(Name = "回收人")]
        [StringLength(20)]
        public virtual string BackInOperator { get; set; }

        /// <summary>
        /// 回收时间
        /// </summary>
        [Display(Name = "回收时间")]
        public virtual DateTime? BackInTime { get; set; }

        /// <summary>
        /// 状态0未接收、1已接收、2开始输注、3输注结束、9退回
        /// </summary>
        [Display(Name = "状态")]
        [StringLength(3)]
        public virtual string Status { get; set; }

        /// <summary>
        /// 接收人id
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(32)]
        public virtual string ReciverId { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(20)]
        public virtual string Reciver { get; set; }

        /// <summary>
        /// 接收人2id
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(32)]
        public virtual string Reciver2_Id { get; set; }

        /// <summary>
        /// 接收人2
        /// </summary>
        [Display(Name = "接收人")]
        [StringLength(20)]
        public virtual string Reciver2 { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        [Display(Name = "接收时间")]
        public virtual DateTime? ReciveTime { get; set; }

        /// <summary>
        /// 输血执行人id
        /// </summary>
        [Display(Name = "输血执行人")]
        [StringLength(32)]
        public virtual string performer_id { get; set; }

        /// <summary>
        /// 输血执行人姓名
        /// </summary>
        [Display(Name = "输血执行人姓名")]
        [StringLength(20)]
        public virtual string performer { get; set; }

        /// <summary>
        /// 输血核对人id
        /// </summary>
        [Display(Name = "输血核对人")]
        [StringLength(32)]
        public virtual string CheckerId { get; set; }

        /// <summary>
        /// 输血核对人姓名
        /// </summary>
        [Display(Name = "输血核对人姓名")]
        [StringLength(20)]
        public virtual string Checker { get; set; }

        /// <summary>
        /// 输血执行备注说明
        /// </summary>
        [Display(Name = "输血执行备注说明")]
        [StringLength(200)]
        public virtual string PerformMemo { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        [Display(Name = "输血执行时间")]
        public virtual DateTime? perform_time { get; set; }

        /// <summary>
        /// 输血结束人id
        /// </summary>
        [Display(Name = "输血结束人")]
        [StringLength(32)]
        public virtual string end_performer_id { get; set; }

        /// <summary>
        /// 输血结束人姓名
        /// </summary>
        [Display(Name = "输血结束人姓名")]
        [StringLength(20)]
        public virtual string end_performer { get; set; }

        /// <summary>
        /// 输血结束时间
        /// </summary>
        [Display(Name = "输血结束时间")]
        public virtual DateTime? end_perform_time { get; set; }

        /// <summary>
        /// 输血结束备注说明
        /// </summary>
        [Display(Name = "输血结束备注说明")]
        [StringLength(200)]
        public virtual string EndPerformMemo { get; set; }

        /// <summary>
        /// 退回操作人id
        /// </summary>
        [Display(Name = "退回操作人")]
        [StringLength(32)]
        public virtual string BackPerformerId { get; set; }

        /// <summary>
        /// 退回操作人姓名
        /// </summary>
        [Display(Name = "退回操作人姓名")]
        [StringLength(20)]
        public virtual string BackPerformer { get; set; }

        /// <summary>
        /// 退回操作时间
        /// </summary>
        [Display(Name = "退回操作时间")]
        public virtual DateTime? BackPerformTime { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 频率方案 实体类
    /// </summary>
    [Serializable]
    public partial class CO_FrequencyScheme
    {
        /// <summary>
        /// 频率方案序号
        /// </summary>
        [Display(Name = "频率方案代码")]
        [StringLength(20)]
        public virtual string SchemeCode { get; set; }

        /// <summary>
        /// 频率代码
        /// </summary>
        [Display(Name = "频率代码")]
        [StringLength(20)]
        public virtual string FrequencyCode { get; set; }

        /// <summary>
        /// 方案内容
        /// </summary>
        [Display(Name = "方案内容")]
        [StringLength(100)]
        public virtual string SchemeContent { get; set; }

        /// <summary>
        /// 方案描述
        /// </summary>
        [Display(Name = "方案描述")]
        [StringLength(50)]
        public virtual string SchemeMemo { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 医嘱执行 实体类
    /// </summary>
    [Serializable]
    public partial class CO_OrderPerform
    {
        /// <summary>
        /// 执行记录序号
        /// </summary>
        [Display(Name = "执行记录序号")]
        [StringLength(32)]
        public virtual string PerformId { get; set; }

        /// <summary>
        /// 执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(32)]
        public virtual string PerformScheduleId { get; set; }

        /// <summary>
        /// 执行人id
        /// </summary>
        [Display(Name = "执行人")]
        [StringLength(32)]
        public virtual string performer_id { get; set; }

        /// <summary>
        /// 执行人姓名
        /// </summary>
        [Display(Name = "执行人姓名")]
        [StringLength(20)]
        public virtual string performer { get; set; }

        /// <summary>
        /// 执行备注说明
        /// </summary>
        [Display(Name = "执行备注说明")]
        [StringLength(200)]
        public virtual string PerformMemo { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        [Display(Name = "执行时间")]
        public virtual DateTime perform_time { get; set; }

        /// <summary>
        /// 执行类型0执行 1完成 2中止3高危药品核对
        /// </summary>
        [Display(Name = "执行类型")]
        [StringLength(3)]
        public virtual string perform_type { get; set; }

        /// <summary>
        /// PDA执行标志
        /// </summary>
        [Display(Name = "执行标志")]
        public virtual int PdaPerformFlag { get; set; }

        /// <summary>
        /// 手工执行标志
        /// </summary>
        [Display(Name = "手工执行标志")]
        public virtual int ManualFalg { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///医嘱相关 输液异常关联 实体类
    /// </summary>
    [Serializable]
    public partial class CO_InfusionReactionRelate
    {
        /// <summary>
        /// 执行计划id
        /// </summary>
        [Display(Name = "执行计划")]
        [StringLength(32)]
        public virtual string PerformScheduleId { get; set; }

        /// <summary>
        /// 输液反应记录id
        /// </summary>
        [Display(Name = "输液反应记录")]
        [StringLength(32)]
        public virtual string InfusionId { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///疾病报卡 CD_DiseasecardDic 疾病报卡字典 实体类
    /// </summary>
    [Serializable]
    public partial class CD_DiseasecardDic
    {
        /// <summary>
        /// 字典类型
        /// </summary>
        [Display(Name = "字典类型")]
        [StringLength(20)]
        public virtual string DicType { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 字典键
        /// </summary>
        [Display(Name = "字典键")]
        [StringLength(20)]
        public virtual string DicKey { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [Display(Name = "字典值")]
        [StringLength(100)]
        public virtual string DicValue { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///疾病报卡 CD_DiseasecardVenereal 传染报卡_性病  实体类
    /// </summary>
    [Serializable]
    public partial class CD_DiseasecardVenereal
    {
        /// <summary>
        /// 性病id
        /// </summary>
        [Display(Name = "性病")]
        [StringLength(20)]
        public virtual string VenerealId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 疾病名称
        /// </summary>
        [Display(Name = "疾病名称")]
        [StringLength(50)]
        public virtual string DiseasecardName { get; set; }

        /// <summary>
        /// 接触史
        /// </summary>
        [Display(Name = "接触史")]
        [StringLength(500)]
        public virtual string ContactHistory { get; set; }

        /// <summary>
        /// 性病史
        /// </summary>
        [Display(Name = "性病史")]
        [StringLength(50)]
        public virtual string VenerealHistory { get; set; }

        /// <summary>
        /// 最可能感染途径
        /// </summary>
        [Display(Name = "最可能感染途径")]
        [StringLength(200)]
        public virtual string InfactionWay { get; set; }

        /// <summary>
        /// 检测样本来源
        /// </summary>
        [Display(Name = "检测样本来源")]
        [StringLength(200)]
        public virtual string SampleSource { get; set; }

        /// <summary>
        /// 实验室检测结论
        /// </summary>
        [Display(Name = "实验室检测结论")]
        [StringLength(100)]
        public virtual string TestResult { get; set; }

        /// <summary>
        /// 死亡日期
        /// </summary>
        [Display(Name = "确认阳性时间")]
        public virtual DateTime? TestTime { get; set; }

        /// <summary>
        /// 确认阳性单位
        /// </summary>
        [Display(Name = "确认阳性单位")]
        [StringLength(100)]
        public virtual string TestCompany { get; set; }

        /// <summary>
        /// 艾滋病确诊日期
        /// </summary>
        [Display(Name = "艾滋病确诊日期")]
        public virtual DateTime? DiagnoseDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(4000)]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 是否作废判别
        /// </summary>
        [Display(Name = "是否作废判别")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 时限控制项目 实体类
    /// </summary>
    [Serializable]
    public partial class CD_TimeQCItem
    {
        /// <summary>
        /// 项目id
        /// </summary>
        [Display(Name = "项目")]
        [StringLength(20)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [StringLength(20)]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        [Display(Name = "项目描述")]
        [StringLength(100)]
        public virtual string ItemMemo { get; set; }

        /// <summary>
        /// 前置条件0无条件 1入院不足24小时出院 2入院不足24小时死亡 3病重病人 4病危病人 5普通病人
        /// </summary>
        [Display(Name = "前置条件")]
        public virtual int? Precondition { get; set; }

        /// <summary>
        /// 开始计时时间0入院时间 1出院时间 2死亡时间 3手术结束时间 4抢救时间 5输血时间
        /// </summary>
        [Display(Name = "开始计时时间")]
        public virtual int? TimingStart { get; set; }

        /// <summary>
        /// 循环计时标志
        /// </summary>
        [Display(Name = "循环计时标志")]
        public virtual int? LoopTiming { get; set; }

        /// <summary>
        /// 书写时限(小时)
        /// </summary>
        [Display(Name = "书写时限")]
        public virtual int? WriteTimeQC { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控项目 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MedicalRecordQC
    {
        /// <summary>
        /// 病历质控项目id
        /// </summary>
        [Display(Name = "病历质控项目")]
        [StringLength(20)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 父级项目id
        /// </summary>
        [Display(Name = "父级项目")]
        [StringLength(20)]
        public virtual string ParentItemId { get; set; }

        /// <summary>
        /// 病历质控项目名称
        /// </summary>
        [Display(Name = "病历质控项目名称")]
        [StringLength(20)]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 病历质控项目描述
        /// </summary>
        [Display(Name = "病历质控项目描述")]
        [StringLength(100)]
        public virtual string ItemMemo { get; set; }

        /// <summary>
        /// 项目默认分值0.5
        /// </summary>
        [Display(Name = "项目默认分值")]
        [StringLength(10)]
        public virtual string DefaultPoints { get; set; }

        /// <summary>
        /// 项目分值0.5-2/处
        /// </summary>
        [Display(Name = "项目分值")]
        [StringLength(10)]
        public virtual string ItemPoints { get; set; }

        /// <summary>
        /// 单项否决0否1是
        /// </summary>
        [Display(Name = "单项否决")]
        public virtual int? Veto { get; set; }

        /// <summary>
        /// 评分类型0是否1计分
        /// </summary>
        [Display(Name = "评分类型")]
        public virtual int? ScoreType { get; set; }

        /// <summary>
        /// 计分单位（类型为1时需设置单位)
        /// </summary>
        [Display(Name = "计分单位")]
        [StringLength(10)]
        public virtual string ScoreUnit { get; set; }

        /// <summary>
        /// 项目适用0否1是
        /// </summary>
        [Display(Name = "项目适用")]
        public virtual int? ItemSuit { get; set; }

        /// <summary>
        /// 分类标志0分类1项目
        /// </summary>
        [Display(Name = "项目标志")]
        public virtual int? ItemFalg { get; set; }

        /// <summary>
        /// 病历质控项目排序序号
        /// </summary>
        [Display(Name = "病历质控项目排序序号")]
        public virtual int? ItemSortNum { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控记录 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcRecord
    {
        /// <summary>
        /// 病历质控记录id
        /// </summary>
        [Display(Name = "病历质控记录")]
        [StringLength(20)]
        public virtual string RecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 病历质控类型-项目分类id
        /// </summary>
        [Display(Name = "病历质控类型")]
        [StringLength(20)]
        public virtual string QCType { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        [Display(Name = "得分")]
        [StringLength(10)]
        public virtual string Score { get; set; }

        /// <summary>
        /// 检查结果0不合格1合格
        /// </summary>
        [Display(Name = "检查结果")]
        public virtual int? CheckResult { get; set; }

        /// <summary>
        /// 质控人
        /// </summary>
        [Display(Name = "质控人")]
        [StringLength(20)]
        public virtual string QCUser { get; set; }

        /// <summary>
        /// 质控人姓名
        /// </summary>
        [Display(Name = "质控人姓名")]
        [StringLength(20)]
        public virtual string QCUserName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控记录明细 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcRecordDetail
    {
        /// <summary>
        /// 质控记录明细id
        /// </summary>
        [Display(Name = "质控记录明细")]
        [StringLength(20)]
        public virtual string RecordDetailId { get; set; }

        /// <summary>
        /// 病历质控记录id
        /// </summary>
        [Display(Name = "病历质控记录")]
        [StringLength(20)]
        public virtual string RecordId { get; set; }

        /// <summary>
        /// 病历质控项目id
        /// </summary>
        [Display(Name = "病历质控项目")]
        [StringLength(20)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 项目是否适用
        /// </summary>
        [Display(Name = "项目是否适用")]
        public virtual int ItemSuit { get; set; }

        /// <summary>
        /// 项目评分结果
        /// </summary>
        [Display(Name = "项目评分结果")]
        [StringLength(10)]
        public virtual string ItemResult { get; set; }

        /// <summary>
        /// 项目得扣分
        /// </summary>
        [Display(Name = "项目得扣分")]
        [StringLength(10)]
        public virtual string ItemScore { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(100)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控项目 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcItem
    {
        /// <summary>
        /// 病历质控项目id
        /// </summary>
        [Display(Name = "病历质控项目")]
        [StringLength(20)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 检查表id
        /// </summary>
        [Display(Name = "检查表")]
        [StringLength(20)]
        public virtual string CheckTableId { get; set; }

        /// <summary>
        /// 父级项目id
        /// </summary>
        [Display(Name = "父级项目")]
        [StringLength(20)]
        public virtual string ParentItemId { get; set; }

        /// <summary>
        /// 病历质控项目名称
        /// </summary>
        [Display(Name = "病历质控项目名称")]
        [StringLength(20)]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 病历质控项目描述
        /// </summary>
        [Display(Name = "病历质控项目描述")]
        [StringLength(100)]
        public virtual string ItemMemo { get; set; }

        /// <summary>
        /// 项目默认分值
        /// </summary>
        [Display(Name = "项目默认分值")]
        [StringLength(10)]
        public virtual string DefaultPoints { get; set; }

        /// <summary>
        /// 项目分值0.5-2/处
        /// </summary>
        [Display(Name = "项目分值")]
        [StringLength(10)]
        public virtual string ItemPoints { get; set; }

        /// <summary>
        /// 评分类型0是否1计分2单项否决
        /// </summary>
        [Display(Name = "评分类型")]
        public virtual int? ScoreType { get; set; }

        /// <summary>
        /// 计分单位（类型为1时需设置单位)
        /// </summary>
        [Display(Name = "计分单位")]
        [StringLength(10)]
        public virtual string ScoreUnit { get; set; }

        /// <summary>
        /// 项目适用0否1是
        /// </summary>
        [Display(Name = "项目适用")]
        public virtual int? ItemSuit { get; set; }

        /// <summary>
        /// 分类标志0分类1项目
        /// </summary>
        [Display(Name = "项目标志")]
        public virtual int? ItemFalg { get; set; }

        /// <summary>
        /// 病历质控项目排序序号
        /// </summary>
        [Display(Name = "病历质控项目排序序号")]
        public virtual int? ItemSortNum { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控检查表 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcCheckTable
    {
        /// <summary>
        /// 检查表id
        /// </summary>
        [Display(Name = "检查表")]
        [StringLength(20)]
        public virtual string CheckTableId { get; set; }

        /// <summary>
        /// 检查表名称
        /// </summary>
        [Display(Name = "检查表名称")]
        [StringLength(20)]
        public virtual string CheckTableName { get; set; }

        /// <summary>
        /// 检查表分类
        /// </summary>
        [Display(Name = "检查表分类")]
        public virtual int? CheckTableCategory { get; set; }

        /// <summary>
        /// 排序序号
        /// </summary>
        [Display(Name = "排序序号")]
        public virtual int? SortNum { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控结果 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcResult
    {
        /// <summary>
        /// 病历质控结果id
        /// </summary>
        [Display(Name = "病历质控结果")]
        [StringLength(20)]
        public virtual string ResultId { get; set; }

        /// <summary>
        /// 检查表id
        /// </summary>
        [Display(Name = "检查表")]
        [StringLength(20)]
        public virtual string CheckTableId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(20)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        [Display(Name = "病区名称")]
        [StringLength(20)]
        public virtual string WardName { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DepartmentName { get; set; }

        /// <summary>
        /// 主管医生id
        /// </summary>
        [Display(Name = "主管医生")]
        [StringLength(20)]
        public virtual string DirectorId { get; set; }

        /// <summary>
        /// 主管医生工号
        /// </summary>
        [Display(Name = "主管医生工号")]
        [StringLength(20)]
        public virtual string DirectorNum { get; set; }

        /// <summary>
        /// 主管医生姓名
        /// </summary>
        [Display(Name = "主管医生姓名")]
        [StringLength(20)]
        public virtual string DirectorName { get; set; }

        /// <summary>
        /// 主治医生id
        /// </summary>
        [Display(Name = "主治医生")]
        [StringLength(20)]
        public virtual string PhysicianId { get; set; }

        /// <summary>
        /// 主治医生工号
        /// </summary>
        [Display(Name = "主治医生工号")]
        [StringLength(20)]
        public virtual string PhysicianNum { get; set; }

        /// <summary>
        /// 主治医生姓名
        /// </summary>
        [Display(Name = "主治医生姓名")]
        [StringLength(20)]
        public virtual string PhysicianName { get; set; }

        /// <summary>
        /// 住院医生id
        /// </summary>
        [Display(Name = "住院医生")]
        [StringLength(20)]
        public virtual string InHospitalId { get; set; }

        /// <summary>
        /// 住院医生工号
        /// </summary>
        [Display(Name = "住院医生工号")]
        [StringLength(20)]
        public virtual string InHospitalNum { get; set; }

        /// <summary>
        /// 住院医生姓名
        /// </summary>
        [Display(Name = "住院医生姓名")]
        [StringLength(20)]
        public virtual string InHospitalName { get; set; }

        /// <summary>
        /// 实习生id
        /// </summary>
        [Display(Name = "实习生")]
        [StringLength(20)]
        public virtual string TraineeId { get; set; }

        /// <summary>
        /// 实习生工号
        /// </summary>
        [Display(Name = "实习生工号")]
        [StringLength(20)]
        public virtual string TraineeNum { get; set; }

        /// <summary>
        /// 实习生姓名
        /// </summary>
        [Display(Name = "实习生姓名")]
        [StringLength(20)]
        public virtual string TraineeName { get; set; }

        /// <summary>
        /// 主刀医生id
        /// </summary>
        [Display(Name = "主刀医生")]
        [StringLength(20)]
        public virtual string OperatorId { get; set; }

        /// <summary>
        /// 主刀医生工号
        /// </summary>
        [Display(Name = "主刀医生工号")]
        [StringLength(20)]
        public virtual string OperatorNum { get; set; }

        /// <summary>
        /// 主刀医生姓名
        /// </summary>
        [Display(Name = "主刀医生姓名")]
        [StringLength(20)]
        public virtual string OperatorName { get; set; }

        /// <summary>
        /// 一助id
        /// </summary>
        [Display(Name = "一助")]
        [StringLength(20)]
        public virtual string AssistantId { get; set; }

        /// <summary>
        /// 一助工号
        /// </summary>
        [Display(Name = "一助工号")]
        [StringLength(20)]
        public virtual string AssistantNum { get; set; }

        /// <summary>
        /// 一助姓名
        /// </summary>
        [Display(Name = "一助姓名")]
        [StringLength(20)]
        public virtual string AssistantName { get; set; }

        /// <summary>
        /// 出院病历年月
        /// </summary>
        [Display(Name = "出院病历年月")]
        public virtual DateTime? LeaveTime { get; set; }

        /// <summary>
        /// 检查地点
        /// </summary>
        [Display(Name = "检查地点")]
        [StringLength(20)]
        public virtual string ExamPlace { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        [Display(Name = "得分")]
        [StringLength(10)]
        public virtual string Score { get; set; }

        /// <summary>
        /// 检查结果0不合格1合格
        /// </summary>
        [Display(Name = "检查结果")]
        public virtual int? CheckResult { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(500)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 质控人
        /// </summary>
        [Display(Name = "质控人")]
        [StringLength(20)]
        public virtual string QCUser { get; set; }

        /// <summary>
        /// 质控人姓名
        /// </summary>
        [Display(Name = "质控人姓名")]
        [StringLength(20)]
        public virtual string QCUserName { get; set; }

        /// <summary>
        /// 质控时间
        /// </summary>
        [Display(Name = "质控时间")]
        public virtual DateTime? QCTime { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime? UpdateTime { get; set; }

    }
    /// <summary>
    ///病历质控 病历质控结果明细 实体类
    /// </summary>
    [Serializable]
    public partial class CD_MrqcResultDetail
    {
        /// <summary>
        /// 质控记录明细id
        /// </summary>
        [Display(Name = "质控记录明细")]
        [StringLength(20)]
        public virtual string RecordDetailId { get; set; }

        /// <summary>
        /// 病历质控结果id
        /// </summary>
        [Display(Name = "病历质控结果")]
        [StringLength(20)]
        public virtual string ResultId { get; set; }

        /// <summary>
        /// 病历质控项目id
        /// </summary>
        [Display(Name = "病历质控项目")]
        [StringLength(20)]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 项目是否适用
        /// </summary>
        [Display(Name = "项目是否适用")]
        public virtual int ItemSuit { get; set; }

        /// <summary>
        /// 项目评分结果
        /// </summary>
        [Display(Name = "项目评分结果")]
        [StringLength(10)]
        public virtual string ItemResult { get; set; }

        /// <summary>
        /// 项目得扣分
        /// </summary>
        [Display(Name = "项目得扣分")]
        [StringLength(10)]
        public virtual string ItemScore { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(100)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [Display(Name = "创建用户")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Display(Name = "用户创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [Display(Name = "修改用户")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>
        [Display(Name = "用户修改时间")]
        public virtual DateTime UpdateTime { get; set; }

    }
    /// <summary>
    ///护士文书 CN_TemperatureChart 体温单 实体类
    /// </summary>
    [Serializable]
    public partial class CN_TemperatureChart
    {
        /// <summary>
        /// 体温单id
        /// </summary>
        [Display(Name = "体温单")]
        [StringLength(20)]
        public virtual string ChartId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(20)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        [Display(Name = "测量时间")]
        public virtual DateTime MeasureTime { get; set; }

        /// <summary>
        /// 体温类型代码
        /// </summary>
        [Display(Name = "体温类型代码")]
        [StringLength(3)]
        public virtual string TypeCode { get; set; }

        /// <summary>
        /// 体温类型
        /// </summary>
        [Display(Name = "体温类型")]
        [StringLength(3)]
        public virtual string Type { get; set; }

        /// <summary>
        /// 出生记录id
        /// </summary>
        [Display(Name = "出生记录")]
        [StringLength(32)]
        public virtual string BirthRecordId { get; set; }

        /// <summary>
        /// 降温类型1降温1小时2降温半小时
        /// </summary>
        [Display(Name = "降温类型")]
        [StringLength(3)]
        public virtual string LowerType { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        [Display(Name = "体温")]
        [StringLength(5)]
        public virtual string Degree { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        [Display(Name = "脉搏")]
        [StringLength(10)]
        public virtual string Pulse { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [Display(Name = "心率")]
        [StringLength(10)]
        public virtual string HeartRate { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        [Display(Name = "呼吸")]
        [StringLength(10)]
        public virtual string Breath { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Display(Name = "舒张压")]
        [StringLength(10)]
        public virtual string DiastolicPressure { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Display(Name = "收缩压")]
        [StringLength(10)]
        public virtual string SystolicPressure { get; set; }

        /// <summary>
        /// 氧饱和度
        /// </summary>
        [Display(Name = "氧饱和度")]
        [StringLength(10)]
        public virtual string Spo { get; set; }

        /// <summary>
        /// 病人事件代码
        /// </summary>
        [Display(Name = "病人事件代码")]
        [StringLength(3)]
        public virtual string EventCode { get; set; }

        /// <summary>
        /// 病人事件
        /// </summary>
        [Display(Name = "病人事件")]
        [StringLength(10)]
        public virtual string Event { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        [Display(Name = "事件时间")]
        public virtual DateTime? EventTime { get; set; }

        /// <summary>
        /// 测理类型0常规1测量后半小时
        /// </summary>
        [Display(Name = "测理类型")]
        public virtual int? TestType { get; set; }

        /// <summary>
        /// 疼痛评分id
        /// </summary>
        [Display(Name = "疼痛评分")]
        [StringLength(20)]
        public virtual string PainScoreId { get; set; }

        /// <summary>
        /// 疼痛评分
        /// </summary>
        [Display(Name = "疼痛评分")]
        [StringLength(5)]
        public virtual string PainScore { get; set; }

        /// <summary>
        /// 新生儿体重
        /// </summary>
        [Display(Name = "新生儿体重")]
        [StringLength(10)]
        public virtual string NeonateWeight { get; set; }

        /// <summary>
        /// 箱温
        /// </summary>
        [Display(Name = "箱温")]
        [StringLength(10)]
        public virtual string BoxTemp { get; set; }

        /// <summary>
        /// 兰光箱
        /// </summary>
        [Display(Name = "兰光箱")]
        [StringLength(10)]
        public virtual string RayBox { get; set; }

        /// <summary>
        /// 保温箱
        /// </summary>
        [Display(Name = "保温箱")]
        [StringLength(10)]
        public virtual string Incubator { get; set; }

        /// <summary>
        /// TCB
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string TCB { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [Display(Name = "创建人姓名")]
        [StringLength(20)]
        public virtual string CreatorName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_TemperatureChartExtra 体温单额外 实体类
    /// </summary>
    [Serializable]
    public partial class CN_TemperatureChartExtra
    {
        /// <summary>
        /// 体温单id
        /// </summary>
        [Display(Name = "体温单")]
        [StringLength(20)]
        public virtual string ChartId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(20)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(20)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(20)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        [Display(Name = "测量时间")]
        public virtual DateTime MeasureTime { get; set; }

        /// <summary>
        /// 是否卧床
        /// </summary>
        [Display(Name = "是否卧床")]
        public virtual int? Bedridden { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Display(Name = "身高")]
        [StringLength(10)]
        public virtual string Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        [StringLength(10)]
        public virtual string Weight { get; set; }

        /// <summary>
        /// 时间阶段代码
        /// </summary>
        [Display(Name = "时间阶段代码")]
        [StringLength(3)]
        public virtual string PeriodCode { get; set; }

        /// <summary>
        /// 时间阶段
        /// </summary>
        [Display(Name = "时间阶段")]
        [StringLength(10)]
        public virtual string Period { get; set; }

        /// <summary>
        /// 入量类型代码
        /// </summary>
        [Display(Name = "入量类型代码")]
        [StringLength(3)]
        public virtual string INTSKETYPECODE { get; set; }

        /// <summary>
        /// 入量类型
        /// </summary>
        [Display(Name = "入量类型")]
        [StringLength(10)]
        public virtual string INTSKETYPE { get; set; }

        /// <summary>
        /// 入量时间间隔
        /// </summary>
        [Display(Name = "入量时间间隔")]
        [StringLength(5)]
        public virtual string IntakeHour { get; set; }

        /// <summary>
        /// 入量
        /// </summary>
        [Display(Name = "入量")]
        [StringLength(10)]
        public virtual string Intake { get; set; }

        /// <summary>
        /// 出量类型代码
        /// </summary>
        [Display(Name = "出量类型代码")]
        [StringLength(3)]
        public virtual string OUTPUTTYPECODE { get; set; }

        /// <summary>
        /// 出量类型
        /// </summary>
        [Display(Name = "出量类型")]
        [StringLength(10)]
        public virtual string OUTPUTTYPE { get; set; }

        /// <summary>
        /// 出量时间间隔
        /// </summary>
        [Display(Name = "出量时间间隔")]
        [StringLength(5)]
        public virtual string OutputHour { get; set; }

        /// <summary>
        /// 出量
        /// </summary>
        [Display(Name = "出量")]
        [StringLength(10)]
        public virtual string Output { get; set; }

        /// <summary>
        /// 尿量时间间隔
        /// </summary>
        [Display(Name = "尿量时间间隔")]
        [StringLength(5)]
        public virtual string UPDOur { get; set; }

        /// <summary>
        /// 尿量
        /// </summary>
        [Display(Name = "尿量")]
        [StringLength(10)]
        public virtual string UPD { get; set; }

        /// <summary>
        /// 排便方式代码
        /// </summary>
        [Display(Name = "排便方式代码")]
        [StringLength(3)]
        public virtual string StoolTypeCode { get; set; }

        /// <summary>
        /// 排便方式
        /// </summary>
        [Display(Name = "排便方式")]
        [StringLength(10)]
        public virtual string StoolType { get; set; }

        /// <summary>
        /// 大便次数
        /// </summary>
        [Display(Name = "大便次数")]
        [StringLength(5)]
        public virtual string StoolTreq { get; set; }

        /// <summary>
        /// 灌肠后大便次数
        /// </summary>
        [Display(Name = "灌肠后大便次数")]
        [StringLength(5)]
        public virtual string StoolFreqAfter { get; set; }

        /// <summary>
        /// 胆汁颜色
        /// </summary>
        [Display(Name = "胆汁颜色")]
        [StringLength(5)]
        public virtual string BileColor { get; set; }

        /// <summary>
        /// 胆汁
        /// </summary>
        [Display(Name = "胆汁")]
        [StringLength(5)]
        public virtual string Bile { get; set; }

        /// <summary>
        /// 鼻饲
        /// </summary>
        [Display(Name = "鼻饲")]
        [StringLength(5)]
        public virtual string NasalFeeding { get; set; }

        /// <summary>
        /// 胃液
        /// </summary>
        [Display(Name = "胃液")]
        [StringLength(5)]
        public virtual string SuccusGastricus { get; set; }

        /// <summary>
        /// 口入
        /// </summary>
        [Display(Name = "口入")]
        [StringLength(5)]
        public virtual string OralRoute { get; set; }

        /// <summary>
        /// 腹围
        /// </summary>
        [Display(Name = "腹围")]
        [StringLength(5)]
        public virtual string Abdomen { get; set; }

        /// <summary>
        /// 引流量
        /// </summary>
        [Display(Name = "引流量")]
        [StringLength(5)]
        public virtual string Drainage { get; set; }

        /// <summary>
        /// 自定义项1的值
        /// </summary>
        [Display(Name = "自定义项")]
        [StringLength(20)]
        public virtual string CustomItme1 { get; set; }

        /// <summary>
        /// 自定义项2的值
        /// </summary>
        [Display(Name = "自定义项")]
        [StringLength(20)]
        public virtual string CustomItme2 { get; set; }

        /// <summary>
        /// 自定义项3的值
        /// </summary>
        [Display(Name = "自定义项")]
        [StringLength(20)]
        public virtual string CustomItme3 { get; set; }

        /// <summary>
        /// 自定义项4的值
        /// </summary>
        [Display(Name = "自定义项")]
        [StringLength(20)]
        public virtual string CustomItme4 { get; set; }

        /// <summary>
        /// 自定义项5的值
        /// </summary>
        [Display(Name = "自定义项")]
        [StringLength(20)]
        public virtual string CustomItme5 { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(20)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [Display(Name = "创建人姓名")]
        [StringLength(20)]
        public virtual string CreatorName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(20)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_NursingRecord 护理记录 实体类
    /// </summary>
    [Serializable]
    public partial class CN_NursingRecord
    {
        /// <summary>
        /// 护理记录id
        /// </summary>
        [Display(Name = "护理记录")]
        [StringLength(32)]
        public virtual string RecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 护理记录类型1护理记录、2神经科护理记录
        /// </summary>
        [Display(Name = "护理记录类型")]
        [StringLength(3)]
        public virtual string RecordType { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public virtual DateTime RecordTime { get; set; }

        /// <summary>
        /// 是否术后0否1是
        /// </summary>
        [Display(Name = "是否术后")]
        public virtual int OperationAfter { get; set; }

        /// <summary>
        /// 体温类型
        /// </summary>
        [Display(Name = "体温类型")]
        [StringLength(3)]
        public virtual string DegreeType { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        [Display(Name = "体温")]
        [StringLength(10)]
        public virtual string Degree { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        [Display(Name = "脉搏")]
        [StringLength(10)]
        public virtual string Pulse { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [Display(Name = "心率")]
        [StringLength(10)]
        public virtual string HeartRate { get; set; }

        /// <summary>
        /// 皮肤情况 875
        /// </summary>
        [Display(Name = "皮肤情况")]
        public virtual int? SkinCondition { get; set; }

        /// <summary>
        /// 小便总量
        /// </summary>
        [Display(Name = "小便总量")]
        [StringLength(10)]
        public virtual string PeeMount { get; set; }

        /// <summary>
        /// 小便次数
        /// </summary>
        [Display(Name = "小便次数")]
        [StringLength(10)]
        public virtual string PeeCount { get; set; }

        /// <summary>
        /// 大便总量
        /// </summary>
        [Display(Name = "大便总量")]
        [StringLength(10)]
        public virtual string ShitMount { get; set; }

        /// <summary>
        /// 大便次数
        /// </summary>
        [Display(Name = "大便次数")]
        public virtual int? ShitCount { get; set; }

        /// <summary>
        /// 大便方式
        /// </summary>
        [Display(Name = "大便方式")]
        [StringLength(50)]
        public virtual string ShitWay { get; set; }

        /// <summary>
        /// 经皮胆红素
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string TCB { get; set; }

        /// <summary>
        /// 呼吸异常处理方法
        /// </summary>
        [Display(Name = "呼吸异常处理方法")]
        [StringLength(50)]
        public virtual string BreathDealMethod { get; set; }

        /// <summary>
        /// 呼吸异常处理代码
        /// </summary>
        [Display(Name = "呼吸异常处理代码")]
        [StringLength(10)]
        public virtual string BreathDealCode { get; set; }

        /// <summary>
        /// 血糖
        /// </summary>
        [Display(Name = "血糖")]
        [StringLength(10)]
        public virtual string BloodSugar { get; set; }

        /// <summary>
        /// RHY编码
        /// </summary>
        [Display(Name = "编码")]
        [StringLength(10)]
        public virtual string RhyCode { get; set; }

        /// <summary>
        /// RHY名称
        /// </summary>
        [Display(Name = "名称")]
        [StringLength(10)]
        public virtual string RhyName { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        [Display(Name = "呼吸")]
        [StringLength(10)]
        public virtual string Breath { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Display(Name = "舒张压")]
        [StringLength(10)]
        public virtual string DiastolicPressure { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Display(Name = "收缩压")]
        [StringLength(10)]
        public virtual string SystolicPressure { get; set; }

        /// <summary>
        /// 平均压
        /// </summary>
        [Display(Name = "平均压")]
        [StringLength(10)]
        public virtual string AveragePressure { get; set; }

        /// <summary>
        /// 有创舒张压
        /// </summary>
        [Display(Name = "有创舒张压")]
        [StringLength(10)]
        public virtual string InvasiveDiastolicPressure { get; set; }

        /// <summary>
        /// 有创收缩压
        /// </summary>
        [Display(Name = "有创收缩压")]
        [StringLength(10)]
        public virtual string InvasiveSystolicPressure { get; set; }

        /// <summary>
        /// 有创平均压
        /// </summary>
        [Display(Name = "有创平均压")]
        [StringLength(10)]
        public virtual string InvasiveAveragePressure { get; set; }

        /// <summary>
        /// 无创舒张压
        /// </summary>
        [Display(Name = "无创舒张压")]
        [StringLength(10)]
        public virtual string NoninvasiveDiastolicPressure { get; set; }

        /// <summary>
        /// 无创收缩压
        /// </summary>
        [Display(Name = "无创收缩压")]
        [StringLength(10)]
        public virtual string NoninvasiveSystolicPressure { get; set; }

        /// <summary>
        /// 无创平均压
        /// </summary>
        [Display(Name = "无创平均压")]
        [StringLength(10)]
        public virtual string NoninvasiveAveragePressure { get; set; }

        /// <summary>
        /// 氧饱和度
        /// </summary>
        [Display(Name = "氧饱和度")]
        [StringLength(10)]
        public virtual string Spo { get; set; }

        /// <summary>
        /// COPD
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string Copd { get; set; }

        /// <summary>
        /// 疼痛评分id
        /// </summary>
        [Display(Name = "疼痛评分")]
        [StringLength(32)]
        public virtual string PainScoreId { get; set; }

        /// <summary>
        /// 疼痛评分
        /// </summary>
        [Display(Name = "疼痛评分")]
        [StringLength(5)]
        public virtual string PainScore { get; set; }

        /// <summary>
        /// 意识代码
        /// </summary>
        [Display(Name = "意识代码")]
        [StringLength(3)]
        public virtual string ConsciousnessCode { get; set; }

        /// <summary>
        /// 意识
        /// </summary>
        [Display(Name = "意识")]
        [StringLength(10)]
        public virtual string Consciousness { get; set; }

        /// <summary>
        /// 中心静脉压
        /// </summary>
        [Display(Name = "中心静脉压")]
        [StringLength(10)]
        public virtual string CVP { get; set; }

        /// <summary>
        /// 中心静脉压单位
        /// </summary>
        [Display(Name = "中心静脉压单位")]
        [StringLength(10)]
        public virtual string CVPUnit { get; set; }

        /// <summary>
        /// 吸氧方式代码
        /// </summary>
        [Display(Name = "吸氧方式代码")]
        [StringLength(10)]
        public virtual string OxygenUptakeCode { get; set; }

        /// <summary>
        /// 吸氧方式
        /// </summary>
        [Display(Name = "吸氧方式")]
        [StringLength(10)]
        public virtual string OxygenUptakeMethod { get; set; }

        /// <summary>
        /// 吸氧量
        /// </summary>
        [Display(Name = "吸氧量")]
        [StringLength(10)]
        public virtual string Fio2 { get; set; }

        /// <summary>
        /// 吸氧量单位
        /// </summary>
        [Display(Name = "吸氧量单位")]
        [StringLength(10)]
        public virtual string Fio2_unit { get; set; }

        /// <summary>
        /// 左瞳孔代码
        /// </summary>
        [Display(Name = "左瞳孔代码")]
        [StringLength(3)]
        public virtual string LeftPupilCode { get; set; }

        /// <summary>
        /// 左瞳孔
        /// </summary>
        [Display(Name = "左瞳孔")]
        [StringLength(10)]
        public virtual string LeftPupil { get; set; }

        /// <summary>
        /// 右瞳孔代码
        /// </summary>
        [Display(Name = "右瞳孔代码")]
        [StringLength(3)]
        public virtual string RightPupilCode { get; set; }

        /// <summary>
        /// 右瞳孔
        /// </summary>
        [Display(Name = "右瞳孔")]
        [StringLength(10)]
        public virtual string RightPupil { get; set; }

        /// <summary>
        /// 左光反应代码
        /// </summary>
        [Display(Name = "左光反应代码")]
        [StringLength(3)]
        public virtual string LeftLightCode { get; set; }

        /// <summary>
        /// 左光反应
        /// </summary>
        [Display(Name = "左光反应")]
        [StringLength(10)]
        public virtual string LeftLight { get; set; }

        /// <summary>
        /// 右光反应代码
        /// </summary>
        [Display(Name = "右光反应代码")]
        [StringLength(3)]
        public virtual string RightLightCode { get; set; }

        /// <summary>
        /// 右光反应
        /// </summary>
        [Display(Name = "右光反应")]
        [StringLength(10)]
        public virtual string RightLight { get; set; }

        /// <summary>
        /// 睁眼反应
        /// </summary>
        [Display(Name = "睁眼反应")]
        [StringLength(5)]
        public virtual string OpenEyesReaction { get; set; }

        /// <summary>
        /// 语言反应
        /// </summary>
        [Display(Name = "语言反应")]
        [StringLength(5)]
        public virtual string LanguageReaction { get; set; }

        /// <summary>
        /// 肢体反应
        /// </summary>
        [Display(Name = "肢体反应")]
        [StringLength(5)]
        public virtual string BodyReaction { get; set; }

        /// <summary>
        /// GCS总分
        /// </summary>
        [Display(Name = "总分")]
        [StringLength(5)]
        public virtual string GcsScore { get; set; }

        /// <summary>
        /// RASS评分
        /// </summary>
        [Display(Name = "评分")]
        [StringLength(5)]
        public virtual string RassScore { get; set; }

        /// <summary>
        /// CAM-ICU评分
        /// </summary>
        [Display(Name = "评分")]
        [StringLength(5)]
        public virtual string CamIcuScore { get; set; }

        /// <summary>
        /// 健康教育
        /// </summary>
        [Display(Name = "健康教育")]
        [StringLength(200)]
        public virtual string HealthEducation { get; set; }

        /// <summary>
        /// 基础护理
        /// </summary>
        [Display(Name = "基础护理")]
        [StringLength(200)]
        public virtual string BasicNursing { get; set; }

        /// <summary>
        /// 简要病情
        /// </summary>
        [Display(Name = "简要病情")]
        [StringLength(2000)]
        public virtual string Illness { get; set; }

        /// <summary>
        /// 胎儿娩出
        /// </summary>
        [Display(Name = "胎儿娩出")]
        public virtual int? NeonateOut { get; set; }

        /// <summary>
        /// 扩展内容JSON或XML
        /// </summary>
        [Display(Name = "扩展内容")]
        [StringLength(20000)]
        public virtual string ExtContent { get; set; }

        /// <summary>
        /// 护士签名人id
        /// </summary>
        [Display(Name = "护士签名人")]
        [StringLength(32)]
        public virtual string SignatureId { get; set; }

        /// <summary>
        /// 护士签名
        /// </summary>
        [Display(Name = "护士签名")]
        [StringLength(20)]
        public virtual string Signature { get; set; }

        /// <summary>
        /// 上级护士签名
        /// </summary>
        [Display(Name = "上级护士签名")]
        [StringLength(32)]
        public virtual string HigherLevelSigId { get; set; }

        /// <summary>
        /// 上级护士签名
        /// </summary>
        [Display(Name = "上级护士签名")]
        [StringLength(20)]
        public virtual string HigherLevelSig { get; set; }

        /// <summary>
        /// 上级护士签名时间
        /// </summary>
        [Display(Name = "上级护士签名时间")]
        public virtual DateTime? HigherLevelSigTime { get; set; }

        /// <summary>
        /// 数据来源(0手动添加1自动采集)
        /// </summary>
        [Display(Name = "数据来源")]
        [StringLength(1)]
        public virtual string DataSource { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int? Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime? UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(32)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_NeonateBirthRecord 新生儿出生记录 实体类
    /// </summary>
    [Serializable]
    public partial class CN_NeonateBirthRecord
    {
        /// <summary>
        /// 出生记录id
        /// </summary>
        [Display(Name = "出生记录")]
        [StringLength(32)]
        public virtual string BirthRecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 胎
        /// </summary>
        [Display(Name = "胎")]
        [StringLength(10)]
        public virtual string Embryo { get; set; }

        /// <summary>
        /// 产
        /// </summary>
        [Display(Name = "产")]
        [StringLength(10)]
        public virtual string Birth { get; set; }

        /// <summary>
        /// 周龄
        /// </summary>
        [Display(Name = "周龄")]
        [StringLength(10)]
        public virtual string Weeks { get; set; }

        /// <summary>
        /// 胎位
        /// </summary>
        [Display(Name = "胎位")]
        [StringLength(10)]
        public virtual string Position { get; set; }

        /// <summary>
        /// 分娩方式
        /// </summary>
        [Display(Name = "分娩方式")]
        [StringLength(10)]
        public virtual string DeliveryWay { get; set; }

        /// <summary>
        /// 出生时间
        /// </summary>
        [Display(Name = "出生时间")]
        public virtual DateTime? BirthTime { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [StringLength(10)]
        public virtual string Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        [StringLength(10)]
        public virtual string Weight { get; set; }

        /// <summary>
        /// 身长
        /// </summary>
        [Display(Name = "身长")]
        [StringLength(10)]
        public virtual string Length { get; set; }

        /// <summary>
        /// 破膜方式
        /// </summary>
        [Display(Name = "破膜方式")]
        [StringLength(10)]
        public virtual string MemRupWay { get; set; }

        /// <summary>
        /// 破膜时间（小时）
        /// </summary>
        [Display(Name = "破膜时间")]
        [StringLength(10)]
        public virtual string MemRupTime { get; set; }

        /// <summary>
        /// 羊水
        /// </summary>
        [Display(Name = "羊水")]
        [StringLength(10)]
        public virtual string Amniotic { get; set; }

        /// <summary>
        /// 羊水量（ml）
        /// </summary>
        [Display(Name = "羊水量")]
        [StringLength(10)]
        public virtual string AmnioticAmount { get; set; }

        /// <summary>
        /// 产前诊断
        /// </summary>
        [Display(Name = "产前诊断")]
        [StringLength(100)]
        public virtual string BirthDiag { get; set; }

        /// <summary>
        /// 产时母亲用药
        /// </summary>
        [Display(Name = "产时母亲用药")]
        [StringLength(100)]
        public virtual string BirthingDrug { get; set; }

        /// <summary>
        /// HBsAg
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string Hbsag { get; set; }

        /// <summary>
        /// HBeAg
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string Hbeag { get; set; }

        /// <summary>
        /// TRust
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string TRust { get; set; }

        /// <summary>
        /// TPPA
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string TPPA { get; set; }

        /// <summary>
        /// ABO血型
        /// </summary>
        [Display(Name = "血型")]
        [StringLength(10)]
        public virtual string Abo { get; set; }

        /// <summary>
        /// Rh
        /// </summary>
        [Display(Name = "")]
        [StringLength(10)]
        public virtual string RH { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        [StringLength(100)]
        public virtual string Other { get; set; }

        /// <summary>
        /// 宫内窘迫0无1有
        /// </summary>
        [Display(Name = "宫内窘迫")]
        public virtual int? WonbStress { get; set; }

        /// <summary>
        /// 产时抢救措施（JSON）
        /// </summary>
        [Display(Name = "产时抢救措施")]
        [StringLength(2000)]
        public virtual string BirthingSave { get; set; }

        /// <summary>
        /// 脐带（JSON）
        /// </summary>
        [Display(Name = "脐带")]
        [StringLength(200)]
        public virtual string Cord { get; set; }

        /// <summary>
        /// 婴儿畸形或异常
        /// </summary>
        [Display(Name = "婴儿畸形或异常")]
        [StringLength(100)]
        public virtual string Abnormal { get; set; }

        /// <summary>
        /// 婴儿去向
        /// </summary>
        [Display(Name = "婴儿去向")]
        [StringLength(20)]
        public virtual string GoWhere { get; set; }

        /// <summary>
        /// 补充记录
        /// </summary>
        [Display(Name = "补充记录")]
        [StringLength(100)]
        public virtual string AddRecord { get; set; }

        /// <summary>
        /// 接生者
        /// </summary>
        [Display(Name = "接生者")]
        [StringLength(32)]
        public virtual string Deliver { get; set; }

        /// <summary>
        /// 接生者姓名
        /// </summary>
        [Display(Name = "接生者姓名")]
        [StringLength(20)]
        public virtual string DeliverName { get; set; }

        /// <summary>
        /// 填表者
        /// </summary>
        [Display(Name = "填表者")]
        [StringLength(32)]
        public virtual string FillUser { get; set; }

        /// <summary>
        /// 填表者姓名
        /// </summary>
        [Display(Name = "填表者姓名")]
        [StringLength(20)]
        public virtual string FillUserName { get; set; }

        /// <summary>
        /// 审核者
        /// </summary>
        [Display(Name = "审核者")]
        [StringLength(32)]
        public virtual string Auditor { get; set; }

        /// <summary>
        /// 审核者姓名
        /// </summary>
        [Display(Name = "审核者姓名")]
        [StringLength(20)]
        public virtual string AuditorName { get; set; }

        /// <summary>
        /// APGAR评分（JSON）
        /// </summary>
        [Display(Name = "评分")]
        [StringLength(1000)]
        public virtual string ApgarScore { get; set; }

        /// <summary>
        /// APGAR一分钟
        /// </summary>
        [Display(Name = "一分钟")]
        [StringLength(10)]
        public virtual string ApgarOneMin { get; set; }

        /// <summary>
        /// APGAR五分钟
        /// </summary>
        [Display(Name = "五分钟")]
        [StringLength(10)]
        public virtual string ApgarFiveMin { get; set; }

        /// <summary>
        /// APGAR十分钟
        /// </summary>
        [Display(Name = "十分钟")]
        [StringLength(10)]
        public virtual string ApgarTenMin { get; set; }

        /// <summary>
        /// 护士签名
        /// </summary>
        [Display(Name = "护士签名")]
        [StringLength(32)]
        public virtual string NurseSignature { get; set; }

        /// <summary>
        /// 护士签名姓名
        /// </summary>
        [Display(Name = "护士签名姓名")]
        [StringLength(20)]
        public virtual string NurseSignatureName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(32)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_NeonateBirthObserve 新生儿产时观察记录 实体类
    /// </summary>
    [Serializable]
    public partial class CN_NeonateBirthObserve
    {
        /// <summary>
        /// 观察记录id
        /// </summary>
        [Display(Name = "观察记录")]
        [StringLength(32)]
        public virtual string ObserveId { get; set; }

        /// <summary>
        /// 出生记录id
        /// </summary>
        [Display(Name = "出生记录")]
        [StringLength(32)]
        public virtual string BirthRecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public virtual DateTime? RecordTime { get; set; }

        /// <summary>
        /// 血糖（mmol/l）
        /// </summary>
        [Display(Name = "血糖")]
        [StringLength(10)]
        public virtual string BloodSugar { get; set; }

        /// <summary>
        /// 异常情况及处理
        /// </summary>
        [Display(Name = "异常情况及处理")]
        [StringLength(2000)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name = "签名")]
        [StringLength(32)]
        public virtual string Signature { get; set; }

        /// <summary>
        /// 签名姓名
        /// </summary>
        [Display(Name = "签名姓名")]
        [StringLength(20)]
        public virtual string SignatureName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(32)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_BirthingRecord 产时记录 实体类
    /// </summary>
    [Serializable]
    public partial class CN_BirthingRecord
    {
        /// <summary>
        /// 产时记录id
        /// </summary>
        [Display(Name = "产时记录")]
        [StringLength(32)]
        public virtual string BirthingRecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 破膜时间
        /// </summary>
        [Display(Name = "破膜时间")]
        public virtual DateTime? MemRupTime { get; set; }

        /// <summary>
        /// 破膜方式1自破，2人工
        /// </summary>
        [Display(Name = "破膜方式")]
        [StringLength(10)]
        public virtual string MemRupWay { get; set; }

        /// <summary>
        /// 羊水0清，1Ⅰ，2Ⅱ，3Ⅲ，4臭
        /// </summary>
        [Display(Name = "羊水")]
        [StringLength(10)]
        public virtual string Amniotic { get; set; }

        /// <summary>
        /// 羊水量（ml）
        /// </summary>
        [Display(Name = "羊水量")]
        [StringLength(10)]
        public virtual string AmnioticAmount { get; set; }

        /// <summary>
        /// 宫缩开始
        /// </summary>
        [Display(Name = "宫缩开始")]
        public virtual DateTime? WonbContBegin { get; set; }

        /// <summary>
        /// 第一产程
        /// </summary>
        [Display(Name = "第一产程")]
        [StringLength(10)]
        public virtual string FirstParturient { get; set; }

        /// <summary>
        /// 宫口全开
        /// </summary>
        [Display(Name = "宫口全开")]
        public virtual DateTime? WonbOpen { get; set; }

        /// <summary>
        /// 第二产程
        /// </summary>
        [Display(Name = "第二产程")]
        [StringLength(10)]
        public virtual string SecondParturient { get; set; }

        /// <summary>
        /// 胎儿娩出
        /// </summary>
        [Display(Name = "胎儿娩出")]
        public virtual DateTime? NeonateOut { get; set; }

        /// <summary>
        /// 第三产程
        /// </summary>
        [Display(Name = "第三产程")]
        [StringLength(10)]
        public virtual string ThridParturient { get; set; }

        /// <summary>
        /// 胎盘娩出
        /// </summary>
        [Display(Name = "胎盘娩出")]
        public virtual DateTime? PlacentaOut { get; set; }

        /// <summary>
        /// 总产程
        /// </summary>
        [Display(Name = "总产程")]
        [StringLength(10)]
        public virtual string Parturient { get; set; }

        /// <summary>
        /// 娩出胎位
        /// </summary>
        [Display(Name = "娩出胎位")]
        [StringLength(10)]
        public virtual string position { get; set; }

        /// <summary>
        /// 分娩方式
        /// </summary>
        [Display(Name = "分娩方式")]
        [StringLength(50)]
        public virtual string DeliveryWay { get; set; }

        /// <summary>
        /// 胎盘（JSON）
        /// </summary>
        [Display(Name = "胎盘")]
        [StringLength(1000)]
        public virtual string Placenta { get; set; }

        /// <summary>
        /// 胎膜（JSON）
        /// </summary>
        [Display(Name = "胎膜")]
        [StringLength(200)]
        public virtual string Membrane { get; set; }

        /// <summary>
        /// 脐带（JSON）
        /// </summary>
        [Display(Name = "脐带")]
        [StringLength(200)]
        public virtual string Cord { get; set; }

        /// <summary>
        /// 新生儿（JSON）
        /// </summary>
        [Display(Name = "新生儿")]
        [StringLength(1000)]
        public virtual string Neonate { get; set; }

        /// <summary>
        /// 会阴（JSON）
        /// </summary>
        [Display(Name = "会阴")]
        [StringLength(100)]
        public virtual string Perineum { get; set; }

        /// <summary>
        /// 麻醉方式
        /// </summary>
        [Display(Name = "麻醉方式")]
        [StringLength(10)]
        public virtual string AnesthetistWay { get; set; }

        /// <summary>
        /// 手术指征
        /// </summary>
        [Display(Name = "手术指征")]
        [StringLength(20)]
        public virtual string OperationIndication { get; set; }

        /// <summary>
        /// 手术方式
        /// </summary>
        [Display(Name = "手术方式")]
        [StringLength(20)]
        public virtual string OperationWay { get; set; }

        /// <summary>
        /// 产后出血
        /// </summary>
        [Display(Name = "产后出血")]
        [StringLength(10)]
        public virtual string PuerperalHemorrhage { get; set; }

        /// <summary>
        /// 子宫收缩
        /// </summary>
        [Display(Name = "子宫收缩")]
        [StringLength(10)]
        public virtual string WonbContraction { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Display(Name = "舒张压")]
        [StringLength(10)]
        public virtual string DiastolicPressure { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Display(Name = "收缩压")]
        [StringLength(10)]
        public virtual string SystolicPressure { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        [Display(Name = "脉搏")]
        [StringLength(10)]
        public virtual string Pulse { get; set; }

        /// <summary>
        /// 诊断
        /// </summary>
        [Display(Name = "诊断")]
        [StringLength(100)]
        public virtual string Diagnosis { get; set; }

        /// <summary>
        /// 补充记录
        /// </summary>
        [Display(Name = "补充记录")]
        [StringLength(100)]
        public virtual string AddRecord { get; set; }

        /// <summary>
        /// 纱布清点（JSON）
        /// </summary>
        [Display(Name = "纱布清点")]
        [StringLength(100)]
        public virtual string GauzeCount { get; set; }

        /// <summary>
        /// 接生者
        /// </summary>
        [Display(Name = "接生者")]
        [StringLength(32)]
        public virtual string Deliver { get; set; }

        /// <summary>
        /// 接生者姓名
        /// </summary>
        [Display(Name = "接生者姓名")]
        [StringLength(20)]
        public virtual string DeliverName { get; set; }

        /// <summary>
        /// 核对者
        /// </summary>
        [Display(Name = "核对者")]
        [StringLength(32)]
        public virtual string Checker { get; set; }

        /// <summary>
        /// 核对者姓名
        /// </summary>
        [Display(Name = "核对者姓名")]
        [StringLength(20)]
        public virtual string CheckerName { get; set; }

        /// <summary>
        /// 早吮吸（JSON）
        /// </summary>
        [Display(Name = "早吮吸")]
        [StringLength(100)]
        public virtual string FirstSuck { get; set; }

        /// <summary>
        /// 谈话记录（JSON）
        /// </summary>
        [Display(Name = "谈话记录")]
        [StringLength(100)]
        public virtual string TalkRecord { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(32)]
        public virtual string Updater { get; set; }

    }
    /// <summary>
    ///护士文书 CN_AfterBirthObserve 产后两小时观察记录 实体类
    /// </summary>
    [Serializable]
    public partial class CN_AfterBirthObserve
    {
        /// <summary>
        /// 观察记录id
        /// </summary>
        [Display(Name = "观察记录")]
        [StringLength(32)]
        public virtual string ObserveId { get; set; }

        /// <summary>
        /// 产时记录id
        /// </summary>
        [Display(Name = "产时记录")]
        [StringLength(32)]
        public virtual string BirthingRecordId { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        [Display(Name = "住院")]
        [StringLength(32)]
        public virtual string InpatientId { get; set; }

        /// <summary>
        /// 机构序号
        /// </summary>
        [Display(Name = "机构序号")]
        [StringLength(20)]
        public virtual string OrganID { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Display(Name = "科室")]
        [StringLength(32)]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 病区id
        /// </summary>
        [Display(Name = "病区")]
        [StringLength(32)]
        public virtual string WardId { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(10)]
        public virtual string BedNum { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public virtual DateTime? RecordTime { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Display(Name = "舒张压")]
        [StringLength(10)]
        public virtual string DiastolicPressure { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Display(Name = "收缩压")]
        [StringLength(10)]
        public virtual string SystolicPressure { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        [Display(Name = "脉搏")]
        [StringLength(10)]
        public virtual string Pulse { get; set; }

        /// <summary>
        /// 宫底
        /// </summary>
        [Display(Name = "宫底")]
        [StringLength(10)]
        public virtual string WonbBottom { get; set; }

        /// <summary>
        /// 子宫质地
        /// </summary>
        [Display(Name = "子宫质地")]
        [StringLength(10)]
        public virtual string WonbTexture { get; set; }

        /// <summary>
        /// 阴道出血量（ml）
        /// </summary>
        [Display(Name = "阴道出血量")]
        [StringLength(10)]
        public virtual string ViginaHemorrhage { get; set; }

        /// <summary>
        /// 膀胱充盈度
        /// </summary>
        [Display(Name = "膀胱充盈度")]
        [StringLength(10)]
        public virtual string Bladder { get; set; }

        /// <summary>
        /// 会阴渗血
        /// </summary>
        [Display(Name = "会阴渗血")]
        [StringLength(10)]
        public virtual string PerineumHemorrhage { get; set; }

        /// <summary>
        /// 会阴水肿
        /// </summary>
        [Display(Name = "会阴水肿")]
        [StringLength(10)]
        public virtual string PerineumEdema { get; set; }

        /// <summary>
        /// 便意感
        /// </summary>
        [Display(Name = "便意感")]
        [StringLength(10)]
        public virtual string PeeFeel { get; set; }

        /// <summary>
        /// 补充记录
        /// </summary>
        [Display(Name = "补充记录")]
        [StringLength(100)]
        public virtual string AddRecord { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name = "签名")]
        [StringLength(32)]
        public virtual string Signature { get; set; }

        /// <summary>
        /// 签名姓名
        /// </summary>
        [Display(Name = "签名姓名")]
        [StringLength(20)]
        public virtual string SignatureName { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        [Display(Name = "作废标志")]
        public virtual int Del { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdaterTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [StringLength(32)]
        public virtual string Updater { get; set; }

    }



    /// <summary>
    ///医院感染督查反馈单 业务 BUS_YGDCFKD  实体类
    /// </summary>
    [Serializable]
    public partial class BUS_YGDCFKD
    {
        /// <summary>
        /// 反馈单主键
        /// </summary>
        [Display(Name = "反馈单ID")]
        [StringLength(20)]
        public virtual string FKDID { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }

        /// <summary>
        /// 受检科室主键
        /// </summary>
        [Display(Name = "受检科室ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }
        /// <summary>
        /// 受检科室名称
        /// </summary>
        [Display(Name = "受检科室名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        [Display(Name = "检查时间")]
        public virtual DateTime? JCSJ { get; set; }
        /// <summary>
        /// 检查者
        /// </summary>
        [Display(Name = "检查者")]
        [StringLength(50)]
        public virtual string JCZ { get; set; }
        /// <summary>
        /// 科主任护士长签名
        /// </summary>
        [Display(Name = "科主任护士长签名")]
        [StringLength(50)]
        public virtual string KHSZQM { get; set; }
        /// <summary>
        /// 签名时间
        /// </summary>
        [Display(Name = "签名时间")]
        public virtual DateTime? QMRQ { get; set; }
        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }
        /// <summary>
        /// 新增人员名称
        /// </summary>
        [Display(Name = "新增人员名称")]
        [StringLength(50)]
        public virtual string XZRYMC { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }

    }

    /// <summary>
    ///医院感染督查反馈单 业务 BUS_YGDCFKD_SOURCE 数据实体类
    /// </summary>
    [Serializable]
    public partial class BUS_YGDCFKD_SOURCE
    {
        /// <summary>
        /// 反馈单数据主键
        /// </summary>
        [Display(Name = "反馈单数据ID")]
        [StringLength(20)]
        public virtual string FKDSOURCEID { get; set; }
        /// <summary>
        /// 存在问题
        /// </summary>
        [Display(Name = "存在问题")]
        [StringLength(2000)]
        public virtual string CZWT { get; set; }
        /// <summary>
        /// 现场照片：以逗号间隔，存放图片url地址 如; guid.jpg
        /// </summary>
        [Display(Name = "现场照片")]
        [StringLength(2000)]
        public virtual string XCZP { get; set; }
        /// <summary>
        /// 整改建议
        /// </summary>
        [Display(Name = "整改建议")]
        [StringLength(2000)]
        public virtual string ZGJY { get; set; }
        /// <summary>
        /// 科室原因分析
        /// </summary>
        [Display(Name = "科室原因分析")]
        [StringLength(2000)]
        public virtual string KSYYFX { get; set; }
        /// <summary>
        /// 科室整改措施
        /// </summary>
        [Display(Name = "科室整改措施")]
        [StringLength(2000)]
        public virtual string KSZGCS { get; set; }
        /// <summary>
        /// 效果评价
        /// </summary>
        [Display(Name = "效果评价")]
        [StringLength(2000)]
        public virtual string XGPJ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(2000)]
        public virtual string BZ { get; set; }
        /// <summary>
        /// BUS_YGDCFKD表ID，主表ID
        /// </summary>
        [Display(Name = "反馈单ID外键")]
        [StringLength(20)]
        public virtual string FKDID { get; set; }
        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员编号")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }
        /// <summary>
        /// 新增人员名称
        /// </summary>
        [Display(Name = "新增人员名称")]
        [StringLength(50)]
        public virtual string XZRYMC { get; set; }
        /// <summary>
        /// 新增人员所在科室ID
        /// </summary>
        [Display(Name = "新增人员所在科室ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }
        /// <summary>
        /// 新增人员所在科室名称
        /// </summary>
        [Display(Name = "新增人员所在科室名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
    }

    /// <summary>
    ///洗手（卫生手消毒）操作评分标准 业务 BUS_WASHHANDOPERATION 数据实体类
    /// </summary> 
    [Serializable]
    public partial class BUS_WASHHANDOPERATION
    {
        /// <summary>
        /// 洗手操作主键
        /// </summary>
        [Display(Name = "洗手操作ID")]
        [StringLength(20)]
        public virtual string WHOID { get; set; }

        [Display(Name = "部门ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }


        [Display(Name = "部门名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }

        [Display(Name = "操作者")]
        [StringLength(20)]
        public virtual string OPNAME { get; set; }

        [Display(Name = "职业名称")]
        [StringLength(20)]
        public virtual string PRONAME { get; set; }

        [Display(Name = "监考人")]
        [StringLength(20)]
        public virtual string PROCTOR { get; set; }

        [Display(Name = "监考日期")]
        [StringLength(20)]
        public virtual DateTime? PROCTDATE { get; set; }

        [Display(Name = "手写得分")]
        [StringLength(20)]
        public virtual string WIRTESCORE { get; set; }

        [Display(Name = "扣分依据1")]
        [StringLength(20)]
        public virtual string DEDBASIS1 { get; set; }

        [Display(Name = "扣分1")]
        [StringLength(20)]
        public virtual string BASIS1 { get; set; }

        [Display(Name = "扣分依据2")]
        [StringLength(20)]
        public virtual string DEDBASIS2 { get; set; }

        [Display(Name = "扣分2")]
        [StringLength(20)]
        public virtual string BASIS2 { get; set; }

        [Display(Name = "扣分依据3")]
        [StringLength(20)]
        public virtual string DEDBASIS3 { get; set; }

        [Display(Name = "扣分3")]
        [StringLength(20)]
        public virtual string BASIS3 { get; set; }

        [Display(Name = "扣分依据4")]
        [StringLength(20)]
        public virtual string DEDBASIS4 { get; set; }

        [Display(Name = "扣分4")]
        [StringLength(20)]
        public virtual string BASIS4 { get; set; }

        [Display(Name = "扣分依据5")]
        [StringLength(20)]
        public virtual string DEDBASIS5 { get; set; }

        [Display(Name = "扣分5")]
        [StringLength(20)]
        public virtual string BASIS5 { get; set; }

        [Display(Name = "扣分依据6")]
        [StringLength(20)]
        public virtual string DEDBASIS6 { get; set; }

        [Display(Name = "扣分6")]
        [StringLength(20)]
        public virtual string BASIS6 { get; set; }

        [Display(Name = "扣分依据7")]
        [StringLength(20)]
        public virtual string DEDBASIS7 { get; set; }

        [Display(Name = "扣分7")]
        [StringLength(20)]
        public virtual string BASIS7 { get; set; }

        [Display(Name = "扣分依据8")]
        [StringLength(20)]
        public virtual string DEDBASIS8 { get; set; }

        [Display(Name = "扣分8")]
        [StringLength(20)]
        public virtual string BASIS8 { get; set; }

        [Display(Name = "扣分依据9")]
        [StringLength(20)]
        public virtual string DEDBASIS9 { get; set; }

        [Display(Name = "扣分9")]
        [StringLength(20)]
        public virtual string BASIS9 { get; set; }

        [Display(Name = "扣分依据10")]
        [StringLength(20)]
        public virtual string DEDBASIS10 { get; set; }

        [Display(Name = "扣分10")]
        [StringLength(20)]
        public virtual string BASIS10 { get; set; }

        [Display(Name = "扣分依据11")]
        [StringLength(20)]
        public virtual string DEDBASIS11 { get; set; }

        [Display(Name = "扣分11")]
        [StringLength(20)]
        public virtual string BASIS11 { get; set; }

        [Display(Name = "扣分依据12")]
        [StringLength(20)]
        public virtual string DEDBASIS12 { get; set; }

        [Display(Name = "扣分12")]
        [StringLength(20)]
        public virtual string BASIS12 { get; set; }

        [Display(Name = "扣分依据13")]
        [StringLength(20)]
        public virtual string DEDBASIS13 { get; set; }

        [Display(Name = "扣分13")]
        [StringLength(20)]
        public virtual string BASIS13 { get; set; }

        [Display(Name = "扣分依据14")]
        [StringLength(20)]
        public virtual string DEDBASIS14 { get; set; }

        [Display(Name = "扣分14")]
        [StringLength(20)]
        public virtual string BASIS14 { get; set; }

        [Display(Name = "扣分15")]
        [StringLength(20)]
        public virtual string DEDBASIS15 { get; set; }

        [Display(Name = "扣分15")]
        [StringLength(20)]
        public virtual string BASIS15 { get; set; }

        [Display(Name = "扣分依据16")]
        [StringLength(20)]
        public virtual string DEDBASIS16 { get; set; }

        [Display(Name = "扣分16")]
        [StringLength(20)]
        public virtual string BASIS16 { get; set; }

        [Display(Name = "扣分依据17")]
        [StringLength(20)]
        public virtual string DEDBASIS17 { get; set; }

        [Display(Name = "扣分17")]
        [StringLength(20)]
        public virtual string BASIS17 { get; set; }

        [Display(Name = "计算得分")]
        [StringLength(20)]
        public virtual string SUMSCORE { get; set; }


        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        [Display(Name = "新增人员名称")]
        [StringLength(50)]
        public virtual string XZRYMC { get; set; }

        [Display(Name = "新增日期")]
        [StringLength(50)]
        public virtual DateTime? XZRQ { get; set; }

        [Display(Name = "组织机构ID")]
        [StringLength(50)]
        public virtual string ORGANID { get; set; }

        [Display(Name = "着装整洁")]
        [StringLength(40)]
        public virtual string ZZZJ { get; set; }
        [Display(Name = "指甲状态")]
        [StringLength(40)]
        public virtual string ZJZT { get; set; }
        [Display(Name = "手部饰品")]
        [StringLength(40)]
        public virtual string SBSP { get; set; }
        [Display(Name = "洗手装备")]
        [StringLength(40)]
        public virtual string XSZB { get; set; }
        [Display(Name = "洗手消毒")]
        [StringLength(40)]
        public virtual string XSXD { get; set; }
        [Display(Name = "消洗质保")]
        [StringLength(40)]
        public virtual string XXZB { get; set; }
        [Display(Name = "非手触式")]
        [StringLength(40)]
        public virtual string FSCS { get; set; }
        [Display(Name = "淋湿双手")]
        [StringLength(40)]
        public virtual string LSSS { get; set; }

        [Display(Name = "关闭水龙头")]
        [StringLength(40)]
        public virtual string GBLT { get; set; }
        [Display(Name = "手背或小鱼际处按压")]
        [StringLength(40)]
        public virtual string SBAY { get; set; }

        [Display(Name = "取消洗剂")]
        [StringLength(40)]
        public virtual string QXXJ { get; set; }
        [Display(Name = "均匀涂抹")]
        [StringLength(40)]
        public virtual string JYTM { get; set; }
        [Display(Name = "掌背指缝")]
        [StringLength(40)]
        public virtual string ZBZF { get; set; }
        [Display(Name = "双手揉擦")]
        [StringLength(40)]
        public virtual string SSRC { get; set; }
        [Display(Name = "相互揉搓")]
        [StringLength(40)]
        public virtual string XHRC { get; set; }
        [Display(Name = "交换进行")]
        [StringLength(40)]
        public virtual string JHJX { get; set; }
        [Display(Name = "掌心相对")]
        [StringLength(40)]
        public virtual string ZXXD { get; set; }
        [Display(Name = "弯曲手指")]
        [StringLength(40)]
        public virtual string WQSZ { get; set; }
        [Display(Name = "握大拇指")]
        [StringLength(40)]
        public virtual string WDMZ { get; set; }
        [Display(Name = "指尖并拢")]
        [StringLength(40)]
        public virtual string ZJBL { get; set; }
        [Display(Name = "双侧手腕")]
        [StringLength(40)]
        public virtual string SCSW { get; set; }
        [Display(Name = "双手冲净")]
        [StringLength(40)]
        public virtual string SSCJ { get; set; }
        [Display(Name = "正确关闭")]
        [StringLength(40)]
        public virtual string ZQGB { get; set; }
        [Display(Name = "非手触式龙头")]
        [StringLength(40)]
        public virtual string FSCSLT { get; set; }
        [Display(Name = "水花飞溅")]
        [StringLength(40)]
        public virtual string SHFJ { get; set; }
        [Display(Name = "擦拭双手")]
        [StringLength(40)]
        public virtual string CSSS { get; set; }
        [Display(Name = "消毒至干")]
        [StringLength(40)]
        public virtual string XDZG { get; set; }
        [Display(Name = "洗手时间")]
        [StringLength(40)]
        public virtual string XSSJ { get; set; }
        [Display(Name = "消毒指征")]
        [StringLength(40)]
        public virtual string XDZZ { get; set; }
        [Display(Name = "先洗后消")]
        [StringLength(40)]
        public virtual string XXHX { get; set; }
        [Display(Name = "细菌菌落")]
        [StringLength(40)]
        public virtual string XJJL { get; set; }
    }

    /// <summary>
    ///外科手消毒操作评分标准 业务 BUS_DISINFECTION 数据实体类
    /// </summary>
    [Serializable]
    public partial class BUS_DISINFECTION
    {
        /// <summary>
        /// 洗手操作主键
        /// </summary>
        [Display(Name = "外科手消毒操作评分标准ID")]
        [StringLength(20)]
        public virtual string DISID { get; set; }

        [Display(Name = "部门ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }


        [Display(Name = "部门名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }

        [Display(Name = "操作者")]
        [StringLength(20)]
        public virtual string OPNAME { get; set; }

        [Display(Name = "职业名称")]
        [StringLength(20)]
        public virtual string PRONAME { get; set; }

        [Display(Name = "监考人")]
        [StringLength(20)]
        public virtual string PROCTOR { get; set; }

        [Display(Name = "监考日期")]
        [StringLength(20)]
        public virtual DateTime? PROCTDATE { get; set; }

        [Display(Name = "手写得分")]
        [StringLength(20)]
        public virtual string WIRTESCORE { get; set; }

        [Display(Name = "扣分依据1")]
        [StringLength(20)]
        public virtual string DEDBASIS1 { get; set; }

        [Display(Name = "扣分1")]
        [StringLength(20)]
        public virtual string BASIS1 { get; set; }

        [Display(Name = "扣分依据2")]
        [StringLength(20)]
        public virtual string DEDBASIS2 { get; set; }

        [Display(Name = "扣分2")]
        [StringLength(20)]
        public virtual string BASIS2 { get; set; }

        [Display(Name = "扣分依据3")]
        [StringLength(20)]
        public virtual string DEDBASIS3 { get; set; }

        [Display(Name = "扣分3")]
        [StringLength(20)]
        public virtual string BASIS3 { get; set; }

        [Display(Name = "扣分依据4")]
        [StringLength(20)]
        public virtual string DEDBASIS4 { get; set; }

        [Display(Name = "扣分4")]
        [StringLength(20)]
        public virtual string BASIS4 { get; set; }

        [Display(Name = "扣分依据5")]
        [StringLength(20)]
        public virtual string DEDBASIS5 { get; set; }

        [Display(Name = "扣分5")]
        [StringLength(20)]
        public virtual string BASIS5 { get; set; }

        [Display(Name = "扣分依据6")]
        [StringLength(20)]
        public virtual string DEDBASIS6 { get; set; }

        [Display(Name = "扣分6")]
        [StringLength(20)]
        public virtual string BASIS6 { get; set; }

        [Display(Name = "扣分依据7")]
        [StringLength(20)]
        public virtual string DEDBASIS7 { get; set; }

        [Display(Name = "扣分7")]
        [StringLength(20)]
        public virtual string BASIS7 { get; set; }

        [Display(Name = "扣分依据8")]
        [StringLength(20)]
        public virtual string DEDBASIS8 { get; set; }

        [Display(Name = "扣分8")]
        [StringLength(20)]
        public virtual string BASIS8 { get; set; }

        [Display(Name = "扣分依据9")]
        [StringLength(20)]
        public virtual string DEDBASIS9 { get; set; }

        [Display(Name = "扣分9")]
        [StringLength(20)]
        public virtual string BASIS9 { get; set; }

        [Display(Name = "扣分依据10")]
        [StringLength(20)]
        public virtual string DEDBASIS10 { get; set; }

        [Display(Name = "扣分10")]
        [StringLength(20)]
        public virtual string BASIS10 { get; set; }

        [Display(Name = "扣分依据11")]
        [StringLength(20)]
        public virtual string DEDBASIS11 { get; set; }

        [Display(Name = "扣分11")]
        [StringLength(20)]
        public virtual string BASIS11 { get; set; }

        [Display(Name = "扣分依据12")]
        [StringLength(20)]
        public virtual string DEDBASIS12 { get; set; }

        [Display(Name = "扣分12")]
        [StringLength(20)]
        public virtual string BASIS12 { get; set; }

        [Display(Name = "扣分依据13")]
        [StringLength(20)]
        public virtual string DEDBASIS13 { get; set; }

        [Display(Name = "扣分13")]
        [StringLength(20)]
        public virtual string BASIS13 { get; set; }

        [Display(Name = "扣分依据14")]
        [StringLength(20)]
        public virtual string DEDBASIS14 { get; set; }

        [Display(Name = "扣分14")]
        [StringLength(20)]
        public virtual string BASIS14 { get; set; }

        [Display(Name = "扣分15")]
        [StringLength(20)]
        public virtual string DEDBASIS15 { get; set; }

        [Display(Name = "扣分15")]
        [StringLength(20)]
        public virtual string BASIS15 { get; set; }

        [Display(Name = "扣分依据16")]
        [StringLength(20)]
        public virtual string DEDBASIS16 { get; set; }

        [Display(Name = "扣分16")]
        [StringLength(20)]
        public virtual string BASIS16 { get; set; }

        [Display(Name = "扣分依据17")]
        [StringLength(20)]
        public virtual string DEDBASIS17 { get; set; }

        [Display(Name = "扣分17")]
        [StringLength(20)]
        public virtual string BASIS17 { get; set; }

        [Display(Name = "扣分依据18")]
        [StringLength(20)]
        public virtual string DEDBASIS18 { get; set; }

        [Display(Name = "扣分18")]
        [StringLength(20)]
        public virtual string BASIS18 { get; set; }

        [Display(Name = "扣分依据19")]
        [StringLength(20)]
        public virtual string DEDBASIS19 { get; set; }

        [Display(Name = "扣分19")]
        [StringLength(20)]
        public virtual string BASIS19 { get; set; }

        [Display(Name = "扣分依据20")]
        [StringLength(20)]
        public virtual string DEDBASIS20 { get; set; }

        [Display(Name = "扣分20")]
        [StringLength(20)]
        public virtual string BASIS20 { get; set; }

        [Display(Name = "扣分依据21")]
        [StringLength(20)]
        public virtual string DEDBASIS21 { get; set; }

        [Display(Name = "扣分21")]
        [StringLength(20)]
        public virtual string BASIS21 { get; set; }



        [Display(Name = "计算得分")]
        [StringLength(20)]
        public virtual string SUMSCORE { get; set; }


        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        [Display(Name = "新增人员名称")]
        [StringLength(50)]
        public virtual string XZRYMC { get; set; }

        [Display(Name = "新增日期")]
        [StringLength(50)]
        public virtual DateTime? XZRQ { get; set; }

        [Display(Name = "组织机构ID")]
        [StringLength(50)]
        public virtual string ORGANID { get; set; }


        [Display(Name = "感应式或非手触式水龙头")]
        [StringLength(40)]
        public virtual string GYLT { get; set; }

        [Display(Name = "洗手液")]
        [StringLength(40)]
        public virtual string XSY { get; set; }

        [Display(Name = "手消毒液")]
        [StringLength(40)]
        public virtual string SXDY { get; set; }

        [Display(Name = "时钟")]
        [StringLength(40)]
        public virtual string SZ { get; set; }

        [Display(Name = "（擦手纸）")]
        [StringLength(40)]
        public virtual string CSZ { get; set; }

        [Display(Name = "穿洗手衣裤")]
        [StringLength(40)]
        public virtual string XSYK { get; set; }

        [Display(Name = "上衣下摆塞进裤腰")]
        [StringLength(40)]
        public virtual string SJKY { get; set; }

        [Display(Name = "袖管卷至肘上10cm以上")]
        [StringLength(40)]
        public virtual string XGZS { get; set; }


        [Display(Name = "袖口、领口内衣无外漏")]
        [StringLength(40)]
        public virtual string XKLK { get; set; }

        [Display(Name = "去掉戒指及手表")]
        [StringLength(40)]
        public virtual string JZSB { get; set; }

        [Display(Name = "正确佩戴帽子、口罩")]
        [StringLength(40)]
        public virtual string MZKZ { get; set; }

        [Display(Name = "帽子遮住全发，口罩遮住口鼻")]
        [StringLength(40)]
        public virtual string QFKB { get; set; }

        [Display(Name = "鼻夹与鼻相适应")]
        [StringLength(40)]
        public virtual string BXSY { get; set; }

        [Display(Name = "修剪指甲")]
        [StringLength(40)]
        public virtual string XJZJ { get; set; }

        [Display(Name = "前端平甲缘")]
        [StringLength(40)]
        public virtual string PJY { get; set; }

        [Display(Name = "剔除指缝污垢")]
        [StringLength(40)]
        public virtual string TCWG { get; set; }

        [Display(Name = "流水湿润双手、前上臂")]
        [StringLength(40)]
        public virtual string LSSR { get; set; }

        [Display(Name = "取4—5ml皂液均匀涂抹双手至肘上10cm")]
        [StringLength(40)]
        public virtual string ZYJY { get; set; }

        [Display(Name = "（内）掌心相对，手指并拢，相互揉搓")]
        [StringLength(40)]
        public virtual string ZSXC { get; set; }

        [Display(Name = "至少来回10次")]
        [StringLength(40)]
        public virtual string ZSXCS { get; set; }

        [Display(Name = "（外）手心对手背沿指缝相互揉搓")]
        [StringLength(40)]
        public virtual string SSRC { get; set; }

        [Display(Name = "至少来回10次，交换进行")]
        [StringLength(40)]
        public virtual string SSRCS { get; set; }

        [Display(Name = "（夹）掌心相对，双手交叉指缝相互揉搓")]
        [StringLength(40)]
        public virtual string ZXXD { get; set; }

        [Display(Name = "至少来回10次")]
        [StringLength(40)]
        public virtual string ZXXDS { get; set; }

        [Display(Name = "（弓）弯曲手指，使关节在另一手掌心旋转揉搓")]
        [StringLength(40)]
        public virtual string WQSZ { get; set; }

        [Display(Name = "至少来回10次，交换进行")]
        [StringLength(40)]
        public virtual string WQSZS { get; set; }

        [Display(Name = "（大）一手握另一手大拇指旋转揉搓")]
        [StringLength(40)]
        public virtual string XZRC { get; set; }

        [Display(Name = "至少来回10次，交换进行")]
        [StringLength(40)]
        public virtual string XZRCS { get; set; }

        [Display(Name = "（立）将一手五指指尖并拢放在另一手掌心旋转揉搓")]
        [StringLength(40)]
        public virtual string ZXXZ { get; set; }

        [Display(Name = "至少来回10次，交换进行")]
        [StringLength(40)]
        public virtual string ZXXZS { get; set; }

        [Display(Name = "（腕）揉搓手腕")]
        [StringLength(40)]
        public virtual string RCSW { get; set; }

        [Display(Name = "至少来回10次，交换进行")]
        [StringLength(40)]
        public virtual string RCSWS { get; set; }

        [Display(Name = "揉搓整个前臂，两侧在同一平面交替上升不得回搓。")]
        [StringLength(40)]
        public virtual string RCZGQB { get; set; }

        [Display(Name = "揉搓上臂下1/3，两侧在同一平面交替上升不得回搓")]
        [StringLength(40)]
        public virtual string RCSXBS { get; set; }

        [Display(Name = "流动水彻底冲洗，指尖朝上，肘部放低，水由指尖流向肘部，不得倒流。")]
        [StringLength(40)]
        public virtual string LDSCDCX { get; set; }

        [Display(Name = "干手：用擦手纸擦干双手。")]
        [StringLength(40)]
        public virtual string CSZCG { get; set; }

        [Display(Name = "抽取两张擦手纸，擦干一侧手臂。擦手纸沿手臂向肘部及肘上1/3移动。")]
        [StringLength(40)]
        public virtual string YCCGSJ { get; set; }

        [Display(Name = "一手取约2ml外科免洗手消毒液，将另一手指尖置于该掌心消毒液中快速浸润1~2s。")]
        [StringLength(40)]
        public virtual string WKSXD { get; set; }

        [Display(Name = "消毒后双手置于胸前、手臂不得下垂、肘部稍外展，远离自己身体。")]
        [StringLength(40)]
        public virtual string SSYLST { get; set; }
          
    }


    /// <summary>
    ///医院感染风险评分表 业务 BUS_RISKINFECTION 实体类
    /// </summary>
    [Serializable]
    public partial class BUS_RISKINFECTION
    {
        /// <summary>
        /// 感染风险评分表主键
        /// </summary>
        [Display(Name = "感染风险评分表ID")]
        [StringLength(20)]
        public virtual string RISKID { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        [Display(Name = "科室ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }


        /// <summary>
        /// 评估人
        /// </summary>
        [Display(Name = "评估人")]
        [StringLength(20)]
        public virtual string OPNAME { get; set; }

        /// <summary>
        /// 评估日期
        /// </summary>
        [Display(Name = "评估日期")]
        public virtual DateTime? PROCTDATE { get; set; }

        /// <summary>
        /// 总分
        /// </summary>
        [Display(Name = "总分")]
        [StringLength(20)]
        public virtual string SUMSCORE { get; set; }

        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        /// <summary>
        /// 新增人员姓名
        /// </summary>
        [Display(Name = "新增人员姓名")]
        [StringLength(20)]
        public virtual string XZRYMC { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }


        [Display(Name = "组织机构ID")]
        [StringLength(50)]
        public virtual string ORGANID { get; set; }
    }

    /// <summary>
    ///医院感染风险评分数据表 业务 BUS_RISKINFECTION_SOURCE 实体类
    /// </summary>
    [Serializable]
    public partial class BUS_RISKINFECTION_SOURCE
    {
        /// <summary>
        /// 感染风险评分数据表主键
        /// </summary>
        [Display(Name = "感染风险评分数据表ID")]
        [StringLength(20)]
        public virtual string SOURCEID { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Display(Name = "分类名称")]
        [StringLength(20)]
        public virtual string FLMC { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        [StringLength(20)]
        public virtual string NR { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        [Display(Name = "权重")]
        [StringLength(20)]
        public virtual string QZ { get; set; }

        /// <summary>
        /// 发生可能性
        /// </summary>
        [Display(Name = "发生可能性")]
        [StringLength(20)]
        public virtual string KNX { get; set; }

        /// <summary>
        /// 后果损失
        /// </summary>
        [Display(Name = "后果损失")]
        [StringLength(20)]
        public virtual string HGSS { get; set; }

        /// <summary>
        /// 当前体系
        /// </summary>
        [Display(Name = "当前体系")]
        [StringLength(20)]
        public virtual string DQTX { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        [Display(Name = "分值")]
        [StringLength(20)]
        public virtual string FZ { get; set; }


        [Display(Name = "BUS_RISKINFECTION主表ID")]
        [StringLength(50)]
        public virtual string RISKID { get; set; }

        [Display(Name = "组织机构ID")]
        [StringLength(50)]
        public virtual string ORGANID { get; set; }
    }

    /// <summary>
    ///多重耐药菌隔离措施表 业务 BUS_DRUGRESISTQUAR 实体类
    /// </summary>
    [Serializable]
    public partial class BUS_DRUGRESISTQUAR
    {
        /// <summary>
        /// 多重耐药菌隔离措施主表主键
        /// </summary>
        [Display(Name = "多重耐药菌隔离措施主表id")]
        [StringLength(20)]
        public virtual string DCID { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        [Display(Name = "科室ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Display(Name = "科室名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }

        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        /// <summary>
        /// 新增人员名称
        /// </summary>
        [Display(Name = "新增人员名称")]
        [StringLength(20)]
        public virtual string XZRYMC { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }


        /// <summary>
        /// 评估人
        /// </summary>
        [Display(Name = "评估人")]
        [StringLength(20)]
        public virtual string OPNAME { get; set; }

        /// <summary>
        /// 评估日期
        /// </summary>
        [Display(Name = "评估日期")]
        public virtual DateTime? PROCTDATE { get; set; }


        [Display(Name = "组织机构ID")]
        [StringLength(50)]
        public virtual string ORGANID { get; set; }
    }


    /// <summary>
    ///多重耐药菌隔离措施数据表表 业务 BUS_DRUGRESISTQUAR_SOURCE 实体类
    /// </summary>
    [Serializable]
    public partial class BUS_DRUGRESISTQUAR_SOURCE
    {
        /// <summary>
        /// 多重耐药菌隔离措施数据表主键
        /// </summary>
        [Display(Name = "多重耐药菌隔离措施落实情况监督数据表ID")]
        [StringLength(20)]
        public virtual string DRUGID { get; set; }

        /// <summary>
        /// 督察日期
        /// </summary>
        [Display(Name = "督察日期")]
        public virtual DateTime? DCRQ { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [Display(Name = "床号")]
        [StringLength(40)]
        public virtual string JBXX_A { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(40)]
        public virtual string JBXX_B { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        [Display(Name = "病案号")]
        [StringLength(40)]
        public virtual string JBXX_C { get; set; }
        /// <summary>
        /// 标本来源
        /// </summary>
        [Display(Name = "标本来源")]
        [StringLength(40)]
        public virtual string JBXX_D { get; set; }
        /// <summary>
        /// 多重耐药菌名称（英文简称）
        /// </summary>
        [Display(Name = "多重耐药菌名称（英文简称）")]
        [StringLength(40)]
        public virtual string JBXX_E { get; set; }
        /// <summary>
        /// 主管医生
        /// </summary>
        [Display(Name = "主管医生")]
        [StringLength(40)]
        public virtual string JBXX_F { get; set; }
        /// <summary>
        /// 隔离医嘱(有/无)
        /// </summary>
        [Display(Name = "隔离医嘱(有/无)")]
        [StringLength(40)]
        public virtual string GLYZ { get; set; }
        /// <summary>
        /// 单间隔离
        /// </summary>
        [Display(Name = "单间隔离")]
        [StringLength(40)]
        public virtual string BRAZ_A { get; set; }
        /// <summary>
        /// 同种病原病人同室或同区域
        /// </summary>
        [Display(Name = "同种病原病人同室或同区域")]
        [StringLength(40)]
        public virtual string BRAZ_B { get; set; }
        /// <summary>
        /// 同房间病人为低免疫或有插管
        /// </summary>
        [Display(Name = "同房间病人为低免疫或有插管")]
        [StringLength(40)]
        public virtual string BRAZ_C { get; set; }


        /// <summary>
        /// 病历卡上蓝色隔离标识
        /// </summary>
        [Display(Name = "病历卡上蓝色隔离标识")]
        [StringLength(40)]
        public virtual string GLBS_A { get; set; }

        /// <summary>
        /// 手腕带上蓝色隔离标识
        /// </summary>
        [Display(Name = "手腕带上蓝色隔离标识")]
        [StringLength(40)]
        public virtual string GLBS_B { get; set; }
        /// <summary>
        /// 病人床边蓝色隔离标牌
        /// </summary>
        [Display(Name = "病人床边蓝色隔离标牌")]
        [StringLength(40)]
        public virtual string GLBS_C { get; set; }


        /// <summary>
        /// 床旁备快速手消净(有/无)
        /// </summary>
        [Display(Name = "床旁备快速手消净(有/无)")]
        [StringLength(40)]
        public virtual string GLCS_A { get; set; }
        /// <summary>
        /// 床旁备快速手消净(是否在效期内)
        /// </summary>
        [Display(Name = "床旁备快速手消净(是否在效期内)")]
        [StringLength(40)]
        public virtual string GLCS_B { get; set; }
        /// <summary>
        /// 床边黄色垃圾桶
        /// </summary>
        [Display(Name = "床边黄色垃圾桶")]
        [StringLength(40)]
        public virtual string GLCS_C { get; set; }
        /// <summary>
        /// 织物双层黄色袋装盛
        /// </summary>
        [Display(Name = "织物双层黄色袋装盛")]
        [StringLength(40)]
        public virtual string GLCS_D { get; set; }
        /// <summary>
        /// 床旁备个人防护用品
        /// </summary>
        [Display(Name = "床旁备个人防护用品")]
        [StringLength(40)]
        public virtual string GLCS_E { get; set; }
        /// <summary>
        /// 个人用品专人专用定点存放
        /// </summary>
        [Display(Name = "个人用品专人专用定点存放")]
        [StringLength(40)]
        public virtual string GLCS_F { get; set; }
        /// <summary>
        /// 医疗设备专人专用
        /// </summary>
        [Display(Name = "医疗设备专人专用")]
        [StringLength(40)]
        public virtual string GLCS_G { get; set; }


        /// <summary>
        /// 病人周围环境每日消毒≥2次
        /// </summary>
        [Display(Name = "病人周围环境每日消毒≥2次")]
        [StringLength(40)]
        public virtual string HJQJXD_A { get; set; }
        /// <summary>
        /// 公用设备用后消毒
        /// </summary>
        [Display(Name = "公用设备用后消毒")]
        [StringLength(40)]
        public virtual string HJQJXD_B { get; set; }
        /// <summary>
        /// 转诊或外出检查前通知接诊科室
        /// </summary>
        [Display(Name = "转诊或外出检查前通知接诊科室")]
        [StringLength(40)]
        public virtual string HJQJXD_C { get; set; }
        /// <summary>
        /// 终末消毒规范、彻底
        /// </summary>
        [Display(Name = "终末消毒规范、彻底")]
        [StringLength(40)]
        public virtual string HJQJXD_D { get; set; }


        /// <summary>
        /// 对保洁工人宣教/交接
        /// </summary>
        [Display(Name = "对保洁工人宣教/交接")]
        [StringLength(40)]
        public virtual string TBXJ_A { get; set; }

        /// <summary>
        /// 对病人及家属宣教
        /// </summary>
        [Display(Name = "对病人及家属宣教")]
        [StringLength(40)]
        public virtual string TBXJ_B { get; set; }


        /// <summary>
        /// 管床人员_手卫生执行次数
        /// </summary>
        [Display(Name = "管床人员_手卫生执行次数")]
        [StringLength(40)]
        public virtual string SWS_A { get; set; }
        /// <summary>
        /// 管床人员_手卫生总时机数
        /// </summary>
        [Display(Name = "管床人员_手卫生总时机数")]
        [StringLength(40)]
        public virtual string SWS_B { get; set; }
        /// <summary>
        /// 家属陪护_手卫生执行次数
        /// </summary>
        [Display(Name = "家属陪护_手卫生执行次数")]
        [StringLength(40)]
        public virtual string SWS_C { get; set; }
        /// <summary>
        /// 家属陪护_手卫生总时机数
        /// </summary>
        [Display(Name = "家属陪护_手卫生总时机数")]
        [StringLength(40)]
        public virtual string SWS_D { get; set; }
        /// <summary>
        /// 会诊人员_手卫生执行次数
        /// </summary>
        [Display(Name = "会诊人员_手卫生执行次数")]
        [StringLength(40)]
        public virtual string SWS_E { get; set; }
        /// <summary>
        /// 会诊人员_手卫生总时机数
        /// </summary>
        [Display(Name = "会诊人员_手卫生总时机数")]
        [StringLength(40)]
        public virtual string SWS_F { get; set; }
        /// <summary>
        /// 督查人
        /// </summary>
        [Display(Name = "督查人")]
        [StringLength(40)]
        public virtual string DCR { get; set; }
        /// <summary>
        /// 督察表主键
        /// </summary>
        [Display(Name = "督察表主键")]
        [StringLength(40)]
        public virtual string DCID { get; set; }
        /// <summary>
        /// 组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
    }

    /// <summary>
    ///环境检测表 业务 BUS_ENVIRONMENTTEST 实体类
    /// </summary>
    [Serializable]
    public partial class BUS_ENVIRONMENTTEST
    {
        /// <summary>
        /// 环境检测表zhu'jian
        /// </summary>
        [Display(Name = "环境检测表ID")]
        [StringLength(20)]
        public virtual string ENVID { get; set; }

        /// <summary>
        /// 上报科室ID
        /// </summary>
        [Display(Name = "上报科室ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }

        /// <summary>
        /// 上报科室名称
        /// </summary>
        [Display(Name = "上报科室名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }

        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        /// <summary>
        /// 新增人员名称
        /// </summary>
        [Display(Name = "新增人员名称")]
        [StringLength(20)]
        public virtual string XZRYMC { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }

        /// <summary>
        /// 送检日期
        /// </summary>
        [Display(Name = "送检日期")]
        public virtual DateTime? SJDATE { get; set; }

        /// <summary>
        /// 送检人
        /// </summary>
        [Display(Name = "送检人")]
        [StringLength(20)]
        public virtual string SJREN { get; set; }

        /// <summary>
        /// 检验者
        /// </summary>
        [Display(Name = "检验者")]
        [StringLength(20)]
        public virtual string JYZ { get; set; }

        /// <summary>
        /// 报告日期
        /// </summary>
        [Display(Name = "报告日期")]
        public virtual DateTime? BGDATE { get; set; }
    }

    /// <summary>
    ///环境检测表 业务 BUS_ENVIRONMENTTEST_SOURCE 数据实体类
    /// </summary>
    [Serializable]
    public partial class BUS_ENVIRONMENTTEST_SOURCE
    {
        /// <summary>
        /// 环境检测数据表主键
        /// </summary>
        [Display(Name = "环境检测数据表主键")]
        [StringLength(20)]
        public virtual string ENSID { get; set; }

        /// <summary>
        /// 申请单编号
        /// </summary>
        [Display(Name = "申请单编号")]
        [StringLength(40)]
        public virtual string SQDBH { get; set; }

        /// <summary>
        /// 申请单分类
        /// </summary>
        [Display(Name = "申请单分类")]
        [StringLength(40)]
        public virtual string SQDFL { get; set; }

        /// <summary>
        /// 申请科室名称
        /// </summary>
        [Display(Name = "申请科室名称")]
        [StringLength(40)]
        public virtual string SQKSNAME { get; set; }

        /// <summary>
        /// 标本
        /// </summary>
        [Display(Name = "标本")]
        [StringLength(40)]
        public virtual string BB { get; set; }

        /// <summary>
        /// 细菌数量
        /// </summary>
        [Display(Name = "细菌数量")]
        [StringLength(40)]
        public virtual string XJSL { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [Display(Name = "结果")]
        [StringLength(40)]
        public virtual string JG { get; set; }

        /// <summary>
        /// 合格
        /// </summary>
        [Display(Name = "合格")]
        [StringLength(40)]
        public virtual string HG { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(200)]
        public virtual string BZ { get; set; }

        /// <summary>
        /// 环境检测主表ID
        /// </summary>
        [Display(Name = "环境检测主表ID")]
        [StringLength(200)]
        public virtual string ENVID { get; set; }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
    }

    /// <summary>
    ///手卫生依从性及正确性现场调查表 业务 BUS_HANDHYGIENE 数据实体类
    /// </summary>
    [Serializable]
    public partial class BUS_HANDHYGIENE
    {
        /// <summary>
        /// 手卫生依从性及正确性现场调查表ID
        /// </summary>
        [Display(Name = "手卫生依从性及正确性现场调查表ID")]
        [StringLength(20)]
        public virtual string HANDID { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Display(Name = "部门ID")]
        [StringLength(20)]
        public virtual string DEPTID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Display(Name = "部门名称")]
        [StringLength(20)]
        public virtual string DEPTNAME { get; set; }

        /// <summary>
        /// 调查日期
        /// </summary>
        [Display(Name = "调查日期")]
        public virtual DateTime? DCDATE { get; set; }

        /// <summary>
        /// 新增人员ID
        /// </summary>
        [Display(Name = "新增人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }

        /// <summary>
        /// 新增人员名称
        /// </summary>
        [Display(Name = "新增人员名称")]
        [StringLength(20)]
        public virtual string XZRYMC { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public virtual DateTime? XZRQ { get; set; }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }


        /// <summary>
        /// 表名称：手卫生依从性及正确性现场调查表  列表展示用
        /// </summary>
        [Display(Name = "表名称：手卫生依从性及正确性现场调查表  列表展示用")]
        [StringLength(40)]
        public virtual string BMC { get; set; }

    }

    /// <summary>
    ///手卫生依从性及正确性现场调查表数据 业务 BUS_HANDHYGIENE_SOURCE 数据实体类
    /// </summary>
    [Serializable]
    public partial class BUS_HANDHYGIENE_SOURCE
    {    /// <summary>
         /// 主键ID
         /// </summary>
        [Display(Name = "主键ID")]
        [StringLength(20)]
        public virtual string HANDSID { get; set; }
         
        /// <summary>
        /// 时间段开始
        /// </summary>
        [Display(Name = "时间段开始")]
        public virtual DateTime? SJDONE { get; set; }

        /// <summary>
        /// 时间段结束
        /// </summary>
        [Display(Name = "时间段结束")]
        public virtual DateTime? SJDTWO { get; set; }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
         
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20)]
        public virtual string XM { get; set; }

        /// <summary>
        /// 职业：护士，医生，医技，工人
        /// </summary>
        [Display(Name = "职业：护士，医生，医技，工人")]
        [StringLength(20)]
        public virtual string ZY { get; set; }
         
        /// <summary>
        /// 单选：接触病人前
        /// </summary>
        [Display(Name = "单选：接触病人前")]
        [StringLength(20)]
        public virtual string JCBRQ { get; set; }

        /// <summary>
        /// 单选：接触病人后
        /// </summary>
        [Display(Name = "单选：接触病人后")]
        [StringLength(20)]
        public virtual string JCBRH { get; set; }

        /// <summary>
        /// 单选：接触无菌物品前
        /// </summary>
        [Display(Name = "单选：接触无菌物品前")]
        [StringLength(20)]
        public virtual string JCWJWPQ { get; set; }

        /// <summary>
        /// 单选：接触病人周围环境后
        /// </summary>
        [Display(Name = "单选：接触病人周围环境后")]
        [StringLength(20)]
        public virtual string JCBRHJH { get; set; }

        /// <summary>
        /// 单选：接触污物后
        /// </summary>
        [Display(Name = "单选：接触污物后")]
        [StringLength(20)]
        public virtual string JCWWH { get; set; }

        /// <summary>
        /// 单选：配餐前
        /// </summary>
        [Display(Name = "单选：配餐前")]
        [StringLength(20)]
        public virtual string PCQ { get; set; }
         
        /// <summary>
        /// 主表ID
        /// </summary>
        [Display(Name = "主表ID")]
        [StringLength(20)]
        public virtual string HANDID { get; set; }

        /// <summary>
        /// 调查者
        /// </summary>
        [Display(Name = "调查者")]
        [StringLength(20)]
        public virtual string DCZ { get; set; }
    }

}

