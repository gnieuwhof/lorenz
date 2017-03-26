namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class PsiWheel1 : WheelBase
    {
        /// <summary>
        /// Constructs A Psi 1 wheel.
        /// Note: this wheel has 43 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public PsiWheel1(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 43)
                throw new ArgumentException(
                    "Pin settings must have 43 elements.", nameof(pinSettings));
        }
    }
}
