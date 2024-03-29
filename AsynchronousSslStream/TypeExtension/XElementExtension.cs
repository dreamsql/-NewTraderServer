﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Trader.Server.Serialization;
namespace Trader.Server.TypeExtension
{
    public static class XElementExtension
    {
        public static XElement ToXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        public static XmlNode ToXmlNode(this XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }

        public static PacketContent ToPacketContent(this XElement source)
        {
            if (source == null)
                throw new ArgumentNullException("source can't be null");
            return new PacketContent(source);
        }
    }
}
