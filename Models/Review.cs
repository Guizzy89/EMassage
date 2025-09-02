using System.ComponentModel.DataAnnotations;
namespace EMassage.Models
{
    public class Review
    {
        // Первичный ключ отзыва
        public int Id { get; set; }

        // Содержимое отзыва
        [Required]
        public string Content { get; set; }

        // Дата и время публикации отзыва
        public DateTime CreatedAt { get; set; }

        // Внешний ключ, связанный с пользователем
        public int AuthorId { get; set; }

        // Навигационная ссылка на объект пользователя
        public virtual User Author { get; set; }
    }
}
