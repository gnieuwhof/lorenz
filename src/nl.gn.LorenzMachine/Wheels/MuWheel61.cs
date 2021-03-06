﻿namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class MuWheel61 : WheelBase
    {
        /// <summary>
        /// Constructs A Mu 61 wheel.
        /// Note: this wheel has 61 pins.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public MuWheel61(bool[] pinSettings)
            : base(pinSettings)
        {
            // Base throws if null.
            Contract.Requires(pinSettings != null);

            if (pinSettings.Length != 61)
                throw new ArgumentException(
                    "Pin settings must have 61 elements.", nameof(pinSettings));
        }
    }
}
