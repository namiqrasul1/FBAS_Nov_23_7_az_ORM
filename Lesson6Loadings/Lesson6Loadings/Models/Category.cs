﻿using System;
using System.Collections.Generic;

namespace Lesson6Loadings.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = [];
}
