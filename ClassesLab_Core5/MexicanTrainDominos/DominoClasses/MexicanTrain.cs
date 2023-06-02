using System.Runtime.CompilerServices;

namespace DominoClasses
{
    //MexicanTrain inherits from Train
    public class MexicanTrain : Train
    {
        #region Constructors

        //Empty constructor
        public MexicanTrain()
        {
        }
    
        //Overloaded constructor requiring an engine value
        public MexicanTrain(int engineValue)
        {
            this.engineValue = engineValue;
        }
        
        #endregion
        
        #region Methods

        //Overridden IsPlayable method required by abstract Train class
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return this.IsPlayable(d, out mustFlip);
        }

        #endregion
    }
}