using System.Collections.Generic;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl {
    public interface ITimeUserControlContext {
        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <returns></returns>
        List<List<TtimeEntityOut>> GetResult();
    }
}
