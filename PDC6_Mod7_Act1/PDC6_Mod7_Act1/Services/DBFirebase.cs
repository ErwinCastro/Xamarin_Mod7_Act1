using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PDC6_Mod7_Act1.Models;
using System.Collections.ObjectModel;
using MvvmHelpers;
using System.Linq;

namespace PDC6_Mod7_Act1.Services
{
   
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdc6mod7-d8c95-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Student")
                .AsObservable<Student>()
                .AsObservableCollection();

            return studentData;
        }
        public async Task AddStudent(int StudentId, string StudentName, string Course, string Year, string Section)
        {
            Student em = new Student() { StudentId = StudentId, StudentName = StudentName, Course = Course, Year = Year, Section = Section };
            await client
                .Child("Student")
                .PostAsync(em);
        }

        public async Task DeleteStudent(int StudentId, string StudentName, string Course, string Year, string Section)
        {

            var toDeleteStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.StudentName == StudentName || a.Object.Course == Course);
            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();


        }

        public async Task UpdateStudent(int StudentId, string StudentName, string Course, string Year, string Section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.StudentName == StudentName);

            Student e = new Student() { StudentId = StudentId, Course = Course, StudentName = StudentName, Year = Year, Section = Section };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(e);

        }
    }
}
