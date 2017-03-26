namespace LorenzConsole
{
    using nl.gn.BaudotPortable;
    using nl.gn.LorenzMachine;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string plain = "NOW IS THE TIME FOR ALL GOOD MEN TO COME TO THE AID OF THE PARTY";

            // Lorenz uses LSB first Baudot (hence the 2nd arg).
            var baudot = Baudot.ToCode(plain, true);

            // Scramble the baudot here...
            // (generate Tunny)

            // Pin settings: https://oilulio.wordpress.com/tag/cipher/
            string p1 = "....x...xx..x..x......x.xxxx...xx.x.....xx.";
            string p2 = ".x..x.......x.xxx...xx.x..xx....xx....xxx......";
            string p3 = "....x..x.x.x..xxxx.xx...x.x...x.x.xx..xxxx.........";
            string p4 = ".xx..x.xx..x.x.x...xxxx.x..xxx.x..xx.xxx.............";
            string p5 = "..x.x....xxxx..xxxx.x.x.x..x..x.x.x.x..x.x.................";

            string m37 = ".x...................................";
            string m61 = ".....................x.......................................";

            string c1 = "...x..x.x.........xxxx...................";
            string c2 = "x..xx..x...xx..x....x.x........";
            string c3 = ".x.x.xx.x...x..x.x..x.x......";
            string c4 = "xx..xx.x.x..x...xxx.......";
            string c5 = ".x.....xx...xx.xxx...xx";

            PsiWheel1 psiWheel1 = WheelFactory.CreatePsiWheel1(p1);
            PsiWheel2 psiWheel2 = WheelFactory.CreatePsiWheel2(p2);
            PsiWheel3 psiWheel3 = WheelFactory.CreatePsiWheel3(p3);
            PsiWheel4 psiWheel4 = WheelFactory.CreatePsiWheel4(p4);
            PsiWheel5 psiWheel5 = WheelFactory.CreatePsiWheel5(p5);

            MuWheel37 muWheel37 = WheelFactory.CreateMuWheel37(m37);
            MuWheel61 muWheel61 = WheelFactory.CreateMuWheel61(m61);

            ChiWheel1 chiWheel1 = WheelFactory.CreateChiWheel1(c1);
            ChiWheel2 chiWheel2 = WheelFactory.CreateChiWheel2(c2);
            ChiWheel3 chiWheel3 = WheelFactory.CreateChiWheel3(c3);
            ChiWheel4 chiWheel4 = WheelFactory.CreateChiWheel4(c4);
            ChiWheel5 chiWheel5 = WheelFactory.CreateChiWheel5(c5);

            var wheelBay = new WheelBay(
                psiWheel1, psiWheel2, psiWheel3, psiWheel4, psiWheel5,
                muWheel37, muWheel61,
                chiWheel1, chiWheel2, chiWheel3, chiWheel4, chiWheel5
                );

            SetWheelPositions(wheelBay);

            IEnumerable<VBit> enciphered = wheelBay.Process(baudot, true).ToList();

            Console.WriteLine("Enciphered:");
            Console.Write(Baudot.FromCode(enciphered, true));

            Console.WriteLine();
            Console.WriteLine();

            // Reset.
            SetWheelPositions(wheelBay);

            IEnumerable<VBit> deciphered = wheelBay.Process(enciphered, false).ToList();

            Console.WriteLine("Deciphered:");
            Console.Write(Baudot.FromCode(deciphered, true));

            Console.ReadKey();
        }

        private static void SetWheelPositions(WheelBay wheelBay)
        {
            wheelBay.SetWheelPositions(
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
