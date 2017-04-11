function shdiv(n) {
    var sh = document.getElementById("testdiv" + n);
    var lia = document.getElementById("li" + n);
    for (var i = 1; i <= 7; i++) {
        var sh1 = document.getElementById("testdiv" + i);
        var lib = document.getElementById("li" + i);
        if (n == i) {
            sh.style.display = "block";
            lia.className = "active";
        } else {
            sh1.style.display = "none";
            lib.className = "normal";
        }
    }
}
