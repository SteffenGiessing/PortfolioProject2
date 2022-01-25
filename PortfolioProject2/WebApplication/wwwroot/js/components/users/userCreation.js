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
                            getUser(emailaddress())
                            postman.publish('changeUserView');
            })
        }

        let getUser = (emailaddress) => {
            ds.getUser(emailaddress, function (data) {
                console.log(data)
                //SAVES THE USER ID
                sessionStorage.setItem('userId', data["userId"])
                sessionStorage.setItem('email', data["emailAddress"])
                userDetails(data);
            });
        };
        
        let switchToLogin = () => {
            console.log("sign in button clicked");
            postman.publish('changeToLogin');
        }
        
        
        return {
            switchToLogin,
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