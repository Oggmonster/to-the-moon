using System;
using System.Collections.Generic;

namespace to_the_moon
{

    /* fight between player and an enemy
        1. player draw 4 cards
        2. enemies intended moves - either defend, spell, attack
        3. player turn - play cards until all energy spent or end turn
        4. enemies executes intended moves
        5. Is player alive? yes - is any enemies alive? yes - go to 1. else end combat and get loot */

    public class Combat
    {
        private Player player;
        private List<Enemy> enemies;

        public Combat(Player player, List<Enemy> enemies) {
            this.player = player;
            this.enemies = enemies;
            this.player.Deck.NewCombat();
            this.enemies.ForEach(e => e.Deck.NewCombat());
        }

        public void Turn() {
            //everyone draws card
        }




        








    }
}