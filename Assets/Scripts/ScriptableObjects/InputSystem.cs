using UnityEngine;

namespace ggj_2025
{
   public abstract class InputSystem : ScriptableObject
   {
      public abstract Vector2 getMovement();

      public abstract Vector2 getAim(Transform sourceTransform, Camera mainCamera);

      public abstract bool getFire();

      public abstract bool getSpecial();
   }
}