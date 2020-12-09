using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.DomainService
{
    public interface IColorRepository
    {
        Color Create(Color color);
        IEnumerable<Color> ReadAllColors(Filter filter = null);
        Color ReadyById(int id);
        Color DeleteColor(int id);
        int Count();
        Color UpdateColorInDB(Color color);
    }
}
