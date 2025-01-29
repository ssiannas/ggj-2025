using UnityEngine;

namespace ggj_2025
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        public void Awake()
        {
            animator = GetComponent<Animator>();
            if (animator is null)
            {
                throw new System.Exception("Animator not assigned");
            }
        }
        
        public void StartWalkUp()
        {
            animator.SetBool("IsWalkingUp", true);
        }
        
        public void StopWalkUp()
        {
            animator.SetBool("IsWalkingUp", false);
        }

        public void StartWalkDown()
        {
            animator.SetBool("IsWalkingDown", true);
        }
        
        public void StopWalkDown()
        {
            animator.SetBool("IsWalkingDown", false);
        }
        
        public void StartWalkLeft()
        {
            animator.SetBool("IsWalkingLeft", true);
        }
        
        public void StopWalkLeft()
        {
            animator.SetBool("IsWalkingLeft", false);
        }
        
        public void StartWalkRight()
        {
            animator.SetBool("IsWalkingRight", true);
        }
        
        public void StopWalkRight()
        {
            animator.SetBool("IsWalkingRight", false);
        }
        
        public void StartIdle()
        {
            animator.SetBool("IsIdle", true);
        }
        
        public void StopIdle()
        {
            animator.SetBool("IsIdle", false);
        }

    }
}