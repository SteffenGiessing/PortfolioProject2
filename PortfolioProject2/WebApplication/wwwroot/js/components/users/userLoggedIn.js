define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){
        let firstName = ko.observable();
        let email = ko.observable();
        let password = ko.observable();
        let userId = ko.observable();
        let commentText = ko.observable();
        
        let changeFirstname = ko.observable();
        let changeLastname = ko.observable();
        let changeEmail = ko.observable();
        let changeUsername = ko.observable();
        
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        let showComments = ko.observableArray([]);

        let getUserData = () => {
            email = sessionStorage.getItem("email")
            ds.getUser(email, function (data) {
               userDetails(data);
               console.log(userDetails());
            });
        };
        
        let getUserComments = () => {
            ds.getUserComments(function (data) {
                showComments(data)
                console.log(showComments() + "THIS DATA");
            });
        }
        
        let updateUser = () => {
            userId = sessionStorage.getItem("userId")
            ds.updateUser(userId, changeFirstname(), changeLastname(), changeEmail(), changeUsername() ,function(data){
                
            });
        }
        
        
        


        /*postman.subscribe('changeUserView', function(data){
            data;
        });*/

        /*postman.subscribe('changeUserView', user => {
            ds.getUser(email, callback => {
                getUser(email().userDetails)
                console.log(getUser());
            })
        });*/
        /*      
        
              let getUser = (email) => {
                  ds.getUser(email, function (data) {
                      console.log(data["userId"])
                      //SAVES THE USER ID
                      sessionStorage.setItem('userId', data["userId"] )
                      userDetails(data);
                  });
              };
              console.log("worked");*/
        /*
              */
        /* 
       */

        /*        let getComments = () => {
                  ds.getUserComments(function(data) {
                      showComments(data)
                  });
              }
        
              getComments();*/

        return {
            getUserData,
            titleId,
            email,
            password,
            userDetails,
            showComments,
            getUserComments,
            firstName,
            commentText,
            updateUser,
            changeFirstname,
            changeLastname,
            changeEmail,
            changeUsername
            /*            getComments*/
        };
    };
});