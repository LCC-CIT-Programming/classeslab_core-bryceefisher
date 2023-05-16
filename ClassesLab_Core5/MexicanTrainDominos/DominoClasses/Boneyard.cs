using System;
using System.Collections;
using System.Collections.Generic;

namespace DominoClasses
{
    public class Boneyard : IEnumerable<Domino>
    {
        private List<Domino> _listOfDominoes = new List<Domino>();
        
        #region Constructors
        
        //Constructor, takes max num od dots as a param
        public Boneyard(int maxDots)
        {
            //from 0 to the max num of dots
            for (int i = 0; i <= maxDots; i++)
            {
                // from i to max num of dots
                for (int j = i; j <= maxDots; j++)
                {
                    //add a Domino object with i and j passed into the constructor
                    _listOfDominoes.Add(new Domino(i, j));  
                }
            }
        }
        
        #endregion

        #region Properties
        
        //Preoperty that returns the num of dominoes
        public int DominoesRemaining => _listOfDominoes.Count;
        
        //Property that lets the user retrieve or change a dominoes value by index
        public Domino this[int i]
        {
            //return donimo at index i
            get => _listOfDominoes[i];
            //set domino at index i to designated values
            set => _listOfDominoes[i] = value;
        }
        
        #endregion

        #region Methods

        //Method to return bool if boneyard is empty or not
        public bool IsEmpty()
        {
            return _listOfDominoes.Count == 0;
        }
        //Methods that removes/returns a domino from index 0
        public Domino Draw()
        {
            if (!IsEmpty())
            {
                Domino d = _listOfDominoes[0];

                _listOfDominoes.Remove(d);

                return d;
            }

            return null;
        }

        public void Shuffle()
        {
            // create a random object
            Random gen = new Random();
            //from 0 to 1 less that the num of dominos
            for (int i = 0; i < _listOfDominoes.Count; i++)
            {
                //access a random index
                int rnd = gen.Next(0, _listOfDominoes.Count);
                //swap the values of domino at index i with the domino at the random index
                (_listOfDominoes[rnd], _listOfDominoes[i]) = (_listOfDominoes[i], _listOfDominoes[rnd]);
            }
        }

        
        public override string ToString()
        {
            //create a string variable
            string output = "";
            // go through every domino
            foreach (Domino d in _listOfDominoes)
                // convert the domino to a string
                output += (d.ToString() + "\n");
            return output;
        }
        
           

        #endregion
        
        #region Interfaces   

        // impliment the IEnumerable interface to allow use of a foreach loop in testing
        public IEnumerator<Domino> GetEnumerator()
        {
            //for each Domino in the list
            foreach (Domino d in _listOfDominoes)
            {
                //use yield to allow the dominos to be returned one at a time. return domino
                yield return d;
            }
        }
        
        //create the enumerator that can iterate through a collection
        IEnumerator IEnumerable.GetEnumerator()
        {
            //return that enumerator
            return GetEnumerator();
        }

        #endregion
    }
}