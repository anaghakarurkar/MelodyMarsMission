
 
 # Mars Mission <img src="https://user-images.githubusercontent.com/102415713/192167507-78d8a380-3161-4121-83ec-e71d7d6493d0.png" width=30 height=30>

![GitHub last commit](https://img.shields.io/github/last-commit/anaghakarurkar/MelodyMarsMission?style=plastic) ![GitHub repo size](https://img.shields.io/github/repo-size/anaghakarurkar/MelodyMarsMission) ![GitHub watchers](https://img.shields.io/github/watchers/anaghakarurkar/MelodyMarsMission)


This project is a class library created using Visual Studio and C#.  Melody Mars Mission is designed to move rovers around the surface of Mars! 
Rovers navigate the Plateau so they can use their special cameras and robot arms to collect samples back to Planet Earth.




### Project details:
 
This project has three interfaces. Using these interfaces, classes can be created to add more functionality. 
 
  -  IObstacle
  -  IPlateau
  -  IRover
  
  Following is the list of classes:
  -  MissionControl : This class communicates with rover. This is main mission controller.
  -  Plateau : Plateau on Mars can be up to 5,5
  -  MarsRover: This project has two mars rovers: Spirit and Opportunity. This class handles moving of rover.
  -  Position: Co-ordinates x, y used by classes.
  -  Focus: This is enum. It has N, S, E, W (North, South, East, West) values.
  -  ChangeFocus - This class finds correct direction when rover is asked to turn left or right.
  -  Obstacle - This class creates new type of obstacle. This project have one obstacle created - Alien
  
  This is a class library created for mars rover mission. Functionality can be extended because it has public interfaces. 
  
### Input to program: 
  
  This project accepts three inputs:
  
  1. Plateau grid size up to 5,5
  2. Co-ordinates and direction to place rover on plateau. 
     For example, "1 2 N" where 1, 2 are co-ordinates and N is North facing rover.
  3. Message to rover, For example, "LMLMRMM". 
  	L, R are commands for rover to turn left or right. 
 	M is the command to move one point on plateau in given direction.
  

### Technologies used <br/>
![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465](https://user-images.githubusercontent.com/102415713/192124277-b19a85b4-9fbb-42a7-8f54-006e4336e23c.svg)
![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f56697375616c5f53747564696f2d3543324439313f7374796c653d666f722d7468652d6261646765266c6f676f3d76697375616c25323073747564696f266c6f676f436f6c6f723d7768697465](https://user-images.githubusercontent.com/102415713/192124308-397221f7-953e-4ca2-b432-0e25e81e764d.svg)
![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f2e4e45542d3531324244343f7374796c653d666f722d7468652d6261646765266c6f676f3d646f746e6574266c6f676f436f6c6f723d7768697465](https://user-images.githubusercontent.com/102415713/192124366-c54ae8ee-6fe2-4ace-8e5c-df8d7be8ff70.svg)
![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4e754765742d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465](https://user-images.githubusercontent.com/102415713/192124538-45ec3989-cb3f-44bf-9cb9-fb1604dcbfe7.svg)
![68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4749542d4534344333303f7374796c653d666f722d7468652d6261646765266c6f676f3d676974266c6f676f436f6c6f723d7768697465](https://user-images.githubusercontent.com/102415713/192124572-c991c405-9e8e-4706-b238-fc811b158783.svg)

