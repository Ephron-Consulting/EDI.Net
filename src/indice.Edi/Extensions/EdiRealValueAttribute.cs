namespace indice.Edi.Extensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public class EdiRealValueAttribute : indice.Edi.Serialization.EdiValueAttribute
{
	public EdiRealValueAttribute(bool mandatory, string path, int dataElement, ushort integerWidth)
	{
		this.Mandatory = mandatory;
		this.Path = path;
		this.DataElement = dataElement;
		this.IntegerWidth = integerWidth;
	}

	public ushort IntegerWidth { get; set; }
	public int DataElement { get; set; }
}