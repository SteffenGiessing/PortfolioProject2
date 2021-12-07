define([], () => {

    const titleApiUrl = "api/titles";

    /*let getJSON = (url, callback) => {
        fetch(url, {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')
            }
        }).then(response => response.json().then(callback));
    }*/
    
    let getTitleById = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/tt10260014", {method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json)})
    }
    
    let  getTitles = (callback) => {
        fetch("https://localhost:5001/api/titles", { method: 'GET' })
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
    
    let getActors = (callback) => {
        fetch("https://localhost:5001/api/actor", { method: 'GET'})
        .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };

   /*let searchForTitles = (url, searchWord, callback) => {
        if (url === undefined) {
            url = titleApiUrl + "/searchresult/" + searchWord;
        }
        getJSON(url, callback);
    };*/
  
    let search = (callback, searchWord) => {
        fetch("https://localhost:5001/api/titles/searchresult/" + searchWord)
            .then(response => response.json())
            .then(json => {
                    callback(json);
                });
        }
   
    return {
        getTitleById,
        getTitles,
        getActors,
        search
    }
});