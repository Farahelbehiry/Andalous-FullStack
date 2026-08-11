namespace TaskApi.Models
{
    public class Products
    {
        private static int _nextId = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Products()
        {
            _nextId++;
            Id = _nextId;
        }
    }
}
