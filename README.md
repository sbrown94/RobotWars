# RobotWars

RobotWars is a simulation of robots moving on an arena based on specific inputs.

---

# Running the Program

Make sure there is a "commands.txt" file in the Build directory and that the commands follow the correct format. Run RobotWars.exe in the Build directory to see the output.

---

# Input Format Example

5 5<br />
1 2 N<br />
LMLMLMLMM<br />
3 3 E<br />
MMRMMRMRRM<br />

Line 1 must be the width and height of the arena

Every two lines following must contain robot instructions 
The first line of the set must be formatted as [starting x position, starting y position, cardinal direction facing]
The second line must contain the instructions. These can be M (move in the currently facing direction), L (rotate 90 degrees left) or R (rotate 90 degrees right)

---

# Questions and Answers

Q: What should happen when the robot is given a command that would take it outside of the arena? Should it ignore the command or fall off the stage?
A: The program will throw an error and exit.

Q: Is it safe to assume there were only ever be the robot and nothing else on the stage?
A: Robots can pass through each other, but cannot finish their movement on the same square as a previous robot. This will throw an error.

---

# Assumptions

As per spec:
- The lower left hand corner of the arena is 0,0
- The square directly north from (x, y) is (x, y+1)
- Robots move sequentially and not at the same time

---

# Design Choices

I began by identifying the key elements of the problem. These are the Robot(s), the Moving Controller, the Spinning Controller, the Arena and the Main Controller. I also saw a need to develop a Parser and Validation system to read in data from a txt file.

I first mocked up a quick version of the program, then attempted to follow TDD by testing and implementing each section in turn. I have attempted to adhere as closely as possible to the Command Pattern, allowing the Main Controller to have control of when parsing data, initialising the simulation and returning the results happens. Further I have tried to pay particular attention to SRP - robots need only care about themselves, and the arena will handle checking of positions.

---

# Program flow

1) Main instantiates MainController
2) MainController instantiates FileParser which reads in data from commands.txt and returns it as a List of strings.
3) InitSimulation instantiates the arena from the first line of the command list, and then the required number of robots by reading each set of two lines until EOF.
4) InitSimulation calls RunSimulation which loops through every robot and calls RunCommands on them, passing in the arena.
5) Each robot loops through their member commands and calls SpinningController and MovingController in turn to determine which direction to turn (if any) and whether or not to move forward respectively. If a robot would fall off the stage, the simulation is halted with an error.
6) Once a robot has finished executing their instructions, they check if they are now on top of another robot. If so, the program halts with an error.
7) Each robot returns their final position and heading to the MainController.
8) Once all robots are done, MainController returns the list of outputs to Main.
9) Main displays the output on screen and exits.

---

# Future Extensions

- As all robots handle their own commands, extending the system so that robots run simultaneously could be done by making the call to RunCommands asynchronous. This would be sufficient on it's own if all robots were still allowed to pass through each other. If robots needed to collide with one another, each robot would need to wait for all other robots to finish their move and then check the state of the arena. A check will also be needed at the end to ensure no robot has finished on top of another robot.