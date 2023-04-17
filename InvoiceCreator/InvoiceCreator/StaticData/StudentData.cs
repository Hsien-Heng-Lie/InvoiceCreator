using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceCreator.Models;

namespace InvoiceCreator.StaticData
{
    public class StudentData
    {
        public static List<StudentModel> Students { 
            get 
            {
                return listOfStudents;
            } 
        }

        private static List<StudentModel> listOfStudents = new List<StudentModel>()
        {
            new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=2,FirstName="James",LastName="N",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=3,FirstName="John",LastName="B",gradYear=DateTime.Now.Year },
            new StudentModel() {Id=4,FirstName="Hyla",LastName="A",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=5,FirstName="Alwyn",LastName="Z",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=6,FirstName="Emma",LastName="L",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=7,FirstName="Jared",LastName="K",gradYear=DateTime.Now.Year},
            new StudentModel() {Id=8,FirstName="Mike",LastName="Doe",gradYear=DateTime.Now.Year},
        };
    }
}
