namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class PsiWheel5 : WheelBase
    {
        /// <summary>
        /// Constructs A Psi 5 wheel.
        /// Note: this wheel has 59 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public PsiWheel5(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 59)
                throw new ArgumentException(
                    "Pin settings must have 59 elements.", nameof(pinSettings));
        }
    }
}
