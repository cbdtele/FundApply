using System;
using Cydb.Common.Helper;

namespace Cydb.Repository.Entity {
    /// <summary>
    /// 时间下拉框控制模型
    /// </summary>
    public class TtimeEntity {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int BEGINTIME { set; get; }
        /// <summary>
        /// 截至时间
        /// </summary>
        public int ENDTIME { set; get; }
        /// <summary>
        /// 经济指标 名称
        /// </summary>
        public string ECO_TYPE { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string DESCRPTION { set; get; }
        /// <summary>
        /// 0无1月  1有1月
        /// </summary>
        public int FLAG_JANUARY { set; get; }
        /// <summary>
        /// 不包含的时间
        /// </summary>
        public string FLAG_DEC { set; get; }
        /// <summary>
        /// 生成类型 1普通 2累计 3年度生成
        /// </summary>
        public int TIMEBUILDTYPE { set; get; }

        /// <summary>
        /// 显示那些月份，默认1-12月
        /// </summary>
        public string SHOWTIME { set; private get; }
        public int[] GetShowTime() {
            var showStrTime = SHOWTIME.Split(',');
            var showTime = Array.ConvertAll(showStrTime, Conv.ToInt);
            return showTime;
        }

        /// <summary>
        /// 拥有多少个下拉框，默认为1
        /// </summary>
        public int CONTROLENUM { set; private get; }
        public int GetControleNum() {
            return CONTROLENUM != 0 ? CONTROLENUM : 1;
        }

        /// <summary>
        /// 分隔符，默认为‘至’
        /// </summary>
        public string SplitChar { set; private get; }
        public string GetSplitChar() {
            return string.IsNullOrWhiteSpace(SplitChar) ? "至" : SplitChar;
        }
    }
}
