function selectTab(num, thisObj, url) {
    thisObj.blur();
    var tab = document.getElementById("tabs").getElementsByTagName("li");
    var tablength = tab.length;
    for (i = 0; i < tablength; i++) {
        tab[i].className = "";
    }
    thisObj.parentNode.className = "selectTab";
    for (i = 0; i < tablength; i++) {
        document.getElementById("tabContent" + i).style.display = "none";
    }
    document.getElementById("tabContent" + num).style.display = "block";
    if (url != null) {
        document.getElementById("Iframe" + num).src = url;
    }

}
function reinitIframe() {
    var iframe = document.getElementById("frmChild");
    if (iframe != null) {
        var bool = iframe.contentWindow.document.readyState == 'complete';
        if (bool) {
            var bHeight = iframe.contentWindow.document.body.scrollHeight;
            var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
            //            alert(bHeight);alert(dHeight);    
            var height = Math.min(bHeight, dHeight);
            iframe.height = height;
        }
    }
}
window.setInterval("reinitIframe()", 1000);
