namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel1 : WheelBase
    {
        /// <summary>
        /// Constructs A Chi 1 wheel.
        /// Note: this wheel has 41 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
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
