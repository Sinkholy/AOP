namespace Core
{
	public interface IAspectPresentation
	{
		Aspect Aspect { get; }
		IPointcutPresentation[] Pointcuts { get; }

		public interface IPointcutPresentation
		{
			Aspect.Pointcut Pointcut { get; }
			IAdvicePresentationBase[] Advices { get; }
		}
		public interface IAdvicePresentationBase
		{
			Aspect.Advice Advice { get; }
		}
	}
}
