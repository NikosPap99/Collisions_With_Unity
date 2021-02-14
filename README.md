# Collisions_With_Unity
 A collision game featuring a main cube and cylinders, spheres. Developed with Unity.

## Description

This game implements first person movement which enables the player to move around, or even inside, the main cube. Inside the main cube one can find a big bright red sphere. The game enables you to move the sphere, using the arrows, inside the cube limits. The main cube color is generated randomly at the start of the game and there is enough transparency to see the objects inside of it with ease. The user can also generate random sized and colored objects inside the cube, which will spawn in its (0, 0, 0) edge at first, moving at a randomly created starting velocity to a random direction. The generated objects will bounce off the cube walls and also off each other and the main sphere. Rotational movement has been implemented upon collisions. Lastly, the user can assign a texture from an image to the main sphere.

## Specifications

1) Developed and built with Unity version 2020.1.17f1.
2) Build target platform: Windows.

## How to use

You can run the game by downloading all the files and using its executable file "Collisions.exe" (it's not standalone). The scripts assigned to the game objects are located in Assets > Scripts.

### Player capsule control (with built-in first person camera)

W: Forward movement in the direction that the camera is pointed to (while remaining in the same height).
S: Backward movement in relation to the direction that the camera is pointed to (while remaining in the same height).
A: Left movement in relation to the direction that the camera is pointed to (while remaining in the same height).
D: Right movement in relation to the direction that the camera is pointed to (while remaining in the same height).
Ε: Move the capsule upwards.
X: Move the capsule downwards.

Up/down mouse movement: Makes the camera look up/down.
Left/right mouse movement: Makes the camera look left/right.

Note that the player capsule has a "rigidbody", which means that the generated objects inside the cube will bounce off the player (but the main sphere won't).

### Main sphere control

Up/down arrow keys: Move the sphere upwards/downwards (along the y-axis).
Left/right arrow keys: Move the sphere to the left/right (along the x-axis).
-/+ (not the numpad ones): Move the sphere forwards/backwards (along the z-axis).
You can speed up the spawned objects by holding down “>” (shift and .) and slow them down by holding down “<” (shift and ,).
T: Enable/disable the sphere texture. 

Note: The texture is loaded from an image file in the game directory called "texture-sphere.jpg". You can use whatever .jpg image you wish in its place in order to change the texture, just make sure the replacement picture has the same name.

## Game screenshots

![Alt text](/Screenshots/Screenshot1.png?raw=true)
![Alt text](/Screenshots/Screenshot2.png?raw=true)
![Alt text](/Screenshots/Screenshot3.png?raw=true)
![Alt text](/Screenshots/Screenshot4.png?raw=true)
![Alt text](/Screenshots/Screenshot5.png?raw=true)