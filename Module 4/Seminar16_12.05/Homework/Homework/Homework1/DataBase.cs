using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Homework {

    class DataBase {
        public string Name { get; }

        private IDictionary<Type, object> Tables = new Dictionary<Type, object>();

        private const string dataBasesPath = "..\\..\\..\\..\\Databases\\";

        public DataBase(string name) => this.Name = name;

        public void CreateTable<T>() where T : IEntity {
            Type tableType = typeof(T);

            if (Tables.ContainsKey(tableType)) {
                throw new DataBaseException($"Table already exists {tableType.Name}!");
            }

            Tables[tableType] = new List<T>();
        }

        public void InsertInto<T>(IEntityCreator<T> values) where T : IEntity {
            Type tableType = typeof(T);

            if (!Tables.ContainsKey(tableType)) {
                throw new DataBaseException($"Unknown table {tableType.Name}!");
            }

            ((List<T>)Tables[tableType]).Add(values.Instance);
        }

        public IEnumerable<T> Table<T>() where T : IEntity {
            Type tableType = typeof(T);

            if (!Tables.ContainsKey(tableType)) {
                throw new DataBaseException($"Unknown table {tableType.Name}!");
            }

            return (IEnumerable<T>)Tables[tableType];
        }

        public void SerializeDataBase() {
            try {
                string folderPath = Path.GetFullPath(DataBase.dataBasesPath + this.Name);
                if (Directory.Exists(folderPath)) { throw new DataBaseException("Serialization-required folder already exists - the serialization process is cancelled"); }
                Directory.CreateDirectory(folderPath);
                this.SerializeEachTable(folderPath);
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }

        }

        private void SerializeEachTable(string folderPath) {
            foreach (Type type in this.Tables.Keys) {
                string tableFilePath = Path.GetFullPath(folderPath + "\\" + $"DB{type.Name}.json");
                using (FileStream outputStream = new FileStream(tableFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                    using (StreamWriter writer = new StreamWriter(outputStream)) {
                        writer.WriteLine(JsonSerializer.Serialize(this.Tables[type]));
                    }
                }
            }
        }

        public void DeserializeDataBase(string dataBaseName) {
            string dataBasePath = Path.GetFullPath(DataBase.dataBasesPath + dataBaseName);
            try {
                this.Tables = this.DeserializeEachTable(dataBasePath);
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }

        private Dictionary<Type, object> DeserializeEachTable(string dataBasePath) {
            Dictionary<Type, object> result = new Dictionary<Type, object>();
            foreach (string filePath in Directory.GetFiles(dataBasePath)) {
                FileInfo fileInfo = new FileInfo(filePath);
                int firstIndex = fileInfo.Name.IndexOf('B') + 1;
                int lastIndex = fileInfo.Name.LastIndexOf('.');
                // Часть кода, для работоспособности которой запрещено менять неймспейсы "сущностей".
                Type tableType = Type.GetType("Homework." + fileInfo.Name.Substring(firstIndex, lastIndex - firstIndex));
                if (result.ContainsKey(tableType)) { throw new DataBaseException($"The uploaded database already has a {tableType.Name}-type table"); }
                using (FileStream input = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                    using (StreamReader reader = new StreamReader(input)) {
                        result.Add(tableType, JsonSerializer.Deserialize(reader.ReadToEnd(), tableType));
                    }
                }
            }
            return result;
        }

    }
}
