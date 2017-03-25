namespace nl.gn.LorenzMachine
{
    using System;

    public class MuWheel37 : WheelBase
    {
        public MuWheel37(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 37)
                throw new ArgumentException(
                    "Pin settings must have 37 elements.", nameof(pinSettings));
        }
    }
}
