using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<Drink> drinks;
        private List<BakedFood> foods;
        private List<Table> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.drinks = new List<Drink>();
            this.foods = new List<BakedFood>();
            this.tables = new List<Table>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            else
            {
                return null;
            }
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
                foods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
                foods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            else
            {
                return null;
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            else
            {
                return null;
            }
        }

        public string GetFreeTablesInfo()
        {
            List<Table> freeTables = tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Table freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:F2}");
            table.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            List<Drink> listDrinks = drinks.Where(d => d.Name == drinkName).ToList();
            Drink drink = listDrinks.FirstOrDefault(d => d.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            BakedFood food = foods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            List<Table> freeTables = tables.Where(t => t.IsReserved == false).ToList();
            ITable freeTable = freeTables.FirstOrDefault(t => t.Capacity >= numberOfPeople);
            if (freeTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                freeTable.Reserve(numberOfPeople);
                return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
