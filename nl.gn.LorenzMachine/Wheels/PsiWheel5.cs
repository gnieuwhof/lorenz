namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel5 : WheelBase
    {
        public PsiWheel5(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 59)
                throw new ArgumentException(
                    "Pin settings must have 59 elements.", nameof(pinSettings));
        }
    }
}
