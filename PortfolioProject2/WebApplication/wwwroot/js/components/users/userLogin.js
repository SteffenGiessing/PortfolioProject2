define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        let email = ko.observable();
        let password = ko.observable();
        let userLogged = ko.observable();
        let userDetails = ko.observableArray([]);
        let titleId = ko.observableArray([]);
        let showComments = ko.observableArray([]);


        let getUser = (email) => {
            ds.getUser(email, function (data) {
                console.log(data)
                //SAVES THE USER ID
                sessionStorage.setItem('userId', data["userId"])
                sessionStorage.setItem('email', data["emailAddress"])
                userDetails(data);
            });
            if (sessionStorage.getItem('userId') != null){
                console.log("works")
            }
        };



        let loginUser = () => {
            ds.loginUser(email(), password(), function (data) {
                for (let errors in data) {
                    if (errors === 'status') {
                        if (data['status'] === 404) {
                            console.log("HittingBreak?");
                            alert("Email and Password Invalid");
                        }
                        if (data['status'] === 200) {
                            console.log(data['status'])
                            getUser(email())
                            postman.publish('changeUserView');
                        }
                    }
                }

            });
        };


        let getComments = () => {
            ds.getUserComments(function (data) {
                showComments(data)
            });
        }


        let signInUserBtn = () => {
            console.log("sign in button clicked");
            postman.publish('userRegister');
        }


        return {
            userLogged,
            /* loggedInUser,*/
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
