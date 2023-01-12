# Online Food Ordering App
## Features
    1. Display all the food items of the restaurant
    2. Display the Location of the Hotel.
    3. Allow User to select the Items in the restaurant.
    4. Display the final Bill to the User and allow the user to buy it. It should display the delivery time.
    5. User Info storing. The User should have a login Page where one can enter the Mobile No and Address of the User. This info should be stored in the localStorage for later usages. If the User information is already available in the localStorage, the login part should not display.

## Users
    Single User Application.

## Things to have
    Links, Images, Data in the form of Arrays, Classes, Implementing localStorage etc. CSS should be implemented.
    
## Install 
    1. Downlaod https://jquery.com/download i.e, mified version of the file (jquerylib.min.js)
    2. Once downloaded link it with FoodOnlneApp.html
    
## Steps To Run The File

    1. Download the Food Ordering App Zip file
    2. Open the Food Ordering App folder in VS Code
    3. Food Ordering App Folder includes 
        i. FoodOnlneApp.html 
        ii. jquerylib.min.js
        iii. food.css
    4. Right click on FoodOnlneApp.html and open it in Default browser i.e, Chrome,edge etc.
    5. Food Application Home page will open which has Navigation bar that contains specific buttons such as 
        i. Login
        ii. To Cart
        iii. About Us
        iv. Drop Down of Hotels i.e, Branch
    6. On click of each button mentioned in step 5 a new page will open and asks the user to enter input to the required field.
    
 ## Login Page 
    1. User is asked to Enter Mobile Number as Address and click on Login
    ## Use Case
        i. MobileNo and Address of user is stored in Local Storage
        ii. If Entered Correct Mobile No and Address and it is already in Local Storage then Login Successfull.
        iii. Else Wrong Credentials error will be displayed
        iv. If Entered Mobile No and Address Are not matched it passes a message saying Not a registered user.
        v. After Corrrectly Logging in It Enters to Home Page of Food App where all Food Items will be displayed.

## Home Page 
    1. This page displayes all varieties of Food item available in this application.
    2. On Clicking Add Button we can add Item to cart
    3. After Clicking Add Button Message Pops up saying item added Successfully

## To Cart 
    1. This page shows total Amount of to be paid in Rs.
    2. On Click on Place The Order button.
    3.  Message will de displayed saying "The Delivery will be ready in 30 Min. U can come to our location by 21:4 today".
    4. "The Delivery will be ready in 30 Min. U can come to our location by 21:4 today"
    5. And it will ask for the user to allow his/her Location so that our application get the order ready by time.
