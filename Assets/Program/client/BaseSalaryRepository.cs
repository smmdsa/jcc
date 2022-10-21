namespace Program.client
{
    public class BaseSalaryRepository 
    {
        public static readonly float HR_BASE_SALARY = 500F;
        public static readonly float ENGINEER_BASE_SALARY = 1500F;
        public static readonly float ARTIST_BASE_SALARY = 1200F;
        public static readonly float DESIGN_BASE_SALARY = 800F;
        public static readonly float PM_BASE_SALARY = 2400F;
        public static readonly float CEO_BASE_SALARY = 20000F;
    }
    public class BaseSalaryMultipliersRepository 
    {
        public static readonly float X_1UNIT = 1;
        public static readonly float X_2UNITS = 2;
        public static readonly float X_3UNITS = 3;
        public static readonly float X_SPECIAL_FIBBO = (X_2UNITS + X_3UNITS) / X_3UNITS;
        public static readonly float X_SPECIAL_FIBBO_TIMES_2UNITS = X_2UNITS * X_SPECIAL_FIBBO;
        public static readonly float X_SPECIAL_TWO_HIGH_AVERAGE = (X_2UNITS + X_3UNITS ) / X_2UNITS;
    }
}