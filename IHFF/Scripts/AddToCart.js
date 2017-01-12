function AddProductToCart(id, amount) {
    $.ajax({
        method: "POST",
        url: "/payment/AddProductToCart",
        data: { id: id, amount: amount}
    }).done(function (msg) {
        alert("Data Saved: " + msg);
    });
}
function AddReservationToCart(id, amount, date) {
    $.ajax({
        method: "POST",
        url: "/payment/AddReservationToCart",
        data: { id: id, amount: amount, date: date}
    }).done(function (msg) {
    alert("Data Saved: " + msg);
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
