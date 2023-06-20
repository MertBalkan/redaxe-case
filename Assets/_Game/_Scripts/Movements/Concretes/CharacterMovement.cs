namespace RedAxeCase
{
    public class CharacterMovement : IEntityMovement
    {
        private IEntityController _entity;
        
        public CharacterMovement(IEntityController entity)
        {
            _entity = entity;
        }
        
        public void Move(float direction)
        {
            if(direction == 0) return;

            
        }
    }
}
