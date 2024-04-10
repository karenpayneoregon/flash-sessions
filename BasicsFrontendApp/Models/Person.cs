using BasicsFrontendApp.Interfaces;


namespace BasicsFrontendApp.Models;

public class Person : IHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    
    public DateOnly BirthDate { get; set; }

    public Gender Gender { get; set; }
}

public class Taxpayer : Person, ITaxpayer
{
    public string SSN { get; set; }
    public string SocialSecurityValue => SSN.Replace("-","");
    public string PIN { get; set; }
    public string JobTitle { get; set; }
    public DateOnly StartDate { get; set; }
    public string EmployerIdentificationNumber { get; set; }
}