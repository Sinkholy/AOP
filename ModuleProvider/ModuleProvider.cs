using Mono.Cecil;

using System;

namespace AOP.ModuleProvider
{
	public class ModuleProvider
	{
		const string DirectorySeparator = @"\";

		public ModuleProvidingResult GetModuleFromPath(string path, string moduleName)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				string errorDesc = "";
				ArgumentNullException ex = new (nameof(path), errorDesc);
				return ModuleProvidingResult.Failed(errorDesc, ex);
			}
			if (string.IsNullOrWhiteSpace(moduleName))
			{
				string errorDesc = "";
				ArgumentNullException ex = new (nameof(moduleName), errorDesc);
				return ModuleProvidingResult.Failed(errorDesc, ex);
			}
			if (PathContainsFileExtension())
			{
				string errorDesc = "";
				ArgumentException ex = new (errorDesc, nameof(path));
				return ModuleProvidingResult.Failed(errorDesc, ex);
			}
			if (!PathEndsWithSeparator())
			{
				path += DirectorySeparator;
			}

			ModuleDefinition result;
			string fullPath = path + moduleName;

			try
			{
				result = ModuleDefinition.ReadModule(fullPath);
			}
			catch(Exception ex)
			{
				return ModuleProvidingResult.Failed(ex.Message, ex);
			}
			return ModuleProvidingResult.Successfull(result);

			bool PathContainsFileExtension()
			{
				return false;
			}
			bool PathEndsWithSeparator()
			{
				return true;
			}
		}

		public class ModuleProvidingResult
		{
			internal ModuleProvidingResult(string errorDescription, Exception exception, ModuleDefinition result)
			{
				ErrorDescription = errorDescription;
				Exception = exception;
				Result = result;
			}

			internal static ModuleProvidingResult Successfull(ModuleDefinition result) => new(null, null, result);
			internal static ModuleProvidingResult Failed(string errorDesc, Exception exception = null) => new(errorDesc, exception, default);

			public bool IsSuccessFull => ErrorDescription == null;
			public string ErrorDescription { get; private set; }
			public Exception Exception { get; private set; }
			public ModuleDefinition Result { get; private set; }
		}
	}
}
