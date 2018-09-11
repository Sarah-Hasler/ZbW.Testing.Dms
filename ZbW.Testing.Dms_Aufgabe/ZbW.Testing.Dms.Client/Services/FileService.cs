using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services {
	public class FileService {

		public void CreateValutaFolderIfNotExists(string path) {
			Directory.CreateDirectory(path);
		}

		public void RemoveDocumentOnSource(string path) {
			File.Delete(path);
		}

		public void CopyDocumentToTarge(String sourcePath, String targetPath) {
			File.Copy(sourcePath, targetPath, true);
		}

		public String GetNewFileName(String typeName, String fileName, Guid guid) {
			var fileExtension = this.GetFileExtension(fileName);
			return $"{guid}_{typeName}.{fileExtension}";
		}

		public String GetFileExtension(String fileName) {
			var splittedByPoint = fileName.Split('.');
			return splittedByPoint[splittedByPoint.Length - 1];
		}
	}
}
