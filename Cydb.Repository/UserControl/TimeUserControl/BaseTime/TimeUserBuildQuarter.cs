using System;
using System.Collections.Generic;
using System.Linq;
using Cydb.Common.Helper;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl.BaseTime {
    public class TimeUserBuildQuarter : TimeUserBuild {

        protected override Func<int, int, List<TtimeEntityOut>, List<TtimeEntityOut>> Do(TtimeEntity entityDto) {
            return (i, j, k) => {
                var text = i + "年" + (j == 3 ? string.Empty : "第一至") + TimeHelper.GetQuarterString(j);
                var timeValue = i + TimeHelper.ComplementZero(j);
                if (!entityDto.GetShowTime().Contains(j)) {
                    return k;
                }
                if (timeValue == entityDto.FLAG_DEC) {
                    return k;
                }
                k.Add(new TtimeEntityOut { Text = text, Value = timeValue, SplitChar = entityDto.GetSplitChar() });
                return k;
            };
        }
    }
}
