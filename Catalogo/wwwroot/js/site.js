
function producto(id) {
    var request = $.ajax({
        url: '/admin/edit?id=' + id
    });
    request.done(function (resp) {
        console.log(resp);
        $("#edit").html(resp);
    });
};
$('.ini').click(function () {
    var request = $.ajax({
        url: '/auth/login'
    });
    request.done(function (resp) {
        console.log(resp);
        $("#iniciarsesion").html(resp);
    });
});

$('.reg').click(function () {
    var request = $.ajax({
        url: '/admin/create'
    });
    request.done(function (resp) {
        console.log(resp);
        $("#regProduc").html(resp);
    });
});

   






