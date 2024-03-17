﻿namespace FirstVersion.Models;

public class Driver : User
{
    public Category Category { get; set; }
    public DateTime DrivingLicenseReceiptDate { get; set; }
    public string City { get; set; }
    public List<Car> Cars { get; set; }
}