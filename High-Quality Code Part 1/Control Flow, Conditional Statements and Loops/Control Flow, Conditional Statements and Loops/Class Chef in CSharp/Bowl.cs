using System.Collections;
using System.Collections.Generic;

namespace Class_Chef_in_CSharp
{
    public class Bowl
    {
        private IList bowl;

        public Bowl()
        {
            this.bowl = new List<IVegetable>();
        }

        public void Add(IVegetable vegetable)
        {
            this.bowl.Add(vegetable);
        }
    }
}