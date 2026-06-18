<p align="center">
  <img width="100%" alt="Turnbase" src="https://github.com/user-attachments/assets/070a18e8-f106-4910-a06a-e38ab6e5e07c">
  </br>
</p>

## Developer & Contributions
**Evan Jonathan** (Game Programmer) <br>

## About
A personal project focused on developing a turn-based RPG battle system inspired by the Persona series. The project features character skills, turn management, and combat mechanics designed to recreate the feel of JRPG battles.

<br>

<br>

## Key Features

• Turn-Based Combat System <br>
• Skill System <br>
• Turn Order Management <br>
• Character Statistics <br>
• Battle State Machine <br>
• Enemy AI<br>

<table>
<tr>
<td align="center" width="50%">
<strong>RPG Turn-based Combat System</strong><br>
<img width="100%" alt="RPG" src="https://github.com/user-attachments/assets/4972e608-7aa8-4745-8e7d-d405d71f95ff">
</td>
</tr>
</table>


## Scene Flow
```mermaid
flowchart LR
  css[CombatSystemScene]
```

## Layer / Module Design
```mermaid
---
config:
  theme: neutral
  look: neo
---
graph TD
    subgraph "Core Systems"
        IM[InputManager]
        Ts[Turn System]
        
    end
    
    subgraph "Player Systems"
        UAS[Unit Action System]
        CC[Camera Controller]
    end
    
    subgraph "Unit System"
        U[Unit]
        UM[Unit Manager]
        HS[Health System]
        ManaSystem[ManaSystem]
        BA[Base Action]
    end

    subgraph "Enemy Systems"
        EA[Enemy AI]
    end

    subgraph "UI Systems"
        UnitActionSystemUI[Unit Action SystemUI]
        TurnSystemUI[Turn System UI]
        ActionBusyUI[Action Busy UI]
        HealthSystemUI[HealthSystemUI]
        ManaSystemUI[ManaSystemUI]
        GameWinUI[GameWinUI]
        GameLoseUI[GameLoseUI]
        UnitSkillUI[UnitSkillUI]
    end

    IM --> UAS
    IM --> CC

    Ts --> TurnSystemUI
    UAS --> UnitActionSystemUI
    UAS --> U
    U --> UM
    U --> HS
    U --> ManaSystem
    U --> BA
    U --> UnitSkillUI
    U --> UnitActionSystemUI

    UM --> GameWinUI
    UM --> GameLoseUI
    BA --> ActionBusyUI
    HS --> HealthSystemUI

    ManaSystem --> ManaSystemUI
    EA --> U
    
    
    
    classDef coreStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef playerStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef enemyStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px
    classDef unitStyle fill:#fff3e0,stroke:#e65100,stroke-width:2px
    classDef uiStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    
    class IM,Ts coreStyle
    class UAS,CC playerStyle
    class EAI enemyStyle
    class U,UM,HS,ManaSystem unitStyle
    class UnitActionSystemUI,TurnSystemUI,ActionBusyUI,GameWinUI,GameLoseUI,UnitSkillUI uiStyle

```

## Modules and Features

The 3D RPG turn-based Combat gameplay with Persona-inspired GridSystem,TurnSystem, EnemyAI, and HealthSystem is powered by an extensive Unity C# scripting system.

|  📂 Name     | 🎬 Scene |  📋 Responsibility                                                 |
| ------------------- |----------------| ------------------------------------------------------------ |
| `TurnSystem` | CombatSystemScene |Manages unit turns and battle flow|
| `UnitManager` | CombatSystemScene |Manages all units on the battlefield|
| `BaseAction` | CombatSystemScene |Abstract base class for all unit actions|
|  `Unit.cs` | CombatSystemScene | Stores unit data and handles combat actions|
| `UnitAnimator.cs`  | CombatSystemScene |Handles unit animations and visual effects |
| `UnitActionSystem.cs`  | CombatSystemScene |Manages player input and unit actions during battle |
| `CameraManager.cs`| CombatSystemScene | Manages camera movement and positioning |
| `InputManager.cs`| CombatSystemScene | Handles player input |
| `EnemyAI.cs`| CombatSystemScene | Controls enemy AI behavior during combat |

<br>

## Game Flow Chart
```mermaid
---
config:
  theme: redux
  look: neo
---
flowchart TD
  start([Battle Start])
  start --> CheckPlayerTurn{Check Is Player Turn}

  CheckPlayerTurn -->|Yes| PlayerTurn[Player Turn]

  PlayerTurn --> ChoosePlayerUnitAction[Choose Player Unit Action]
  ChoosePlayerUnitAction --> PlayerUnitActionPerform[Player Unit Action Perform]

  PlayerUnitActionPerform --> CheckEnemyUnit{Is Enemy Unit Health <= 0}

  CheckEnemyUnit -->|Yes| EnemyUnitDead[Enemy Unit Dead]
  CheckEnemyUnit -->|No| PlayerTurnEnd[Player Turn End]

  EnemyUnitDead --> CheckEnemyUnitList{Check Unit Manager Are there still Enemy unit on the battlefield?}

  CheckEnemyUnitList -->|Yes| PlayerTurnEnd
  CheckEnemyUnitList -->|No| Victory[VICTORY!]

  PlayerTurnEnd --> CheckPlayerTurn
  
  CheckPlayerTurn -->|No| EnemyAI[EnemyAI]

  EnemyAI --> ChooseBestAction[Choose Best Action]
  ChooseBestAction --> EnemyActionPerform[EnemyActionPerform]

  EnemyActionPerform --> CheckPlayerUnit{Is Player Unit Health <= 0}

  CheckPlayerUnit -->|Yes| PlayerUnitDead
  CheckPlayerUnit -->|No| EnemyActionComplete[Enemy Action Complete]

  PlayerUnitDead --> CheckPlayerUnitList{Check Unit Manager Are there still Player unit on the battlefield?}

  CheckPlayerUnitList -->|Yes| EnemyActionComplete
  CheckPlayerUnitList -->|No| Defeat[Defeat!]


  EnemyActionComplete --> EnemyTurnEnd[Enemy Turn End]

  EnemyTurnEnd --> CheckPlayerTurn

```

<br>

## Event Signal Diagram
```mermaid
classDiagram
    %% --- Unit Systems ---
    class Unit {
        +OnAnyUnitSpawned()
        +OnAnyUnitDead()
    }

    class UnitActionSystem {
        +OnStateChanged()
        +OnSelectedUnitChanged()
        +OnSelectedActionChanged()
        +OnBusyChanged(bool)
        +OnActionStarted()
    }

    class HealthSystem {
        +OnDead()
        +OnDamaged()
        +OnRestoreHealth()
    }

    class ManaSystem {
        +OnConsumeMana()
        +OnRestoreMana()
    }

    class TurnSystem {
        +OnTurnChanged()
        +OnUnitTurnChanged()
    }

    class BaseAction{
        +OnAnyActionStart()
        +OnAnyActionComplete()  
    }

    class UnitManager{
        +OnEnemyUnitListEmpty()
        +OnFriendlyUnitListEmpty()
    }


    %% --- Relations ---
    UnitManager --> Unit : Update List

    Unit --> HealthSystem : Modify Health
    Unit --> ManaSystem : Modify Mana
    Unit --> BaseAction : GetUnitAction

    UnitActionSystem --> TurnSystem : CheckCurrentTurnIsAlly
    BaseAction --> TurnSystem : Update Action Complete
    
    HealthSystem --> Unit : Dead

    UnitActionSystem --> BaseAction : PerformAction


```

<br>

## Installation & Setup
1. Clone this repository
2. Open the project in Unity (6 or later recommended)
3. Open the main gameplay scene
4. Press Play to start testing

CityScene -> City area to test UI, Shop, Inventory, PlayerController
<br>
CombatSystemScene -> Battle System (To Start Battle Press L)

## Controls
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

