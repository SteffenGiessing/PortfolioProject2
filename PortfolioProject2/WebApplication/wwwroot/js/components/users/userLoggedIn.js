define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){

        let email = ko.observable();
        let password = ko.observable();
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        let showComments = ko.observableArray([]);
        
        let getUser = (email) => {
            ds.getUser(email, function (data) {
                console.log(data["userId"])
                //SAVES THE USER ID
                sessionStorage.setItem('userId', data["userId"] )
                userDetails(data);
            });
        };

        let getComments = () => {

            ds.getUserComments(function(data) {
                showComments(data)
            });
        }
        
        return {
            titleId,
            email,
            password,
            userDetails,
            showComments,
            getComments
        };
    };
});