namespace DictionaryExercises.Transportation
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Vin},{Make},{Model},{Year},{Color}";
        }
    }
}
