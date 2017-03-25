namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel5 : WheelBase
    {
        public ChiWheel5(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 23)
                throw new ArgumentException(
                    "Pin settings must have 23 elements.", nameof(pinSettings));
        }
    }
}
