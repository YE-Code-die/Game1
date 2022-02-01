***The First Game of Yang Qianlai***

This game is build on the Unity and C#. The some of module I use the KADAPT library to support. This game is about people go through a maze try to collect enough score by collect the score pickup.
 And there are time limit (120 second). If the player don’t have enough scores, we will lose this game. Else we will win. Also we still have another way to end the game. In the middle of the maze, we have another pickup which worse 15 scores. The player is control the character by first personal view. We use wasd to control the character move and use the mouse to move the camera. And player could use “space” to jump.


If we pick up that one, we will end the game immediately. So sometime people find the path to the center of the maze, they might need find more score to win this game. Also in the game we have two secret scenes. In each secret scenes, we have same environment set: a sample set with some pick up. The only different between this two scenes is one scene with good pickup(which people could earn score from those pickup), and another one with the bad pickup(people will lose score if they collect the pickup in that scenes). There are 4 ports in the map, and two of them could send us to the good scene and another two will send to the devil scene
 
That’s interest because people need make a decision to touch the port or not. That’s make this game have more elements people could faced with. Also people who get in to the port, in the secret scene, there exist port to send them back to the main game but the port is look like as same as the other pickup, so even people find out he get into the devil scene, he could not just use the port to leave. He need try each pickup until he get the port. If you are unlucky, even you go to the good scene, if the first pickup is the port, you will get nothing and the port will send you to the start point of the maze. You might lose the score and time, but you also could win this game by this try.



Also we have a complete set of this game, we have menu, main game, win scene and lose scene. And we have back ground music. That’s a important element for me when I play a game. A good background music will get me better game experience. So I add different music in the different scenes which will make player could perfectly feat in this game.
