define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray([]);
        let pageSizes = [5, 10, 15, 20];
        let selectedPageSize = ko.observableArray([10]);
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
        let actors = ko.observableArray([]);
        /*ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });*/

        let selectTitle = title => {
            selectedTitle(title);
            postman.publish('changeTitle', selectedTitle());
        }

        ds.getTitles(function(data) {
            prev(data.prev || undefined);
            next(data.next || undefined);
            titles(data);
            console.log(titles())
        });

        ds.getActorsInTitle(titleId,function(data) {
            actors(data);
            console.log(actors());
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
            //titleId,
            titleId,
            actors,
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