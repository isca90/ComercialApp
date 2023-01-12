# Exercise - Securibox - Inês Cabaço


##### We want to model two types of customer in a commercial application: singular persons and companies:
>  I used a **ASP .NET MVC5** to create the application.

##### Singular persons and companies have the following aspect in common: name and email
> All the aspects in commom were written in an abstract class (**People**) from which both **Singular** and **Companies** are inherited.

##### The email should be accessible for writing and reading
>A standard property with **get** and **set** accessor.

##### The name should only be readable
>I assumed this property should be read only AFTER it's created, so I used **init** accessor instead of **set** and enforced this rule in the program code by making this property not acessible for writting in any view, setting it as **hidden** in the edit forms.

##### The singular person has a tax number (called NIF) The company has a tax number (called NIPC)
>Because it's explicitly referred with different names, I set tax number as a property of **Company** and **Singular** classes instead of **People**.  

##### The NIF and NIPC should not be accessible for writing or reading after the creation of the object.
>To guarantee the immutability of this property I applied the same logic as I did in **name** field of **People** class.
I set the accessor as **init** instead of **set** and enforced this rule in the program by making this property not acessible for writting in any view, setting it as **hidden** in the edit forms and not showing it in any view.

##### The NIF and NIPC should be accessible through the method GetIdentificationNumber for both entities (singular persons and companies).
```sh
public string GetIdentificationNumber()
{
    return NIF;
}
```
```sh
public string GetIdentificationNumber()
{
    return NIPC;
}
```
##### In the future, it should not be possible to extend classes that represent both customers.
>To make sure these classes can't be extended they were coded with the **sealed** modifier 
```sh
public sealed class Company : People
{
 //code     
}
```

##### Use an object-oriented programming language of your choice to solve the problem above.
> I used **C#** because **.NET Core** is fantastic and gives me all the tools I need, this is the language I learned OOP  and data access with therefore it's the one I'm most confortable with.
The alternatives would be **Python** (but I usually only work with it for simpler shorter programs that rely on basic scripts only) or **Javascipt** (but I never got to teach myself any JS framework to build a proper web app as I only worked with **JS** as a complement to basic **HTML** pages).

##### Bonus question to go further, if you feel like it :For each Singular person, there is a list of purchases (Identification of the purchased product, unitary price without tax, quantity, tax rate and the reference of the company it has been bought from). For each company, there is a list of their sellings (Identification of the product sold, unitary price without tax, quantity, tax rate and the reference to which Singular person it has been sold to). 
> ![alt text](https://github.com/isca90/ComercialApp/blob/main/Diagram.png?raw=true)
The program db **Seed** will make sure you have enough data to test this.


##### We wish to perform a check of consistency of the data.Could you propose a way to solve this problem? It does not need to be extensive, but it needs to show how you solve this problem in a logical way.
>***Data consistency (Request  x  Response)***
Because i've never worked in a project with a dimention big enough to have these kinds of challenges, I've never really had the need to create a system that dealt with data consistency BUT I know the best pratices about data storage tell us we should always replicate data to avoid single point of failure, in different servers preferably in different physical locations  to reduce the chance of losing all servers at the same time.
We can then pick between ensuring ***strong consistency*** by putting requests on hold until the server can return the updated data, OR if we don't want to sacrifice the performance, we can settle for ***eventual consistency*** and not put the requests on hold but send the data as is.
To achieve this we can create a timestamp property in our models and everytime a record is updated so is the timestamp. In case some request for that data is made in the meanwhile the user requesting it will be alerted that the information has changed before going on with whatever action.

>***Data Consistency (Inside the DB server)***
If we're using the standart rules for DB code first building in Entity Framework we won't be creating any consistency problems in the database.
But if we're using SQL Server, we can make sure the data in our db is consistent by running the command 
```sh
DBCC CHECKDB (<nameofdb>)
```


## To test the application

- Clone the repository to Visual Studio.
- Edit the connection string in ***appsettings.json***.
```sh
  "ConnectionStrings": {
    "CAppDb_ConnectionStrings": "Server=<yourSQLServerName>;Database=<aNameForTheDB>;Trusted_Connection=True"
  },
  ```
- Run the program in localhost, if you want to set a different port for debugging you can set it in ***ComercialApp>Properties>Debug***.
- an user with the username ***admin*** and password ***admin*** has been added and is allowed to do all CRUD operations without restritions.
- logged in as ***admin*** you can create a new ***Company*** wich will be able to then create products.
- log in as ***Singular*** and test away.

## Known issues
-When your creating a product if any field has an error you will have to upload the product image again
-In price field you can't write  ,

## Notes
The program is very simple as it was made to make sure the models were designed correctly and could use more work, namely:
- needs refactoring to eliminate repetitions and make the code cleaner.
- one or more interfaces should be implemented to serve as a layer between the models and the controllers and offer all methods necessary.
- the models and the DAL should be added to the solution as a library so it's easier to adapt to a multi layer scalable solution.
- ***ASP .NET CORE Identity*** should have been used to enforce authentication and authorization as it surely is more secure then the code I wrote.
- the look and feel definitely needs work.
- the model could have more tables to add ***Categories*** to ***Products*** and a way to deal with ***Stock*** should be implemented.
