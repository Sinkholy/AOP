using System;
using System.Reflection;

namespace Core
{
	public class JoinPoint
	{
		public Context JPContext { get; }
		public Metadata JPMetadata { get; }

		public class Context
		{
			// TODO: решить вопрос с тем нужно ли вообще передавать переменные.
			public Argument[] Arguments { get; }

			public class Argument
			{
				public Metadata.Parameter Parameter { get; }
				public object? Value { get; }
			}
		}
		public class Metadata
		{
			public string Name { get; }
			public Type JoinPointType { get; }
			public System.Type DeclaredIn { get; }
			public Parameter[] Parameters { get; }
			public bool ContainsParameters => Parameters != null && Parameters.Length != 0;
			public System.Type ReturnType { get; }
			public MemberInfo MemberInfo { get; }

			public class Parameter
			{
				public string Name { get; }
				public System.Type Type { get; }
				public ParameterInfo ParameterInfo { get; }
			}
			public enum Type : byte
			{
				Getter,
				Setter,
				Method,
				Constructor
				// TODO: etc
			}
		}
	}
}
