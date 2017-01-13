function AddProductToCart(id, amount) {
    $.ajax({
        method: "POST",
        url: "/payment/AddProductToCart",
        data: { id: id, amount: amount}
    }).done(function (msg) {
        ShowShoppingCart();
    });
}
function AddReservationToCart(id, amount, date) {
    $.ajax({
        method: "POST",
        url: "/payment/AddReservationToCart",
        data: { id: id, amount: amount, date: date}
    }).done(function (msg) {
        ShowShoppingCart();
});
}
function Explosion() {
    $.ajax({
        method: "POST",
        url: "/payment/DeleteCart",
        data: {}
    }).done(function () {
        $('.modal').modal('hide')
    });
}
function ShowShoppingCart(){
    $.ajax({
        method: "POST",
        url: "/payment/GetCart",
        data: {}
    }).done(function (msg) {
        $('.modal-content').html(msg);
        $('.modal').modal();
    });
};


function AddProductToProgram(id, amount) {
    $.ajax({
        method: "POST",
        url: "/program/AddProductToProgram",
        data: { id: id, amount: amount }
    }).done(function (msg) {
        ShowShoppingCart();
    });
}

function AddProgramToCart(){
    $.ajax({
        method: "POST",
        url: "/program/AddProgramToCart",
    }).done(function () {
        ShowShoppingCart();
    });
}

function AddReservationToProgram(id, amount, date) {
    $.ajax({
        method: "POST",
        url: "/program/AddReservationToProgram",
        data: { id: id, amount: amount, date: date }
    }).done(function (msg) {
        ShowProgram();
    });
}
function DeleteProgram() {
    $.ajax({
        method: "POST",
        url: "/program/DeleteProgram",
        data: {}
    }).done(function () {
        $('.modal').modal('hide')
    });
}
function ShowProgram() {
    $.ajax({
        method: "POST",
        url: "/program/GetProgram",
        data: {}
    }).done(function (msg) {
        $('.modal-content').html(msg);
        $('.modal').modal();
    });
};





var currentId;

function MapsLocation(location) {
    var str1 = "https://maps.google.com/maps?q=";
    var str2 = "&t=&z=14&ie=UTF8&iwloc=&output=embed";
    document.getElementById('maps').src = str1 + location + str2;
}

$(document).ready(function () {
    $("#result").dialog({
        autoOpen: false,
        title: 'Persoonlijk Programma',
        width: 500,
        height: 'auto',
    });
});

$(document).ready(function () {
    $("#OrderRestaurant").dialog({
        autoOpen: false,
        title: 'Reservering maken',
        width: 500,
        height: 'auto',
    });
    $("#ProgramRestaurant").dialog({
        autoOpen: false,
        title: 'Voeg toe aan persoonlijke programma',
        width: 500,
        height: 'auto',
    });
});

function openOrderDialog() {
    $("#OrderRestaurant").dialog("open");
}

function openProgramDialog() {
    $("#ProgramRestaurant").dialog("open");
}

function FillOrderDialogInfo(identity, name, poster) {
    var posterContainer = document.getElementById("orderPoster");
    posterContainer.innerHTML = "test";
    var a = "<img style=\"width: 230px; height: 150px;margin: 10px;margin-top: 25px;\" src=";
    var b = ">";

    currentId = identity;

    posterContainer.innerHTML = a + poster + b;
    document.getElementById("orderName").innerHTML = name;

}

function fillProgramDialogInfo(identity, name, poster) {
    var posterContainer = document.getElementById("programPoster");
    posterContainer.innerHTML = "test";
    var a = "<img style=\"width: 230px; height: 150px;margin: 10px;margin-top: 25px;\" src=";
    var b = ">";

    currentId = identity;

    posterContainer.innerHTML = a + poster + b;
    document.getElementById("programName").innerHTML = name;
}

function confirmReservation() {
    var aantal = document.getElementById("orderAantal").value;
    var datum = document.getElementById("orderDate").value;
    AddReservationToCart(currentId, aantal, datum);
}

function confirmProgram() {
    var aantal = document.getElementById("programAantal").value;
    var datum = document.getElementById("programDate").value;
    AddReservationToProgram(currentId, aantal, datum);
}