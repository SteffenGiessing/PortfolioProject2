/// <reference path="lib/jquery/dist/jquery.min.js" />
/// <reference path="lib/requirejs/text.js" />
/// <reference path="lib/knockout/build/output/knockout-latest.debug.js" />


require.config({
    baseUrl: 'js',
    paths: {
        text: "lib/requirejs/text",
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        bootstrap: "../css/lib/bootstrap/dist/js/bootstrap.bundle.min",
        dataService: "services/dataService",
        postman: "services/postman"
    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("home", {
        viewModel: {require: "components/home/getHome"},
        template: {require: "text!components/home/getHome.html"}
    });

    ko.components.register("popular titles", {
        viewModel: {require: "components/titles/getTitles"},
        template: {require: "text!components/titles/getTitles.html"}
    });

    ko.components.register("actorsearch", {
        viewModel: {require: "components/actorSearch/actorSearch"},
        template: {require: "text!components/actorSearch/actorSearch.html"}
    });

    ko.components.register("get-actors", {
        viewModel: {require: "components/actors/getActors"},
        template: {require: "text!components/actors/getActors.html"}
    });

    ko.components.register("loggedin", {
        viewModel: {require: "components/users/userLoggedIn"},
        template: {require: "text!components/users/userLoggedIn.html"}
    });

    ko.components.register("login", {
        viewModel: {require: "components/users/userLogin"},
        template: {require: "text!components/users/userLogin.html"}
    });

    ko.components.register("register", {
        viewModel: {require: "components/users/userCreation"},
        template: {require: "text!components/users/userCreation.html"}
    });

    ko.components.register("search", {
        viewModel: {require: "components/search/search"},
        template: {require: "text!components/search/search.html"}
    });

    ko.components.register("comments", {
        viewModel: {require: "components/createComment/createComment"},
        template: {require: "text!components/search/search.html"}
    });

    ko.components.register("title-info", {
        viewModel: {require: "components/titleInfo/titleInfo"},
        template: {require: "text!components/titleInfo/titleInfo.html"}
    });


});

require(["knockout", "viewmodel", "bootstrap"], function (ko, vm) {

    ko.applyBindings(vm);

});