using BasicLibrary.Interfaces;

namespace BasicLibrary.Models;

public  class Taxpayer : Person, ITaxpayer
{
    public string SSN { get; set; }
    public string SocialSecurityValue => SSN.Replace("-","");
    public string PIN { get; set; }
    public string JobTitle { get; set; }
    public DateOnly StartDate { get; set; }
    public string EmployerIdentificationNumber { get; set; }
}