void Main(string[] args){
    try{
        Console.WriteLine("Please enter your name :");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter your age:");
        int age = int.Parse(Console.ReadLine());
        if(age>70)(
            Console.WriteLine($"Hello {name}, Welcome to racing club!");
        )else{
            Console.WriteLine($"Hello {name}, Sorry you cannot be a part of our Racing club");
        }
    }catch(e){
        Console.WriteLine(e.Message());
    }
}