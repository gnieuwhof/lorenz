namespace nl.gn.LorenzMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class WheelFactory
    {
        // Psi/ψ (S)        Mu (M)  Chi/X (K)
        // 43 47 51 53 59   37 61   41 31 29 26 23

        public static PsiWheel1 CreatePsiWheel1(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new PsiWheel1(boolPinSettings);
        }

        public static PsiWheel2 CreatePsiWheel2(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new PsiWheel2(boolPinSettings);
        }

        public static PsiWheel3 CreatePsiWheel3(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new PsiWheel3(boolPinSettings);
        }

        public static PsiWheel4 CreatePsiWheel4(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new PsiWheel4(boolPinSettings);
        }

        public static PsiWheel5 CreatePsiWheel5(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new PsiWheel5(boolPinSettings);
        }

        public static MuWheel37 CreateMuWheel37(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new MuWheel37(boolPinSettings);
        }

        public static MuWheel61 CreateMuWheel61(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new MuWheel61(boolPinSettings);
        }

        public static ChiWheel1 CreateChiWheel1(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new ChiWheel1(boolPinSettings);
        }

        public static ChiWheel2 CreateChiWheel2(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new ChiWheel2(boolPinSettings);
        }

        public static ChiWheel3 CreateChiWheel3(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new ChiWheel3(boolPinSettings);
        }

        public static ChiWheel4 CreateChiWheel4(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new ChiWheel4(boolPinSettings);
        }

        public static ChiWheel5 CreateChiWheel5(string pinSettings)
        {
            bool[] boolPinSettings =
                ToBoolEnumerable(pinSettings)
                .ToArray();

            return new ChiWheel5(boolPinSettings);
        }

        /// <summary>
        /// Converts a string into an IEnumerable of boolean.
        /// Given the passed in string the method will
        /// return a false (lower/inactive) for every '0' & '.' char
        /// or true (raised/active) otherwise.
        /// </summary>
        private static IEnumerable<bool> ToBoolEnumerable(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            foreach (char c in str)
            {
                yield return ((c != '0') && (c != '.'));
            }
        }
    }
}
