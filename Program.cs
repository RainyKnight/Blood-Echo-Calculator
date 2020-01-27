// Designed by Lucas Stoltman 2018

using System;

namespace BloodEchoCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
			var bec = new BloodEchoCalculator();

			Console.WriteLine("=====================================");
            Console.WriteLine("WELCOME TO THE BLOOD ECHO CALCULATOR");
			Console.WriteLine("=====================================");
            while (true)
			{
				Console.Write("Current Level: ");
				bec.SetCLevel();

				Console.Write("Target Level: ");
				bec.SetTLevel();

				Console.WriteLine("\nBlood echoes needed to go from level {0} to level {1} = {2}\n", bec.CLevel, bec.TLevel, bec.Calculate());
				bec.beReqResetter();
				Console.WriteLine("=====================================");
			}
        }
    }
    
	class BloodEchoCalculator
	{
		// current level
		private double cLevel;

		// target level
		private double tLevel;
        
		// Blood Echo Required
		private double beReq;

        
		public double CLevel
		{
			get { return cLevel; }
		}

        public void SetCLevel()
		{
			cLevel = InputTaker();
		}
         

		public double TLevel 
		{ 
			get { return tLevel; }
		}
        
		public void SetTLevel()
        {
			double x = InputTaker();
            
            while (x < cLevel)
			{
				Console.WriteLine("ERROR: You cannot level backwards!");
				x = InputTaker();
			}
				tLevel = x;
        }


        public void beReqResetter()
		{
			beReq = 0;
		}

        
        public string Calculate()
		{
			double mLevel = cLevel + 1;
            
			for (double i = cLevel; i < TLevel; i++)
			{
				// the equation becomes exponential at level 12
				if (i < 12)
                {
                    beReq += ((mLevel) * 17.5952381) + 652.7857143;
					mLevel++;
                }
                else
                {
                    beReq += 0.02 * Math.Pow(mLevel, 3) + 3.06 * Math.Pow(mLevel, 2) + (105.6 * mLevel) - 895;
					mLevel++;
                }
			}

            // adds commas to make the number more readable
			return string.Format("{0:n0}", beReq);
		}

		// I got tired of micromanaging the userinput within each method
        public double InputTaker()
		{
			bool isNum = false;
			double input;

			while (true)
            {
                // attempts to convert the string of input into a double
                isNum = double.TryParse(Console.ReadLine(), out input);

                // checks for numbers
                if (isNum == false)
                {
					Console.WriteLine(" ERROR: You need to type a whole number between 4 and 544");
                }
                // checks that it is within desired range
                else if (input < 4 || input > 544)
                {
					Console.WriteLine("ERROR: You need to type a whole number between 4 and 544");
                }
                else
                {
					return input;
                }
            }
		}
	}
}

// Designed by Lucas Stoltman 2018