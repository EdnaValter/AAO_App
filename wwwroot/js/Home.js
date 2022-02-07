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