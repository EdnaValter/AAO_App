
        // get date
    const date = new Date();
    // get array
    const markDateList = [];

    //Green
    markDateList.push(new Date(2021, 11, 09).getTime());
    markDateList.push(new Date(2021, 11, 10).getTime());
    markDateList.push(new Date(2021, 11, 11).getTime());
    markDateList.push(new Date(2021, 11, 12).getTime());

    //Red
    markDateList.push(new Date(2021, 11, 13).getTime());
    markDateList.push(new Date(2021, 11, 14).getTime());
    markDateList.push(new Date(2021, 11, 15).getTime());
    markDateList.push(new Date(2021, 11, 16).getTime());

        // render calendar
        const renderCalendar = () => {
        date.setDate(1);

    const monthDays = document.querySelector(".days");

    const lastDay = new Date(
    date.getFullYear(),
    date.getMonth() + 1,
    0
    ).getDate();

    const prevLastDay = new Date(
    date.getFullYear(),
    date.getMonth(),
    0
    ).getDate();

    const firstDayIndex = date.getDay();

    //getting fullyear + month
    const lastDayIndex = new Date(
    date.getFullYear(),
    date.getMonth() + 1,
    0
    ).getDay();

    const nextDays = 7 - lastDayIndex - 1;

    const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
    ];
    //Show Header Calendar Month
    document.querySelector(".date h2").innerHTML = months[date.getMonth()];
    // show day, month, date and year
    document.querySelector(".date p").innerHTML = new Date().toDateString();

    //getting calendar
    let days = "";

            for (let x = firstDayIndex; x > 0; x--) {
        days += `<div class="prev-date">${prevLastDay - x + 1}</div>`;
            }

    for (let i = 1; i <= lastDay; i++) {
                if (i === new Date().getDate() && date.getMonth() === new Date().getMonth()) {
        days += `<div class="today">${i}</div>`;

                } else if (markDateList.includes(new Date(date.getYear() + 1900, date.getMonth(), i).getTime())) {

        days += `<div class="lists">${i}</div>`;
                }
    else {
        days += `<div>${i}</div>`;
                }
            }

    for (let j = 1; j <= nextDays; j++) {
        days += `<div class="next-date">${j}</div>`;
    monthDays.innerHTML = days;
            }
        };
        // previous arrow
        document.querySelector(".prev").addEventListener("click", () => {
        date.setMonth(date.getMonth() - 1);
    renderCalendar();
        });
        // next arrow
        document.querySelector(".next").addEventListener("click", () => {
        date.setMonth(date.getMonth() + 1);
    renderCalendar();
        });

    renderCalendar();

