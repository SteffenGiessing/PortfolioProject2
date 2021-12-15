define(['knockout', 'dataService', 'postman'], (ko, ds, postman) => {
    return function (params) {
        

        let titles = ko.observable();

        let titleId = ko.observable();
        
        let userId = ko.observable();

        let primaryTitle = ko.observable();

        let titleInfo = ko.observableArray();

        let startYear = ko.observable();

        let endYear = ko.observable();

        let genres =  ko.observable();

        let plot =  ko.observable();

        let awards =  ko.observable();
        
        let averageRating = ko.observable();
        
        let numVotes = ko.observable();

        let bookMark = ko.observable();
        
        let titleReview = ko.observable();
        
        let commentText = ko.observable();
        

        postman.subscribe('changeTitle', title => {
            titles(title);
            titleId(titles().titleId);
            console.log(titles());
            console.log(titleId());
        });

        ds.getInfoSpecificTitle(titleId, function (data) {
            titleInfo(data);
            console.log(titleInfo());
        });
        
       let addToBookmarks = (function(data) {
           ds.addToBookmarks(userId(), titleId());
           bookMark(data);
           console.log(bookMark());
        });

        let addTitleReview = (function(data) {
            ds.addTitleReview(userId(), titleId(), commentText());
            titleReview(data);
            console.log(titleReview());
        });
       
       /*let addToBookmarks = () => ds.addToBookmarks(userId, titleId, function (data) {
           bookMark(data);
           console.log(bookMark());
       });*/

        
        
        

        return {
            titles,
            bookMark,
            titleReview,
            commentText,
            addToBookmarks,
            addTitleReview,
            primaryTitle,
            titleInfo,
            titleId,
            startYear,
            endYear,
            genres,
            plot,
            awards,
            averageRating,
            numVotes
        }
    }
});