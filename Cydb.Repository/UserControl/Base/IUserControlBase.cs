using System.Collections.Generic;

namespace Cydb.Repository.UserControl.Base {
    /// <summary>
    /// 用户自定义控件 基接口
    /// </summary>
    public interface IUserControlBase {
        /// <summary>
        /// 用户自定义控件 查询所有的集合
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetAllList();
    }
}
