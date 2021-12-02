define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observable();
        let titleid = ko.observable();

        ds.getTitles(titleid);

        return {
            titles
        };
    };
});
