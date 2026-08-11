namespace TaskApi.Models
{
    public class Products
    {
        private static int _nextId = 0;
        public int Id { get;  }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Products(int id)
        {
            _nextId++;
            Id = _nextId;


        }
    }
}
