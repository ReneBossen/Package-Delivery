using System;

public static class PackageEventHandler
{
    public static event EventHandler PackagedPickedUp;
    public static event EventHandler CostumerRecievedPackage;
    public static event EventHandler SpeedUpPickedUp;

    public static void ResetStaticData()
    {
        PackagedPickedUp = null;
        CostumerRecievedPackage = null;
        SpeedUpPickedUp = null;
    }
    public static void RaisePackagePickedUp(object sender, EventArgs args)
    {
        PackagedPickedUp?.Invoke(sender, args);
    }
    public static void RaiseCostumerRecievedPackage(object sender, EventArgs args)
    {
        CostumerRecievedPackage?.Invoke(sender, args);
    }
    public static void RaiseSpeedUpPickedUp(object sender, EventArgs args)
    {
        SpeedUpPickedUp?.Invoke(sender, args);
    }
}
