﻿using System;
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
			// TODO: ret type?
			// TODO: jp signature?
			public string DeclaredInTypeName { get; }
			public string DeclaredInTypeFullName { get; }
			public string Name { get; }
			public JoinpointType JPType { get; }
			public Parameter[] Parameters { get; }
			public bool ContainsParameters => Parameters != null && Parameters.Length != 0;

			// TODO: кеширование
			public Type GetDeclaredType()
			{
				return Type.GetType(DeclaredInTypeFullName);
			}
			public MemberInfo GetJoinpointInfo() // TODO: Уверен ли ты в том, что тебе нужен именно MemberInfo, но не MethodBase?
			{
				return GetDeclaredType().GetMember(Name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)[0]; // TODO: очень не нравится
			}
			public ParameterInfo[] GetParametersInfo()
			{
				return GetJoinpointInfo() is MethodBase method 
					? method.GetParameters() 
					: Array.Empty<ParameterInfo>();
			}

			public class Parameter
			{
				public string Name { get; }
				public string TypeName { get; }
				public int Position { get; }
			}
			public enum JoinpointType : byte
			{
				PropertyGetter,
				PropertySetter,
				EventAdd,
				EventRemove,
				Method,
				Constructor
			}
		}
	}
}
