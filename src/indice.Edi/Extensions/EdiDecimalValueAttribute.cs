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

    public string? ToX12(decimal? value) {
        if (value.HasValue) {
            return ((int)(decimal.Parse(value.Value.ToString($"N{this.FractionalWidth}")) * (int)Math.Pow(10, this.FractionalWidth))).ToString();
        }
        return null;
    }

    public bool IsDecimalValid(decimal? value, out int rightWidth) {
        rightWidth = -1;
        if (value.HasValue) {
            try {
                var stringValue = value.Value.ToString();

                var decimalIndex = stringValue.IndexOf('.');
                rightWidth = stringValue.Length - (decimalIndex == -1 ? stringValue.Length : ++decimalIndex);
                if (rightWidth > this.FractionalWidth) {
                    return false;
                }
            } catch (Exception _) {
                return false;
            }
        }
        return true;
    }

    public bool IsWidthValid(decimal? value, out int actualWidth) {
        actualWidth = -1;
        if (value.HasValue) {
            try {
                var stringValue = value.Value.ToString();
                stringValue = ToX12(value).Replace("-", string.Empty);
                actualWidth = stringValue.Length;
                if (this.IntegerWidth + this.FractionalWidth < actualWidth) {
                    return false;
                }
            } catch (Exception _) {
                return false;
            }
        }
        return true;
    }
}