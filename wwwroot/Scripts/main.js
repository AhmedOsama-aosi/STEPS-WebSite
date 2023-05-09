//navbar


    




    // tabs in predict page
    let tabs = document.querySelectorAll(".tabs li");
    let tabsarray = Array.from(tabs);


    const divs = document.querySelectorAll(".tcontent > div");
    let divsarray = Array.from(divs);


    tabsarray.forEach((ele) => {
        ele.addEventListener("click", function (e) {
            // console.log(ele);
            tabsarray.forEach((ele) => {
                ele.classList.remove("active2");

            });
            e.currentTarget.classList.add("active2");
            divsarray.forEach((div) => {
                div.style.display = 'none';

            });
            // console.log(e.currentTarget.dataset.contt);
            document.querySelector(e.currentTarget.dataset.contt).style.display = "block";
        });
    });



    //-------------------------------------------------
    // bottons in index page
    const btn1 = document.getElementsByClassName("eqday");
    const btn22 = document.getElementsByClassName("mmorning");
    const btn3 = document.getElementsByClassName("mevening");

    //console.log("btn1");
    let bottonns = document.querySelectorAll(".radio li");
    let bottonnsarray = Array.from(bottonns);

    bottonnsarray.forEach((x) => {
        x.addEventListener("click", function (e) {
            bottonnsarray.forEach((r) => {
                r.classList.remove("btnactive");
            });
            //console.log( e.currentTarget)
            e.currentTarget.classList.add("btnactive");

        });
    });

    // tabs in index page
    let tabs2 = document.querySelectorAll(".tabs2 li");
    let tabsarray2 = Array.from(tabs2);


    const divs2 = document.querySelectorAll(".dcontent > div");
    let divsarray2 = Array.from(divs2);


    tabsarray2.forEach((ele) => {
        ele.addEventListener("click", function (e) {
            // console.log(ele);
            tabsarray2.forEach((ele) => {
                ele.classList.remove("active3");

            });
            e.currentTarget.classList.add("active3");
            divsarray2.forEach((div) => {
                div.style.display = 'none';

            });
            // console.log(e.currentTarget.dataset.contt);
            document.querySelector(e.currentTarget.dataset.cont2).style.display = "block";
        });
    });

