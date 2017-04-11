/*
    Jquery.CBD.js附属Echart图表封装插件
    维护者：李科笠（2016年3月1日 15:07:40）
*/
!(function ($) {
    $.ChartTemple = {
        /**
         * 图表模型 - 带有时间轴的【单饼图】
         * @param {} target 目标容器ID
         * @param {} title 标题
         * @param {} json 数据源
         * @returns {} 
         */
        TimePie: function (target, title, json) {
            require(
                [
                    "echarts",
                    "echarts/chart/pie",
                    "echarts/theme/macarons"
                ],
                function (ec) {
                    var myChart = ec.init(document.getElementById(target));
                    var option = {
                        timeline: {
                            data: json.xAxisData,
                            autoPlay: true,
                            playInterval: 2000
                        },
                        options: [
                            {
                                title: {
                                    text: title,
                                    x: "center"
                                },
                                tooltip: {
                                    trigger: "Item",
                                    formatter: "{a} <br/>{b} <br/> {c} ({d}%)"
                                },
                                series: [
                                    {
                                        name: json.xAxisData[0],
                                        type: "pie",
                                        center: ["50%", "45%"],
                                        radius: "50%",
                                        data: json.seriesJson[0].series[0].data,
                                        itemStyle: {
                                            normal: {
                                                label: {
                                                    show: true,
                                                    formatter: "{b}({d}%)"
                                                },
                                                labelLine: { show: true }
                                            }
                                        }
                                    }
                                ]
                            },
                            json.seriesJson[1], json.seriesJson[2], json.seriesJson[3], json.seriesJson[4],
                            json.seriesJson[5], json.seriesJson[6], json.seriesJson[7], json.seriesJson[8],
                            json.seriesJson[9], json.seriesJson[10], json.seriesJson[11], json.seriesJson[12],
                            json.seriesJson[13], json.seriesJson[14], json.seriesJson[15], json.seriesJson[16],
                            json.seriesJson[17], json.seriesJson[18], json.seriesJson[19], json.seriesJson[20]
                        ]
                    };
                    myChart.setOption(option);
                }
            );
        },
        /**
         * 图表模型 - 带有时间轴的【多饼图】
         * 布局算法不完美，需要优化
         * @param {} target 目标容器ID 
         * @param {} title 标题
         * @param {} json 数据源
         * @param {} center 园的内外半径，间距
         * @returns {} 
         */
        TimePieMacarons: function (target, title, jsonData, center) {
            var labelFromatter = {
                normal: {
                    label: {
                        formatter: function (params) {
                            return CBD.toFixed((100 - params.value), 2) + "%";
                        },
                        textStyle: {
                            baseline: "top"
                        }
                    }
                }
            },
                $width = $("#" + target).width(),
                $heigth = $("#" + target).height();
            var pieCenters = $.extend({}, { r: [40, 55], padding: 30, left: false, leftPadding: 0.08 }, center);
            var left = pieCenters.left ? ($width * pieCenters.leftPadding) : 0;
            function getDecimal(obj) {
                return (String(obj)).substring(parseInt(obj).length + 1, obj.length);
            }

            function temple(obj) {
                var len = obj.length;
                var rows = 1, column = 1;
                var radius = pieCenters.r, padding = pieCenters.padding;
                var w = parseInt($width / ((radius[1] + padding) * 2));
                var s = parseInt($heigth / ((Math.ceil(len / w)) * ((radius[1] + padding) * 2)));
                var avgWidth = ($width - w * (radius[1] + padding)) / 2;
                var avgHeight = ($heigth * 0.89 - s * (radius[1] + padding)) / 2;

                for (var i = 0; i < obj.length; i++) {
                    if (i % w === 0 && i !== 0) {
                        column = 1;
                        rows++;
                    }
                    $.extend(true, obj[i], {
                        type: "pie",
                        center: [avgWidth * column - left, avgHeight * rows],
                        radius: radius,
                        itemStyle: labelFromatter
                    });
                    column++;
                }
                return obj;
            };
            require(
                [
                    "echarts",
                    "echarts/chart/pie",
                    "echarts/theme/macarons"
                ],
                function (ec) {
                    var myChart = ec.init(document.getElementById(target));
                    var option = {
                        timeline: {
                            data: jsonData.xAxisData,
                            autoPlay: true,
                            playInterval: 2000
                        },
                        options: [
                            {
                                legend: {
                                    x: "center",
                                    y: "bottom",
                                    data: []
                                },
                                title: {
                                    text: title,
                                    subtext: "",
                                    x: "center"
                                },
                                series: temple(jsonData.seriesJson[0].series)
                                //[
                                //    {
                                //        type: 'pie',
                                //        center: ['35%', '30%'],
                                //        radius: radius,
                                //        itemStyle: labelFromatter,
                                //        data: jsonData.seriesJson[0].series[0].data
                                //    },
                                //    {
                                //        type: 'pie',
                                //        center: ['65%', '30%'],
                                //        radius: radius,
                                //        itemStyle: labelFromatter,
                                //        data: jsonData.seriesJson[0].series[1].data
                                //    },
                                //    {
                                //        type: 'pie',
                                //        center: ['35%', '70%'],
                                //        radius: radius,
                                //        itemStyle: labelFromatter,
                                //        data: jsonData.seriesJson[0].series[2].data
                                //    },
                                //    {
                                //        type: 'pie',
                                //        center: ['65%', '70%'],
                                //        radius: radius,
                                //        itemStyle: labelFromatter,
                                //        data: jsonData.seriesJson[0].series[3].data
                                //    }
                                //]
                            },
                            jsonData.seriesJson[1], jsonData.seriesJson[2], jsonData.seriesJson[3],
                            jsonData.seriesJson[4], jsonData.seriesJson[5], jsonData.seriesJson[6],
                            jsonData.seriesJson[7], jsonData.seriesJson[8], jsonData.seriesJson[9],
                            jsonData.seriesJson[10], jsonData.seriesJson[11], jsonData.seriesJson[12],
                            jsonData.seriesJson[13], jsonData.seriesJson[14], jsonData.seriesJson[15],
                            jsonData.seriesJson[16], jsonData.seriesJson[17], jsonData.seriesJson[18],
                            jsonData.seriesJson[19], jsonData.seriesJson[20]
                        ]
                    };
                    myChart.setOption(option);
                }
            );
        }
    }

})(jQuery);

