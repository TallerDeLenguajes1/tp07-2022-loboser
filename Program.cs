// See https://aka.ms/new-console-template for more information

using System;

namespace TP07
{
    public class Program {
        public static void Main(string[] args)
        {
            var tareasPendientes = new List<Tarea>();
            var tareasRealizadas = new List<Tarea>();

            Console.Write("Cuantas TAREAS PENDIENTES desea crear aleatoriamente?");
            tareasPendientes = CrearListaDeTareas(Convert.ToInt32(Console.ReadLine()));
            
        }

        public static List<Tarea> CrearListaDeTareas(int cantTareas){
            int tareaID = -1;
            string descripcion;
            int duracion;

            var Lista = new List<Tarea>();

            for (int i = 0; i < cantTareas; i++)
            {
                tareaID++;
                descripcion = "Descripcion Generica N" + (i+1);
                duracion = new Random().Next(10,101);
                var Tarea = new Tarea(tareaID, descripcion, duracion);
            }

            return Lista;
        }

        public static void MostrarTareas(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas){
            foreach (var tarea in tareasPendientes)
            {
                Console.WriteLine("\nTarea ID: " + tarea.TareaID);
                Console.WriteLine("Descripcion: " + tarea.Descripcion);
                Console.WriteLine("Duracion: " + tarea.Duracion);
                Console.Write("Se realizo esta tarea? 1 = Si: ");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    MoverTareas(tareasPendientes, tareasRealizadas, tarea.TareaID);
                }

            }
        }

        public static void MoverTareas(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas, int tareaID){
            foreach (var tarea in tareasPendientes)
            {
                if (tarea.TareaID == tareaID)
                {
                    tareasRealizadas.Add(tarea);
                    tareasPendientes.Remove(tarea);
                    break;
                }
            }
        }
    }

    public class Tarea {
        int tareaID; //Numerado en ciclo iterativo
        string descripcion; //
        int duracion; // entre 10 – 100

        public int TareaID{
            get {return tareaID;}
            set {tareaID = value;}
        }

        public string Descripcion{
            get {return descripcion;}
            set {descripcion = value;}
        }

        public int Duracion{
            get {return duracion;}
            set {duracion = value;}
        }

        public Tarea(int TareaID, string Descripcion, int Duracion){
            tareaID = TareaID;
            descripcion = Descripcion;
            duracion = Duracion;
        }
    }
}