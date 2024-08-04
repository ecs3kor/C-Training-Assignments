namespace InterfaceExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iphysics physics = new Science();
            Console.WriteLine(physics.PhysicsDepartmentLocation());

            IChemistry chemistry = new Science();
            Console.WriteLine(chemistry.ChemistryDepartmentLocation());

            IBiology biology = new Science();
            Console.WriteLine(biology.BiologyDepartmentLocation());

            IScience science = new Science();
            
        }
    }
}
