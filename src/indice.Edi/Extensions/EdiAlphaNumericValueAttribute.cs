namespace indice.Edi.Extensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public class EdiAlphaNumericValueAttribute : indice.Edi.Serialization.EdiValueAttribute
{
	public EdiAlphaNumericValueAttribute(bool mandatory, string path, int dataElement, ushort minimumLength, ushort maximumLength)
	{
        base.Mandatory = mandatory;
        base.Path = path;
		this.DataElement = dataElement;
		this.MinimumLength = minimumLength;
		this.MaximumLength = maximumLength;
		base.picture = new(maximumLength, PictureKind.Alphanumeric);
	}

	public ushort MinimumLength { get; set; } = 1;
	public ushort MaximumLength { get; set; } = 1;
	public int DataElement { get; set; }
	//public Type? ConstrainedValues { get; set; }
}
