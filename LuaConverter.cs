using System.IO;
using System.Xml.Serialization;
using XmlToLuaTableConverter.Data;
using XmlToLuaTableConverter.Interface;

namespace XmlToLuaTableConverter
{
    class LuaConverter : ILuaConverter
    {
        public DkpEntryObject[] ReadXmlFile(string xmlFileName)
        {
            DkpTableObject dkpTableObject;
            using (TextReader reader = new StreamReader(xmlFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DkpTableObject));
                dkpTableObject = (DkpTableObject)serializer.Deserialize(reader);
            }
            return dkpTableObject.dkpEntryObjects;

        }

        public bool WriteLuaTableFile(DkpEntryObject[] dkpEntryArray, string luaFileName)
        {
            string luaString = LuaWriter.writeDkpTableStartEntry();
            int count = 1;
            foreach (DkpEntryObject dkpEntryobject in dkpEntryArray)
            {
                luaString += LuaWriter.writeStartEntry();
                luaString += dkpEntryobject.WriteLuaString();
                luaString += LuaWriter.writeEndEntry(count++);
            }
            luaString += LuaWriter.writeDkpTableEndEntry();

            File.WriteAllText(luaFileName, luaString);
            return true;
        }
    }
}
