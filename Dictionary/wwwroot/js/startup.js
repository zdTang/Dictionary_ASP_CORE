
﻿// this file is used in startup.js

$(function () {

    $('#ok').click(function () {

        var name = $.trim($('#user').val());
        var password = $.trim($('#pwd').val());

        //alert(name + '  ' + password);

        if (name == "" && pssword == "") {
            alert("must have value");
        }
        else
        {
            $.post
                ({
                   // url: '/Home/Varify',  // use action to verify
                    url: 'api/User',  // use web API to verify
                    data: { "UserName": name, "Password": password },
                    success: function (data) {
                        //Here to determine if user is verified
                       // alert(data);
                        if (data != "ok") {

                            $("#error").html("wrong user name or password, Re-put again");

                            //====Empty the Input box, seems not very helpful
                            //$("#user").val("");
                            //$("#pwd").val("");

                           // var obj = new Object();
                           // obj.UserName = name;
                           // obj.password = password;
                           
                           //var user = JSON.stringify(obj);
                            //window.location.href = '@Url.Action("Init", "Home")/' + data;
                           // window.location.href = '/Home/Add/'+user;

                            //=======the following method can work
                            //$.ajax({
                            //    url: '/Home/Init',
                            //    data: { "UserName": name, "Password": password }
                            //})

                            //url: '/home/Varify',
                            //    data: { "UserName": name, "Password": password },
                        }
                        else { // here need to do something

                            window.location.href = '/Home/Init';
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //some errror, some show err msg to user and log the error  
                        alert(xhr.responseText);

                    }    


                })
        }
        // asynchronous Calling testing 
        //alert("haha");
    })


})