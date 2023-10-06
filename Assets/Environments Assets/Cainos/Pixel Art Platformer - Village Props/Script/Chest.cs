using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;
        private winning wonManager;
        private bool opened = false;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]

        private void Start()
        {
            wonManager = GameObject.Find("Chest Golden").GetComponent<winning>();
        }
        private void Update()
        {
            if (!opened)
            {
                if (wonManager.won)
                {
                    isOpened = true;
                    animator.SetBool("IsOpened", isOpened);
                    opened = true;
                }
            }
        }
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
}
