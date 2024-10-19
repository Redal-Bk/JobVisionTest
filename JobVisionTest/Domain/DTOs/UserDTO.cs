using System.ComponentModel.DataAnnotations;

namespace JobVisionTest.Domain.DTOs
{
    public class UserDTO
    {
        [Key]
        
        public int Id { get; set; }

        public string? ProfileImageUrl { get; set; }
        
        [MinLength(3,ErrorMessage = "نام کاربر نباید کمتر از 3 حرف باشد")]
        [MaxLength(15,ErrorMessage = "نام کاربر نباید بیشتر از 15 حرف باشد")]
        public string? Name { get; set; }
        
        [MinLength(3, ErrorMessage = "نام خانوادگی کاربر نباید کمتر از 3 حرف باشد")]
        [MaxLength(15, ErrorMessage = "نام خانوادگی کاربر نباید بیشتر از 15 حرف باشد")]
        public string? Family { get; set; }

        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
}
