namespace Cars.Data
{
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Models;

    public class Database : IDatabase
    {
        public Database()
        {
            this.Cars = new List<Car>();
        }
        public IList<Car> Cars { get; set; }
    }
}
