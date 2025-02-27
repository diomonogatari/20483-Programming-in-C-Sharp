﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GradesPrototype.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // WPF Databinding requires properties

    // TODO: Exercise 1: Task 1a: Convert Grade into a class and define constructors
    public class Grade
    {
        public int StudentID { get; set; }
        public string AssessmentDate { get; set; }
        public string SubjectName { get; set; }
        public string Assessment { get; set; }
        public string Comments { get; set; }

        #region Constructors
        public Grade(int studentID, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentID = studentID;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }
        //Default constructor
        public Grade()
        {
            StudentID = 0;
            AssessmentDate = DateTime.Now.ToString("d");
            SubjectName = "Math";
            Assessment = "A";
            Comments = String.Empty;
        }
        #endregion
    }

    // TODO: Exercise 1: Task 2a: Convert Student into a class, make the password property write-only, add the VerifyPassword method, and define constructors
    public class Student
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); //Randomly generated pw
        public string Password
        {
            set
            {   //write only
                _password = value;
            }

        }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool VerifyPassword(string pass)
        {
            return String.Compare(pass, _password) == 0;
        }

        #region Constructors
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }
        
        //Default
        public Student()
        {
            StudentID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }
        #endregion
    }

    // TODO: Exercise 1: Task 2b: Convert Teacher into a class, make the password property write-only, add the VerifyPassword method, and define constructors
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); //Randomly generated pw
        public string Password
        {
            set
            {   //write only
                _password = value;
            }

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public bool VerifyPassword(string pass)
        {
            return String.Compare(pass, _password) == 0;
        }

        #region Constructors
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }
        #endregion
    }
}
