namespace Class_Chef_in_CSharp
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(IVegetable vegetable)
        {
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Peel(IVegetable vegetable)
        {
        }
    }
}