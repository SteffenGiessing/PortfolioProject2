define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){
     
        let email = ko.observable();
        let password = ko.observable();
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        let showComments = ko.observableArray([]);
        
        console.log(email, password);
 
        let loginUser = () => {
            ds.loginUser(email(), password(), function(data) {
                getUser(email())
            });
            

        };
        let getUser = (email) => {
            ds.getUser(email, function (data) {
              userDetails(data);
             // getUserComments(data.index("userId").valueOf);
            });
        };
        
        let getComments = () => {
            ds.getUserComments( function(data) {
               showComments(data) 
            });
        }
        
        

        let signInUserBtn = () =>{
            console.log("sign in button clicked");
        }

        
        return {
            titleId,
            email,
            password,
            userDetails,
            signInUserBtn,
            loginUser,
            showComments,
            getComments
        };
    };
});