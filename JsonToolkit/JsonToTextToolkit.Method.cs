using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace JsonToolkit;

partial class JsonToTextToolkit
{
	private string _inputText;

	public string InputText
	{
		get { return _inputText; }
		set { _inputText = value; }
	}


	public async Task<JsonToolkitNode> ExecuteAsync()
	{
		if (InputText == null)
			return null;
		JsonNode jsonParser = JsonObject.Parse(InputText);
		var obj = jsonParser.AsObject();
		foreach (var item in obj)
		{
			Debug.WriteLine(item.Key+""+item.Value);

		}
		return new();
	}
}

public class JsonToolkitNode
{
}