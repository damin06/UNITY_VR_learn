#define PC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VR_Input 
{
    public static void Recenter(Transform target, Vector3 direction)
    {
        target.forward = target.rotation * direction;
    }
    
    public static float GetAxis(string axis, Controller hand = Controller.LTouch)
    {
#if PC
        return Input.GetAxis(axis);
#endif
    }

    #if PC
    public enum ButtonTarget
    {
        Fire1,
        Fire2,
        Fire3,
        Jump,
    }
    #endif

    public enum Button
    {
#if PC
        One = ButtonTarget.Fire1,
        Two = ButtonTarget.Jump,
        Thumbstick = ButtonTarget.Fire1,
        IndexTrigger = ButtonTarget.Fire3,
        HandTrigger = ButtonTarget.Fire2
#endif        
    }
    public enum Controller
    {

#if PC
        LTouch,
        RTouch
#endif
    }
     public static bool Get(Button virtualMask, Controller hand = Controller.RTouch)
    {
#if PC
        // virtualMask에 들어온 값을 ButtonTarget 타입으로 변환해 전달한다.
        return Input.GetButton(((ButtonTarget)virtualMask).ToString());
#endif
    }

         public static bool GetDown(Button virtualMask, Controller hand = Controller.RTouch)
    {
#if PC
        // virtualMask에 들어온 값을 ButtonTarget 타입으로 변환해 전달한다.
        return Input.GetButtonDown(((ButtonTarget)virtualMask).ToString());
#endif
    }
         public static bool GetUp(Button virtualMask, Controller hand = Controller.RTouch)
    {
#if PC
        // virtualMask에 들어온 값을 ButtonTarget 타입으로 변환해 전달한다.
        return Input.GetButtonUp(((ButtonTarget)virtualMask).ToString());
#endif
    }

    public static Vector3 RHandDirection
    {
        get
        {
#if PC
            Vector3 direction = RHandPosition-Camera.main.transform.position;
            RHand.forward = direction;
            return direction;
#endif
        }
    }
    public static Vector3 RHandPosition
    {
        get
        {
#if PC
            Vector3 pos = Input.mousePosition;
            pos.z = 0.7f;
            pos = Camera.main.ScreenToWorldPoint(pos);
            RHand.position = pos;
            return pos;
#endif
        }
    }
    public static Vector3 LHandPosition
    {
        get
        {
#if PC 
            Vector3 pos = Input.mousePosition;
            pos.z = 0.7f;
            pos = Camera.main.ScreenToWorldPoint(pos);
            LHand.position = pos;
            return pos;
#endif
        }
    }
    public static Vector3 LHandDirection
    {
        get
        {
#if PC 
            Vector3 direction = LHandPosition-Camera.main.transform.position;
            LHand.forward = direction;
            return direction;
#endif
        }
    }
    static Transform lHand;
    
    public static Transform LHand
    {
        get
        {
            if(lHand = null)
            {
#if PC       
                GameObject handObj = new GameObject("LHand");
                lHand = handObj.transform;
                lHand.parent = Camera.main.transform;
#endif             
            }
            return lHand;
        }
    }
    static Transform rHand;
    public static Transform RHand
    {
        get
        {
            if(rHand = null)
            {
#if PC
                GameObject handobj = new GameObject("RHand");
                rHand = handobj.transform;
                rHand.parent = Camera.main.transform;
#endif                
            }
            return rHand;
        }
    }

}
