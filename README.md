# DAT605_REST_Project

### Updates
*05 Oct 2016*
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
*06 Oct 2016*
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
