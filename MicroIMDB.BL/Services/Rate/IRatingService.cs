﻿using MicroIMDb.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIMDb.Application.Services.Rate
{
    public interface IRatingService
    {
        Task<bool> RateMovie(AddRatingDto addRatingDto);
    }
}
