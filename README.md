<p align="center">
  <img width="100%" alt="Turnbase" src="https://github.com/user-attachments/assets/070a18e8-f106-4910-a06a-e38ab6e5e07c">
  </br>
</p>

## 🔴About
A personal project focused on developing a turn-based RPG battle system inspired by the Persona series. The project features character skills, turn management, and combat mechanics designed to recreate the feel of JRPG battles.

<br>

## 📋 Project Info
This project using Unity 6000.0.58f2

| **Role** | **Name** | **Development Time** 
|:-|:-|:-|
| Game Programmer | Evan Jonathan | 1 month |

<br>

##  📜Scripts and Features

• Turn-Based Combat System <br>
• Skill System <br>
• Turn Order Management <br>
• Character Statistics <br>
• Battle State Machine <br>
• Enemy AI<br>


|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `TurnSystem` |Manages unit turns and battle flow|
|  `UnitManager.cs` | Manages all units on the battlefield|
| `BaseAction.cs`  | Abstract base class for all unit actions |
| `Unit.cs`  | Stores unit data and handles combat actions |
| `UnitAnimator.cs`  | Handles unit animations and visual effects |
| `UnitActionSystem.cs`  | Manages player input and unit actions during battle |
| `CameraManager.cs`  | Manages camera movement and positioning |
| `InputManager.cs`  | Handles player input |
| `EnemyAI.cs`  | Controls enemy AI behavior during combat |
| `etc`  | |


<br>


## 📂Files description

```
├── BelajarBikinTurnBase            # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # Project assets and resources
      ├── Animations                # Animation clips and Animator Controllers
      ├── Import                    # Imported packages and third-party assets
      ├── Materials                 # Materials used by game objects
      ├── Plugins                   # Third-party plugins and development tools
      ├── Prefabs                   # Reusable game object prefabs
      ├── Resources                 # Resources loaded at runtime
      ├── Scenes                    # Game scenes that can be opened and played in Unity
      ├── Scripts                   # Gameplay and system scripts
      ├── Settings                  # Unity project settings and configurations
      ├── TextMeshPro               # TextMeshPro assets and resources
      ├── Tumbal                    # Temporary placeholder assets used during development
      ├── TutorialInfo              # Unity-generated tutorial and URP resources
   ├── ...
      
```
<br>

## 🕹️Game controls

The following controls are bound in-game, for gameplay and testing.

## Battle Controller
| Key Binding       | Function          |
| ----------------- | ----------------- |
| Q          | Basic Attack |
| W             | Open Skill Menu              |
| Enter              | Confirm |
| 1            | Back |
| ← →           | Select target enemy            |

## Player Controller 
| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D         | Standard movement |
| E        | Interact |
| Mouse | Camera Movement|


<br>

Note:
<br>
CityScene -> City area to test UI, Shop, Inventory, PlayerController
<br>
CombatSystemScene -> Battle System (To Start Battle Press L)
