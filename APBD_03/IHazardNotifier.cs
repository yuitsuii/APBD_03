namespace APBD_03;

public interface IHazardNotifier
{
    void SendHazardNotification(string message, string containerNumber);
}