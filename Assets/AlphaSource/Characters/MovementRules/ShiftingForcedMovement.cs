using System;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace AlphaSource.Characters.MovementRules
{
    public class ShiftingForcedMovement : BaseForcedMovementRule
    {
        public float ShiftDistance = 15f;
        private Vector3 Direction = Vector3.Zero;
        public float CompletedDistance = 0;
        public float ShiftSpeed = 30f;
        public float ShiftTime = 0.5f;
        
        
        public override void Setup(Dictionary<string, float> movementData)
        {
            CompletedDistance = 0;
            movementData.TryGetValue("DirectionX", out Direction.X);
            movementData.TryGetValue("DirectionY", out Direction.Y);
            movementData.TryGetValue("DirectionZ", out Direction.Z);
            
            
            movementData.TryGetValue("ShiftDistance", out ShiftDistance);
            movementData.TryGetValue("ShiftTime", out ShiftTime);

            ShiftTime = Mathf.Clamp(ShiftTime, 0.1f, 99f);
            ShiftSpeed = ShiftDistance / ShiftTime;
        }

        public override void ExecuteMovementRule(MovementMediator onEndMovementCallback, Action OnEndMovementCallback)
        {
            
        }
        
        
    }
}