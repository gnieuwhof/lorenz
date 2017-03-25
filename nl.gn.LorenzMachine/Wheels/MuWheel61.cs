namespace nl.gn.LorenzMachine
{
    using System;

    public class MuWheel61 : WheelBase
    {
        public MuWheel61(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 61)
                throw new ArgumentException(
                    "Pin settings must have 61 elements.", nameof(pinSettings));
        }
    }
}
