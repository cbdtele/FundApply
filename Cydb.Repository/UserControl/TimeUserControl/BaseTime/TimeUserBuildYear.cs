using System;
using System.Collections.Generic;
using Cydb.Common.Helper;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl.BaseTime {
    public class TimeUserBuildYear : TimeUserBuild {
        protected override Func<int, int, List<TtimeEntityOut>, List<TtimeEntityOut>> Do(TtimeEntity ttimeEntity) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 生成年份下拉框
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        public override List<TtimeEntityOut> BuildList(TtimeEntity entityDto) {
            List<TtimeEntityOut> list = new List<TtimeEntityOut>();
            var bgYear = TimeHelper.GetYear(entityDto.BEGINTIME);
            var enYear = TimeHelper.GetYear(entityDto.ENDTIME);
            Func<int, List<TtimeEntityOut>, List<TtimeEntityOut>> funcM = (i, k) => {
                var timeValue = i.ToString();
                if (timeValue != entityDto.FLAG_DEC) {
                    k.Add(new TtimeEntityOut { Text = timeValue + "年", Value = timeValue, SplitChar = entityDto.GetSplitChar() });
                }
                return k;
            };

            for (var i = bgYear; i <= enYear; i++) {
                list = funcM(i, list);
            }
            list.Reverse();
            return list;
        }

    }
}
