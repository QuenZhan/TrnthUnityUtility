using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
namespace TRNTH
{
    [System.Serializable]public class DiskSaveLoad{
		enum SaveFileFormmat{
			Binary,XML
		}
		[SerializeField]SaveFileFormmat _SaveFileFormmat;
		void Serialize<T>(FileStream stream,T data){
			switch(_SaveFileFormmat){
			case SaveFileFormmat.Binary:
				var  serializer=new BinaryFormatter();
				serializer.Serialize(stream,data);
				break;
			case SaveFileFormmat.XML:
				var serializerXml=new XmlSerializer(typeof(T));
				serializerXml.Serialize(stream,data);
				break;
			}
		}
		T Deserialize<T>(FileStream file){
			switch(_SaveFileFormmat){
			case SaveFileFormmat.Binary:
				var  serializer=new BinaryFormatter();
				return (T)serializer.Deserialize(file);
			case SaveFileFormmat.XML:
				var serializerXml=new XmlSerializer(typeof(T));
				return (T)serializerXml.Deserialize(file);
			default:return default(T);
			}
		}
		[SerializeField]string _path;
		string SaveFilePath{
			get{
				if(string.IsNullOrEmpty(_path)){
					_path=Application.persistentDataPath +"/";
				}
				return _path+_fileName;
			}
		}
		const string DefaultFileName="gamesave.save";
		[SerializeField]string _fileName=DefaultFileName;
		public void SaveToFile(object userdata,string filename=DefaultFileName){
			_fileName=filename;
			if(File.Exists(SaveFilePath))File.Delete(SaveFilePath);
			using(FileStream file = File.Create( SaveFilePath)) {
				Serialize(file,userdata);
				file.Close();
			}
		}
		
		public T LoadFromFile<T>(string filename=DefaultFileName){
			_fileName=filename;
			T UserData=default(T);
			if(File.Exists(SaveFilePath)){
				using(FileStream file = File.Open( SaveFilePath, FileMode.Open)) {
					file.Position=0;
					try{
						UserData=Deserialize<T>(file);
					}
					catch(System.Exception e){
						Debug.LogWarning(e);
					}
					file.Close();
				}
			}
			return UserData;
		}
	}

}
