# RobotWars

# Running the Program

Make sure there is a "commands.txt" file in the root directory and that the commands follow the correct format
Run RobotWars.exe to see the output

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

# Questions and Answers

What should happen when the robot is given a command that would take it outside of the arena? Should it ignore the command or fall off the stage?

---

Is it safe to assume there were only ever be the robot and nothing else on the stage?

---

# Future Extensions