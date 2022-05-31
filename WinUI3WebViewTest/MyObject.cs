using System.Runtime.InteropServices;

namespace WinUI3WebViewTest
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MyObject
    {
        public string GetAString(string aString)
        {
            return $"Your string is: {aString}";
        }
    }
}
