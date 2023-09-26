using System.ComponentModel.DataAnnotations;
using AspNetCoreUploadTest.Models.Validation;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreUploadTest.Models.InputModels;

public class ContattoInputModel
{
    [Required(ErrorMessage = "Campo richiesto")]
    [MaxLength(100, ErrorMessage = "Lunghezza massima del nome di {1} caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [MaxLength(100, ErrorMessage = "Lunghezza massima del cognome di {1} caratteri.")]
    public string Cognome { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [MaxLength(256, ErrorMessage = "Lunghezza massima della mail di {1} caratteri.")]
    [EmailAddress(ErrorMessage = "Formato email non valida")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [Range(18, 100, ErrorMessage = "Il campo dev'essere compreso tra {1} e {2}")]
    public int? Eta { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [MaxLength(50, ErrorMessage = "Il campo deve avere lunghezza massima di {1} cifre")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [MaxLength(2000, ErrorMessage = "Lunghezza massima del messaggio di {1} caratteri.")]
    public string Messaggio { get; set; }

    [EnforceTrue(ErrorMessage = "Il campo deve essere flaggato")]
    [Display(Name = "Accetta la privacy")]
    public bool IsPrivacyAccepted { get; set; }

    [Required(ErrorMessage = "Campo richiesto")]
    [Display(Name = "Allega documento")]
    public IFormFile AttachFile { get; set; }
}