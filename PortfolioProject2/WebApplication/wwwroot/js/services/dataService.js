define([], () => {
    
    let getTitleById = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/tt10260014", {method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json)})
    }
    
    /*let getTitles = (url, searchString, callback) => {
        if (url === undefined) {
            url = titleApiUrl + "search-title/" + searchString;
        }
        
    }*/
    
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
   
    return {
        getTitleById,
        getTitles,
        getActors
    }
});