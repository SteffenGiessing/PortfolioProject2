define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-titles");

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });
    
    return {
        currentView
    }
});