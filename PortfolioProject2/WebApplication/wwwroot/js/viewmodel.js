define(["knockout", "postman"], function (ko, postman) {
    let selectedComponent = ko.observable("home");
    
    let menuElements2 = ["Home", "Popular Titles", "Login", "ActorSearch"];
    let menuElements = ["Home", "Popular Titles", "ActorSearch"];
    
    // showMe = ko.observable(true);  // hidden initially

    
    let searchWord = ko.observable().extend({
        validation: {
            message: "Please add a longer search string for better search results",
            validator: function(value) {
                return value > 2
            }
        }
    });
    let actorSearchWord = ko.observable().extend({
       validation: {
           message: "Please add a longer search string for better search results",
           validator: function(value) {
               return value > 2
           }
       } 
    });
    
    let currentParams = ko.observable({searchWord});
    let actorParam = ko.observable({actorSearchWord});
    let isActive = element => {
        return element.toLowerCase() === selectedComponent() ? "active" : "";
    }

    postman.subscribe("changeContent", component => {
        changeContent(component);
    });
    
    postman.subscribe("changeUserView", component => {
        changeContent('loggedin');
    });

    postman.subscribe("userRegister", component => {
        changeContent('register');
    });

    postman.subscribe("changeToLogin", component => {
        changeContent('login');
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
    let actorSearchBtn = () => {
        console.log("Actor search clicked");
        actorParam({actorSearchWord});
        selectedComponent("actorSearch");
    }

    return {
        // showMe,
        searchBtn,
        actorSearchBtn,
        loginBtw,
        searchWord,
        actorSearchWord,
        selectedComponent,
        menuElements,
        menuElements2,
        isActive,
        changeContent,
        currentParams
    }
});