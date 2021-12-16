define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params){
        let firstName = ko.observable();
        let email = ko.observable();
        let password = ko.observable();
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        let showComments = ko.observableArray([]);
        let userId = ko.observable();


        let getUserData = () => {
            ds.getUser(email, function (data) {
                userId =  sessionStorage.getItem("userId");
               userDetails(data);
               console.log(userDetails());
            });
        };
        


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
            /*            getComments*/
        };
    };
});