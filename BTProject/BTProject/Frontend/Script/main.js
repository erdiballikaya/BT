Login = () =>{         
    var email = document.getElementById("mail").value;   
    var password = document.getElementById("Password").value;
    
    user = {
        Email: email,
        Password: password
    }

    $.ajax({
        url: 'https://localhost:44308/api/Login/Login',
        type: 'POST',
        dataType: 'json',
        data:JSON.stringify(user),
        contentType: 'application/json; charset=utf-8',
        success: function (_data) {
            if(_data.statusCode == 0){
                Swal.fire({
                    title: 'Hata!',
                    text: 'Böyle bir kullanıcı yok',
                    icon: 'error',
                    confirmButtonText: 'Cool'
                  })
            }
            if(_data.statusCode == 1){
                Swal.fire({
                    title: 'Hata!',
                    text: 'Parolayı Kontrol Edin',
                    icon: 'error',
                    confirmButtonText: 'Cool'
                  })
            }
            if (_data.statusCode == 2){
                sessionStorage.setItem("sessionID", _data.content);
                window.location.href = "home.html";
            }
        }
    });
}

SignIn = () =>{         
    var ad = document.getElementById("Ad").value;   
    var soyad = document.getElementById("Soyad").value;
    var E_mail = document.getElementById("Email").value;   
    var Parola = document.getElementById("Parola").value;
    if(ad == "" || soyad == "" || E_mail == "" || Parola == ""){
        Swal.fire({
            title: 'Hata!',
            text: 'Lütfen Tüm Alanları Doldurun',
            icon: 'error',
            confirmButtonText: 'Kapat'
          })
    }
    else{        
        user = {
            Name: ad,
            Surname: soyad,
            Email: E_mail,
            Password:Parola
        }

        $.ajax({
            url: 'https://localhost:44308/api/Login/SignIn',
            type: 'POST',
            dataType: 'json',
            data:JSON.stringify(user),
            contentType: 'application/json; charset=utf-8',
            success: function (_data) {
                if(_data.statusCode == 2)
                {
                    Swal.fire({
                        title: 'Başarılı!',
                        text: 'Kayıt Başarıyla Oluşturuldu',
                        icon: 'success',
                        confirmButtonText: 'Kapat'
                    })

                    document.getElementById("Ad").value  = "";   
                    document.getElementById("Soyad").value = "";
                    document.getElementById("Email").value = "";   
                    document.getElementById("Parola").value = "";


                }
                if(_data.statusCode == 1)
                {
                    Swal.fire({
                        title: 'Hata!',
                        text: 'Bir Hata Meydana Geldi',
                        icon: 'error',
                        confirmButtonText: 'Kapat'
                    })
                }
            }
        });
    }
}   
                
