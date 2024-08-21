﻿namespace Postcrossing.Domain.Models;

public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public ResidentialAddress ResidentialAddress { get; set; }
}