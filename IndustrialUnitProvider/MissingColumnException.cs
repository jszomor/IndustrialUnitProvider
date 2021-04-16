using System;

namespace IndustrialUnitProvider
{
  [Serializable]
  public class MissingColumnException : Exception
  {
    public MissingColumnException() : base() { }
    public MissingColumnException(string message) : base(message) { }
    public MissingColumnException(string message, Exception inner) : base(message, inner) { }

    protected MissingColumnException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }
}
