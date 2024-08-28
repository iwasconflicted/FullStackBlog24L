// This will hold our helper functions or method
let userData = {};
// helper function to check our token

const checkToken = () => {
    let result = false;
    let lsData = localStorage.getItem("Token");
    if(lsData && isData != null)
    {
        result = true;
    }
    return result;
}

// helper function or method to createAccount, async and await 
// fetch() json() stringify

const createAccount = async (createduser) =>

{
    const result = await fetch ('http://localhost:5242/api/User/AddUsers', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(createduser)
    })
    if(!result.ok)
    {
        const message = `Yo you have an error home skillet ${
            result.status}`
            throw new Error(message);
        }
        let data = await result.json();
        console.log(data);
        
    }


    const login = async (loginUser) => 
    {
        const result = await fetch ('http://localhost:5242/api/User/Login', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(loginUser)
        })
        if(!result.ok)
        {
            const message = `Yo you have an error home skillet ${
                result.status}`
                throw new Error(message);
            }
            let data = await result.json();
            console.log(data);
    }


    const GetLoggedInUser = async (username) =>
    {
        await fetch(`"http://localhost:5242/api/User/GetUserByUserName/${username}"`)
       
        userData = await result.json();

        console.log(userData)
        
    }

    const LoggedInData = () => 
    {
        return userData;
    }
    


export {checkToken, createAccount, login, GetLoggedInUser, LoggedInData}