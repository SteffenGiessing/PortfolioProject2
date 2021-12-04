define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("getTitles");

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });
    
    return {
        currentView
    }
});