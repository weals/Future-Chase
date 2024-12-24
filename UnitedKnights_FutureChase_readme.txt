Game Name: Future Chase
Team Name: United Knights
Start Scene: Menu_Screen

How To Play:
Welcome to Future Chase! In this game, you will race against an AI-controlled opponent in a futuristic landscape.
Your main objective is to beat the opponent to win the game.

When the menu screen loads up, select "Play" to start playing the game. You are controlling the car on the left.
When the timer counts down to 0, you can begin controlling your car by using the arrow keys of your keyboard (
or the WASD keys). The controls are pretty straight forward: hit up to accelerate, down to brake, left to turn left,
and right to turn right. As you move along the track, be sure to collect powerups (yellow cubes) for an additional
speed boost! Collect coins as well, which will be helpful in future parts of the game. If you fall off the track,
do not worry; you will be respawned close to where you fell off and can continue the race. If the AI car beats
you to the finish line before you, unfortunately, you lose. However, beat the AI car and you win!

Parts of the level to observe technology requirements:
1. 3D Game Feel:
  There is a clearly defined objective, which is winning the race. We communicate to the player whether or not they
  achieve this goal via UI elements. In addition, there is a start menu to support starting the game, and the player is also
  able to reset and replay the game.
2. Precursors to Fun Gameplay:
  The player has many choices to make such as what race line they want to follow (can beat AI by optimally completing the race).
  In addition, they have the options to pick up powerups and coins. For each of these choices, the player is rewarded.
3. 3D Vehicel with Real-Time Control:
  The player controls a racecar vehicle that animates and moves based on the player's input. This control is continuous, quick, and analog-style.
  In addition, the camera is smooth and follows the main player as they traverse the racetrack.
4. 3D World with Physics and Spatial Simulation:
  We created a new world, primarily consisting of a racetrack and some background buildings. There is real graphics aligned with physics representation
  (how the cars move), and there are appropriate boundaries such as the track boundaries.
5. AI:
  The player competes against an AI-controlled racecar, which uses a waypoint system to complete the race. This opponent is not too easy to beat nor to
  difficult, providing the player with a satisfactory level of engagement.
6. Polish:
  We implemented a start menu GUI as well as in in-game pause menu. We included some polish aspects such as smooth animations (e.g. coin animations), sounds, lighting, etc.

Known problem areas:
One known problem area is the car can go through the fence even though the fence seems low enough to block the car in case it goes off the track. 
Other than this, we still need to work on improvements. For instance, we want to flesh out our world (add more backgrounds), add a checkpoint
system which would help the AI rubber band as well as help in respawning and orienting the player, add more powerups.

Contributions:
- Pujith Veeravelli:
  - Created AI car, Waypoints, Braking Zones
  - Wrote AICarController.cs and edited PlayerController.cs (respawning)
- Arnav Adulla:
  - Sound System edited PlayerController.cs and FinishLine.cs to include sounds
  - UI and Powerups
- Xisheng Zhang:
  - Wrote most parts in PlayerController.cs except Respawn() method
  - Wrote everything in RotateCube.cs to rotate the cubes.
  - Wrote everything in SpeedPowerUp.cs to speed up the car.
  - Wrote everything in GameStarterCountdown.cs to wait 3sec after game start.
  - Build environment such as track and palyercar, design the racing track, and power up object
- Qihui Wang:
  - Wrote most parts except audio system in FinishLine.cs to detect whether user has won or lost, and stop the game
  - Wrote CoinCollector.cs to rotate the coins
  - Wrote everything in CameraController.cs to control the camera 
  - Build fence on the side of the track, design the coin object and camera object.
