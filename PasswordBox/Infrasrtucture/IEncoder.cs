﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Infrasrtucture
{
    public interface IEncoder
    {
        string GetHashCode(string password);
    }
}
