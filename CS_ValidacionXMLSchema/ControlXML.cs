using System;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace CS_ValidacionXMLSchema
{
    class ControlXML
    {
        private string RutaArchivoEsquema;
        private string RutaArchivoXML;
        private XmlReaderSettings ConfiguracionXML;
        private XmlReader ArchivoXML;
        private bool existewarning;
        private bool existeerror;

        public ControlXML()
        {
            RutaArchivoEsquema = "";
            RutaArchivoXML = "";
            ConfiguracionXML = null;
            ArchivoXML = null;
            existewarning = false;
            existeerror = false;
        }

        public void AbrirEsquema(string ruta)
        {
            RutaArchivoEsquema = ruta;
            if (File.Exists(RutaArchivoEsquema))
            {
                ConfiguracionXML = new XmlReaderSettings();
                // Se asigna el XSD a la configuración
                ConfiguracionXML.Schemas.Add(null, RutaArchivoEsquema);
                ConfiguracionXML.ValidationType = ValidationType.Schema;
                // Se añade el método Validador al evento ValidationEventHandler
                ConfiguracionXML.ValidationEventHandler += new ValidationEventHandler(Validador);
            }
            else
            {
                Console.WriteLine("Archivo esquema no existe");
                existeerror = true;
            }
        }

        public void AbrirXML(string ruta)
        {
            RutaArchivoXML = ruta;
            if (File.Exists(RutaArchivoXML))
            {
                // Se asigna configuración al lector
                ArchivoXML = XmlReader.Create(RutaArchivoXML, ConfiguracionXML);
            }
            else
            {
                Console.WriteLine("Archivo XML no existe");
                existeerror = true;
            }
        }

        private void Validador(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("WARNING:\n" + e.Message);
                existewarning = true;
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.WriteLine("ERROR:\n" + e.Message);
                existeerror = true;
            }
        }

        public void LeerXML()
        {
            string textoxml = "";

            if (ArchivoXML != null)
            {
                while (ArchivoXML.Read())
                {
                    textoxml += ArchivoXML.Value;
                }
            }

            if ((!existeerror) && (!existewarning))
            {
                Console.WriteLine("Validado correctamente");
            }

            Console.WriteLine(textoxml);
            existeerror = false;
            existewarning = false;
        }
    }
}
