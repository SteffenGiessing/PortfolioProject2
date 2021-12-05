define([], () => {
    
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
   
    return {
        getTitleById,
        getTitles
    }
});