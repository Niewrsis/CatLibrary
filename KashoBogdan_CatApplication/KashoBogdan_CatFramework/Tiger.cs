namespace KashoBogdan_CatFramework
{
    public class Tiger : Cat
    {
        public override int Fluffiness { get; }
        public double Weight { get; }

        public Tiger(double weight = 50, int fluffiness = 50)
        {
            string errorMessage = "";
            if (weight < 75.0 || weight > 140.0)
                errorMessage += "Unable to create a tiger with weight: " + weight + ". ";
            if (fluffiness < 0 || fluffiness > 100)
                errorMessage += "Unable to create a tiger with fluffiness " + fluffiness + ". ";

            if (!string.IsNullOrEmpty(errorMessage))
                throw new CatException(errorMessage.Trim());

            Weight = weight;
            Fluffiness = fluffiness;
        }

        public override string FluffinessCheck()
        {
            return "Kycb!";
        }

        public override string ToString()
        {
            return $"A tiger with weight: {Weight}, fluffiness: {Fluffiness}";
        }
    }
}
