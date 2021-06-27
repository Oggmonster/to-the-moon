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
        private int maxCardLimit = 25;
        private int minCardLimit = 10;
        
        public Deck(List<Card> startingCards) {            
            fullDeck = startingCards.ToDictionary(c => c.Id, c => c);
            discarded = new List<Card>();
        }

        private List<Card> Shuffle(List<Card> cards) {
            var r = new Random();
            return cards.OrderBy(x => r.Next()).ToList();
        }

        public void NewCombat() {
            active = Shuffle(fullDeck.Select(c => c.Value).ToList()).ToDictionary(c => c.Id, c => c);
            discarded = new List<Card>();
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
            if (fullDeck.Count >= maxCardLimit) {
                throw new Exception("Sorry your deck is full. Please remove a card first");
            }
            fullDeck.Add(card.Id, card);
        }

        public void RemoveCard(string id) {
            if (fullDeck.Count <= minCardLimit) {
                throw new Exception("Sorry you can't remove any cards. You have reached minimum amount");
            }
            fullDeck.Remove(id);
        }

        public List<Card> GetAllCards() {
            return fullDeck.Select(d => d.Value).ToList();
        }

        public void IncreaseMaxCardLimit(int num) {
            maxCardLimit += num;
        }

    }
}