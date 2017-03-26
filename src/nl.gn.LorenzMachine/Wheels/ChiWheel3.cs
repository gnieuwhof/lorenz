namespace nl.gn.LorenzMachine
{
    using System;

    public class ChiWheel3 : WheelBase
    {
        /// <summary>
        /// Constructs A Chi 3 wheel.
        /// Note: this wheel has 29 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public ChiWheel3(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 29)
                throw new ArgumentException(
                    "Pin settings must have 29 elements.", nameof(pinSettings));
        }
    }
}
