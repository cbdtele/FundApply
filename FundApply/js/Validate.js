//验证输入时间的格式
function VDate(txtDate) {
    var pattern = /^([1-2]\d{3})[\/|\-](0?[1-9]|10|11|12)[\/|\-]([1-2]?[0-9]|0[1-9]|30|31)$/ig;
    return pattern.test(txtDate);
}