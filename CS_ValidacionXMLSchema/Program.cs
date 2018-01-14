using System;

namespace CS_ValidacionXMLSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlXML mControlXML = new ControlXML();
            mControlXML.AbrirEsquema("archivo.xsd");
            mControlXML.AbrirXML("archivo.xml");
            mControlXML.LeerXML();
            Console.ReadKey();
        }
    }
}
