using System;
using System.Collections.Generic;
using Cydb.Common.Helper;
using Cydb.Repository.Entity;
using System.Linq;

namespace Cydb.Repository.UserControl.TimeUserControl.BaseTime {
    public class TimeUserBuildCumulative : TimeUserBuild {
       
        protected override Func<int, int, List<TtimeEntityOut>, List<TtimeEntityOut>> Do(TtimeEntity entityDto) {
            return (i, j, k) => {
                var text = i + "年" + (j == 1 ? "1" : "1-" + j + "月");
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
