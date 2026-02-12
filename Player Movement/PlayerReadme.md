# Basic Player Script.

Player  
│   ├─ Transform  
│   ├─ PlayerMovement.cs  
│   └─ CharacterController  
├─ Unity > 3D Object > Capsule  
│   ├─ Transform  
│   ├─ MeshFilter  
│   ├─ Mesh Renderer  
│   ├─ CapsuleCollider  
└─ Player Camera  
      ├─ Transform  
      ├─ Camera  
      ├─ AudioListener  
      └─ UniversalAdditionalCamera  


## Player Script - step by step.
A few variables get created at the beginning of the script for easier configuration and organization.  
At the first execution of update ("Start()" function), the cursor is hidden and the variable isPaused is set to false.  
On every frame, if isPaused is equal to false, the playerMovementInput and playerMouseInput vectors (3 and 2 respectively) are set to its inputs using the old Input System. Short after, two functions are called: MovePlayer() and MoveCamera().  
MovePlayer transforms the input to a proper vector to make transform able to use it. If the controller is touching ground, the controller is forced down to avoid flying. Next, if the player holds space, the controller adds the jump force to the velocity.y variable, making the game object jump. If the controller isn't grounded, the physics get applied properly. The game object moves to the player input.  
MoveCamera uses math to clamp data and apply the player mouse position fixed values to the camera's rotation.  