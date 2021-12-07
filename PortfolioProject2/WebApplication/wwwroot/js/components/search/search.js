define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let searchString = params.titlesearch;


        /*ds.searchForTitles(searchString(), function(data) {
            titles(data.titles);
            console.log(data());
        });*/

        ds.search(titles, function (data) {
            titles(data);
            console.log(titles());
        });

        return {
            titles,
            searchString
        }
    };
});
