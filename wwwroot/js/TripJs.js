
/*ÅBNER OG LUKKER FILTER*/

function OpenCloseFilter() {
    var filter = document.getElementById("Filter");
 /*   var test = document.getElementById("test").addEventListener('click', OpenCloseFilter())*/

    if (filter.style.display == "none") {
        filter.style.display = "flex";
    }

    else {
        filter.style.display = "none";
    }
}

/*VISER LEDIGE OG MINETURE' DATA*/
var AllTrips = document.getElementsByClassName("AllNewTrips");
var MyTrips = document.getElementsByClassName("MyTrips");

var AllTripsBtn = document.getElementById("TripItem2"); 
var MyTripsBtn = document.getElementById("TripItem1");


AllTripsBtn.addEventListener('click', ShowTrips);
MyTripsBtn.addEventListener('click', ShowTrips); 


var ledigTur = true;


function ShowTrips() {
    if (ledigTur) {
        for (let e = 0; e < AllTrips.length; e++) {
            AllTrips[e].style.display = "none";
        }
        for (let e = 0; e < MyTrips.length; e++) {
            MyTrips[e].style.display = "flex";
        }
        ledigTur = false;
    } else {
        for (let e = 0; e < AllTrips.length; e++) {
            AllTrips[e].style.display = "flex";
        }
        for (let e = 0; e < MyTrips.length; e++) {
            MyTrips[e].style.display = "none";
        }
        ledigTur = true;
    }



    for (let e = 0; e < MyTrips.length; e++) {

        if (document.getElementById("TripItem1").style.height == "46px") {
            MyTrips[e].style.display = "flex";
        }

        else {
            MyTrips[e].style.display = "none";
        }

    }
 
}

/*TOGGLE IMELLEM LEDIGE TURE OG MINE TURE*/
function MyTrip() {
    document.getElementById("TripItem1").style.height = "46px";
    document.getElementById("TripItem1").style.lineHeight = "46px";
    document.getElementById("line").style.backgroundColor = "#005140";
    document.getElementById("TripItem2").style.height = "42px";
    document.getElementById("TripItem2").style.lineHeight = "42px";
}

function AvaTrip() {
    document.getElementById("TripItem2").style.height = "46px";
    document.getElementById("TripItem2").style.lineHeight = "46px";
    document.getElementById("line").style.backgroundColor = "#00904A";
    document.getElementById("TripItem1").style.height = "42px";
    document.getElementById("TripItem1").style.lineHeight = "42px";
}

/*ÅBNER OG LUKKER INFORMATIONER OM TUREN*/
var n = document.getElementsByClassName('TripsHolder');
for (let e = 0; e < n.length; e++) {
    n[e].addEventListener('click', function () {

       
        var Info = document.getElementsByClassName("MoreInfo")[e];
        var Date = document.getElementsByClassName("Date")[e];
        var Country = document.getElementsByClassName("Country")[e];

        if (Info.style.display == "none" || Date.style.borderRadius == "0.25em 0 0 0.25em" || Country.style.borderRadius == "0 0 0.25em 0") {
            Info.style.display = "grid";
            Date.style.borderRadius = "0.25em 0 0 0";
            Country.style.borderRadius = "0";
        }

        else {
            Info.style.display = "none";
            Date.style.borderRadius = "0.25em 0 0 0.25em";
            Country.style.borderRadius = "0 0 0.25em 0";
        }

    });
}

/*SÅ FILTERET TIL AT VIRKE*/
function CheckboxValues(name) {
    const checkboxes = document.querySelectorAll(`input[name="${name}"]:checked`);
    const CountryCheckboxes = document.querySelectorAll(`input[name="${name}"]:checked`);
    let values = [];
    let CountryValues = [];

    checkboxes.forEach((checkbox) => {
        values.push(checkbox.value);
    });

    CountryCheckboxes.forEach((CountryCheckbox) => {
        CountryValues.push(CountryCheckbox.value);
    });

    return [values, CountryValues];
}

var Start = document.getElementsByClassName('StartPoint');
var Box = document.getElementsByClassName('TripsHolder');
var Ctype = document.getElementsByClassName('CType');

document.querySelectorAll(".btn").forEach(btn => {
    btn.addEventListener('click', event => {
        console.log(CheckboxValues('check')[0]);
        console.log(CheckboxValues('CountryTypeCheck')[1]);

        for (let i = 0; i < Box.length; i++) {

            if ( //Du har valgt en by og du har ikke valgt national eller international
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(": ").pop()) &&
                    (CheckboxValues('CountryTypeCheck')[1].length == 0)) ||
                //Du har valgt en by og du har valgt national
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(": ").pop()) &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "DK - DK")) ||
                //Du har valgt en by og du har valgt international
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(": ").pop()) &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("International") && Ctype[i].innerHTML != "DK - DK")) ||
                //Du har ikke valgt en by og du har valgt national
                (CheckboxValues('check')[0].length == 0 &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "DK - DK")) ||
                //Du har ikke valgt en by og du har valgt international
                (CheckboxValues('check')[0].length == 0 &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("International") && Ctype[i].innerHTML != "DK - DK")) ||
                //Afgangsted Starteri Dk
                (CheckboxValues('check')[0].length == 0 &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "DK - SE")) ||
                //Afgangsted Starteri Dk
                (CheckboxValues('check')[0].length == 0 &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "DK - NO")) ||
                //Afgangsted Starteri Dk
                (CheckboxValues('check')[0].length == 0 &&
                    (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "DK - NL")) ||
                //Du har ikke valgt noget
                (CheckboxValues('check')[0].length == 0 && (CheckboxValues('CountryTypeCheck')[1].length == 0))
            ) {
                Box[i].style.display = "grid";
            }
            else {
                Box[i].style.display = "none";
            }

        }
    })
}); 

//VISER MÅNEDEr I BUKSTAVER ISTEDET FOR ID 
const ShowMonth = document.querySelectorAll('#Month');
for (let i = 0; i < ShowMonth.length; i++) {

    switch (ShowMonth[i].innerHTML) {
        case "1":
            ShowMonth[i].innerHTML = "JAN";
            break; 
        case "2":
            ShowMonth[i].innerHTML = "FEB";
            break; 
        case "3":
            ShowMonth[i].innerHTML = "MAR";
            break;
        case "4":
            ShowMonth[i].innerHTML = "APR";
            break;
        case "5":
            ShowMonth[i].innerHTML = "MAJ";
            break;
        case "6":
            ShowMonth[i].innerHTML = "JUN";
            break;
        case "7":
            ShowMonth[i].innerHTML = "JUL";
            break;
        case "8":
            ShowMonth[i].innerHTML = "AUG";
            break;
        case "9":
            ShowMonth[i].innerHTML = "SEP";
            break;
        case "10":
            ShowMonth[i].innerHTML = "OKT";
            break;
        case "11":
            ShowMonth[i].innerHTML = "NOV";
            break;
        case "12":
            ShowMonth[i].innerHTML = "DEC";
    }
 }