// Standart Room
var mainimg1 = document.querySelector(".sliderimg1");
var images1 = [
    "/images/desktop/accomodation/Standart Room/comfort_standart1.jpg",
    "/images/desktop/accomodation/Standart Room/comfort_standart2.jpg",
    "/images/desktop/accomodation/Standart Room/comfort_standart3.jpg",
    "/images/desktop/accomodation/Standart Room/comfort_standart6.jpg"
];
var num1 = 0;

function next1() {
    num1++;
    if (num1 >= images1.length) {
        num1 = 0;
    }
    mainimg1.src = images1[num1];
}

function back1() {
    num1--;
    if (num1 < 0) {
        num1 = images1.length - 1;
    }
    mainimg1.src = images1[num1];
}

// Elite Standart Room
var mainimg2 = document.querySelector(".sliderimg2");
var images2 = [
    "/images/desktop/accomodation/Elite Standart Room/elite_standart1.jpg",
    "/images/desktop/accomodation/Elite Standart Room/elite_standart2.jpg",
    "/images/desktop/accomodation/Elite Standart Room/elite_standart3.jpg",
    "/images/desktop/accomodation/Elite Standart Room/elite_standart4.jpg"
];
var num2 = 0;

function next2() {
    num2++;
    if (num2 >= images2.length) {
        num2 = 0;
    }
    mainimg2.src = images2[num2];
}

function back2() {
    num2--;
    if (num2 < 0) {
        num2 = images2.length - 1;
    }
    mainimg2.src = images2[num2];
}

// Family Room
var mainimg3 = document.querySelector(".sliderimg3");
var images3 = [
    "/images/desktop/accomodation/Family Room/comfort_quad1.jpg",
    "/images/desktop/accomodation/Family Room/comfort_quad3.jpg",
    "/images/desktop/accomodation/Family Room/comfort_quad4.jpg"
];
var num3 = 0;

function next3() {
    num3++;
    if (num3 >= images3.length) {
        num3 = 0;
    }
    mainimg3.src = images3[num3];
}

function back3() {
    num3--;
    if (num3 < 0) {
        num3 = images3.length - 1;
    }
    mainimg3.src = images3[num3];
}

// Comfort Swim Up Room
var mainimg4 = document.querySelector(".sliderimg4");
var images4 = [
    "/images/desktop/accomodation/Comfort Swim up Room/comfort_Swim-up1.jpg",
    "/images/desktop/accomodation/Comfort Swim up Room/comfort_Swim-up2.jpg",
    "/images/desktop/accomodation/Comfort Swim up Room/comfort_Swim-up3.jpg",
    "/images/desktop/accomodation/Comfort Swim up Room/comfort_Swim-up5.jpg"
];
var num4 = 0;

function next4() {
    num4++;
    if (num4 >= images4.length) {
        num4 = 0;
    }
    mainimg4.src = images4[num4];
}

function back4() {
    num4--;
    if (num4 < 0) {
        num4 = images4.length - 1;
    }
    mainimg4.src = images4[num4];
}



document.getElementById('phoneInput').addEventListener('input', function (e) {
    var x = e.target.value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    e.target.value = !x[2] ? x[1] : `${x[1]} ${x[2]}` + (x[3] ? ` ${x[3]}` : '');
});