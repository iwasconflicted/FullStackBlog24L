<!-- Goal is to Create FullStack web app for Blog Site -->
<!-- Backend will be done in .net8, web api, Ef core, sql server -->
<!-- Front end will done in React with JS -->
<!-- Deploy with Azure Static web apps -->


<!-- Create an API for blog, must handle all CRUD functions -->

<!-- 
Create
Read
Update
Delete
 -->

 <!-- In this app, the user should be able to login so need login page -->

 <!-- Create Account page -->
<!-- Blog view Post page of published items -->
<!-- Dashboard page(this is the profile page will edit, delete, publish and unpublish your blog post) -->

<!-- SQL server from azure for our database -->

<!-- Folder structure -->

<!-- Controllers/Folders 
    UserController: this will handle all our user interactions
    All our endpoints will be in this controller for users

-->

<!-- Login/endpoint

    AddUser//endpoint
    UpdateUser//endpoint
    DeleteUser//endpoint

 -->

<!-- BlogController

    AddBlogItems//endpoint
    GetAllBlogItems//endpoint
    GetAllBlogItemsByCategory//endpoint
    GetAllBlogItemsByTag//endpoint
    GetAllBlogItemsByDate//endpoint
    UpdateBlogItems//endpoint
    DeleteBlogItems//endpoint

 -->

 <!-------------------------------- Models ------------------------------>

 <!-- Models Folder Structure -->

 <!-- UserMode 

    id: int
    username: string
    Salt: string
    Hash: string
 -->

 <!-- BlogItemModel 
    
    id: int
    UserId: int
    PublisherName: string
    Title: string
    Description: string
    Date: string
    Category: string
    IsPublished: bool
    IsDeleted: bool
 
 -->

 <!------------ Items that will be saved to our database are above ------------>





 <!-- LoginModel
        Username: string
        Password: string
    CreateAccountModel
        id:int
        Username: string
        password: string
    PasswordModel
        Salt: string
        Hash: string
 
  -->

  <!-- Services/ Folder
  
    UserService//file
        GetUserByUsername
        Login
        AddUser
        DeleteUser
    BlogItemService
        AddBlogItems
        GetAllBlogItemsByCategory//functions(methods)   
        GetAllBlogItemsByTag//functions(methods)   
        GetAllBlogItemsByDate//functions(methods)   
        UpdateBlogItems
        DeleteBlogItems
        GetUsersById
   -->

   <!-- PasswordServices//file
   
        Hash password

        Very hash password

   
    -->