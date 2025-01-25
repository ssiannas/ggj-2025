using UnityEngine;

namespace ggj_2025
{
   public abstract class InputSystem : ScriptableObject
   {
      /**
       * Returns a vector representing the movement input.
       */
      public abstract Vector2 GetMovement();

      /**
       * Returns a vector representing the aim input.
       *
       * @param sourceTransform The transform of the object that is aiming.
       * @param mainCamera The main camera in the scene.
       */
      public abstract Vector2 GetAim(Transform sourceTransform, Camera mainCamera);
   
      /**
       * Returns true if the fire button is pressed.
       */
      public abstract bool GetFire();

      /**
       * Returns true if the special button is pressed.
       */
      public abstract bool GetSpecial();
   }
}