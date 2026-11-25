# VR Project Reflection

Locomotion

In this project, I used my own movement-based system to match the theme of the project, which was a simulation. I had to use Climb as my main form of movement in 0 gravity. How I did it was by making the Project have no gravity in the project physics.

<img width="1050" height="214" alt="Screenshot 1" src="https://github.com/user-attachments/assets/5acbed9b-06bb-4570-8f7a-ef1c109fa180" />

 this is how I was able to solve the gravity problem. To get the gravity feel of pushing the wall, I had it so the transform of the player is updated and taken as velocity to be moved around. I also made it so if the player touches the wall by flying into it, it would try to mimic real physics, where you would bounce at an angle if coming in. To be honest, this is probably my proudest moment in the project because it just feels really smooth and nice to play around with.
 
 <img width="562" height="1584" alt="Screenshot 2" src="https://github.com/user-attachments/assets/64023cc2-1b5c-47bf-a7de-0a5b39cc1141" />

 <img width="501" height="609" alt="Screenshot 3" src="https://github.com/user-attachments/assets/0679c76a-019e-47f2-9d26-45e63a8f7d3e" />

 
For the last bit, I needed it so that the player had a way to come back to the space station because sometimes players would slip and couldn't come back, so I just made a simple dome where, if the player tries to leave it, it would just pull them back to the space station. 
 
 <img width="431" height="729" alt="Screenshot 4" src="https://github.com/user-attachments/assets/6a76e39a-6915-47fa-bd12-d7728af15402" />
 
This part of the project I am not too happy about, to be honest, I wanted to try to implement a jetpack where, if you move the stick, it should move the player in that direction, but I could not figure it out in time. I also wanted to try and add rotation when climbing, where if you hold on to a wall and turn your wrist, it should turn the player's rotation, but it proved very difficult and not fun in a way because it would be too much for the player to focus on, but I did not get to do proper testing for it.

Objects

In this, I had mainly 2 objects that were interactable with a purpose. The battery is the main mission of the game, where you can hold it and put it on you using sockets. 

<img width="322" height="299" alt="Screenshot 5" src="https://github.com/user-attachments/assets/1cd390a3-8ed6-489b-a3b1-cd0a3f6a0251" />

The mission is to get a charged battery and replace the dead one. When you replace it, it shoots confetti and makes a jungle noise. I am quite pleased with this, it could improve the particle system, but overall I think the feature is well done. The Gun is the other object that is fun to play with, its main purpose is that it shoots a bullet, and on impact the bullet explodes and pushes objects away. I made the grab transform the handle so it feels good in the hands. The main problem showed when I wanted to make it explode. The problem was that it impacts the gun and explodes in your face. To combat this, I tried to mess around with mask layers and see how they interact, but nothing worked. So I said I would just move the position of the bullet spawning, and it worked. I spent so much time trying to figure out how to get it to stop exploding, and just moving the spawn fixed it.

<img width="439" height="314" alt="Screenshot 6" src="https://github.com/user-attachments/assets/e7a716f2-5737-4d3a-a5d7-f632b85ed5b7" />

<img width="509" height="263" alt="Screenshot 7" src="https://github.com/user-attachments/assets/865d6810-9fad-4a8a-8d8d-dd4b6792a215" />

<img width="681" height="1407" alt="Screenshot 8" src="https://github.com/user-attachments/assets/40035e33-ba6d-412d-8ff1-c1fa7a2f7706" />

To be honest, I like this code, it was nice to try to figure out the layerMask but found a simpler solution. If I wanted to expand on this idea, I might try to add one where it pulls objects instead of pushing, or maybe a gun where it applies a force in one direction and use it like a jet pack. All other objects in the scene are just there to fill up space and look nice 

<img width="875" height="607" alt="Screenshot 9" src="https://github.com/user-attachments/assets/f504becf-5570-4d8f-960f-32078abb49d8" />


UI

The UI is alright it does its job, but on the day of the presentation it broke. It was supposed to have a ray, but it only shows a point on the UI because I did not want rays in my project and picking up objects. So I added it so it can only recognise UI, but on the day the Ray would get stuck on the button and stay. I don't know why, but it just did. Well, there were two UI one was just display text when the player hits a trigger zone to go change the battery, and one was the button to change the gravity so the player can feel how it might feel normally without 0 gravity.

<img width="440" height="377" alt="Screenshot 10" src="https://github.com/user-attachments/assets/576fe474-944c-4307-95b7-035913b02cf3" />

<img width="192" height="170" alt="Screenshot 11" src="https://github.com/user-attachments/assets/26db18a4-aac6-459b-9fce-aa1211673fd9" />

If I had to say, I think I should have put in my time to make it look nicer, try to add more functionality, like have a slider for the bounce and fraction in my movement gravity or some way where I can change the colour for the hand models for fun.

Sound and Assets

For this section, it was my biggest weakness, but I think I tried to do everything, I added sound to almost everything. I had it when the hand grabs objects and vibrates as you put stuff in the sockets, like the battery and gun. My proudest moment with sound was for the hackathon. I wanted it to feel like space, so when you open the second door in the airlock, I made it so there is no sound anywhere, ere like in space. The model is where I fell off because I am not an artist and not skilled in animation. I did the bare minimum, but I also think I worked around it quite nicely. The spaceship and battery assets are from a hackathon, but I made sure they had functionality, like the space station is all wall-climbable, and I added functionality to the batteries. For myself, I made the hand models handle it in a special way where, if it holds an object, the hand disappears, but if it is a wall, it turns into a sphere so the player can judge where they are holding from. Sound-wise, I think I did that perfectly, but the assets are where I wish I should have spent a little bit of time, like maybe I could have made a simple helmet, and you can put it on, just something simply like that, but the way I went around the hand to show the player is grabbing something, I think visually it shows it well.

<img width="251" height="251" alt="Screenshot 12" src="https://github.com/user-attachments/assets/a5754ec2-e8a9-4e62-8fd8-96495b0ea0bf" />

<img width="178" height="180" alt="Screenshot 13" src="https://github.com/user-attachments/assets/1bde2c86-f0ae-4113-997d-96f55b9895f0" />

<img width="266" height="392" alt="Screenshot 14" src="https://github.com/user-attachments/assets/a3a053e9-64f0-4852-b4f8-90a7a8cbf208" />

Extras not directly related to VR

There is some extra stuff not really related to the VR stuff, just more functionality and vibe of the project, like having a radio play all the time for the sound feel. The alarm triggers when collecting the battery. One feature that made it feel like a space is the airlock. I made it so that when the alarm goes off, it opens the door, and you can press the button to close it and then press the other button to close the sound and be outside the ship.

<img width="602" height="421" alt="Screenshot 15" src="https://github.com/user-attachments/assets/304233a5-d3f2-4932-8ffe-c7c7b6ff986c" />

<img width="389" height="375" alt="Screenshot 16" src="https://github.com/user-attachments/assets/78094402-d47d-44e2-a71c-6864ecae1d3f" />

If I had to do something like this again, I want to try the XR poke. I had a look at that, but the time and struggle of animation made it hard to add because you had to figure out the collision system and how much the button can move. As I said, I am not the best at animation, but with more time I could have added more buttons to say change music or could have made a crazy space station that can move with controls, but that would be a lot of time.

Conclusion

I believe I did what I could in the time and made a good-quality project with lots of features I chose to include. If I had to give a few points where I need to work on, I would say to have the more complex stuff done first, like the U, because I had issues where it would not point in the right direction at all and would bug out for example, on the screen it shows I am not pointing to the canvas, but in VR I am.

<img width="711" height="1295" alt="Screenshot 17" src="https://github.com/user-attachments/assets/bf3d8060-92f8-49e9-afae-ae237326ccd2" />

I wish I had done more stuff outside of the physics side of the project because I know I am good at that and try the stuff I am uncertain about. Overall, I am pleased with the project could have done more, but I did deliver a good VR simulator.


