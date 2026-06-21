using UnityEngine;
using UnityEngine.UIElements;

/*
    Hitbox por conversar com o cenário (possivel interação, ou apenas para não passar por ele)
*/
public class HitBoxScenary : HitBox
{
    private const string tag = "Scenary";
    public override void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("HitBoxScenary triggered with: " + collision.gameObject.name);
        if (collision.CompareTag("Scenary") && isEnabled )
        {
            Debug.Log("Hit Scenary!");
            //var scenary = collision.GetComponent<IScenary>();
            //if(scenary != null)
            //{
            //    scenary.Interact();
            //}
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }

}