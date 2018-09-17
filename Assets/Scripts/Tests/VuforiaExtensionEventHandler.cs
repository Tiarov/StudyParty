
using UnityEngine;
using Vuforia;

public class VuforiaExtensionEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public TrackableBehaviour MTrackableBehaviour;

    public System.Action TrackingFoundEvent;
    public System.Action TrackingLostEvent;

    private void Start()
    {
        if (MTrackableBehaviour)
        {
            MTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    public void OnTrackingLost()
    {
        if (TrackingLostEvent != null)
            TrackingLostEvent();
    }

    public void OnTrackingFound()
    {
        if (TrackingFoundEvent != null)
            TrackingFoundEvent();
    }

}
