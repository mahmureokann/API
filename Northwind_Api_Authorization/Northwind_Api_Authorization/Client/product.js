$(document).ready(function(){
    $("#btnProduct").click(function () {
        var firstname = $("#firstname").val();
        var lastname = $("#lastname").val();


        $.ajax({
            method: 'Get',
            url: '../api/products',
            headers: {
                "Authorization" :"Basic "+ btoa(firstname+":"+lastname)
            },
            success: function (data) {
                /*  console.log("succses: " + data);*/

                GetProducts(data)
            },
            complete: function (data) {
                if (data.status=="401") {
                    alert("yetkiniz bulunmamaktadır!");

                }
                else if (data.status =="200") {
                    alert("Giriş başarılı!");
                }
            }
        })
    })

    function GetProducts(data) {
        data.forEach(function (val,index) {
            console.log(val.PoductName)
        })
    }
})