    using UnityEngine;
    using UnityEngine.UIElements;
    public class HitBox : MonoBehaviour, IHitBox
    {
        private bool isEnabled = false;
        public Collider2D hitBoxCollider;
        public SpriteRenderer hitBoxSpriteRenderer;
        public void Enable()
        {
            isEnabled = true;
            hitBoxCollider.enabled = true;
            if(hitBoxSpriteRenderer != null)
            {
                hitBoxSpriteRenderer.enabled = true;
            }
        }

        public void Disable()
        {
            isEnabled = false;
            hitBoxCollider.enabled = false;
            if(hitBoxSpriteRenderer != null)
            {
                hitBoxSpriteRenderer.enabled = false;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("HitBox triggered with: " + collision.gameObject.name);
            if(collision.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy!");
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            return;
        }

        void Start()
        {
            hitBoxCollider = GetComponent<Collider2D>();
            hitBoxSpriteRenderer = GetComponent<SpriteRenderer>();
            Enable();
        }
        void Update()
        {

        }
    }