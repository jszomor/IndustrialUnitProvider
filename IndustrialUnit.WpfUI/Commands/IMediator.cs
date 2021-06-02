namespace IndustrialUnit.WpfUI.Commands
{
  public interface IMediator
  {
    TResponse Send<TRequest, TResponse>(TRequest request);
  }
}