# CMPM 163 Homework 2
This assignment showcases a tron-like shader that applies several different effects to a jetplane and a water shader that can reflect and refract its surroundings. Users can travel between the two parts through a portal set up in each scene. <sup>*</sup>
<img src="https://github.com/VMLima/CMPM163_HW2/blob/master/Screenshots/PortalTron.PNG" width="30%" height="30%">
<img src="https://github.com/VMLima/CMPM163_HW2/blob/master/Screenshots/PortalLandscape.PNG" width="30%" height="30%">

## Part A: Tron Filter 
The Tron filter is made up of 3 effects. The first is an outline shader that scales the vertices of an object on the first pass and renders the object normally on the second pass. The second is an outline shader that highlights the edges of the object and the last is a bloom effect that brightens the bright parts of the object. The outline shader is visible behind objects.
<img src="https://github.com/VMLima/CMPM163_HW2/blob/master/Screenshots/PartA.PNG">

## Part B: Outdoor 3D scene
The terrain is generated procedurally using Perlin noise with textures applied depending on the mesh height. The water reflects the skybox and refracts the objects under the water. It also refracts the bottom of the skybox creating an oil slick effect on the surface and the water effect still works when the user falls below the water level. The water shader can be controlled by holding the number keys and scrolling the mouse wheel.
* Holding 1 changes the Glossiness of the water
* Holding 2 changes the speed that the water flows
* Holding 3 changes the height of the water
* Holding 4 changes how much reflection vs refraction there is
<img src="https://github.com/VMLima/CMPM163_HW2/blob/master/Screenshots/PartB.PNG">
<img src="https://github.com/VMLima/CMPM163_HW2/blob/master/Screenshots/Underwater.PNG">

<sup>* If the X-Ray and Bloom filters are still visible after crossing to the landscape side, enter and exit the portal again</sup>
