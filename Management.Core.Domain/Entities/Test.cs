﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Domain.Entities;

public class Test
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
}
