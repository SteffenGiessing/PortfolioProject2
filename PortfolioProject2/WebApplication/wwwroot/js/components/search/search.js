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
        let log = ko.observable("bob")

        ko.bindingHandlers.img = {
            update: function(element, valueAccessor) {
                //grab the value of the parameters, making sure to unwrap anything that could be observable
                var value = ko.utils.unwrapObservable(valueAccessor()),
                    src = ko.utils.unwrapObservable(value.src),
                    fallback = ko.utils.unwrapObservable(value.fallback),
                    $element = $(element);

                //now set the src attribute to either the bound or the fallback value
                if (src) {
                    $element.attr('src', src);
                } else {
                    $element.attr('src', fallback);
                }
            },
            init: function(element, valueAccessor) {
                var $element = $(element);

                //hook up error handling that will unwrap and set the fallback value
                $element.error(function() {
                    var value = ko.utils.unwrapObservable(valueAccessor()),
                        fallback = ko.utils.unwrapObservable(value.fallback);

                    $element.attr('src', fallback);
                });
            }
        }

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
            log,
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
        };
    };
});