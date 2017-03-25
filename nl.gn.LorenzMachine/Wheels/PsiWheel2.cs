namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel2 : WheelBase
    {
        public PsiWheel2(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 47)
                throw new ArgumentException(
                    "Pin settings must have 47 elements.", nameof(pinSettings));
        }
    }
}
