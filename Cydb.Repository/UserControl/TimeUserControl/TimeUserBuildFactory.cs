using System;
using Cydb.Repository.Entity;
using Cydb.Repository.UserControl.TimeUserControl.BaseTime;

namespace Cydb.Repository.UserControl.TimeUserControl {
    public enum BuildType {
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 累计
        /// </summary>
        Cumulative = 2,
        /// <summary>
        /// 年份
        /// </summary>
        Year = 3,
        /// <summary>
        /// 季度
        /// </summary>
        Quarter = 4,
        /// <summary>
        /// 特殊的固定资产
        /// </summary>
        NormalByGdzc = 5,
        /// <summary>
        /// 特殊的批零
        /// </summary>
        NormalByPl = 6
    }

    /// <summary>
    /// 生成构造工厂
    /// </summary>
    public class TimeUserBuildFactory {
        readonly ITimeUserBuild _iTimeUserBuild;
        /// <summary>
        /// 生成构造工厂
        /// </summary>
        /// <param name="ttimeEntity"></param>
        public TimeUserBuildFactory(TtimeEntity ttimeEntity) {
            switch ((BuildType)ttimeEntity.TIMEBUILDTYPE) {
                case BuildType.Normal:
                    _iTimeUserBuild = new TimeUserBuildNormal();
                    break;
                case BuildType.NormalByGdzc:
                    _iTimeUserBuild = new TimeUserBuildNormalByGdzc();
                    break;
                case BuildType.NormalByPl:
                    _iTimeUserBuild = new TimeUserBuildNormalByPl();
                    break;
                case BuildType.Cumulative:
                    _iTimeUserBuild = new TimeUserBuildCumulative();
                    break;
                case BuildType.Year:
                    _iTimeUserBuild = new TimeUserBuildYear();
                    break;
                case BuildType.Quarter:
                    _iTimeUserBuild = new TimeUserBuildQuarter();
                    break;
                default:
                    throw new Exception("接收到未知生成类型,TIMEBUILDTYPE=" + ttimeEntity.TIMEBUILDTYPE);
            }
        }

        public ITimeUserBuild GetBuildType() {
            return _iTimeUserBuild;
        }
    }
}
