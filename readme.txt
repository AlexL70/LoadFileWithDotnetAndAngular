Test task.
Done by Alex Levinson for Flying Donkey IT Pty Ltd

Tast Definition:
Using Web Api and Angular create a simple page to upload/view files. Page is splitted into two parts: upload area and view area.
Upload area - single for all files. File size and file types that can be uploaded to server must be configurable. Validation for invalid data should present.
View area - consists of one or more table (one table per permitted file type). Must reflect: file name, file size, upload date, user that uploded file.
Page should be as generic/reusable as possible.
Add at least one unit test to back-end and front-end

Questions:
>> user that uploaded file
Does it mean that the application should also support the simplest security (user registration/login)?
Are there any restrictions as for .Net version to be used? Should it necessarily be .Net Core? Could I use "standard" MVC solution for security?
Do I understand right that application does not have to expose file content, but only file metadata listed above?

Answers:
1) not necessarily, username can be omitted
2) no restrictions
3) its up to candidate's decision whether to expose content or not

Implementation notes:
1. I did not do any error interceptions in SPA. All errors go straight to the browser console. Validation is done on the server side but it is invisible on the client unless you open browser console.
2. Security is emulated through predefined user list (filled in during data migration, no way to change it except straight access to DB). You chose a user from the drop-down list and then load a file.
3. No filtering, sorting, or pagiation in the files table. Back-end returns the whole table sorted by Id; front-end shows it all. Will be turtle slow on big amounts of data.
4. The only couple of very simple unit-tests are implemented.

Prerequisites. To build, run and test this you need:
    1. One of the latest npm version (I have 6.4.1 and I haven't tested it with an earlier one).
    2. .Net Core 2.2 (I have 2.2.203 and I haven't tested it with any earlier ones)

To run and test application:
    1. Go to LoadFiles\LoadFiles\ClientApp subfolder and run "npm install" command.
    2. Go one level up, make sure that connection string in "appsettings.json" is fine for your environment and run "dotnet ef database update" command.
    3. When DB is created successfully, then and run "dotnet run" command
    4. When app is started (it starts back-end first and then run front-end), run browser and open "http://localhost:5000" URL. If you get a security warning, proceed with "unsafe" option.

To run unit tests:
    1. Back-end: run "dotnet test" command in the "LoadFiles\TestLoadFilesBackend" directory.
    2. Front-end: run "ng test" command in "LoadFiles\ClientApp" directory.

May 24, 2019