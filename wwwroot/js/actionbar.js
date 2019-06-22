$(document).ready(function(){
    
    $("#deleteButton").addClass("disabled");
    $("#editButton").addClass("disabled");
    
    $("table  tr:not(thead tr)").click(function(){
        $("#deleteButton").removeClass("disabled");
        $("#editButton").removeClass("disabled");
        
        var iter = $(".selected");

        var check = iter.length === 0 ? "disabled":"";

        $("#deleteButton").addClass(check);
        $("#editButton").addClass(check);
    });
});