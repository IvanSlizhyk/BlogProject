﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public class BaseEntity<T> : Entity
    {
        public T Id { get; set; }
    }
}
