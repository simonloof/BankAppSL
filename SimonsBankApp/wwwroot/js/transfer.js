$(document).ready(function () {

    $('#transfer').on('click', function () {
        let sourceAccountNo = $('#source-account-number').val();
        let targetAccountNo = $('#target-account-number').val();
        let sum = $('#account-sum').val();
        $.post('/Account/Transfer', { sourceAccountNo: sourceAccountNo, targetAccountNo: targetAccountNo, Sum: sum }, function (res) {
            $('.account-details').html(res);

            $('#account-sum').val("");
        });
    });
});