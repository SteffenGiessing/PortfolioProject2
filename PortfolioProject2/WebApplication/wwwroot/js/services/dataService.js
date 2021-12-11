define([], () => {
    const titleApi = "http://localhost:5001/api/titles";

    let getJson = (url, callback) => {
        fetch(url).then(response => response.json()).then(callback);
/*    fetch(url).then(res => res.text())          // convert to plain text
            .then(text => console.log(text)).then(callback);*/
    };


    let getTitles = (url, callback) => {
    if (url === undefined) {
        url = titleApi;
    }
    getJson(url, callback);
}

    let getTitlesUrlWithPageSize = size => titleApi + "?pageSize=" + size;

    let getTitleById = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/tt10260014", {method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json)})
    }
    

/*    let  getTitles = (callback) => {
        fetch("http://localhost:5000/api/titles/populartitles", { method: 'GET' })
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
    */
    let getActors = (callback) => {
        fetch("https://localhost:5001/api/actor", { method: 'GET'})
        .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
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
    let searchForTitles = (searchWord, callback ) => {
        fetch("http://localhost:5000/api/titles/searchresult/" + searchWord, { method: 'GET'})
            .then(response => response.json()).then(response => {console.log(json)})
            .then(json => {
                callback(json);
            });
    };
   
    return {
        //getTitleById,
        getTitles,
        getTitle: getJson,
        getTitlesUrlWithPageSize,
        getActors,
        loginUser,
        searchForTitles,
        getUser,
        getUserComments
    }
});