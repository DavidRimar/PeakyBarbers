# **PeakyBarbers**

### **System Requirements**
 
 - You need to have Visual Studio installed on your machine.
 - LocalDB instance at `(localDB)\MSSQLLocalDB`. It is installed by default for [Visual Studio](https://visualstudio.microsoft.com/downloads/). 

### **Running the project**

 - Clone the repo to your computer or download the project zip file
 - Open the solution in Visual Studio 
 - Set the start-up project to be the Web project and run the application with Debugging with `F5` or by running `dotnet run` 
 - Note: No need to run `dotnet ef database update` as all migrations will be applied when sttarting the application.
 - Upon starting the application, a local database should be created with enough seed data to try out all functionalities.

### User Profiles

To test the varying functionalities, one needs to sign in with one of the seeded User profiles shown below. Alternatively, you can create a Customer account via local authentication or Google authentication.

Customer:<br />
Username: jamievardy@example.com<br />
Password: Password123!<br />

Non-Admin Barber:<br />
Username: johnshelby@example.com<br />
Password: Password123!<br />

Admin Barber:<br />
Username: thomasshelby@example.com<br />
Password: Password123!<br />

### User Functionality Summary based on Authorisation Roles

*1. Guest (User without logging in)*

| Pages        | CRUD Operations         |
| ------------- |:-------------:|
| Barbers      | View records in a read-only mode and cannot access CRUD operations. |
| Services      | View records in a read-only mode and cannot access CRUD operations. |
| Appointments | View records in a read-only mode and cannot access CRUD operations.  |
| MyProfile | None.     |

*2. Customer*

| Pages        | CRUD Operations         |
| ------------- |:-------------:|
| Barbers      | View records in a read-only mode and cannot access CRUD operations. |
| Services      | View records in a read-only mode and cannot access CRUD operations. |
| Appointments | Can book an appointment (Update). No Create or Delete operations.  |
| MyProfile | Can view and change Profile details under MyProfile section and view historical and upcoming appointments. |

*3. Barber*

| Pages        | CRUD Operations         |
| ------------- |:-------------:|
| Barbers      | View records in a read-only mode and cannot access CRUD operations. |
| Services      | View records in a read-only mode and cannot access CRUD operations. |
| Appointments | Can create and delete an appointment that belongs to his/her profile but not others.  |
| MyProfile | Can view and change Profile details under MyProfile section and view historical and upcoming appointments. |

*4. Admin*

| Pages        | CRUD Operations         |
| ------------- |:-------------:|
| Barbers      | Can View, Edit, Create and Delete any Barbers. |
| Services      | Can View, Edit, Create and Delete any Barbers. |
| Appointments | Can View, Edit, Create and Delete any Appointments.  |
| MyProfile | Can view and change Profile details under MyProfile section and view historical and upcoming appointments. |
