var test = null;
    let app = new Vue({
        el: '#app',
        data: {
            color: "white",
            status: true,
        }
    })
    function changestatus() {
        app.status = !app.status;
    }
    function setcolor(obj) {
        app.status = false;
        // floor -----------------------------------------------------------------
        if (obj.classList[1] == 'nf') {
            app.color = "white";
            app.status = true;
        } else if (obj.classList[1] == 'dl') {
            app.color = "black";
            app.status = true;
        } else if (obj.classList[1] == 'atkp') {
            app.color = "red";
            app.status = true;
        } else if (obj.classList[1] == 'atkn') {
            app.color = "cyan";
            app.status = true;
        } else if (obj.classList[1] == 'defp') {
            app.color = "gray";
            app.status = true;
        } else if (obj.classList[1] == 'defn') {
            app.color = "brown";
            app.status = true;
        } else if (obj.classList[1] == 'poison') {
            app.color = "purple";
            app.status = true;
        }
        // medicine -----------------------------------------------------------------
        else if (obj.classList[1] == 'spr') {
            app.color = "chartreuse";
        } else if (obj.classList[1] == 'hm') {
            app.color = "pink";
        } else if (obj.classList[1] == 'nd') {
            app.color = "yellow";
        } else if (obj.classList[1] == 'dft') {
            app.color = "hotpink";
        } else if (obj.classList[1] == 'ap') {
            app.color = "turquoise";
        } else if (obj.classList[1] == 'ad') {
            app.color = "violet";
        } else if (obj.classList[1] == 'mpm') {
            app.color = "coral";
        } else if (obj.classList[1] == 'fgc') {
            app.color = "indianred";
        } else if (obj.classList[1] == 'bt') {
            app.color = "darkblue";
        } else if (obj.classList[1] == 'blt') {
            app.color = "crimson";
        } else if (obj.classList[1] == 'bnt') {
            app.color = "chocolate";
        } else if (obj.classList[1] == 'hero') {
            app.color = "gold";
        }
        // disease -----------------------------------------------------------------
        else if (obj.classList[1] == 'sa') {
            app.color = "olivedrab";
        } else if (obj.classList[1] == 'hah') {
            app.color = "darkcyan";
        } else if (obj.classList[1] == 'rn') {
            app.color = "green";
        } else if (obj.classList[1] == 'if') {
            app.color = "lightsteelblue";
        } else if (obj.classList[1] == 'ich') {
            app.color = "peru";
        } else if (obj.classList[1] == 'acne') {
            app.color = "navajowhite";
        } else if (obj.classList[1] == 'musp') {
            app.color = "palevioletred";
        } else if (obj.classList[1] == 'skf') {
            app.color = "lightyellow";
        } else if (obj.classList[1] == 'delo') {
            app.color = "mediumslateblue";
        }
        document.getElementsByClassName('nowc')[0].style.backgroundColor = app.color;
    }
    function setmap(obj, type) {
        if (app.color == "black") {
            document.getElementById(obj.id.slice(5)).childNodes[2].childNodes[2].style.backgroundColor = app.color;
        }
        if (app.status) {
            setWallColor(obj, app.color);
        }
        if (type == "floor") {
            obj.style.backgroundColor = app.color;
        }
    }
    function setWallColor(obj, color) {
        document.getElementById(obj.id.slice(5)).childNodes[0].childNodes[0].style.backgroundColor = color;
        document.getElementById(obj.id.slice(5)).childNodes[0].childNodes[2].style.backgroundColor = color;
        document.getElementById(obj.id.slice(5)).childNodes[0].childNodes[4].style.backgroundColor = color;

        document.getElementById(obj.id.slice(5)).childNodes[2].childNodes[0].style.backgroundColor = color;
        document.getElementById(obj.id.slice(5)).childNodes[2].childNodes[4].style.backgroundColor = color;

        document.getElementById(obj.id.slice(5)).childNodes[4].childNodes[0].style.backgroundColor = color;
        document.getElementById(obj.id.slice(5)).childNodes[4].childNodes[2].style.backgroundColor = color;
        document.getElementById(obj.id.slice(5)).childNodes[4].childNodes[4].style.backgroundColor = color;
    }
    function reset() {
        let allfloor = document.getElementsByClassName("floor");
        for (let i = 1; i <= allfloor.length; i++) {
            document.querySelectorAll("#type_floor" + i).forEach(element => {
                element.style.backgroundColor = "black";
            });
        }
    }
    function doCapture() {
        window.scrollTo(0, 0);
        html2canvas(document.getElementById('image')).then(function (canvas) {
            console.log(canvas.toDataURL("image/jpg", 1));
        });
    }