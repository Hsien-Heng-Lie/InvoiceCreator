// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function(event) { 
    let navItems = document.getElementsByClassName("nav-item");

    for(let i = 0; i < navItems.length; i++){
        navItems[i].addEventListener("mouseover", () => {
            for(let j = 0; j < navItems.length; j++){
                if(i !== j){
                    navItems[j].classList.add("notHovered");
                } else {
                    navItems[j].classList.remove("notHovered");
                }
            }
        });

        navItems[i].addEventListener("mouseout", () => {
            for(let j = 0; j < navItems.length; j++){
                navItems[j].classList.remove("notHovered");
            }
        });
    }
});