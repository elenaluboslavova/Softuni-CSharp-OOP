using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weightInGrams;

        public Dough(string flourType, string bakingTechnique, double weightInGrams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightInGrams = weightInGrams;

            if (this.FlourType.ToLower() == "white")
            {
                this.Modifier = 1.5;
            }
            else
            {
                this.Modifier = 1;
            }
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                this.Modifier *= 0.9;
            }
            else if(this.BakingTechnique.ToLower() == "chewy")
            {
                this.Modifier *= 1.1;
            }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }
                this.bakingTechnique = value;
            }
        }
        public double WeightInGrams 
        {
            get
            {
                return this.weightInGrams;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(0);
                }
                this.weightInGrams = value;
            }
        }
        private double Modifier { get; set; }
        public double CalculateDoughCalories()
        {
            double calories = 2.00 * WeightInGrams * Modifier;
            return calories;
        }
    }
}
