# Platformer_Test

Unity Version: 2022.3.37f1

We use the Character Controller instead of Rigidbody because:

- Rigidbody is physics-based and relies on force/velocity for movement
- Character Controller is not physics-based, requiring manual coding
- Offers better control through move and simplemove methods
- More predictable behavior for platformer games
- Easier to implement precise movement mechanics

velocity.y = Mathf.Sqrt(jumpHeight _ -2f _ gravity);
h = v₀t + (1/2)gt²
h = v₀²/(-2g)
v₀ = √(2gh)
