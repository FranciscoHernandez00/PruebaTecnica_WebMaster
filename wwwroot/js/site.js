﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Info() {
    alert("User accounts are assigned by administrators.");
}

$("#myFunction").on("click", function (event) {
    var r = confirm("Do you want to delete this Store?");
    if (r == true) {
        
    } else {
        event.preventDefault();
    }
    
    
   
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})