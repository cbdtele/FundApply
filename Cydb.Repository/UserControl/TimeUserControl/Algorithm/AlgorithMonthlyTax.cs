using System.Collections.Generic;
using Cydb.Common.Helper;
using Cydb.Repository.Entity;

namespace Cydb.Repository.UserControl.TimeUserControl.Algorithm {
    /// <summary>
    /// 税收算法策略
    /// </summary>
    public class AlgorithMonthlyTax : Strategy {
        public AlgorithMonthlyTax(TtimeEntity entity) : base(entity) {
        }
    }
}
