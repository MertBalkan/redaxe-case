namespace RedAxeCase
{
    public class  CarPropertyRandomizerSystem : ICarRandomizePart
    {
        private ICarController _carController;
        private float _carSpeed;
        private float _engineTorque;

        public CarPropertyRandomizerSystem(ICarController carController)
        {
            _carController = carController;
        }
        
        public void Randomize()
        {
            _carSpeed = UnityEngine.Random.Range(200, 280);
            _engineTorque = UnityEngine.Random.Range(350, 480);
            
            SetCarProperties();
        }

        private void SetCarProperties()
        {
            _carController.Controller.maxspeed = _carSpeed;
            _carController.Controller.maxEngineTorque = _engineTorque;
        }
    }
}