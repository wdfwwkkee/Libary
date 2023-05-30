using System;
using System.Collections.Generic;

namespace UsmanovBochkarevKhayrullin.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int Amount { get; set; }

    public DateTime ReleaseDate { get; set; }
}
