# C#-xSQL(ASP.NET)
## Requirements
Your web application should have an interface that allows the specified actions to be done for each of the
mentioned user type:
Note: You should always make sure that the data passed from the interface to your database
is valid data.
___
## **System Admin:**
1. Add a new club using its name and location.
2. Delete a club using its name.
3. Add a new stadium using its name, location and capacity.
4. Delete a stadium using its name.
5. Block a fan using its national id number.
___
## Sports Association Manager:
1. Register with a name, username and a password.
2. Add a new match with a host club name, guest club name, start time and end time.
3. delete a match with a host club name, guest club name, start time and end time.
4. View All upcoming matches (in a form of host club name, guest club name ,start time and end
time).
5. View already played matches (in a form of host club name, guest club name, start time and end
time).
6. View pair of club names who never scheduled to play with each other.
___
## Club Representative:
1. Register with a name, username, a password and a name of an already existing club.
2. View all related information of the club he is representing.
3. View all upcoming matches for the club he is representing (in a form of host club name, guest club
name, start time and end time) with the stadium name that hosts the match (if available).
4. View all available stadiums starting at a certain date (in a form of stadium name, location and
capacity).
5. Send a request to a stadium manager requesting to host an upcoming match his club is hosting. 
___
## Stadium Manager:
1. Register with a name, username, a password and a name of an already existing stadium.
2. View all related information of the Stadium he is managing.
3. View all requests he already received (in a form of name of the sending club representative, name
of the host club of the requested match, name of the guest club of the requested match ,start time
of the match, end time of the match and the staus of the request).
4. Accept an already sent unhandled request.
5. Reject an already sent unhandled request.
___
## Fan:
1. Register with a name, username, a password, national id number, phone number,birth date and an
address.
2. View all matches that have available tickets starting at a given time (in a form of host club name,
guest club name, name of the stadium hosting the match and the location of that stadium).
3. Purchase a ticket for a match.
___
![alt text](https://raw.githubusercontent.com/xDido/C-xSQL/master/ERD.png)
