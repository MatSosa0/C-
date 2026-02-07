namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public DateTime CreatedAd { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
    }
}

