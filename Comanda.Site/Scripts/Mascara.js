function MascaraPreco(objeto)
{    
    $(objeto).keyup(function (event) {

        var value = $(this).val();
        for (var x in value) {
            value = value.replace(",", '');
            value = value.replace(".", '');
        }

        var mask = "9.999.999,99";
        var mmask = "";
        var xmask = "";
        var patt = new RegExp("[0-9]");
        j = 1;
        h = 0;
        for (var i = mask.length - 1; i >= 0; i--) {
            var vv = '';
            if (!patt.test(mask[i])) {
                vv = mask[i];
                mmask = vv + mmask;
                continue;
            }
            else {
                h = value.length - j;
                vv = value[h];
                vv = vv === undefined ? "?" : vv;
                mmask = vv + mmask;
                j++;
            }
        }

        for (var i = mmask.length - 1; i >= 0; i--) {
            if (mmask[i] == "?")
                break;

            xmask = mmask[i] + xmask;
        }


        value = parseInt(value).toString();

        if (value.length == 1) {
            xmask = "0,0" + value;
        }
        else if (value.length == 2) {
            xmask = "0," + value;
        }

        if (xmask[0] == "," || xmask[0] == ".") {
            xmask = xmask.substring(1, xmask.length);
        }
        else if (xmask.substring(0, 2) == "0.") {
            xmask = xmask.substring(2, xmask.length);
        }

        if (value.length > 2 && xmask[0] == "0") {
            xmask = xmask.substring(1, xmask.length);
        }

        $(this).val(xmask);

    }).keydown(function (event) {
        if (event.key.length == 1) {
            var patt = new RegExp("[0-9]");
            if (!patt.test(event.key)) {
                event.preventDefault();
            }
        }
    });
}
function MascaraData(objeto) {
    $(objeto).keyup(function (event) {

        var value = $(this).val();
        for (var x in value) {
            value = value.replace("/", '');            
        }

        value = value.substring(0, 8);
        var xvalue = "";
        var i = 0;

        var mask = "99/99/9999";
        for (var x in mask) {
            if (mask[x] == "9") {
                xvalue += value[i] !== undefined ? value[i] : "";                
                i++;
            }
            else
            {
                xvalue += mask[x];                
            }
        }
        
        $(this).val(xvalue);

    }).keydown(function (event) {
        if (event.key.length == 1) {
            var patt = new RegExp("[0-9]");
            if (!patt.test(event.key)) {
                event.preventDefault();
            }
        }
    });
}
function MascaraNumero(objeto)
{
    $(objeto).keyup(function (event) {
                

    }).keydown(function (event) {
        if (event.key.length == 1) {
            var patt = new RegExp("[0-9]");
            if (!patt.test(event.key)) {
                event.preventDefault();
            }
        }
    });
}
function MascaraNome(objeto)
{
    $(objeto).keyup(function (event) {
        $(this).val($(this).val().toUpperCase());

    }).keydown(function (event) {        
        if (event.key.length == 1) {
            var text = event.key.toLowerCase();            
            var patt = new RegExp("^[a-z\\s\.\ç\á\ó\ã\õ]*$", "g");
            if (!patt.test(text)) {                
                event.preventDefault();
            }
        }
    });
}
function MascaraDinheiro(valor) {
    return valor.format(2, 3, '.', ',');
}
function MascaraMaiuscula(objeto) {
    $(objeto).keyup(function (event) {
        $(this).val($(this).val().toUpperCase());

    })
}

Number.prototype.format = function (n, x, s, c) {
    var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\D' : '$') + ')',
        num = this.toFixed(Math.max(0, ~~n));

    return (c ? num.replace('.', c) : num).replace(new RegExp(re, 'g'), '$&' + (s || ','));
}