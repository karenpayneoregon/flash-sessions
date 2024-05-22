﻿using Bogus;
using Bogus.DataSets;
using ConditionalBreakpointsSample.Models;

namespace ConditionalBreakpointsSample.Classes;

public class BogusOperations
{
    public static List<Customer> CustomersList(int count = 1000)
    {

        Randomizer.Seed = new Random(338);

        int identifier = 1;

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer(identifier++))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDay, f => f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName));

        return faker.Generate(count);

    }
}
