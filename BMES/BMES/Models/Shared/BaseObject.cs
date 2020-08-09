﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES.Models.Shared
{
    public class BaseObject
    {
        public long Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
