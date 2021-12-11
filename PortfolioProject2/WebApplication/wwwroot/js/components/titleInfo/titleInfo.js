define(['knockout', 'dataService', 'postman'], (ko, ds, postman) => {
    return function (params) {
        

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

        ds.getInfoSpecificTitle(titleId, function (data) {
            titleId(data);
            console.log(titleId());
        });
        

        return {
            titles,
            primaryTitle,
            titleInfo,
            titleId,
            startYear,
            endYear,
            genres,
            plot
        }
    }
});