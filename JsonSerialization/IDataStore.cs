using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization
{
    internal interface IDataStorage
    {
        void Save(Person[] people);
        Person[] Restore();
    }
}
