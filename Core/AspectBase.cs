namespace Core
{
	public abstract class AspectBase
	{
		public AspectBase() { }

		public abstract class PointcutBase
		{
			public PointcutBase() { }

			public abstract bool IsMatching(IJoinPoint.IMetadata joinPoint); // TODO: Мне не нравится нейминг
		}
		public abstract class AdviceBase
		{
			public abstract string PointcutName { get; }
			// TODO: мои мысли таковы: 
			// Либо оставлять ссылку на срез именно в форме как это реализовано сейчас
			// Либо применять атрибут к самому классу AdviceBase
			// я не могу определиться с тем, что лучше

			public AdviceBase() { }

			public abstract void MakeAdvice(IJoinPoint.IContext joinPoint);
		}
	}
}
