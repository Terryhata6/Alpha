using System.Collections.Generic;
using UnityEngine;

namespace AlphaSource.Characters.Skills
{
    [CreateAssetMenu(fileName = "SkillsPack", menuName = "Skills/SkillPack", order = 0)]
    public class SkillsPack : ScriptableObject
    {
        public List<BaseSkill> Skills;
    }
}