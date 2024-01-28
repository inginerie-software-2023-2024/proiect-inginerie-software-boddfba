# Elysian Solitude - Project


## 1 - Clear definition of Problem Statement/Product vision
	
- Creating a fully working Massively Multiplayer Online Role-Playing Game (MMORPG) in Unity (Metin 2 style) . The game will have a few maps based on different themes where players can meet and level up by defeating different monsters and bosses.
Every player will have their predefined abilities and can scale up their power by going on different adventures across the world.

## 2 - Product features and functionalities

![ERROR](https://github.com/inginerie-software-2023-2024/proiect-inginerie-software-boddfba/blob/main/Images/Product_features%26functionalities.png)

![ERROR](https://github.com/inginerie-software-2023-2024/proiect-inginerie-software-boddfba/blob/main/Images/Feature_development_roadmap.png)

## 3 - Non-functional requirements

1. Performance: The game should maintain a consistent frame rate of at least 30 frames per second (FPS) on minimum system requirements. Loading times for maps and game assets should not be more than 10 seconds to ensure a seamless gaming experience.

2. Scalability: The game server should be scalable to accommodate a minimum of 50 concurrent players. The system should gracefully handle 5 maps and around 50 monsters without significant performance degradation.

3. Reliability: The game server should have a decent uptime over any given month. In case of server or connection failures, the game should be able to run on the user's local device offline.

4. Maintainability: Implement version control for the game's source code every month to track changes and manage collaboration among developers.

5. Compatibility: Ensure compatibility with a range of hardware configurations. Running on a Unity engine, the game should support Windows and macOS to broaden the player base.

## 4 - Customer Journey

### User Persona:
- Adventurous Alex 
### Demographic Information:
- Age: 22
- Gender: Male
- Location: Bucuresti, Romania 
- Occupation: Unibuc student, studying Software Engineering
### Background:
- Alex has been an avid gamer since childhood, with a preference for MMORPGs. 
- Spends a lot of time preparing for courses and exams in order to become a software developer, seeking an escape and social interaction in gaming. 
- Beginner level of technological proficiency. 
### Goals and Objectives: 
- Primary Goal: Experience an immersive and challenging MMORPG environment.  
- Secondary Goal: Connect with a community of like-minded players.
### Motivations: 
- Motivated by a desire for adventure, exploration, and overcoming in-game challenges. 
- Enjoys the social aspect of gaming and forming alliances with other players.

### Behaviors: 
- Prefers playing on a desktop PC but occasionally uses a laptop for gaming on the go. Typically plays 10-15 hours per week, with longer sessions on weekends.
- Enjoys exploring in-game lore and participating in both PvE and PvP activities.

### User Journey:
- Discovery: Alex discovers the MMORPG through online forums and social media. Engages with promotional materials and trailers to learn more.

- Trial and Onboarding: Decides to try the game after a friend recommends him the game. Completes the onboarding process, including choosing the character and moving through the map. 

- Early Gameplay: Explores the first map and completes introductory quests. Participates in early social interactions, possibly joining a guild.

- Mid-Game Challenges: Progresses through different maps, encountering various monsters and bosses. Engages in PvP activities and challenges to level up and improve abilities.
 
- Community Interaction: Regularly participates in guild events, and in-game chat. Collaborates with other players to tackle challenging dungeons. 

- Achievements and Rewards: Achieves significant in-game milestones, earning rewards and recognition. Enjoys the sense of accomplishment and progression.

## 5 - State Diagram

![ERROR](https://github.com/inginerie-software-2023-2024/proiect-inginerie-software-boddfba/blob/main/Images/state_diagram.png)

## 6 - A set of User Stories

### Game World:
- As a new player, I want to explore the detailed main map so that I get a sense of the game's world and lore.
- As a normal player, I know  that 4-5 theme-based maps are in progress so that I anticipate and prepare for new challenges.
- As a player, I want to encounter diverse monsters on each map so that the gameplay is engaging and unpredictable. 
- As a dedicated player, I look forward to facing specific boss monsters on each map so that I can test my skills and earn unique rewards.


### Character: 
- As a new player, I want to choose my starting character so that I can start my gaming experience. 
- As a player, I expect smooth and realistic animations for my character so that my gameplay experience is enhanced.
- As a player, I look forward to the introduction of multiple character model so that variety is provided and I get to choose the one that suits my playstyle.

### Abilities:
- As a player, I want to experience the standard abilities with specific animations for my character so that an engaging combat system is ensured. 
- As an advanced player, I anticipate the addition of customized abilities for each character model so that unique strategies and playstyles are offered.


### User Interface:
- As a player, I expect a well-designed main menu so that easy access to various game features is provided.

### Community:
- As a social player, I look forward to the implementation of a chat system so that it allows me to communicate with other players in real-time. 
- As a player who values community, I want the ability to add friends in the game so that a sense of teamwork is fostered.


 ## 7 - Prioritized Product Backlog

![ERROR](https://github.com/inginerie-software-2023-2024/proiect-inginerie-software-boddfba/blob/main/Images/Trello.png)


## 8 - Team members:
- Tudor Oprea
- Albert-Ionut Balauta-Amargheoalei
- Vlad-Rares Furdui
- Mihai-Razvan Dana
- George Boboc (Senior Code)
- Nicolae Dirva (TL)



# Software Architecture Report 


Project: Elysian Solitude 
Date: 01.2024
Version: commit 67e3cbf

## What the purpose of the software project is 
* This may be a summary based on the planning documentation. 
A fully working Massively Multiplayer Online Role-Playing Game (MMORPG) in Unity (Metin 2 style) . The game will have a few maps based on different themes where players can meet and level up by defeating different monsters and bosses. Every player will have their predefined abilities and can scale up their power by going on different adventures across the world.	

* Fulfilled capabilities – what can the project do at this point, and what is to be done until project fulfillment. 
The whole idea of the game is travelling along all the maps, get all the items and finish your job to save the Empire. Along your way, you can do many different actions:
You can explore the design of different maps
You can battle with different mobs, correlated to the map theme
You can defeat bosses in the maps and gain different items
After killing a mob, you can use the items it drops to restore the health
You can use the items dropped by the bosses to teleport to other maps
		
## Guides on how to: 
* Run the project locally.
		To run the project locally you should run the .exe file (the builded version of the game), or open it in Unity app and run from a scene.
* Build the project. 
		The project is already builded. Otherwise, you should download and install Unity and UnityHub, open the project and then click on run. To build it you should press the build button.
* Deploy the project (either locally, or how is it hosted, where it is the case) 
		To deploy the project you should enter the site itch.io (or other similar site) and upload the project.
* Contribution guide  
Patterns used in your application 
			We used a few patterns like Singletone - MainMenu.

## Application entry points 
* Data sources 
		The code and the packages we used is organized in the Assets folder of the project. There are all the documents of the application.
		
* Data inputs 
		The inputs are mouse and keyboard events, witch controls the player and the action. With W,A,S,D you can walk on the map forward, to the left or right, or backward. With Q you can beat enemies, and the same you can do by using the 1,2,3 keys. The mouse is used to control the main menu.
* Configuration files 
	The project contains basic configuration files for a Unity project.

## High level diagrams of the architecture  
* User/data journeys 
	The users follow the next road map in their progress along the game. There are five maps where our hero should beat all the enemies to receive items in inventory. These items are valuable because it helps you travel between the maps and after the battle with the final boss, you receive a special one, that announce you about finishing all your long road and beating all the monsters. That comes with a special Congratulations message. 
	![ERROR](https://github.com/inginerie-software-2023-2024/proiect-inginerie-software-boddfba/blob/main/Images/state_diagram.png)
* Most valuable output 
		The most valuable output of the game is the pleasure of playing it. You receive items by playing to keep it interesting, and each item is useful at one step. 

## Deployment plan 
* Where is the application deployed. 
The application is deployed on itch.io and it is available on this link: https://de3v.itch.io/eli 
* How the CI/CD pipeline works. 
	Before pushing different changes in the map, we had to check for any conflicts with the code on our branch, and had to adapt it so that the game would work. Everyone had a branch, and after making sure that the branch is safe to use as the main game, it would have a pull request to push it to main.

## Description of the QA process 
* Test suites – what do they test.
	We tested the way combat works, if the teleportation is in concordance with the schema we had and if the items dropped by a mob restores health

## External dependencies included in the project 
* APIs used 
	Our project does not integrate with external APIs.
* Libraries 
	The game uses only Libraries offered by Unity (UnityEngine.UI , UnityEngine.Events etc.). There are some assets from the game that are imported from AssetStore.
How vulnerable is the project to dependency attacks (ex. Dependency Confusion) 
Dependency attacks, like Dependency Confusion, are a concern for any modern software project. We've tried to reduce this risk and we ensured that all the libraries and assets are sourced from official and verified repositories, and that means that our project contains only secure and autentic versions..




