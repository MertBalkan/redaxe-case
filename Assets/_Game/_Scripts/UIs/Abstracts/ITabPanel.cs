using UnityEngine.UI;

namespace RedAxeCase
{
    public interface ITabPanel
    {
        public void AddNewPart<T>(T partName, Image partImage);
    }
}