
export function AosInit() {
    AOS.init();
}
export function navClick() {
    $(".link1").click(function () {
        $(".menu1 li a").removeClass("active");
        $(this).addClass("active");

    });
}