using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{    
    public class Deck
    {
        private Dictionary<string, Card> active;

        private List<Card> discarded; //after active pile is empy - shuffle discarded and add to active
        
        public Deck(List<Card> startingCards) {
            active = startingCards.ToDictionary(c => c.Id, c => c);
        }

        public List<Card> Draw(int count) {
            if (count > active.Count) {
                discarded.ForEach(c => active.Add(c.Id, c));
                discarded = new List<Card>();
            }
            var cards = active.Take(count).Select(c => c.Value).ToList();
            cards.ForEach(c => active.Remove(c.Id));
            discarded.AddRange(cards.Where(c => c.IsReplayable));
            return cards;
        }

    }
}