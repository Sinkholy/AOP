﻿using System;

namespace Core
{
	// Задача:
		// во время выполнения необходимо создавать экземпляры типов реализующих контракты.
		// Для этого необходимо иметь публичный беспараметровый конструктор.
	
	// Варианты решения:
		// 1) Объявить всё семейство как интерфейсы и указать пользователю каким-то образом на то, 
		// что необходимо оставить базовый конструктор без переопределения.
		// 2) Объявить всё как абстрактные классы и явно оставить публичный беспараметровый конструктор.

	// Обоснование выбора:
		// Я решил, что оставлять необходимый аспект для работы приложения
		// на откуп пользователю - не очень хорошее решение т.к.
		// нет никакой возможности явно ограничить пользователя в переопределении
		// конструктора при использовании интерфейсов. В таком случае необходимо
		// будет проверять наличие возможности создать экземпляр и при её отсутствии 
		// пробрасывать исключение. Зачем, если можно изначально явно указать на свои намерения.
	public abstract class Aspect
	{
		public Aspect() { }

		public abstract class Pointcut
		{
			public Pointcut() { }

			public abstract bool IsMatching(IJoinPoint.IMetadata joinPoint);
		}
		public abstract class Advice
		{
			public abstract Type TargetPointcut { get; }	// Нужна ли возможность иметь несколько поинткатов?
															// Так же можно вынести это в атрибут к Advice
															// И там же добавить вариант поиска поинтката - глобальный или локальный (внутри аспекта)
			// TODO: мои мысли таковы: 
			// Либо оставлять ссылку на срез именно в форме как это реализовано сейчас
			// Либо применять атрибут к самому классу AdviceBase
			// я не могу определиться с тем, что лучше

			public Advice() { }

			public abstract void MakeAdvice(IJoinPoint joinPoint);
		}
	}
}
