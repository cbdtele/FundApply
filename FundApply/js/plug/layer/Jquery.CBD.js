/*  头部为必要依赖组件，包括json处理、cookie处理、拟态、样式、兼容调整、渲染引擎
    底部的部分为核心组件
    -- 2015年12月31日 10:27:52 By 李科笠
    -- ps：2015年最后一天的代码
*/
!function (a, b) { "function" == typeof define && define.amd ? define(b) : "object" == typeof exports ? module.exports = b(require, exports, module) : a.CountUp = b() }(this, function () { var d = function (a, b, c, d, e, f) { for (var g = 0, h = ["webkit", "moz", "ms", "o"], i = 0; i < h.length && !window.requestAnimationFrame; ++i) window.requestAnimationFrame = window[h[i] + "RequestAnimationFrame"], window.cancelAnimationFrame = window[h[i] + "CancelAnimationFrame"] || window[h[i] + "CancelRequestAnimationFrame"]; window.requestAnimationFrame || (window.requestAnimationFrame = function (a) { var c = (new Date).getTime(), d = Math.max(0, 16 - (c - g$timeInterval)), e = window.setTimeout(function () { a(c + d) }, d); return g = c + d, e }), window.cancelAnimationFrame || (window.cancelAnimationFrame = function (a) { clearTimeout(a) }), this.options = { useEasing: !0, useGrouping: !0, separator: ",", decimal: "." }; for (var j in f) f.hasOwnProperty(j) && (this.options[j] = f[j]); "" === this.options.separator && (this.options.useGrouping = !1), this.options.prefix || (this.options.prefix = ""), this.options.suffix || (this.options.suffix = ""), this.d = "string" == typeof a ? document.getElementById(a) : a, this.startVal = Number(b), isNaN(b) && (this.startVal = Number(b.match(/[\d]+/g).join(""))), this.endVal = Number(c), isNaN(c) && (this.endVal = Number(c.match(/[\d]+/g).join(""))), this.countDown = this.startVal > this.endVal, this.frameVal = this.startVal, this.decimals = Math.max(0, d || 0), this.dec = Math.pow(10, this.decimals), this.duration = 1e3 * Number(e) || 2e3; var k = this; this.version = function () { return "1.5.3" }, this.printValue = function (a) { var b = isNaN(a) ? "--" : k.formatNumber(a); "INPUT" == k.d.tagName ? this.d.value = b : "text" == k.d.tagName ? this.d.textContent = b : this.d.innerHTML = b }, this.easeOutExpo = function (a, b, c, d) { return 1024 * c * (-Math.pow(2, -10 * a / d) + 1) / 1023 + b }, this.count = function (a) { k.startTime || (k.startTime = a), k.timestamp = a; var b = a - k.startTime; k.remaining = k.duration - b, k.frameVal = k.options.useEasing ? k.countDown ? k.startVal - k.easeOutExpo(b, 0, k.startVal - k.endVal, k.duration) : k.easeOutExpo(b, k.startVal, k.endVal - k.startVal, k.duration) : k.countDown ? k.startVal - (k.startVal - k.endVal) * (b / k.duration) : k.startVal + (k.endVal - k.startVal) * (b / k.duration), k.frameVal = k.countDown ? k.frameVal < k.endVal ? k.endVal : k.frameVal : k.frameVal > k.endVal ? k.endVal : k.frameVal, k.frameVal = Math.round(k.frameVal * k.dec) / k.dec, k.printValue(k.frameVal), b < k.duration ? k.rAF = requestAnimationFrame(k.count) : k.callback && k.callback() }, this.start = function (a) { return k.callback = a, isNaN(k.endVal) || isNaN(k.startVal) || k.startVal === k.endVal ? (console.log("countUp error: startVal or endVal is not a number"), k.printValue(c)) : k.rAF = requestAnimationFrame(k.count), !1 }, this.pauseResume = function () { k.paused ? (k.paused = !1, delete k.startTime, k.duration = k.remaining, k.startVal = k.frameVal, requestAnimationFrame(k.count)) : (k.paused = !0, cancelAnimationFrame(k.rAF)) }, this.reset = function () { k.paused = !1, delete k.startTime, k.startVal = b, cancelAnimationFrame(k.rAF), k.printValue(k.startVal) }, this.update = function (a) { cancelAnimationFrame(k.rAF), k.paused = !1, delete k.startTime, k.startVal = k.frameVal, k.endVal = Number(a), k.countDown = k.startVal > k.endVal, k.rAF = requestAnimationFrame(k.count) }, this.formatNumber = function (a) { a = a.toFixed(k.decimals), a += ""; var b, c, d, e; if (b = a.split("."), c = b[0], d = b.length > 1 ? k.options.decimal + b[1] : "", e = /(\d+)(\d{3})/, k.options.useGrouping) for (; e.test(c) ;) c = c.replace(e, "$1" + k.options.separator + "$2"); return k.options.prefix + c + d + k.options.suffix }, k.printValue(k.startVal) }; return d });
!function (a) { "function" == typeof define && define.amd ? define(["jquery"], a) : "object" == typeof exports ? a(require("jquery")) : a(jQuery) }(function (a) { function b(a) { return h.raw ? a : encodeURIComponent(a) } function c(a) { return h.raw ? a : decodeURIComponent(a) } function d(a) { return b(h.json ? JSON.stringify(a) : String(a)) } function e(a) { 0 === a.indexOf('"') && (a = a.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, "\\")); try { return a = decodeURIComponent(a.replace(g, " ")), h.json ? JSON.parse(a) : a } catch (b) { } } function f(b, c) { var d = h.raw ? b : e(b); return a.isFunction(c) ? c(d) : d } var g = /\+/g, h = a.cookie = function (e, g, i) { if (void 0 !== g && !a.isFunction(g)) { if (i = a.extend({}, h.defaults, i), "number" == typeof i.expires) { var j = i.expires, k = i.expires = new Date; k.setTime(+k + 864e5 * j) } return document.cookie = [b(e), "=", d(g), i.expires ? "; expires=" + i.expires.toUTCString() : "", i.path ? "; path=" + i.path : "", i.domain ? "; domain=" + i.domain : "", i.secure ? "; secure" : ""].join("") } for (var l = e ? void 0 : {}, m = document.cookie ? document.cookie.split("; ") : [], n = 0, o = m.length; o > n; n++) { var p = m[n].split("="), q = c(p.shift()), r = p.join("="); if (e && e === q) { l = f(r, g); break } e || void 0 === (r = f(r)) || (l[q] = r) } return l }; h.defaults = {}, a.removeCookie = function (b, c) { return void 0 === a.cookie(b) ? !1 : (a.cookie(b, "", a.extend({}, c, { expires: -1 })), !a.cookie(b)) } });
"object" != typeof JSON && (JSON = {}), function () { "use strict"; function f(t) { return 10 > t ? "0" + t : t } function this_value() { return this.valueOf() } function quote(t) { return rx_escapable.lastIndex = 0, rx_escapable.test(t) ? '"' + t.replace(rx_escapable, function (t) { var e = meta[t]; return "string" == typeof e ? e : "\\u" + ("0000" + t.charCodeAt(0).toString(16)).slice(-4) }) + '"' : '"' + t + '"' } function str(t, e) { var r, n, o, u, f, a = gap, i = e[t]; switch (i && "object" == typeof i && "function" == typeof i.toJSON && (i = i.toJSON(t)), "function" == typeof rep && (i = rep.call(e, t, i)), typeof i) { case "string": return quote(i); case "number": return isFinite(i) ? i + "" : "null"; case "boolean": case "null": return i + ""; case "object": if (!i) return "null"; if (gap += indent, f = [], "[object Array]" === Object.prototype.toString.apply(i)) { for (u = i.length, r = 0; u > r; r += 1) f[r] = str(r, i) || "null"; return o = 0 === f.length ? "[]" : gap ? "[\n" + gap + f.join(",\n" + gap) + "\n" + a + "]" : "[" + f.join(",") + "]", gap = a, o } if (rep && "object" == typeof rep) for (u = rep.length, r = 0; u > r; r += 1) "string" == typeof rep[r] && (n = rep[r], o = str(n, i), o && f.push(quote(n) + (gap ? ": " : ":") + o)); else for (n in i) Object.prototype.hasOwnProperty.call(i, n) && (o = str(n, i), o && f.push(quote(n) + (gap ? ": " : ":") + o)); return o = 0 === f.length ? "{}" : gap ? "{\n" + gap + f.join(",\n" + gap) + "\n" + a + "}" : "{" + f.join(",") + "}", gap = a, o } } var rx_one = /^[\],:{}\s]*$/, rx_two = /\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, rx_three = /"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, rx_four = /(?:^|:|,)(?:\s*\[)+/g, rx_escapable = /[\\\"\u0000-\u001f\u007f-\u009f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g, rx_dangerous = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g; "function" != typeof Date.prototype.toJSON && (Date.prototype.toJSON = function () { return isFinite(this.valueOf()) ? this.getUTCFullYear() + "-" + f(this.getUTCMonth() + 1) + "-" + f(this.getUTCDate()) + "T" + f(this.getUTCHours()) + ":" + f(this.getUTCMinutes()) + ":" + f(this.getUTCSeconds()) + "Z" : null }, Boolean.prototype.toJSON = this_value, Number.prototype.toJSON = this_value, String.prototype.toJSON = this_value); var gap, indent, meta, rep; "function" != typeof JSON.stringify && (meta = { "\b": "\\b", "	": "\\t", "\n": "\\n", "\f": "\\f", "\r": "\\r", '"': '\\"', "\\": "\\\\" }, JSON.stringify = function (t, e, r) { var n; if (gap = "", indent = "", "number" == typeof r) for (n = 0; r > n; n += 1) indent += " "; else "string" == typeof r && (indent = r); if (rep = e, e && "function" != typeof e && ("object" != typeof e || "number" != typeof e.length)) throw Error("JSON.stringify"); return str("", { "": t }) }), "function" != typeof JSON.parse && (JSON.parse = function (text, reviver) { function walk(t, e) { var r, n, o = t[e]; if (o && "object" == typeof o) for (r in o) Object.prototype.hasOwnProperty.call(o, r) && (n = walk(o, r), void 0 !== n ? o[r] = n : delete o[r]); return reviver.call(t, e, o) } var j; if (text += "", rx_dangerous.lastIndex = 0, rx_dangerous.test(text) && (text = text.replace(rx_dangerous, function (t) { return "\\u" + ("0000" + t.charCodeAt(0).toString(16)).slice(-4) })), rx_one.test(text.replace(rx_two, "@").replace(rx_three, "]").replace(rx_four, ""))) return j = eval("(" + text + ")"), "function" == typeof reviver ? walk({ "": j }, "") : j; throw new SyntaxError("JSON.parse") }) }();
; !function () { "use strict"; var f, b = { open: "{{", close: "}}" }, c = { exp: function (a) { return new RegExp(a, "g") }, query: function (a, c, e) { var f = ["#([\\s\\S])+?", "([^{#}])*?"][a || 0]; return d((c || "") + b.open + f + b.close + (e || "")) }, escape: function (a) { return String(a || "").replace(/&(?!#?[a-zA-Z0-9]+;)/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/'/g, "&#39;").replace(/"/g, "&quot;") }, error: function (a, b) { var c = "Laytpl Error："; return "object" == typeof console && console.error(c + a + "\n" + (b || "")), c + a } }, d = c.exp, e = function (a) { this.tpl = a }; e.pt = e.prototype, e.pt.parse = function (a, e) { var f = this, g = a, h = d("^" + b.open + "#", ""), i = d(b.close + "$", ""); a = a.replace(/[\r\t\n]/g, " ").replace(d(b.open + "#"), b.open + "# ").replace(d(b.close + "}"), "} " + b.close).replace(/\\/g, "\\\\").replace(/(?="|')/g, "\\").replace(c.query(), function (a) { return a = a.replace(h, "").replace(i, ""), '";' + a.replace(/\\/g, "") + '; view+="' }).replace(c.query(1), function (a) { var c = '"+('; return a.replace(/\s/g, "") === b.open + b.close ? "" : (a = a.replace(d(b.open + "|" + b.close), ""), /^=/.test(a) && (a = a.replace(/^=/, ""), c = '"+_escape_('), c + a.replace(/\\/g, "") + ')+"') }), a = '"use strict";var view = "' + a + '";return view;'; try { return f.cache = a = new Function("d, _escape_", a), a(e, c.escape) } catch (j) { return delete f.cache, c.error(j, g) } }, e.pt.render = function (a, b) { var e, d = this; return a ? (e = d.cache ? d.cache(a, c.escape) : d.parse(d.tpl, a), b ? (b(e), void 0) : e) : c.error("no data") }, f = function (a) { return "string" != typeof a ? c.error("Template not found") : new e(a) }, f.config = function (a) { a = a || {}; for (var c in a) b[c] = a[c] }, f.v = "1.1", "function" == typeof define ? define(function () { return f }) : "undefined" != typeof exports ? module.exports = f : window.laytpl = f }();
; !function (a, b) { "use strict"; var c, d, e = { getPath: function () { var a = document.scripts, b = a[a.length - 1], c = b.src; if (!b.getAttribute("merge")) return c.substring(0, c.lastIndexOf("/") + 1) }(), enter: function (a) { 13 === a.keyCode && a.preventDefault() }, config: {}, end: {}, btn: ["&#x786E;&#x5B9A;", "&#x53D6;&#x6D88;"], type: ["dialog", "page", "iframe", "loading", "tips"] }, f = { v: "2.0", ie6: !!a.ActiveXObject && !a.XMLHttpRequest, index: 0, path: e.getPath, config: function (a, b) { var d = 0; return a = a || {}, f.cache = e.config = c.extend(e.config, a), f.path = e.config.path || f.path, "string" == typeof a.extend && (a.extend = [a.extend]), f.use("skin/layer.css", a.extend && a.extend.length > 0 ? function g() { var c = a.extend; f.use(c[c[d] ? d : d - 1], d < c.length ? function () { return ++d, g }() : b) }() : b), this }, use: function (a, b, d) { var e = c("head")[0], a = a.replace(/\s/g, ""), g = /\.css$/.test(a), h = document.createElement(g ? "link" : "script"), i = "layui_layer_" + a.replace(/\.|\//g, ""); return f.path ? (g && (h.rel = "stylesheet"), h[g ? "href" : "src"] = /^http:\/\//.test(a) ? a : f.path + a, h.id = i, c("#" + i)[0] || e.appendChild(h), function j() { (g ? 1989 === parseInt(c("#" + i).css("width")) : f[d || i]) ? function () { b && b(); try { g || e.removeChild(h) } catch (a) { } }() : setTimeout(j, 100) }(), this) : void 0 }, ready: function (a, b) { var d = "function" == typeof a; return d && (b = a), f.config(c.extend(e.config, function () { return d ? {} : { path: a } }()), b), this }, alert: function (a, b, d) { var e = "function" == typeof b; return e && (d = b), f.open(c.extend({ content: a, yes: d }, e ? {} : b)) }, confirm: function (a, b, d, g) { var h = "function" == typeof b; return h && (g = d, d = b), f.open(c.extend({ content: a, btn: e.btn, yes: d, cancel: g }, h ? {} : b)) }, msg: function (a, d, g) { var i = "function" == typeof d, j = e.config.skin, k = (j ? j + " " + j + "-msg" : "") || "layui-layer-msg", l = h.anim.length - 1; return i && (g = d), f.open(c.extend({ content: a, time: 3e3, shade: !1, skin: k, title: !1, closeBtn: !1, btn: !1, end: g }, i && !e.config.skin ? { skin: k + " layui-layer-hui", shift: l } : function () { return d = d || {}, (-1 === d.icon || d.icon === b && !e.config.skin) && (d.skin = k + " " + (d.skin || "layui-layer-hui")), d }())) }, load: function (a, b) { return f.open(c.extend({ type: 3, icon: a || 0, shade: .01 }, b)) }, tips: function (a, b, d) { return f.open(c.extend({ type: 4, content: [a, b], closeBtn: !1, time: 3e3, maxWidth: 210 }, d)) } }, g = function (a) { var b = this; b.index = ++f.index, b.config = c.extend({}, b.config, e.config, a), b.creat() }; g.pt = g.prototype; var h = ["layui-layer", ".layui-layer-title", ".layui-layer-main", ".layui-layer-dialog", "layui-layer-iframe", "layui-layer-content", "layui-layer-btn", "layui-layer-close"]; h.anim = ["layui-anim", "layui-anim-01", "layui-anim-02", "layui-anim-03", "layui-anim-04", "layui-anim-05", "layui-anim-06"], g.pt.config = { type: 0, shade: .3, fix: !0, move: h[1], title: "&#x4FE1;&#x606F;", offset: "auto", area: "auto", closeBtn: 1, time: 0, zIndex: 19891014, maxWidth: 360, shift: 0, icon: -1, scrollbar: !0, tips: 2 }, g.pt.vessel = function (a, b) { var c = this, d = c.index, f = c.config, g = f.zIndex + d, i = "object" == typeof f.title, j = f.maxmin && (1 === f.type || 2 === f.type), k = f.title ? '<div class="layui-layer-title" style="' + (i ? f.title[1] : "") + '">' + (i ? f.title[0] : f.title) + "</div>" : ""; return f.zIndex = g, b([f.shade ? '<div class="layui-layer-shade" id="layui-layer-shade' + d + '" times="' + d + '" style="' + ("z-index:" + (g - 1) + "; background-color:" + (f.shade[1] || "#000") + "; opacity:" + (f.shade[0] || f.shade) + "; filter:alpha(opacity=" + (100 * f.shade[0] || 100 * f.shade) + ");") + '"></div>' : "", '<div class="' + h[0] + " " + (h.anim[f.shift] || "") + (" layui-layer-" + e.type[f.type]) + (0 != f.type && 2 != f.type || f.shade ? "" : " layui-layer-border") + " " + (f.skin || "") + '" id="' + h[0] + d + '" type="' + e.type[f.type] + '" times="' + d + '" showtime="' + f.time + '" conType="' + (a ? "object" : "string") + '" style="z-index: ' + g + "; width:" + f.area[0] + ";height:" + f.area[1] + (f.fix ? "" : ";position:absolute;") + '">' + (a && 2 != f.type ? "" : k) + '<div class="layui-layer-content' + (0 == f.type && -1 !== f.icon ? " layui-layer-padding" : "") + (3 == f.type ? " layui-layer-loading" + f.icon : "") + '">' + (0 == f.type && -1 !== f.icon ? '<i class="layui-layer-ico layui-layer-ico' + f.icon + '"></i>' : "") + (1 == f.type && a ? "" : f.content || "") + '</div><span class="layui-layer-setwin">' + function () { var a = j ? '<a class="layui-layer-min" href="javascript:;"><cite></cite></a><a class="layui-layer-ico layui-layer-max" href="javascript:;"></a>' : ""; return f.closeBtn && (a += '<a class="layui-layer-ico ' + h[7] + " " + h[7] + (f.title ? f.closeBtn : 4 == f.type ? "1" : "2") + '" href="javascript:;"></a>'), a }() + "</span>" + (f.btn ? function () { var a = ""; "string" == typeof f.btn && (f.btn = [f.btn]); for (var b = 0, c = f.btn.length; c > b; b++) a += '<a class="' + h[6] + b + '">' + f.btn[b] + "</a>"; return '<div class="' + h[6] + '">' + a + "</div>" }() : "") + "</div>"], k), c }, g.pt.creat = function () { var a = this, b = a.config, g = a.index, i = b.content, j = "object" == typeof i; switch ("string" == typeof b.area && (b.area = "auto" === b.area ? ["", ""] : [b.area, ""]), b.type) { case 0: b.btn = "btn" in b ? b.btn : e.btn[0], f.closeAll("dialog"); break; case 2: var i = b.content = j ? b.content : [b.content || "http://layer.layui.com", "auto"]; b.content = '<iframe scrolling="' + (b.content[1] || "auto") + '" allowtransparency="true" id="' + h[4] + g + '" name="' + h[4] + g + '" onload="this.className=\'\';" class="layui-layer-load" frameborder="0" src="' + b.content[0] + '"></iframe>'; break; case 3: b.title = !1, b.closeBtn = !1, -1 === b.icon && 0 === b.icon, f.closeAll("loading"); break; case 4: j || (b.content = [b.content, "body"]), b.follow = b.content[1], b.content = b.content[0] + '<i class="layui-layer-TipsG"></i>', b.title = !1, b.shade = !1, b.fix = !1, b.tips = "object" == typeof b.tips ? b.tips : [b.tips, !0], b.tipsMore || f.closeAll("tips") } a.vessel(j, function (d, e) { c("body").append(d[0]), j ? function () { 2 == b.type || 4 == b.type ? function () { c("body").append(d[1]) }() : function () { i.parents("." + h[0])[0] || (i.show().addClass("layui-layer-wrap").wrap(d[1]), c("#" + h[0] + g).find("." + h[5]).before(e)) }() }() : c("body").append(d[1]), a.layero = c("#" + h[0] + g), b.scrollbar || h.html.css("overflow", "hidden").attr("layer-full", g) }).auto(g), 2 == b.type && f.ie6 && a.layero.find("iframe").attr("src", i[0]), c(document).off("keydown", e.enter).on("keydown", e.enter), 4 == b.type ? a.tips() : a.offset(), b.fix && d.on("resize", function () { a.offset(), (/^\d+%$/.test(b.area[0]) || /^\d+%$/.test(b.area[1])) && a.auto(g), 4 == b.type && a.tips() }), b.time <= 0 || setTimeout(function () { f.close(a.index) }, b.time), a.move().callback() }, g.pt.auto = function (a) { function b(a) { a = g.find(a), a.height(i[1] - j - k - 2 * (0 | parseFloat(a.css("padding")))) } var e = this, f = e.config, g = c("#" + h[0] + a); "" === f.area[0] && f.maxWidth > 0 && (/MSIE 7/.test(navigator.userAgent) && f.btn && g.width(g.innerWidth()), g.outerWidth() > f.maxWidth && g.width(f.maxWidth)); var i = [g.innerWidth(), g.innerHeight()], j = g.find(h[1]).outerHeight() || 0, k = g.find("." + h[6]).outerHeight() || 0; switch (f.type) { case 2: b("iframe"); break; default: "" === f.area[1] ? f.fix && i[1] >= d.height() && (i[1] = d.height(), b("." + h[5])) : b("." + h[5]) } return e }, g.pt.offset = function () { var a = this, b = a.config, c = a.layero, e = [c.outerWidth(), c.outerHeight()], f = "object" == typeof b.offset; a.offsetTop = (d.height() - e[1]) / 2, a.offsetLeft = (d.width() - e[0]) / 2, f ? (a.offsetTop = b.offset[0], a.offsetLeft = b.offset[1] || a.offsetLeft) : "auto" !== b.offset && (a.offsetTop = b.offset, "rb" === b.offset && (a.offsetTop = d.height() - e[1], a.offsetLeft = d.width() - e[0])), b.fix || (a.offsetTop = /%$/.test(a.offsetTop) ? d.height() * parseFloat(a.offsetTop) / 100 : parseFloat(a.offsetTop), a.offsetLeft = /%$/.test(a.offsetLeft) ? d.width() * parseFloat(a.offsetLeft) / 100 : parseFloat(a.offsetLeft), a.offsetTop += d.scrollTop(), a.offsetLeft += d.scrollLeft()), c.css({ top: a.offsetTop, left: a.offsetLeft }) }, g.pt.tips = function () { var a = this, b = a.config, e = a.layero, f = [e.outerWidth(), e.outerHeight()], g = c(b.follow); g[0] || (g = c("body")); var i = { width: g.outerWidth(), height: g.outerHeight(), top: g.offset().top, left: g.offset().left }, j = e.find(".layui-layer-TipsG"), k = b.tips[0]; b.tips[1] || j.remove(), i.autoLeft = function () { i.left + f[0] - d.width() > 0 ? (i.tipLeft = i.left + i.width - f[0], j.css({ right: 12, left: "auto" })) : i.tipLeft = i.left }, i.where = [function () { i.autoLeft(), i.tipTop = i.top - f[1] - 10, j.removeClass("layui-layer-TipsB").addClass("layui-layer-TipsT").css("border-right-color", b.tips[1]) }, function () { i.tipLeft = i.left + i.width + 10, i.tipTop = i.top, j.removeClass("layui-layer-TipsL").addClass("layui-layer-TipsR").css("border-bottom-color", b.tips[1]) }, function () { i.autoLeft(), i.tipTop = i.top + i.height + 10, j.removeClass("layui-layer-TipsT").addClass("layui-layer-TipsB").css("border-right-color", b.tips[1]) }, function () { i.tipLeft = i.left - f[0] - 10, i.tipTop = i.top, j.removeClass("layui-layer-TipsR").addClass("layui-layer-TipsL").css("border-bottom-color", b.tips[1]) }], i.where[k - 1](), 1 === k ? i.top - (d.scrollTop() + f[1] + 16) < 0 && i.where[2]() : 2 === k ? d.width() - (i.left + i.width + f[0] + 16) > 0 || i.where[3]() : 3 === k ? i.top - d.scrollTop() + i.height + f[1] + 16 - d.height() > 0 && i.where[0]() : 4 === k && f[0] + 16 - i.left > 0 && i.where[1](), e.find("." + h[5]).css({ "background-color": b.tips[1], "padding-right": b.closeBtn ? "30px" : "" }), e.css({ left: i.tipLeft, top: i.tipTop }) }, g.pt.move = function () { var a = this, b = a.config, e = { setY: 0, moveLayer: function () { var a = e.layero, b = parseInt(a.css("margin-left")), c = parseInt(e.move.css("left")); 0 === b || (c -= b), "fixed" !== a.css("position") && (c -= a.parent().offset().left, e.setY = 0), a.css({ left: c, top: parseInt(e.move.css("top")) - e.setY }) } }, f = a.layero.find(b.move); return b.move && f.attr("move", "ok"), f.css({ cursor: b.move ? "move" : "auto" }), c(b.move).on("mousedown", function (a) { if (a.preventDefault(), "ok" === c(this).attr("move")) { e.ismove = !0, e.layero = c(this).parents("." + h[0]); var f = e.layero.offset().left, g = e.layero.offset().top, i = e.layero.outerWidth() - 6, j = e.layero.outerHeight() - 6; c("#layui-layer-moves")[0] || c("body").append('<div id="layui-layer-moves" class="layui-layer-moves" style="left:' + f + "px; top:" + g + "px; width:" + i + "px; height:" + j + 'px; z-index:2147483584"></div>'), e.move = c("#layui-layer-moves"), b.moveType && e.move.css({ visibility: "hidden" }), e.moveX = a.pageX - e.move.position().left, e.moveY = a.pageY - e.move.position().top, "fixed" !== e.layero.css("position") || (e.setY = d.scrollTop()) } }), c(document).mousemove(function (a) { if (e.ismove) { var c = a.pageX - e.moveX, f = a.pageY - e.moveY; if (a.preventDefault(), !b.moveOut) { e.setY = d.scrollTop(); var g = d.width() - e.move.outerWidth(), h = e.setY; 0 > c && (c = 0), c > g && (c = g), h > f && (f = h), f > d.height() - e.move.outerHeight() + e.setY && (f = d.height() - e.move.outerHeight() + e.setY) } e.move.css({ left: c, top: f }), b.moveType && e.moveLayer(), c = f = g = h = null } }).mouseup(function () { try { e.ismove && (e.moveLayer(), e.move.remove(), b.moveEnd && b.moveEnd()), e.ismove = !1 } catch (a) { e.ismove = !1 } }), a }, g.pt.callback = function () { function a() { var a = g.cancel && g.cancel(b.index); a === !1 || f.close(b.index) } var b = this, d = b.layero, g = b.config; b.openLayer(), g.success && (2 == g.type ? d.find("iframe")[0].onload = function () { this.className = "", g.success(d, b.index) } : g.success(d, b.index)), f.ie6 && b.IE6(d), d.find("." + h[6]).children("a").on("click", function () { var e = c(this).index(); g["btn" + (e + 1)] && g["btn" + (e + 1)](b.index, d), 0 === e ? g.yes ? g.yes(b.index, d) : f.close(b.index) : 1 === e ? a() : g["btn" + (e + 1)] || f.close(b.index) }), d.find("." + h[7]).on("click", a), g.shadeClose && c("#layui-layer-shade" + b.index).on("click", function () { f.close(b.index) }), d.find(".layui-layer-min").on("click", function () { f.min(b.index, g), g.min && g.min(d) }), d.find(".layui-layer-max").on("click", function () { c(this).hasClass("layui-layer-maxmin") ? (f.restore(b.index), g.restore && g.restore(d)) : (f.full(b.index, g), g.full && g.full(d)) }), g.end && (e.end[b.index] = g.end) }, e.reselect = function () { c.each(c("select"), function (a, b) { var d = c(this); d.parents("." + h[0])[0] || 1 == d.attr("layer") && c("." + h[0]).length < 1 && d.removeAttr("layer").show(), d = null }) }, g.pt.IE6 = function (a) { function b() { a.css({ top: f + (e.config.fix ? d.scrollTop() : 0) }) } var e = this, f = a.offset().top; b(), d.scroll(b), c("select").each(function (a, b) { var d = c(this); d.parents("." + h[0])[0] || "none" === d.css("display") || d.attr({ layer: "1" }).hide(), d = null }) }, g.pt.openLayer = function () { var a = this; f.zIndex = a.config.zIndex, f.setTop = function (a) { var b = function () { f.zIndex++, a.css("z-index", f.zIndex + 1) }; return f.zIndex = parseInt(a[0].style.zIndex), a.on("mousedown", b), f.zIndex } }, e.record = function (a) { var b = [a.outerWidth(), a.outerHeight(), a.position().top, a.position().left + parseFloat(a.css("margin-left"))]; a.find(".layui-layer-max").addClass("layui-layer-maxmin"), a.attr({ area: b }) }, e.rescollbar = function (a) { h.html.attr("layer-full") == a && (h.html[0].style.removeProperty ? h.html[0].style.removeProperty("overflow") : h.html[0].style.removeAttribute("overflow"), h.html.removeAttr("layer-full")) }, f.getChildFrame = function (a, b) { return b = b || c("." + h[4]).attr("times"), c("#" + h[0] + b).find("iframe").contents().find(a) }, f.getFrameIndex = function (a) { return c("#" + a).parents("." + h[4]).attr("times") }, f.iframeAuto = function (a) { if (a) { var b = f.getChildFrame("html", a).outerHeight(), d = c("#" + h[0] + a), e = d.find(h[1]).outerHeight() || 0, g = d.find("." + h[6]).outerHeight() || 0; d.css({ height: b + e + g }), d.find("iframe").css({ height: b }) } }, f.iframeSrc = function (a, b) { c("#" + h[0] + a).find("iframe").attr("src", b) }, f.style = function (a, b) { var d = c("#" + h[0] + a), f = d.attr("type"), g = d.find(h[1]).outerHeight() || 0, i = d.find("." + h[6]).outerHeight() || 0; (f === e.type[1] || f === e.type[2]) && (d.css(b), f === e.type[2] && d.find("iframe").css({ height: parseFloat(b.height) - g - i })) }, f.min = function (a, b) { var d = c("#" + h[0] + a), g = d.find(h[1]).outerHeight() || 0; e.record(d), f.style(a, { width: 180, height: g, overflow: "hidden" }), d.find(".layui-layer-min").hide(), "page" === d.attr("type") && d.find(h[4]).hide(), e.rescollbar(a) }, f.restore = function (a) { var b = c("#" + h[0] + a), d = b.attr("area").split(","); b.attr("type"); f.style(a, { width: parseFloat(d[0]), height: parseFloat(d[1]), top: parseFloat(d[2]), left: parseFloat(d[3]), overflow: "visible" }), b.find(".layui-layer-max").removeClass("layui-layer-maxmin"), b.find(".layui-layer-min").show(), "page" === b.attr("type") && b.find(h[4]).show(), e.rescollbar(a) }, f.full = function (a) { var b, g = c("#" + h[0] + a); e.record(g), h.html.attr("layer-full") || h.html.css("overflow", "hidden").attr("layer-full", a), clearTimeout(b), b = setTimeout(function () { var b = "fixed" === g.css("position"); f.style(a, { top: b ? 0 : d.scrollTop(), left: b ? 0 : d.scrollLeft(), width: d.width(), height: d.height() }), g.find(".layui-layer-min").hide() }, 100) }, f.title = function (a, b) { var d = c("#" + h[0] + (b || f.index)).find(h[1]); d.html(a) }, f.close = function (a) { var b = c("#" + h[0] + a), d = b.attr("type"); if (b[0]) { if (d === e.type[1] && "object" === b.attr("conType")) { b.children(":not(." + h[5] + ")").remove(); for (var g = 0; 2 > g; g++) b.find(".layui-layer-wrap").unwrap().hide() } else { if (d === e.type[2]) try { var i = c("#" + h[4] + a)[0]; i.contentWindow.document.write(""), i.contentWindow.close(), b.find("." + h[5])[0].removeChild(i) } catch (j) { } b[0].innerHTML = "", b.remove() } c("#layui-layer-moves, #layui-layer-shade" + a).remove(), f.ie6 && e.reselect(), e.rescollbar(a), c(document).off("keydown", e.enter), "function" == typeof e.end[a] && e.end[a](), delete e.end[a] } }, f.closeAll = function (a) { c.each(c("." + h[0]), function () { var b = c(this), d = a ? b.attr("type") === a : 1; d && f.close(b.attr("times")), d = null }) }, e.run = function () { c = jQuery, d = c(a), h.html = c("html"), f.open = function (a) { var b = new g(a); return b.index } }, "function" == typeof define ? define(function () { return e.run(), f }) : function () { a.layer = f, e.run(), f.use("skin/layer.css") }() }(window);

/*
    核心库组件
    By 李科笠 2016年1月28日 14:08:08
*/
;
(function ($) {
    layer.config({
        skin: 'layui-layer-lan'
    });
    var isLoad;
    var textStyle = {
        left: "text-align: left;",
        right: "text-align: right;",
        center: "text-align: center;",
        blue: "color:blue;",
        red: "color:red;",
        black: "color:black;"
    };

    function initsetTableDefault(obj) {
        return $.extend(true, {}, {
            lower: {
                align: textStyle.right,
                color: textStyle.red,
                values: -20
            },
            upper: {
                align: textStyle.right,
                color: textStyle.blue,
                values: 20
            },
            nomal: {
                align: textStyle.right,
                color: textStyle.black
            },
            nomalCenter: {
                align: textStyle.center,
                color: textStyle.black
            }
        }, obj);
    };

    function urlParametBuild(param, key, encode) {
        if (param == null) return '';
        var paramStr = '';
        var t = typeof (param);
        if (t == 'string' || t == 'number' || t == 'boolean') {
            paramStr += '&' + key + '=' + ((encode == null || encode) ? escape(param) : param);
        } else {
            for (var i in param) {
                var k = key == null ? i : key + (param instanceof Array ? '[' + i + ']' : '.' + i);
                paramStr += urlParametBuild(param[i], k, encode);
            }
        }
        return paramStr;
    }

    $.CBD = {
        /**
         * 调试日志，兼容IE所有版本
         * @param {} obj 
         * @returns {} 
         */
        debug: function (obj) {
            try {
                console.debug(obj);
            } catch (e) {
                alert(obj);
            }
        },
        /**
         * 非空执行
         * @param {} obj 判断非空的变量
         * @param {} f 非空执行的方法
         * @returns {} 
         */
        isNotNull: function (obj, f) {
            if (typeof (obj) != "undefined" && obj != null) {
                if (typeof (f) == "function") {
                    f();
                } else {
                    CBD.showAlertBox("isNotNull方法需要一个可执行的方法。");
                }
            }
        },
        textStyle: function () { return textStyle; },
        /**
         * 弹出加载层
         * @returns {} 
         */
        showLoad: function () {
            isLoad = layer.load(3, { shade: [0.3, '#393D49'] });
            return this;
        },
        /**
         * 关闭加载层
         * @returns {} 
         */
        hiddenLoad: function () {
            layer.close(isLoad);
            return this;
        },
        /**
         * 弹出自定义询问
         * @param {} a 正文内容
         * @param {} b 配置 【可忽略， {icon: 3, title:'提示'} 】
         * @param {} c yes回调方法
         * @returns {} cancel回调方法
         */
        showconfirm: function (a, b, c, d) {
            layer.confirm(a, b, c, d);
        },
        /**
         * 弹出带标题信息
         * @param {} message 
         * @returns {} 
         */
        showAlertBox: function (message) {
            layer.open({
                title: '消息',
                shadeClose: true,
                offset: '123px',
                content: message
            });
        },
        /**
         * 弹出新的游览器窗口，并居中
         * @param {} url 
         * @param {} name 
         * @returns {} 
         */
        showAlertWindow: function (url, name) {
            var iWidth = 400;  //弹出窗口的宽度;
            var iHeight = 300; //弹出窗口的高度;
            var iTop = (window.screen.height - 30 - iHeight) / 2;
            var iLeft = (window.screen.width - 10 - iWidth) / 2;
            window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
        },
        /**
         * 弹出错误消息
         * @param {} message 
         * @returns {} 
         */
        showErrorBox: function (message) {
            layer.open({
                icon: 2,
                offset: '123px',
                title: '错误提示',
                shadeClose: true,
                content: message
            });
        },
        /**
         * 弹出简单信息
         * @param {} message 
         * @returns {} 
         */
        showMessage: function (message) {
            layer.msg(message);
        },
        /**
         * 捕获页面元素，并全屏
         * @param {} obj 目标
         * @param {} title 标题
         * @returns {} 
         */
        captureDiv: function (obj, title) {
            layer.open({
                type: 1,
                skin: 'cbd-class',
                shade: false,
                title: title || false,
                content: obj,
                cancel: function (index) {
                    layer.close(index);
                    this.content.show();
                },
                success: function (layero, index) {
                    layer.full(index);
                }
            });
        },
        /**
         * 捕获Easyui - DataGrid表格，并最大化
         * @param {} obj 
         * @returns {} 
         */
        captureGridTable: function (obj) {
            var content = $(obj).datagrid('getPanel');
            var title = $("title").text() ? $("title").text() : "表格详情";
            CBD.captureDiv(content, title);
        },
        /**
         * 检索URL中的参数，正则方式完成 
         * @param {} name 
         * @returns {} 
         */
        getQueryString: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); //解码
            return null;
        },
        /**
         * 表单序列化成对象
         * @param {} obj DOM对象
         * @returns {} 
         */
        formSerializeObject: function (obj) {
            var o = {};
            var a = obj.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        },
        /**
         * Ajax发送异步post请求
         * @param {} requestData 在发送前会转换为json字符串
         * @param {} url 
         * @param {} successFunc 成功后执行的方法
         * @param {} doOther 回调方法
         * @returns {} 
         */
        ajaxData: function (requestData, url, successFunc, doOther, error) {
            var data;
            if (typeof (requestData) === "string") {
                data = requestData;
            } else {
                data = JSON.stringify(requestData);
            }
            $.ajax({
                type: "post",
                url: url,
                async: true,
                datatype: "json",
                contentType: "application/json",
                data: data,
                //beforeSend: function () { $.showLoad(); },
                success: function (response) {
                    try {
                        var d;
                        try {
                            d = JSON.parse(response.d);
                        } catch (e) {
                            d = response.d;
                        }
                        successFunc(d);
                    } catch (e) {
                        debugger;
                        $.CBD.showAlertBox("错误路径：" + this.url + "<br />描述：成功获取到数据，但处理过程中出现了错误。<br />错误详情：" + e.message);
                    }
                },
                error: function (message) {
                    try {
                        if (CBD.isNotNull(error)) {
                            error(message);
                        }
                        var errorOmit = "", errorDetail = message.responseText;
                        var showMessage = JSON.parse(message.responseText).Message;
                        if (errorDetail.length > 300) {
                            errorOmit = errorDetail.substr(0, 300) + "...";
                        }
                        setTimeout(layer.open({
                            icon: 2,
                            title: '错误提示【开发者调试】',
                            shadeClose: true,
                            content: "路径：" + this.url
                                + "<br/><span style='color:#FFA500;'><b>错误信息</b>：" + showMessage + "</span>"
                                + "<br/><span style='color:#DC143C;'><b>错误详情</b>：<lable title='" + errorDetail + "' >" + errorOmit + "</lable></span>"
                        }), 1000);

                    } catch (e) {
                        CBD.debug(message);
                        setTimeout(layer.open({
                            icon: 2,
                            title: '错误提示',
                            shadeClose: true,
                            content: "路径：" + this.url
                                + "<br/>异步调用错误<br/>" + e
                        }), 1000);
                    }
                },
                complete: function () {
                    $.CBD.hiddenLoad();
                    if (doOther) {
                        doOther();
                    }
                }
            });
        },
        /**
         * easyui datagride 分页逻辑，假分页
         * By 李科笠 2016年2月1日 10:11:47
         * @param {} targetTable 源表
         * @param {} param 传递给远程服务器的参数对象
         * @param {} success 当检索数据成功的时候会调用该回调函数
         * @param {} error 当检索数据失败的时候会调用该回调函数
         * @param {} data 进行分页的数据源
         * @returns {} 
         */
        tableLoader: function (targetTable, param, success, error, data) {
            try {
                var that = $(targetTable);
                var cache = that.data().datagrid.cache;
                if (!cache) {
                    that.data().datagrid['cache'] = data;
                    success(bulidData(data));
                } else {
                    success(bulidData(cache));
                }
                function bulidData(data) {
                    //debugger;
                    var temp = $.extend({}, data);
                    var tempRows = [];
                    var start = (param.page - 1) * parseInt(param.rows);
                    var end = start + parseInt(param.rows);
                    var rows = data.rows;
                    for (var i = start; i < end; i++) {
                        if (rows[i]) {
                            tempRows.push(rows[i]);
                        } else {
                            break;
                        }
                    }
                    temp.rows = tempRows;
                    return temp;
                }
            } catch (e) {
                CBD.showErrorBox('似乎是easyui组件出现错误。<br />错误详情：' + e);
            }
        },
        /**
         * table中居中情况
         * @param {} text 
         * @param {} align 
         * @returns {} 
         */
        textAlign: function (text, align, display) {
            display = display || 'block';
            return "<div style='display: " + display + ";text-align:" + align + " !important'>" + text + "</div>";
        },
        /**
         * 正负值判断，自动添加百分号，颜色。自动补齐参数。
         * @param {} value 值
         * @param {} conf 配置默认染色区间、颜色
         * @param {} isDyeColor 是否染色
         * @returns {} 
         */
        tableTextCheck: function (value, conf, isDyeColor) {
            var config;
            function deyColor() {
                return {
                    lower: {
                        align: textStyle.right,
                        color: textStyle.black,
                        values: -20
                    },
                    upper: {
                        align: textStyle.right,
                        color: textStyle.black,
                        values: 20
                    },
                    nomal: {
                        align: textStyle.right,
                        color: textStyle.black
                    },
                    nomalCenter: {
                        align: textStyle.center,
                        color: textStyle.black
                    }
                };
            }
            if (typeof (conf) === "object") {
                config = initsetTableDefault(conf);
            } else {
                config = initsetTableDefault({});
            }

            if (typeof (conf) === "boolean") {
                config = deyColor();
            }
            if (typeof (isDyeColor) === "boolean" && isDyeColor === false) {
                config = deyColor();
            }

            if (value >= config.upper.values) {
                return "<div style='" + config.upper.color + config.upper.align + "'>" + value + "%</div>";
            } else if (value <= config.lower.values) {
                return "<div style='" + config.lower.color + config.lower.align + "'>" + value + "%</div>";
            } else {
                if (value === 0 || value == null) {
                    return "<div style='" + config.nomalCenter.align + "'>-</div>";
                }
                else if (value === '') {
                    return '';
                } else {
                    return "<div style='" + config.nomal.align + "'>" + value + "%</div>";
                }
            }
        },
        /**
         * 保留小数
         * @param {} num 
         * @param {} point 
         * @returns {} 
         */
        toFixed: function (num, point) {
            if (num === 0) {
                return 0;
            }
            return new Number(num).toFixed(point);
        },
        /**
         * 将数据表格中0改为-
         * @param {} value 
         * @returns {} 
         */
        tableTextZero: function (value) {
            var config = initsetTableDefault({});
            if (value == null) {
                return "<div style='" + config.nomalCenter.align + "'>-</div>";
            } else {
                return "<div style='" +config.nomal.align + "'>" + value + "</div>";
            }
            //if (value === 0) {
            //    return "<div style='" + config.nomalCenter.align + "'>-</div>";
            //} else {
            //    return "<div style='" + config.nomal.align + "'>" + value + "</div>";
            //}
        },
        /**
         * 打开一个新的连接，URL自动编码，根据全局配置，打开iframe或者跳转页面
         * @param {} url 
         * @param {} paramete 
         * @returns {} 
         */
        openNewPage: function (url, paramete, isOpenByMoudel) {
            //iframe的url
            var iframeurl = url + CBD.urlEncode(paramete, null, true);
            if (typeof (isOpenByMoudel) == "undefined") {
                window.location.href = iframeurl;
            } else {
                layer.open({
                    type: 2,
                    shadeClose: true,
                    scrollbar: false,
                    fix: false,
                    maxmin: true,
                    shade: 0.5,
                    //skin: 'cbd-class',
                    title: '二级窗口',
                    offset: '0px',
                    area: ['100%', '100%'],
                    content: iframeurl
                });
            }
        },
        /**
         * param 将要转为URL参数字符串的对象
         * key URL参数字符串的前缀
         * encode true/false 是否进行URL编码,默认为true
         * return URL参数字符串
         */
        urlEncode: function (param, key, encode) {
            return urlParametBuild(param, key, encode).replace(/&/, '?');
        },
        /**
         * 自定义模板引擎：
         * 根据自定义模板生成页面
         * @param {} sourceId 模板ID
         * @param {} targetView 容器ID
         * @param {} data 加载数据源
         * @returns {} 
         */
        buildByTemplate: function (sourceId, targetView, data) {
            var gettpl = document.getElementById(sourceId).innerHTML;
            laytpl(gettpl).render(data, function (html) {
                document.getElementById(targetView).innerHTML = html;
            });
        },
        /**
         * 导航菜单操作
         */
        navigate: {
            Add: function (title, path) {
                var foreachJson = function (data) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].name === title) {
                            return true;
                        }
                    }
                    return false;
                };
                if (!$.cookie('navigate')) {
                    $.cookie('navigate', JSON.stringify([{ name: '首页', path: '/Website/Index.aspx' }]));
                }

                var menuData = JSON.parse($.cookie('navigate'));
                debugger;
                if (foreachJson(menuData)) {
                    return;
                }
                var navigateMenu = { name: title, path: path };
                menuData.push(navigateMenu);
                $.cookie('navigate', JSON.stringify(menuData));
            },
            /**
             * 导航菜单生成
             * @returns {} 
             */
            Build: function () {
                if ($.cookie('navigate') == '') {
                    return;
                }
                var menuData = JSON.parse($.cookie('navigate'));
                var liHtml = '';
                for (var i = 0; i < menuData.length; i++) {
                    liHtml += '<li><a href="' + menuData[i].path + '">' + menuData[i].name + '</a></li>';
                }
                $('div.place ul.placeul').html(liHtml);
            }
        },
        /**
         * 数学计算
         */
        math: {
            /**
             * 转换为亿元，并保留两位小数
             * @param {} value 
             * @returns {} 
             */
            toBillion: function (value) {
                if (!value || value === 0) {
                    return 0;
                }
                var a = CBD.toFixed(value / 100000000, 2);
                if (a == 0.00) {
                    a = 0;
                }
                return a;
            },
            /**
             * 百分比转换，并着色，不进行百分比计算
             * @param {} value 
             * @param {} conf 
             * @returns {} 
             */
            toPercent: function (value, conf) {
                var config = initsetTableDefault(conf);
                if (value >= config.upper.values) {
                    return "<div style='" + config.upper.color + config.upper.align + "'>" + value + "%</div>";
                } else if (value <= config.lower.values) {
                    return "<div style='" + config.lower.color + config.lower.align + "'>" + value + "%</div>";
                } else {
                    if (value === 0) {
                        return "<div style='" + config.nomal.align + "'>0</div>";
                    }
                    else if (value === '' || !value) {
                        return "<div style='" + config.nomalCenter.align + "'>-</div>";
                    } else {
                        return "<div style='" + config.nomal.align + "'>" + value + "%</div>";
                    }
                }
            },
            /**
             * 百分比转换，并进行百分比计算
             * @param {} value 
             * @returns {} 
             */
            toPercentByCalculate: function (value) {
                console.debug(value);
                var config = initsetTableDefault({});
                return "<div style='" + config.nomal.align + "'>" + CBD.toFixed(value * 100, 2) + "%</div>";
            }
        },
        /**
         * DOM元素操作
         */
        dom: {
            selSet: function (startTime, endTime) {

            }
        },
        /**
         * DOM简单动画
         */
        domAnimation: {
            /**
             * 简单数字滚动
             * @param {} id DOM的id
             * @param {} startVal 开始值
             * @param {} endVal 结束值
             * @param {} decimals 保留小数位
             * @param {} duration 延迟时间
             * @returns {} 
             */
            countUp: function (id, startVal, endVal, decimals, duration) {
                try {
                    new CountUp(id, startVal, endVal, decimals, duration, {
                        useEasing: true,
                        useGrouping: true,
                        separator: ',',
                        decimal: '.',
                        prefix: '',
                        suffix: ''
                    }).start();
                } catch (e) {
                    CBD.log(e);
                    $("#" + id).text(endVal);
                }
            }
        },
        /**
         * 初始化操作
         */
        initialization: {
            /**
             * 初始化时间
             * @returns {} 
             */
            start: function () {
                //初始化select
                //debugger;
                var startTime = CBD.getQueryString('startTime');
                var endTime = CBD.getQueryString('endTime') || '';
                if (startTime != null) {
                    var set = function (time1, time2) {
                        $('.sel_beginTime').val(time1);
                        $('.sel_endTime').val(time2);
                    }
                    if (endTime == "") {
                        set(startTime, endTime);
                    } else {
                        startTime < endTime ? set(startTime, endTime) : set(endTime, startTime);
                    }
                }
                return {
                    beginttime: $('.sel_beginTime').val(),
                    endtime: $('.sel_endTime').val()
                };
            },
            /**
             * 输出根据时间下拉框选择的 年份，时间 
             * outType 数组
             * @returns {} ['带年份的日期','不带年份的日期']
             */
            startTimeList: function ($beginTime, $endTime) {
                var $timeInterval, $timeIntervalNoYear;
                CBD.isNotNull($beginTime, function () {
                    if ($beginTime.length >= 6 && $beginTime.length >= 6) {
                        if ($endTime == 'undefined'||$endTime==''||$endTime==null) { 
                            return;
                        } 
                        $timeInterval = $beginTime.substring(0, 4) + "年" + parseInt($beginTime.substring(4, 6)) + "-" + parseInt($endTime.substring(4, 6)) + "月";
                        $timeIntervalNoYear = parseInt($beginTime.substring(4, 6)) + "-" + parseInt($endTime.substring(4, 6)) + "月";
                    }
                    if ($beginTime.length === 4) {
                        $timeInterval = $beginTime;
                    }
                });
                return new Array($timeInterval, $timeIntervalNoYear);
            }
        }
    };
})(jQuery); var CBD = $.CBD;
var $beginTime, $endTime, $timeInterval, $timeIntervalNoYear;
$(function () {
    var time = CBD.initialization.start();
    $beginTime = time.beginttime;
    $endTime = time.endtime;
    var gather = CBD.initialization.startTimeList($beginTime, $endTime);
    $timeInterval = gather[0];        //1-**月
    $timeIntervalNoYear = gather[1];  //年
});