using XmlToLuaTableConverter.Data;

namespace XmlToLuaTableConverter.Interface
{
    interface ILuaConverter
    {
        public DkpEntryObject[] ReadXmlFile(string xmlFileName);

        public bool WriteLuaTableFile(DkpEntryObject[] dkpEntryArray, string luaFileName);

    }
}
