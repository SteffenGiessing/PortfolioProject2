define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let searchString = params.searchWord;
        let pageSizes = [5, 10, 15, 20];
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();
        let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let averagerating = ko.observable();
        let poster = ko.observable();


        ds.searchForTitles(searchString(), function (data) {
            titles(data);
            console.log( titles())
        });

        let showPrev = title => {
            console.log(prev());
            searchForTitles(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = title => {
            console.log(next());
            searchForTitles(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            let size = selectedPageSize()[0];
            searchForTitles(ds.searchForTitlesWithPageSize(size));
        });

        return {
            titles,
            titleId,
            primaryTitle,
            averagerating,
            pageSizes,
            selectedPageSize,
            enableNext,
            enablePrev,
            showPrev,
            showNext,
            poster,
            imageUrl
        };
    };
});