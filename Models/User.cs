using System.ComponentModel.DataAnnotations;

namespace EMassage.Models
{
    public class User
    {
        // Первичный ключ пользователя
        public int Id { get; set; }

        // Логин пользователя
        [Required(ErrorMessage = "Необходимо ввести логин.")]
        public string Login { get; set; }

        // Пароль пользователя (хешированный)
        [Required(ErrorMessage = "Необходимо ввести пароль.")]
        public string PasswordHash { get; set; }

        // Роль администратора (true - администратор, false - обычный пользователь)
        public bool IsAdmin { get; set; } = false;

        // Методы проверки полномочий
        public bool CanLogin() => !string.IsNullOrEmpty(Login);
        public bool CanLogout() => this.CanLogin();
        public bool CanSelectMassageService() => this.CanLogin(); // Только зарегистрированные пользователи могут выбрать услугу
        public bool CanLeaveReview() => this.CanLogin();          // Только зарегистрированные пользователи могут оставить отзыв

        // Метод изменения статуса администрации (например, при изменении прав пользователя)
        public void SetAsAdmin(bool isAdmin = true)
        {
            this.IsAdmin = isAdmin;
        }
    }
}