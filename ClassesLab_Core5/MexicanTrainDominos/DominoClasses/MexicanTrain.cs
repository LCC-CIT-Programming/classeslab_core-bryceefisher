using System.Runtime.CompilerServices;

namespace DominoClasses
{
    public class MexicanTrain : Train
    {
        #region Constructors

        public MexicanTrain()
        {
        }

        public MexicanTrain(int engineValue)
        {
            this.engineValue = engineValue;
        }
        
        #endregion
        
        #region Methods

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return this.IsPlayable(d, out mustFlip);
        }

        #endregion
    }
}