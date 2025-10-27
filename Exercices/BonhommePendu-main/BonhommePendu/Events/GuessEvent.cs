using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            if (this.Events == null)
                this.Events = new List<GameEvent>();
            GuessedLetterEvent guess = new GuessedLetterEvent(gameData, letter);
            this.Events.Add(guess);
            
        }
    }
}
