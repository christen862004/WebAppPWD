namespace WebAppPWD.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id=1,Name="Ahmed",Address="Alex",ImageURL= "m.png" });
            students.Add(new Student() { Id=2,Name="Sondos",Address="Alex",ImageURL="2.jpg"});
            students.Add(new Student() { Id=3,Name="Asmaa",Address="Alex",ImageURL="2.jpg"});
            students.Add(new Student() { Id=4,Name="Mohamed",Address="Alex",ImageURL="m.png"});
            students.Add(new Student() { Id=5,Name="David",Address="Alex",ImageURL="m.png"});
        }
        public List<Student> GetAll() {
            return students;
        }
        public Student GetByID(int id)
        {
            return  students.FirstOrDefault(s => s.Id == id);
        }
    }
}
