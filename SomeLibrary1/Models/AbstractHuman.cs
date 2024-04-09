#nullable disable

/*
 * There are several classes in this file, for a real
 * project, one class/model per file.
 */

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Spectre.Console;

namespace SomeLibrary1.Models;

/// <summary>
/// The abstract keyword enables you to create classes and class members
/// that are incomplete (or sometimes has code) and must be implemented in a derived class.
/// 💡 An abstract class can not be created on its own, it must be inherited.
/// </summary>
public abstract class AbstractHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public virtual void PerformSimpleTask(int index)
    {
        AnsiConsole.MarkupLine($"[lightcoral]Base implementation[/] - [greenyellow]Caller '{GetType()}'[/]");
    }

    public virtual string GetFullName() 
        => $"{FirstName} {LastName}"; // has no clue what FirstName and LastName are 🙄
}

/// <summary>
/// A class which inherits from an abstract class must implement all abstract members
/// and provides change notification using <see cref="INotifyPropertyChanged"/>.
/// </summary>
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


    /// <summary>
    /// Let's talk about
    /// - Regular break points
    /// - Conditional break points
    /// - Enable/disable break points
    /// - Ooops I removed a break point by accident 😒
    /// </summary>
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

    /// <summary>
    /// Here we are overriding code in base class AbstractHuman
    /// </summary>
    /// <param name="index"></param>
    public override void PerformSimpleTask(int index)
    {
        base.PerformSimpleTask(index +=9);

        var parent = GetType().BaseType.Name;
        AnsiConsole.MarkupLine($"[lightcoral]New implementation of {GetType().Name}.{GetMethodName()}[/] [greenyellow]overriding {parent}.{GetMethodName()}[/]");
    }
    private string GetMethodName() 
        => new StackTrace(1).GetFrame(0)!.GetMethod().Name;

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