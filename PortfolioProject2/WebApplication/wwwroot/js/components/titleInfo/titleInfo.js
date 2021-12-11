define(['knockout', 'dataService', 'postman'], (ko, ds, postman) => {
    return function (params) {
        //let title = ko.observableArray();
        //let tconst = params.tconst;

        //ds.getTitle(tconst, function (data) { title(data) });

        let titles = ko.observable();

        let titleId = ko.observable();

        let primaryTitle = ko.observable();

        let titleInfo = ko.observableArray();
        
        let startYear = ko.observable();

        let endYear = ko.observable();

        let genres =  ko.observable();
        
        let plot =  ko.observable();
        

        postman.subscribe('changeTitle', title => {
            titles(title);
            titleId(titles().titleId);
            console.log(titles());
            console.log(titleId());
            });
            
        

        /*ds.getGenres(tconst, function (data) {
            genres(data);
            console.log(genres());
        });*/
        

        /*ds.getStartYear(startYear, function (data) {
            startYear(data);
            console.log(startYear());
        });*/
        
        ds.getInfoSpecificTitle(titleId, function (data) {
            titleId(data);
            console.log(titleId());
        });
        

        /*let addToBookmarks = (function(data) {
            ds.addToBookmarks(uconst(), tconst());
        });*/

        return {
            titles,
            primaryTitle,
            titleInfo,
            titleId,
            startYear,
            endYear,
            genres,
            plot
            //addToBookmarks
        }
    }
});