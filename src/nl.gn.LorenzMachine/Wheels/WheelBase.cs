﻿namespace nl.gn.LorenzMachine
{
    using System;
    using System.Diagnostics.Contracts;

    public class WheelBase
    {
        private readonly bool[] pinSettings;
        private int position;

        /// <summary>
        /// Constructs a WheelBase.
        /// </summary>
        /// <param name="pinSettings">Pin settings of the wheel.</param>
        public WheelBase(bool[] pinSettings)
        {
            if (pinSettings == null)
                throw new ArgumentNullException(nameof(pinSettings));
            if (pinSettings.Length == 0)
                throw new ArgumentException(
                    "The array must at least contain one element.", nameof(pinSettings));

            this.pinSettings = pinSettings;
        }


        /// <summary>
        /// Gets or sets the positions of the wheel.
        /// Protects agains overflow so can
        /// be ++ ed without checking.
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value < 0)
                    new ArgumentException("Value cannot be lower than zero.", nameof(value));

                //Contract.Assume(this.pinSettings.Length > 0);

                int temp = (value % this.pinSettings.Length);

                this.position = temp;
            }
        }

        /// <summary>
        /// Gets whether the current pin is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                Contract.Requires(this.Position > 0);

                //Contract.Assume(position < this.pinSettings.Length);

                return this.pinSettings[this.Position];
            }
        }

        /// <summary>
        /// Gets whether the previous position is active
        /// (used by SZ42A/B only).
        /// </summary>
        public bool Previous
        {
            get
            {
                int position = (this.Position - 1);

                if (position < 0)
                {
                    position += this.pinSettings.Length;
                }

                //Contract.Assume(position >= 0);
                //Contract.Assume(position < this.pinSettings.Length);

                return this.pinSettings[position];
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.pinSettings != null);
        }
    }
}
