﻿using System.ComponentModel.DataAnnotations;

namespace Postcrossing.Storage.Models.Address;

public class CountryEntity
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = "";
    [MaxLength(10)] public string Code { get; set; } = "";

    public bool OpenBorder { get; set; }

    public ICollection<DistrictEntity> Districts { get; set; }
    public ICollection<ResidentialAddressEntity> Addresses { get; set; }
}