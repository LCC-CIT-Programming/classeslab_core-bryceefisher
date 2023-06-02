using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DominoClasses
{
    // Train is an abstract class, so it can't be instantiated
    public abstract class Train : IEnumerable<Domino>
    {
        // Instance variables
        protected List<Domino> dominoes = new List<Domino>();
        protected int engineValue;

        #region Constructors

        // Empty constructor
        protected Train()
        {
        }

        // Overloaded constructor requiring an engine value
        protected Train(int engineValue)
        {
            this.engineValue = engineValue;
        }

        #endregion

        #region Properties

        // Properties
        //return the number of dominoes in the train
        public int Count => dominoes.Count;

        //return or set the engine value of the train
        public int EngineValue
        {
            get => engineValue;

            set => engineValue = value;
        }

        //return true if the train is empty, false otherwise
        public bool IsEmpty => (dominoes.Count == 0);

        //return the last domino in the train
        public Domino LastDomino => dominoes.Count > 0 ? dominoes[^1] : null;

        //return the playable value of the train
        public int PlayableValue => dominoes.Count > 0 ? this.LastDomino.Side2 : engineValue;

        //return the domino at the specified index
        public Domino this[int index] => dominoes.Count > 0
            ? dominoes[index]
            : throw new IndexOutOfRangeException("The dominoes collection is empty.");

        #endregion

        #region Methods

        //Add a domino to the train
        public void Add(Domino d)
        {
            dominoes.Add(d);
        }

        //Determine if a domino is playable on the train and whether it must be flipped
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == PlayableValue )
            {
                mustFlip = false;
                return true;
            }
            else if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            }

            mustFlip = false;
            return false;
            
        }

        //Play a domino on the train
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;

            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip) d.Flip();
                Add(d);
            }
            else
            {
                throw new Exception("Domino " + d.ToString() + " is not playable on train.");
            }
        }

        //Determine if a domino is playable on the train abstract method
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        //Ienumerable implementation
        public IEnumerator<Domino> GetEnumerator()
        {
            return dominoes.GetEnumerator();
        }

        //Override ToString method
        public override string ToString()
        {
            return String.Format("Count: {0}, EngineValue: {1}, IsEmpty: {2}, LastDomino: {3}, PlayableValue: {4}",
                Count, EngineValue, IsEmpty, LastDomino, PlayableValue);
        }

        //Ienumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)dominoes).GetEnumerator();
        }

        #endregion
    }
}