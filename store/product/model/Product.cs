namespace store.product.model
{
    public class Product
    {
        private int Id;  // id
        private string Name;  // nome
        private string Manufacturer;  // fabricante
        private string Category;  // categoria
        private float Price;  // preço
        private int Amount;  // quantidade

        public Product() { }

        public Product(int id, string name, string manufacturer, string category, float price, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Category = category;
            this.Price = price;
            this.Amount = amount;
        }

        public int getId()
        {
            return this.Id;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getManufacturer()
        {
            return this.Manufacturer;
        }

        public string getCategory()
        {
            return this.Category;
        }

        public float getPrice()
        {
            return this.Price;
        }

        public int getAmount()
        {
            return this.Amount;
        }

        public void setId(int value)
        {
            this.Id = value;
        }

        public void setName(string value)
        {
            this.Name = value;
        }

        public void setManufacturer(string value)
        {
            this.Manufacturer = value;
        }

        public void setCategory(string value)
        {
            this.Category = value;
        }

        public void setPrice(float value)
        {
            this.Price = value;
        }

        public void setAmount(int value)
        {
            this.Amount = value;
        }
    }
}
