namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class MuWheel37 : WheelBase
    {
        /// <summary>
        /// Constructs A Mu 37 wheel.
        /// Note: this wheel has 37 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public MuWheel37(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 37)
                throw new ArgumentException(
                    "Pin settings must have 37 elements.", nameof(pinSettings));
        }
    }
}
