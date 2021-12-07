define(["knockout", "postman"], function (ko, postman) {
    let selectedComponent = ko.observable("loginUser");
    let menuElements = ["get-Home", "get-titles", "get-actors", "loginUser"];

    let isActive = element => {
        return element.toLowerCase() === selectedComponent() ? "active" : "";
    }

    postman.subscribe("changeContent", component => {
        changeContent(component);
    });


    /*    let loginUser = ko.observable("loginUser");*/
    
/*    postman.subscribe("changeView", function(data) {
        currentView(data);
    });

    postman.subscribe("changeView", function (data) {
        loginUser(data);
    });
    */
    
/*
    postman.subscribe("userLogin", component => {
        changeContent('loginUser');
    });

    */
    
    let changeContent = element => {
        selectedComponent(element.toLowerCase());
    }
    
    let loginBtw = () => {
        console.log("loginButton Clicked");
    }
    
    return {
        loginBtw,
        selectedComponent,
        menuElements,
        isActive,
        changeContent
    }
});