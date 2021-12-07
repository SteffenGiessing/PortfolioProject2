define(["knockout", "postman"], function (ko, postman) {
    let selectedComponent = ko.observable("users");
    let currentView = ko.observable("get-titles");
    let loginUser = ko.observable("loginUser");
    let menuElements = ["users"]

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });
    postman.subscribe("changeView", function (data) {
        loginUser(data);
    });
    postman.subscribe("changeContent", component => {
       changeContent(component);
    });
    
    let changeContent = element => {
        selectedComponent(element.toLowerCase());
    }
    let loginBtw = () =>{
        console.log("loginButton Clicked");
    }
    return {
        loginBtw,
        selectedComponent,
        currentView,
        menuElements,
        loginUser,
        changeContent
    }
});