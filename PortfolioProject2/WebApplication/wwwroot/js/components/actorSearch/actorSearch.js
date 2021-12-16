define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let actors = ko.observableArray([]);
        let searchActorString = params.actorSearchWord;
        let selectedActor = ko.observable();
        
        let selectActor = actors => {
            selectedActor(actors);
            postman.publish('changeActor', selectedActor());
        }
        ds.searchForActor(searchActorString, function (data) {
            console.log(data + "ARE WE HERE")
            actors(data)
        });
        return {
            actors,
            selectActor
        }
    };
});