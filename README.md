# DAT605_REST_Project

![4cast_graphic](images/4Cast.jpg)

| Team: 4Cast      | Github ID        |
|:-----------------|:----------------:|
| Michael Bradvica | [mjbradvica](https://github.com/mjbradvica) |
| Noe Hernandez    | [leivanoe1011](https://github.com/leivanoe1011) |
| Brent Hoskins    | [brenthoskins84](https://github.com/brenthoskins84) |
| Dan Sullivan     | [uid100](https://github.com/uid100) |

### Updates ###
* [O5 Oct](#05Oct) TodoMVC file structure
* [06 Oct](#06Oct) Google Cloud
* [12 Oct](#12Oct) Microsoft Azure Configuration
* [13 Oct](#13Oct) Documentation Updates
* [15 Oct](#15Oct) Chat notes
* [16 Oct](#16Oct) Presentation upload 'Pull Request
* [17 Oct](#17Oct) SQL Connection and App Deployment
* [18 Oct](#18Oct) Code Diagram and deploy Web API to Azure

---
<a name="18Oct">*18 Oct, 2016*</a>
* tried porting build to Azure - failed
* traced and tried modifying build files - 711 files generated in repo!
* reverted changes and tried pushing from Win VS on VM -- crashed hard
* built template todomvc app to test connectivity. [works great](http://mygitwebapptest.azurewebsites.net)
* built alternative .NET API and started porting source files to it. [slow but working](http://4castdemo.azurewebsites.net)
* researched using Visual Studio in VM (PaaS) in Azure. Requires MSDN subscription. (expensive)
* rebuilding Windows VM with WAY more disk and RAM.
* installed MS Visual Studio Community Edition
* downloaded and opened project from Github, Rebuild All

---
<a name="17Oct">*17 Oct, 2016*</a>
* Create (Azure) SQL Tables


| ODBC Data Source | parameters                 |
|------------------|----------------------------|
| Server Name:     | 4cast.database.windows.net |
| Database:        | Todo_SQL                   |
| Authentication   |                            |
| Method:          | Username/Password          |
| User Name:       | bobjones                   |
| Password:        | ********                   |
*IP address needs to be added to firewall rules*

The Azure SQL Database can be managed using SQL Server Management Studio (SSMS). This is only available on WINDOWS platforms, and it is a large download.  Alternatively, use the Query capability with MS Excel over an ODBC connection.

```
IF OBJECT_ID('tblTodo', 'U') IS NOT NULL
   DROP TABLE  tblTodo;

CREATE TABLE tblTodo(
   ID int NOT NULL,
   Descr  varchar(128) NOT NULL,
   IsDone  bit NOT NULL DEFAULT (0),
   ToDoListId   int,
   PRIMARY KEY (Id)
);

IF OBJECT_ID('tblTodoList', 'U') IS NOT NULL
   DROP TABLE  tblTodoList;

CREATE TABLE tblTodoList(
   Username  varchar(32),
   ListId   int
);

IF OBJECT_ID('tblUser', 'U') IS NOT NULL
   DROP TABLE  tblUser;

CREATE TABLE tblUser(
   Username  varchar(32),
   Password  varchar(32)
);
```

![tables](images/ShowTables.jpg)

* App deployment - create new app and point to GITHUB.
deployed to http://4cast.azurewebsites.net

---
<a name="16Oct">*16 Oct, 2016*</a>
* uploaded draft presentation

---
<a name="15Oct">*15 Oct, 2016*</a>
* status: port issues running locally
* SQL database setup on MS Windows Azure - working out connection issues. Initial firewall settings are configured.
* code walk-through. Adding source comments. More to add.

---
<a name="13Oct">*13 Oct, 2016*</a>
* Reordered Notes from most recent.
* Inserted draft presentation
* Need to review / update code comments
* Finish migrating code from XML to JSON
* Update architecture diagrams

 [back to TOC](#updates)

---
<a name="12Oct">*12 Oct, 2016*</a>
* Created simple group icon for use in presentation(s) (images/4Cast.jpg)
* Configure (Free) account in Microsoft Azure Cloud Services
* Login and Select Portal and Add SQL database

| Parameter          | Setting                |
|--------------------|:----------------------:|
| Database name      | Todo_SQL               |
| Subscription       | Free Trial             |
| Resource group     | 4cast                  |
| Select source      | Blank database         |
| Server: >>         |                        |
| Pricing Tier       | S1 Standard            |
*Configure New Server*

| Parameter          | Setting                      |
|--------------------|------------------------------|
| Server name        | 4cast(.database.windows.net) |
| Server admin login | bobjones                     |
| Password           | (lab 1 password +'!' =8 char)|
| Location           | West US                      |

*Check "All services to access..." and press "Select"*

* Press Create

 [back to TOC](#updates)

---

<a name="06Oct">*06 Oct 2016*</a>
* Setup Google Cloud Database Instance:

![SQL Database Instance](images/SQL\ Cloud\ Database.jpg?raw=true "Google DB")
---
* To access the database, Go to the [SQL instances page](https://console.cloud.google.com/projectselector/sql/instances?_ga=1.226861209.544085363.1475456239), selet project DAT605-todomvc.
* Set root password to match lab1 default password
* Connect using MySQL client in the Cloud Shell:  [from here](https://console.cloud.google.com/home/dashboard?project=causal-calculus-145618&_ga=1.230524056.544085363.1475456239), find this item:

![Launch Google Cloud Shell](images/Launch\ Cloud\ Shell.jpg?raw=true "Google Cloud Shell")

* [more google db help here](https://cloud.google.com/sql/docs/quickstart)
```
...:~$ gcloud beta sql connect dat605-todomvc --user-output-enabled=root

Enter password: #######
```
* check authorized IP networks.
Temporarily set to 0.0.0.0/0 to allow access.
```
mysql> CREATE DATABASE todomvc;
Query OK, 1 row affected (3.20 sec)
mysql> use todomvc;
Database changed
mysql> CREATE TABLE mytodos(task VARCHAR(255), complete boolean);
Query OK, 0 rows affected (0.02 sec)
mysql> INSERT INTO mytodos (task, complete) values('mow the lawn', FALSE);
Query OK, 1 row affected (0.00 sec)
mysql> show tables
    -> ;
+-------------------+
| Tables_in_todomvc |
+-------------------+
| mytodos           |
+-------------------+
1 row in set (0.00 sec)
mysql> SELECT * from mytodos;
+--------------+----------+
| task         | complete |
+--------------+----------+
| mow the lawn |        0 |
+--------------+----------+
1 row in set (0.00 sec)
mysql> quit
Bye
```
 [back to TOC](#updates)
 
---

<a name="05Oct">*05 Oct 2016*</a>
* The [Application Spec](https://github.com/tastejs/todomvc/blob/master/app-spec.md) for the [todoMVC](todomvc.com) application includes a required directory structure:
```
index.html
package.json
node_modules/
css
└── app.css
js/
├── app.js
├── controllers/
└── models/
readme.md
```
* Common utilities used in every todo app are [here](https://github.com/tastejs/todomvc-common)
```
$ npm install --save todomvc-common
```
* css files are [here](https://github.com/tastejs/todomvc-app-css)
```
$ npm install --save todomvc-app-css
```
* for data persistence, use RESTful API to send JSON for database queries
---
 [back to TOC](#updates)
