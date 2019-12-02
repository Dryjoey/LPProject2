﻿using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Models
{
    class Ad: IAd
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Game Game { get; private set; }

    }
}
