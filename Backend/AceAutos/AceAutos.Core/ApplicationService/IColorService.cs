using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface IColorService
    {
        Color CreateColor(Color color);
        IEnumerable<Color> GetAllColors();
        Color GetColorWithId(int id);
        Color RemoveColor(int id);
        Color UpdateColor(Color colorToUpdate);
        IEnumerable<Color> GetFilteredColor(Filter filter);
    }
}
