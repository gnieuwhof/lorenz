namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class PsiWheel2 : WheelBase
    {
        /// <summary>
        /// Constructs A Psi 2 wheel.
        /// Note: this wheel has 47 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public PsiWheel2(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 47)
                throw new ArgumentException(
                    "Pin settings must have 47 elements.", nameof(pinSettings));
        }
    }
}
