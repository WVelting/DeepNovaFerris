using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using System;

public class ShipMovement : MonoBehaviour
{
    private Transform playerModel;

    private float fixedTime;
    public float dmfTime;
    public float dmfLength;


    [Header("Settings")]
    public bool joystick = true;

    [Space]

    [Header("Parameters")]
    public float xySpeed = 18;
    public float lookSpeed = 340;
    public float forwardSpeed = 6;

    [Space]

    [Header("Public References")]
    public Transform aimTarget;
    public CinemachineDollyCart dolly;
    public Transform cameraParent;

    [Space]

    [Header("Particles")]
    public ParticleSystem trail;
    public ParticleSystem circle;
    public ParticleSystem barrel;
    public ParticleSystem stars;

    void Start()
    {
        playerModel = transform.GetChild(0);
        SetSpeed(forwardSpeed);
        fixedTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        float h = joystick ? Input.GetAxis("Horizontal") : Input.GetAxis("Mouse X");
        float v = joystick ? Input.GetAxis("Vertical") : Input.GetAxis("Mouse Y");

        LocalMove(h, v, xySpeed);
        RotationLook(h, v, lookSpeed);
        HorizontalLean(playerModel, h, 80, .1f);

        DarkMatterFuel();

        if (Input.GetKeyDown(KeyCode.Space))
            Boost(true);

        if (Input.GetKeyUp(KeyCode.Space))
            Boost(false);

        if (Input.GetButtonDown("Fire3"))
            Break(true);

        if (Input.GetButtonUp("Fire3"))
            Break(false);

        if (Input.GetButtonDown("TriggerL") || Input.GetButtonDown("TriggerR"))
        {
            int dir = Input.GetButtonDown("TriggerL") ? -1 : 1;
            QuickSpin(dir);
        }

    }

    private void DarkMatterFuel()
    {
        float slowDown = 0.35f; // slowdown value

        Time.timeScale = slowDown; // value of timescale is now the slowdown value
        Time.fixedDeltaTime = fixedTime * slowDown; // slows down everything
        dmfTime -= Time.deltaTime; // counts down the timer/length of DMF

        if (dmfTime <= 0)
        {
            //return timer to 0 to prevent any overflow
            dmfTime = 0;
            //return time to normal speed
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedTime * 1;
        }
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float p)
    {
        Vector3 result = new Vector3();

        result.x = Lerp(a.x, b.x, p);
        result.y = Lerp(a.y, b.y, p);
        result.z = Lerp(a.z, b.z, p);

        return result;
    }

    public static float Lerp(float a, float b, float p)
    {
        return (b - a) * p + a;
    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.25f, 0.75f);
        pos.y = Mathf.Clamp(pos.y, 0.35f, 0.7f);
        transform.position = Lerp(transform.position, Camera.main.ViewportToWorldPoint(pos), 0.03f);
    }

    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DarkMatterFuel")
        {
            Destroy(other.gameObject);
            dmfTime = dmfLength;

            
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);

    }

    public void QuickSpin(int dir)
    {
        if (!DOTween.IsTweening(playerModel))
        {
            playerModel.DOLocalRotate(new Vector3(playerModel.localEulerAngles.x, playerModel.localEulerAngles.y, 360 * -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
            barrel.Play();
        }
    }

    void SetSpeed(float x)
    {
        dolly.m_Speed = x;
    }

    void SetCameraZoom(float zoom, float duration)
    {
        cameraParent.DOLocalMove(new Vector3(0, 0, zoom), duration);
    }

    void DistortionAmount(float x)
    {
        Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<LensDistortion>().intensity.value = x;
    }

    void FieldOfView(float fov)
    {
        cameraParent.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView = fov;
    }

    void Chromatic(float x)
    {
        Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<ChromaticAberration>().intensity.value = x;
    }


    void Boost(bool state)
    {

        if (state)
        {
            cameraParent.GetComponentInChildren<CinemachineImpulseSource>().GenerateImpulse();
            trail.Play();
            circle.Play();
        }
        else
        {
            trail.Stop();
            circle.Stop();
        }
        trail.GetComponent<TrailRenderer>().emitting = state;

        float origFov = state ? 40 : 55;
        float endFov = state ? 55 : 40;
        float origChrom = state ? 0 : 1;
        float endChrom = state ? 1 : 0;
        float origDistortion = state ? 0 : -30;
        float endDistorton = state ? -30 : 0;
        float starsVel = state ? -20 : -1;
        float speed = state ? forwardSpeed * 2 : forwardSpeed;
        float zoom = state ? -7 : 0;

        DOVirtual.Float(origChrom, endChrom, .5f, Chromatic);
        DOVirtual.Float(origFov, endFov, .5f, FieldOfView);
        DOVirtual.Float(origDistortion, endDistorton, .5f, DistortionAmount);
        var pvel = stars.velocityOverLifetime;
        pvel.z = starsVel;

        DOVirtual.Float(dolly.m_Speed, speed, .15f, SetSpeed);
        SetCameraZoom(zoom, .4f);
    }

    void Break(bool state)
    {
        float speed = state ? forwardSpeed / 3 : forwardSpeed;
        float zoom = state ? 3 : 0;

        DOVirtual.Float(dolly.m_Speed, speed, .15f, SetSpeed);
        SetCameraZoom(zoom, .4f);
    }
}
