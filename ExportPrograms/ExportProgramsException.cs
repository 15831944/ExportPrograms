using System;
using System.Collections.Generic;
using System.Text;

namespace ExportPrograms {
  [Serializable]
  public class ExportProgramsException : Exception {
    public ExportProgramsException() { }
    public ExportProgramsException(string message) : base(message) { }
    public ExportProgramsException(string message, Exception inner) : base(message, inner) { }
    protected ExportProgramsException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
