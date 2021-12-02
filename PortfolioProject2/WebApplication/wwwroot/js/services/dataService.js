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

    let getCategories = (callback) => {
        fetch("api/categories")
            .then(response => response.json())
            .then(json => callback(json));
    };

    let deleteCategory = category => {
        fetch(category.url, { method: "DELETE" })
            .then(response => console.log(response.status))
    };

    let createCategory = (category, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(category),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/categories", param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getTitleById,
        getTitles,
        getCategories,
        deleteCategory,
        createCategory
    }
});