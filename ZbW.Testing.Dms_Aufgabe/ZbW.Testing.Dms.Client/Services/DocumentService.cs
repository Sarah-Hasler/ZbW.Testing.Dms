using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
	public class DocumentService
	{
		private static String FILE_TYPE_NAME = "Content";
		private static String METASATA_TYPE_NAME = "Metadata";

		private String _targePath;

		private FileService _fileService;

		public DocumentService()
		{
			this._targePath = ConfigurationManager.AppSettings["RepositoryDir"];
			this._fileService = new FileService();
		}

		internal void AddDocumentToDms(MetadataItem metadataItem)
		{
			var targetPath = this._targePath + "/" + metadataItem.ValutaDatum.Year;
			_fileService.CreateValutaFolderIfNotExists(targetPath);
			var guid = Guid.NewGuid();

			this.HandelDocument(metadataItem, targetPath, guid);
			this.HandelMetadata(metadataItem, targetPath, guid);
		}

		private void HandelDocument(MetadataItem metadataItem, String targetPath, Guid guid)
		{
			var newFileName = _fileService.GetNewFileName(FILE_TYPE_NAME, metadataItem.FilePath, guid);
			var sourcePath = metadataItem.FilePath;
			targetPath = targetPath + "/" + newFileName;
			_fileService.CopyDocumentToTarge(sourcePath, targetPath);

			if (metadataItem.IsRemoveFileEnabled)
			{
				_fileService.RemoveDocumentOnSource(metadataItem.FilePath);
			}
		}

		private void HandelMetadata(MetadataItem metadataItem, String targetPath, Guid guid)
		{
			var xmlService = new XmlService();
			var newFileName = _fileService.GetNewFileName(METASATA_TYPE_NAME, ".xml", guid);

			var serializeXml = xmlService.SeralizeMetadataItem(metadataItem);
			xmlService.SaveXml(serializeXml, targetPath + "/" + newFileName);
		}
	}
}