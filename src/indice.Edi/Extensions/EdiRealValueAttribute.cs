namespace indice.Edi.Extensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public class EdiRealValueAttribute : indice.Edi.Serialization.EdiValueAttribute
{
	public EdiRealValueAttribute(bool mandatory, string path, int dataElement, ushort width)
	{
		this.Mandatory = mandatory;
		this.Path = path;
		this.DataElement = dataElement;
		this.Width = width;
	}

    public ushort Width { get; set; }
    public int DataElement { get; set; }

    /// <returns></returns>
    public string? ToX12(decimal? value) {
        if (value.HasValue) {
            string strValue = value.Value.ToString();
            var left = strValue.IndexOf('.');
            int adjustedLength = strValue.Length - (left > -1 ? 1 : 0) - (strValue.IndexOf('-') > -1 ? 1 : 0) - (left > 0 && int.Parse(strValue[..left]) == 0 ? left : 0);
            if (this.Width > 0 && adjustedLength > this.Width) {
                // Trim fractional  portion
                strValue = strValue[..(this.Width + strValue.Length - adjustedLength)];
            }
            return strValue;
        }
        return null;
    }

    public bool IsWidthValid(decimal? value, out int adjustedLength) {
        if (value.HasValue) {
            try {
                string strValue = value.Value.ToString();
                adjustedLength = strValue.IndexOf('.') - (strValue.IndexOf('-') > -1 ? 1 : 0);
                if(adjustedLength > this.Width) {
                    return false;
                }
            } catch (Exception ex) {
                adjustedLength = -1;
                return false;
            }
        }
        else {
            adjustedLength = 0;
        }
        return true;
    }
}