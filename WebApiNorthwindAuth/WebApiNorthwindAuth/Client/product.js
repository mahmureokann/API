$(document).ready(function () {
    $("#btnProducts").click(function () {
        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
       
        $.ajax({
            method: 'Get',
            url: '../api/products',
            headers: {
                "Authorization": "Basic " + btoa(firstName + ":" + lastName)
            },
            success: function (data) {
                GetProducts(data);
            },
            complete: function (data) {
                if (data.status == '401') {
                    alert("yetkiniz bulunmamaktadır!");
                } else if (data.status == '200') {
                    alert('giriş başarılı');
                }
            }
        })
    })

    function GetProducts(data) {
        data.forEach(function (val, index) {
            $("#productTable").append(`
                    <tr>
                        <td>${val.Id}</td>
                        <td>${val.ProductName}</td>
                        <td>${val.UnitPrice}</td>
                        <td>${val.UnitsInStock}</td>

                    </tr>
`)
        })
    }
})