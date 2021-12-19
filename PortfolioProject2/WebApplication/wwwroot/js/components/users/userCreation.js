define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let firstname = ko.observable();
        let username = ko.observable();
        let lastname = ko.observable();
        let emailaddress = ko.observable();
        let password = ko.observable();
        let email = ko.observable();
        let userDetails = ko.observable();
        
        let createeuser = () => {
            ds.createUser(firstname(), lastname(), username(), emailaddress(), password(), function (data){
                console.log(data);
                postman.publish('changeUserView');
            })
        }

        let getUser = (email) => {
            ds.getUser(email, function (data) {
                console.log(data)
                //SAVES THE USER ID
                sessionStorage.setItem('userId', data["userId"])
                sessionStorage.setItem('email', data["emailAddress"])
                userDetails(data);
            });
        };

        getUser();
        
        return {
            email,
            firstname,
            lastname,
            username,
            emailaddress,
            password,
            createeuser
        };
    };
});