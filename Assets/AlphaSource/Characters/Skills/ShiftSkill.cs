using AlphaSource.Characters.MovementRules;
using UnityEngine;

namespace AlphaSource.Characters.Skills
{
    [CreateAssetMenu(fileName = "ShiftSkill", menuName = "Skills/SkillConfig", order = 0)]
    public class ShiftSkill : BaseSkill
    {
        public ShiftingForcedMovement ForcedMovement = new ShiftingForcedMovement();

        public override void SetupSkill(CharacterMediator mediator)
        {
            
        }

        public override void ExecuteSkill(CharacterMediator mediator)
        {
            
        }
    }
}