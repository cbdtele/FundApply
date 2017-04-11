using System.Collections.Generic;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl.BaseTime {
    /// <summary>
    /// 自定义时间控件生成 接口
    /// </summary>
    public interface ITimeUserBuild {
        /// <summary>
        /// 生成
        /// </summary>
        /// <returns></returns>
        List<TtimeEntityOut> BuildList(TtimeEntity ttimeEntity);
    }
}
