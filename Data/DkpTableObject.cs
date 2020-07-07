using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlToLuaTableConverter.Data
{
    [XmlRoot("dkptable")]
    public class DkpTableObject
    {
        [XmlElement("dkpentry")]
        public DkpEntryObject[] dkpEntryObjects { get; set; }
    }
}
