using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Character
    {
        private Random rnd = new Random();        
        public string Name { get; private set; }
        public int Energy { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public Deck Deck { get; private set; }
        public Role Role { get; set; }
        public CombatState CombatState { get; set; }        
        public List<Artifact> Artifacts { get; set; }
        public List<Monster> Minions { get; set; }
        public virtual void SetHealth(int constitution)
        {
            var hp = (constitution * 2) + 5;
            Health = hp;
            MaxHealth = hp;
        }
        public Character(string name, Role role, Deck deck)
        {            
            Name = name;
            Role = role;
            Deck = deck;
            Shield = 0;
            CombatState = new CombatState(Role);
            SetHealth(role.Constitution);
            Artifacts = new List<Artifact>();
            Minions = new List<Monster>();
        }

        public int CalculateDamage(int damage, int boost)
        {
            var dmgAmount = rnd.Next(boost, boost + damage);
            return dmgAmount;
        }

        public int Defend(int block, int boost)
        {
            var blockAmount = rnd.Next(block, boost + block);
            Shield += blockAmount;
            return blockAmount;
        }

        public int Heal(int heal)
        {
            var healAmount = rnd.Next(heal, CombatState.Constitution + heal);
            Health = Math.Min(Health + healAmount, MaxHealth);
            return healAmount;
        }

        public int IncomingAttack(int damage)
        {
            var takenDamage = damage;
            if (Shield > 0)
            {
                takenDamage = damage >= Shield ? damage - Shield : 0;
                Shield = Math.Max(Shield - damage, 0);
            }
            Health = Math.Max(Health - takenDamage, 0);
            return takenDamage;
        }

        private void ApplyArtifacts() {
            Artifacts.ForEach(a => a.Execute(CombatState));
        }

        public virtual void NewCombat()
        {
            Shield = 0;
            Deck.NewCombat();
            CombatState = new CombatState(Role);
            Minions = new List<Monster>();
            ApplyArtifacts();
        }

        public void AddMinion(Monster monster) {
            monster.NewCombat();
            Minions.Add(monster);
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void NewTurn()
        {
            Energy = CombatState.MaxEnergy;
        }

        public void EndTurn()
        {
            Energy = 0;
        }

        public override string ToString()
        {
            if (Health == 0)
            {
                return $"{Name} is dead";
            }
            return $"{Name} - hp: {Health}/{MaxHealth} def: {Shield} {Role.RoleType.ToString()} ({CombatState.ToString()})";
        }

    }
}