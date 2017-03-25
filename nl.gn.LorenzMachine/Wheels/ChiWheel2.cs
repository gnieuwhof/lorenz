namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel2 : WheelBase
    {
        public ChiWheel2(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 31)
                throw new ArgumentException(
                    "Pin settings must have 31 elements.", nameof(pinSettings));
        }
    }
}
