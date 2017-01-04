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