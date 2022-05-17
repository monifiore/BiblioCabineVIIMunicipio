function Evento_LeggiTutto(idEvento, isTutto) {
    var idLeggiMeno = "leggiMeno_" + idEvento;
    var idBtnLeggiMeno = "leggiMenoBtn_" + idEvento;

    var idLeggiTutto = "leggiTutto_" + idEvento;
    var idBtnLeggiTutto = "leggiTuttoBtn_" + idEvento;

    if (isTutto=="True") {
        document.getElementById(idLeggiTutto).style.display = 'block';
        document.getElementById(idLeggiMeno).style.display = 'none';

        document.getElementById(idBtnLeggiMeno).style.display = 'block';
        document.getElementById(idBtnLeggiTutto).style.display = 'none';
    }
    else {
        document.getElementById(idLeggiTutto).style.display = 'none';
        document.getElementById(idLeggiMeno).style.display = 'block';

        document.getElementById(idBtnLeggiMeno).style.display = 'none';
        document.getElementById(idBtnLeggiTutto).style.display = 'block';
    }
    $('#container-eventi').find('div').each(function () {
        var innerDivId = $(this).attr('id');
        if (innerDivId != "undefined" && innerDivId != "" && innerDivId != null && innerDivId.substring(0, 5) == 'leggi'
            && innerDivId != idLeggiMeno && innerDivId != idBtnLeggiMeno && innerDivId != idLeggiTutto && innerDivId != idBtnLeggiTutto
        )
        {
            if (innerDivId.substring(0, 9) == "leggiMeno") {
                document.getElementById(innerDivId).style.display = 'block';
            } else if (innerDivId.substring(0, 10) == "leggiTutto") {
                document.getElementById(innerDivId).style.display = 'none';
            }
            if (innerDivId.substring(0, 12) == "leggiMenoBtn") {
                document.getElementById(innerDivId).style.display = 'none';
            } else if (innerDivId.substring(0, 13) == "leggiTuttoBtn") {
                document.getElementById(innerDivId).style.display = 'block';
            }
        }
    });
   
    
}