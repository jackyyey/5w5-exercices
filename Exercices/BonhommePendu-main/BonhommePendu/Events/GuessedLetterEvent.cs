using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer peu importe si la lettre est dans le mot ou pas!
    public class GuessedLetterEvent : GameEvent
    {
        public override string EventType { get { return "GuessedLetter"; } }
        public char Letter { get; set; }
        // TODO: Compléter
        public GuessedLetterEvent(GameData gameData, char letter)
        {
            Events = [];
            bool hasLetter = false;
            Letter = letter;
            gameData.GuessedLetters.Add(letter);
            for (int i = 0; i < gameData.Word.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    this.Events.Add(new RevealLetterEvent(gameData, letter, i));
                    hasLetter = true;
                }
            }
            if (!hasLetter)
            {
                this.Events.Add(new WrongGuessEvent(gameData));
            }
        }
    }
}
