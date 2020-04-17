// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#con").hide();// when initiate, hide first
    $("#word").keyup(function () {

        var word = $.trim($("#word").val());
        if (word == "") {
            $("#con").hide();//even one key is up, if nothing there, the tip box is still invisible. 
        }
        else
        {
            $("#con").show();
            $.get({
                // GET api/<controller>/5
                url: "/api/Word",
                data: { i: word },
                success: function (data) {
                    //alert(data);
                    var list = JSON.parse(data);
                    //$.each(list, function (n, value) {
                    //    var x = value.Word;
                    //    var y = value.Explain;
                    //    alert(x.toString());
                    //}
                    //var json = eval(data.rows) 
                    var s = "";
                    for (var i = 0; i < list.length; i++) {
                        //var x= list[i].word;
                        // var y = list[i].explain; 
                        // alert(json[i].Word);//class='alert alert - success'
                        s += "<div><strong>" + list[i].word + "</strong>" +"  "+ list[i].explain + "</div>";
                        //$("#tips").append($span);
                    }

                    $("#con").html(s);

                    // change backgroud once hover the mouse point
                    $("#con div").hover(function () {

                        $(this).addClass("bg"); // add a class Name to current item

                    }, function () {

                            $(this).removeClass("bg");
                    });


                    $("#con div").click(function () {

                        $("#con").hide();// Once user click a item, hide the drop down list

                        // find the content of tag "strong" in the current tang

                        var word = $(this).find("strong").text();// Get content of tag "strong"

                        $("#word").val(word);// assign the content from tag "strong" to word

                        //$("#word").val($(this).text());

                    })
                    //alert(s);

                    //              <div class="alert alert-success">
                    //                  <strong>Success!</strong> This alert box could indicate a successful or positive action.
                    //</div>
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                }





            })
        


        }
    })
       
})
