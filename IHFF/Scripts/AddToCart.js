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
