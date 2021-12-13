define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
            titleId = ko.observable();
            actors = ko.observableArray([]);
            primaryName = ko.observable()

        ds.getActors(function(data) {
            actors(data);
            console.log(actors());
        });
        
        return {
            titleId,
            actors,
            primaryName
        };
    };
});
