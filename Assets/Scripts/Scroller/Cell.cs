/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2019 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollView.Example01
{
    public class Cell : FancyScrollViewCell<ItemData>
    {
        [SerializeField] Animator animator = default;
        [SerializeField] Image image = default;

        static class AnimatorHash
        {
            public static readonly int Scroll = Animator.StringToHash("scroll");
        }

        public override void UpdateContent(ItemData itemData)
        {
            image.overrideSprite = itemData.Sprite;
        }

        public override void UpdatePosition(float position)
        {
            currentPosition = position;

            if (animator.isActiveAndEnabled)
            {
                animator.Play(AnimatorHash.Scroll, -1, position);
            }

            animator.speed = 0;
        }

        float currentPosition = 0;

        void OnEnable() => UpdatePosition(currentPosition);
    }
}
