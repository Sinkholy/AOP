namespace Core
{
	public interface IAspectPresentation
	{
		AspectBase Aspect { get; }
		IPointcutPresentation[] Pointcuts { get; }

		public interface IPointcutPresentation
		{
			AspectBase.PointcutBase Pointcut { get; }
			IAdvicePresentationBase[] Advices { get; }
		}
		public interface IAdvicePresentationBase
		{
			AspectBase.AdviceBase Advice { get; }
		}
	}
}
