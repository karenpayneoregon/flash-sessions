#nullable disable

/*
 * There are several classes in this file, for a real
 * project, one class/model per file.
 */

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SomeLibrary1.Models;

/// <summary>
/// The abstract keyword enables you to create classes and class members
/// that are incomplete and must be implemented in a derived class.
/// </summary>
public abstract class AbstractHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public virtual void DoWork(int index)
    {
        Console.WriteLine($"Original implementation {index}");
    }

    public virtual string GetFullName()
    {
        return $"{LastName} {FirstName}"; // has no clue what FirstName and LastName are
    }
}

public class Person : AbstractHuman, INotifyPropertyChanged
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private DateOnly _birthDate;

    public new int Id
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged();
        }
    }

    public new string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public new string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public DateOnly BirthDate
    {
        get => _birthDate;
        set
        {
            if (value.Equals(_birthDate)) return;
            _birthDate = value;
            OnPropertyChanged();
        }
    }

    public override void DoWork(int index)
    {
        base.DoWork(index +=9);
        Console.WriteLine($"New implementation with {index}");
    }

    public override string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Employee : Person
{
    public virtual string Description 
        => "Employee";

    public DateOnly HireDate { get; set; }
}

public class Manager : Employee
{
    public new virtual string Description 
        => "Manager";

    public List<Employee> Employees { get; set; }
}