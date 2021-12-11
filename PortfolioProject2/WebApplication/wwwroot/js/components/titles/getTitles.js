define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let titles = ko.observableArray();
        let pageSize = ko.observableArray([10, 15, 20, 25]);
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();
        //let titleId = ko.observableArray([]);
        let primaryTitle = ko.observable();
        let poster = ko.observable();
        let genres = ko.observable()
        let startYear = ko.observable();
        
        /*ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });*/
 
        let getData = url => {
            ds.getTitles(url, data => {
                pageSize(data.pageSize);
                prev(data.prev || undefined);
                next(data.next || undefined);
                titles(data.items);
                console.log(titles());
            })
        }
        
        
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
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = title => {
            console.log(next());
            getData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            let size = selectedPageSize()[0];
            getData(ds.getTitlesUrlWithPageSize(size));
        });
        
        getData();
        
        return {
            //titleId,
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
