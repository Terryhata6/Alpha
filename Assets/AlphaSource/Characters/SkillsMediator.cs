using System.Collections.Generic;
using System.Linq;
using AlphaSource.Characters.Skills;
using UnityEngine;

namespace AlphaSource.Characters
{
    public class SkillsMediator : MonoBehaviour
    {
        public List<BaseSkill> Skill;

        public void Init(List<BaseSkill> starterPack)
        {
            Skill.AddRange(starterPack);
        }
    }
}