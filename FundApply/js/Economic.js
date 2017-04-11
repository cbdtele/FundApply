function rdoSet(num) {

    if (num == null) {
        return;
    }
    var ck1 = document.getElementById("ck1");
    var ck2 = document.getElementById("ck2");
    if (num == 1) {
        ck1.disabled = false;
        ck2.disabled = false;
        ck1.checked = true;
        ck2.checked = true;
    } else if (num == 2) {
        ck1.disabled = true;
        ck2.disabled = true;
        ck1.checked = false;
        ck2.checked = false;
    }
}