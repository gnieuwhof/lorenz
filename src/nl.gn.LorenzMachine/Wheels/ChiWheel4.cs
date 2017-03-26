namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class ChiWheel4 : WheelBase
    {
        /// <summary>
        /// Constructs A Chi 4 wheel.
        /// Note: this wheel has 26 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public ChiWheel4(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 26)
                throw new ArgumentException(
                    "Pin settings must have 26 elements.", nameof(pinSettings));
        }
    }
}
