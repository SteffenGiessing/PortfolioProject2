define(["knockout", "postman"], function (ko, postman) {
    let selectedComponent = ko.observable("home");
    let menuElements = ["Home", "Popular Titles", "Login", "ActorSearch"];

    let searchWord = ko.observable().extend({
        validation: {
            message: "Please add a longer search string for better search results",
            validator: function(value) {
                return value > 2
            }
        }
    });


    let currentParams = ko.observable({searchWord});

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
        });q
        */

    /*
        postman.subscribe("userLogin", component => {
            changeContent('loginUser');
        });
        */
    
    postman.subscribe("changeUserView", component => {
        changeContent('loggedin');
    });

    postman.subscribe("changeTitle", component => {
        changeContent('title-info');
    });


    let changeContent = element => {
        selectedComponent(element.toLowerCase());
    }

    let loginBtw = () => {
        console.log("loginButton Clicked");
    }

    let searchBtn = () => {
        console.log("Search button clicked");
        currentParams({searchWord});
        selectedComponent("search");
    }

    return {
        searchBtn,
        loginBtw,
        searchWord,
        selectedComponent,
        menuElements,
        isActive,
        changeContent,
        currentParams
    }
});