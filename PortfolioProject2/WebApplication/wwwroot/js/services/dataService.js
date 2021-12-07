define([], () => {
    
    let getTitleById = (titleId, callback) => {
        fetch("http://localhost:5000/api/titles/tt10260014", {method: 'GET'})
            .then(response => response.json())
            .then(json => {
                callback(json)})
    };
    
    let  getTitles = (callback) => {
        fetch("https://localhost:5000/api/titles", { method: 'GET' })
            .then(response => response.json())
            .then(json => {
                callback(json);
            });
    };
    
    let loginUser = (email,password, callback) => {
        let data ={"EmailAddress": email, "Password": password};
        console.log(data)
        console.log(email, password);
        fetch("http://localhost:5000/api/user/login", { 
            headers: { 
                "Content-Type": "application/json",
                "Accept":"application/json",
            }, 
                method: 'POST', 
                body: JSON.stringify(data),
        }
        ).then(response => response.json()).then(json => {
                callback(json)
            });
    };
   
    return {
        getTitleById,
        getTitles,
        loginUser
    }
});