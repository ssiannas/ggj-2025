using UnityEngine;

public abstract class InputSystem : ScriptableObject
{
   public abstract Vector2 getMovement();

   public abstract Vector2 getAim(GameObject sourceTransform);
}
