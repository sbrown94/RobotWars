# RobotWars

# Running the Program

Make sure there is a "commands.txt" file in the root directory and that the commands follow the correct format
Run RobotWars.exe to see the output

---

# Input Format Example

5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Line 1 must be the width and height of the arena

Every two lines following must contain robot instructions 
The first line of the set must be formatted as [starting x position, starting y position, cardinal direction facing]
The second line must contain the instructions. These can be M (move in the currently facing direction), L (rotate 90 degrees left) or R (rotate 90 degrees right)

---

# Questions and Answers

Q: What should happen when the robot is given a command that would take it outside of the arena? Should it ignore the command or fall off the stage?

A: The program will throw an error and exit.


Q: Is it safe to assume there were only ever be the robot and nothing else on the stage?

A: Robots can pass through each other, but cannot stop on the same square as a previous robot. This will throw an error.

---

# Program flow

1) Main instantiates FileParser which reads in data from commands.txt and returns it as a List of strings.
2) Main then instantiates MainController and passes the List of commands to InitSimulation.
3) InitSimulation instantiates the arena from the first line of the command list, and then the required number of robots by reading each set of two lines until EOF.
4) InitSimulation calls RunSimulation which loops through every robot and calls RunCommands on them, passing in the arena.
5) Each robot loops through their member commands and calls SpinningController and MovingController in turn to determine which direction to turn (if any) and whether or not to move forward respectively. If a robot would fall off the stage, the simulation is halted with an error.
6) Each robot returns their final position and heading to the MainController.
7) Once all robots are done, MainController returns the list of outputs to Main.
8) Main displays the output on screen and exits.

---

# Future Extensions

As all robots handle their own commands, extending the system so that robots run simultaneously could be done by making the call to RunCommands asynchronous. This would be sufficient on it's own if all robots were still allowed to pass through each other. If robots needed to collide with one another, each robot would need to wait for all other robots to finish their move and then check the state of the arena. A check will also be needed at the end to ensure no robot has finished on top of another robot.