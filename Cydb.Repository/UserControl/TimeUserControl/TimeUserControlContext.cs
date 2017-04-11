using System;
using System.Collections.Generic;
using Cydb.Repository.Entity;
using Cydb.Repository.UserControl.TimeUserControl.Algorithm;

namespace Cydb.Repository.UserControl.TimeUserControl {
    /// <summary>
    /// 时间策略类型
    /// </summary>
    public enum TimeSelectAlgorithm {
        /// <summary>
        /// 税收策略
        /// </summary>
        Tax,
        /// <summary>
        /// 区级收入策略
        /// </summary>
        Qjsr,
        /// <summary>
        /// GDP策略
        /// </summary>
        Gdp,
        /// <summary>
        /// 批零策略
        /// </summary>
        Pl,
        /// <summary>
        /// 固定资产策略
        /// </summary>
        Gdzc,
        /// <summary>
        /// 从业人员策略
        /// </summary>
        Cyry,
        /// <summary>
        /// 营业收入策略
        /// </summary>
        Yysr,
        /// <summary>
        /// 资产总计策略
        /// </summary>
        Zczj,
        /// <summary>
        /// 利润总额策略
        /// </summary>
        Lrze,
        /// <summary>
        /// 能耗策略
        /// </summary>
        Nh,
        /// <summary>
        /// 水耗策略
        /// </summary>
        Sh
    }

    /// <summary>
    /// 时间自定义控件上下文
    /// </summary>
    public class TimeUserControlContext : ITimeUserControlContext {
        private readonly Strategy _strategy = null;
        /// <summary>
        /// 时间自定义控件上下文
        /// </summary>
        /// <param name="timeSelectAlgorithm"></param>
        public TimeUserControlContext(TimeSelectAlgorithm timeSelectAlgorithm) {
            switch (timeSelectAlgorithm) {
                case TimeSelectAlgorithm.Tax:
                    _strategy = new AlgorithMonthlyTax(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Tax.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Qjsr:
                    _strategy = new AlgorithMonthlyQjsr(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Qjsr.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Gdp:
                    _strategy = new AlgorithMonthlyGdp(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Gdp.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Pl:
                    _strategy = new AlgorithMonthlyPl(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Pl.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Gdzc:
                    _strategy = new AlgorithMonthlyGdzc(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Gdzc.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Cyry:
                    _strategy = new AlgorithMonthlyCyry(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Cyry.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Yysr:
                    _strategy = new AlgorithMonthlyYysr(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Yysr.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Zczj:
                    _strategy = new AlgorithMonthlyZczj(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Zczj.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Lrze:
                    _strategy = new AlgorithMonthlyLrze(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Lrze.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Nh:
                    _strategy = new AlgorithMonthlyNh(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Nh.ToString()
                    });
                    break;
                case TimeSelectAlgorithm.Sh:
                    _strategy = new AlgorithMonthlySh(new TtimeEntity {
                        ECO_TYPE = TimeSelectAlgorithm.Sh.ToString()
                    });
                    break;
                default:
                    throw new Exception("未知命令操作时间下拉框。");
            }
        }

        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <returns></returns>
        public List<List<TtimeEntityOut>> GetResult() {
            return _strategy.AlgorithmInterface();
        }
    }
}
