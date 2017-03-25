namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel1 : WheelBase
    {
        public ChiWheel1(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 41)
                throw new ArgumentException(
                    "Pin settings must have 41 elements.", nameof(pinSettings));
        }
    }
}
