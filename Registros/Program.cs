using System;
using System.Collections.Generic;

namespace Registros
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string name1;
            string address;
            string address1;
            int year;
            string agno;
            int month;
            string mes;
            int day;
            string dia;
            string dni;
            int cert;
            Mantenimiento mant = new Mantenimiento();

            Console.WriteLine("¿Desea ingrear un registro? S/N");
            string resp = Console.ReadLine();
            string resp1 = resp.ToUpper();
            while (resp1 == "S")
            {
                Console.WriteLine("Ingrese nombre y apellido");
                name = Console.ReadLine();
                name1 = name.ToUpper();

                Console.WriteLine("Ingrese domicilio");
                address = Console.ReadLine();
                address1 = address.ToUpper();

                Console.WriteLine("Ingrese día de nacimiento");
                dia = Console.ReadLine();
                Eval ev5 = new Eval("0", "0", dia, "0");
                day = ev5.MandarDia();

                if (day < 1 || day > 31)
                {
                    while (day < 1 || day > 31)
                    {
                        Console.WriteLine("Reingrese día de nacimiento (entre 1 y 31)");
                        dia = Console.ReadLine();
                        Eval ev6 = new Eval("0", "0", dia, "0");
                        day = ev6.MandarDia();
                    }
                }

                Console.WriteLine("Ingrese mes de nacimiento");
                mes = Console.ReadLine();
                Eval ev3 = new Eval("0", mes, "0", "0");
                month = ev3.MandarMes();

                if (month < 1 || month > 12)
                {
                    while (month < 1 || month > 12)
                    {
                        Console.WriteLine("Reingrese mes de nacimiento (entre 1 y 12)");
                        mes = Console.ReadLine();
                        Eval ev4 = new Eval("0", mes, "0", "0");
                        month = ev4.MandarMes();
                    }
                }

                Console.WriteLine("Ingrese año de nacimiento");
                agno = Console.ReadLine();
                Eval ev1 = new Eval(agno, "0", "0", "0");
                year = ev1.MandarAgno();

                if (year < 1900 || year > 2022)
                {
                    while (year < 1900 || year > 2022)
                    {
                        Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                        agno = Console.ReadLine();
                        Eval ev2 = new Eval(agno, "0", "0", "0");
                        year = ev2.MandarAgno();
                    }
                }

                DateTime date1 = new DateTime(year, month, day);

                Console.WriteLine("Ingrese DNI");
                dni = Console.ReadLine();
                Eval ev7 = new Eval("0", "0", "0", dni);
                cert = ev7.MandarDNI();
                if (cert < 1 || cert > 100000000)
                {
                    while (cert < 1 || cert > 100000000)
                    {
                        Console.WriteLine("Reingrese DNI");
                        dni = Console.ReadLine();
                        Eval ev8 = new Eval("0", "0", "0", dni);
                        cert = ev8.MandarDNI();
                    }
                }
                Persona pers = new Persona();
                pers.nombre = name1;
                pers.domicilio = address1;
                pers.fecha = date1;

                mant.Alta(dni, pers);

                Console.WriteLine("¿Desea ingresar otro registro? S/N");
                resp = Console.ReadLine();
                resp1 = resp.ToUpper();
            }
            Console.WriteLine("¿Desea borrar un registro? S/N");
            resp = Console.ReadLine();
            resp1 = resp.ToUpper();
            while (resp1 == "S")
            {
                Console.WriteLine("Ingrese el DNI del registro que desea borrar:");
                dni = Console.ReadLine();
                mant.Borrar(dni);
                Console.WriteLine("¿Desea borrar otro registro? S/N");
                resp = Console.ReadLine();
                resp1 = resp.ToUpper();
            }
            Console.WriteLine("¿Busca algún registro en particular? S/N");
            resp = Console.ReadLine();
            resp1 = resp.ToUpper();
            if (resp1 == "S")
            {
                Console.WriteLine("Ingrese DNI:");
                dni = Console.ReadLine();
                mant.Leer(dni);
            }
            Console.WriteLine("¿Desea leer los registros almacenados? S/N");
            resp = Console.ReadLine();
            resp1 = resp.ToUpper();
            if (resp1 == "S")
            {
                mant.LeerTodo();
            }

        }
    }
    class Persona
    {
        public string nombre
        {
            get;
            set;
        }
        public string domicilio
        {
            get;
            set;
        }
        public DateTime fecha
        {
            get;
            set;
        }

    }
    class Eval
    {
        int year;
        int month;
        int day;
        int cert;
        public Eval(string agno, string mes, string dia, string dni)
        {
            try
            {
                year = int.Parse(agno);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                year = 0;
            }
            try
            {
                month = int.Parse(mes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                month = 0;
            }
            try
            {
                day = int.Parse(dia);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                day = 0;
            }
            try
            {
                cert = int.Parse(dni);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caracteres incorrectos");
                cert = 0;
            }
        }

        public int MandarAgno()
        {
            return year;
        }
        public int MandarMes()
        {
            return month;
        }
        public int MandarDia()
        {
            return day;
        }
        public int MandarDNI()
        {
            return cert;
        }
    }
    class Mantenimiento
    {
        Dictionary<string, Persona> lista = new Dictionary<string, Persona>();
        public void Alta(string dni, Persona per)
        {
            lista.Add(dni, per);
        }
        public void Leer(string dni)
        {
            if (lista.ContainsKey(dni))
            {
                Persona pers = lista[dni];
                Console.WriteLine($"DNI: {dni}. / Nombre: {pers.nombre}. / Domicilio: {pers.domicilio}. / Fecha de nacimiento: {pers.fecha}.");
            }
            else
            {
                Console.WriteLine("No existe ese registro.");
            }
        }
        public void LeerTodo()
        {
            foreach (KeyValuePair<string, Persona> p in lista)
            {
                Persona pers = p.Value;
                Console.WriteLine($"DNI: {p.Key}. / Nombre: {pers.nombre}. / Domicilio: {pers.domicilio}. / Fecha de nacimiento: {pers.fecha}.");
            }
        }
        public void Borrar(string dni)
        {
            lista.Remove(dni);
        }
    }
}
