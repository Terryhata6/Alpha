using System;
using System.Collections.Generic;

namespace AlphaSource.Characters.MovementRules
{
    public abstract class BaseForcedMovementRule
    {
        public abstract void Setup(Dictionary<string,float> movementData);
        public abstract void ExecuteMovementRule(MovementMediator onEndMovementCallback, Action OnEndMovementCallback);
    }
}