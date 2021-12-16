define([], () => {
    // UTILS
    const popularTitlesUrl = "http://localhost:5000/api/titles/populartitles";
    const titlesUrl = "http://localhost:5000/api/titles";

    let getJson = (url, callback) => {
        fetch(url).then(response => response.json()).then(callback);
        /*   fetch(url).then(res => res.text())          // convert to plain text
                   .then(text => console.log(text)).then(callback);*/
    };
    
    
    // METHOD GET FOR TITLES // 
    let getTitleById = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/tt10260014", {method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json)})
    }

    // Popular Titles 
    let getPopularTitles = (url, callback) => {
        if (url === undefined) {
            url = popularTitlesUrl;
        }
        getJson(url, callback);
    }

    let getPopularUrlWithPageSize = size => popularTitlesUrl + "?pageSize=" + size;

    // All Titles
    let getTitles = (url, callback) => {
        if (url === undefined) {
            url = titlesUrl;
        }
        getJson(url, callback);
    }

    let getTitlesUrlWithPageSize = size => titlesUrl + "?pageSize=" + size;

    
    let getInfoSpecificTitle = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/titleinfo" + titleId, { method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };

    let searchForTitles = (searchWord, callback ) => {
        fetch("http://localhost:5000/api/titles/searchresult/" + searchWord, { method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
    
    let searchForActor = (searchWord, callback) =>  {
      fetch("http://localhost:5000/api/actor/namesearch/"+ searchWord)
          .then(response => response.json())
          .then(json => { callback(json);
          });
    };
    // METHOD GET FOR ACTORS //
    
    let getActors = (callback) => {
        fetch("http://localhost:5001/api/actor", { method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
    
    // METHOD GET FOR USER //
    let getUser = (email, callback) => {
        fetch("http://localhost:5000/api/user/"+email, {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer' + localStorage.getItem('jwtToken'),
            },
            method: 'GET'})
            .then(response => response.json()).then(json => {
            callback(json);
        });
    }
    
    let loginUser = (email, password, callback) => {
        let data = {"EmailAddress": email, "Password": password};
        console.log(data);
        console.log(email,password);
        fetch("http://localhost:5000/api/user/login", {
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => response.json().then(response => localStorage.setItem('jwtToken', response.tokenJwt))
            .then(callback));
    };
    
    let getUserComments = (callback) => {
        let userid = sessionStorage.getItem("userId").toString();
        console.log(userid)
        fetch("http://localhost:5000/api/comments/"+userid +"/comments", {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                //THIS LINE IS NEEDED TO BE AUTHENTICATED BY THE BACKEND! ONLY WORKS WHEN YOU ARE LOGGED IN
                'Authorization': localStorage.getItem('jwtToken'),
            },
            method: 'GET'})
            .then(response => response.json()).then(json => {
            callback(json);
        });
    };
    
    // METHOD POST
    let addToBookmarks = (userId, titleId, callback) => {
        let data = {"userId": userId, "titleId":titleId};
        userId =  sessionStorage.getItem("userId");
        //titleId = 'tt5813916'
        console.log(userId);
        console.log(titleId);
        fetch("http://localhost:5000/api/bookmarks/" + userId + "/titlebookmarks/"+ titleId, {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': localStorage.getItem('jwtToken'),
            },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => response.json())
            .then(json => {console.log(json);
            });
    };

    let addTitleReview = (userId, titleId, commentText, callback) => {
        userId =  sessionStorage.getItem("userId");
        let data = {"UserId": userId, "TitleId":titleId, "CommentText":commentText};
        console.log(userId);
        console.log(titleId);
        console.log(commentText);
        fetch("http://localhost:5000/api/comments/add/usercomment/", {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': localStorage.getItem('jwtToken'),
            },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => response.json())
            .then(json => {console.log(json);
            });
    };

    let addRating = (userId, titleId, ratingNumber, callback) => {
        userId =  80//sessionStorage.getItem("userId");
        let data = {"UserId": userId, "TitleId":titleId, "ratingNumber":ratingNumber};
        console.log(userId);
        console.log(titleId);
        console.log(ratingNumber);
        fetch("http://localhost:5000/api/ratings/add/userrating/", {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': localStorage.getItem('jwtToken'),
            },
            method: 'POST',
            body: JSON.stringify(data)
            }).then(response => response.json())
            .then(json => {console.log(json);
            });
    };

    
    return {
        //getTitleById,
        getPopularUrlWithPageSize,
        getTitles,
        getPopularTitles,
        getTitlesUrlWithPageSize,
        getActors,
        loginUser,
        searchForTitles,
        searchForActor,
        getUser,
        getUserComments,
        getInfoSpecificTitle,
        addToBookmarks,
        addTitleReview,
        addRating
    }
});