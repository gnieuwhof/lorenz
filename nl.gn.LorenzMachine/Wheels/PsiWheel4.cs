namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel4 : WheelBase
    {
        /// <summary>
        /// Constructs A Psi 4 wheel.
        /// Note: this wheel has 53 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public PsiWheel4(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 53)
                throw new ArgumentException(
                    "Pin settings must have 53 elements.", nameof(pinSettings));
        }
    }
}
