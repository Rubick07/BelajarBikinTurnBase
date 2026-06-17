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
| `TurnSystem` |Manages Turn for unit|
|  `UnitManager.cs` | Manages Unit in field|
| `BaseAction.cs`  | Abstract base class for all unit actions |
| `Unit.cs`  | Handles character data and combat actions for battle units |
| `UnitAnimator.cs`  | Handles Unit Animation and effect |
| `UnitActionSystem.cs`  | Manages for player Input in battle |
| `CameraManager.cs`  | Manages camera position |
| `InputManager.cs`  | Manages player input |
| `EnemyAI.cs`  | Manages for Enemy AI in combat scene |
| `etc`  | |


<br>


## 📂Files description

```
├── BelajarBikinTurnBase            # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # In this folder, it contains all our code, assets, scenes, etc was not automatically created by Unity
      ├── Animations                # In this folder, it contaions all animation clip and animation Controller
      ├── Import                    # In this folder, it contaions all imported Unity Packages
      ├── Materials                 # In this folder, it contaions all materials
      ├── Plugins                   # In this folder, it contaions plugin for development
      ├── Prefabs                   # In this folder, it contaions all prefabs for the games
      ├── Resources                 # In this folder, it contaions plugin settings
      ├── Scenes                    # In this folder, there are scenes. You can open these scenes to play the game via Unity
      ├── Scripts                   # In this folder, it contaions all script for the games
      ├── Settings                  # In this folder, it contaions base settings from unity
      ├── TextMeshPro               # In this folder, it contaions plugin for TextMeshPro
      ├── Tumbal                    # In this folder, it contaions image for placeholder when development
      ├── TutorialInfo              # In this folder, it contaions URP packages
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
