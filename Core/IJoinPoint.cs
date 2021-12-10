using System;
using System.Reflection;

namespace Core
{
	public interface IJoinPoint
	{
		IContext Context { get; }
		IMetadata Metadata { get; }

		public interface IContext
		{
			IArgument[] Arguments { get; }
			IVariable[] Variables { get; }

			public interface IEntity
			{
				string Name { get; }
				Type Type { get; }
				object Value { get; }
			}
			public interface IVariable : IEntity
			{
			}
			public interface IArgument : IEntity
			{
			}
		}
		public interface IMetadata
		{
			string Name { get; }
			Type JoinPointType { get; }
			System.Type DeclaredIn { get; }
			IParameter[] Parameters { get; }
			bool ContainsParameters => Parameters != null && Parameters.Length != 0;
			System.Type ReturnType { get; }
			MemberInfo MemberInfo { get; }

			interface IParameter
			{
				// TODO: нужен ли вообще этот интерфейс?
				// Сейчас я использую его как некий shortcut для ParameterInfo
				// т.к. Name и Type просто обращаются к ParameterInfo
				// В принципе это выглядит более "user friendly"
				// Но это так же может усложнять структуру
				// Нужно решить:
				// - Оставить всё какесть
				// - Избавиться от интерфейса и использовать ParameterInfo напрямую
				// - Избавиться от ParameterInfo и добавлять сущности по необходимости
				// Так же всё вышесказанное вполне относится к IMetadata ^^^
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
