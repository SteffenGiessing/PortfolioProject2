define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let primaryTitle = ko.observable();
        let genres = ko.observable()
        let titleId = ko.observableArray([]);
        let startYear = ko.observable();

        /*ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });

        /*       ds.getTitles(function(data) {
                   titles(data);
                   console.log(titles)
               });
       */
        return {
            titleId,
            primaryTitle,
            startYear,
            genres
        };
    };
});
