using _04.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Contracts
{
    public interface IFeedable
    {
        void Feed(IFood food);
        int FoodEaten { get; }
        double WeightMultiplier { get; }
        ICollection<Type> PreferredFoods { get; }
    }
}
