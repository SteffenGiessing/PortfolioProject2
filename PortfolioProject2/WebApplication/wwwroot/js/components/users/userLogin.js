﻿define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){
        // let currentTemplate = ko.observe("loginUser");
        // let login = ko.observableArray();
        let email = ko.observable();
        let password = ko.observable();
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        
        console.log(email, password);
        console.log(email(), password());

/*
        ds.loginUser(function(data) {
            
        }
*/

        let loginUser = () => {
         /*   postman.publish("loginUser", {EmailAddress: email(), Password: password()});*/
            ds.loginUser(email(), password()); 
              /*  console.log(data, "COPY SOMTHING");
                userDetails(data);
                email(email());
                password(password());*/
            
        };
        
        let signInUserBtn = () =>{
            console.log("sign in button clicked");
        }

        ds.getTitleById(titleId, function(data) {
            titleId(data);
            console.log(titleId());
        });
        
        return {
            // currentTemplate,
            titleId,
            email,
            password,
            signInUserBtn,
            loginUser
        };
    };
});