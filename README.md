# Platformer_Test

Unity Version: 2022.3.37f1

We use the Character Controller instead of Rigidbody because:

- Rigidbody is physics-based and relies on force/velocity for movement
- Character Controller is not physics-based, requiring manual coding
- Offers better control through move and simplemove methods
- More predictable behavior for platformer games
- Easier to implement precise movement mechanics
