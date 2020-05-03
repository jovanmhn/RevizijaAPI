using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace RevizijaAPI.Klase
{
    [Serializable]
    public class Configuration
    {
        public static Configuration Current { get; set; }

        public static Configuration Load(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                StreamReader reader = new StreamReader(fileName);
                var Config = (Configuration)serializer.Deserialize(reader);
                Config.FileName = fileName;

                reader.Close();
                return Current = Config;
            }
            catch
            {
                return Current = new Configuration { FileName = fileName, Connection = new ServerConnection() };
            }
        }

        public void Save()
        {
            Save(FileName);
        }
        public void Save(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            TextWriter textWriter = new StreamWriter(fileName);
            serializer.Serialize(textWriter, this);
            textWriter.Close();
        }

        private string FileName { get; set; }

        [XmlElement("Connection")]
        public ServerConnection Connection { get; set; }

        public class ServerConnection : IEditableObject
        {
            [XmlAttribute]
            public string Server { get; set; }
            [XmlAttribute]
            public bool IntegratedSecurity { get; set; }
            [XmlAttribute]
            public string UserId { get; set; }
            [XmlAttribute]
            public string Password { get; set; }
            [XmlIgnore]
            public string PasswordPlain
            {
                get
                {
                    try { return Base64Decode(this.Password); }
                    catch { return null; }
                }
                set
                {
                    this.Password = Base64Encode(value);
                }
            }
            [XmlAttribute]
            public string Database { get; set; }

            private ServerConnection Original { get; set; }
            private void CopyTo(ServerConnection dest)
            {
                dest.Server = Server;
                dest.IntegratedSecurity = IntegratedSecurity;
                dest.UserId = UserId;
                dest.PasswordPlain = PasswordPlain;
                dest.Database = Database;
            }
            public void BeginEdit()
            {
                Original = Clone();
            }
            public void CancelEdit()
            {
                Original.CopyTo(this);
            }
            public void EndEdit()
            {
                Original = null;
            }

            public string GetDataSource()
            {
                return String.Format("data source={0};Integrated Security={1};user id={2};password={3};initial catalog={4};MultipleActiveResultSets=True;App=EntityFramework", Server, IntegratedSecurity ? "True" : "False", UserId, PasswordPlain, Database);
            }
            public string GetConnection()
            {
                return GetConnection("*", "Models.Database.Model");
            }
            public string GetConnection(string assembly, string entity)
            {
                return String.Format("metadata=res://{0}/{1}.csdl|res://{0}/{1}.ssdl|res://{0}/{1}.msl;provider=System.Data.SqlClient;provider connection string=\"{2}\"", assembly, entity, GetDataSource());
            }

            public bool TestConnection(bool throwError = false)
            {
                bool returnValue;

                try
                {
                    SqlConnection sql = new SqlConnection(GetDataSource());
                    sql.Open();
                    sql.Close();
                    returnValue = true;
                }
                catch (Exception ex)
                {
                    returnValue = false;
                    if (throwError)
                        throw new Exception("Connection error!", ex);
                }
                return returnValue;
            }

            public ServerConnection Clone()
            {
                return (ServerConnection)this.MemberwiseClone();
            }



            private static string Base64Encode(string plainText)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }

            private static string Base64Decode(string base64EncodedData)
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
        }
    }
}