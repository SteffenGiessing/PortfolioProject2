define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let popularTitles = ko.observableArray([]);
        let pageSize = [5, 10, 15, 20];
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();
        //let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let poster = ko.observable();
        let genres = ko.observable()
        let startYear = ko.observable();
        let titleId = ko.observable();
        
        /*ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });*/

        let getTitlesData = url => {
            ds.getTitles(url, data => {

                prev(data.prev || undefined);
                next(data.next || undefined);
                titles(data.items);
                console.log(titles());
            })
        }


        let getPopularTitlesData = url => {
            ds.getPopularTitles(url, data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                popularTitles(data.items);
                console.log(popularTitles());
            })
        }

        getPopularTitlesData();
/*
        ds.getTitles(function(data) {
            prev(data.prev || undefined);
            next(data.next || undefined);
            titles(data);
            console.log(titles())
        });
*/

        let showPrev = title => {
            console.log(prev());
            getPopularTitlesData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = title => {
            console.log(next());
            getPopularTitlesData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            let size = selectedPageSize()[0];
            getPopularTitlesData(ds.getPopularUrlWithPageSize(size));
        });
        
        
        return {
            //titleId,
            popularTitles,
            titles,
            primaryTitle,
            startYear,
            genres,
            pageSize,
            selectedPageSize,
            enableNext,
            enablePrev,
            showPrev,
            showNext,
            poster
        };
    };
});
