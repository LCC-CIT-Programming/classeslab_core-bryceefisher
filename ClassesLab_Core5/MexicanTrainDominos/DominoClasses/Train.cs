using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DominoClasses
{
    public abstract class Train
    {
        // Instance variables
        protected List<Domino> dominoes = new List<Domino>();
        protected int engineValue;

        #region Constructors

        protected Train()
        {
        }

        protected Train(int engineValue)
        {
            this.engineValue = engineValue;
        }

        #endregion

        #region Properties

        public int Count => dominoes.Count;

        public int EngineValue
        {
            get => engineValue;

            set => engineValue = value;
        }

        public bool IsEmpty => (dominoes.Count == 0);

        public Domino LastDomino => dominoes.Count > 0 ? dominoes[dominoes.Count - 1] : null;

        public int PlayableValue => dominoes.Count > 0 ? this.LastDomino.Side2 : engineValue;

        public Domino this[int index] => dominoes.Count > 0
            ? dominoes[index]
            : throw new IndexOutOfRangeException("The dominoes collection is empty.");

        #endregion

        #region Methods

        public void Add(Domino d)
        {
            dominoes.Add(d);
        }

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

        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        public override string ToString()
        {
            return String.Format("Count: {0}, EngineValue: {1}, IsEmpty: {2}, LastDomino: {3}, PlayableValue: {4}",
                Count, EngineValue, IsEmpty, LastDomino, PlayableValue);
        }





        #endregion
    }
}