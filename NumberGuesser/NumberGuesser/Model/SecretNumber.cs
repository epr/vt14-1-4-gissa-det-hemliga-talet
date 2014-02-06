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
        public bool CanMakeGuess
        {
            get
            {
                return _previousGuesses.Count < MaxNumberOfGuesses;
            }
        }
        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }
        public Outcome Outcome { get; private set; }
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }
        public void Initialize()
        {
            _number = new Random().Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }
        public Outcome MakeGuess(int guess)
        {
            if (Count == MaxNumberOfGuesses)
            {
                return Outcome.NoMoreGuesses;
            }
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (PreviousGuesses.Contains(guess))
            {
                return Outcome.PreviousGuess;
            }
            _previousGuesses.Add(guess);
            if (guess < Number)
            {
                return Outcome.Low;
            }
            else if (guess > Number)
            {
                return Outcome.High;
            }
            else
            {
                return Outcome.Correct;
            }
        }
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }
}