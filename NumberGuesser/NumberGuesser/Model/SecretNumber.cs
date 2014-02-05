using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuesser.Model
{
    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;
        public bool CanMakeGuess { get; }
        public int Count { get; }
        public int? Number { get; }
        public Outcome Outcome { get; private set; }
        public IEnumerable<int> PreviousGuesses { get; }
        public void Initialize()
        {

        }
        public Outcome MakeGuess(int guess)
        {
            return Outcome.Indefinite;
        }
        public SecretNumber()
        {

        }
    }
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }
}