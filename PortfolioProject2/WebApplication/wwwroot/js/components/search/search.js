define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let searchString = params.searchWord;
        let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let averagerating = ko.observable();
        let poster = ko.observable();
        let awards =  ko.observable();
        let log = ko.observable("bob")
        let selectedTitle = ko.observable();
        let averageRating = ko.observable();
        let numVotes = ko.observable();
        
        let selectTitle = title => {
            selectedTitle(title);
            postman.publish('changeTitle', selectedTitle());
        }

        ds.searchForTitles(searchString(), function (data) {
            titles(data);
            console.log( titles())
        });

        return {
            selectTitle,
            selectedTitle,
            log,
            titles,
            titleId,
            primaryTitle,
            averagerating,
            poster,
            awards,
            averageRating,
            numVotes,
        };
    };
});