//取消select选中项
function noneSelect(id) {
    var elem = document.getElementById(id);
    for (var i = 0; i < elem.options.length; i++) {
        var opt = elem.options[i];
        opt.selected = false;
    }
}

//清除综合查询中选中的值,参数：计数对象
function clearConditionSelectedValue(sv) {
    //var sv=getSelectedValue(selectId);
    //alert("sv: "+sv);
    //如果条件计数器中存在累记条件
    if (!((sv == null) || (sv.value.length == 0))) {
        var svs = sv.value.split(",");
        for (var i = 0; i < svs.length; i++) {
            //var svValues ="";
            //var svField = sv+":field"; //条件字段
            //var svCond1 = sv+":cond1"; //关系
            var svValue = svs[i] + ":value"; //条件字段值
            //var svCond2 = sv+":cond2"; //关系2
            var svType = svs[i] + ":type";  //条件类型
            //alert("svType: "+svType);
            //根据条件类型清除选中值
            var svTypeV = document.getElementById(svType).value;
            //alert("svTypeV: "+svTypeV);
            var svValueV = document.getElementById(svValue);
            //alert("fdddf: "+svValueV);
            if (svTypeV == "select") {
                noneSelect(svValue);
            } else {
                svValueV.value = "";
            }

        }
    }

}

//当用户清除条件选项则清除综合条件与批量条件
//参数说明：id：条件table标识；countid: 记数器标识
function clearCondition(id, countid) {
    //综合条件记数器
    var c = document.getElementById(countid);
    //清除综合条件中的值
    clearConditionSelectedValue(c);
    //清除综合条件计数器累计
    c.value = "";
    //使条件不显示
    var elem = document.getElementById(id);
    for (var i = elem.rows.length; i > 2; i--) {
        elem.rows[i - 1].style.display = "none";
    }
    //选择第一项
    //document.getElementById("fieldsSelect").options[0].selected=true;
    //document.getElementById("fieldsSelect").onchange();
}

function getSelectedValue(selectId) {
    var select = document.getElementById(selectId);
    for (var i = 0; i < select.options.length; i++) {
        if (select.options[i].selected == true) {
            selectValue = select.options[i].value;
        }
    }
    return selectValue;
}

//获取多选值
function getSelectedValues(selectId) {
    var select = document.getElementById(selectId);
    var selectValue = "";
    for (var i = 0; i < select.options.length; i++) {
        if (select.options[i].selected == true) {
            selectValue = selectValue + select.options[i].value;
            //if(i<(select.options.length-1)){
            selectValue = selectValue + ",";
            //}
        }
    }
    if (selectValue.length > 0) {
        selectValue = selectValue.substring(0, selectValue.length - 1);
    }
    return selectValue;
}

//累计条件中是否包括条件
function isIncludeCondition(v, vs) {
    var bool = null;
    if (vs != null && vs.length > 0) {
        for (var i = 0; i < vs.length; i++) {
            var temp = vs[i];
            if (temp == v) {
                bool = true;
                break;
            }
        }
        if (bool == null) {
            bool = false;
        }
    } else {
        bool = false;
    }
    return bool;
}

//当用户先择一个新的条件则进行条件记数操作
function calCondition(self, id) {
    var v = getSelectedValue(self.id);
    var c = document.getElementById(id);
    //如果是请选择则不做累计处理
    if (v != '-1') {
        //第一个条件
        if (c.value == null || c.value.length == 0) {
            //累计条件
            c.value = v;
        } else {
            //获取所有条件
            var cs = c.value.split(",");
            //如果记录器中不包含条件则累计条件
            if (!isIncludeCondition(v, cs)) {
                //累计条件
                c.value = c.value + "," + v;
            }
        }
    }
    //alert("conditions: "+c.value);
}

function addTableTr(id, self) {
    for (var i = 0; i < self.options.length; i++) {
        if (self.options[i].selected == true) {
            //alert("selectd: "+self.options[i].value);
            if (!(self.options[i].value == "-1")) {
                addRowToTable(id);
                break;
            } else
                if (!(self.options[i].id == 'conditions2')) {
                    //moveRowToTable(id,i+1);
                }
        }
    }
}

function moveRowToTable(id, len) {
    var tbl = document.getElementById(id);
    //alert("id: "+tbl.rows.length+"len: "+len);
    tbl.deleteRow(tbl.rows.length - 1);
    for (var i = tbl.rows.length - 1; i > len; i--) {
        //alert("rows: "+i);
        tbl.deleteRow(i);
    }
}

function addRowToTable(id) {
    var tbl = document.getElementById(id);
    var lastRow = tbl.rows.length;
    // if there's no header row in the table, then iteration = lastRow + 1 
    var iteration = lastRow;
    var row = tbl.insertRow(lastRow);

    var fields = document.getElementById("fields");
    // select cell 
    var cellRightSel = row.insertCell(0);
    var sel = document.createElement('select');
    sel.name = 'selRow' + iteration;
    for (var i = 0; i < fields.options.length; i++) {
        sel.options[i] = new Option(fields.options[i].text, fields.options[i].value);
    }
    cellRightSel.appendChild(sel);
    iteration = iteration + 1;
    var fields = document.getElementById("conditions");
    // select cell 
    var cellRightSel = row.insertCell(1);
    var sel = document.createElement('select');
    sel.name = 'selRow' + iteration;
    for (var i = 0; i < fields.options.length; i++) {
        sel.options[i] = new Option(fields.options[i].text, fields.options[i].value);
    }
    cellRightSel.appendChild(sel);

    iteration = iteration + 1;
    // right cell 
    var cellRight = row.insertCell(2);
    var el = document.createElement('input');
    el.type = 'text';
    el.name = 'txtRow' + iteration;
    el.id = 'txtRow' + iteration;
    el.size = 20;
    cellRight.appendChild(el);
    // select cell 
    var fields = document.getElementById("conditions2");
    iteration = iteration + 1;
    // select cell 
    var cellRightSel = row.insertCell(3);
    var sel = document.createElement('select');
    sel.name = 'selRow' + iteration;
    sel.onchange = function () { addTableTr('selectConditionTable', sel); };
    for (var i = 0; i < fields.options.length; i++) {
        sel.options[i] = new Option(fields.options[i].text, fields.options[i].value);
    }
    cellRightSel.appendChild(sel);
}

//选择自段
function selectField(id) {
    var tbl = document.getElementById(id);
    for (var i = 0; i < tbl.options.length; i++) {
        if (tbl.options[i].selected == true) {
            var selectid = "selectType" + tbl.options[i].value;
            var selectType = document.getElementById(selectid);
            //alert("selectType: "+selectType);
        }
    }
}

//添加条件
function addCondition(selectId, tableId, msg) {
    var table = document.getElementById(tableId);
    var selectValue = getSelectedValue(selectId);
    var animate = ['', 'fadeIn', 'fadeInUp', 'flipInX'];
    //如果不是“请选则”提示信息，则添加选择条件
    if ((selectValue != '-1')) {
        var node = document.getElementById(selectValue + ":field");
        var con2SelectValue = getSelectedValue((selectValue + ":cond2"));
        var tr = (node.parentNode).parentNode;
        tr.style.display = "";
        tr.className = animate[Math.ceil(Math.random() * 3)] + " animated";
        setTimeout(function () {
            tr.className = "";
        }, 2000);
    }
}

var Condition = new Object();
Condition.value = "";
Condition.cond2 = "";

//获取所有 参数说明：条件累计标识
function getConditionSelectedValues(countid) {
    var svValues = "";
    var sv = "";
    var countvalues = document.getElementById(countid).value;
    //alert("countvalues: "+countvalues);
    if (countvalues != null && countvalues.length > 0) {
        var svs = countvalues.split(",");
        for (var i = 0; i < svs.length; i++) {
            var Condition = getConditionSelectedValue(svs[i]);
            if (i > 0 && i <= (svs.length - 1)) {
                svValues = svValues + " " + Condition.cond2 + " ";
            }
            svValues = svValues + Condition.value;
        }
    }
    return svValues;
}
//获取一个条件的值
function getConditionSelectedValue(sv) {
    //var sv=getSelectedValue(selectId);
    var svValues = "";
    var svField = sv + ":field";
    var svCond1 = sv + ":cond1";
    var svValue = sv + ":value";
    var svCond2 = sv + ":cond2";
    var svType = sv + ":type";
    var svFieldV = document.getElementById(svField).value;
    //条件选项
    var svCond1V = getSelectedValue(svCond1);
    //alert("svFieldV:"+svFieldV);
    //根据不同的类型取值
    var svTypeV = document.getElementById(svType).value;
    //alert("svTypeV: "+svTypeV);
    var svValueV = "";
    if (svTypeV == "select") {
        svValueV = getSelectedValues(svValue);
        //alert("svValueV: "+svValueV);
    } else {
        svValueV = document.getElementById(svValue).value;
    }
    var svCond2V = document.getElementById(svCond2).value;
    //alert("svCond1V: "+svCond1V);
    //将选择条件转换成接口条件值
    svValues = getConditionStr(svFieldV, svValueV, svCond1V, svTypeV);
    //alert("svValues:"+svValues);
    Condition.value = svValues;
    Condition.cond2 = svCond2V;
    //alert("svCond2V: "+svCond2V);
    return Condition;
}
function getConditionKey(value) {
    var key = "";
    //alert("value: "+value);
    if (value == '1') {
        key = " = ";
    } else if (value == "2") {
        key = " != ";
    } else if (value == "3") {
        key = " > ";
    } else if (value == "4") {
        key = " < ";
    } else if (value == "5") {
        key = " >= ";
    } else if (value == "6") {
        key = " <= ";
    } else if (value == "7") {
        key = " like ";
    } else if (value == "8") {
        key = " not like ";
    } else if (value == "9") {
        key = " in ";
    } else if (value == "10") {
        key = " not in ";
    }
    //alert("key: "+key);
    return key;
}
function getStrValue(value) {
    return "'" + value + "'";
}
function getConditionStr(value, value2, key, type) {
    var realValue = "";
    //alert("type: "+type);
    var realKey = getConditionKey(key);
    //alert("realKey"+realKey);
    if (value2 != null && value2.length > 0) {
        if (key == "1") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
        } else if (key == "2") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
        } else if (key == "3") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
        } else if (key == "4") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
        } else if (key == "5") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
        } else if (key == "6") {
            if (type == 'text') {
                realValue = value + realKey + getStrValue(value2);
            } else {
                realValue = value + realKey + value2;
            }
            //多项选择
        } else if (key == "7") {
            if (type == 'text') {
                realValue = value + realKey + "'%" + value2 + "%'";
            }
        } else if (key == "8") {
            if (type = 'text') {
                realValue = value + realKey + "'%" + value2 + "%'";
            }
        } else if (key == "9") {
            if (type == 'text') {
                realValue = value + realKey + "(" + getStrValue(value2) + ")";
            } else {
                if (value2 != null && value2.length > 0) {
                    var temp = value2.split(",");
                    var temp2 = "";
                    for (var i = 0; i < temp.length; i++) {
                        temp2 = temp2 + getStrValue(temp[i]);
                        if (i < temp.length - 1) {
                            temp2 = temp2 + ",";
                        }
                    }
                    realValue = value + realKey + "(" + temp2 + ")";
                }
            }
        } else if (key == "10") {
            if (type == 'text') {
                realValue = value + realKey + "(" + getStrValue(value2) + ")";
            } else {
                if (value2 != null && value2.length > 0) {
                    var temp = value2.split(",");
                    var temp2 = "";
                    for (var i = 0; i < temp.length; i++) {
                        temp2 = temp2 + getStrValue(temp[i]);
                        if (i < temp.length - 1) {
                            temp2 = temp2 + ",";
                        }
                    }
                    realValue = value + realKey + "(" + temp2 + ")";
                }
            }
        }
    }
    return realValue;
}