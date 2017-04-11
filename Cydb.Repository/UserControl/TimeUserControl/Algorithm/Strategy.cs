using Dapper;
using System.Linq;
using System.Collections.Generic;
using Cydb.Common.Helper;
using Cydb.Repository.Base;
using Cydb.Repository.Entity;
using Cydb.Repository.UserControl.TimeUserControl.BaseTime;

namespace Cydb.Repository.UserControl.TimeUserControl.Algorithm {
    /// <summary>
    /// 基础策略
    /// </summary>
    public abstract class Strategy {
        /// <summary>
        /// 配置实体
        /// </summary>
        protected TtimeEntity ttimeEntity { set; get; }

        protected Strategy(TtimeEntity entity) {
            if (string.IsNullOrWhiteSpace(entity.ECO_TYPE)) {
                ttimeEntity = entity;
            }
            else {
                using (var conn = new DbBase().DbConnecttion) {
                    ttimeEntity = conn.Query<TtimeEntity>($@" select * from t_time where eco_type='{entity.ECO_TYPE.ToUpper()}' ").SingleOrDefault();
                }
            }

            if (ttimeEntity == null) return;
            ttimeEntity.SplitChar = entity.GetSplitChar();
        }

        /// <summary>
        /// 基础算法接口
        /// </summary>
        public virtual List<List<TtimeEntityOut>> AlgorithmInterface() {
            var controleNum = ttimeEntity.GetControleNum();
            var controleList = new List<List<TtimeEntityOut>>();
            for (int i = 0; i < controleNum; i++) {
                controleList.Add(BuildControl(new TimeUserBuildFactory(ttimeEntity).GetBuildType()));
            }

            if (controleNum == 1) {
                //单个下拉框配置默认选中配置
                controleList[0][controleList[0].FindIndex(t => t.Value.Equals(ttimeEntity.ENDTIME.ToString()))].IsChecked = true;
            }
            else {
                //两个下拉框配置默认选中配置
                var selectedTimeFirst = TimeHelper.GetYear(ttimeEntity.ENDTIME)
                                        + TimeHelper.ComplementZero(Conv.ToInt(ttimeEntity.GetShowTime().Min()));
                var selectedTimeSecond = ttimeEntity.ENDTIME.ToString();
                controleList[0][controleList[0].FindIndex(t => t.Value.Equals(selectedTimeFirst))].IsChecked = true;
                controleList[1][controleList[1].FindIndex(t => t.Value.Equals(selectedTimeSecond))].IsChecked = true;
            }
            return controleList;
        }

        public List<TtimeEntityOut> BuildControl(ITimeUserBuild timeUserCommon) {
            return timeUserCommon.BuildList(ttimeEntity);
        }
    }
}
