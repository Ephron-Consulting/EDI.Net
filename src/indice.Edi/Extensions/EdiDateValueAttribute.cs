namespace indice.Edi.Extensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public class EdiDateValueAttribute : indice.Edi.Serialization.EdiValueAttribute
{
	public EdiDateValueAttribute(bool mandatory, string path, int dataElement)
	{
		base.Mandatory = mandatory;
		base.Path = path;
		this.DataElement = dataElement;

		base.picture = new(8);
		base.Format = "yyyyMMdd";
	}

	public int? DataElement { get; set; }
}