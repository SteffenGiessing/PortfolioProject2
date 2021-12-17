define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let popularTitles = ko.observableArray([]);
        let pageSizes = [8, 12, 20, 24];
        let selectedPageSize = ko.observableArray([12]);
        let prev = ko.observable();
        let next = ko.observable();
        let primaryTitle = ko.observable();
        let poster = ko.observable();
        let genres = ko.observable()
        let startYear = ko.observable();
        let titleId = ko.observableArray([]);
        let selectedTitle = ko.observable();
        let awards = ko.observable();
        let averageRating = ko.observable();
        let numVotes = ko.observable();
        
        
        /* Switch from Popular Title to Title Informations*/
        let selectTitle = title => {
            selectedTitle(title);
            postman.publish('changeTitle', selectedTitle());
        }

        /* Retrieve the popular titles + pagination */
        let getPopularTitlesData = url => {
            ds.getPopularTitles(url, data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                popularTitles(data.items);
                console.log(popularTitles());
            })
        }
        
        /*Call the popular titles function*/
        getPopularTitlesData();

        /* Pagination Utilities */
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
            popularTitles,
            //titleId,
            titleId,
            titles,
            primaryTitle,
            startYear,
            genres,
            awards,
            averageRating,
            numVotes,
            pageSizes,
            selectedPageSize,
            enableNext,
            enablePrev,
            showPrev,
            showNext,
            poster,
            selectedTitle,
            selectTitle
        };
    };
});