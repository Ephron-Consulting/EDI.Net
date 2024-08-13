namespace indice.Edi.Extensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public class EdiDecimalValueAttribute : indice.Edi.Serialization.EdiValueAttribute
{
	public EdiDecimalValueAttribute(bool mandatory, string path, int dataElement, ushort integerWidth, byte fractionalWidth = 0)
	{
		this.Mandatory = mandatory;
		this.Path = path;
		this.DataElement = dataElement;
		this.IntegerWidth = integerWidth;
		this.FractionalWidth = fractionalWidth;
	}

	public ushort IntegerWidth { get; set; } = 1;
	public ushort FractionalWidth { get; set; } = 1;
	public int DataElement { get; set; }
}