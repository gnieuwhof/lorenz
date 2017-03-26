namespace nl.gn.LorenzMachine
{
    using nl.gn.BaudotPortable;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class WheelBay
    {
        private bool previousP5;
        private bool p5TwoBack;

        private readonly PsiWheel1 psiWheel1;
        private readonly PsiWheel2 psiWheel2;
        private readonly PsiWheel3 psiWheel3;
        private readonly PsiWheel4 psiWheel4;
        private readonly PsiWheel5 psiWheel5;

        private readonly MuWheel37 muWheel37;
        private readonly MuWheel61 muWheel61;

        private readonly ChiWheel1 chiWheel1;
        private readonly ChiWheel2 chiWheel2;
        private readonly ChiWheel3 chiWheel3;
        private readonly ChiWheel4 chiWheel4;
        private readonly ChiWheel5 chiWheel5;


        /// <summary>
        /// Creates a WheelBay given the twelve wheels.
        /// </summary>
        public WheelBay(
            PsiWheel1 psiWheel1,
            PsiWheel2 psiWheel2,
            PsiWheel3 psiWheel3,
            PsiWheel4 psiWheel4,
            PsiWheel5 psiWheel5,

            MuWheel37 muWheel37,
            MuWheel61 muWheel61,

            ChiWheel1 chiWheel1,
            ChiWheel2 chiWheel2,
            ChiWheel3 chiWheel3,
            ChiWheel4 chiWheel4,
            ChiWheel5 chiWheel5
            )
        {
            if (psiWheel1 == null)
                throw new ArgumentNullException(nameof(psiWheel1));
            if (psiWheel2 == null)
                throw new ArgumentNullException(nameof(psiWheel2));
            if (psiWheel3 == null)
                throw new ArgumentNullException(nameof(psiWheel3));
            if (psiWheel4 == null)
                throw new ArgumentNullException(nameof(psiWheel4));
            if (psiWheel5 == null)
                throw new ArgumentNullException(nameof(psiWheel5));

            if (muWheel37 == null)
                throw new ArgumentNullException(nameof(muWheel37));
            if (muWheel61 == null)
                throw new ArgumentNullException(nameof(muWheel61));

            if (chiWheel1 == null)
                throw new ArgumentNullException(nameof(chiWheel1));
            if (chiWheel2 == null)
                throw new ArgumentNullException(nameof(chiWheel2));
            if (chiWheel3 == null)
                throw new ArgumentNullException(nameof(chiWheel3));
            if (chiWheel4 == null)
                throw new ArgumentNullException(nameof(chiWheel4));
            if (chiWheel5 == null)
                throw new ArgumentNullException(nameof(chiWheel5));


            this.psiWheel1 = psiWheel1;
            this.psiWheel2 = psiWheel2;
            this.psiWheel3 = psiWheel3;
            this.psiWheel4 = psiWheel4;
            this.psiWheel5 = psiWheel5;

            this.muWheel37 = muWheel37;
            this.muWheel61 = muWheel61;

            this.chiWheel1 = chiWheel1;
            this.chiWheel2 = chiWheel2;
            this.chiWheel3 = chiWheel3;
            this.chiWheel4 = chiWheel4;
            this.chiWheel5 = chiWheel5;
        }

        /// <summary>
        /// Sets the positions of the wheels.
        /// </summary>
        public void SetWheelPositions(
            int psi1Position,
            int psi2Position,
            int psi3Position,
            int psi4Position,
            int psi5Position,
            int mu37Position,
            int mu61Position,
            int chi1Position,
            int chi2Position,
            int chi3Position,
            int chi4Position,
            int chi5Position
            )
        {
            this.psiWheel1.Position = psi1Position;
            this.psiWheel2.Position = psi2Position;
            this.psiWheel3.Position = psi3Position;
            this.psiWheel4.Position = psi4Position;
            this.psiWheel5.Position = psi5Position;

            this.muWheel37.Position = mu37Position;
            this.muWheel61.Position = mu61Position;

            this.chiWheel1.Position = chi1Position;
            this.chiWheel2.Position = chi2Position;
            this.chiWheel3.Position = chi3Position;
            this.chiWheel4.Position = chi4Position;
            this.chiWheel5.Position = chi5Position;
        }

        /// <summary>
        /// Encipher the given input using the current wheel settings.
        /// </summary>
        /// <param name="input">The input to encipher.</param>
        /// <param name="encipher">
        /// Whether we are enciphering or deciphering
        /// (only used for SZ42A/B).
        /// </param>
        /// <returns>Returns the converted input.</returns>
        public IEnumerable<VBit> Process(IEnumerable<VBit> input, bool encipher)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            this.p5TwoBack = false;
            this.previousP5 = false;

            foreach (VBit vbit in input)
            {
                byte chiKey = this.GetCurrentChiKey();
                byte psiKey = this.GetCurrentPsiKey();

                byte C = vbit.Value;
                byte K = (byte)(chiKey ^ psiKey);
                byte Z = (byte)(K ^ C);

                yield return new VBit(Z);

                this.AdvanceWheelPositions();

                // Keeping track of 5th bit of the input is
                // only needed for SZ42A/B.
                this.p5TwoBack = this.previousP5;
                if (encipher)
                {
                    this.previousP5 = ((vbit.Value % 2) == 1);
                }
                else
                {
                    this.previousP5 = ((Z % 2) == 1);
                }
            }
        }

        private byte GetCurrentChiKey()
        {
            byte result = BoolsToByte(
                this.chiWheel1.IsActive,
                this.chiWheel2.IsActive,
                this.chiWheel3.IsActive,
                this.chiWheel4.IsActive,
                this.chiWheel5.IsActive
                );

            return result;
        }

        private byte GetCurrentPsiKey()
        {
            byte result = BoolsToByte(
                this.psiWheel1.IsActive,
                this.psiWheel2.IsActive,
                this.psiWheel3.IsActive,
                this.psiWheel4.IsActive,
                this.psiWheel5.IsActive
                );

            return result;
        }

        /// <summary>
        /// Creates a byte given max 8 booleans.
        /// </summary>
        private byte BoolsToByte(params bool[] bools)
        {
            if (bools == null)
                throw new ArgumentNullException(nameof(bools));
            if (bools.Length > 8)
                throw new ArgumentException(
                    "The array cannot contain more than 8 elements", nameof(bools));

            byte result = 0;
            foreach (bool b in bools)
            {
                // Move everything in result one position.
                result <<= 1;

                if (b)
                {
                    // Set last.
                    result |= 1;
                }
            }
            return result;
        }

        private void AdvanceWheelPositions()
        {
            bool previousChi2 = this.chiWheel2.Previous;
            bool previousPsi1 = this.psiWheel1.Previous;

            // These wheels always move.
            this.chiWheel1.Position++;
            this.chiWheel2.Position++;
            this.chiWheel3.Position++;
            this.chiWheel4.Position++;
            this.chiWheel5.Position++;

            bool limitation = GetLimitation(
                previousChi2, previousPsi1, this.p5TwoBack);

            // Remove the next line for SZ42A/B motor behaviour.
            // (but then our cool example text does not
            // encipher into a readable code.
            // @see
            // https://infogalactic.com/info/Cryptanalysis_of_the_Lorenz_cipher#British_Tunny)
            limitation = true;

            if (this.muWheel37.IsActive || !limitation)
            {
                this.psiWheel1.Position++;
                this.psiWheel2.Position++;
                this.psiWheel3.Position++;
                this.psiWheel4.Position++;
                this.psiWheel5.Position++;
            }

            if (this.muWheel61.IsActive)
            {
                this.muWheel37.Position++;
            }

            this.muWheel61.Position++;
        }

        /// <summary>
        /// Gets the motor limitations (used by SZ42A/B only)
        /// </summary>
        private static bool GetLimitation(bool previousChi2, bool previousPsi1, bool p5TwoBack)
        {
            if (previousChi2)
            {
                // Chi2 lim
                return true;
            }
            if (previousChi2 ^ previousPsi1)
            {
                // Psi2 lim
                return true;
            }
            if (p5TwoBack ^ previousChi2)
            {
                // P5 lim
                return true;
            }
            if (previousChi2 ^ previousPsi1 ^ p5TwoBack)
            {
                // Psi1 P5 lim
                return true;
            }

            return false;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.psiWheel1 != null);
            Contract.Invariant(this.psiWheel2 != null);
            Contract.Invariant(this.psiWheel3 != null);
            Contract.Invariant(this.psiWheel4 != null);
            Contract.Invariant(this.psiWheel5 != null);

            Contract.Invariant(this.muWheel37 != null);
            Contract.Invariant(this.muWheel61 != null);

            Contract.Invariant(this.chiWheel1 != null);
            Contract.Invariant(this.chiWheel2 != null);
            Contract.Invariant(this.chiWheel3 != null);
            Contract.Invariant(this.chiWheel4 != null);
            Contract.Invariant(this.chiWheel5 != null);
        }
    }
}
