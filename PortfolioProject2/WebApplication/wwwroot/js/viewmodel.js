define(["knockout", "postman"], function (ko, postman) {
    
    let selectedComponent = ko.observable("get-home");
    let menuElements = ["get-Home", "get-titles", "get-actors"];

    let isActive = element => {
        return element.toLowerCase() === selectedComponent() ? "active" : "";
    }
    
    postman.subscribe("changeContent", component => {
        changeContent(component);
    });

    postman.subscribe("getHome", component => {
        changeContent('get-Home');
    });

    
    let changeContent = element => {
        selectedComponent(element.toLowerCase());
    }


    return {
        selectedComponent,
        menuElements,
        isActive,
        changeContent
    }
});