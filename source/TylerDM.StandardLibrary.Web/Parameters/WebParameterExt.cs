namespace TylerDM.StandardLibrary.Parameters;

public static class WebParameterExt
{
	public static KeyValuePair<string, string> ToKeyValuePair(this IWebParameter parameter) =>
		new(parameter.ParameterName, parameter.ParameterValue);

	public static FormUrlEncodedContent ToFormUrlEncoded(this IEnumerable<IWebParameter> parameters) =>
		new(parameters.Select(x => x.ToKeyValuePair()));
}