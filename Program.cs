namespace EJd;

class Program{
    static void Main(string[] args){
        Dictionary<string, int> dicMateriales = new Dictionary<string, int>();
        dicMateriales.Add("oro", 10);
        dicMateriales.Add("plata", 12);
        dicMateriales.Add("plutonio", 8);
        int menu;
        do{
            menu = ingresarMenu("Bienvenido. Ingrese una opcion: \n1.Ver inventario.\n2.Actualizar/Agregar stock.\n3.Consumir recurso.\n4.Consultar un recurso.\n5.Salir.");
            Console.Clear();
            switch (menu){
                case 1:
                foreach(KeyValuePair<string, int> material in dicMateriales){
                    Console.WriteLine("Material: " + material.Key + " Cantidad: " + material.Value);
                }
                break;
                case 2:
                string materialAIngresar = ingresarString("Ingresar el material a actualizar/agregar: ");
                int cantidadAIngresar = 0;
                if (dicMateriales.ContainsKey(materialAIngresar)){
                    cantidadAIngresar = ingresarNum("Ingresar cantidad de material a agregar: ");
                    dicMateriales[materialAIngresar] += cantidadAIngresar;
                }
                else{
                    cantidadAIngresar = ingresarNum("Ingresar cantidad de material a agregar: ");
                    dicMateriales.Add(materialAIngresar, cantidadAIngresar);
                }
                break;
                case 3:
                string materialARestar = ingresarString("Ingresar el material a consumir: ");
                if (dicMateriales.ContainsKey(materialARestar)){
                    int cantidadARestar = ingresarNum("Ingresar cantidad de material a consumir: ");
                    dicMateriales[materialARestar] -= cantidadARestar;
                }
                else{
                    Console.WriteLine("No se encontro este material.");
                }
                if (dicMateriales[materialARestar] < 5){
                    Console.WriteLine("ALERTA: REABASTECER " + materialARestar);
                }
                break;
                case 4:
                string materialAConsultar = ingresarString("Ingresar el material a consultar: ");
                if (dicMateriales.ContainsKey(materialAConsultar)){
                    Console.WriteLine("Material: " + materialAConsultar);
                    Console.WriteLine("Cantidad: " + dicMateriales[materialAConsultar]);
                }
                else{
                    Console.WriteLine("No se encontro este material.");
                }
                break;
                case 5:
                break;
            }
        }while (menu != 5);

        static int ingresarMenu(string v){
            int n;
            Console.WriteLine(v);
            n = int.Parse(Console.ReadLine());
            while (n < 1 && n > 6){
                Console.WriteLine("Numero fuera del rango. Ingresar de nuevo: ");
                n = int.Parse(Console.ReadLine());
            }
            return n;
        }

        static string ingresarString(string v){
            string s;
            Console.WriteLine(v);
            s = Console.ReadLine().ToLower();
            return s;
        }

        static int ingresarNum(string v){
            int n;
            Console.WriteLine(v);
            n = int.Parse(Console.ReadLine());
            return n;
        }
    }
}
