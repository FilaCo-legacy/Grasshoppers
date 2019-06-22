$(document).ready(function(){
    
    $("#deleteButton").find(':input[type="submit"]').prop('disabled', true);
    $("#editButton").find(':input[type="submit"]').prop('disabled', true);

    $("table  tr:not(thead tr)").click(function(){
        var iter = $(".selected");

        var check = iter.length === 0;

        $("#deleteButton").find(':input[type="submit"]').prop('disabled', check);
        $("#editButton").find(':input[type="submit"]').prop('disabled', check);
    });

    $("#deleteButton").click(getSelectedRows);

    $("#editButton").click(getSelectedRows);

    function getSelectedRows () {
        var identifiers = $(".selected").find("td:hidden", this);
        var elems = "?elems=" + identifiers[0].innerText;
        
        for (var iter = 1; iter < identifiers.length; ++identifiers){
            elems += "&elems=" + identifiers[iter].innerText;
        }
        
        $(this).attr("action", $(this).attr("action") + elems);
    }
    
});

