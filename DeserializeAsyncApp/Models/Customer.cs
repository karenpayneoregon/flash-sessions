﻿#pragma warning disable CS8618

namespace DeserializeAsyncApp.Models;

public interface IBaseEntity
{
    int Id { get; set; }
}

public class Customer : IBaseEntity
{
    public int Id { get; set; }
    public string Company { get; set; }
    public string Title { get; set; }
    public string Contact { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public DateTime Modified { get; set; }
}
