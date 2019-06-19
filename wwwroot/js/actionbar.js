$(document).ready(function(){
    var iter = $(".selected");

    var check = iter.length === 0;

    $("#deleteButton").prop("disabled", check);
    $("#editButton").prop("disabled", check);
    
    $("table  tr:not(thead tr)").click(function(){
        iter = $(".selected");

        check = iter.length === 0;

        $("#deleteButton").prop("disabled", check);
        $("#editButton").prop("disabled", check);
    });
});