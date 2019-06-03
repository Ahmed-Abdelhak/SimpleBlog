# SimpleBlog
A Simple Blog to publish new Articles by the Admin with a nice image, where visitors can comment

# Features :
1. Only admin can add articles.
2. Admin should assign a category to each article they add.
3. Visitors can list the published articles.
4. Visitors can add comments on the published articles.
5. Visitors can filter articles by category.


# How to setUp :
1- Download the Complete Solution file
2- Clean the Solution ( sometimes the references are not identified ) [ check : https://i.imgur.com/lZDgaYm.png ]
3- Rebuild the Solution 
4- run "Update-Datatbase" through the Package Manager Console  ( like you do with Code First Migrations )
5- if you got an error of "Access Denied" : https://i.imgur.com/q6X8h2h.png , check the following step, otherwise skip step 6
6- open the file "Web.config" and change the path of your SQL Server Databases folder : https://i.imgur.com/QLL4BYh.png
   ( my default path is : C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ 

7- Open the file "AccountController.cs" and scroll down to the "Register" method ( we want to register a new account as Admin )
8- uncomment these few lines : https://i.imgur.com/R8Y9kEi.png
9- Compile your project by pressing CTRL+F5
10- head to : http://localhost:{port}/Account/Register  ( to register a new account)
11- go back to step 8, to comment the lines
12- head to :  http://localhost:{port}/Dashboard ( to add new Categories ) or ( add new Articles ) : https://i.imgur.com/gWylgqe.png
    ( Disclaimer: you will not be able to view the Dashboard unless you are in the role:Admin , and of course "logged in" xD ) 
    
13- open a new tab and copy any article ( tip:  you can fetch some raw articles from BBC website xD )
14- Add the Articles ( if the field "IsPublished" not checked, the Article will NOT be visible in the Home Page, nor the Category page)
15- go back to the Index page : http://localhost:{port}/
16- logOff ( or you can open the Index Page in an incognito window )
17- post a comment as a Visitor : https://i.imgur.com/TnrCe2g.png
18- just watch the window until it scrolls down to your comment : https://i.imgur.com/Q0u7fI0.png
19- Visitors can filter Articles through "Dynamic" Categories sidebar on the left
