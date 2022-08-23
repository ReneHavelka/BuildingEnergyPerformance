﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dictionaries
{
    public static class IssuesSk
    {
        public static readonly IDictionary<string, string> IssuesList = new Dictionary<string, string>()
        {
            {"Storeys", "Podlažia" },
            {"Spaces", "Priestory" },
            {"BuildingElements", "Stavebné konštrukcie" },
            { "BuildingElementComponents", "Prvky stavebných konštrukcií"},
            {"Layers", "Vrstvy" },
            {"SpaceTemperatures", "Teploty v priestoroch" },
            {"ThermalResistanceTable", "Tabuľka tepelných odporov" },
            {"ThermalConductivityTable", "Tabuľka tepelných vodivostí" }
        };
    }
}