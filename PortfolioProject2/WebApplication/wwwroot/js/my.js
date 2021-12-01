
var input = document.getElementById("in");
var output = document.getElementById("out");
var output2 = document.getElementById("out2");


function getTitles(callback) {
    fetch("https://localhost:5001/api/titles", { method: 'GET' })
        .then(response => response.json())
        .then(json => {
            callback(json);
        });
}


getTitles(function (titltes) {
    console.log(titltes.items);
    var output2 = document.getElementById("out2");
    for (var i = 0; i < titltes.items.length; i++) {
        var div = document.createElement("div");
        div.innerHTML = 'Name: ' + titltes.items[i].primaryTitle + ' ' + titltes.items[i].genres;
        output2.appendChild(div);
    }});
    
/*function getCategories(callback) {
    fetch("api/categories", { method: 'GET' })
        .then(response => response.json())
        .then(json => {
            //console.log(json);
            callback(json);
        });
}


getCategories(function (categories) {
    console.log(categories);
})*/

