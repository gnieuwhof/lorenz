namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

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
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 29)
                throw new ArgumentException(
                    "Pin settings must have 29 elements.", nameof(pinSettings));
        }
    }
}
