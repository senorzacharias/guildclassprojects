﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class UpdateMovieResponse : Response
    {
        public Movie Movie { get; set; }
    }
}