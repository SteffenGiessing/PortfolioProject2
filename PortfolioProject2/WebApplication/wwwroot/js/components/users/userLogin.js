define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){
       // let currentTemplate = ko.observe("loginUser");
       // let login = ko.observableArray();
        let email = ko.observable();
        let password = ko.observable();
        console.log(email, password);

        console.log(email(), password());
        
        let loginUser =() =>{
            //postman.publish("loginUser", {EmailAddress: email(), Password: password()});
        
            ds.loginUser(email(), password());
           // console.log(data, "COPY SOMTHING");
         //   email(email());
          //  password(password());
            //});
        };
        
        
        
        let signInUserBtn = () =>{
            console.log("sign in button clicked");
            currentTemplate("signIn-page");
        }
        return {
           // currentTemplate,
            email,
            password,
            signInUserBtn,
            loginUser
        };
    };
});