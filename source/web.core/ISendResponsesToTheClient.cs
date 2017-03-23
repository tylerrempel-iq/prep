namespace code.web.core
{
  public interface ISendResponsesToTheClient
  {
    void send<Data>(Data data);
  }
}