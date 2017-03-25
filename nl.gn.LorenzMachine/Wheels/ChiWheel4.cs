namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel4 : WheelBase
    {
        public ChiWheel4(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 26)
                throw new ArgumentException(
                    "Pin settings must have 26 elements.", nameof(pinSettings));
        }
    }
}
