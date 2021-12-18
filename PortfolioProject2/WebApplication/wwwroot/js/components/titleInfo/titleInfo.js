define(['knockout', 'dataService', 'postman'], (ko, ds, postman) => {
    return function (params) {


        let titles = ko.observable();

        let titleId = ko.observable();

        let userId = ko.observable();

        let primaryTitle = ko.observable();

        let titleInfo = ko.observableArray();

        let startYear = ko.observable();

        let endYear = ko.observable();

        let genres = ko.observable();

        let plot = ko.observable();

        let awards = ko.observable();

        let averageRating = ko.observable();

        let numVotes = ko.observable();

        let commentText = ko.observable();

        let ratingNumber = ko.observable();


        postman.subscribe('changeTitle', title => {
            titles(title);
            titleId(titles().titleId);
            console.log(titles());
        });

        ds.getInfoSpecificTitle(titleId, function (data) {
            titleInfo(data);
        });

        let addToBookmarks = (function (data) {
            ds.addToBookmarks(userId(), titleId());
        });

        let addTitleReview = (function (data) {
            ds.addTitleReview(userId(), titleId(), commentText());
        });

        let addRating = (function (data) {
            ds.addRating(userId(), titleId(), ratingNumber());
        });


        return {
            titles,
            primaryTitle,
            titleInfo,
            titleId,
            startYear,
            endYear,
            genres,
            plot,
            awards,
            averageRating,
            numVotes,
            addToBookmarks,
            addTitleReview,
            commentText,
            addRating,
            ratingNumber
        }
    }
});