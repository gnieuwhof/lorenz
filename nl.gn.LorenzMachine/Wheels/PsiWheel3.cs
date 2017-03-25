namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel3 : WheelBase
    {
        public PsiWheel3(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 51)
                throw new ArgumentException(
                    "Pin settings must have 51 elements.", nameof(pinSettings));
        }
    }
}
