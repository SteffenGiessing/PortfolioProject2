define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let actors = ko.observableArray([]);
        let primaryName = ko.observable();
        let role = ko.observable();
        /* let searchActorString = params.actorSearchWord;*/
        let searchActorString = ko.observable();
        let selectedActor = ko.observable();


        let getActorData = () => {
            ds.searchForActor(searchActorString(), function (data) {
                console.log(searchActorString)
                actors(data);
                console.log(actors());

            });
        };

        /*      
               
               /*    
               let selectActor = actors => {
                   selectedActor(actors);
                   postman.publish('changeActor', selectedActor());
               }
               
               ds.searchForActor(searchActorString(), function (data) {
                   console.log(data + "ARE WE HERE")
                   actors(data)
                   console.log(actors())
               });*/


        return {
            role,
            primaryName,
            actors,
            getActorData,
            searchActorString
            /*selectActor*/
        }
    };
});