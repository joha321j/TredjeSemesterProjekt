// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function seePricesProducts(firstSpanId, buttonId, moreTextId) {
    var dots = document.getElementById(firstSpanId);
    var moreText = document.getElementById(moreTextId);
    var btnText = document.getElementById(buttonId);

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Se priser";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Skjul";
        moreText.style.display = "inline";
    }
} 