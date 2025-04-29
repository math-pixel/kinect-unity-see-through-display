# kinect-unity-see-through-display

Unity scale : 10 unit = 1 meter
Kinect speed movement = Vector3(1,1,9.36) -> NB : change

## Infos
In unity the kinect is in the origin of the world in (0,0,0).
And the screen and the object need to be set up manually.

## Tips
So for a better set up I scan the object with the kinect sdk tools and upload obj in unity at scale *10

## Issues Resolved
### Screen displacement in reel life :
so the camera in unity is the perfect representation of the users eyes.
If the screen is perpendicular to the users vision there is no problem But in my case the screen is oriented
<add image>
for fix it i calculate the angle btw the vector observed object (poterie) in direction to perpendicular of screen and the vector user head to observefd object.
After that I apply this angle to the observed object. And now we have a beautiful illusion !
