# Web Application Development 
### Assignment - 2 (Web Api)

- This assignment requires to solve the problem using a WebAPI method.

- https://cemc.math.uwaterloo.ca/contests/computing/2018/stage%201/juniorEF.pdf 

### Problem J1: Telemarketer or not?
---
#### Problem Description: 

Here at the Concerned Citizens of Commerce (CCC), we have noted that telemarketers like to use
seven-digit phone numbers where the last four digits have three properties. Looking just at the last
four digits, these properties are:

-   the first of these four digits is an 8 or 9
- the last digit is an 8 or 9
- the second and third digits are the same.

For example, if the last four digits of the telephone number are 8229, 8338, or 9008, these are
telemarketer numbers.
Write a program to decide if a telephone number is a telemarketer number or not, based on the
last four digits. If the number is not a telemarketer number, we should answer the phone, and
otherwise, we should ignore it.

### Input Specification
- Numbers should be between 0 to 9.
- GET : http://localhost/api/J1/Telemarker/{digit1}/{digit2}/{digit3}/{digit4}
- {digit1} : 1st digit in the 4 digits.
- {digit2} : 2nd digit in the 4 digits
- {digit3} : 3rd  digit in the 4 digits
- {digit4} : 4th digit in the 4 digits

### Output Specification 

- GET ../api/J1/TeleMarker/9/6/6/8 --> Ignore
- GET ../api/J1/TeleMarker/5/6/6/8 --> Answer
- GET ../api/J1/TeleMarker/9/9/9/9 --> Ignore



---
### Problem J2 - Occupy parking?
---
### Problem Description:

You supervise a small parking lot which has N parking spaces.
Yesterday, you recorded which parking spaces were occupied by cars and which were empty.
Today, you recorded the same information.
How many of the parking spaces were occupied both yesterday and today?

### Input Specification 
- The string should only have C and E
- GET : http://localhost/api/J2/OccupyParking/{numOfParking}/{yestParking}/{todayParking}
- numOfParking(int): Should be between 1 to 100.
- yestParking(string) : Parking Information of Yesterday.
- todayParking(string) : Parking Information of Today.

### Ouptut Specification

- GET api/J2/OccupyParking/4/CCEC/CECE ---> Number of occupied places today and tomorrow are 1.
- GET api/J2/OccupyParking/5/CCEEC/ECCEE ---> Number of occupied places today and tomorrow are 1.
- GET api/J2/OccupyParking/9/CCCEEECCC/CECECECEC ---> Number of occupied places today and tomorrow are 4.



---
### Problem J3 - Are we there yet?
---
###Problem Description:
You decide to go for a very long drive on a very straight road. Along this road are five cities. As
you travel, you record the distance between each pair of consecutive cities.
You would like to calculate a distance table that indicates the distance between any two of the cities
you have encountered.

### Input Specification :
- The input should be a postive integer and less than 1000
- GET : http://localhost/api/J3/ReachedDestination/{city1}/{city2}/{city3}/{city4}
- city1 : Distance of city1
- city2 : Distance of city2 from city1
- city3 : Distance of city3 from city2
- city4 : Distance of city4 from city3.

### Output Specfication :
- Returns multidimension array, where each block represents the distance from that city to all the other or null if input condition are not satisfied.
- GET api/J3/ReachedDestination/3/10/15/5 ---> [[0,3,13,25,30],[3,0,10,22,27],[13,10,0,12,17],[25,22,12,0,5],[30,27,17,5,0]]
- GET api/J3/ReachedDestination/13/10/117/5 --->[[0,13,23,140,145],[13,0,10,127,132],[23,10,0,117,122],[140,127,117,0,5],[145,132,122,5,0]]
- GET api/J3/ReachedDestination/1/-2/7/90 ---> Null(Blank)
- GET api/J3/ReachedDestination/1/2/7/1000 ---> Null(Blank)
