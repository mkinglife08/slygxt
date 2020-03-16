using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_HospitalPhysicalRxam 体格检查
	/// </summary>
    public class CD_HOSPITALPHYSICALRXAM
    {

        /// <summary>
 	    /// (索引)(主键)体格检查id
	    /// </summary>
		public string PHYSICALEXAMID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 体温
	    /// </summary>
		public decimal? DEGREE{ get; set; }

        /// <summary>
 	    /// 脉搏
	    /// </summary>
		public string PULSE{ get; set; }

        /// <summary>
 	    /// 呼吸
	    /// </summary>
		public string BREATHE{ get; set; }

        /// <summary>
 	    /// 舒张压
	    /// </summary>
		public string DIASTOLICPRESSURE{ get; set; }

        /// <summary>
 	    /// 收缩压
	    /// </summary>
		public string SYSTOLICPRESSURE{ get; set; }

        /// <summary>
 	    /// 身高
	    /// </summary>
		public string HEIGHT{ get; set; }

        /// <summary>
 	    /// 体重
	    /// </summary>
		public string WEIGHT{ get; set; }

        /// <summary>
 	    /// 发育
	    /// </summary>
		public string GROWTH{ get; set; }

        /// <summary>
 	    /// 营养
	    /// </summary>
		public string NUTRITION{ get; set; }

        /// <summary>
 	    /// 意识
	    /// </summary>
		public string CONSCIOUS{ get; set; }

        /// <summary>
 	    /// 病容
	    /// </summary>
		public string SICKLYLOOK{ get; set; }

        /// <summary>
 	    /// 合作
	    /// </summary>
		public string COOPERATION{ get; set; }

        /// <summary>
 	    /// 神智
	    /// </summary>
		public string MIND{ get; set; }

        /// <summary>
 	    /// 呼吸频率
	    /// </summary>
		public string BREATHING{ get; set; }

        /// <summary>
 	    /// 面容
	    /// </summary>
		public string FACE{ get; set; }

        /// <summary>
 	    /// 表情
	    /// </summary>
		public string EXPRESSION{ get; set; }

        /// <summary>
 	    /// 体位
	    /// </summary>
		public string POSITION{ get; set; }

        /// <summary>
 	    /// 步态
	    /// </summary>
		public string TREAD{ get; set; }

        /// <summary>
 	    /// 配合检查
	    /// </summary>
		public string COOPERATE{ get; set; }

        /// <summary>
 	    /// 皮肤苍白
	    /// </summary>
		public string SKINPALE{ get; set; }

        /// <summary>
 	    /// 皮肤潮红
	    /// </summary>
		public string SKINFLUSH{ get; set; }

        /// <summary>
 	    /// 面颊潮红
	    /// </summary>
		public string FACEFLUSH{ get; set; }

        /// <summary>
 	    /// 皮肤黄色
	    /// </summary>
		public string SKINYELLOW{ get; set; }

        /// <summary>
 	    /// 皮疹
	    /// </summary>
		public string RASH{ get; set; }

        /// <summary>
 	    /// 紫癍
	    /// </summary>
		public string PURPLEMACULA{ get; set; }

        /// <summary>
 	    /// 水肿
	    /// </summary>
		public string EDEMA{ get; set; }

        /// <summary>
 	    /// 脱水现象
	    /// </summary>
		public string DEHYDRATION{ get; set; }

        /// <summary>
 	    /// 松紧度
	    /// </summary>
		public string TIGHTNESS{ get; set; }

        /// <summary>
 	    /// 皮肤温度
	    /// </summary>
		public string SKINDEGREE{ get; set; }

        /// <summary>
 	    /// 出汗
	    /// </summary>
		public string SWEAT{ get; set; }

        /// <summary>
 	    /// 瘢痕
	    /// </summary>
		public string SCAR{ get; set; }

        /// <summary>
 	    /// 皮肤感染
	    /// </summary>
		public string SKININFACTION{ get; set; }

        /// <summary>
 	    /// 色泽
	    /// </summary>
		public string COLOR{ get; set; }

        /// <summary>
 	    /// 出血
	    /// </summary>
		public string BLEEDING{ get; set; }

        /// <summary>
 	    /// 头颅大小
	    /// </summary>
		public string HEADSIZE{ get; set; }

        /// <summary>
 	    /// 头颅畸形
	    /// </summary>
		public string HEADABNORMAL{ get; set; }

        /// <summary>
 	    /// 头颅包块
	    /// </summary>
		public string HEADMASS{ get; set; }

        /// <summary>
 	    /// 头颅压痛
	    /// </summary>
		public string HEADTENDERNESS{ get; set; }

        /// <summary>
 	    /// 头颅凹陷
	    /// </summary>
		public string HEADDENT{ get; set; }

        /// <summary>
 	    /// 头部外形
	    /// </summary>
		public string HEADSHAPE{ get; set; }

        /// <summary>
 	    /// 眼睑
	    /// </summary>
		public string EYELID{ get; set; }

        /// <summary>
 	    /// 结膜
	    /// </summary>
		public string CONJUNCTIVA{ get; set; }

        /// <summary>
 	    /// 巩膜
	    /// </summary>
		public string SCLERA{ get; set; }

        /// <summary>
 	    /// 左眼象限运动
	    /// </summary>
		public string LEFTEYEACTIVITY{ get; set; }

        /// <summary>
 	    /// 右眼象限运动
	    /// </summary>
		public string RIGHTEYEACTIVITY{ get; set; }

        /// <summary>
 	    /// 左眼外形
	    /// </summary>
		public string LEFTEYESHAPE{ get; set; }

        /// <summary>
 	    /// 右眼外形
	    /// </summary>
		public string RIGHTEYESHAPE{ get; set; }

        /// <summary>
 	    /// 角膜
	    /// </summary>
		public string CONEA{ get; set; }

        /// <summary>
 	    /// 瞳孔
	    /// </summary>
		public string PUPIL{ get; set; }

        /// <summary>
 	    /// 左眼对光反射
	    /// </summary>
		public string LEFTEYEREFLEX{ get; set; }

        /// <summary>
 	    /// 右眼对光反射
	    /// </summary>
		public string RIGHTEYEREFLEX{ get; set; }

        /// <summary>
 	    /// 鼻外形
	    /// </summary>
		public string NOSESHAPE{ get; set; }

        /// <summary>
 	    /// 鼻其他异常
	    /// </summary>
		public string NOSEOTHER{ get; set; }

        /// <summary>
 	    /// 副鼻窦压痛
	    /// </summary>
		public string PARANASALSINUSTENDERNESS{ get; set; }

        /// <summary>
 	    /// 鼻通气
	    /// </summary>
		public string NASALVENTILATION{ get; set; }

        /// <summary>
 	    /// 唇
	    /// </summary>
		public string LIP{ get; set; }

        /// <summary>
 	    /// 口腔黏膜
	    /// </summary>
		public string ORALMUCOSA{ get; set; }

        /// <summary>
 	    /// 腮腺导管开口
	    /// </summary>
		public string PAROTID{ get; set; }

        /// <summary>
 	    /// 舌
	    /// </summary>
		public string TONGUE{ get; set; }

        /// <summary>
 	    /// 牙龈
	    /// </summary>
		public string GUM{ get; set; }

        /// <summary>
 	    /// 龋齿
	    /// </summary>
		public string DECAYEDTOOTH{ get; set; }

        /// <summary>
 	    /// 扁桃体
	    /// </summary>
		public string TONSIL{ get; set; }

        /// <summary>
 	    /// 咽
	    /// </summary>
		public string PHARYNX{ get; set; }

        /// <summary>
 	    /// 声音
	    /// </summary>
		public string VOICE{ get; set; }

        /// <summary>
 	    /// 淋巴结
	    /// </summary>
		public string LYMPHNODE{ get; set; }

        /// <summary>
 	    /// 颈部抵抗感
	    /// </summary>
		public string NECKENDPOINT{ get; set; }

        /// <summary>
 	    /// 颈动脉
	    /// </summary>
		public string NECKARTERY{ get; set; }

        /// <summary>
 	    /// 颈静脉
	    /// </summary>
		public string JUGULARVEIN{ get; set; }

        /// <summary>
 	    /// 气管位置
	    /// </summary>
		public string TRACHEALPOSITION{ get; set; }

        /// <summary>
 	    /// 颈静脉回流征
	    /// </summary>
		public string NECKVEINREFLUX{ get; set; }

        /// <summary>
 	    /// 甲状腺
	    /// </summary>
		public string THYROID{ get; set; }

        /// <summary>
 	    /// 胸部外形
	    /// </summary>
		public string CHESTSHAPE{ get; set; }

        /// <summary>
 	    /// 胸廓
	    /// </summary>
		public string THORAX{ get; set; }

        /// <summary>
 	    /// 乳房
	    /// </summary>
		public string BREAST{ get; set; }

        /// <summary>
 	    /// 乳突压痛
	    /// </summary>
		public string MASTOIDTENDERNESS{ get; set; }

        /// <summary>
 	    /// 呼吸运动
	    /// </summary>
		public string BREATHINGMOVEMENT{ get; set; }

        /// <summary>
 	    /// 语颤
	    /// </summary>
		public string VF{ get; set; }

        /// <summary>
 	    /// 胸膜摩擦感
	    /// </summary>
		public string PLEURAFRICTION{ get; set; }

        /// <summary>
 	    /// 叩诊音
	    /// </summary>
		public string PERCUSSIONSOUND{ get; set; }

        /// <summary>
 	    /// 肺下界活动度
	    /// </summary>
		public string LUNGSLBACTIVITY{ get; set; }

        /// <summary>
 	    /// 呼吸节奏
	    /// </summary>
		public string BREATHINGRHYTHM{ get; set; }

        /// <summary>
 	    /// 双肺呼吸音
	    /// </summary>
		public string BREATHINGSOUND{ get; set; }

        /// <summary>
 	    /// 语音传导
	    /// </summary>
		public string VOICECONDUCATION{ get; set; }

        /// <summary>
 	    /// 啰音
	    /// </summary>
		public string RALES{ get; set; }

        /// <summary>
 	    /// 胸膜摩擦音
	    /// </summary>
		public string PLEURAFRICTIONSONDS{ get; set; }

        /// <summary>
 	    /// 心尖搏动弥散
	    /// </summary>
		public string APICALPULSEDISPERSION{ get; set; }

        /// <summary>
 	    /// 其他位置移动
	    /// </summary>
		public string OTHERPOSITIONMOVE{ get; set; }

        /// <summary>
 	    /// 心尖搏动位置
	    /// </summary>
		public string APICALPULSEPOSITION{ get; set; }

        /// <summary>
 	    /// 心尖搏动
	    /// </summary>
		public string APICALPULSE{ get; set; }

        /// <summary>
 	    /// 振颤
	    /// </summary>
		public string FLAPPING{ get; set; }

        /// <summary>
 	    /// 心包摩檫感
	    /// </summary>
		public string PERICARDIUMFRICTION{ get; set; }

        /// <summary>
 	    /// 心浊音界
	    /// </summary>
		public string HEARTDULNESSAREA{ get; set; }

        /// <summary>
 	    /// 肝脏
	    /// </summary>
		public string LIVER{ get; set; }

        /// <summary>
 	    /// 心率
	    /// </summary>
		public string HEARTRATE{ get; set; }

        /// <summary>
 	    /// 心律
	    /// </summary>
		public string HEARTRHYTHM{ get; set; }

        /// <summary>
 	    /// 锁骨中线距前中线
	    /// </summary>
		public string CLAVICALFRONTLENGTH{ get; set; }

        /// <summary>
 	    /// 心音
	    /// </summary>
		public string HEARTSOUNDS{ get; set; }

        /// <summary>
 	    /// 额外心音
	    /// </summary>
		public string OTHERHEARTSOUNDS{ get; set; }

        /// <summary>
 	    /// 杂音
	    /// </summary>
		public string NOISE{ get; set; }

        /// <summary>
 	    /// 心包摩擦音
	    /// </summary>
		public string PERICARDIUMFRICTIONSOUNDS{ get; set; }

        /// <summary>
 	    /// 异常血管征
	    /// </summary>
		public string ABNORMALVESSELSIGN{ get; set; }

        /// <summary>
 	    /// 腹部外形
	    /// </summary>
		public string ABDOMINALSHAPE{ get; set; }

        /// <summary>
 	    /// 腹式呼吸
	    /// </summary>
		public string ABDOMINALBREATHING{ get; set; }

        /// <summary>
 	    /// 脐
	    /// </summary>
		public string NAVEL{ get; set; }

        /// <summary>
 	    /// 腹部其他异常
	    /// </summary>
		public string ABDOMINALOTHERABNORMAL{ get; set; }

        /// <summary>
 	    /// 腹壁紧张度
	    /// </summary>
		public string ABDOMINALWALLTENSION{ get; set; }

        /// <summary>
 	    /// 压痛
	    /// </summary>
		public string TENDERNESS{ get; set; }

        /// <summary>
 	    /// 反跳痛
	    /// </summary>
		public string REBOUNDTENDERNESS{ get; set; }

        /// <summary>
 	    /// 液波振颤
	    /// </summary>
		public string FLUIDWAVEFLAPPING{ get; set; }

        /// <summary>
 	    /// 振水声
	    /// </summary>
		public string FLAPPINGWATERSOUNDS{ get; set; }

        /// <summary>
 	    /// 周围血管征
	    /// </summary>
		public string PERIPHERALVASCULARSIGN{ get; set; }

        /// <summary>
 	    /// 胆囊
	    /// </summary>
		public string GALLBLADDER{ get; set; }

        /// <summary>
 	    /// Murphy征
	    /// </summary>
		public string MURPHY{ get; set; }

        /// <summary>
 	    /// 脾脏
	    /// </summary>
		public string SPLEEN{ get; set; }

        /// <summary>
 	    /// 肝浊音界
	    /// </summary>
		public string LIVERDULNESSAREA{ get; set; }

        /// <summary>
 	    /// 肠鸣音
	    /// </summary>
		public string BOWELSOUNDS{ get; set; }

        /// <summary>
 	    /// 肠鸣音频率
	    /// </summary>
		public string BOWELSOUNDSFREQUENCY{ get; set; }

        /// <summary>
 	    /// 气过水音
	    /// </summary>
		public string AIRPATHWATERSOUNDS{ get; set; }

        /// <summary>
 	    /// 血管杂音
	    /// </summary>
		public string VESSELOTHERSOUNDS{ get; set; }

        /// <summary>
 	    /// 肛门直肠
	    /// </summary>
		public string RECTUMANUS{ get; set; }

        /// <summary>
 	    /// 生殖器
	    /// </summary>
		public string GENITALS{ get; set; }

        /// <summary>
 	    /// 脊柱
	    /// </summary>
		public string SPINE{ get; set; }

        /// <summary>
 	    /// 压痛叩痛
	    /// </summary>
		public string PRESSPERCUSSPAIN{ get; set; }

        /// <summary>
 	    /// 活动度
	    /// </summary>
		public string ACTIVITY{ get; set; }

        /// <summary>
 	    /// 四肢
	    /// </summary>
		public string LIMBS{ get; set; }

        /// <summary>
 	    /// 杵状指趾
	    /// </summary>
		public string CLUBBEDFINGER{ get; set; }

        /// <summary>
 	    /// 腹壁反射
	    /// </summary>
		public string NAPESREFLEX{ get; set; }

        /// <summary>
 	    /// 肌张力
	    /// </summary>
		public string MUSCLETENSION{ get; set; }

        /// <summary>
 	    /// 四肢肌力
	    /// </summary>
		public string LIMBMUSCLESTRENGTH{ get; set; }

        /// <summary>
 	    /// 肢体瘫痪
	    /// </summary>
		public string LIMBPARALYSIS{ get; set; }

        /// <summary>
 	    /// 肱二头肌反射
	    /// </summary>
		public string BICEPSREFLEX{ get; set; }

        /// <summary>
 	    /// Hoffman征
	    /// </summary>
		public string HOFFMAN{ get; set; }

        /// <summary>
 	    /// 跟腱反射
	    /// </summary>
		public string ACHILLESTENDOREFLEX{ get; set; }

        /// <summary>
 	    /// Babinski征
	    /// </summary>
		public string BABINSHISSIGN{ get; set; }

        /// <summary>
 	    /// 膝腱反射
	    /// </summary>
		public string KNEETENDONREFLEX{ get; set; }

        /// <summary>
 	    /// Kernig征
	    /// </summary>
		public string KERNIG{ get; set; }

        /// <summary>
 	    /// 软硬度
	    /// </summary>
		public string SOFTNESS{ get; set; }

        /// <summary>
 	    /// 肋间隙
	    /// </summary>
		public string RIBGAP{ get; set; }

        /// <summary>
 	    /// 蠕动波
	    /// </summary>
		public string PERISTALTICWAVE{ get; set; }

        /// <summary>
 	    /// 肾区叩痛
	    /// </summary>
		public string KIDNEYAREAPERCUSSIONPAIN{ get; set; }

        /// <summary>
 	    /// 移动性浊音
	    /// </summary>
		public string MOBILEDULLNESS{ get; set; }

        /// <summary>
 	    /// 浅表淋巴结
	    /// </summary>
		public string SUPERFICIALLYMPHNODES{ get; set; }

        /// <summary>
 	    /// 听力粗测
	    /// </summary>
		public string LISTENINGROUGHTEST{ get; set; }

        /// <summary>
 	    /// 外生殖器
	    /// </summary>
		public string EXTERNALGENITALIA{ get; set; }

        /// <summary>
 	    /// 其他
	    /// </summary>
		public string OTHER{ get; set; }

        /// <summary>
 	    /// 修改历史
	    /// </summary>
		public decimal? CHANGEHISTORY{ get; set; }

        /// <summary>
 	    /// 体格图片编辑
	    /// </summary>
		public string TGIMGSRC{ get; set; }

        /// <summary>
 	    /// 心肺图片编辑
	    /// </summary>
		public string XFIMGSRC{ get; set; }

        /// <summary>
 	    /// 创建用户ID
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 用户创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 修改用户ID
	    /// </summary>
		public string UPDATER{ get; set; }

        /// <summary>
 	    /// 用户修改时间
	    /// </summary>
		public DateTime? UPDATETIME{ get; set; }
      
    }
}