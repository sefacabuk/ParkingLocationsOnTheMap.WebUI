// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GosterBeklet() {
    $('#page-top').css("opacity", "0.5");
    $('#loader').css("display", "block");
}

function GizleBeklet() {
    $('#page-top').css("opacity", "1");
    $('#loader').css("display", "none");
}
