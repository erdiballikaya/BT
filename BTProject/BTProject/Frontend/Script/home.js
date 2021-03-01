var userID = sessionStorage.getItem("sessionID");
var tableData;

window.onload = function (){
    $.ajax({
        url: 'https://localhost:44308/api/Movie/GetMovie?userID='+userID,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (_data) {
            var table = $('#UserMovieTable').DataTable({
                "aadata": _data,
                "searching": false,
                rowId: 'imdbID',
                data: _data,
                columns: [
                    {data: "Title"},
                    {data: "Year"},
                    {data: "imdbID"},
                    {
                        mRender: function (data, type, row) {
                            return '<button onclick="DeleteMovie(' + row.imdbID + "," + userID +')" class="btn btn-danger btn-sm" >Sil</button>'
                        }
                    }
                ]
            });
        }
        
    });
}

SearchFunc = () => {
    value = document.getElementById("Search").value;
    var settings = {
        "url": "http://www.omdbapi.com/?apikey=119d0694&s="+value,
        "method": "POST",
        "timeout": 0,
        "dataType": "json",
      };
      
      $.ajax(settings).done(function (_data) {
        console.log(_data.Search)
        $('#movieTable').DataTable({
                "aadata": _data,
                "searching": false,
                "destroy": true,
                rowId: 'imdbID',
                data: _data.Search,
                columns: [
                    {data: "Title"},
                    {data: "Year"},
                    {data: "imdbID"},
                    {
                        mRender: function (data, type, row) {
                            return '<button onclick="AddMovie(' + row.imdbID + "," + userID +')" class="btn btn-dark btn-sm" >Ekle</button>'
                            
                        }
                    }
                ]
            });
    });      
};

AddMovie = (id, user) =>{
    var settings = {
        "url": "http://www.omdbapi.com/?apikey=119d0694&i="+id.id,
        "method": "POST",
        "timeout": 0,
        "dataType": "json",
      };
      
      $.ajax(settings).done(function (_data) {
        movie={
            Title: _data.Title,
            Year: _data.Year,
            userID: user,
            imdbID: id.id
        }

        $.ajax({
            url: 'https://localhost:44308/api/Movie/Add',
            type: 'POST',
            dataType: 'json',
            data:JSON.stringify(movie),
            contentType: 'application/json; charset=utf-8',
            success: function (_data) {
                if(_data.result.statusCode == 2){
                    Swal.fire({
                        title: 'Sayfa Yükleniyor...!',
                        text: 'Film eklendi',
                        icon: 'success',
                        confirmButtonText: 'Kapat'
                      })
                    location.reload();
                }           
            }            
        });
      });      
}

DeleteMovie = (imdbID, userID) =>{
    $.ajax({
        url: 'https://localhost:44308/api/Movie/Delete?imdbID='+imdbID.id+"&userID="+userID,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (_data) {
            if(_data.statusCode == 2){
                Swal.fire({
                    title: 'Sayfa Yükleniyor...!',
                    text: 'Silme İşlemi Başarılı',
                    icon: 'success',
                    confirmButtonText: 'Kapat'
                  })
                location.reload();
            }           
        }
    });
}
