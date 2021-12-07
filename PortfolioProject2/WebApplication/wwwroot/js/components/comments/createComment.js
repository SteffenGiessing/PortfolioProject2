//define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

let post= document.getElementById("post");
post.addEventListener("click", function() {
    let commentBoxValue = document.getElementById("commentField").value;

    let li = document.createElement("li");
    let text = document.createTextNode(commentBoxValue);
    li.appendChild(text);
    document.getElementById("unordered").appendChild(li);

});