namespace InterfaceExamples
{
    internal class Science : IScience
    {
        string IBiology.BiologyDepartmentLocation()
        {
            return "south";
        }

        string IChemistry.ChemistryDepartmentLocation()
        {
            return "north";
        }

        string Iphysics.PhysicsDepartmentLocation()
        {
            return "east";
        }
    }
}
