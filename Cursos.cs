namespace practicaBBDDyC;
public class Cursos 
{
    public Cursos(int id, string nombreCurso, string familiaProfesional, int horas)
    {
        Id=id;
        NombreCurso=nombreCurso;
        FamiliaProfesional=familiaProfesional;
        Horas=horas;
    }
    public Cursos(){}
    public int Id {get; set;}
    public string NombreCurso {get;set;}
    public string FamiliaProfesional {get; set; }
    public int Horas {get; set;}
}