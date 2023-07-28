using Rewired;
using UnityEngine;

namespace AlphaSource.Characters.MovementStates
{
    public class MovingState : BaseEnabledState
    {

        public MovingState(MovementMediator movementMediator, Player playerInput) : base(movementMediator, playerInput)
        {
        }

        public override void Enter(MovementStateType previousState)
        {
        }
        
        public override void Exit()
        {
        }
        
        public override void ExecuteState()
        {
            _movementMediator.CalculateDirection();
            if (_movementMediator.Direction == Vector3.zero)
            {
                _movementMediator.ChangeState(MovementStateType.Idle);
            }
            if (ValidateDirection())
            {
                _movementMediator.Move();
            }
        }

        

        private bool ValidateDirection()
        {
            return true;
            /*Vector3 currentPosition = _movementMediator.transform.position;

            // Проверяем, есть ли препятствия в текущем местоположении объекта
            if (Physics.Raycast(currentPosition, -Vector3.up, out RaycastHit groundHit, Mathf.Infinity))
            {
                // Проверяем, соответствует ли поверхность условиям
                if (!groundHit.collider.gameObject.CompareTag("Surface"))
                {
                    return false;
                }
            }
            else
            {
                // Если рейкаст сверху вниз не попал на поверхность, возвращаем false
                return false;
            }

            // Создаем луч, начинающийся от предполагаемого следующего местоположения объекта и направленный вниз
            Ray ray = new Ray(currentPosition + _movementMediator.Direction, -Vector3.up);

            // Задайте максимальное расстояние рейкаста в соответствии с вашими потребностями
            float maxDistance = 1.0f;

            // Проводим рейкаст и получаем результат
            if (Physics.Raycast(ray, out RaycastHit nextPositionHit, maxDistance))
            {
                // Проверяем, соответствует ли поверхность условиям
                if (!nextPositionHit.collider.gameObject.CompareTag("Surface"))
                {
                    return false;
                }
            }
            else
            {
                // Если рейкаст не попал на поверхность, возвращаем false
                return false;
            }

            // Если пройдены все проверки, возвращаем true
            return true;
            */
        }
    }
}