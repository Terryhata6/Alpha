using UnityEngine;
using UnityEngine.Serialization;

namespace AlphaSource.Characters.Skills
{
    public class BaseSkill : ScriptableObject
    {
        public string SkillID = "";
        public Sprite SkillIcon;
        public virtual void SetupSkill(CharacterMediator mediator)
        {
            
        }

        public virtual void ExecuteSkill(CharacterMediator mediator)
        {
            
        }

    }
}