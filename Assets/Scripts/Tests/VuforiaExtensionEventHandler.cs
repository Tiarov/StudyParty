public class VuforiaExtensionEventHandler : DefaultTrackableEventHandler
{
    public System.Action TrackingFoundEvent;
    public System.Action TrackingLostEvent;

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        if (TrackingLostEvent != null)
            TrackingLostEvent();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        if (TrackingFoundEvent != null)
            TrackingFoundEvent();
    }
}
