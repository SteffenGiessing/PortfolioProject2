define(["knockout", "postman"], function (ko, postman) {
    
    let selectedComponent = ko.observable('get-home');
    
    let searchWord = ko.observable().extend({
        validation: {
            message: "Please add a longer search string for better search results",
            validator: function(value) {
                return value > 2
            }
        }
    });
    
    let currentParams = ko.observable({searchWord});
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
    
    let searchBtn = () => {
        console.log("Search button clicked");
        currentParams({searchWord});
        selectedComponent('search');
    }
    
    let changeContent = element => {
        selectedComponent(element.toLowerCase());
    }


    return {
        searchBtn,
        searchWord,
        selectedComponent,
        menuElements,
        isActive,
        changeContent,
        currentParams
    }
});