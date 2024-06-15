using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleEmployee;

internal interface IRepository<T>
{/// <summary>
/// Loads the data from the file
/// </summary>
    IList<T> LoadDataFromFile(IList<T> _entities , string entityFile);
    /// <summary>
    /// Saves the data to the file
    /// </summary>
    bool SaveDataToFile(IList<T> _entities , string entityFile);
}
