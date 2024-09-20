# PinewoodTechTask
Start Up:
* This application uses a local DB, to set this up go to Server Explorer and connect to a new instance then provide the MDF file located at PinewoodTechTask > PinewoodTechTaskAPI > Database > PinewoodTechTaskDB.MDF
* Once the DB has been connected to right click Pinewood > Properties and copy the connection string.
* This should be pasted in the appsetting.development.json file under AppConfig > ConnectionString in the PinewoodTechTaskAPI Project.
* Next go to the PinewoodTechTaskUI Project and Confirm the port is correct.
* Please ensure both projects are set to startup in Solution Property Pages > Startup Project >  Multiple Startup Projects
* Next run the AddData.SQL file if no data is present at start
