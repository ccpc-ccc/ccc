using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using YF.MWS.Metadata;
using YF.Utility;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// XML工具类
    /// </summary>
    public class XmlUtil
    {
        /// 创建Xml配置文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        public static void CreateXmlFile(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //创建Xml声明
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", Encoding.Default.BodyName, null);
            xmlDoc.AppendChild(xmlDec);

            //创建Xml根节点
            XmlElement xmlRoot = xmlDoc.CreateElement("Config");
            xmlDoc.AppendChild(xmlRoot);

            xmlDoc.Save(fileName);
        }

        /// <summary>
        /// 根据Xml节点路径创建多级节点
        /// </summary>
        /// <param name="xmlDoc">Xml对象</param>
        /// <param name="xmlNode">Xml节点</param>
        /// <param name="xmlPath">Xml节点路径</param>
        public static void CreateNodeByXmlPath(XmlDocument xmlDoc, XmlNode xmlNode, string xmlPath)
        {
            if (xmlPath.IndexOf("/") > 0)
            {
                string nodeName = xmlPath.Substring(0, xmlPath.IndexOf("/"));
                string childNodeName = xmlPath.Substring(xmlPath.IndexOf("/") + 1);

                XmlNode node = xmlNode.SelectSingleNode(nodeName);
                if (node == null)
                {
                    XmlElement xmlEle = xmlDoc.CreateElement(nodeName);
                    node = xmlEle as XmlNode;
                    xmlNode.AppendChild(node);
                }

                CreateNodeByXmlPath(xmlDoc, node, childNodeName);
            }
            else
            {
                XmlNode node = xmlNode.SelectSingleNode(xmlPath);
                if (node == null)
                {
                    XmlElement xmlEle = xmlDoc.CreateElement(xmlPath);
                    xmlNode.AppendChild(xmlEle);
                }
            }
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="value">节点值</param>
        public static void CreateXmlNode(string fileName, string xmlPath, string value)
        {
            if (!File.Exists(fileName))
            {
                CreateXmlFile(fileName);
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                CreateNodeByXmlPath(xmlDoc, xmlRoot, xmlPath);
            }

            xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            //设置节点的值
            xmlNode.InnerText = value;

            xmlDoc.Save(fileName);
        }

        /// <summary>
        /// 修改Xml路径对应节点的值
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="value">节点值</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool UpdateXmlNode(string fileName, string xmlPath, string value, out string message)
        {
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }

            //设置节点的值
            xmlNode.InnerText = value;

            xmlDoc.Save(fileName);

            return true;
        }

        /// <summary>
        /// 给Xml路径对应节点添加属性
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="attributeName">Xml节点属性</param>
        /// <param name="value">属性值</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool CreateXmlAttribute(string fileName, string xmlPath, string attributeName, string value, out string message)
        {
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }

            //设置节点属性
            XmlElement xmlEle = xmlNode as XmlElement;
            xmlEle.SetAttribute(attributeName, value);

            xmlDoc.Save(fileName);

            return true;
        }

        /// <summary>
        /// 修改Xml路径对应节点的属性值
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="attributeName">Xml节点属性</param>
        /// <param name="value">属性值</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool UpdateXmlAttribute(string fileName, string xmlPath, string attributeName, string value, out string message)
        {
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }

            XmlElement xmlEle = xmlNode as XmlElement;

            XmlAttribute attribute = xmlEle.GetAttributeNode(attributeName);
            if (attribute == null)
            {
                message = "查找的节点属性不存在！";
                return false;
            }

            //设置节点属性
            xmlEle.SetAttribute(attributeName, value);

            xmlDoc.Save(fileName);

            return true;
        }

        /// <summary>
        /// 获取Xml路径对应节点的值
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="defaultValue">节点默认值</param>
        /// <returns></returns>
        public static string GetXmlNodeValue(string fileName, string xmlPath, string defaultValue)
        {
            if (!File.Exists(fileName))
            {
                return defaultValue;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                return defaultValue;
            }

            return xmlNode.InnerText;
        }

        /// <summary>
        /// 获取Xml路径对应节点的属性值
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="attributeName">Xml节点属性</param>
        /// <param name="value">获取到的属性值</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool GetXmlAttributeValue(string fileName, string xmlPath, string attributeName, out string value, out string message)
        {
            value = string.Empty;
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }

            XmlElement xmlEle = xmlNode as XmlElement;

            XmlAttribute attribute = xmlEle.GetAttributeNode(attributeName);
            if (attribute == null)
            {
                message = "查找的节点属性不存在！";
                return false;
            }

            //获取属性值
            value = xmlEle.GetAttribute(attributeName);

            return true;
        }

        /// <summary>
        /// 删除Xml路径对应的节点
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool DeleteXmlNode(string fileName, string xmlPath, out string message)
        {
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }
            else
            {
                xmlRoot.RemoveChild(xmlNode);
                return true;
            }
        }

        /// <summary>
        /// 删除节点属性
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="attributeName">Xml节点属性</param>
        /// <param name="message">输出的错误消息</param>
        /// <returns></returns>
        public static bool DeleteXmlAttribute(string fileName, string xmlPath, string attributeName, out string message)
        {
            message = string.Empty;

            if (!File.Exists(fileName))
            {
                message = "配置文件不存在！";
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                message = "查找的节点不存在！";
                return false;
            }

            XmlElement xmlEle = xmlNode as XmlElement;

            XmlAttribute attribute = xmlEle.GetAttributeNode(attributeName);
            if (attribute == null)
            {
                message = "查找的节点属性不存在！";
                return false;
            }

            //删除节点属性
            xmlEle.RemoveAttribute(attributeName);

            return true;
        }

        /// <summary>
        /// 检查节点是否存在
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <returns></returns>
        public static bool IsNodeExists(string fileName, string xmlPath)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查节点属性是否存在
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="attributeName">Xml节点属性</param>
        /// <returns></returns>
        public static bool IsAttributeExists(string fileName, string xmlPath, string attributeName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                return false;
            }

            XmlElement xmlEle = xmlNode as XmlElement;

            XmlAttribute attribute = xmlEle.GetAttributeNode(attributeName);
            if (attribute == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取Xml路径对应的实体类
        /// </summary>
        /// <param name="fileName">Xml配置文件路径</param>
        /// <param name="xmlPath">Xml节点路径</param>
        /// <param name="configType">转换类型</param>
        /// <returns></returns>
        public static object GetXmlNodeEntity(string fileName, string xmlPath, SysConfig configType)
        {
            if (!File.Exists(fileName))
            {
                goto DefaultValue;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            //获取根节点
            XmlNode xmlRoot = xmlDoc.SelectSingleNode("Config");

            xmlPath = xmlPath.Trim('/');
            XmlNode xmlNode = xmlRoot.SelectSingleNode(xmlPath);
            if (xmlNode == null)
            {
                goto DefaultValue;
            }
            else
            {
                switch (configType)
                {
                    case SysConfig.VideoChannel:
                        VideoChannel channel = new VideoChannel();
                        channel.IpAddress = xmlNode.SelectSingleNode("IpAddress").InnerText;
                        channel.PortNumber = int.Parse(xmlNode.SelectSingleNode("PortNumber").InnerText);
                        channel.UserName = xmlNode.SelectSingleNode("UserName").InnerText;
                        channel.PassWord = xmlNode.SelectSingleNode("PassWord").InnerText;
                        channel.ChannelNo = xmlNode.SelectSingleNode("ChannelNo").InnerText.ToInt();
                        return channel;
                    default:
                        return null;
                }
            }

        DefaultValue:
            switch (configType)
            {
                case SysConfig.VideoChannel:
                    return null;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="xmlPath"></param>
        public static void Serialize<T>(T t, string xmlPath)
        {
            StreamWriter sw = new StreamWriter(xmlPath);
            Type type = t.GetType();
            //创建XML命名空间
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xml = new XmlSerializer(type);
            xml.Serialize(sw, t, ns);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlPath)
        {
            try
            {
                if (File.Exists(xmlPath))
                {
                    FileStream file = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
                    XmlSerializer xmlSearializer = new XmlSerializer(typeof(T));
                    T entity = (T)xmlSearializer.Deserialize(file);
                    file.Close();
                    return entity;
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
