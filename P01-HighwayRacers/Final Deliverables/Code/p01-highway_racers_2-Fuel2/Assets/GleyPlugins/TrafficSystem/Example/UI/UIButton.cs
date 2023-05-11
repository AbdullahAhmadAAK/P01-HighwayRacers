using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GleyTrafficSystem
{
    public class UIButton : Button
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        public override void OnPointerDown(PointerEventData eventData)
        {
            UIInput.TriggerButtonDownEvent(gameObject.name);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            UIInput.TriggerButtonUpEvent(gameObject.name);
            base.OnPointerUp(eventData);
        }
#endif
    }
}
