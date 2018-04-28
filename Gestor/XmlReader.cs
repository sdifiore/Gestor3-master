using System;
using System.Xml;
using Gestor.Models;

namespace Gestor
{
    public static class XmlReader
    {
        public static string Read(string key)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Files.Frases);
            if (doc.DocumentElement == null)
            {
                DbLogger.Log(Reason.Error,"Elemento faltante em Frases.xml");
                throw new InvalidOperationException("Elemento faltante em Frases.xml");
            }

            XmlNode node = doc.DocumentElement.SelectSingleNode($"/root/{key}");

            if (node == null)
            {
                DbLogger.Log(Reason.Error, "Nó faltante em Frases.xml");
                throw new InvalidOperationException("Nó faltante em Frases.xml");
            }

            return node.InnerText;
        }
    }
}