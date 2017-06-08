using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelService
{
    [ServiceContract]
    public interface IDateService
    {
        [OperationContract]
        DateTime GetDate();
        [OperationContract]
        int Add(int x, int y);
    }
}