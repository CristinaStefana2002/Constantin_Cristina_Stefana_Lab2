namespace Constantin_Cristina_Stefana_Lab2.Models.ViewModels
{
    public class CategoryIndex
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Category Category { get; set; } 

    }
}
