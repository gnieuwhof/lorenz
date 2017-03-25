﻿namespace nl.gn.LorenzMachine
{
    using System;

    public class WheelBase
    {
        private bool[] pinSettings;
        private int position;

        public WheelBase(bool[] pinSettings)
        {
            if (pinSettings == null)
                throw new ArgumentNullException(nameof(pinSettings));
            if (pinSettings.Length < 1)
                throw new ArgumentException(
                    "The array must at leas contain one element.", nameof(pinSettings));

            this.pinSettings = pinSettings;
        }


        public virtual int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value < 0)
                    new ArgumentException("Value cannot be lower than zero", nameof(value));

                int temp = (value % this.pinSettings.Length);

                this.position = temp;
            }
        }

        public bool IsActive
        {
            get
            {
                return this.pinSettings[this.Position];
            }
        }

        public bool Previous
        {
            get
            {
                int position = this.Position - 1;

                if (position < 0)
                {
                    position += this.pinSettings.Length;
                }

                return this.pinSettings[position];
            }
        }
    }
}
