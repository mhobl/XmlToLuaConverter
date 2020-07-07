
namespace XmlToLuaTableConverter
{
    public static class LuaWriter
    {
        private static string Tab = "\t";
        private static string DoubleTab = "\t\t";
        private static string NewLine = "\n";

        public static string writeDkpTableStartEntry()
        {
            return "MonDKP_DKPTable = {" + NewLine;
        }

        public static string writeDkpTableEndEntry()
        {
            return "}" + NewLine;
        }

        public static string writeStartEntry()
        {
            return Tab + "{" + NewLine;
        }

        public static string writeEndEntry(int count)
        {
            return Tab + "}," + " --[" + count.ToString() + "]" + NewLine;
        }

        public static string writeTextAttribute(string name, string value)
        {
            return DoubleTab + addBracket(attributeConvert(name)) + " = " + addApostrophe(value) + "," + NewLine;
        }

        public static string writeDecimalAttribute(string name, decimal value)
        {
            return DoubleTab + addBracket(attributeConvert(name)) + " = " + value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + NewLine;
        }

        private static string attributeConvert(string attributeName)
        {
            string convertedAttributeName = attributeName;
            if(attributeName == "LifetimeGained")
            {
                convertedAttributeName = "lifetime_gained";
            }
            if (attributeName == "LifetimeSpent")
            {
                convertedAttributeName = "lifetime_spent";
            }
            return convertedAttributeName.ToLower();
        }

        private static string addApostrophe (string value)
        {
            return "\"" + value + "\"";
        }

        private static string addBracket(string value)
        {
            return "[\"" + value + "\"]";
        }
    }
}
