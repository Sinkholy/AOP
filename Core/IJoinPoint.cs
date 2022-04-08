using System;
using System.Reflection;

namespace Core
{
	public class JoinPoint
	{
		Context JPContext { get; }
		Metadata JPMetadata { get; }

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
			string Name { get; }
			Type JoinPointType { get; }
			System.Type DeclaredIn { get; }
			Parameter[] Parameters { get; }
			bool ContainsParameters => Parameters != null && Parameters.Length != 0;
			System.Type ReturnType { get; }
			MemberInfo MemberInfo { get; }

			public class Parameter
			{
				string Name { get; }
				System.Type Type { get; }
				ParameterInfo ParameterInfo { get; }
			}
			enum Type : byte
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
