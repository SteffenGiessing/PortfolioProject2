define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let pageSizes = [5, 10, 15, 20];
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();
        let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let poster = ko.observable();
        let genres = ko.observable()
        let startYear = ko.observable();
        
        ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });
        
        ds.getTitles(function(data) {
            prev(data.prev || undefined);
            next(data.next || undefined);
            titles(data.items);
            console.log(titles())
        });

        let showPrev = title => {
            console.log(prev());
            getTitles(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = title => {
            console.log(next());
            getTitles(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            let size = selectedPageSize()[0];
            getTitles(ds.getTitlesUrlWithPageSize(size));
        });
        
        
        return {
            titleId,
            titles,
            primaryTitle,
            startYear,
            genres,
            pageSizes,
            selectedPageSize,
            enableNext,
            enablePrev,
            showPrev,
            showNext,
            poster
        };
    };
});
