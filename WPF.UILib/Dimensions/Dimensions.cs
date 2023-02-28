﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.UILib.Dimensions
{
    public static class Dimensions
    {
        public static ComponentResourceKey CornerRadius => new ComponentResourceKey(typeof(Dimensions), "CornerRadius");

        public static ComponentResourceKey BorderThickness => new ComponentResourceKey(typeof(Dimensions), "BorderThickness");
    }
}
