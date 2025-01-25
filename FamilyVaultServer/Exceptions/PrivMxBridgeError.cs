[Serializable]
public class PrivMxBridgeException : Exception
{
	public PrivMxBridgeException() { }
	public PrivMxBridgeException(string message) : base(message) { }
	public PrivMxBridgeException(string message, Exception inner) : base(message, inner) { }
}