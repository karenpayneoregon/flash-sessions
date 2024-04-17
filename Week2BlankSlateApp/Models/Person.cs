using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2BlankSlateApp.Models;
internal class Person
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }

    public Person()
    {
        
    }

    public Person(string firstName, string lastName, DateOnly birthDate)
    {
        
    }
}

