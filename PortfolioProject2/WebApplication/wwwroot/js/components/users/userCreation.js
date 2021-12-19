define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let firstname = ko.observable();
        let username = ko.observable();
        let lastname = ko.observable();
        let emailaddress = ko.observable();
        let password = ko.observable();
              // let createuser = (function (data) {
              //     ds.createUser(firstname(), lastname(), username(), emailaddress(), password());
              // }) 
              //
        let createeuser = () => {
            ds.createUser(firstname(), lastname(), username(), emailaddress(), password(), function (data){
                createeuser(data);
                //console.log(createdUser());
            })
        }
        
        return {
            firstname,
            lastname,
            username,
            emailaddress,
            password,
           // createuser,
            createeuser
        };
    };
});