using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
	    public String Bezeichnung;
	    public String Benutzer;
	    public DateTime Erfassungsdatum;
	    public String FilePath;
	    public Boolean IsRemoveFileEnabled;
	    public String Type;
	    public String Stichwoerter;
	    public DateTime ValutaDatum;

	    public MetadataItem() {
	    }

		MetadataItem(
			String bezeichnung,
			DateTime erfassungsdatum,
			String filePath,
			Boolean isRemoveFileEnabled,
			String type,
			String stichwoerter,
			DateTime valutaDatum,
			String benutzer)
	    {
		    this.Bezeichnung = bezeichnung;
		    this.Benutzer = benutzer;
		    this.Erfassungsdatum = erfassungsdatum;
		    this.FilePath = filePath;
		    this.IsRemoveFileEnabled = isRemoveFileEnabled;
		    this.Type = type;
		    this.Stichwoerter = stichwoerter;
		    this.ValutaDatum = valutaDatum;
	    }
    }
}