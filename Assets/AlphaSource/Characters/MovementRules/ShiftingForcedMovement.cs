using System;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace AlphaSource.Characters.MovementRules
{
    public class ShiftingForcedMovement : BaseForcedMovementRule
    {
        public float ShiftDistance = 15f;
        public float CompletedDistance = 0;
        public float ShiftSpeed = 30f;
        public float ShiftTime = 0.5f;

        private Vector3 _direction = Vector3.Zero;

        public override void Setup(Dictionary<string, float> movementData)
        {
            CompletedDistance = 0;
            movementData.TryGetValue("DirectionX", out _direction.X);
            movementData.TryGetValue("DirectionY", out _direction.Y);
            movementData.TryGetValue("DirectionZ", out _direction.Z);
            
            
            movementData.TryGetValue("ShiftDistance", out ShiftDistance);
            movementData.TryGetValue("ShiftTime", out ShiftTime);

            ShiftTime = Mathf.Clamp(ShiftTime, 0.1f, 99f);
            ShiftSpeed = ShiftDistance / ShiftTime;
        }

        public override void ExecuteMovementRule(MovementMediator TargetMediator, Action OnEndMovementCallback)
        {
            
        }
        
        
    }
}