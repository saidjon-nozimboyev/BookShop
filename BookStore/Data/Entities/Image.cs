﻿namespace Ustoz_Proyekti.Data.Entities;

public class Image: BaseEntity
{
    public string Url { get; set; } = null!;
    public Book Book { get; set; } = null!;
}
