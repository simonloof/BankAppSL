$(document).ready(function () {

    $('#withdrawal').on('click', function () {
        let accountNo = $('#account-number').val();
        let sum = $('#account-sum').val();
        $.post('/Account/WithDrawal', { accountNo: accountNo, Sum: sum }, function (res) {
            $('.account-details').html(res);

            $('#account-sum').val("");
        });
    });
    $('#deposit').on('click', function () {
        let accountNo = $('#account-number').val();
        let sum = $('#account-sum').val();
        $.post('/Account/Deposit', { accountNo: accountNo, Sum: sum }, function (res) {
            $('.account-details').html(res);

            $('#account-sum').val("");
        });
    });



});