﻿namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Sets
    {
        public Long(string name)
            : base(name, new TimeSpan(0, 60, 0))
        {
        }
    }
}
