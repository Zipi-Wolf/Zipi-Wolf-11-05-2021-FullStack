﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Interfaces
{
    public interface IHttpClientService
    {
        Task OnGet(string query);
    }
}
