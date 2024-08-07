namespace TylerDM.StandardLibrary.Parameters;

public static class UrlFactory
{
	#region methods
	public static string Create(string endpoint, params IWebParameter?[] parameters) =>
		Create(endpoint, (IReadOnlyCollection<IWebParameter?>)parameters);

	public static string Create(string endpoint, IReadOnlyCollection<IWebParameter?> parameters)
	{
		var url = endpoint;
		var queryString = CreateQueryString(parameters);
		if (!string.IsNullOrWhiteSpace(queryString))
			url += "?" + queryString;
		return url;
	}

	public static string CreateQueryString(IReadOnlyCollection<IWebParameter?> parametersNullable)
	{
		var parameters = parametersNullable.WhereNotNull().ToList();
		if (parameters.None()) return string.Empty;

		var stringBuilder = new StringBuilder();
		foreach (var parameter in parameters)
			stringBuilder.Append($"{parameter.ParameterName}={parameter.ParameterValue}&");
		stringBuilder.RemoveFromEnd(1);
		return stringBuilder.ToString();
	}
	#endregion
}