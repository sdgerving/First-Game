using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster:LivingCreature 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public string creatureImage { get; set; }
        public List<LootItem> LootTable { get; set; }
       // public List<LootItem> LootTable { get; set; }

        public Monster(int id, string name, int maximumDamage, int mininumDamage, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints,string creatureimage)
            : base(currentHitPoints, maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            MinimumDamage = mininumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            creatureImage = creatureimage;
            LootTable = new List<LootItem>();
        }
    }
}
