namespace nl.gn.LorenzMachine
{
    using System;

    public class PsiWheel3 : WheelBase
    {
        /// <summary>
        /// Constructs A Psi 3 wheel.
        /// Note: this wheel has 51 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public PsiWheel3(bool[] pinSettings)
            : base(pinSettings)
        {
            // base does the null check.

            if (pinSettings.Length != 51)
                throw new ArgumentException(
                    "Pin settings must have 51 elements.", nameof(pinSettings));
        }
    }
}
