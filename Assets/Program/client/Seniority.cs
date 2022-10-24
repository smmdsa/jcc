using System;
using System.Collections.Generic;
using NSubstitute.Routing.Handlers;

namespace Program.client
{
    public abstract class Seniority
    {
        public float SeniorityMultiplier
        {
            get => _seniorMultiplier;
            set => _seniorMultiplier = value;
        }
        private float _seniorMultiplier;
        public string SeniorityLabel => seniorityLabel;
        protected string seniorityLabel;
        public string ShortSeniorityLabel => shortSeniorityLabel;
        protected string shortSeniorityLabel;

        public static Seniority CreateNewJunior(float multiplier=1)=>  new Junior(multiplier);
        public static Seniority CreateNewSemiSenior(float multiplier=2)=>  new SemiSenior(multiplier);
        public static Seniority CreateNewSenior(float multiplier=3)=>  new Senior(multiplier);

       
    }

    public class SeniorityFactory
    {
        private static Dictionary<Type, Seniority> SeniorityModifiers => _seniorityModifiers ??= new Dictionary<Type, Seniority>();
        private static Dictionary<Type, Seniority> _seniorityModifiers;
        private static Dictionary<Type, IRoleModifier> RoleModifier => _seniorityModifiersByRol ??= new Dictionary<Type, IRoleModifier>();
        private static Dictionary<Type, IRoleModifier> _seniorityModifiersByRol;
        private static void InitializeSeniorityModifiers(IRoleModifier roleModifier)
        {
            SeniorityModifiers.Clear();
            SeniorityModifiers.Add(typeof(Junior), Seniority.CreateNewJunior(roleModifier.JuniorModifier));
            SeniorityModifiers.Add(typeof(SemiSenior), Seniority.CreateNewSemiSenior(roleModifier.SemiSeniorModifier));
            SeniorityModifiers.Add(typeof(Senior), Seniority.CreateNewSenior(roleModifier.SeniorModifier));
        }
        
        private static void GetModifierData()
        {
            RoleModifier.Clear();
            RoleModifier.Add(typeof(Engineer), new EngineerSeniorityModifier());
            RoleModifier.Add(typeof(Artist), new ArtistSeniorityModifier());
            RoleModifier.Add(typeof(HumanResource), new HumanResourceSeniorityModifier());
            RoleModifier.Add(typeof(Designer), new DesignerSeniorityModifier());
            RoleModifier.Add(typeof(ProjectManager), new ProjectManagerSeniorityModifier());
            RoleModifier.Add(typeof(CEO), new ChiefExecutiveOfficerSeniorityModifier());
        }
        public static Seniority CreateSeniorityFor<TR, TS>(TR role, TS seniority) where TR : IRole where TS : Seniority
        {
            GetModifierData();
            
            var byRol = RoleModifier[role.GetType()];
            InitializeSeniorityModifiers(byRol);
            var output = SeniorityModifiers[seniority.GetType()];
            return output;
        }
        public interface IRoleModifier
        {
            float JuniorModifier { get; }
            float SemiSeniorModifier { get;  }
            float SeniorModifier { get;  }
        }
        public class EngineerSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier => BaseSalaryMultipliersRepository.X_1UNIT;
            public float SemiSeniorModifier => BaseSalaryMultipliersRepository.X_2UNITS;
            public float SeniorModifier => BaseSalaryMultipliersRepository.X_SPECIAL_FIBBO_TIMES_2UNITS;
        }
        public class ArtistSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier => 0; 
            public float SemiSeniorModifier => BaseSalaryMultipliersRepository.X_1UNIT;
            public float SeniorModifier => BaseSalaryMultipliersRepository.X_SPECIAL_FIBBO;
        }
        public class HumanResourceSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier=> BaseSalaryMultipliersRepository.X_1UNIT;
            public float SemiSeniorModifier => BaseSalaryMultipliersRepository.X_2UNITS;
            public float SeniorModifier => BaseSalaryMultipliersRepository.X_3UNITS;
        }
        public class DesignerSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier=> BaseSalaryMultipliersRepository.X_1UNIT;
            public float SemiSeniorModifier => 0; 
            public float SeniorModifier=> BaseSalaryMultipliersRepository.X_SPECIAL_TWO_HIGH_AVERAGE;
        }
        public class ProjectManagerSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier => 0; 
            public float SemiSeniorModifier => BaseSalaryMultipliersRepository.X_1UNIT;
            public float SeniorModifier=> BaseSalaryMultipliersRepository.X_SPECIAL_FIBBO;
        }
        public class ChiefExecutiveOfficerSeniorityModifier : IRoleModifier
        {
            public float JuniorModifier { get; } = 1;
            public float SemiSeniorModifier { get; }= 1;
            public float SeniorModifier { get; }= 1;
            
        }
    }
}