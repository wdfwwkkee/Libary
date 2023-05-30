using System;
using System.Collections.Generic;

namespace UsmanovBochkarevKhayrullin.Models;

public partial class LibaryCard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string MiddleOfName { get; set; } = null!;

    public string Group { get; set; } = null!;
}
