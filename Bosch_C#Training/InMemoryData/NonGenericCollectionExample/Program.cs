using System.Collections;

namespace NonGenericCollectionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList
            ArrayList zipcodes = new ArrayList();
            //Boxing- Converting Int to Object type [Reference to value type]
            zipcodes.Add(580030);
            zipcodes.Add(580031);
            zipcodes.Add(580032);
            zipcodes.Add(580033);
            //Unboxing -Converting Object type to Value type
            int firstZip =Convert.ToInt32(zipcodes[0]); 

            Stack books = new Stack();
            Queue queue = new Queue();
            Hashtable hashtable = new Hashtable();
            




        }
    }
}
