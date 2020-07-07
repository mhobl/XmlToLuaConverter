using System;
using System.Collections.Generic;
using System.Text;

namespace XmlToLuaTableConverter.Interface
{
    interface IDataObject
    {
        public string WriteLuaString();
    }
}
