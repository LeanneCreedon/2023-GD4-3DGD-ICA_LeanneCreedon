![NewGameIdeaPoster](https://github.com/LeanneCreedon/2023-GD4-3DGD-ICA_LeanneCreedon/assets/78487811/9f57efcb-1af6-44be-8bb5-0df4d2a520c3)
# ICA 3D Game Development Project
By Leanne Creedon

## 🗃️ Overview ##

This repository contains Unity Project Files for my game. 🎲

Instructions for download: 

> Simply download the zip file and open it up in unity.

Link to Screencast: 

> https://youtu.be/ZLHfggLOJ_Y

## 📰 Game Description ##

**William’s Wildlife Adventure** is a point and click game set in a cozy cute wee town where all the animals can talk. William is a young boy who loves to read and one evening, after reading his favourite storybook, finds himself drifting off into a deep sleep. He wakes up and realises he is in the animal town from his book! What’s even more of a surprise for little William, is that he is now in fact a small gecko! On this adventure, you’ll meet many different animals who all have their own set of skills and personalities. Can you help young William to get back home to reality? He has school tomorrow his mother would be disappointed if he overslept! This game focuses on teaching children the importance of stories and using their imagination to learn and have fun. All work no play makes jack (William) a dull boy 😉

Genre: Point & Click, Social Simulation/Role-Playing, Adventure in 3rd-Person view.

Age Recomendation: Suitable for all age groups, targeted at younger players (PEGI rating would be 3).

Controls: Left-Click = Move & Sort Inventory Items, E = Interact.

<h2 align="center">***</h2>
<h1 align="center">🔍 Map of Fern Village 🔎</h1>
<h4 align="center">Welcome! Explore and get to know your Neighbors!</h4>
<p align="center"><img src="https://github.com/LeanneCreedon/2023-GD4-3DGD-ICA_LeanneCreedon/assets/78487811/fe5cb764-028b-4e01-8d22-313d3d0c75fd" width="600" /></p>
<p align="center"><sub><sup><i>Developed using Pixlr & Photopea</i></sup></sub></p>

## 🚶 Walkthrough ##

> [!TIP]
> On Start - Menu Loaded - Press Play / Press Exit
>
> > On Exit - Exits Application
> 
> -> On Play - Walk Around The Scene - Talk to NPC Mr Ribbit - Collect Leaf - Collect Stick - Interact with CampFire - Interact with Tree Blocking Path
>
> -> Walk into Fern Village
> 
> > In No Particular Order...
> 
> -> Talk to NPC Cliff Ferny - Talk to NPC Rupin Merryweather - Talk to NPC P.C. Monty - Talk to NPC Sammy - Talk to NPC Bamble - Talk to NPC Mayor Tobus
>
> -> Collect 3 Apples - Place all 3 Apples in Crate - Find Key in Bag - Open Chest with Key - Obtain Special Book from Chest
>
> > THE END....for now
>
> > The rest would be...
>
> -> Give Book to P.C. Monty - Bring all villagers to town hall (they would follow player after their quest is complete) - Talk to Mayor Tobus - He Sends you Home to Reality - Short Cutscene Outro - THE END!

## 🐛 Bugs ##

- [ ] When the torch object is crafted, the 2D sprite is not visable when the torch is first selected after being crafted.
- [ ] When an item is picked up, the dialogue UI does not disable after the allocated time for it to remain enabled. This is due to the object being destroyed afterwards and therefore the script no longer knows to disable it.
- [ ] Apple sometimes does not add to the crate when interacted with. Not sure why.
- [ ] The NavMesh is not smooth in all areas of the map. Some parts are a bit hard to move through due to the mav mesh not covering the ground properly everywhere.
- [ ] As seen, there is another brach named 'PerformanceDrop'. This branch was created becuase during the attempted implementation of the Objective System, something went wrong and the game started to lag more. The player controller also began to look strange.
- [ ] When the player collides with an object, the collision works but is jittery. From researching this issue, it could be a number of things such as the scale of the assets being to big or small. The assets in the scene are scaled down small so that could be the problem.

## ⭐ Functionality Achieved ##

- Point & CLick Player Controller
- NavMesh Navigation
- Inventory
- Crafting
- Dialogue
- Pickups
- Animations & VFX (Player, NPCs, Chest (shake if no key, open if key), Fire, Leaves Falling)
- Scene Transition from Main Menu to Game
- Pause Menu
- Interaction
- Simple Quests (Find Key -> Open Chest -> Obtain Book, Find 3 Apples -> Place in Empty Crate, Collect Leaf -> Collect Stick -> Craft Torch -> Set Torch On Fire -> Burn Tree)
- UI (Menus (main, pause), HUD (inventory, current objective, pause button), Dialogue box with text, Interaction Prompt that changes text based on nearby object)
- Events
- Use of Scriptable Objects for better data
- Camera Stacks (UI Camera (Overaly), Main Camera)
- Sounds (Background Music (Menu, Game) & SFX (pickup, NPC mumbling))
- Drag & Drop Items Functionality on the Inventory HUD
- Item Quantity Tracker on HUD
- Pink Selection Highlight OnMouseHover (using third party asset linked below)

## 😞 Incomplete Objectives ##

- Objective System not currently being used properly - this is due to the complication of the implementation attempted and the time left to achieve the goal. The obejctive does update one time on the UI but it is not updating via the objective system. The attemped approach was creating scriptable objects that held the different tasks needed to complete the objective. For example: Find a way to clear the path -> Collect stick 1, collect leaf 1, craft torch 1, set torch on fire 1, burn tree 1. This also meant that the progress of the player could not be properly tracked on screen without an objective system set up, so this feature was left out.
  
- Final screen letting the player know how they did and or what was learnt from playing the game. For this, it would have been a brief amount of text on screen simply informing the player of the importance of having fun and not taking life too seriously. As the game is about a young boy named William having an innocent dream about waking up in the animal village from his favourite story book, this would have been appropriate.
  
- Intro dialogue to set the scene for the story and what was going on.
  
- Have the dialogue update when the player does the quest for the NPC.
  
- Have the NPC follow the player around the town when they complete their objective. This would all lead up to bringing all the characters to the town hall for the election banquet. When that occurs, the Mayor thanks William and sends him home after helping the towns folk. That was the main goal regarding the level progression.
  
- For the inventory items, the original idea was to be able to use the drag and drop functionality to use or do something with the objects collected. Such as drag and drop apple into crate or drag and drop torch into fire. However, as other tasks took priority over this, the item usage controls was left with the E key that is used for interacting with objects and NPCs.


## 🧵 Sources ##

**Reference List:** 
| Type | Description | Website URL | Asset URL |
| --- | --- | --- | --- |
| 🌲 | Low Poly Village House Cute | [Sketchfab](https://sketchfab.com/feed) | https://sketchfab.com/3d-models/low-poly-village-house-cute-53077dcdf6e24b94b743b0139692438f |
| 🌲 | Low Poly Cute House | [cgtrader](https://www.cgtrader.com/) | https://www.cgtrader.com/free-3d-models/exterior/house/low-poly-cute-house-dffe99ed-8cfa-406e-9500-f5e9acd8bf60 |
| 🌲 | Fantasy FREE Model (Pack) | [TURBOSQUID](https://www.turbosquid.com/) | https://www.turbosquid.com/3d-models/fantasy-free-model-2098553 |
| 🌲 | 3D model Bugs City: Cartoon Town Mushroom House | [TURBOSQUID](https://www.turbosquid.com/) | https://www.turbosquid.com/3d-models/3d-model-bugs-city-toon-cartoon-town-lowpoly-free-pack-1933085 |
| 🌲 | Low Poly Wind | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/vfx/shaders/low-poly-wind-182586 |
| 🌲 | Low-Poly Style Nature | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/environments/low-poly-style-nature-66322 |
| 🌲 | Low Poly Cartoon Environment Pack | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/environments/low-poly-cartoon-environment-pack-233907 |
| 🌲 | Quirky Series - FREE Animals Pack | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235 |
| 🌲 | Kids character Free | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/characters/kids-character-free-242192 |
| 🔴 | Point & Click Movement | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=LVu3_IVCzys&t=303s |
| 🖋️ | Point & Click Movement | [GitHub](https://github.com/) | https://github.com/ItsPogle/Unity-Mouse-Click-Movement-Template/blob/main/Episode%201%20-%20Mouse%20Click%20Movement/Scripts/PlayerController.cs |
| 🔴 | Simple Dialogue System with Scriptable Objects | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=z3XgjSb_Oh0 |
| 🔴 | Unity Pause Game - Easy Tutorial (2023) | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=G1AQxNAQV8g |
| 🔴 | Let's make an Inventory System! | [YouTube](https://www.youtube.com/) | https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx |
| 🔴 | Unity Interaction System How To Interact With Any Game Object In Unity | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=THmW4YolDok&t=861s |
| 🎆 | Quick Outline | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488 |
| 🔴 | Outline Object on Pointer Hover and Selection at Runtime in Unity | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=qYnAkMGbgwo |
| 🖋️ | Outline Object on Pointer Hover and Selection at Runtime in Unity | [GitHub](https://github.com/) | https://github.com/DA-LAB-Tutorials/YouTube-Unity-Tutorials/blob/main/OutlineSelection.cs |
| ✍️ | Warung Kopi Light | [1001fonts](https://www.1001fonts.com/) | https://www.1001fonts.com/simple+clean-fonts.html |
| ✍️ | Primer Bold | [1001fonts](https://www.1001fonts.com/) | https://www.1001fonts.com/simple+clean-fonts.html |
| ✍️ | Odin Rounded | [1001fonts](https://www.1001fonts.com/) | https://www.1001fonts.com/simple+clean-fonts.html |
| ✍️ | BrookeshappeII.10-p BDZ | [fontspace](https://www.fontspace.com/) | https://www.fontspace.com/category/cute,pencil |
| 🔨 | Photopea | [Photopea](https://www.photopea.com/) | https://www.photopea.com/ |
| 🔨 | ChatGPT | [ChatGPT](https://chat.openai.com/) | https://chat.openai.com/ |
| 🎆 | Ultimate Particle Pack | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/vfx/particles/ultimate-particle-pack-265409 |
| 🌲 | Lowpoly Wooden Chest | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/props/lowpoly-wooden-chest-93960 |
| 🌲 | Low Poly Survival Kit MOBILE and VR READY | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/props/tools/low-poly-survival-kit-mobile-and-vr-ready-111978 |
| 🌲 | Simplistic Low Poly Nature | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/environments/simplistic-low-poly-nature-93894 |
| 🌲 | Low Poly Fruit Pickups | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/props/food/low-poly-fruit-pickups-98135 |
| 🌲 | Low-Poly Nature | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/3d/environments/low-poly-nature-260306 |
| 🎧 | Crazy Town | [Purple Planet](https://www.purple-planet.com/) | https://www.purple-planet.com/tracks/crazy-town |
| 🎧 | Relaxing Ambient Scene | [Purple Planet](https://www.purple-planet.com/) | https://www.purple-planet.com/tracks/relaxing-ambient-scene |
| 🎧 | GrandPa004(2.5s).mp3 | [Freesound.org](https://freesound.org/) | https://freesound.org/people/gipsyGA/sounds/128479/ |
| 🎧 | INCOHERENT SILLY MUMBLING.wav | [Freesound.org](https://freesound.org/) | https://freesound.org/people/metrostock99/sounds/514495/ |
| 🎧 | Cartoon Mumble Speak | [Freesound.org](https://freesound.org/) | https://freesound.org/people/dersuperanton/sounds/435876/ |
| 🎧 | Cute Pop Sound Effects | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=QvghQOO3K-I |
| 🎧 | Pop Sound Effect! FREE TO DOWNLOAD | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=Zw1Xp9wdmog |
| 🌲 | Stylized Fantasy Key | [Sketchfab](https://sketchfab.com/feed) | https://sketchfab.com/3d-models/stylized-fantasy-key-b5431c53a2ed48db9fde3ebfc59cd56a |
| 🖼️ | E Key | [FLATICON](https://www.flaticon.com/) | https://www.flaticon.com/free-icon/keyboard-key-e_32007 |
| 🔴 | Unity TERRAIN Tutorial - Easy and Quick (2023) | [YouTube](https://www.youtube.com/) | https://www.youtube.com/watch?v=DbJB9534PZQ |
| 🔨 | Odin Inspector | [Unity Asset Store](https://assetstore.unity.com/) | https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041 |
| 🔨 | Pixlr | [Pixlr](https://pixlr.com/) | https://pixlr.com/ |
| 🖋️ | Scripts used Referenced in the files | [GitHub](https://github.com/) | https://github.com/nmcguinness/2023_GD4_Introduction.git |

> [!NOTE]
> **Legend:** 
>| gitmoji | Meaning |
>| --- | --- |
>| 🔴  | Tutorial |
>| 🔨 | Tool |
>| 🖋️ | Script |
>| 🎧 | Sound |
>| 🌲 | 3D Asset |
>| 🖼️ | Image Texture |
>| ✍️  | Font |
>| 🎆  | VFX |
