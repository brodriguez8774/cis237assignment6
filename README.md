# Assignment 6 - Web Application to Manage Beverages

## Author

Brandon Rodriguez

## Description

Basic .net web application to display a beverage database.

Has four main pages: home, about, contact, and beverages.

The first three are mostly static with minor changes to prove that I can manipulate various elements.

Beverages actually displays the database, and requires user authentication to see. Attempting to go to the page without authentication will lead to a login screen.

CSS modified to a kinda odd blue theme to prove that I can change that as well.

Attempted one unit test. I don't /think/ I did any other extra credit?

## Program Requirements

You are to create a web application using ASP.NET MVC to manage our beverage database.
The application should have the following pages and navigation:

A Home page.
A Contact page.
A About page.
A Beverages page that can only be seen when the user is logged in.
Other CRUD related pages to augment the Beverages page.
All of the built in user account pages.

Every view must use a Master Layout file for the things that do not change.

The Home page should have a nice welcome page that helps a new user figure out how to use the site without being as overly detailed as the About page. This will more or less be a static page.

The Contact Page should provide a way for users of the site to contact you if they have questions or concerns about the site. This will also be more or less be a static page.

The About Page should include some information about the purpose of the application and how to use the application for people who have never been to the site. This will also be more or less a static page.

The Beverages page is where the main focus of the site should be.

Once a user is registered and logged in, they will be able to see navigation links to reach this page. If they try to navigate directly to this page without being logged in, it should redirect them to the home page.

The Beverages page should list all of the beverages stored in the same database as what was used for assignment 5. The information to connect is listed below in case you forgot. In addition to the page displaying the list of items, there should be links for each item that allows the user to update or delete a specific item from the list. This will require the creation of additional pages to implement the functionality.

There should also be a way to create a new item to be added to the beverages database. This will require an additional page to implement the functionality.

At the top of the Beverages list page there should be a filter that can be used to filter the contents of the beverages list. Filter fields should include Name, Pack, Min Price, Max Price, and Active. There should be a button in the filter section to submit the filter. Submitting the filter will cause the application to store the filter information in the session, and then use that information to display a filtered version of the data in the database.

It is okay to use scaffolding to create Views, however you may need to then go in and tweak Views to add more functionality to them. (Filter)

The Login information for users will be stored in a localdb, and the Beverage information will be stored in the same remote database we used in the previous assignment. Just so it is clear, the application will be using 2 databases.

The EntityFramework Models that are created for the Beverages, and the ones that .NET provides for user authentication will make up the Models portion of MVC.

You must create your own Controller for handling the work of maintaining the Beverages and dealing with any pages related to maintaining the beverages. This will be the Controller portion of MVC.

You must create any Views that you need to for handling the work of maintain the Beverages. This includes the list of beverages and views to add, update, and delete. This will be the View portion of MVC.

Here is a reminder of how to connect to your Beverage Database.

To connect to the database you will use the following information.

Sever address / name: barnesbrothers.homeserver.com,443 //Remember that the comma denotes that the port number follows.

Sql Server Authentication (Not Windows Auth):

Username: FirstInial + LastName (All lowercase) (ie. John Smith would be jsmith)

Password: password (If you would like me to change your password to something else for you, I can)

DatabaseName: Beverage + FirstInital + LastName

********************************************************************************************
*NOTE: There is a database for each person. Use the one that is for you. Don't be a troll. If I hear about you trolling on someone elses database, you will get a zero for the assignment!
********************************************************************************************

Solution Requirements:

* 4 Main pages: Home, Contact, About, and Beverages
* Beverages must be augmented by any additional needed pages to perform CRUD
* Master Layout page
* Pages for user authentication and account setup
* EntityFramework Model and Collection
* Read functionality
* Insert functionality
* Update functionality
* Delete functionality
* Filter on the list of beverages that will filter the results on the page
* Denied access to beverages page for non-logged in users.

### Extra Credit
You can get up to 20 assignment points of extra credit by doing the following:
* Validate all information that is submitted to ensure it is valid for both Update and Create of Beverages.
* Use JavaScript / jQuery to handle getting to the edit page of a item in the list by setting a click listener on the table row for the item. (This would replace the edit link from scaffolding)
* Use JavaScript / jQuery to pop up a confirmation delete message when deleting a beverage.
* Ability to click on a table header and sort the list of items by that column.
* Write at least 2 unit tests to verify your code.

### Notes

There are a few Youtube videos I found that should help you out with MVC.

This one is really good and I think it is from lynda.com:
[Lynda](https://www.youtube.com/watch?v=5KxF476mRFE)

This one is okay, and it is from Microsoft:
[Microsoft](https://www.youtube.com/watch?v=XRXYa_NyLSQ)


## Outside Resources Used

## Known Problems, Issues, And/Or Errors in the Program

Note: Beverage active filter requires "true" or "false." Everything else is taken as invalid input and returns all actives.

I don't think there are any issues, probably?

I attempted to do a single unit test. Verified a viewbag message and then /attempted/ to verify that the contact link was what I expected, but couldn't figure out how.


