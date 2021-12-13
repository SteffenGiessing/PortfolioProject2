define(['knockout', 'dataService', 'postman'], (ko, ds, postman) => {
    return function (params) {


        let titles = ko.observable();

        let titleId = ko.observable();

        let userId = ko.observable();

        let primaryTitle = ko.observable();

        let titleInfo = ko.observableArray();

        let actors = ko.observableArray([]);

        let startYear = ko.observable();

        let endYear = ko.observable();

        let genres =  ko.observable();

        let plot =  ko.observable();

        let awards =  ko.observable();

        let bookMark = ko.observable();

        let averageRating = ko.observable();

        let numVotes = ko.observable();


        postman.subscribe('changeTitle', title => {
            titles(title);
            titleId(titles().titleId);
            console.log(titles());
            console.log(titleId());
        });
        
        
        /*let getActorsInTitle = (function(data) {
            ds.getActorsInTitle(titleId());
        });*/


        let getActorsInTitle =
            ds.getActorsInTitle(titleId, function(data) {
            actors(data);
            console.log(actors())
        });
        
        ds.getInfoSpecificTitle(titleId, function (data) {
            titleInfo(data);
            console.log(titleInfo());
        });

        let addToBookmarks = (function(data) {
            ds.addToBookmarks(userId(), titleId());
        });





        return {
            titles,
            bookMark,
            primaryTitle,
            titleInfo,
            actors,
            titleId,
            startYear,
            endYear,
            genres,
            plot,
            awards,
            averageRating,
            numVotes,
            addToBookmarks,
            getActorsInTitle
        }
    }
});