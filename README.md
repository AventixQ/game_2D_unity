# 2D Unity Game - README

## Game Idea

Welcome to the 2D Unity game project! The goal of this project is to create a simple yet engaging 2D game using Unity. The game features a player character, enemies, a dynamic enemy "AI", collision detection, user interface elements, and more.

## Components of the Game

- **Player and Camera Movement**: The player can control their character's movement using the WSAD keys. A camera follows the player's movement, ensuring a smooth gameplay experience.

- **Mobile Enemy**: The game includes an enemy character that roams around the scene. This enemy will interact with the player based on its behavior.

- **Wanderer Algorithm**: The enemy features a wanderer algorithm, a script that enables random movements. When the player character is nearby, the enemy will start to chase the player until certain conditions are met.

- **Respawn Points**: Both the player and enemy have designated respawn points. This ensures that if the player or enemy is defeated, they will respawn at the appropriate location.

- **Map and Collision Detection**: The game features at least one map with objects, and collision detection is implemented. This adds depth to the gameplay and environment interaction.

- **User Interface (UI)**: The game includes a simple user interface, encompassing elements such as coins, lives, a health bar, and a player inventory.

## Gameplay Instructions

- **Movement**: Use the WSAD keys to control the player character's movement.

- **Enemy Interaction**: Beware of the mobile enemy. When it detects the player nearby, it will chase the player until certain conditions are met.

- **Objective**: Your objective is to find and collect the red crystal hidden within the maze.

- **Winning**: Collect the red crystal and stay alive while collecting as much gold as possible. Avoid enemies to survive.

- **Exiting the Game**: Press the ESC key to exit the game.

## Getting Started

To clone the repository and run the game:

```bash
git clone https://github.com/AventixQ/game_2D_unity.git
