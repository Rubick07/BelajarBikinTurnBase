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
| `UnitActionSystem.cs`  | Manages for Unit Action in battle |
| `CameraManager.cs`  | Manages camera position |
| `InputManager.cs`  | Manages player input |
| `EnemyAI.cs`  | Manages for Enemy AI in combat scene |
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
