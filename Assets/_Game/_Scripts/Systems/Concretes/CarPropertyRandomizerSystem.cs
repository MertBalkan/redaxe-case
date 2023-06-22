namespace RedAxeCase
{
    public class CarPropertyRandomizerSystem : ICarRandomizePart
    {
        private ICarController _carController;
        private PropertyPartPanel _tabPanel;

        private float _carSpeed;
        private float _engineTorque;

        public CarPropertyRandomizerSystem(ICarController carController, PropertyPartPanel tabPanel)
        {
            _carController = carController;
            _tabPanel = tabPanel;
        }
        
        public void Randomize(BasePartPanel partPanel)
        {
            
            _carSpeed = UnityEngine.Random.Range(200, 280);
            _engineTorque = UnityEngine.Random.Range(350, 480);
            
            SetCarProperties();
        }

        private void SetCarProperties()
        {
            _carController.Controller.maxspeed = _carSpeed;
            _carController.Controller.maxEngineTorque = _engineTorque;
            
            _tabPanel.AddNewPart();
        }
    }
}