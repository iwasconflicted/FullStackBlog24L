// This will hold our helper functions or method
let userData = {};

if(localStorage.getItem("UserData"))
{
    userData = JSON.parse(localStorage.getItem("UserData"))
}

// helper function to check our token

const checkToken = () => {
    let result = false;
    let IsData = localStorage.getItem("Token");
    if(IsData && IsData != null)
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
            if(data.token != null)
            {
                localStorage.setItem("Token", data.token)
                // localStorage.setItem("UserData", JSON.stringify(data.user));
            }
            console.log(data, "login method");
            return data;
    }


    const GetLoggedInUser = async (username) =>
    {
        let result = await fetch(`http://localhost:5242/api/User/GetUserByUserName/${username}`)
       
        userData = await result.json();
        console.log(userData,"get loggedin")
        localStorage.setItem("UserData", JSON.stringify(userData));
        userData = JSON.parse(localStorage.getItem("UserData"))      
    }

    const LoggedInData = () => 
    {
        if(!userData && localStorage.getItem("UserData"))
        {
            userData = JSON.parse(localStorage.getItem("UserData"))
        }
        return userData;
    }
    

    // we need a function to help us add our blog items
    const AddBlogItems = async (blogItems) => 
    {
        const result = await fetch ('http://localhost:5242/api/blog/AddBlogItems', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(blogItems)
        })
        if(!result.ok)
        {
            const message = `Yo you have an error home skillet ${
                result.status}`
                throw new Error(message);
            }
            let data = await result.json();
            console.log(data,"addBlogItems");
            return data;    
        }

    const sendData = async (controller,endpoint,passedInData) => 
{
    const result = await fetch (`http://localhost:5242/api/${controller}/${endpoint}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(passedInData)
    })
    if(!result.ok)
    {
        const message = `Yo you have an error home skillet ${
            result.status}`
            throw new Error(message);
        }
        let data = await result.json();
        console.log(data, "send data");
        return data; 
}

// function to help us get our blogitems
    const getBlogItems = async () =>
    {
        let result = await fetch("http://localhost:5242/api/blog/GetBlogItems")
       
       let data = await result.json();
        console.log(data,"blogItems")
        return data;
    }

// create a function to hit our GetItemsByUserId
    const GetItemsByUserId = async (UserId) =>
    {
        let result = await fetch(`http://localhost:5242/api/blog/GetItemsByUserId/${UserId}`)
       
        let data = await result.json();
         console.log(data,"blogItemsiD")
         return data;
    }


export {checkToken, createAccount, login, GetLoggedInUser, LoggedInData, AddBlogItems, sendData, getBlogItems, GetItemsByUserId}