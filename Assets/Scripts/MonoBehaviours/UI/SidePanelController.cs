using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.UI
{
    public class SidePanelController : MonoBehaviour
    {
        public Animation Animation;

        private string _closeAnimName= "SidePanel_Close";
        private string _openAnimName= "SidePanel_Open";

        public void Open()
        {
            PlayAnim(_openAnimName);
        }

        public void Close()
        {
            PlayAnim(_closeAnimName);
        }

        private void PlayAnim(string name)
        {
            Animation.Play(name);
        }
    }
}
