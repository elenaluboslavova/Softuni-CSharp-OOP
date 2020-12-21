using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Contracts
{
    public interface IProductStock : IEnumerable<IProduct>
    {
        int Count { get; }

        void Add(IProduct product);

        bool Contains(IProduct product);

        IProduct Find(int index);

        IProduct FindByLabel(string label);

        IEnumerable<IProduct> FindAllInPriceRange(decimal lowerEnd, decimal higherEnd);

        IEnumerable<IProduct> FindAllByPrice(decimal price);

        IProduct FindMostExpensiveProduct();

        IEnumerable<IProduct> FindAllByQuantity(int quantity);

        IEnumerable<IProduct> GetEnumerator<IProduct>();
    }
}
