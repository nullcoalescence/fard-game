using fardgame.core.Services.Interfaces;
using fardgame.models;

namespace fardgame.core.Services
{
    public class CardBuilderService : ICardBuilderService
    {
        private string[] _cardNames;

        public CardBuilderService()
        {
            _cardNames = ["Archer", "Soldier", "Paladin"];
        }


        public Card CreateRandomCard()
        {
            // pick a random name from the array
            var name = _cardNames[Random.Shared.Next(0, _cardNames.Length)];
            
            // create simple random stats for now
            var health = Random.Shared.Next(5, 21);
            var attack = Random.Shared.Next(1, 11);

            return new Card
            {
                Name = name,
                Health = health,
                Attack = attack
            };
        }
    }
}
