using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelService
{
    [ServiceContract]
    public interface IGebruikerService
    {
        [OperationContract]
        bool Registreer(string gebruikersnaam);
        [OperationContract]
        int Login(int x, int y);

    }
}