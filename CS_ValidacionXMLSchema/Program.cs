using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ValidacionXMLSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlXML mControlXML = new ControlXML();
            mControlXML.AbrirEsquema("compras.xsd");
            mControlXML.AbrirXML("compras.xml");
            mControlXML.LeerXML();
            Console.ReadKey();
        }
    }
}
