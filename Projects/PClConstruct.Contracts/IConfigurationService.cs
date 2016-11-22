using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PClConstruct.Contracts
{
    public interface IConfigurationService
    {
        string GetStorageConnection(string storageName);

        string GetStorageName(string context);
    }
}
