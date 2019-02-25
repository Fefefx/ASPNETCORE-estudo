using System.ComponentModel.DataAnnotations;

namespace Forms.Models
{
    public class Product
    {
        //Diz que é obrigatório o preenchimento da propriedade
        [Required(ErrorMessage = "Id é obrigatório")]
        //Define um intervalo de valores que serão aceitos pela propriedade
        [Range(10,20, ErrorMessage = "Número de 10 a 20")]
        public int Id {get; set;}
        [Required(ErrorMessage = "Name é obrigatório")]
        //Aceita apenas valores com pelo menos 3 caracteres
        [MinLength(3, ErrorMessage = "Mínimo com 3 letras")]
        //Aceita valores com no máximo 5 caracteres
        [MaxLength(5, ErrorMessage = "Máximo com 5 letras")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Price é obrigatório")]
        [Range(1,int.MaxValue, ErrorMessage = "Número de 1 a muito número")]
        public int Price {get; set;}
    }
}