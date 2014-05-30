# CelemarRoboCode #

This is my RoboCode project  
http://robocode.sourceforge.net/

## Development ##
**NOTE:**
A Reference to a local version of robocode.dll has been added for continuous integration,
For development this should be changed to the installation directory of robocode, explained in 'Creating a .net robot' below

### ToDo: ###
* Complete WallE robot
	* Test best result between moving in parallel with target synchronously or asynchronously
	* Test how to lock onto target while rotating and target moving away  
	Possibly use oscillate scan instead of lock

## Robots ##

### WallE: ###
**NOTE:** still in developement  
This is my first Robot, the idea with **WallE** is at the start of the round he will immediately scan the area for a target. When a target is found **WallE** moves in parallel with the opponent and then start firing. This hopefully will allow the maximum number of hits per shot.

### Targetbot: ###
This is a development robot designed to help with creating new robots. **TargetBot** will simply move forward untill it hits a wall, then rotate 90 degrees and move forward again.
The idea with **TargetBot** is to have a moving target.

## Getting Started ##

### Download and Install: ###
1. The latest version of **Java**  
  http://www.java.com/en/download/index.jsp

2. The latest version of **robocode setup** and **robocode .net setup**  
  Install both into the *same* default C: drive directory  
  http://sourceforge.net/projects/robocode/files/

### Creating a .net robot: ###
Full instructions on this wiki link  
http://robowiki.net/wiki/Robocode/.NET/Create_a_.NET_robot_with_Visual_Studio

1. Create a Class Library project

2. Add a reference to the robocode.dll file  
  (this can be found in the *libs* directory of the installation location)

3. Add the following using clause  
  <pre><code>using Robocode;</code></pre>

4. Add a class which inherits from *Robot*  
  <pre><code>class MyRobot : Robot {  
  }</code></pre>

5. Change the Namespace to that of your *handle*  
  (This follows the Robocode naming standards)

6. Add an override to the run method  
  <pre><code>public override void Run() {
      Code goes here...
  }</code></pre>

### Debugging a .net robot: ###
Full instructions on this wiki link  
http://robowiki.net/wiki/Robocode/.NET/Debug_a_.NET_robot_in_Visual_Studio

1. Copy the *robocode.bat* file and rename it to *robocode.bat*
  (this can be found in the *libs* directory of the installation location)

2. Edit the file and add the following line after the word *java*  
  <pre><code>-Ddebug=true</code></pre>

3. In Visual Studio select *Debug > Attach to Process* from the menu item  
  And from the window that appears, select the *java.exe* process