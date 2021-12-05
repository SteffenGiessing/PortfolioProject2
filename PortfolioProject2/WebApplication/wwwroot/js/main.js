/// <reference path="lib/jquery/dist/jquery.min.js" />
/// <reference path="lib/requirejs/text.js" />
/// <reference path="lib/knockout/build/output/knockout-latest.debug.js" />


require.config({
    baseUrl: 'js',
    paths: {
        text: "lib/requirejs/text",
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        dataService: "services/dataService",
        postman: "services/postman"
    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("get-titles", {
        viewModel: { require: "components/titles/getTitles" },
        template: { require: "text!components/titles/getTitles.html" }
    });
});

require(["knockout", "viewmodel"], function (ko, vm) {
/*
    console.log(vm.currentView);
*/

    ko.applyBindings(vm);

});