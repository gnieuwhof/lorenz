namespace nl.gn.LorenzMachine
{
    using System;

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
            // base does the null check.

            if (pinSettings.Length != 59)
                throw new ArgumentException(
                    "Pin settings must have 59 elements.", nameof(pinSettings));
        }
    }
}
