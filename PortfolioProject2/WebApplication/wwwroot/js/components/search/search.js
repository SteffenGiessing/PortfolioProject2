define(['knockout', 'dataService', 'postman', "lib/knockout/build/output/knockout-latest"], function (ko, ds, postman, selectedPageSize) {
    return function (params) {
        let searchForTitles = ko.observableArray([]);
        let searchString = params.searchWord;
        let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let averagerating = ko.observable();
        let poster = ko.observable();
        let awards = ko.observable();
        let searchActorString = params.actorSearchWord;
        let selectedTitle = ko.observable();
        let averageRating = ko.observable();
        let numVotes = ko.observable();

        let selectTitle = title => {
            selectedTitle(title);
            postman.publish('changeTitle', selectedTitle());
        }

/*        let searchForTitles = url => {
            ds.searchForTitles(url, data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                searchForTitles(data.items);
                console.log(searchForTitles());
            })
        }
        */
        ds.searchForTitles(searchString(), function (data) {
            titles(data);
            console.log(titles())
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
            selectTitle,
            selectedTitle,
            titles,
            titleId,
            primaryTitle,
            averagerating,
            poster,
            awards,
            averageRating,
            numVotes,
        };
    };
});