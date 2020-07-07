using System;
using XmlToLuaTableConverter.Interface;

namespace XmlToLuaTableConverter.Data
{
    [Serializable()]
    public class DkpEntryObject : IDataObject
    {
        [System.Xml.Serialization.XmlElement("player")]
        public string Player { get; set; }
        [System.Xml.Serialization.XmlElement("class")]
        public string Class { get; set; }
        [System.Xml.Serialization.XmlElement("dkp")]
        public decimal Dkp { get; set; }
        [System.Xml.Serialization.XmlElement("lifetime_gained")]
        public decimal LifetimeGained { get; set; }
        [System.Xml.Serialization.XmlElement("lifetime_spent")]
        public decimal LifetimeSpent { get; set; }

        public string WriteLuaString()
        {
            string luaString = string.Empty;
            luaString += LuaWriter.writeDecimalAttribute("previous_dkp", 0);
            luaString += LuaWriter.writeTextAttribute(nameof(Player), Player);
            luaString += LuaWriter.writeTextAttribute(nameof(Class), Class);
            luaString += LuaWriter.writeDecimalAttribute(nameof(Dkp), Dkp);
            luaString += LuaWriter.writeDecimalAttribute(nameof(LifetimeGained), LifetimeGained);
            luaString += LuaWriter.writeDecimalAttribute(nameof(LifetimeSpent), LifetimeSpent);
            return luaString;
        }


    }
}
