﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class AdDTO
    {
        public AdDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
