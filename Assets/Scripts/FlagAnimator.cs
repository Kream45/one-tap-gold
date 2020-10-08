using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimator : MonoBehaviour
{
    [SerializeField] Sprite[] frameArray;
    [SerializeField] float framerate = .1f;
    int currentFrame;
    float timer;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }
}
