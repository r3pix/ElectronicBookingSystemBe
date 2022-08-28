﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToLikeExpression(this string word) =>
            $"%{word}%";
    }
}
