namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class ChiWheel5 : WheelBase
    {
        /// <summary>
        /// Constructs A Chi 5 wheel.
        /// Note: this wheel has 23 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public ChiWheel5(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 23)
                throw new ArgumentException(
                    "Pin settings must have 23 elements.", nameof(pinSettings));
        }
    }
}
