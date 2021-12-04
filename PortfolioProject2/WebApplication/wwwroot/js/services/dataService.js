define([], () => {
    
    let getTitleById = (titleId, callback) => {
        fetch("api/titles/" + titleId)
            .then(response => response.json())
            .then(callback)
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