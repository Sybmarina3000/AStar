using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
   private Image _image;
   [SerializeField] private Color[] mass;

   private void Start()
   {
      _image = GetComponent<Image>();
   }

   public void ChangeColorImage(int numberColor)
   {
      _image.color = mass[numberColor];
   }

}
