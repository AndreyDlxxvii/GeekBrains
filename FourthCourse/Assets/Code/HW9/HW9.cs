using UnityEditor;
using UnityEngine;

namespace CodeGeek.HW9
{
    [RequireComponent(typeof(Rigidbody)), ExecuteInEditMode]
    public class HW9 : MonoBehaviour
    {
        [Header("Тестовая переменная")] [Range(0, 20)] [Space(10)] public int Test;
        [TextArea(4, 5)] [Tooltip("TestTest")] public string TestText;
        [ContextMenuItem("Random num", nameof(Random))] [SerializeField] private int x;

        private void Random()
        {
            x = UnityEngine.Random.Range(0, 20);
        }
        
        [MenuItem("MyMenu/Test №0 %_q")]
        private static void MenuFirst()
        {
            EditorWindow.GetWindow(typeof(TestWindow), false, "Geekbrains");
        }        
        [MenuItem("MyMenu/Test №1 %#q")]
        private static void MenuSecond()
        {
        }        
        [MenuItem("MyMenu/Test №2 %&q")]
        private static void MenuThird()
        {
        }        
        [MenuItem("MyMenu/Test №1/Test-1 %#q")]
        private static void MenuFive()
        {
        }
        [MenuItem("MyMenu/Test №2/Test-2 %&q")]
        private static void MenuFour()
        {
        }


    }
}