# 🐦 Flappy Bird - Unity Clone

Un clon del clàssic joc Flappy Bird desenvolupat amb Unity com a projecte d'aprenentatge de desenvolupament de videojocs.

![Unity](https://img.shields.io/badge/Unity-2022.3.9f1-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-Language-blue)
![License](https://img.shields.io/badge/License-MIT-green)

## 📋 Descripció

Aquest és un clon funcional del famós joc mòbil Flappy Bird, creat utilitzant Unity 2022.3.9f1 i programat en C#. El joc implementa tota la mecànica essencial: control de l'ocell, física de vol, generació procedural d'obstacles, sistema de puntuació i col·lisions.

## 🎮 Com Jugar

### Controls
- **Click Esquerre del Ratolí** o **Espai**: Fer volar l'ocell
- **R**: Reiniciar el joc després de morir

### Objectiu
- Vola entre els obstacles (tubs) sense col·lisionar
- Cada obstacle superat suma 1 punt a la teva puntuació
- El joc acaba quan col·lisions amb un obstacle o el terra

## 🛠️ Tecnologies Utilitzades

- **Motor**: Unity 2022.3.9f1
- **Llenguatge**: C#
- **UI**: TextMesh Pro (TMP)
- **Física**: Unity Physics2D
- **Àudio**: Unity Audio System

## 📦 Instal·lació i Execució

### Requisits Previs
- Unity Hub instal·lat
- Unity Editor 2022.3.9f1 (o superior)
- Sistema operatiu: Windows, macOS o Linux

### Pas a Pas

1. **Clona el repositori**
   ```bash
   git clone https://github.com/Irisdurantoteldia/FlappyBird.git
   cd FlappyBird
   ```

2. **Obre el projecte amb Unity Hub**
   - Obre Unity Hub
   - Clica a "Add" i selecciona la carpeta del projecte
   - Selecciona la versió correcta d'Unity (2022.3.9f1)
   - Clica sobre el projecte per obrir-lo

3. **Executa el joc**
   - A l'editor Unity, obre `Assets/Scenes/SampleScene.unity`
   - Prem el botó Play (▶️) a la part superior
   - Juga!

4. **Build del joc (opcional)**
   - Ves a `File > Build Settings`
   - Selecciona la teva plataforma (Windows, Mac, Linux)
   - Clica "Build" i selecciona una carpeta de destinació
   - Executa l'arxiu generat

## 📁 Estructura del Projecte

```
FlappyBird/
│
├── Assets/
│   ├── Fonts/                    # Font personalitzada (SpongeBoy)
│   │   └── SpongeboyRegular-gx2n6.otf
│   │
│   ├── Prefabs/                  # Prefabs del joc
│   │   ├── Bird.prefab          # Prefab de l'ocell jugador
│   │   └── Obstacle.prefab      # Prefab dels obstacles (tubs)
│   │
│   ├── Scenes/                   # Escenes del joc
│   │   └── SampleScene.unity    # Escena principal
│   │
│   ├── Scripts/                  # Scripts C#
│   │   ├── PlayerController.cs  # Control del jugador
│   │   ├── GameManager.cs       # Gestió del joc i puntuació
│   │   ├── ObstacleSpawner.cs   # Generació d'obstacles
│   │   ├── Obstacle.cs          # Comportament dels obstacles
│   │   └── MenuManager.cs       # Gestió del menú
│   │
│   ├── Sounds/                   # Efectes de so
│   │   ├── gameover_1.mp3       # So de Game Over
│   │   ├── lobby-classic-game.mp3 # Música de fons
│   │   └── untitled_599.mp3     # So de punt
│   │
│   ├── Sprites/                  # Sprites i animacions
│   │   ├── background.png       # Fons del joc
│   │   ├── pipe.png            # Sprite dels tubs
│   │   ├── flap-1.png          # Animació de vol (frame 1)
│   │   ├── flap-2.png          # Animació de vol (frame 2)
│   │   ├── flap-3.png          # Animació de vol (frame 3)
│   │   ├── flap-4.png          # Animació de vol (frame 4)
│   │   ├── got-hit-1.png       # Animació de mort (frame 1)
│   │   ├── got-hit-2.png       # Animació de mort (frame 2)
│   │   ├── Alive.anim          # Animació "viu"
│   │   └── Dead.anim           # Animació "mort"
│   │
│   └── TextMesh Pro/            # Recursos de TextMesh Pro
│
├── Packages/                     # Dependencies del projecte
├── ProjectSettings/              # Configuració d'Unity
└── README.md                     # Aquest fitxer
```

## 🎯 Característiques Implementades

### ✅ Mecàniques de Joc
- Sistema de vol amb física realista
- Rotació dinàmica de l'ocell segons la velocitat vertical
- Control responsive (click o espai)
- Detecció precisa de col·lisions

### ✅ Sistema d'Obstacles
- Generació procedural d'obstacles a intervals regulars
- Alçada aleatòria dels obstacles
- Moviment automàtic cap a l'esquerra
- Destrucció automàtica fora de pantalla

### ✅ Sistema de Puntuació
- Comptador de punts en temps real
- Increment de puntuació al passar cada obstacle
- Interfície TextMesh Pro per a una millor qualitat visual

### ✅ Efectes Visuals i Àudio
- Animació de l'ocell volant (4 frames)
- Animació de mort (2 frames)
- So quan es guanya un punt
- So de Game Over
- Música de fons (opcional)

### ✅ Gestió del Joc
- Menú de Game Over
- Sistema de reinici (tecla R)
- Singleton pattern per a GameManager i MenuManager

## 🧠 Com Funciona

### Arquitectura del Codi

El projecte segueix una arquitectura orientada a components típica d'Unity:

#### 1. **PlayerController.cs**
Gestiona el comportament de l'ocell jugador:
```csharp
// Física de salt
void Flap()
{
    rb.velocity = Vector2.zero;
    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
}

// Rotació dinàmica
float rotationZ = Mathf.Clamp(rb.velocity.y * 2f, -maxRotationAngle, maxRotationAngle);
transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
```

**Funcionalitats**:
- Detecta input del jugador (espai/click)
- Aplica força de salt utilitzant Rigidbody2D
- Ajusta la rotació segons la velocitat vertical
- Gestiona les col·lisions amb obstacles i terra
- Controla les animacions (viu/mort)
- Reprodueix efectes de so

#### 2. **GameManager.cs**
Gestiona l'estat global del joc:
```csharp
public void AddScore(int value)
{
    score += value;
    UpdateScoreText();
    if (audioSource != null && pointSound != null)
    {
        audioSource.PlayOneShot(pointSound);
    }
}
```

**Funcionalitats**:
- Implementa el patró Singleton per a accés global
- Manté el comptador de puntuació
- Actualitza la interfície de puntuació
- Reprodueix sons de punts

#### 3. **ObstacleSpawner.cs**
Genera obstacles de forma procedural:
```csharp
void SpawnObstacle()
{
    float spawnPosY = Random.Range(spawnHeightMin, spawnHeightMax);
    Instantiate(obstaclePrefab, new Vector3(transform.position.x, spawnPosY, 0), Quaternion.identity);
}
```

**Funcionalitats**:
- Genera obstacles a intervals regulars (`spawnRate`)
- Varia l'alçada aleatòriament dins d'un rang
- Instancia el prefab dels obstacles

#### 4. **Obstacle.cs**
Controla el comportament individual dels obstacles:

**Funcionalitats**:
- Mou els obstacles cap a l'esquerra
- S'autodestrueix quan surt de la pantalla
- Optimitza el rendiment eliminant objectes innecessaris

#### 5. **MenuManager.cs**
Gestiona la interfície d'usuari:

**Funcionalitats**:
- Mostra/amaga el menú de Game Over
- Reprodueix efectes de so
- Gestiona la transició entre estats del joc

### Fluxe del Joc

```
Inici del Joc
    ↓
Ocell en repòs (esperant input)
    ↓
Input del jugador (Espai/Click)
    ↓
Aplicar força de salt
    ↓
Generar obstacles (cada X segons)
    ↓
┌─────────────────────────────┐
│ Actualitzar cada frame:     │
│ - Física de l'ocell        │
│ - Moviment dels obstacles  │
│ - Rotació de l'ocell       │
│ - Comprovar col·lisions    │
│ - Comprovar punts          │
└─────────────────────────────┘
    ↓
Detecció de col·lisió?
    ├─ No → Continuar joc
    └─ Sí → Game Over
            ↓
        Mostrar menú
            ↓
        Reiniciar (R)
```

### Física i Moviment

El joc utilitza el sistema de física 2D d'Unity:

- **Gravetat**: Constant que fa caure l'ocell
- **Força de salt**: Impulse aplicat verticalment quan es prem
- **Rigidbody2D**: Component que gestiona la física de l'ocell
- **Collider2D**: Components per a detecció de col·lisions
- **Trigger2D**: Zones invisibles per detectar punts

## 🎨 Assets Utilitzats

### Sprites
- **Ocell**: 4 frames d'animació de vol + 2 frames de mort
- **Tubs**: Sprite reutilitzable per als obstacles
- **Fons**: Background estàtic

### Sons
- **Punt**: So reproduït en guanyar puntuació
- **Game Over**: So de mort/col·lisió
- **Música de fons**: Loop musical (opcional)

### Fonts
- **SpongeBoy Regular**: Font personalitzada per a la UI

## 🚀 Possibles Millores Futures

### Funcionalitats
- [ ] Sistema de puntuació màxima (High Score) amb PlayerPrefs
- [ ] Diferents nivells de dificultat
- [ ] Power-ups (escut, slow motion, doble punt)
- [ ] Mode dia/nit amb diferents backgrounds
- [ ] Diferents skins per a l'ocell
- [ ] Sistema d'assoliments

### Tècniques
- [ ] Object Pooling per als obstacles (optimització)
- [ ] Sistema de partícules en col·lisions
- [ ] Transicions suaus entre escenes
- [ ] Menú principal amb opcions
- [ ] Configuració d'àudio (volum, mutear)
- [ ] Suport per a dispositius mòbils (touch controls)

### Multijugador
- [ ] Mode competitiu local
- [ ] Taula de classificació en línia
- [ ] Compartir puntuacions a xarxes socials

## 🐛 Solució de Problemes Comuns

### L'ocell no salta
- Verifica que el component Rigidbody2D estigui assignat
- Comprova que `jumpForce` tingui un valor adequat (recomanat: 10-15)
- Assegura't que Gravity Scale del Rigidbody2D no sigui 0

### No es generen obstacles
- Verifica que el `obstaclePrefab` estigui assignat a l'Inspector
- Comprova que `spawnRate` sigui un valor raonable (3-6 segons)
- Assegura't que l'ObstacleSpawner estigui a l'escena

### La puntuació no s'actualitza
- Verifica que el GameManager tingui assignat el `scoreText`
- Comprova que els obstacles tinguin el tag "Point" als triggers
- Assegura't que el GameManager estigui a l'escena

### No hi ha so
- Verifica que els AudioClips estiguin assignats
- Comprova que l'AudioSource estigui present als GameObjects
- Revisa que el volum del joc no estigui a 0

## 📚 Recursos d'Aprenentatge

Aquest projecte és perfecte per aprendre:
- **Física 2D** en Unity
- **Sistema de col·lisions** i triggers
- **Patró Singleton** per a gestió d'estat global
- **Prefabs i instanciació** d'objectes
- **Animacions 2D** amb Animator Controller
- **TextMesh Pro** per a interfícies modernes
- **Gestió d'àudio** amb AudioSource i AudioClip
- **Game Loops** i actualitzacions per frame

### Conceptes Unity Utilitzats
- Rigidbody2D i forces físiques
- Collider2D (BoxCollider2D, CircleCollider2D)
- Trigger zones per detecció sense col·lisió
- Animator i Animation Clips
- Prefabs per a reutilització d'objectes
- Singleton pattern per a managers
- Time.time per a temporitzadors
- Random.Range per a valors aleatoris
- Instantiate i Destroy per a gestió d'objectes
