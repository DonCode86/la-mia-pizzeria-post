namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        public Pizza()
        {
        }

        public Pizza(string name, string ingredients, string image, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Image = image;
            Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

    }
}
