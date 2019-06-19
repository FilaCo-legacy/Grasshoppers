$(document).ready(function(){
    $("table tr:not(thead tr)").hover(function(){
        $(this).addClass("hovered")
    }, function(){
        $(this).removeClass("hovered")
    });

    $("table  tr:not(thead tr)").click(function(){
        $(this).toggleClass("selected");
    });
});