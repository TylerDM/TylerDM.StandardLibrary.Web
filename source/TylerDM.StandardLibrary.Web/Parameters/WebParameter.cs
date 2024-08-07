namespace TylerDM.StandardLibrary.Parameters;

public record WebParameter(
	string Name,
	string Value
) : IWebParameter
{
	#region properties
	string IWebParameter.ParameterName => Name;
	string IWebParameter.ParameterValue => Value;
	#endregion

	#region constructors
	public WebParameter(string name, object value) : this(name, value?.ToString() ?? string.Empty)
	{
	}

	public WebParameter(int id) : this(nameof(id), id)
	{
	}

	public WebParameter(Guid id) : this(nameof(id), id)
	{
	}
	#endregion
}