namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel1 : WheelBase
    {
        public PsiWheel1(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 43)
                throw new ArgumentException(
                    "Pin settings must have 43 elements.", nameof(pinSettings));
        }
    }
}
