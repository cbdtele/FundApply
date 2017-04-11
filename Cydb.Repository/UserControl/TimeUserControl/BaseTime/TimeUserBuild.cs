using System;
using System.Collections.Generic;
using Cydb.Common.Helper;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl.BaseTime {
    /// <summary>
    /// 自定义时间控件生成 基类
    /// </summary>
    public abstract class TimeUserBuild : ITimeUserBuild {

        /// <summary>
        /// 生成策略
        /// </summary>
        /// <returns></returns>
        protected abstract Func<int, int, List<TtimeEntityOut>, List<TtimeEntityOut>> Do(TtimeEntity ttimeEntity);

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="ttimeEntity">下拉框生成配置实体</param>
        /// <returns></returns>
        public virtual List<TtimeEntityOut> BuildList(TtimeEntity ttimeEntity) {
            var list = new List<TtimeEntityOut>();
            var bgYear = TimeHelper.GetYear(ttimeEntity.BEGINTIME);
            var bgMonth = TimeHelper.GetMonth(ttimeEntity.BEGINTIME);
            var enYear = TimeHelper.GetYear(ttimeEntity.ENDTIME);
            var enMonth = TimeHelper.GetMonth(ttimeEntity.ENDTIME);
            for (var i = bgYear; i <= enYear; i++) {
                if (i == bgYear) {
                    //起始
                    for (var j = bgMonth; j <= 12; j++) {
                        list = Do(ttimeEntity)(i, j, list);
                    }
                }
                else if (i == enYear) {
                    //结束
                    for (var j = 1; j <= enMonth; j++) {
                        list = Do(ttimeEntity)(i, j, list);
                    }
                }
                else {
                    //中间循环
                    for (var j = 1; j <= 12; j++) {
                        list = Do(ttimeEntity)(i, j, list);
                    }
                }
            }
            list.Reverse();
            return list;
        }


    }
}
