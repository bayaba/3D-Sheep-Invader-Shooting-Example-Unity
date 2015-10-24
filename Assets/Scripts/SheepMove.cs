using UnityEngine;
using System.Collections;

public class SheepMove : MonoBehaviour
{
    Animator anim;
    public GameObject Glass;
    Camera UICam;
    GlassManager Gmanager;
    ExplosionManager Emanager;
    public bool isDead = false;

    void Start()
    {
        UICam = GameObject.Find("UICamera").GetComponent<Camera>();
        Gmanager = GameObject.Find("GlassManager").GetComponent<GlassManager>();
        Emanager = GameObject.Find("ExplosionManager").GetComponent<ExplosionManager>();
        anim = GetComponent<Animator>();
    }

	void OnEnable()
	{
        LeanTween.move(gameObject, new Vector3(transform.position.x, -transform.position.x / 9f, 1.0f), 3.0f).setOnComplete(FirstJump);
	}
	
	void FirstJump()
	{
        anim.Play("jump", -1, 0f);

        float ypos = transform.position.y;
        LeanTween.moveY(gameObject, 2.1f, 1.0f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveY(gameObject, ypos - 0.5f, 1.0f).setDelay(1.0f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveZ(gameObject, -3.0f, 2.0f).setOnComplete(SecondJump);
    }

    void SecondJump()
    {
        anim.Play("jump", -1, 0f);

        float ypos = transform.position.y;
        LeanTween.moveY(gameObject, Random.Range(2f, 4f), 1.0f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveY(gameObject, ypos - 2.0f, 1.5f).setDelay(1.0f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveZ(gameObject, -8f, 2.0f).setOnComplete(Window);
    }

    void Window()
    {
        if (!isDead)
        {
            anim.Play("window");
            LeanTween.cancel(gameObject);
            LeanTween.moveY(gameObject, -6f, 2.5f).setEase(LeanTweenType.easeInCubic).setOnComplete(Complete);

            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos.z = 1f;
            Gmanager.SendMessage("CreateGlass", UICam.ScreenToWorldPoint(pos));
            isDead = true;
        }
    }

    void HitSheep()
    {
        if (!isDead)
        {
            audio.Play();
            anim.Play("dead");
            LeanTween.cancel(gameObject);

            float ypos = transform.position.y;
            LeanTween.moveY(gameObject, ypos + 6.0f, 1.5f).setEase(LeanTweenType.easeOutCubic);
            LeanTween.moveY(gameObject, ypos, 1.5f).setEase(LeanTweenType.easeInCubic).setDelay(1.5f);
            LeanTween.moveZ(gameObject, 18f, 3.0f).setEase(LeanTweenType.easeOutCubic).setOnComplete(Complete);

            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos.z = 3.5f;
            Emanager.SendMessage("CreateExplosion", UICam.ScreenToWorldPoint(pos));
            isDead = true;
        }
    }

    void Complete()
    {
        isDead = false;
        LeanTween.cancel(gameObject);
        gameObject.SetActive(false);
    }
}
