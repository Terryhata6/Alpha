using UnityEngine;

namespace AlphaSource.Characters
{
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator
    {
        private readonly int _movementDirectionX = Animator.StringToHash("movementDirectionX");
        private readonly int _movementDirectionZ = Animator.StringToHash("movementDirectionZ");
        private readonly int _movementSpeed = Animator.StringToHash("movementSpeed");

        private Animator _animator;

        public void Init()
        {
            _animator = GetComponent<Animator>();
        }


        public void Move(Vector3 direction, float speed)
        {
            _animator.SetFloat(_movementSpeed, speed);
            _animator.SetFloat(_movementDirectionX, direction.x);
            _animator.SetFloat(_movementDirectionZ, direction.z);
        }
    }

    public interface ICharacterAnimator
    {
        void Init();
        void Move(Vector3 direction, float speed);
    }
}