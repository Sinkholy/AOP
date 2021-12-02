using Mono.Cecil;

using System;

namespace AOP.ModuleProvider
{
	public class ModuleProvider
	{
		public ModuleProvidingResult GetModuleFromPath(string path, string moduleName)
		{
			// Если path == null или пустой
				// Вернуть отрицательный результат с параметрами:
					// errorDesc - path == null или пустой
					// Exception - ArgumentException
			// Если moduleName == null или пустой
				// Вернуть отрицательный результат с параметрами:
					// errorDesc - передан невалидный путь
					// Exception - ArgumentException
			// Объявить переменную типа string fullPath
			// Объявить переменную типа ModuleDefenition result
			// Проверить содержит ли переменная path расширение файла
			// Если содержит
				// Вычленить имя файла, указанного в path
				// Сравнить полученое имя файла с moduleName
				// Если они совпадают
					// Присвоить значение path в переменную fullPath
			// Иначе
				// Проверить содержит ли переменная path сепаратора (\) в окончании
					// Если не содержит
						// Добавить сепаратор к окончанию
				// Проверить содержит ли переменная moduleName расширение файла
					// Если не содержит
						// Вернуть отрицательный результат с параметрами:
							// errorDesc - передано невалидное название модуля
							// Exception - ArgumentException
					// Иначе
						// Скомбинировать path и moduleName и присвоисть результат в fullPath
			try
			{
				// Получить ModuleDefenition используя fullPath
			}
			catch // Исключение ввода-вывода
			{
				// Вернуть отрицательный результат с параметрами:
					// errorDesc - невозможно получить доступ к файлу модуля
					// Exception - ArgumentException
			}
			catch // Другие исключения
			{
				// Вернуть отрицательный результат с параметрами:
					// errorDesc - ошибка про чтении модуля
					// Exception - ArgumentException
			}
			// Вернуть положительный результат с параметрами:
				// Result = result
			return null;
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

			public bool IsSuccessFull => ErrorDescription != null;
			public string ErrorDescription { get; private set; }
			public Exception Exception { get; private set; }
			public ModuleDefinition Result { get; private set; }
		}
	}
}
