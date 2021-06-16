using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{    
    public class Deck
    {
        private Dictionary<string, Card> fullDeck;
        private Dictionary<string, Card> active;
        private List<Card> discarded; //after active pile is empy - shuffle discarded and add to active
        
        public Deck(List<Card> startingCards) {
            fullDeck = startingCards.ToDictionary(c => c.Id, c => c);
        }

        private List<Card> Shuffle(List<Card> cards) {
            var r = new Random();
            return cards.OrderBy(x => r.Next()).ToList();
        }

        public void NewCombat() {
            active = Shuffle(fullDeck.Select(c => c.Value).ToList()).ToDictionary(c => c.Id, c => c);
        }

        public List<Card> Draw(int count) {
            if (count > active.Count) {
                var shuffled = Shuffle(discarded);
                shuffled.ForEach(c => active.Add(c.Id, c));
                discarded = new List<Card>();
            }
            var result = active.Take(count).Select(c => c.Value).ToList();
            result.ForEach(c => active.Remove(c.Id));
            discarded.AddRange(result.Where(c => c.IsReplayable));
            return result;
        }

        public void AddCard(Card card) {
            fullDeck.Add(card.Id, card);
        }

        public void RemoveCard(string id) {
            fullDeck.Remove(id);
        }

    }
}