namespace AsteroidGB.HW5.Parse
{
    public class EnemyFactory
    {
        private Units _units;

        public void Create(Units unit)
        {
            switch (unit.unit.type)
            {
                case "mag":
                    new EnemyMage(unit).CreateEnemy();
                    break;
                case "infantry":
                    new EnemyInfantry(unit).CreateEnemy();
                    break;
            }
        }
    }
}