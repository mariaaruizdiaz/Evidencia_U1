using System;
using System.IO;

class Donador
{
    private string nombre;
    private string apellidoP;
    private string apellidoM;
    private char sexo;
    private DateTime fechaN;
    private DateTime fechaD;
    private string estadoCivil;
    private bool discapacidad;
    private double ingresoM;
    private string correoE;

    //Atributos que se van a calcular
    private int edad;
    private DateTime fechaPD;  //proxima donacion
    private DateTime horaEjercicio;
    private double reembolso;
    private string folio;

    public Donador(string nombre, string apellidoP, string apellidoM, char sexo)
    {
        this.nombre = nombre;
        this.apellidoP = apellidoP;
        this.apellidoM = apellidoM;
        this.sexo = sexo;
    }

    public void setFechaN(DateTime fechaN)
    {
        this.fechaN = fechaN;
    }

    public void setFechaD(DateTime fechaD)
    {
        this.fechaD = fechaD;
    }

    public void setEstadoCivil(string estadoCivil)
    {
        this.estadoCivil = estadoCivil;
    }

    public void setDiscapacidad(bool discapacidad)
    {
        this.discapacidad = discapacidad;
    }

    public void setIngresoM(double ingresoM)
    {
        this.ingresoM = ingresoM;
    }

    public void setCorreoE(string correoE)
    {
        this.correoE = correoE;
    }

    public void calProxDonacion()
    {
        fechaPD = fechaD.AddDays(30.0);
    }

    public void calEdad()
    {
        edad = DateTime.Now.Year - fechaN.Year;
    }

    public void calReembolso()
    {
        reembolso = ingresoM * 0.015;
    }

    public void generarFolio()
    {
        Random rd = new Random();
        int num = rd.Next(1000, 9999);
        int letra = rd.Next(65, 90);
        folio = nombre.Substring(1,1) +apellidoP.Substring(0,1) +
            apellidoM.Substring(2,1) + num.ToString() + ((char)letra);
    }

    public void calHoraEjercicio()
    {
        horaEjercicio = fechaD.AddHours(8);
    }

    public void imprimirFicha()
    {
        System.Console.WriteLine("----------------- FICHA DONADOR -----------------");
        System.Console.WriteLine("Folio: {0}", folio);
        System.Console.WriteLine("Nombre: {0} {1} {2}", nombre, apellidoP, apellidoM);
        System.Console.WriteLine("Sexo: {0}", sexo);
        System.Console.WriteLine("Fecha de Nacimiento: {0}/{1}/{2}", fechaN.Month, fechaN.Day, fechaN.Year);
        System.Console.WriteLine("Edad: {0} años", edad);   
        System.Console.WriteLine("Estado civil: {0}", estadoCivil);
        System.Console.WriteLine("Discapacidad: {0}", discapacidad);
        System.Console.WriteLine("Ingreso mensual: ${0:N2}", ingresoM);
        System.Console.WriteLine("Correo electrónico: {0}", correoE);
        System.Console.WriteLine("-----> Datos de la donacion: ");
        System.Console.WriteLine("Fecha de donación: {0}", fechaD);
        System.Console.WriteLine("Fecha proxima donacion: {0}", fechaPD);
        if(horaEjercicio.Hour <= 9 & horaEjercicio.Minute > 9)
            System.Console.WriteLine("Hora para hacer ejecicio: 0{0}:{1} horas", horaEjercicio.Hour, horaEjercicio.Minute);
        if(horaEjercicio.Hour > 9 & horaEjercicio.Minute <= 9)
            System.Console.WriteLine("Hora para hacer ejecicio: {0}:0{1} horas", horaEjercicio.Hour, horaEjercicio.Minute);
        if(horaEjercicio.Hour <= 9 & horaEjercicio.Minute <= 9)
            System.Console.WriteLine("Hora para hacer ejecicio: 0{0}:0{1} horas", horaEjercicio.Hour, horaEjercicio.Minute);
        if (horaEjercicio.Hour > 9 & horaEjercicio.Minute > 9)
            System.Console.WriteLine("Hora para hacer ejecicio: {0}:{1} horas", horaEjercicio.Hour, horaEjercicio.Minute);
        System.Console.WriteLine("Reembolso: ${0:N2}.", reembolso);
    }

    public void guardarDatos()
    {
        string path = "/Users/maryan/Projects/Evidencia_U1/Evidencia_U1/Archivo.txt";
        string info = folio + "," + nombre + "," + apellidoP + "," + apellidoM + "," + sexo.ToString() + ","
            + fechaN.Month.ToString()+"/" + fechaN.Day.ToString()+"/"+ fechaN.Year.ToString()+","
            + edad.ToString()+ ","+ estadoCivil + "," + discapacidad.ToString() + ","
            + ingresoM.ToString() + "," + correoE + ","+ fechaD.ToString() + ","
            + fechaPD.ToString() + "," + horaEjercicio.Hour.ToString() + ":"
            + horaEjercicio.Minute.ToString() + "," + reembolso.ToString()+ "\n";
        File.AppendAllText(path, info);
    }
}

    class Test
    {
        public static void Main(string[] args)
        {
            string nombre, apellidoP, apellidoM;
            char sexo;

            System.Console.WriteLine(">> INFORMACION DONADOR <<");
            System.Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            System.Console.WriteLine("Apellido paterno: ");
            apellidoP = Console.ReadLine();
            System.Console.WriteLine("Apellido materno: ");
            apellidoM = Console.ReadLine();
            System.Console.WriteLine("Sexo (M)/(F): ");
            sexo = Convert.ToChar(Console.ReadLine());
            //Creacion del objeto donador
            Donador don = new Donador(nombre, apellidoP, apellidoM, sexo);

            System.Console.WriteLine("Fecha de nacimiento: Mes/Dia/Año ");
            string fecha = Console.ReadLine();
            fecha = fecha + " 12:00:00 PM";
            don.setFechaN(Convert.ToDateTime(fecha));
            System.Console.WriteLine("Estado civil: ");
            don.setEstadoCivil(Console.ReadLine());
            System.Console.WriteLine("¿Tiene alguna discapacidad?: S/N ");
            string d = Console.ReadLine();
            if (d.Equals("S"))
                don.setDiscapacidad(true);
            else
                don.setDiscapacidad(false);
            System.Console.WriteLine("Ingreso mensual: ");
            don.setIngresoM(Convert.ToDouble(Console.ReadLine()));
            System.Console.WriteLine("Correo electronico: ");
            don.setCorreoE(Console.ReadLine());
            don.setFechaD(DateTime.Now);

            //Valores que se calculan
            don.calEdad();
            don.calProxDonacion();
            don.calHoraEjercicio();
            don.calReembolso();
            don.generarFolio();

            //Salida de la informacion
            don.imprimirFicha();
            don.guardarDatos();

        }
    }